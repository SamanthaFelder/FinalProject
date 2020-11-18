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
    public partial class Form1 : Form
    {
        //Constants to use when creating DB connections
        private const string DbServerHost = "localhost";
        private const string DbUsername = "postgres";
        private const string DbUuserPassword = "peteypete117";
        private const string DbName = "OOP";

        NpgsqlConnection dbConnection;
        public Form1()
        {
            InitializeComponent();

            SetDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);

            CheckPostgresVersion();
        }

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

        /// <summary>
        /// This method displays the version of the Postgres server to which the program connects to.
        /// </summary>
        private void CheckPostgresVersion()
        {
            dbConnection.Open();

            string sqlQuery = "SELECT version()";

            NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            string postgresVersion = dbCommand.ExecuteScalar().ToString();

            dbConnection.Close();
        }

        private void managerButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the ManagerLogIn class.
            ManagerLogIn myManagerLogIn = new ManagerLogIn();
            // Display the form.
            myManagerLogIn.ShowDialog();
        }

        private void clientButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the ClientLogIn class.
            ClientLogIn myClientLogIn = new ClientLogIn();
            // Display the form.
            myClientLogIn.ShowDialog();
        }
    }
}
