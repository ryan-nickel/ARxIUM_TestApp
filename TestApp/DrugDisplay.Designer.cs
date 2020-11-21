
namespace TestApp
{
    partial class DrugDisplay
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelName = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.buttonIncrement = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(10, 12);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(39, 15);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(10, 41);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(40, 15);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "Count";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(55, 9);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(216, 23);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(55, 38);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.ReadOnly = true;
            this.textBoxCount.Size = new System.Drawing.Size(123, 23);
            this.textBoxCount.TabIndex = 3;
            // 
            // buttonIncrement
            // 
            this.buttonIncrement.Location = new System.Drawing.Point(184, 38);
            this.buttonIncrement.Name = "buttonIncrement";
            this.buttonIncrement.Size = new System.Drawing.Size(87, 23);
            this.buttonIncrement.TabIndex = 4;
            this.buttonIncrement.Text = "Increment";
            this.buttonIncrement.UseVisualStyleBackColor = true;
            // 
            // DrugDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.buttonIncrement);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelName);
            this.Name = "DrugDisplay";
            this.Size = new System.Drawing.Size(287, 73);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Button buttonIncrement;
    }
}
