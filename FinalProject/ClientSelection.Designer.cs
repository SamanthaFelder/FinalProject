namespace FinalProject
{
    partial class ClientSelection
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
            this.moviesListBox = new System.Windows.Forms.ListBox();
            this.showtimesListBox = new System.Windows.Forms.ListBox();
            this.moviesPictureBox = new System.Windows.Forms.PictureBox();
            this.buyButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.moviesPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // moviesListBox
            // 
            this.moviesListBox.FormattingEnabled = true;
            this.moviesListBox.ItemHeight = 16;
            this.moviesListBox.Location = new System.Drawing.Point(52, 55);
            this.moviesListBox.Margin = new System.Windows.Forms.Padding(4);
            this.moviesListBox.Name = "moviesListBox";
            this.moviesListBox.Size = new System.Drawing.Size(289, 356);
            this.moviesListBox.TabIndex = 0;
            this.moviesListBox.SelectedIndexChanged += new System.EventHandler(this.moviesListBox_SelectedIndexChanged);
            // 
            // showtimesListBox
            // 
            this.showtimesListBox.FormattingEnabled = true;
            this.showtimesListBox.ItemHeight = 16;
            this.showtimesListBox.Location = new System.Drawing.Point(653, 55);
            this.showtimesListBox.Margin = new System.Windows.Forms.Padding(4);
            this.showtimesListBox.Name = "showtimesListBox";
            this.showtimesListBox.Size = new System.Drawing.Size(289, 356);
            this.showtimesListBox.TabIndex = 1;
            this.showtimesListBox.SelectedIndexChanged += new System.EventHandler(this.showtimesListBox_SelectedIndexChanged);
            // 
            // moviesPictureBox
            // 
            this.moviesPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.moviesPictureBox.Location = new System.Drawing.Point(352, 55);
            this.moviesPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.moviesPictureBox.Name = "moviesPictureBox";
            this.moviesPictureBox.Size = new System.Drawing.Size(293, 356);
            this.moviesPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.moviesPictureBox.TabIndex = 2;
            this.moviesPictureBox.TabStop = false;
            // 
            // buyButton
            // 
            this.buyButton.Location = new System.Drawing.Point(700, 431);
            this.buyButton.Margin = new System.Windows.Forms.Padding(4);
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(212, 28);
            this.buyButton.TabIndex = 3;
            this.buyButton.Text = "Buy Ticket";
            this.buyButton.UseVisualStyleBackColor = true;
            this.buyButton.Click += new System.EventHandler(this.buyButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(315, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(353, 29);
            this.label4.TabIndex = 13;
            this.label4.Text = "Select a movie and showtime";
            // 
            // ClientSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 474);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buyButton);
            this.Controls.Add(this.moviesPictureBox);
            this.Controls.Add(this.showtimesListBox);
            this.Controls.Add(this.moviesListBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClientSelection";
            this.Text = "ClientSelection";
            ((System.ComponentModel.ISupportInitialize)(this.moviesPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox moviesListBox;
        private System.Windows.Forms.ListBox showtimesListBox;
        private System.Windows.Forms.PictureBox moviesPictureBox;
        private System.Windows.Forms.Button buyButton;
        private System.Windows.Forms.Label label4;
    }
}