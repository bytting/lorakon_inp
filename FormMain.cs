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
using System.IO;
using System.ComponentModel;
using System.Text;
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
        const string SampleTypeBase = "sample-types.txt";

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

        AutoCompleteStringCollection sampleTypes = new AutoCompleteStringCollection();
        AutoCompleteStringCollection communities = new AutoCompleteStringCollection();

        BindingList<LocationType> LocationTypes = new BindingList<LocationType>();
        BindingList<CoordinateType> CoordinateTypes = new BindingList<CoordinateType>();

        public FormSampleInput()
        {
            InitializeComponent();            
        }

        string GetGeniePath()
        {
            RegistryKey rk = Registry.LocalMachine.OpenSubKey(GenieRegistry, false);
            String value = (String)rk.GetValue("GENIE2K");
            if (!String.IsNullOrEmpty(value))
                return value;            

            if(Directory.Exists("C:\\GENIE2K\\"))
                return "C:\\GENIE2K\\";

            return String.Empty;
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
            tbLivetime.TextChanged += CustomEvents.Crop16_TextChanged;
            tbIntegral.TextChanged += CustomEvents.Crop16_TextChanged;
            tbStartChannel.TextChanged += CustomEvents.Crop8_TextChanged;
            tbEndChannel.TextChanged += CustomEvents.Crop8_TextChanged;
            tbSSyserr.TextChanged += CustomEvents.Crop8_TextChanged;
            tbSSysterr.TextChanged += CustomEvents.Crop8_TextChanged;
            tbComment.TextChanged += CustomEvents.Crop64_TextChanged;

            // Force format of fields
            tbSQuant.KeyPress += CustomEvents.UnsignedNumeric_KeyPress;
            tbSQuantErr.KeyPress += CustomEvents.UnsignedNumeric_KeyPress;
            tbLatitude.KeyPress += CustomEvents.SignedNumeric_KeyPress;
            tbLongitude.KeyPress += CustomEvents.SignedNumeric_KeyPress;
            tbAltitude.KeyPress += CustomEvents.SignedNumeric_KeyPress;
            tbLivetime.KeyPress += CustomEvents.Integer_KeyPress;
            tbIntegral.KeyPress += CustomEvents.Integer_KeyPress;
            tbStartChannel.KeyPress += CustomEvents.Integer_KeyPress;
            tbEndChannel.KeyPress += CustomEvents.Integer_KeyPress;
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
                        MessageBox.Show("Genie2k directory not found: " + GeniePath);
                        Close();
                        return;
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
                        if (!File.Exists(InstallDir + "template_sample-types.txt"))
                        {
                            MessageBox.Show("Finner ikke filen " + InstallDir + "template_sample-types.txt");
                            Close();
                        }
                        File.Copy(InstallDir + "template_sample-types.txt", SampleTypeFile, true);
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
                    string[] sampTypes = File.ReadAllLines(SampleTypeFile, enc);
                    sampleTypes.AddRange(sampTypes);
                    cboxSDesc1.Items.AddRange(sampTypes);
                    cboxSDesc1.AutoCompleteCustomSource = sampleTypes;                    

                    string[] locTypes = File.ReadAllLines(LocationTypeFile, enc);
                    for (int i = 0; i < locTypes.Length; i++)
                        LocationTypes.Add(new LocationType(locTypes[i], i.ToString()));
                    cboxLocation.DataSource = LocationTypes;
                    cboxLocation.DisplayMember = "Name";
                    cboxLocation.ValueMember = "Value";

                    CoordinateTypes.Add(new CoordinateType("Desimalgrader (Lat,Lon,Alt)", "0"));
                    CoordinateTypes.Add(new CoordinateType("Grader/Minutter/Sekunder", "1"));
                    cboxCoordType.DataSource = CoordinateTypes;
                    cboxCoordType.DisplayMember = "Name";
                    cboxCoordType.ValueMember = "Value";

                    DateTime now = DateTime.Now;
                    dtpSDate.Value = now;
                    dtpSTime.Value = new DateTime(now.Year, now.Month, now.Day, 12, 0, 0);

                    InputFile = SystemPath + InputBase;
                    if (File.Exists(InputFile))
                    {
                        // Load params from file                    
                        string[] lines = File.ReadAllLines(InputFile, enc);

                        if(lines.Length > 0)
                            tbLab.Text = lines[0];
                        if (lines.Length > 1)
                            tbScollName.Text = lines[1];
                        if (lines.Length > 2)
                            tbSTitle.Text = lines[2];
                        if (lines.Length > 3)
                            if (sampleTypes.Contains(lines[3]))
                                cboxSDesc1.Text = lines[3];
                        if (lines.Length > 4)
                            tbSIdent.Text = lines[4];
                        if (lines.Length > 5)
                            if (communities.Contains(lines[5]))
                                cboxCommunity.Text = lines[5];
                        if (lines.Length > 6)
                            tbLatitude.Text = lines[6];
                        if (lines.Length > 7)
                            tbLongitude.Text = lines[7];
                        if (lines.Length > 8)
                            tbAltitude.Text = lines[8];
                        if (lines.Length > 9)
                            cboxLocation.SelectedValue = lines[9];
                        if (lines.Length > 10)
                            tbSLoctn.Text = lines[10];
                        if (lines.Length > 11)
                            tbSQuant.Text = lines[11];
                        if (lines.Length > 12)
                            tbSQuantErr.Text = lines[12];
                        if (lines.Length > 13)
                            cboxSUnits.Text = lines[13];
                        if (lines.Length > 14)
                            cboxSGeomtry.Text = lines[14];
                        if (lines.Length > 15)
                        {
                            DateTime dt = Convert.ToDateTime(lines[15]);
                            dtpSDate.Value = dt;
                            dtpSTime.Value = dt;
                        }
                        if (lines.Length > 16)
                            tbSSyserr.Text = lines[16];
                        if (lines.Length > 17)
                            tbSSysterr.Text = lines[17];
                        if (lines.Length > 18)
                            tbStartChannel.Text = lines[18];
                        if (lines.Length > 19)
                            tbEndChannel.Text = lines[19];
                        if (lines.Length > 20)
                            tbComment.Text = lines[20];
                    }

                    tbLab.Enabled = true;
                    LaboratoryFile = SystemPath + LaboratoryBase;
                    if (File.Exists(LaboratoryFile))
                    {
                        string[] LabName = File.ReadAllLines(LaboratoryFile, enc);
                        if(LabName.Length > 0)
                        {
                            tbLab.Text = LabName[0].Trim();
                            tbLab.Enabled = false;
                        }
                    }

                    tbLab.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }                
            }
        }        

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;            

            // Sanity checks for input fields
            if(String.IsNullOrEmpty(tbLab.Text.Trim()) 
                || String.IsNullOrEmpty(tbScollName.Text.Trim()) 
                || String.IsNullOrEmpty(tbSTitle.Text.Trim())
                || String.IsNullOrEmpty(cboxSDesc1.Text.Trim())
                || String.IsNullOrEmpty(cboxSUnits.Text.Trim())
                || String.IsNullOrEmpty(tbSQuant.Text.Trim()) 
                || String.IsNullOrEmpty(tbSQuantErr.Text.Trim())
                || String.IsNullOrEmpty(tbSSyserr.Text.Trim())
                || String.IsNullOrEmpty(tbSSysterr.Text.Trim()))
            {
                statusLabel.Text = "En eller flere påkrevde felter mangler";
                return;
            }

            if(!sampleTypes.Contains(cboxSDesc1.Text))
            {
                statusLabel.Text = "Du må velge en gyldig prøvetype";
                return;
            }

            if (!communities.Contains(cboxCommunity.Text))
            {
                statusLabel.Text = "Du må velge en gyldig kommune";
                return;
            }

            try
            {
                if (tbLatitude.Text.Trim() != string.Empty)
                {
                    double lat = Convert.ToDouble(tbLatitude.Text.Trim());
                    if (lat < -90.0 || lat > 90.0)
                    {
                        statusLabel.Text = "Breddegrad er ugyldig";
                        return;
                    }
                }

                if (tbLongitude.Text.Trim() != string.Empty)
                {
                    double lon = Convert.ToDouble(tbLongitude.Text.Trim());
                    if (lon < -180.0 || lon > 180.0)
                    {
                        statusLabel.Text = "Lengdegrad er ugyldig";
                        return;
                    }
                }

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
            catch(Exception ex)
            {
                statusLabel.Text = "Ugyldige koordinater funnet";
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

            if (!CustomEvents.ValidateUnsignedInteger(tbLivetime.Text))
            {
                statusLabel.Text = "Ugyldig livetime";
                return;
            }

            if (!CustomEvents.ValidateUnsignedInteger(tbIntegral.Text))
            {
                statusLabel.Text = "Ugyldig integral";
                return;
            }

            // Store params to file
            try
            {
                DateTime dt = new DateTime(dtpSDate.Value.Year, dtpSDate.Value.Month, dtpSDate.Value.Day, dtpSTime.Value.Hour, dtpSTime.Value.Minute, dtpSTime.Value.Second);

                string c = tbLab.Text + Environment.NewLine +
                    tbScollName.Text + Environment.NewLine +
                    tbSTitle.Text + Environment.NewLine +
                    cboxSDesc1.Text + Environment.NewLine +
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
                    tbSSyserr.Text + Environment.NewLine +
                    tbSSysterr.Text + Environment.NewLine +
                    tbStartChannel.Text + Environment.NewLine +
                    tbEndChannel.Text + Environment.NewLine +
                    tbComment.Text;

                File.WriteAllText(InputFile, c, enc);

                if (!File.Exists(LaboratoryFile))
                {
                    File.WriteAllText(LaboratoryFile, tbLab.Text, enc);
                }

                DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(1);
            }
            
            Environment.Exit(0);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Environment.Exit(1);
        }        

        private void cboxSDesc1_Leave(object sender, EventArgs e)
        {            
            ComboBox cb = (ComboBox)sender;
            if (!sampleTypes.Contains(cb.Text))
            {
                cb.Focus();
                cb.Select(cb.Text.Length, 1);
                statusLabel.Text = "Du må velge en gyldig prøvetype";
            }
            else statusLabel.Text = String.Empty;
        }

        private void cboxCommunity_Leave(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!communities.Contains(cb.Text))
            {
                cb.Focus();
                cb.Select(cb.Text.Length, 1);
                statusLabel.Text = "Du må velge en gyldig kommune";
            }
            else statusLabel.Text = String.Empty;
        }
    }

    public class LocationType
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public LocationType(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class CoordinateType
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public CoordinateType(string name, string value)
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
