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
        bool Initialized = false;
        const string GenieRegistry = @"SOFTWARE\Wow6432Node\Canberra Industries, Inc.\Genie-2000 Environment";        
        const string InputBase = "input-params.txt";
        const string SampleCategoryBase = "sample-types.txt";
        const string GeometryTypeBase = "geometry-types.txt";
        const string CommunitiesBase = "communities.txt";
        const string LocationTypeBase = "location-types.txt";
        string GeniePath, LorakonPath, ReportsPath, SamplePath, QAPath, BkgPath, UploadPath, SystemPath, SampleLoadPath;
        string SampleCategoryFile, GeometryTypeFile, InputFile, CommunitiesFile, LocationTypeFile;

        AutoCompleteStringCollection sampleTypes = new AutoCompleteStringCollection();
        AutoCompleteStringCollection communities = new AutoCompleteStringCollection();        

        const int MagicNumber = 4124411;

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
            // Load                  
            tbSQuant.KeyPress += CustomEvents.Numeric_KeyPress;
            tbSQuantErr.KeyPress += CustomEvents.Numeric_KeyPress;
            tbLatitude.KeyPress += CustomEvents.Numeric_KeyPress;
            tbLongitude.KeyPress += CustomEvents.Numeric_KeyPress;
            tbAltitude.KeyPress += CustomEvents.Numeric_KeyPress;
            tbLivetime.KeyPress += CustomEvents.Integer_KeyPress;
            tbIntegral.KeyPress += CustomEvents.Integer_KeyPress;
            tbStartChannel.KeyPress += CustomEvents.Integer_KeyPress;
            tbEndChannel.KeyPress += CustomEvents.Integer_KeyPress;
            tbSSyserr.KeyPress += CustomEvents.Numeric_KeyPress;
            tbSSysterr.KeyPress += CustomEvents.Numeric_KeyPress;

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

                    ReportsPath = LorakonPath + "Rapporter\\";
                    if (!Directory.Exists(ReportsPath))
                        Directory.CreateDirectory(ReportsPath);

                    SamplePath = ReportsPath + "PR\\";
                    if (!Directory.Exists(SamplePath))
                        Directory.CreateDirectory(SamplePath);

                    QAPath = ReportsPath + "QA\\";
                    if (!Directory.Exists(QAPath))
                        Directory.CreateDirectory(QAPath);

                    BkgPath = ReportsPath + "BKG\\";
                    if (!Directory.Exists(BkgPath))
                        Directory.CreateDirectory(BkgPath);

                    UploadPath = ReportsPath + "PR_SENT\\";
                    if (!Directory.Exists(UploadPath))
                        Directory.CreateDirectory(UploadPath);

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

                    SampleCategoryFile = SystemPath + SampleCategoryBase;
                    if (!File.Exists(SampleCategoryFile))
                    {
                        if (!File.Exists(InstallDir + "template_sample-types.txt"))
                        {
                            MessageBox.Show("Finner ikke filen " + InstallDir + "template_sample-types.txt");
                            Close();
                        }
                        File.Copy(InstallDir + "template_sample-types.txt", SampleCategoryFile, true);
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

                    SampleLoadPath = LorakonPath + "Eksterne\\";
                    if (!Directory.Exists(SampleLoadPath))
                        Directory.CreateDirectory(SampleLoadPath);

                    // Load communities
                    string[] communitiesList = File.ReadAllLines(CommunitiesFile, Encoding.UTF8);
                    communities.AddRange(communitiesList);
                    cboxCommunity.Items.AddRange(communitiesList);
                    cboxCommunity.AutoCompleteCustomSource = communities;

                    // Load geometry types
                    cboxSGeomtry.Items.Clear();                    
                    string[] geomTypes = File.ReadAllLines(GeometryTypeFile, Encoding.UTF8);
                    cboxSGeomtry.Items.AddRange(geomTypes);

                    // Load sample types
                    string[] sampTypes = File.ReadAllLines(SampleCategoryFile, Encoding.UTF8);
                    sampleTypes.AddRange(sampTypes);
                    cboxSDesc1.Items.AddRange(sampTypes);
                    cboxSDesc1.AutoCompleteCustomSource = sampleTypes;                    

                    string[] locTypes = File.ReadAllLines(LocationTypeFile, Encoding.UTF8);
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
                        string[] lines = File.ReadAllLines(InputFile, Encoding.UTF8);

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

            // FIXME: more checks
            /*
            if(String.IsNullOrEmpty(tbScollName.Text) 
                || String.IsNullOrEmpty(tbSTitle.Text)
                || String.IsNullOrEmpty(cboxSDesc1.Text)
                || String.IsNullOrEmpty(cboxSUnits.Text)
                || String.IsNullOrEmpty(tbSQuant.Text) 
                || String.IsNullOrEmpty(tbSQuantErr.Text)
                || String.IsNullOrEmpty(tbSSyserr.Text)
                || String.IsNullOrEmpty(tbSSysterr.Text))
            {
                MessageBox.Show("En eller flere påkrevde felter mangler");
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
            }*/

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

                File.WriteAllText(InputFile, c, Encoding.UTF8);               
                DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);                
            }            

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
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
