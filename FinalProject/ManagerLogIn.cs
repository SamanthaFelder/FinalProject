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
    public partial class ManagerLogIn : Form
    {
        //Constants to use when creating DB connections
        private const string DbServerHost = "localhost";
        private const string DbUsername = "postgres";
        private const string DbUuserPassword = "peteypete117";
        private const string DbName = "OOP";

        NpgsqlConnection dbConnection;

        public ManagerLogIn()
        {
            InitializeComponent();
            SetDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            GetManagersFromDB();
        }

        List<Member> foundMembers = new List<Member>();

        private void SetDBConnection(string serverAddress, string username, string passwd, string dbName)
        {
            string conectionString = "Host=" + serverAddress + "; Username=" + username + "; Password=" + passwd + "; Database=" + dbName + ";";

            dbConnection = new NpgsqlConnection(conectionString);
        }

        private NpgsqlConnection CreateDBConnection(string serverAddress, string username, string passwd, string dbName)
        {
            string conectionString = "Host=" + serverAddress + "; Username=" + username + "; Password=" + passwd + "; Database=" + dbName + ";";

            dbConnection = new NpgsqlConnection(conectionString);

            return dbConnection;
        }
        private List<Member> GetManagersFromDB()
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
        private void managerLogInButton_Click(object sender, EventArgs e)
        {

            // Check if username exists, if the user is a manager, and if the password is correct.
            if (foundMembers.Exists(x => x.Username == managerUserTextBox.Text && x.Type == 2 && x.Password == managerPassTextBox.Text))
            {
                // Create an instance of the SelectionScreen class.
                SelectionScreen mySelectionScreen = new SelectionScreen();
                // Display the form.
                mySelectionScreen.ShowDialog();
            }
            else
            {
                // Display an error message.
                MessageBox.Show("Username or Password incorrect");
            }

        }
        }
    }

