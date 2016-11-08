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
using System.Xml;
using System.Windows.Forms;
using Microsoft.Win32;

namespace lorakon
{
    public partial class FormSampleInput : Form
    {
        // Flag used to keep track of initialization in the paint event (Avoid displaying forms/messages in the load event)
        bool Initialized = false;

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

        // Filename for laboratory name
        const string LaboratoryBase = "laboratory.txt";

        // Paths for configuration files        
        string GeniePath, LorakonPath, SystemPath;
        string SampleTypeFile, GeometryTypeFile, InputFile, LaboratoryFile, CommunitiesFile, LocationTypeFile;
        
        AutoCompleteStringCollection communities = new AutoCompleteStringCollection();        
        BindingList<LocationType> LocationTypes = new BindingList<LocationType>();        

        ToolTip coordToolTip = new ToolTip();
        ToolTip locationToolTip = new ToolTip();

        public FormSampleInput()
        {
            InitializeComponent();            
        }        

        private void FormSampleInput_Load(object sender, EventArgs e)
        {
            // Limit max length of fields
            tbLab.TextChanged += CustomEvents.Crop16_TextChanged;
            tbScollName.TextChanged += CustomEvents.Crop24_TextChanged;
            tbSTitle.TextChanged += CustomEvents.Crop64_TextChanged;
            tbSIdent.TextChanged += CustomEvents.Crop16_TextChanged;
            tbLatitude.TextChanged += CustomEvents.Crop16_TextChanged;
            tbLongitude.TextChanged += CustomEvents.Crop16_TextChanged;
            tbAltitude.TextChanged += CustomEvents.Crop16_TextChanged;
            tbSLoctn.TextChanged += CustomEvents.Crop32_TextChanged;
            tbSQuant.TextChanged += CustomEvents.Crop16_TextChanged;
            tbSQuantErr.TextChanged += CustomEvents.Crop16_TextChanged;            
            tbSSyserr.TextChanged += CustomEvents.Crop8_TextChanged;
            tbSSysterr.TextChanged += CustomEvents.Crop8_TextChanged;
            tbComment.TextChanged += CustomEvents.Crop255_TextChanged;

            // Force format of fields
            tbSQuant.KeyPress += CustomEvents.UnsignedNumeric_KeyPress;
            tbSQuantErr.KeyPress += CustomEvents.UnsignedNumeric_KeyPress;
            tbLatitude.KeyPress += CustomEvents.SignedNumeric_KeyPress;
            tbLongitude.KeyPress += CustomEvents.SignedNumeric_KeyPress;
            tbAltitude.KeyPress += CustomEvents.SignedNumeric_KeyPress;            
            tbSSyserr.KeyPress += CustomEvents.UnsignedNumeric_KeyPress;
            tbSSysterr.KeyPress += CustomEvents.UnsignedNumeric_KeyPress;

            statusLabel.Text = String.Empty;
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
                    cboxSGeomtry.Items.Clear();                    
                    string[] geomTypes = File.ReadAllLines(GeometryTypeFile, enc);
                    cboxSGeomtry.Items.AddRange(geomTypes);

                    // Load sample types
                    string[] sampTypes = GetSampleTypes();
                    foreach(string st in sampTypes)                    
                        cboxSampleType.Items.Add(new SampleType(GetLabelFromSampleType(st), st));

                    // Load location types                    
                    string[] locTypes = File.ReadAllLines(LocationTypeFile, enc);
                    for (int i = 0; i < locTypes.Length; i++)
                        LocationTypes.Add(new LocationType(locTypes[i], i));
                    cboxLocation.DataSource = LocationTypes;
                    cboxLocation.DisplayMember = "Name";
                    cboxLocation.ValueMember = "Value";

                    // Add coordinate types                    
                    cboxCoordType.Items.Add(new CoordinateType("", CoordinateFormat.None));
                    cboxCoordType.Items.Add(new CoordinateType("WGS84", CoordinateFormat.WGS84));
                    cboxCoordType.Items.Add(new CoordinateType("Desimalgrader", CoordinateFormat.DecimalDegrees));
                    cboxCoordType.Items.Add(new CoordinateType("Grader/Minutter/Sekunder", CoordinateFormat.DegreesMinutesSeconds));
                    cboxCoordType.Items.Add(new CoordinateType("Grader/Desimal minutter", CoordinateFormat.DegreesDecimalMinutes));                    

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
                            string loc = PrepareStringParam(lines[10], typeof(Int32), cboxLocation.MaxLength);
                            if(!String.IsNullOrEmpty(loc))
                                cboxLocation.SelectedValue = Convert.ToInt32(loc);
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
                            string sdt = PrepareStringParam(lines[16], typeof(DateTime), 24);
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
                            tbComment.Text = PrepareStringParam(lines[19], typeof(String), 255);
                    }

                    if(tbLatitude.Text.Trim() != String.Empty || tbLongitude.Text.Trim() != String.Empty)
                    {
                        cboxCoordType.SelectedIndex = 1;
                        tbLatitude.Enabled = true;
                        tbLongitude.Enabled = true;
                        tbAltitude.Enabled = true;
                    }
                    else
                    {
                        cboxCoordType.SelectedIndex = 0;
                        tbLatitude.Enabled = false;
                        tbLongitude.Enabled = false;
                        tbAltitude.Enabled = false;
                    }

                    tbLab.Enabled = true;
                    LaboratoryFile = SystemPath + LaboratoryBase;
                    if (File.Exists(LaboratoryFile))
                    {
                        string LabName = File.ReadAllText(LaboratoryFile, enc).Trim();
                        if(!String.IsNullOrEmpty(LabName))
                        {
                            tbLab.Text = LabName;
                            tbLab.Enabled = false;
                        }
                    }

                    FormSampleInput_Resize(sender, e);                    

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
            cboxComponent.Width = panelSampleCompID.Width / 2;
            tbLatitude.Width = panelCoords.Width / 3;
            tbAltitude.Width = panelCoords.Width / 3;
            tbSQuant.Width = panelSampleQuant.Width / 2;
            cboxSUnits.Width = panelUnitGeom.Width / 2;
            dtpSDate.Width = panelReferenceDate.Width / 2;
            tbSSyserr.Width = panelError.Width / 2;
            labelCoordLatitude.Left = tbLatitude.Left;
            labelCoordLongitude.Left = tbLongitude.Left;
            labelCoordAltitude.Left = tbAltitude.Left;
        }        

        private void cboxLocation_MouseHover(object sender, EventArgs e)
        {
            coordToolTip.ToolTipTitle = "";
            coordToolTip.UseFading = true;
            coordToolTip.UseAnimation = true;
            coordToolTip.IsBalloon = true;
            coordToolTip.ShowAlways = true;
            coordToolTip.AutoPopDelay = 10000;
            coordToolTip.InitialDelay = 700;
            coordToolTip.ReshowDelay = 0;
            coordToolTip.SetToolTip(cboxLocation, "Velg lokasjons informasjon...");
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

        private void cboxCoordType_MouseHover(object sender, EventArgs e)
        {
            coordToolTip.ToolTipTitle = "";
            coordToolTip.UseFading = true;
            coordToolTip.UseAnimation = true;
            coordToolTip.IsBalloon = true;
            coordToolTip.ShowAlways = true;
            coordToolTip.AutoPopDelay = 10000;
            coordToolTip.InitialDelay = 700;
            coordToolTip.ReshowDelay = 0;
            coordToolTip.SetToolTip(cboxCoordType, (string)cboxCoordType.Tag);
        }

        private void cboxCoordType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbLatitude.Enabled = true;
            tbLongitude.Enabled = true;
            tbAltitude.Enabled = true;
            
            switch (((CoordinateType)cboxCoordType.SelectedItem).Value)
            {
                case CoordinateFormat.None:                    
                    cboxCoordType.Tag = "Velg koordinat format...";
                    tbLatitude.Text = String.Empty;
                    tbLongitude.Text = String.Empty;
                    tbAltitude.Text = String.Empty;
                    tbLatitude.Enabled = false;
                    tbLongitude.Enabled = false;
                    tbAltitude.Enabled = false;
                    break;
                case CoordinateFormat.WGS84:
                    cboxCoordType.Tag = "Format:   40.446    -79.982";
                    break;
                case CoordinateFormat.DegreesMinutesSeconds:
                    cboxCoordType.Tag = "Format:   40° 26′ 46″ N    79° 58′ 56″ W";
                    break;
                case CoordinateFormat.DegreesDecimalMinutes:
                    cboxCoordType.Tag = "Format:   40° 26.767′ N    79° 58.933′ W";
                    break;
                case CoordinateFormat.DecimalDegrees:
                    cboxCoordType.Tag = "Format:   40.446° N    79.982° W";
                    break;
            }            
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
                    XmlNodeList sampleNodes = xmlDoc.SelectNodes(samplePath + "/component");
                    foreach (XmlNode sNode in sampleNodes)
                        cboxComponent.Items.Add(sNode.Attributes["name"].InnerText);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }                

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;            

            // Sanity checks for input fields
            if(String.IsNullOrEmpty(tbLab.Text.Trim()) 
                || String.IsNullOrEmpty(tbScollName.Text.Trim()) 
                || String.IsNullOrEmpty(tbSTitle.Text.Trim())
                || String.IsNullOrEmpty(cboxSampleType.Text.Trim())
                || String.IsNullOrEmpty(cboxSUnits.Text.Trim())
                || String.IsNullOrEmpty(tbSQuant.Text.Trim()) 
                || String.IsNullOrEmpty(tbSQuantErr.Text.Trim()))
            {
                statusLabel.Text = "En eller flere påkrevde felter mangler";
                return;
            }           

            if (!communities.Contains(cboxCommunity.Text))
            {
                statusLabel.Text = "Du må velge en gyldig kommune";
                return;
            }

            CoordinateFormat fmt = ((CoordinateType)cboxCoordType.SelectedItem).Value;

            if(fmt != CoordinateFormat.None && (tbLatitude.Text.Trim() == String.Empty || tbLongitude.Text.Trim() == String.Empty))            
            {
                statusLabel.Text = "Breddegrad eller Lengdegrad mangler";
                return;
            }

            if (fmt == CoordinateFormat.WGS84)
            {
                double lat, lon;

                try
                {                    
                    lat = Convert.ToDouble(tbLatitude.Text.Trim());
                    if (lat < -90.0 || lat > 90.0)
                    {
                        statusLabel.Text = "Breddegrad er ugyldig";
                        return;
                    }                
                    
                    lon = Convert.ToDouble(tbLongitude.Text.Trim());
                    if (lon < -180.0 || lon > 180.0)
                    {
                        statusLabel.Text = "Lengdegrad er ugyldig";
                        return;
                    }                    
                }
                catch
                {
                    statusLabel.Text = "Ugyldig format på koordinater";
                    return;
                }
            }
            else if (fmt == CoordinateFormat.DegreesMinutesSeconds)
            {
                try
                {
                    //lat = ConvertToDecimalDegrees(tbLatitude.Text.Trim());
                    //lon = ConvertToDecimalDegrees(tbLongitude.Text.Trim());
                }
                catch
                {
                    statusLabel.Text = "Ugyldig format på koordinater";
                    return;
                }
            }
            else if (fmt == CoordinateFormat.DegreesDecimalMinutes)
            {

            }
            else if (fmt == CoordinateFormat.DecimalDegrees)
            {

            }                        

            try
            {
                if (tbAltitude.Text.Trim() != string.Empty)
                {
                    double alt = Convert.ToDouble(tbAltitude.Text.Trim());
                    // 10994: Depth of the Challenger Deep
                    // 480000: Thinkness of the atmosphere
                    if (alt < -10994.0 || alt > 480000)
                    {
                        statusLabel.Text = "Høyde over havet er ugyldig";
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Ugyldige høyde over havet";
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
            catch (Exception ex)
            {
                statusLabel.Text = "Ugyldige Error verdier funnet";
                return;
            }

            if(!CustomEvents.ValidateSignedNumeric(tbLatitude.Text))
            {
                statusLabel.Text = "Ugyldig breddegrad funnet";
                return;
            }

            if (!CustomEvents.ValidateSignedNumeric(tbLongitude.Text))
            {
                statusLabel.Text = "Ugyldig lengdegrad funnet";
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

            // Store params to file
            try
            {
                DateTime dt = new DateTime(dtpSDate.Value.Year, dtpSDate.Value.Month, dtpSDate.Value.Day, dtpSTime.Value.Hour, dtpSTime.Value.Minute, dtpSTime.Value.Second);

                string c = tbLab.Text + Environment.NewLine +
                    tbScollName.Text + Environment.NewLine +
                    tbSTitle.Text + Environment.NewLine +
                    GetSampleTypeFromLabel(cboxSampleType.Text) + Environment.NewLine +
                    cboxComponent.Text + Environment.NewLine +
                    tbSIdent.Text + Environment.NewLine +
                    cboxCommunity.Text + Environment.NewLine +
                    tbLatitude.Text + Environment.NewLine +
                    tbLongitude.Text + Environment.NewLine +
                    tbAltitude.Text + Environment.NewLine +
                    cboxLocation.SelectedValue + Environment.NewLine +
                    tbSLoctn.Text + Environment.NewLine +
                    tbSQuant.Text + Environment.NewLine +
                    tbSQuantErr.Text + Environment.NewLine +
                    cboxSUnits.Text + Environment.NewLine +
                    cboxSGeomtry.Text + Environment.NewLine +
                    dt.ToString("yyyy-MM-dd hh:mm:ss") + Environment.NewLine +                    
                    (String.IsNullOrEmpty(tbSSyserr.Text.Trim()) ? "0" : tbSSyserr.Text.Trim()) + Environment.NewLine +
                    (String.IsNullOrEmpty(tbSSysterr.Text.Trim()) ? "0" : tbSSysterr.Text.Trim()) + Environment.NewLine +
                    tbComment.Text;

                File.WriteAllText(InputFile, c, enc);
                
                File.WriteAllText(LaboratoryFile, tbLab.Text, enc);

                DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(1);
            }
            
            Environment.Exit(0);
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

    enum CoordinateFormat
    {
        None = 0,
        WGS84 = 1,
        DecimalDegrees = 2,
        DegreesMinutesSeconds = 3,
        DegreesDecimalMinutes = 4
    }

    class CoordinateType
    {
        public string Name { get; set; }
        public CoordinateFormat Value { get; set; }

        public CoordinateType(string name, CoordinateFormat value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
