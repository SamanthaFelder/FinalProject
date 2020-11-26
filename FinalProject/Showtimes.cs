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
            GetScreeningRoomFromDB();
            GetMovieFromDB();
        }

        List<ShowTime> foundShowTime = new List<ShowTime>();
        List<Movie> foundMovie = new List<Movie>();
        List<ScreeningRoom> foundScreeningRoom = new List<ScreeningRoom>();

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
                showtimesListbox.Items.Add(currentShowTime.Id);

            }
            dbConnection.Close();

            return foundShowTime;
        }

        private List<Movie> GetMovieFromDB()
        {
            Movie currentMovie;

            dbConnection.Open();

            // This is a string representing the SQL query to execute in the db.
            string sqlQuery = "SELECT * FROM movie;";

            NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            NpgsqlDataReader dataReader = dbCommand.ExecuteReader();

            while (dataReader.Read())
            {
                currentMovie = new Movie();

                currentMovie.Id = dataReader.GetInt32(0);
                currentMovie.Title = dataReader.GetString(1);
                currentMovie.Year = dataReader.GetInt32(2);
                currentMovie.Length = dataReader.GetTimeSpan(3);
                currentMovie.Rating = dataReader.GetDouble(4);
               
                foundMovie.Add(currentMovie);
                movieComboBox.Items.Add(currentMovie.Title);
              
            }
            dbConnection.Close();

            return foundMovie;
        }

        private List<ScreeningRoom> GetScreeningRoomFromDB()
        {
            ScreeningRoom currentScreeningRoom;

            dbConnection.Open();

            // This is a string representing the SQL query to execute in the db.
            string sqlQuery = "SELECT * FROM screening_room;";

            NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            NpgsqlDataReader dataReader = dbCommand.ExecuteReader();

            while (dataReader.Read())
            {
                currentScreeningRoom = new ScreeningRoom();

                currentScreeningRoom.Code = dataReader.GetString(0);
                currentScreeningRoom.Capacity = dataReader.GetInt32(1);
               
                foundScreeningRoom.Add(currentScreeningRoom);
                RoomComboBox.Items.Add(currentScreeningRoom.Code);

            }
            dbConnection.Close();

            return foundScreeningRoom;
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
