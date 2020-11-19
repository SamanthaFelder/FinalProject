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
    public partial class Clients : Form
    {

        //Constants to use when creating DB connections
        private const string DbServerHost = "localhost";
        private const string DbUsername = "postgres";
        private const string DbUuserPassword = "peteypete117";
        private const string DbName = "OOP";

        NpgsqlConnection dbConnection;

        public Clients()
        {
            InitializeComponent();
            SetDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            GetClientsFromDB();

            clientListView.View = View.Details;
            clientListView.FullRowSelect = true;
            clientListView.GridLines = true;
            clientListView.Columns.Add("ID");
            clientListView.Columns.Add("Name");
            clientListView.Columns.Add("Username");
            clientListView.Columns.Add("Password");
            clientListView.Columns.Add("Email");
            clientListView.Columns.Add("SignUp Time");

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

                if (currentMember.Type == 1)
                {
                    clientListView.Items.Add(new ListViewItem(new[] { currentMember.Id.ToString(), currentMember.Name, currentMember.Username, currentMember.Password, currentMember.Email, currentMember.SignUpTime.ToString()}));
                }
            }

            dbConnection.Close();

            return foundMembers;
        }

        private void Clients_Load(object sender, EventArgs e)
        {

        }
    }
}
