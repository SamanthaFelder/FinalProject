using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace FinalProject
{
    public partial class ClientLogIn : Form
    {
        //Constants to use when creating DB connections
        private const string DbServerHost = "localhost";
        private const string DbUsername = "postgres";
        private const string DbUuserPassword = "peteypete117";
        private const string DbName = "OOP";
        public static int UserId;

        NpgsqlConnection dbConnection;
        public ClientLogIn()
        {
            InitializeComponent();
            SetDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            GetClientsFromDB();
        }

        List<Member> foundMembers = new List<Member>();

        private void SetDBConnection(string serverAddress, string username, string passwd, string dbName)
        {
            string conectionString = "Host=" + serverAddress + "; Username=" + username + "; Password=" + passwd + "; Database=" + dbName + ";";

            dbConnection = new NpgsqlConnection(conectionString);
        }

        private List<Member> GetClientsFromDB()
        {
            Member currentMember;

            dbConnection.Open();

            // This is a string representing the SQL query to execute in the db.
            string sqlQuery = "SELECT * FROM user_account;";

            NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            NpgsqlDataReader dataReader = dbCommand.ExecuteReader();

            while (dataReader.Read())
            {
                currentMember = new Member();

                currentMember.Id = dataReader.GetInt32(0);
                currentMember.Name = dataReader.GetString(1);
                currentMember.Password = dataReader.GetString(2);
                currentMember.Email = dataReader.GetString(3);
                currentMember.Type = dataReader.GetInt32(4);
                currentMember.SignUpTime = dataReader.GetDateTime(5);
                currentMember.Username = dataReader.GetString(6);

                foundMembers.Add(currentMember);

            }
            dbConnection.Close();

            return foundMembers;
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
            GetClientsFromDB();

            // Check if username exists, if the user is a client, and if the password is correct.
            if (foundMembers.Exists(x => x.Username == clientUserTextBox.Text && x.Type == 1 && x.Password == clientPassTextBox.Text))
            {
                foreach (Member member in foundMembers)
                {
                    if (member.Username == clientUserTextBox.Text && member.Type == 1 && member.Password == clientPassTextBox.Text)
                    { 
                           UserId = member.Id;
                    }
                }
                
                // Create an instance of the ClientSelection class.
                ClientSelection myClientSelection = new ClientSelection();
                // Display the form.
                myClientSelection.ShowDialog();

                
            }
            else
            {
                // Display an error message.
                MessageBox.Show("Username or Password incorrect");
            }
        }
    }
}
