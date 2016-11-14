using System;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace lorakon
{
    public partial class FormSampleTypes : Form
    {
        private string SampleTypeFile;
        public string SelectedSampleType;

        public FormSampleTypes(string sampleTypeFile)
        {
            InitializeComponent();
            SampleTypeFile = sampleTypeFile;
        }

        private void FormSampleTypes_Load(object sender, EventArgs e)
        {
            labelStatus.Text = String.Empty;

            if (!File.Exists(SampleTypeFile))
                return;

            XmlDocument doc = new XmlDocument();
            doc.Load(SampleTypeFile);
            XmlElement root = doc.DocumentElement;
            TreeNode tnode = treeSampleTypes.Nodes.Add("Prøvetyper");
            AddSampleTypes(root, tnode);

            tnode.Expand();
        }

        private void AddSampleTypes(XmlNode node, TreeNode tnode)
        {            
            foreach (XmlNode n in node.ChildNodes)
            {
                if (n.NodeType == XmlNodeType.Element && n.Name.ToLower() == "sampletype")
                {
                    TreeNode newNode = new TreeNode(n.Attributes["name"].InnerText);                    
                    newNode.ToolTipText = tnode.ToolTipText + "/" + n.Attributes["name"].InnerText;                    
                    tnode.Nodes.Add(newNode);
                    AddSampleTypes(n, newNode);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            labelStatus.Text = String.Empty;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(treeSampleTypes.SelectedNode == null)
            {
                labelStatus.Text = "Ingen prøvetype er valgt";
                return;
            }

            labelStatus.Text = String.Empty;
            SelectedSampleType = treeSampleTypes.SelectedNode.ToolTipText;
            SelectedSampleType = SelectedSampleType.Remove(0, 1);

            DialogResult = DialogResult.OK;
            Close();
        }        
    }
}
