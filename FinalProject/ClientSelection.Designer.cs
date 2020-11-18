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
            this.moviesListBox.Location = new System.Drawing.Point(39, 45);
            this.moviesListBox.Name = "moviesListBox";
            this.moviesListBox.Size = new System.Drawing.Size(218, 290);
            this.moviesListBox.TabIndex = 0;
            // 
            // showtimesListBox
            // 
            this.showtimesListBox.FormattingEnabled = true;
            this.showtimesListBox.Location = new System.Drawing.Point(490, 45);
            this.showtimesListBox.Name = "showtimesListBox";
            this.showtimesListBox.Size = new System.Drawing.Size(218, 290);
            this.showtimesListBox.TabIndex = 1;
            // 
            // moviesPictureBox
            // 
            this.moviesPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.moviesPictureBox.Location = new System.Drawing.Point(264, 45);
            this.moviesPictureBox.Name = "moviesPictureBox";
            this.moviesPictureBox.Size = new System.Drawing.Size(220, 290);
            this.moviesPictureBox.TabIndex = 2;
            this.moviesPictureBox.TabStop = false;
            // 
            // buyButton
            // 
            this.buyButton.Location = new System.Drawing.Point(525, 350);
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(159, 23);
            this.buyButton.TabIndex = 3;
            this.buyButton.Text = "Buy Ticket";
            this.buyButton.UseVisualStyleBackColor = true;
            this.buyButton.Click += new System.EventHandler(this.buyButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(236, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(282, 24);
            this.label4.TabIndex = 13;
            this.label4.Text = "Select a movie and showtime";
            // 
            // ClientSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 385);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buyButton);
            this.Controls.Add(this.moviesPictureBox);
            this.Controls.Add(this.showtimesListBox);
            this.Controls.Add(this.moviesListBox);
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