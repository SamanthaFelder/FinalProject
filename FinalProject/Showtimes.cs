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
            GetMovieFromDB();
            GetScreeningRoomFromDB();
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
                currentShowTime.Movie = LoadMovie(currentShowTime.MovieId);
                currentShowTime.ScreeningRoom = LoadScreeningRoom(currentShowTime.RoomCode);

                foundShowTime.Add(currentShowTime);
                showtimesListbox.Items.Add(currentShowTime.Id);

            }
            dbConnection.Close();

            return foundShowTime;
        }

        private List<Movie> LoadMovie(int MovieId)
        {
            //The following Connection, Command and DataReader objects will be used to access the jt_genre_movie table
            NpgsqlConnection dbConnection = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            NpgsqlCommand dbCommand;
            NpgsqlDataReader dataReader;

            Movie currentMovie;

            List<Movie> MovieList = new List<Movie>();

            dbConnection.Open();

            // This is a string representing the SQL query to execute in the db.
            string sqlQuery = "SELECT * FROM movie WHERE id = " + MovieId + ";";

            dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            dataReader = dbCommand.ExecuteReader();

            //While there are genre_codes in the dataReader2
            while (dataReader.Read())
            {
                currentMovie = new Movie();

                currentMovie.Id = dataReader.GetInt32(0);
                currentMovie.Title = dataReader.GetString(1);
                currentMovie.Year = dataReader.GetInt32(2);
                currentMovie.Length = dataReader.GetTimeSpan(3);
                currentMovie.Rating = dataReader.GetDouble(4);

                MovieList.Add(currentMovie);
            }
            dbConnection.Close();

            return MovieList;
        }

        private List<ScreeningRoom> LoadScreeningRoom(string ScreeningRoomCode)
        {
            //The following Connection, Command and DataReader objects will be used to access the jt_genre_movie table
            NpgsqlConnection dbConnection6 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            NpgsqlCommand dbCommand6;
            NpgsqlDataReader dataReader6;

            ScreeningRoom currentScreeningRoom;

            List<ScreeningRoom> ScreeningRoomList = new List<ScreeningRoom>();

            dbConnection6.Open();

            // This is a string representing the SQL query to execute in the db.
            string sqlQuery = "SELECT * FROM screening_room WHERE code = '" + ScreeningRoomCode + "';";

            dbCommand6 = new NpgsqlCommand(sqlQuery, dbConnection6);

            dataReader6 = dbCommand6.ExecuteReader();

            //While there are genre_codes in the dataReader2
            while (dataReader6.Read())
            {
                currentScreeningRoom = new ScreeningRoom();

                currentScreeningRoom.Code = dataReader6.GetString(0);
                currentScreeningRoom.Capacity = dataReader6.GetInt32(1);
                if (dataReader6.IsDBNull(2))
                {
                    currentScreeningRoom.Description = "";
                }
                else
                {
                    currentScreeningRoom.Description = dataReader6.GetString(2);
                }

                ScreeningRoomList.Add(currentScreeningRoom);
            }
            dbConnection6.Close();

            return ScreeningRoomList;
        }


         private int InsertShowTimeInDB(ShowTime ShowTime)
         {
            try
            {
                NpgsqlConnection dbConnection9 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
                NpgsqlCommand dbCommand9;

                //This variable will store the number of affecter rows by the INSERT query
                int queryResult;

                //Before sending commands to the database, the connection must be opened
                dbConnection9.Open();

                //This is a string representing the SQL query to execute in the db
                string sqlQuery1 = "INSERT INTO showtime VALUES('" + ShowTime.Id + "', '" + ShowTime.Date + "', '" + foundMovie[movieComboBox.SelectedIndex].Id + "', '" + ShowTime.RoomCode + "', '" + ShowTime.TicketPrice + "');";

                //This is the actual SQL containing the query to be executed
                dbCommand9 = new NpgsqlCommand(sqlQuery1, dbConnection9);

                queryResult = dbCommand9.ExecuteNonQuery();

                //After executing the query(ies) in the db, the connection must be closed
                dbConnection9.Close();

                return queryResult;

            }
            catch
            {
                MessageBox.Show("please enter a different screening room");

                NpgsqlConnection dbConnection9 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);

                dbConnection9.Close();

                return 0;
            }
        }

        private int ModifyShowTimeInDB(ShowTime ShowTime)
        {
           
                NpgsqlConnection dbConnection12 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);

                //This variable will store the number of affecter rows by the INSERT query
                int queryResult;

                //Before sending commands to the database, the connection must be opened
                dbConnection12.Open();

                //This is a string representing the SQL query to execute in the db           
                string sqlQuery = "UPDATE showtime SET date_time = '" + ShowTime.Date + "', ticket_price = '" + ShowTime.TicketPrice + "' WHERE id = '" + ShowTime.Id + "';";

                //This is the actual SQL containing the query to be executed
                NpgsqlCommand dbCommand12 = new NpgsqlCommand(sqlQuery, dbConnection12);

                queryResult = dbCommand12.ExecuteNonQuery();

                //After executing the query(ies) in the db, the connection must be closed
                dbConnection12.Close();

                return queryResult;
            
            
        }

        private int DeleteShowTimeInDB(ShowTime ShowTime)
        {
            try
            {
                NpgsqlConnection dbConnection15 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
                NpgsqlCommand dbCommand15;

                //This variable will store the number of affecter rows by the INSERT query
                int queryResult;

                //Before sending commands to the database, the connection must be opened
                dbConnection15.Open();

                //This is a string representing the SQL query to execute in the db
                string sqlQuery = "DELETE FROM showtime WHERE id = '" + ShowTime.Id + "';" + "DELETE FROM e_ticket WHERE showtime_id = '" + ShowTime.Id + "';";
                //This is the actual SQL containing the query to be executed
                dbCommand15 = new NpgsqlCommand(sqlQuery, dbConnection15);

                queryResult = dbCommand15.ExecuteNonQuery();

                //After executing the query(ies) in the db, the connection must be closed
                dbConnection15.Close();

                return queryResult;

            }
            catch
            {
                MessageBox.Show("please delete a different ScreeningRoom");

                NpgsqlConnection dbConnection15 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);

                dbConnection15.Close();

                return 0;
            }
        }

        private int SearchMoviesByName(string movieName)
        {
            int I = 0;
            foreach (ShowTime ShowTime in foundShowTime)
            {
                if (movieName != foundShowTime[I].Id.ToString())
                {
                    I++;
                }
            }
            return I;
        }

        private void showtimesListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (showtimesListbox.SelectedIndices.Count <= 0)
                {
                    return;
                }

                int index = showtimesListbox.SelectedIndices[0];
                string Name = showtimesListbox.Items[index].ToString();

                movieComboBox.Text = "";
                RoomComboBox.Text = "";
                movieComboBox.Items.Clear();
                RoomComboBox.Items.Clear();

                foreach (Movie Movie in foundShowTime[SearchMoviesByName(Name)].Movie)
                {

                    movieComboBox.Items.Add(Movie.Title);
                }

                foreach (ScreeningRoom ScreeningRoom in foundShowTime[SearchMoviesByName(Name)].ScreeningRoom)
                {

                    RoomComboBox.Items.Add(ScreeningRoom.Code);
                }

                idTextBox.Text = foundShowTime[SearchMoviesByName(Name)].Id.ToString();
                dateTextBox.Text = foundShowTime[SearchMoviesByName(Name)].Date.ToString();
                costTextBox.Text = foundShowTime[SearchMoviesByName(Name)].TicketPrice.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            ShowTime NewShowTime = new ShowTime();

            NewShowTime.Id = int.Parse(idTextBox.Text);
            NewShowTime.Date = DateTime.Parse(dateTextBox.Text);
            NewShowTime.RoomCode = RoomComboBox.Text;
            NewShowTime.TicketPrice = double.Parse(costTextBox.Text);

            foundShowTime.Clear();
            InsertShowTimeInDB(NewShowTime);
            showtimesListbox.Items.Clear();
            GetShowTimeFromDB();
           
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            ShowTime ModifyShowTime = new ShowTime();

            ModifyShowTime.Id = int.Parse(idTextBox.Text);
            ModifyShowTime.Date = DateTime.Parse(dateTextBox.Text);
            ModifyShowTime.RoomCode = RoomComboBox.Text;
            ModifyShowTime.TicketPrice = double.Parse(costTextBox.Text);

            foundShowTime.Clear();
            ModifyShowTimeInDB(ModifyShowTime);
            showtimesListbox.Items.Clear();
            GetShowTimeFromDB();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            ShowTime DeleteShowTime = new ShowTime();

            DeleteShowTime.Id = int.Parse(idTextBox.Text);
            DeleteShowTime.Date = DateTime.Parse(dateTextBox.Text);
            DeleteShowTime.RoomCode = RoomComboBox.Text;
            DeleteShowTime.TicketPrice = double.Parse(costTextBox.Text);

            foundShowTime.Clear();
            DeleteShowTimeInDB(DeleteShowTime);
            showtimesListbox.Items.Clear();
            GetShowTimeFromDB();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            idTextBox.Text = "";
            dateTextBox.Text = "";
            movieComboBox.Text = "";
            RoomComboBox.Text = "";
            movieComboBox.Items.Clear();
            RoomComboBox.Items.Clear();
            costTextBox.Text = "";
            GetScreeningRoomFromDB();
            GetMovieFromDB();
        }
    }
}
