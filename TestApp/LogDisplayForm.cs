using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp
{
    public partial class LogDisplayForm : Form
    {
        public LogDisplayForm()
        {
            InitializeComponent();
        }

        public string LogText
        {
            get
            {
                return textBoxLog.Text;
            }

            set
            {
                if (value.Length > textBoxLog.MaxLength)
                {
                    throw new ArgumentException("Log is too long to be displayed");
                }
                else
                {
                    textBoxLog.Text = value;
                }
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
