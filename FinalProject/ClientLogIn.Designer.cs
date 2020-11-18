namespace FinalProject
{
    partial class ClientLogIn
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clientLogInButton = new System.Windows.Forms.Button();
            this.clientPassTextBox = new System.Windows.Forms.TextBox();
            this.clientUserTextBox = new System.Windows.Forms.TextBox();
            this.signUpButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Username:";
            // 
            // clientLogInButton
            // 
            this.clientLogInButton.Location = new System.Drawing.Point(185, 177);
            this.clientLogInButton.Name = "clientLogInButton";
            this.clientLogInButton.Size = new System.Drawing.Size(75, 23);
            this.clientLogInButton.TabIndex = 7;
            this.clientLogInButton.Text = "Log In";
            this.clientLogInButton.UseVisualStyleBackColor = true;
            this.clientLogInButton.Click += new System.EventHandler(this.clientLogInButton_Click);
            // 
            // clientPassTextBox
            // 
            this.clientPassTextBox.Location = new System.Drawing.Point(137, 129);
            this.clientPassTextBox.Name = "clientPassTextBox";
            this.clientPassTextBox.Size = new System.Drawing.Size(168, 20);
            this.clientPassTextBox.TabIndex = 6;
            // 
            // clientUserTextBox
            // 
            this.clientUserTextBox.Location = new System.Drawing.Point(137, 76);
            this.clientUserTextBox.Name = "clientUserTextBox";
            this.clientUserTextBox.Size = new System.Drawing.Size(168, 20);
            this.clientUserTextBox.TabIndex = 5;
            // 
            // signUpButton
            // 
            this.signUpButton.Location = new System.Drawing.Point(185, 215);
            this.signUpButton.Name = "signUpButton";
            this.signUpButton.Size = new System.Drawing.Size(75, 23);
            this.signUpButton.TabIndex = 10;
            this.signUpButton.Text = "Sign Up";
            this.signUpButton.UseVisualStyleBackColor = true;
            this.signUpButton.Click += new System.EventHandler(this.signUpButton_Click);
            // 
            // ClientLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 269);
            this.Controls.Add(this.signUpButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clientLogInButton);
            this.Controls.Add(this.clientPassTextBox);
            this.Controls.Add(this.clientUserTextBox);
            this.Name = "ClientLogIn";
            this.Text = "ClientLogIn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clientLogInButton;
        private System.Windows.Forms.TextBox clientPassTextBox;
        private System.Windows.Forms.TextBox clientUserTextBox;
        private System.Windows.Forms.Button signUpButton;
    }
}