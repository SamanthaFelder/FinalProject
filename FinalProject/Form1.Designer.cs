namespace FinalProject
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.managerButton = new System.Windows.Forms.Button();
            this.clientButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Log in as:";
            // 
            // managerButton
            // 
            this.managerButton.Location = new System.Drawing.Point(45, 102);
            this.managerButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.managerButton.Name = "managerButton";
            this.managerButton.Size = new System.Drawing.Size(181, 28);
            this.managerButton.TabIndex = 1;
            this.managerButton.Text = "Manager";
            this.managerButton.UseVisualStyleBackColor = true;
            this.managerButton.Click += new System.EventHandler(this.managerButton_Click);
            // 
            // clientButton
            // 
            this.clientButton.Location = new System.Drawing.Point(303, 102);
            this.clientButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clientButton.Name = "clientButton";
            this.clientButton.Size = new System.Drawing.Size(181, 28);
            this.clientButton.TabIndex = 2;
            this.clientButton.Text = "Client";
            this.clientButton.UseVisualStyleBackColor = true;
            this.clientButton.Click += new System.EventHandler(this.clientButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 207);
            this.Controls.Add(this.clientButton);
            this.Controls.Add(this.managerButton);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "FirstForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button managerButton;
        private System.Windows.Forms.Button clientButton;
    }
}

