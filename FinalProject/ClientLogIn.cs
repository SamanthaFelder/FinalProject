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
    public partial class ClientLogIn : Form
    {
        public ClientLogIn()
        {
            InitializeComponent();
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the SignUp class.
            SignUp mySignUp = new SignUp();
            // Display the form.
            mySignUp.ShowDialog();
        }

        private void clientLogInButton_Click(object sender, EventArgs e)
        {
            // Write code so that they can only access this form after successfully loging in.
            // User must have an account in order to log in.
            // Create an instance of the ClientSelection class.
            ClientSelection myClientSelection = new ClientSelection();
            // Display the form.
            myClientSelection.ShowDialog();
        }
    }
}
