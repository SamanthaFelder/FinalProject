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
    public partial class ClientSelection : Form
    {
        public ClientSelection()
        {
            InitializeComponent();
        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            // Write code to allow user to see ticket only after having selected a movie and showtime.
            // Create an instance of the ClientTicket class.
            ClientTicket myClientTicket = new ClientTicket();
            // Display the form.
            myClientTicket.ShowDialog();
        }
    }
}
