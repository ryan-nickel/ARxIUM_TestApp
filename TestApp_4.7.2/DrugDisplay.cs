using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestApp_4_7_2.Models;

namespace TestApp_4_7_2
{
    public partial class DrugDisplay : UserControl
    {
        private Drug drug;

        public DrugDisplay()
        {
            InitializeComponent();
        }

        public Drug Drug
        {
            get { return drug; }

            set
            {
                drug = value;
                UpdateDisplay();
            }

        }

        public void UpdateDisplay()
        {
            textBoxName.Text = drug.Name;
            textBoxCount.Text = drug.Count.ToString();
        }

        public void UpdateCountDisplay()
        {
            textBoxCount.Text = drug.Count.ToString();
        }

        private void ButtonIncrement_Click(object sender, EventArgs e)
        {
            Drug.Increment();
            textBoxCount.Text = drug.Count.ToString();
        }

        

    }
}
