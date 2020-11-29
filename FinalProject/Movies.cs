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
    public partial class Movies : Form
    {
        private const string DbServerHost = "localhost";
        private const string DbUsername = "postgres";
        private const string DbUuserPassword = "peteypete117";
        private const string DbName = "OOP";
        NpgsqlConnection dbConnection;

        public Movies()
        {
            InitializeComponent();
            SetDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            GetMovieFromDB();
            GetGenreFromDB();
        }

        List<Movie> foundMovie = new List<Movie>();
        List<Genre> foundGenre = new List<Genre>();

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

        private List<Genre> GetGenreFromDB()
        {
            Genre currentGenre;

            dbConnection.Open();

            // This is a string representing the SQL query to execute in the db.
            string sqlQuery = "SELECT * FROM genre;";

            NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

            NpgsqlDataReader dataReader = dbCommand.ExecuteReader();

            while (dataReader.Read())
            {
                currentGenre = new Genre();

                currentGenre.Code = dataReader.GetString(0);
                currentGenre.Name = dataReader.GetString(1);
                

                foundGenre.Add(currentGenre);
                genreComboBox.Items.Add(currentGenre.Name);

            }
            dbConnection.Close();

            return foundGenre;
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
                currentMovie.Genres = LoadMovieGenres(currentMovie.Id);
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

        private List<Genre> LoadMovieGenres(int movieID)
        {
            //The following Connection, Command and DataReader objects will be used to access the jt_genre_movie table
            NpgsqlConnection dbConnection2 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            NpgsqlCommand dbCommand2;
            NpgsqlDataReader dataReader2;

            //The following Connection, Command and DataReader objects will be used to access the genre table
            NpgsqlConnection dbConnection3 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            NpgsqlCommand dbCommand3;
            NpgsqlDataReader dataReader3;

            string currentGenreCode;

            Genre currentGenre;

            List<Genre> GenreList = new List<Genre>();

            dbConnection2.Open();

            // This is a string representing the SQL query to execute in the db.
            string sqlQuery = "SELECT genre_code FROM jt_genre_movie WHERE movie_id = " + movieID + ";";

            dbCommand2 = new NpgsqlCommand(sqlQuery, dbConnection2);

            dataReader2 = dbCommand2.ExecuteReader();

            //While there are genre_codes in the dataReader2
            while (dataReader2.Read())
            {
                currentGenre = new Genre();

                currentGenreCode = dataReader2.GetString(0);

                //Open a connection to access the 'genre' table
                dbConnection3.Open();

                // This is a string representing the SQL query to execute in the db.
                sqlQuery = "SELECT * FROM genre WHERE code = '" + currentGenreCode + "';";

                dbCommand3 = new NpgsqlCommand(sqlQuery, dbConnection3);

                dataReader3 = dbCommand3.ExecuteReader();

                //Read a line from the 'genre' table
                dataReader3.Read();

                currentGenre.Code = dataReader3.GetString(0);
                currentGenre.Name = dataReader3.GetString(1);
                if (dataReader3.IsDBNull(2))
                {
                    currentGenre.Description = "";
                }
                else
                {
                    currentGenre.Description = dataReader3.GetString(2);
                }
                GenreList.Add(currentGenre);

                dbConnection3.Close();
            }
            dbConnection2.Close();

            return GenreList;
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

        private int CheakIfMovieExist(int movieID, string movieName)
        {
            //The following Connection, Command and DataReader objects will be used to access the jt_genre_movie table
            NpgsqlConnection dbConnection6 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            NpgsqlCommand dbCommand6;
            NpgsqlDataReader dataReader6;

            dbConnection6.Open();

            // This is a string representing the SQL query to execute in the db.
            string sqlQuery = "SELECT * FROM movie WHERE id = " + movieID + ";";

            dbCommand6 = new NpgsqlCommand(sqlQuery, dbConnection6);

            dataReader6 = dbCommand6.ExecuteReader();

            int i = 0;

            //While there are genre_codes in the dataReader2
            while (dataReader6.Read())
            {
                i++;
            }
            dbConnection6.Close();

            return i;
        }

        private int ModifyMovieInDB(Movie movie)
        {
            try
            {
                NpgsqlConnection dbConnection12 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);

                //This variable will store the number of affecter rows by the INSERT query
                int queryResult;

                //Before sending commands to the database, the connection must be opened
                dbConnection12.Open();

                //This is a string representing the SQL query to execute in the db           
                string sqlQuery = "UPDATE movie SET image_file_path = '" + movie.Image + "', title = '" + movie.Title + "', year = '"
                        + movie.Year + "', length = '" + movie.Length + "', audience_rating = '" + movie.Rating + "' WHERE id = " + movie.Id + ";";

                //This is the actual SQL containing the query to be executed
                NpgsqlCommand dbCommand12 = new NpgsqlCommand(sqlQuery, dbConnection12);

                queryResult = dbCommand12.ExecuteNonQuery();

                //After executing the query(ies) in the db, the connection must be closed
                dbConnection12.Close();

                return queryResult;
            }
            catch
            {
                MessageBox.Show("please Modify a different movie");

                NpgsqlConnection dbConnection12 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);

                dbConnection12.Close();

                return 0;
            }
        }

        private int InsertMovieInDB(Movie movie)
        {
            try
            {
                NpgsqlConnection dbConnection9 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
                NpgsqlCommand dbCommand9;

                NpgsqlConnection dbConnection = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
                NpgsqlCommand dbCommand;

                //This variable will store the number of affecter rows by the INSERT query
                int queryResult;

                //Before sending commands to the database, the connection must be opened
                dbConnection9.Open();

                if (CheakIfMovieExist(movie.Id, movie.Title) == 0)
                {
                    //This is a string representing the SQL query to execute in the db
                    string sqlQuery1 = "INSERT INTO movie VALUES('" + movie.Id + "', '" + movie.Title + "', '"
                    + movie.Year + "', '" + movie.Length + "', '" + movie.Rating + "', '" + movie.Image + "');";

                    //This is the actual SQL containing the query to be executed
                    dbCommand9 = new NpgsqlCommand(sqlQuery1, dbConnection9);

                    queryResult = dbCommand9.ExecuteNonQuery();

                }

                dbConnection.Open();
                string sqlQuery = "INSERT INTO jt_genre_movie VALUES('" + movie.Code + "', '" + movie.Id + "');";

                dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

                queryResult = dbCommand.ExecuteNonQuery();

                //After executing the query(ies) in the db, the connection must be closed
                dbConnection9.Close();
                dbConnection.Close();

                return queryResult;

            }
            catch
            {
                MessageBox.Show("please enter a different movie");

                NpgsqlConnection dbConnection9 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);

                dbConnection9.Close();

                return 0;
            }
        }

        private int DeleteMovieInDB(Movie movie)
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
                string sqlQuery = "DELETE FROM jt_movie_member WHERE movie_id = '" + movie.Id + "';" + "DELETE FROM jt_genre_movie WHERE movie_id = '" + movie.Id + "';" + "DELETE FROM showtime WHERE movie_id = '" + movie.Id + "';" + "DELETE FROM movie WHERE id = '" + movie.Id + "';";

                //This is the actual SQL containing the query to be executed
                dbCommand15 = new NpgsqlCommand(sqlQuery, dbConnection15);

                queryResult = dbCommand15.ExecuteNonQuery();

                //After executing the query(ies) in the db, the connection must be closed
                dbConnection15.Close();

                return queryResult;

            }
            catch
            {
                MessageBox.Show("please delete a different movie");

                NpgsqlConnection dbConnection15 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);

                dbConnection15.Close();

                return 0;
            }
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

            try
            {
                if (moviesListBox.SelectedIndices.Count <= 0)
                {
                    return;
                }

                int index = moviesListBox.SelectedIndices[0];
                string Name = moviesListBox.Items[index].ToString();

                genreComboBox.Items.Clear();
                genreComboBox.Text = "";

                foreach (Genre genre in foundMovie[SearchMoviesByName(Name)].Genres)
                {

                    genreComboBox.Items.Add(genre.Name);
                }

                idTextBox.Text = foundMovie[SearchMoviesByName(Name)].Id.ToString();
                titleTextBox.Text = foundMovie[SearchMoviesByName(Name)].Title;
                yearTextBox.Text = foundMovie[SearchMoviesByName(Name)].Year.ToString();
                lengthTextBox.Text = foundMovie[SearchMoviesByName(Name)].Length.ToString();
                ratingTextBox.Text = foundMovie[SearchMoviesByName(Name)].Rating.ToString("N2");
                imageTextBox.Text = foundMovie[SearchMoviesByName(Name)].Image;

                if (foundMovie[SearchMoviesByName(Name)].Image != "")
                {
                    moviesPictureBox.ImageLocation = foundMovie[SearchMoviesByName(Name)].Image;
                }
                else
                {
                    moviesPictureBox.ImageLocation = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Movie NewMovie = new Movie();
           
            NewMovie.Id = int.Parse(idTextBox.Text);
            NewMovie.Title = titleTextBox.Text;
            NewMovie.Year = int.Parse(yearTextBox.Text);
            NewMovie.Length = TimeSpan.Parse(lengthTextBox.Text);
            NewMovie.Rating = double.Parse(ratingTextBox.Text);
            NewMovie.Image = imageTextBox.Text;

            foundMovie.Clear();
            InsertMovieInDB(NewMovie);
            moviesListBox.Items.Clear();
            moviesPictureBox.ImageLocation = "";
            GetMovieFromDB();

        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            Movie ModifyMovie = new Movie();

            ModifyMovie.Id = int.Parse(idTextBox.Text);
            ModifyMovie.Title = titleTextBox.Text;
            ModifyMovie.Year = int.Parse(yearTextBox.Text);
            ModifyMovie.Length = TimeSpan.Parse(lengthTextBox.Text);
            ModifyMovie.Rating = double.Parse(ratingTextBox.Text);
            ModifyMovie.Image = imageTextBox.Text;

            foundMovie.Clear();
            ModifyMovieInDB(ModifyMovie);
            moviesListBox.Items.Clear();
            moviesPictureBox.ImageLocation = "";
            GetMovieFromDB();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Movie DeleteMovie = new Movie();

            DeleteMovie.Id = int.Parse(idTextBox.Text);
            DeleteMovie.Title = titleTextBox.Text;
            DeleteMovie.Year = int.Parse(yearTextBox.Text);
            DeleteMovie.Length = TimeSpan.Parse(lengthTextBox.Text);
            DeleteMovie.Rating = double.Parse(ratingTextBox.Text);
            DeleteMovie.Image = imageTextBox.Text;

            foundMovie.Clear();
            DeleteMovieInDB(DeleteMovie);
            moviesListBox.Items.Clear();
            moviesPictureBox.ImageLocation = "";
            GetMovieFromDB();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            idTextBox.Text = "";
            titleTextBox.Text = "";
            yearTextBox.Text = "";
            lengthTextBox.Text = "";
            ratingTextBox.Text = "";
            genreComboBox.Text = "";
            genreComboBox.Items.Clear();
            moviesPictureBox.ImageLocation = "";
            imageTextBox.Text = "";
            moviesListBox.Items.Clear();
            GetMovieFromDB();
            GetGenreFromDB();
        }
    }//how to insert genre code with genre name
}
