
namespace TestApp_4_7_2
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanelMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonResetCounts = new System.Windows.Forms.Button();
            this.buttonShowLog = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.flowLayoutPanelDrugs = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelMenu
            // 
            this.flowLayoutPanelMenu.Controls.Add(this.buttonResetCounts);
            this.flowLayoutPanelMenu.Controls.Add(this.buttonShowLog);
            this.flowLayoutPanelMenu.Controls.Add(this.buttonExit);
            this.flowLayoutPanelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMenu.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMenu.Name = "flowLayoutPanelMenu";
            this.flowLayoutPanelMenu.Size = new System.Drawing.Size(597, 38);
            this.flowLayoutPanelMenu.TabIndex = 0;
            // 
            // buttonResetCounts
            // 
            this.buttonResetCounts.Location = new System.Drawing.Point(3, 3);
            this.buttonResetCounts.Name = "buttonResetCounts";
            this.buttonResetCounts.Size = new System.Drawing.Size(64, 25);
            this.buttonResetCounts.TabIndex = 0;
            this.buttonResetCounts.Text = "Reset Counts";
            this.buttonResetCounts.UseVisualStyleBackColor = true;
            this.buttonResetCounts.Click += new System.EventHandler(this.ButtonResetCounts_Click);
            // 
            // buttonShowLog
            // 
            this.buttonShowLog.Location = new System.Drawing.Point(73, 3);
            this.buttonShowLog.Name = "buttonShowLog";
            this.buttonShowLog.Size = new System.Drawing.Size(64, 25);
            this.buttonShowLog.TabIndex = 1;
            this.buttonShowLog.Text = "Show Log";
            this.buttonShowLog.UseVisualStyleBackColor = true;
            this.buttonShowLog.Click += new System.EventHandler(this.ButtonShowLog_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(143, 3);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(64, 25);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // flowLayoutPanelDrugs
            // 
            this.flowLayoutPanelDrugs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelDrugs.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelDrugs.Name = "flowLayoutPanelDrugs";
            this.flowLayoutPanelDrugs.Size = new System.Drawing.Size(597, 387);
            this.flowLayoutPanelDrugs.TabIndex = 1;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.flowLayoutPanelMenu);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.flowLayoutPanelDrugs);
            this.splitContainerMain.Size = new System.Drawing.Size(597, 428);
            this.splitContainerMain.SplitterDistance = 38;
            this.splitContainerMain.SplitterWidth = 3;
            this.splitContainerMain.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 428);
            this.Controls.Add(this.splitContainerMain);
            this.Name = "MainForm";
            this.Text = "TestApp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.flowLayoutPanelMenu.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMenu;
        private System.Windows.Forms.Button buttonResetCounts;
        private System.Windows.Forms.Button buttonShowLog;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelDrugs;
        private System.Windows.Forms.SplitContainer splitContainerMain;
    }
}

