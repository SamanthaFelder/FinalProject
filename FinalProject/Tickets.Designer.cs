﻿namespace FinalProject
{
    partial class Tickets
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
            this.ticketTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.moviesListBox = new System.Windows.Forms.ListBox();
            this.showtimesListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ticketTextBox
            // 
            this.ticketTextBox.Enabled = false;
            this.ticketTextBox.Location = new System.Drawing.Point(482, 147);
            this.ticketTextBox.Name = "ticketTextBox";
            this.ticketTextBox.ReadOnly = true;
            this.ticketTextBox.Size = new System.Drawing.Size(138, 20);
            this.ticketTextBox.TabIndex = 0;
            this.ticketTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(277, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "Tickets";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(495, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Number of tickets sold";
            // 
            // moviesListBox
            // 
            this.moviesListBox.FormattingEnabled = true;
            this.moviesListBox.Location = new System.Drawing.Point(12, 36);
            this.moviesListBox.Name = "moviesListBox";
            this.moviesListBox.Size = new System.Drawing.Size(218, 290);
            this.moviesListBox.TabIndex = 14;
            this.moviesListBox.SelectedIndexChanged += new System.EventHandler(this.moviesListBox_SelectedIndexChanged);
            // 
            // showtimesListBox
            // 
            this.showtimesListBox.FormattingEnabled = true;
            this.showtimesListBox.Location = new System.Drawing.Point(236, 36);
            this.showtimesListBox.Name = "showtimesListBox";
            this.showtimesListBox.Size = new System.Drawing.Size(218, 290);
            this.showtimesListBox.TabIndex = 15;
            this.showtimesListBox.SelectedIndexChanged += new System.EventHandler(this.showtimesListBox_SelectedIndexChanged);
            // 
            // Tickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 329);
            this.Controls.Add(this.showtimesListBox);
            this.Controls.Add(this.moviesListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ticketTextBox);
            this.Name = "Tickets";
            this.Text = "Tickets";
            this.Load += new System.EventHandler(this.Tickets_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ticketTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox moviesListBox;
        private System.Windows.Forms.ListBox showtimesListBox;
    }
}