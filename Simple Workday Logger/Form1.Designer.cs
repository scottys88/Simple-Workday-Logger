
namespace Simple_Workday_Logger
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.messageBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(350, 358);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(405, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Are you working from home?";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(364, 500);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(375, 175);
            this.button1.TabIndex = 1;
            this.button1.Text = "Yes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.YesOrNoButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(985, 500);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(375, 175);
            this.button2.TabIndex = 2;
            this.button2.Text = "No";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.YesOrNoButton_Click);
            // 
            // messageBox
            // 
            this.messageBox.AutoSize = true;
            this.messageBox.ForeColor = System.Drawing.Color.Red;
            this.messageBox.Location = new System.Drawing.Point(390, 776);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(97, 41);
            this.messageBox.TabIndex = 3;
            this.messageBox.Text = "label2";
            this.messageBox.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1697, 1085);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label messageBox;
    }
}

