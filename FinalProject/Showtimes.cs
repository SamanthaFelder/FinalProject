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
    public partial class Showtimes : Form
    {
        private const string DbServerHost = "localhost";
        private const string DbUsername = "postgres";
        private const string DbUuserPassword = "peteypete117";
        private const string DbName = "OOP";
        NpgsqlConnection dbConnection;

        public Showtimes()
        {
            InitializeComponent();
            SetDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            GetShowTimeFromDB();
        }

        List<ShowTime> foundShowTime = new List<ShowTime>();

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

        private List<ShowTime> GetShowTimeFromDB()
        {
            ShowTime currentShowTime;

            dbConnection.Open();

            // This is a string representing the SQL query to execute in the db.
            string sqlQuery = "SELECT * FROM showtime;";

            NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            NpgsqlDataReader dataReader = dbCommand.ExecuteReader();

            while (dataReader.Read())
            {
                currentShowTime = new ShowTime();

                currentShowTime.Id = dataReader.GetInt32(0);
                currentShowTime.Date = dataReader.GetDateTime(1);
                currentShowTime.MovieId = dataReader.GetInt32(2);
                currentShowTime.RoomCode = dataReader.GetString(3);
                currentShowTime.TicketPrice = dataReader.GetDouble(4);

                foundShowTime.Add(currentShowTime);

            }
            dbConnection.Close();

            return foundShowTime;
        }

        private void showtimesListbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void consultButton_Click(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

        private void modifyButton_Click(object sender, EventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }
    }
}
