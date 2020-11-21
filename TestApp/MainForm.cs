using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TestApp.Models;


namespace TestApp
{
    public partial class MainForm : Form
    {
        private const string drugsFileName = "drugs.xml";
        private readonly string[] defaultDrugNames = { "Acetaminophen", "Oxycotin", "Ibuprofen" };
        private List<Drug> drugsList;

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonResetCounts_Click(object sender, EventArgs e)
        {
            drugsList.ForEach(d => d.Reset());
            foreach (DrugDisplay display in flowLayoutPanelDrugs.Controls)
            {
                display.UpdateCountDisplay();
            }
        }

        private void buttonShowLog_Click(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists(drugsFileName))
            {
                drugsList = new List<Drug>(3);
                foreach (string drugName in defaultDrugNames)
                {
                    drugsList.Add(new Drug(drugName));
                }

                XmlSerializationHelper.SerializeToXmlFile(drugsFileName, drugsList);
            }
            else
            {
                drugsList = XmlSerializationHelper.DeserializeFromXmlFile<List<Drug>>(drugsFileName);
            }

            foreach (var drug in drugsList)
            {
                flowLayoutPanelDrugs.Controls.Add(new DrugDisplay() { Drug = drug });
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
