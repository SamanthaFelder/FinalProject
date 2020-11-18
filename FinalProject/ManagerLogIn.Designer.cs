namespace FinalProject
{
    partial class ManagerLogIn
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
            this.managerUserTextBox = new System.Windows.Forms.TextBox();
            this.managerPassTextBox = new System.Windows.Forms.TextBox();
            this.managerLogInButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // managerUserTextBox
            // 
            this.managerUserTextBox.Location = new System.Drawing.Point(106, 78);
            this.managerUserTextBox.Name = "managerUserTextBox";
            this.managerUserTextBox.Size = new System.Drawing.Size(168, 20);
            this.managerUserTextBox.TabIndex = 0;
            // 
            // managerPassTextBox
            // 
            this.managerPassTextBox.Location = new System.Drawing.Point(106, 131);
            this.managerPassTextBox.Name = "managerPassTextBox";
            this.managerPassTextBox.Size = new System.Drawing.Size(168, 20);
            this.managerPassTextBox.TabIndex = 1;
            // 
            // managerLogInButton
            // 
            this.managerLogInButton.Location = new System.Drawing.Point(154, 188);
            this.managerLogInButton.Name = "managerLogInButton";
            this.managerLogInButton.Size = new System.Drawing.Size(75, 23);
            this.managerLogInButton.TabIndex = 2;
            this.managerLogInButton.Text = "Log In";
            this.managerLogInButton.UseVisualStyleBackColor = true;
            this.managerLogInButton.Click += new System.EventHandler(this.managerLogInButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password:";
            // 
            // ManagerLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 265);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.managerLogInButton);
            this.Controls.Add(this.managerPassTextBox);
            this.Controls.Add(this.managerUserTextBox);
            this.Name = "ManagerLogIn";
            this.Text = "ManagerLogIn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox managerUserTextBox;
        private System.Windows.Forms.TextBox managerPassTextBox;
        private System.Windows.Forms.Button managerLogInButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}