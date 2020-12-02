using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TestApp_4_7_2.Models;

namespace TestApp_4_7_2
{
    public partial class MainForm : Form
    {
        private const string logFileName = "DrugIncrementTest.log";
        private const string drugsFileName = "drugs.xml";
        private readonly string[] defaultDrugNames = { "Acetaminophen", "Oxycotin", "Ibuprofen" };
        private List<Drug> drugsList;
        private readonly BasicLogger log = BasicLogger.Instance;
        private readonly LogDisplayForm logDisplayForm = new LogDisplayForm();
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void Drug_DrugUpdatedEvent(string name, int count, int previousCount, DateTime lastChanged)
        {
            log.WriteLine($"Name = {name} , Previous Count = {previousCount} , New Count = {count}", lastChanged);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Drug file names stored in an XML file so new drugs can be easily added
            if (!File.Exists(drugsFileName))
            {
                // Drugs xml file does not exist so generate a default
                drugsList = new List<Drug>(3);
                foreach (string drugName in defaultDrugNames)
                {
                    drugsList.Add(new Drug(drugName));
                }

                try
                {
                    XmlSerializationHelper.SerializeToXmlFile(drugsFileName, drugsList);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show($"Error creating drug file: {ex.Message}", "Drug File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    drugsList = XmlSerializationHelper.DeserializeFromXmlFile<List<Drug>>(drugsFileName);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show($"Error opening drug file: {ex.Message}", "Drug File File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            foreach (var drug in drugsList)
            {
                drug.DrugUpdatedEvent += Drug_DrugUpdatedEvent;
                flowLayoutPanelDrugs.Controls.Add(new DrugDisplay() { Drug = drug });
            }

            try
            {
                log.Open(logFileName, false);
                log.WriteLine("START");
            }
            catch (BasicLogger.BasicLoggerException ex)
            {
                MessageBox.Show($"Error creating log file: {ex.Message}", "Log File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonResetCounts.Enabled = false;
                buttonShowLog.Enabled = false;
                splitContainerMain.Panel2.Enabled = false;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            log.Close();
        }

        private void ButtonResetCounts_Click(object sender, EventArgs e)
        {
            log.WriteLine("RESET");
            drugsList.ForEach(d => d.Reset());
            foreach (DrugDisplay display in flowLayoutPanelDrugs.Controls)
            {
                display.UpdateCountDisplay();
            }
        }

        private async void ButtonShowLog_Click(object sender, EventArgs e)
        {   
            try
            {
                log.Close();
                using (StreamReader reader = new StreamReader(logFileName))
                {
                    logDisplayForm.LogText = await reader.ReadToEndAsync();
                }

                logDisplayForm.ShowDialog();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show($"Log file not found.", "Log File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch  (DirectoryNotFoundException)
            {
                MessageBox.Show($"Log file path is not valid.", "Log File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException)
            {
                MessageBox.Show($"Log file is not valid.", "Log File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                log.Open(logFileName, true);
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
