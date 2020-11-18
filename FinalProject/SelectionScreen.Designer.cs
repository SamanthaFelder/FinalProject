namespace FinalProject
{
    partial class SelectionScreen
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
            this.showtimesButton = new System.Windows.Forms.Button();
            this.moviesButton = new System.Windows.Forms.Button();
            this.screeningRoomsButton = new System.Windows.Forms.Button();
            this.ticketsButton = new System.Windows.Forms.Button();
            this.clientsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // showtimesButton
            // 
            this.showtimesButton.Location = new System.Drawing.Point(77, 115);
            this.showtimesButton.Name = "showtimesButton";
            this.showtimesButton.Size = new System.Drawing.Size(100, 43);
            this.showtimesButton.TabIndex = 0;
            this.showtimesButton.Text = "Showtimes";
            this.showtimesButton.UseVisualStyleBackColor = true;
            this.showtimesButton.Click += new System.EventHandler(this.showtimesButton_Click);
            // 
            // moviesButton
            // 
            this.moviesButton.Location = new System.Drawing.Point(213, 115);
            this.moviesButton.Name = "moviesButton";
            this.moviesButton.Size = new System.Drawing.Size(100, 43);
            this.moviesButton.TabIndex = 1;
            this.moviesButton.Text = "Movies";
            this.moviesButton.UseVisualStyleBackColor = true;
            this.moviesButton.Click += new System.EventHandler(this.moviesButton_Click);
            // 
            // screeningRoomsButton
            // 
            this.screeningRoomsButton.Location = new System.Drawing.Point(346, 115);
            this.screeningRoomsButton.Name = "screeningRoomsButton";
            this.screeningRoomsButton.Size = new System.Drawing.Size(100, 43);
            this.screeningRoomsButton.TabIndex = 2;
            this.screeningRoomsButton.Text = "Screening Rooms";
            this.screeningRoomsButton.UseVisualStyleBackColor = true;
            this.screeningRoomsButton.Click += new System.EventHandler(this.screeningRoomsButton_Click);
            // 
            // ticketsButton
            // 
            this.ticketsButton.Location = new System.Drawing.Point(137, 190);
            this.ticketsButton.Name = "ticketsButton";
            this.ticketsButton.Size = new System.Drawing.Size(100, 43);
            this.ticketsButton.TabIndex = 3;
            this.ticketsButton.Text = "Tickets";
            this.ticketsButton.UseVisualStyleBackColor = true;
            this.ticketsButton.Click += new System.EventHandler(this.ticketsButton_Click);
            // 
            // clientsButton
            // 
            this.clientsButton.Location = new System.Drawing.Point(284, 190);
            this.clientsButton.Name = "clientsButton";
            this.clientsButton.Size = new System.Drawing.Size(100, 43);
            this.clientsButton.TabIndex = 4;
            this.clientsButton.Text = "Clients";
            this.clientsButton.UseVisualStyleBackColor = true;
            this.clientsButton.Click += new System.EventHandler(this.clientsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(133, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select to view and/or edit";
            // 
            // SelectionScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 290);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clientsButton);
            this.Controls.Add(this.ticketsButton);
            this.Controls.Add(this.screeningRoomsButton);
            this.Controls.Add(this.moviesButton);
            this.Controls.Add(this.showtimesButton);
            this.Name = "SelectionScreen";
            this.Text = "SelectionScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button showtimesButton;
        private System.Windows.Forms.Button moviesButton;
        private System.Windows.Forms.Button screeningRoomsButton;
        private System.Windows.Forms.Button ticketsButton;
        private System.Windows.Forms.Button clientsButton;
        private System.Windows.Forms.Label label1;
    }
}