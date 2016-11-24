/*	
	lorakon_inp - Sample input form for Genie2k
    Copyright (C) 2016  Norwegian Radiation Protection Authority

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
// Authors: Dag Robole,
using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Win32;

namespace lorakon
{
    public partial class FormSampleInput : Form
    {
        // Flag used to keep track of initialization in the paint event (Avoid displaying forms/messages in the load event)
        bool Initialized = false;

        string NumSep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        string NL = Environment.NewLine;

        Settings settings = new Settings();

        // Encoding used for config files
        Encoding enc = Encoding.GetEncoding(1252);

        // Registry key for the Genie2k installation path
        const string GenieRegistry = @"SOFTWARE\Wow6432Node\Canberra Industries, Inc.\Genie-2000 Environment";        

        // Filename for input parameters
        const string InputBase = "input-params.txt";

        // Filename for sample types
        const string SampleTypeBase = "sample-types.xml";

        // Filename for geometry types
        const string GeometryTypeBase = "geometry-types.txt";

        // Filename for counties/communities
        const string CommunitiesBase = "communities.txt";

        // Filename for location types
        const string LocationTypeBase = "location-types.txt";        

        // Paths for configuration files        
        string GeniePath, LorakonPath, SystemPath;
        string SettingsFile, SampleTypeFile, GeometryTypeFile, InputFile, CommunitiesFile, LocationTypeFile;
        
        AutoCompleteStringCollection communities = new AutoCompleteStringCollection();

        ToolTip Tip = new ToolTip();
        ToolTip TipRequired = new ToolTip();
        ToolTip TipOptional = new ToolTip();

        FormAbout about = new FormAbout();

        public FormSampleInput()
        {
            InitializeComponent();            
        }        

        private void FormSampleInput_Load(object sender, EventArgs e)
        {
            statusLabel.Text = String.Empty;

            // Limit max length of fields
            tbLab.TextChanged += CustomEvents.Crop16_TextChanged;
            tbScollName.TextChanged += CustomEvents.Crop24_TextChanged;
            tbSTitle.TextChanged += CustomEvents.Crop64_TextChanged;
            tbSIdent.TextChanged += CustomEvents.Crop16_TextChanged;            
            tbAltitude.TextChanged += CustomEvents.Crop16_TextChanged;
            tbSLoctn.TextChanged += CustomEvents.Crop255_TextChanged;
            tbSQuant.TextChanged += CustomEvents.Crop16_TextChanged;
            tbSQuantErr.TextChanged += CustomEvents.Crop16_TextChanged;            
            tbSSyserr.TextChanged += CustomEvents.Crop8_TextChanged;
            tbSSysterr.TextChanged += CustomEvents.Crop8_TextChanged;
            tbComment.TextChanged += CustomEvents.Crop255_TextChanged;
            tbLatitude.TextChanged += CustomEvents.Coordinate_TextChanged;
            tbLongitude.TextChanged += CustomEvents.Coordinate_TextChanged;

            // Force format of fields
            tbSQuant.KeyPress += CustomEvents.UnsignedNumeric_KeyPress;
            tbSQuantErr.KeyPress += CustomEvents.UnsignedNumeric_KeyPress;            
            tbAltitude.KeyPress += CustomEvents.SignedNumeric_KeyPress;            
            tbSSyserr.KeyPress += CustomEvents.UnsignedNumeric_KeyPress;
            tbSSysterr.KeyPress += CustomEvents.UnsignedNumeric_KeyPress;
            tbLatitude.KeyPress += CustomEvents.Latitude_KeyPress;
            tbLongitude.KeyPress += CustomEvents.Longitude_KeyPress;

            // Set up tooltips
            Tip.ToolTipTitle = "";            
            Tip.SetToolTip(btnBrowseSampleType, "Velg prøvetype fra meny");
            Tip.SetToolTip(btnCoordsClear, "Tøm felter for koordinater");

            TipRequired.ToolTipTitle = "Påkrevet";
            TipRequired.SetToolTip(lblLabOperator, "Skriv inn navn på laboratorium og operator");
            TipRequired.SetToolTip(lblSampleID, "Skriv inn identifikasjon til prøven");
            TipRequired.SetToolTip(lblSampleType, "Velg prøvetype");
            TipRequired.SetToolTip(lblQuantityQuantErr, "Skriv inn prøvemengde og absolutt usikkerhet");
            TipRequired.SetToolTip(lblQuantityUnitGeometry, "Velg prøvemengde enhet og geometri");
            TipRequired.SetToolTip(lblRefDate, "Velg referansedato");

            TipOptional.ToolTipTitle = "Valgfri";
            TipOptional.SetToolTip(lblProject, "Skriv inn navn på prosjekt/oppdrag");
            TipOptional.SetToolTip(lblSampleComponent, "Velg hvilken del av prøven det har blitt målt på");
            TipOptional.SetToolTip(lblCommunity, "Velg kommune/fylke der prøven ble tatt");
            TipOptional.SetToolTip(lblCoords, "Breddegrad, Lengdegrad, Meter over havet" + NL + NL 
                + "Format på koordinater: " + NL + "61° 34' 12\" N   11° 67' 20\" E" + NL + "61° 34" + NumSep + "23' N   11° 67" + NumSep + "33' E" 
                + NL + "61" + NumSep + "543478° N   11" + NumSep + "776344° E" + NL + "61" + NumSep + "543478   -11" + NumSep + "776344" + NL + NL + "° kan erstattes med *");
            TipOptional.SetToolTip(cboxLocation, "Velg lokasjons informasjon...");
            TipOptional.SetToolTip(lblSysErrSystErr, "Skriv inn tilfeldig usikkerhet og system usikkerhet");
        }

        private void FormSampleInput_Paint(object sender, PaintEventArgs e)
        {
            if (!Initialized)
            {                
                try
                {
                    Initialized = true;                                        

                    // Check and initialize environment
                    GeniePath = GetGeniePath();
                    if (String.IsNullOrEmpty(GeniePath))
                    {
                        MessageBox.Show("Genie2k katalog ble ikke funnet");
                        Environment.Exit(1);                        
                    }

                    LorakonPath = GeniePath + "Lorakon\\";
                    if (!Directory.Exists(LorakonPath))                    
                        Directory.CreateDirectory(LorakonPath);                    

                    SystemPath = LorakonPath + "System\\";
                    if (!Directory.Exists(SystemPath))
                        Directory.CreateDirectory(SystemPath);

                    string InstallDir = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + Path.DirectorySeparatorChar;

                    SettingsFile = SystemPath + "settings.xml";
                    if (!File.Exists(SettingsFile))                    
                        SaveSettings();

                    LoadSettings();

                    GeometryTypeFile = SystemPath + GeometryTypeBase;
                    if (!File.Exists(GeometryTypeFile))
                    {
                        if(!File.Exists(InstallDir + "template_geometry-types.txt"))
                        {
                            MessageBox.Show("Finner ikke filen " + InstallDir + "template_geometry-types.txt");
                            Close();
                        }
                        File.Copy(InstallDir + "template_geometry-types.txt", GeometryTypeFile, true);
                    }

                    SampleTypeFile = SystemPath + SampleTypeBase;
                    if (!File.Exists(SampleTypeFile))
                    {
                        if (!File.Exists(InstallDir + "template_sample-types.xml"))
                        {
                            MessageBox.Show("Finner ikke filen " + InstallDir + "template_sample-types.xml");
                            Close();
                        }
                        File.Copy(InstallDir + "template_sample-types.xml", SampleTypeFile, true);
                    }

                    CommunitiesFile = SystemPath + CommunitiesBase;
                    if (!File.Exists(CommunitiesFile))
                    {
                        if (!File.Exists(InstallDir + "template_communities.txt"))
                        {
                            MessageBox.Show("Finner ikke filen " + InstallDir + "template_communities.txt");
                            Close();
                        }
                        File.Copy(InstallDir + "template_communities.txt", CommunitiesFile, true);
                    }

                    LocationTypeFile = SystemPath + LocationTypeBase;
                    if (!File.Exists(LocationTypeFile))
                    {
                        if (!File.Exists(InstallDir + "template_location-types.txt"))
                        {
                            MessageBox.Show("Finner ikke filen " + InstallDir + "template_location-types.txt");
                            Close();
                        }
                        File.Copy(InstallDir + "template_location-types.txt", LocationTypeFile, true);
                    }                    

                    // Load communities
                    string[] communitiesList = File.ReadAllLines(CommunitiesFile, enc);
                    communities.AddRange(communitiesList);
                    cboxCommunity.Items.AddRange(communitiesList);
                    cboxCommunity.AutoCompleteCustomSource = communities;

                    // Load geometry types                    
                    string[] geomTypes = File.ReadAllLines(GeometryTypeFile, enc);
                    cboxSGeomtry.Items.AddRange(geomTypes);

                    // Load sample types
                    string[] sampTypes = GetSampleTypes();
                    foreach(string st in sampTypes)                    
                        cboxSampleType.Items.Add(new SampleType(GetLabelFromSampleType(st), st));

                    // Load location types                    
                    string[] locTypes = File.ReadAllLines(LocationTypeFile, enc);
                    cboxLocation.Items.AddRange(locTypes);                                        

                    DateTime now = DateTime.Now;
                    dtpSDate.Value = now;
                    dtpSTime.Value = new DateTime(now.Year, now.Month, now.Day, 12, 0, 0);

                    InputFile = SystemPath + InputBase;
                    if (File.Exists(InputFile))
                    {
                        // Load params from file                    
                        string[] lines = File.ReadAllLines(InputFile, enc);

                        if(lines.Length > 0)
                            tbLab.Text = PrepareStringParam(lines[0], typeof(String), tbLab.MaxLength);
                        if (lines.Length > 1)
                            tbScollName.Text = PrepareStringParam(lines[1], typeof(String), tbScollName.MaxLength);
                        if (lines.Length > 2)
                            tbSTitle.Text = PrepareStringParam(lines[2], typeof(String), tbSTitle.MaxLength);
                        if (lines.Length > 3)
                        {
                            string st = PrepareStringParam(lines[3], typeof(String), cboxSampleType.MaxLength);                            
                            if (!String.IsNullOrEmpty(st))
                            {
                                string sampType = GetLabelFromSampleType(st);
                                if(SampleTypeExists(sampType))
                                    cboxSampleType.Text = sampType;
                            }                                
                        }
                        if (lines.Length > 4)
                        {
                            string comp = PrepareStringParam(lines[4], typeof(String), cboxComponent.MaxLength);
                            if (!String.IsNullOrEmpty(comp))
                            {
                                if(cboxComponent.Items.Contains(comp))
                                    cboxComponent.Text = comp;
                            }
                        }
                        if (lines.Length > 5)
                            tbSIdent.Text = PrepareStringParam(lines[5], typeof(String), tbSIdent.MaxLength);
                        if (lines.Length > 6)
                            if (communities.Contains(lines[6]))
                                cboxCommunity.Text = lines[6];
                        if (lines.Length > 7)
                            tbLatitude.Text = PrepareStringParam(lines[7], typeof(Double), tbLatitude.MaxLength);
                        if (lines.Length > 8)
                            tbLongitude.Text = PrepareStringParam(lines[8], typeof(Double), tbLongitude.MaxLength);
                        if (lines.Length > 9)
                            tbAltitude.Text = PrepareStringParam(lines[9], typeof(Double), tbAltitude.MaxLength);
                        if (lines.Length > 10)
                        {
                            string loc = PrepareStringParam(lines[10], typeof(String), cboxLocation.MaxLength);
                            if(!String.IsNullOrEmpty(loc))
                                cboxLocation.Text = loc;
                            cboxLocation_SelectedIndexChanged(sender, e);
                        }
                        if (lines.Length > 11)
                            tbSLoctn.Text = PrepareStringParam(lines[11], typeof(String), tbSLoctn.MaxLength);
                        if (lines.Length > 12)
                            tbSQuant.Text = PrepareStringParam(lines[12], typeof(float), tbSQuant.MaxLength);
                        if (lines.Length > 13)
                            tbSQuantErr.Text = PrepareStringParam(lines[13], typeof(float), tbSQuantErr.MaxLength);
                        if (lines.Length > 14)
                        {
                            string unit = PrepareStringParam(lines[14], typeof(String), cboxSUnits.MaxLength);
                            if(!String.IsNullOrEmpty(unit))
                                cboxSUnits.Text = unit;
                        }
                        if (lines.Length > 15)
                        {
                            string geom = PrepareStringParam(lines[15], typeof(String), cboxSGeomtry.MaxLength);
                            if(!String.IsNullOrEmpty(geom))
                                cboxSGeomtry.Text = geom;
                        }
                        if (lines.Length > 16)
                        {
                            string sdt = PrepareStringParam(lines[16], typeof(DateTime), 100);
                            if (!String.IsNullOrEmpty(sdt))
                            {
                                DateTime dt = Convert.ToDateTime(sdt);
                                dtpSDate.Value = dt;
                                dtpSTime.Value = dt;
                            }
                        }
                        if (lines.Length > 17)
                            tbSSyserr.Text = PrepareStringParam(lines[17], typeof(float), tbSSyserr.MaxLength);
                        if (lines.Length > 18)
                            tbSSysterr.Text = PrepareStringParam(lines[18], typeof(float), tbSSysterr.MaxLength);
                        if (lines.Length > 19)
                            tbComment.Text = PrepareStringParam(lines[19], typeof(String), tbComment.MaxLength);
                    }                    

                    FormSampleInput_Resize(sender, e);  

                    try
                    {
                        double lat = Convert.ToDouble(tbLatitude.Text.Trim());
                        double lon = Convert.ToDouble(tbLongitude.Text.Trim());
                        double alt = Convert.ToDouble(tbAltitude.Text.Trim());

                        if (lat == 0.0 && lon == 0.0 && alt == 0.0)
                            linkClearCoords_Click(sender, e);
                    }
                    catch { }
                    
                    if(String.IsNullOrEmpty(tbLab.Text.Trim()))
                    {
                        if(settings.UseStoredLaboratoryName)
                        {
                            if (String.IsNullOrEmpty(settings.StoredLaboratoryName))
                            {
                                tbLab.Enabled = true;
                            }
                            else
                            {
                                tbLab.Text = settings.StoredLaboratoryName;
                                tbLab.Enabled = false;
                            }
                        }
                        else
                        {
                            tbLab.Enabled = true;
                        }                        
                    }
                    else
                    {
                        tbLab.Enabled = false;
                    }

                    tbScollName.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        string GetGeniePath()
        {
            RegistryKey rk = Registry.LocalMachine.OpenSubKey(GenieRegistry, false);
            String value = (String)rk.GetValue("GENIE2K");
            if (!String.IsNullOrEmpty(value))
                return value;

            if (Directory.Exists("C:\\GENIE2K\\"))
                return "C:\\GENIE2K\\";

            return String.Empty;
        }

        private void LoadSettings()
        {
            // Deserialize settings from file
            using (StreamReader sr = new StreamReader(SettingsFile))
            {
                XmlSerializer x = new XmlSerializer(settings.GetType());
                settings = x.Deserialize(sr) as Settings;
            }
        }

        private void SaveSettings()
        {
            // Serialize settings to file
            using (StreamWriter sw = new StreamWriter(SettingsFile))
            {
                XmlSerializer x = new XmlSerializer(settings.GetType());
                x.Serialize(sw, settings);
            }
        }

        private string PrepareStringParam(string s, Type type, int siz)
        {
            if (s.Length > siz)
                return String.Empty;

            try
            {
                if (type == typeof(Int32))
                    Convert.ToInt32(s);
                else if (type == typeof(float))
                    Convert.ToSingle(s);
                else if (type == typeof(double))
                    Convert.ToDouble(s);
                else if (type == typeof(DateTime))
                    Convert.ToDateTime(s);
            }
            catch
            {
                return String.Empty;
            }

            return s;
        }

        private string[] GetSampleTypes()
        {
            List<string> sampleTypes = new List<string>();
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(SampleTypeFile);
                XmlElement root = doc.DocumentElement;
                AddSampleTypes(root, ref sampleTypes);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return sampleTypes.ToArray();
        }

        private void AddSampleTypes(XmlNode node, ref List<string> sampleTypes)
        {
            foreach (XmlNode n in node.ChildNodes)
            {
                if (n.NodeType == XmlNodeType.Element && n.Name.ToLower() == "sampletype")
                {
                    sampleTypes.Add(GetNodePath(n));
                    AddSampleTypes(n, ref sampleTypes);
                }
            }
        }

        private string GetNodePath(XmlNode node)
        {
            string path = node.Attributes["name"].InnerText;
            XmlNode search = null;
            while ((search = node.ParentNode).Name.ToLower() != "sampletypes")
            {
                path = search.Attributes["name"].InnerText + "/" + path;
                node = search;
            }
            return path;
        }

        private string GetSampleTypeFromLabel(string lbl)
        {
            string[] items = lbl.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
            if (items.Length > 0)
                return items[1];
            else return String.Empty;
        }

        private string GetLabelFromSampleType(string st)
        {
            string[] items = st.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (items.Length > 0)
                return items[items.Length - 1] + " -> " + st;
            else return String.Empty;
        }

        private bool SampleTypeExists(string stName)
        {
            foreach(SampleType st in cboxSampleType.Items)
            {
                if (st.Name == stName)
                    return true;
            }
            return false;
        }

        private void btnBrowseSampleType_Click(object sender, EventArgs e)
        {
            FormSampleTypes form = new FormSampleTypes(SampleTypeFile);
            if(form.ShowDialog() == DialogResult.OK)
            {
                cboxSampleType.Text = GetLabelFromSampleType(form.SelectedSampleType);
                cboxSampleType_SelectedIndexChanged(sender, e);
            }
        }

        private void FormSampleInput_Resize(object sender, EventArgs e)
        {
            tbLab.Width = panelLab.Width / 2;            
            tbLatitude.Width = panelCoords.Width / 3;
            tbAltitude.Width = panelCoords.Width / 3;
            tbSQuant.Width = panelSampleQuant.Width / 2;
            cboxSUnits.Width = panelUnitGeom.Width / 2;
            dtpSDate.Width = panelReferenceDate.Width / 2;
            tbSSyserr.Width = panelError.Width / 2;            
        }        

        private void cboxLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSLoctn.Enabled = true;
            if (cboxLocation.Text.Trim() == String.Empty)
            {
                tbSLoctn.Text = String.Empty;
                tbSLoctn.Enabled = false;
            }
        }

        private void linkClearCoords_Click(object sender, EventArgs e)
        {
            tbLatitude.Text = String.Empty;
            tbLongitude.Text = String.Empty;
            tbAltitude.Text = String.Empty;
        }

        private void cboxSampleType_SelectedIndexChanged(object sender, EventArgs e)
        {            
            string sampleType = GetSampleTypeFromLabel(cboxSampleType.Text);
            string[] items = sampleType.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(SampleTypeFile);

                cboxComponent.Items.Clear();
                cboxComponent.Items.Add("");
                cboxComponent.Text = String.Empty;
                string samplePath = "/";
                foreach (string st in items)
                {
                    samplePath += "/sampletype[@name='" + st + "']";
                    XmlNodeList componentNodes = xmlDoc.SelectNodes(samplePath + "/component");
                    foreach (XmlNode sNode in componentNodes)
                        cboxComponent.Items.Insert(1, sNode.Attributes["name"].InnerText);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            about.ShowDialog();            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;            

            // Sanity checks for input fields
            if(String.IsNullOrEmpty(tbLab.Text.Trim()) 
                || String.IsNullOrEmpty(tbScollName.Text.Trim())
                || String.IsNullOrEmpty(tbSIdent.Text.Trim())
                || String.IsNullOrEmpty(cboxSampleType.Text.Trim())
                || String.IsNullOrEmpty(cboxSUnits.Text.Trim())
                || String.IsNullOrEmpty(cboxSGeomtry.Text.Trim())
                || String.IsNullOrEmpty(tbSQuant.Text.Trim()) 
                || String.IsNullOrEmpty(tbSQuantErr.Text.Trim()))
            {
                statusLabel.Text = "En eller flere påkrevde felter mangler";
                return;
            }

            if (!String.IsNullOrEmpty(cboxCommunity.Text.Trim()) && !communities.Contains(cboxCommunity.Text))
            {
                statusLabel.Text = "Du må velge en gyldig kommune";
                return;
            }            

            if (!CustomEvents.ValidateSignedNumeric(tbAltitude.Text))
            {
                statusLabel.Text = "Høyde over havet er ugyldig";
                return;
            }

            if(cboxLocation.Text.Trim() != String.Empty && tbSLoctn.Text.Trim() == String.Empty)
            {
                statusLabel.Text = "Lokasjon info mangler";
                return;
            }

            if (!CustomEvents.ValidateUnsignedNumeric(tbSQuant.Text))
            {
                statusLabel.Text = "Ugyldig prøvemengde";
                return;
            }
            
            double sq = Convert.ToDouble(tbSQuant.Text.Trim());
            if (sq <= 0.0)
            {
                statusLabel.Text = "Prøvemengde må være større enn 0";
                return;
            }

            if (!CustomEvents.ValidateUnsignedNumeric(tbSQuantErr.Text))
            {
                statusLabel.Text = "Ugyldig prøvemengde error";
                return;
            }

            if (!CustomEvents.ValidateUnsignedNumeric(tbSSyserr.Text))
            {
                statusLabel.Text = "Ugyldig random error";
                return;
            }

            if (!CustomEvents.ValidateUnsignedNumeric(tbSSysterr.Text))
            {
                statusLabel.Text = "Ugyldig system error";
                return;
            }            

            if(!SampleTypeExists(cboxSampleType.Text))
            {
                cboxSampleType.Focus();
                statusLabel.Text = "Du må velge en gyldig prøvetype";
                return;
            }

            double lat = 0.0, lon = 0.0, alt = 0.0;
            try
            {
                if (tbLatitude.Text.Trim() != string.Empty)
                {
                    lat = GetLatitude(tbLatitude.Text.Trim());
                    if(lat > 90 || lat < -90)                
                        throw new Exception("Breddegrad er utenfor gyldig område");                    
                }

                if (tbLongitude.Text.Trim() != string.Empty)
                {
                    lon = GetLongitude(tbLongitude.Text.Trim());
                    if (lon > 180 || lon < -180)                    
                        throw new Exception("Lengdegrad er utenfor gyldig område");                    
                }
            }
            catch(Exception ex)
            {
                statusLabel.Text = ex.Message;
                return;
            }
            
            try
            {
                if (tbAltitude.Text.Trim() != string.Empty)
                {
                    alt = Convert.ToDouble(tbAltitude.Text.Trim());
                    // 10994: Depth of the Challenger Deep
                    // 480000: Thinkness of the atmosphere
                    if (alt < -10994.0 || alt > 480000)                    
                        throw new Exception("Høyde over havet er ugyldig");
                }
            }
            catch(Exception ex)
            {
                statusLabel.Text = ex.Message;
                return;
            }

            try
            {
                if (tbSSyserr.Text.Trim() != string.Empty)
                {
                    double syserr = Convert.ToDouble(tbSSyserr.Text.Trim());
                    if (syserr < 0.0 || syserr > 100.0)
                    {
                        statusLabel.Text = "Random Error er ugyldig";
                        return;
                    }
                }

                if (tbSSysterr.Text.Trim() != string.Empty)
                {
                    double systerr = Convert.ToDouble(tbSSysterr.Text.Trim());
                    if (systerr < 0.0 || systerr > 100.0)
                    {
                        statusLabel.Text = "System Error er ugyldig";
                        return;
                    }
                }
            }
            catch
            {
                statusLabel.Text = "Ugyldige Error verdier funnet";
                return;
            }

            settings.StoredLaboratoryName = tbLab.Text.Trim();

            // Store params to file
            try
            {
                DateTime dt = new DateTime(dtpSDate.Value.Year, dtpSDate.Value.Month, dtpSDate.Value.Day, dtpSTime.Value.Hour, dtpSTime.Value.Minute, dtpSTime.Value.Second);

                string c = settings.StoredLaboratoryName + NL +
                    tbScollName.Text.Trim() + NL +
                    tbSTitle.Text.Trim() + NL +
                    GetSampleTypeFromLabel(cboxSampleType.Text) + NL +
                    cboxComponent.Text.Trim() + NL +
                    tbSIdent.Text.Trim() + NL +
                    cboxCommunity.Text.Trim() + NL +
                    lat.ToString("##0.0#####") + NL +
                    lon.ToString("##0.0#####") + NL +
                    alt.ToString() + NL +
                    cboxLocation.Text.Trim() + NL +
                    tbSLoctn.Text.Trim() + NL +
                    tbSQuant.Text.Trim() + NL +
                    tbSQuantErr.Text.Trim() + NL +
                    cboxSUnits.Text.Trim() + NL +
                    cboxSGeomtry.Text.Trim() + NL +
                    dt.ToString("yyyy-MM-dd hh:mm:ss") + NL +
                    (String.IsNullOrEmpty(tbSSyserr.Text.Trim()) ? "0" : tbSSyserr.Text.Trim()) + NL +
                    (String.IsNullOrEmpty(tbSSysterr.Text.Trim()) ? "0" : tbSSysterr.Text.Trim()) + NL +
                    tbComment.Text.Trim() + NL + NL;

                File.WriteAllText(InputFile, c, enc);
                SaveSettings();

                DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(1);
            }
            
            Environment.Exit(0);
        }

        private int GetGroupSuccesses(Match m)
        {
            int nSuccesses = 0;
            foreach (Group g in m.Groups)
            {
                if (g.Success)
                    nSuccesses++;
            }
            return nSuccesses;
        }

        private double GetLatitude(string input)
        {
            double lat = 0;
            input = input.Replace('°', '*');
            Regex regex = new Regex("^(\\d{1,2})\\*?\\s+(\\d{1,2})'?\\s+(\\d{1,2})\"?\\s*([NS])$");
            Match match = regex.Match(input);
            if(match.Success)
            {
                // Degrees, Minutes, Seconds
                if (GetGroupSuccesses(match) != 5)                
                    throw new Exception("Ugyldig format på breddegrad");
                
                double degree = Convert.ToDouble(match.Groups[1].Value);
                double minutes = Convert.ToDouble(match.Groups[2].Value);
                double seconds = Convert.ToDouble(match.Groups[3].Value);
                    
                lat = degree + (minutes / 60.0) + (seconds / 3600.0);

                if (match.Groups[4].Value == "S")
                    lat = -lat;                                        
                
                return lat;
            }

            regex = new Regex("^(\\d{1,2})\\*?\\s+(\\d{1,2}" + NumSep + "?\\d{0,6})'?\\s*([NS])$");
            match = regex.Match(input);
            if (match.Success)
            {
                // Degrees, Minutes
                if (GetGroupSuccesses(match) != 4)                
                    throw new Exception("Ugyldig format på breddegrad");
                
                double degree = Convert.ToDouble(match.Groups[1].Value);
                double minutes = Convert.ToDouble(match.Groups[2].Value);                    

                //degrees = degrees + minutes / 60
                lat = degree + minutes / 60.0;

                if (match.Groups[3].Value == "S")
                    lat = -lat;
                
                return lat;                
            }

            regex = new Regex("^(\\d{1,2}" + NumSep + "?\\d{0,6})\\*?\\s*([NS])$");
            match = regex.Match(input);
            if (match.Success)
            {
                // Desimalgrader
                if (GetGroupSuccesses(match) != 3)
                    throw new Exception("Ugyldig format på breddegrad");

                lat = Convert.ToDouble(match.Groups[1].Value);
                if (match.Groups[2].Value == "S")
                    lat = -lat;
                                
                return lat;
            }

            regex = new Regex("^(-?\\d{1,2}" + NumSep + "?\\d{0,6})$");
            match = regex.Match(input);
            if (match.Success)
            {
                // Desimal
                if (GetGroupSuccesses(match) != 2)
                    throw new Exception("Ugyldig format på breddegrad");
                
                lat = Convert.ToDouble(match.Groups[1].Value);                                    

                return lat;
            }

            throw new Exception("Ugyldig format på breddegrad");
        }

        private double GetLongitude(string input)
        {
            double lon = 0;
            input = input.Replace('°', '*');
            Regex regex = new Regex("^(\\d{1,3})\\*?\\s+(\\d{1,2})'?\\s+(\\d{1,2})\"?\\s*([EW])$");
            Match match = regex.Match(input);
            if (match.Success)
            {
                // Degrees, Minutes, Seconds
                if (GetGroupSuccesses(match) != 5)
                    throw new Exception("Ugyldig format på lengdegrad");
                
                double degree = Convert.ToDouble(match.Groups[1].Value);
                double minutes = Convert.ToDouble(match.Groups[2].Value);
                double seconds = Convert.ToDouble(match.Groups[3].Value);

                lon = degree + (minutes / 60.0) + (seconds / 3600.0);

                if (match.Groups[4].Value == "W")
                    lon = -lon;
                
                return lon;
            }

            regex = new Regex("^(\\d{1,3})\\*?\\s+(\\d{1,2}" + NumSep + "?\\d{0,6})'?\\s*([EW])$");
            match = regex.Match(input);
            if (match.Success)
            {
                // Degrees, Minutes
                if (GetGroupSuccesses(match) != 4)
                    throw new Exception("Ugyldig format på lengdegrad");
                
                double degree = Convert.ToDouble(match.Groups[1].Value);
                double minutes = Convert.ToDouble(match.Groups[2].Value);

                //degrees = degrees + minutes / 60
                lon = degree + minutes / 60.0;

                if (match.Groups[3].Value == "W")
                    lon = -lon;                

                return lon;
            }

            regex = new Regex("^(\\d{1,3}" + NumSep + "?\\d{0,6})\\*?\\s*([EW])$");
            match = regex.Match(input);
            if (match.Success)
            {
                // Desimalgrader
                if (GetGroupSuccesses(match) != 3)
                    throw new Exception("Ugyldig format på lengdegrad");
                
                lon = Convert.ToDouble(match.Groups[1].Value);
                if (match.Groups[2].Value == "W")
                    lon = -lon;                

                return lon;
            }

            regex = new Regex("^(-?\\d{1,3}" + NumSep + "?\\d{0,6})$");
            match = regex.Match(input);
            if (match.Success)
            {
                // Desimal
                if (GetGroupSuccesses(match) != 2)                
                    throw new Exception("Ugyldig format på lengdegrad");
                                
                lon = Convert.ToDouble(match.Groups[1].Value);
                return lon;
            }

            throw new Exception("Ugyldig format på lengdegrad");
        }

        private void cboxSampleType_Leave(object sender, EventArgs e)
        {               
            if(!SampleTypeExists(cboxSampleType.Text))            
            {
                cboxSampleType.Focus();                    
                statusLabel.Text = "Du må velge en gyldig prøvetype";
            }
            else statusLabel.Text = String.Empty;
        }                

        private void cboxCommunity_Leave(object sender, EventArgs e)
        {            
            if (!String.IsNullOrEmpty(cboxCommunity.Text))
            {
                if (!communities.Contains(cboxCommunity.Text))
                {
                    cboxCommunity.Focus();
                    //cb.Select(cb.Text.Length, 1);
                    statusLabel.Text = "Du må velge en gyldig kommune";
                }
                else statusLabel.Text = String.Empty;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Environment.Exit(1);
        }
    }

    public class SampleType
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public SampleType(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    class LocationType
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public LocationType(string name, int val)
        {
            Name = name;
            Value = val;
        }

        public override string ToString()
        {
            return Name;
        }
    }    
}
