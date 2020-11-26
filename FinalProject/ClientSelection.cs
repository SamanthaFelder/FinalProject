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
    public partial class ClientSelection : Form
    {
        //Constants to use when creating DB connections
        private const string DbServerHost = "localhost";
        private const string DbUsername = "postgres";
        private const string DbUuserPassword = "peteypete117";
        private const string DbName = "OOP";
        public static DateTime Date;
        public static string Movie;
        public static string Room;
        public static string ShowTimeId;

        NpgsqlConnection dbConnection;

        public ClientSelection()
        {
             
            InitializeComponent();
            SetDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            GetMovieFromDB();
            GetShowTimeFromDB();
        }

        List<Movie> foundMovie = new List<Movie>();
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
                currentMovie.ShowTime = LoadShowTime(currentMovie.Id);

                if (dataReader.IsDBNull(5))
                {
                    currentMovie.Image = "";
                }
                else
                {
                    currentMovie.Image = dataReader.GetString(5);
                }
                foundMovie.Add(currentMovie);
                moviesListBox.Items.Add(currentMovie.Title);
            }
            dbConnection.Close();

            return foundMovie;
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

        private int InsertTicketInDB(Ticket ticket)
        {
            try
            {
                NpgsqlConnection dbConnection8 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
                NpgsqlCommand dbCommand8;

                //This variable will store the number of affecter rows by the INSERT query
                int queryResult;

                //Before sending commands to the database, the connection must be opened
                dbConnection8.Open();

                //This is a string representing the SQL query to execute in the db
                string sqlQuery = "INSERT INTO e_ticket VALUES('" + ticket.Id + "', '" + ticket.Purchase_date_time + "', '" + ticket.ShowTimeId + "' , '" + ticket.UserId + "');";

                //This is the actual SQL containing the query to be executed
                dbCommand8 = new NpgsqlCommand(sqlQuery, dbConnection8);

                queryResult = dbCommand8.ExecuteNonQuery();

                //After executing the query(ies) in the db, the connection must be closed
                dbConnection8.Close();

                return queryResult;

            }
            catch
            {
                MessageBox.Show("please enter a different member");

                NpgsqlConnection dbConnection8 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);

                dbConnection8.Close();

                return 0;
            }

        }

        private List<ShowTime> LoadShowTime(int movieID)
        {
            //The following Connection, Command and DataReader objects will be used to access the jt_genre_movie table
            NpgsqlConnection dbConnection6 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            NpgsqlCommand dbCommand6;
            NpgsqlDataReader dataReader6;

            ShowTime currentShowTime;

            List<ShowTime> ShowTimeList = new List<ShowTime>();

            dbConnection6.Open();

            // This is a string representing the SQL query to execute in the db.
            string sqlQuery = "SELECT * FROM showtime WHERE movie_id = " + movieID + ";";

            dbCommand6 = new NpgsqlCommand(sqlQuery, dbConnection6);

            dataReader6 = dbCommand6.ExecuteReader();

            //While there are genre_codes in the dataReader2
            while (dataReader6.Read())
            {
                currentShowTime = new ShowTime();

                currentShowTime.Id = dataReader6.GetInt32(0);
                currentShowTime.Date = dataReader6.GetDateTime(1);
                currentShowTime.MovieId = dataReader6.GetInt32(2);
                currentShowTime.RoomCode = dataReader6.GetString(3);
                currentShowTime.TicketPrice = dataReader6.GetDouble(4);

                ShowTimeList.Add(currentShowTime);
            }
            dbConnection6.Close();

            return ShowTimeList;
        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            // Write code to allow user to see ticket only after having selected a movie and showtime.
            // Create an instance of the ClientTicket class.
            ClientTicket myClientTicket = new ClientTicket();
            // Display the form.
            myClientTicket.ShowDialog();
            
            Ticket NewTicket = new Ticket();
            Random r = new Random();

            var x = r.Next(0, 1000000);
            string s = x.ToString("000000");
            
            //if s dosent already exist
            NewTicket.Id = int.Parse(s);
            NewTicket.Purchase_date_time = DateTime.Now;
            NewTicket.ShowTimeId = int.Parse(ShowTimeId);
            NewTicket.UserId = ClientLogIn.UserId;

            InsertTicketInDB(NewTicket);
            
        }

        private int SearchMoviesByName(string movieName)
        {
            int I = 0;
            foreach (Movie movies in foundMovie)
            {
                if (movieName != foundMovie[I].Title)
                {
                    I++;
                }
            }
            return I;
        }

        private void moviesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showtimesListBox.Items.Clear();

            try
            {
                if (moviesListBox.SelectedIndices.Count <= 0)
                {
                    return;
                }

                

                int index = moviesListBox.SelectedIndices[0];
                string Name = moviesListBox.Items[index].ToString();

                Movie = foundMovie[SearchMoviesByName(Name)].Title;
                
                if (foundMovie[SearchMoviesByName(Name)].Image != "")
                {
                    moviesPictureBox.ImageLocation = foundMovie[SearchMoviesByName(Name)].Image;
                }
                else
                {
                    moviesPictureBox.ImageLocation = "";
                }

                foreach (ShowTime ShowTime in foundMovie[SearchMoviesByName(Name)].ShowTime)
                {
                    showtimesListBox.Items.Add(ShowTime.Date);

                    if (foundMovie[SearchMoviesByName(Name)].Id == ShowTime.MovieId)
                    {
                       
                        Date = ShowTime.Date;
                        Room = ShowTime.RoomCode;
                        ShowTimeId = ShowTime.Id.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
//to check seleted date
//if s dosent already exist
//show price and hour on list showtime
//witch movie is with witch ticket
//show after current date showtimes