namespace FinalProject
{
    partial class Showtimes
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
            this.deleteButton = new System.Windows.Forms.Button();
            this.modifyButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.consultButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.movieTextBox = new System.Windows.Forms.TextBox();
            this.dateTextBox = new System.Windows.Forms.TextBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.showtimesListbox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.costTextBox = new System.Windows.Forms.TextBox();
            this.roomTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(208, 415);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(136, 28);
            this.deleteButton.TabIndex = 21;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // modifyButton
            // 
            this.modifyButton.Location = new System.Drawing.Point(67, 415);
            this.modifyButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(133, 28);
            this.modifyButton.TabIndex = 20;
            this.modifyButton.Text = "Modify";
            this.modifyButton.UseVisualStyleBackColor = true;
            this.modifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(208, 379);
            this.addButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(136, 28);
            this.addButton.TabIndex = 19;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // consultButton
            // 
            this.consultButton.Location = new System.Drawing.Point(67, 379);
            this.consultButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.consultButton.Name = "consultButton";
            this.consultButton.Size = new System.Drawing.Size(133, 28);
            this.consultButton.TabIndex = 18;
            this.consultButton.Text = "Consult";
            this.consultButton.UseVisualStyleBackColor = true;
            this.consultButton.Click += new System.EventHandler(this.consultButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(425, 180);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Movie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(425, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Date and time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(425, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "ID";
            // 
            // movieTextBox
            // 
            this.movieTextBox.Location = new System.Drawing.Point(429, 199);
            this.movieTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.movieTextBox.Name = "movieTextBox";
            this.movieTextBox.Size = new System.Drawing.Size(155, 22);
            this.movieTextBox.TabIndex = 14;
            // 
            // dateTextBox
            // 
            this.dateTextBox.Location = new System.Drawing.Point(429, 150);
            this.dateTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.Size = new System.Drawing.Size(155, 22);
            this.dateTextBox.TabIndex = 13;
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(429, 102);
            this.idTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(155, 22);
            this.idTextBox.TabIndex = 12;
            // 
            // showtimesListbox
            // 
            this.showtimesListbox.FormattingEnabled = true;
            this.showtimesListbox.ItemHeight = 16;
            this.showtimesListbox.Location = new System.Drawing.Point(67, 59);
            this.showtimesListbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.showtimesListbox.Name = "showtimesListbox";
            this.showtimesListbox.Size = new System.Drawing.Size(276, 292);
            this.showtimesListbox.TabIndex = 11;
            this.showtimesListbox.SelectedIndexChanged += new System.EventHandler(this.showtimesListbox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 278);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Ticket Cost";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(425, 230);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 24;
            this.label5.Text = "Room";
            // 
            // costTextBox
            // 
            this.costTextBox.Location = new System.Drawing.Point(429, 298);
            this.costTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.costTextBox.Name = "costTextBox";
            this.costTextBox.Size = new System.Drawing.Size(155, 22);
            this.costTextBox.TabIndex = 23;
            // 
            // roomTextBox
            // 
            this.roomTextBox.Location = new System.Drawing.Point(429, 250);
            this.roomTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.roomTextBox.Name = "roomTextBox";
            this.roomTextBox.Size = new System.Drawing.Size(155, 22);
            this.roomTextBox.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(252, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 29);
            this.label6.TabIndex = 26;
            this.label6.Text = "Showtimes";
            // 
            // Showtimes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 480);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.costTextBox);
            this.Controls.Add(this.roomTextBox);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.modifyButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.consultButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.movieTextBox);
            this.Controls.Add(this.dateTextBox);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.showtimesListbox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Showtimes";
            this.Text = "Showtimes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button modifyButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button consultButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox movieTextBox;
        private System.Windows.Forms.TextBox dateTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.ListBox showtimesListbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox costTextBox;
        private System.Windows.Forms.TextBox roomTextBox;
        private System.Windows.Forms.Label label6;
    }
}