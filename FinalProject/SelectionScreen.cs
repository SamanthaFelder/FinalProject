using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class SelectionScreen : Form
    {
        public SelectionScreen()
        {
            InitializeComponent();
        }

        private void screeningRoomsButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the ScreeningRooms class.
            ScreeningRooms myScreeningRoom = new ScreeningRooms();
            // Display the form.
            myScreeningRoom.ShowDialog();
        }

        private void moviesButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the Movies class.
            Movies myMovies = new Movies();
            // Display the form.
            myMovies.ShowDialog();
        }

        private void showtimesButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the Showtimes class.
            Showtimes myShowtimes = new Showtimes();
            // Display the form.
            myShowtimes.ShowDialog();
        }

        private void ticketsButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the Tickets class.
            Tickets myTickets = new Tickets();
            // Display the form.
            myTickets.ShowDialog();
        }

        private void clientsButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the Clients class.
            Clients myClients = new Clients();
            // Display the form.
            myClients.ShowDialog();
        }
    }
}
