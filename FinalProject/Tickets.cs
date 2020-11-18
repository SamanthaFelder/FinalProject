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
    public partial class Tickets : Form
    {
        //Constants to use when creating DB connections
        private const string DbServerHost = "localhost";
        private const string DbUsername = "postgres";
        private const string DbUuserPassword = "peteypete117";
        private const string DbName = "OOP";

        NpgsqlConnection dbConnection;
        public Tickets()
        {
            InitializeComponent();
            SetDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
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

        
        private void Tickets_Load(object sender, EventArgs e)
        {
            // Before sending commands to the database, the connection must be opened.
            dbConnection.Open();

            // This is a string representing the SQL query to execute in the database.
            string sqlQuery = "SELECT COUNT(*) FROM e_ticket;";

            // This is the actual SQL containing the query to be executed.
            NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            // Get ticket count from database.
            int count = Convert.ToInt32(dbCommand.ExecuteScalar());

            // Display the ticket count in the ticket textbox.
            ticketTextBox.Text = count.ToString();

            
        }

    }
}
