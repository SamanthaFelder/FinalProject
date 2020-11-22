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
    public partial class ClientTicket : Form
    {
        public ClientTicket()
        {
            InitializeComponent();
        }

        private void ClientTicket_Load(object sender, EventArgs e)
        {
            textBox1.Text = ClientSelection.Date.ToString();
            textBox2.Text = ClientSelection.Movie;
            textBox3.Text = ClientSelection.Room;
        }
    }
}
