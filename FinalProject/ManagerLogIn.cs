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
    public partial class ManagerLogIn : Form
    {
        public ManagerLogIn()
        {
            InitializeComponent();
        }

        private void managerLogInButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the SelectionScreen class.
            SelectionScreen mySelectionScreen = new SelectionScreen();
            // Display the form.
            mySelectionScreen.ShowDialog();
        }
    }
}
