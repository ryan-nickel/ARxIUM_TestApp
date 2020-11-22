﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TestApp.Models;


namespace TestApp
{
    public partial class MainForm : Form
    {
        private const string logFileName = "DrugIncrementTest.log";
        private const string drugsFileName = "drugs.xml";
        private readonly string[] defaultDrugNames = { "Acetaminophen", "Oxycotin", "Ibuprofen" };
        private List<Drug> drugsList;
        private BasicLogger log = new BasicLogger();
        

        public MainForm()
        {
            InitializeComponent();
        }

        private async void buttonResetCounts_Click(object sender, EventArgs e)
        {
            await log.WriteLineAsync("RESET");
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
                drug.DrugUpdatedEvent += Drug_DrugUpdatedEvent;
                flowLayoutPanelDrugs.Controls.Add(new DrugDisplay() { Drug = drug });
            }

            try
            {
                log.OpenLog(logFileName, false);
                log.WriteLine("START");
            }
            catch (BasicLogger.BasicLoggerException ex)
            {
                MessageBox.Show($"Error creating log file: {ex.Message}", "Log File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private async void Drug_DrugUpdatedEvent(string name, int count, int previousCount, DateTime lastChanged)
        {
            await log.WriteLineAsync($"Name = {name} , Previous Count = {previousCount} , New Count = {count}", lastChanged);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
