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
    public partial class ScreeningRooms : Form
    {
        private const string DbServerHost = "localhost";
        private const string DbUsername = "postgres";
        private const string DbUuserPassword = "peteypete117";
        private const string DbName = "OOP";
        NpgsqlConnection dbConnection;

        public ScreeningRooms()
        {
            InitializeComponent();
            SetDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);
            GetScreeningRoomFromDB();
        }

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
                if (dataReader.IsDBNull(2))
                {
                    currentScreeningRoom.Description = "";
                }
                else
                {
                    currentScreeningRoom.Description = dataReader.GetString(2);
                }
                screeningRoomsListbox.Items.Add(currentScreeningRoom.Code);
                foundScreeningRoom.Add(currentScreeningRoom);

            }
            dbConnection.Close();

            return foundScreeningRoom;
        }

        private int InsertScreeningRoomInDB(ScreeningRoom ScreeningRoom)
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
                string sqlQuery1 = "INSERT INTO screening_room VALUES('" + ScreeningRoom.Code + "', '" + ScreeningRoom.Capacity + "', '" + ScreeningRoom.Description + "');";

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

        private int ModifyScreeningRoomInDB(ScreeningRoom ScreeningRoom)
        {
            try
            {
                NpgsqlConnection dbConnection12 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);

                //This variable will store the number of affecter rows by the INSERT query
                int queryResult;

                //Before sending commands to the database, the connection must be opened
                dbConnection12.Open();

                //This is a string representing the SQL query to execute in the db           
                string sqlQuery = "UPDATE screening_room SET capacity = '" + ScreeningRoom.Capacity + "', description = '" + ScreeningRoom.Description +  "' WHERE code = '" + ScreeningRoom.Code + "';";

                //This is the actual SQL containing the query to be executed
                NpgsqlCommand dbCommand12 = new NpgsqlCommand(sqlQuery, dbConnection12);

                queryResult = dbCommand12.ExecuteNonQuery();

                //After executing the query(ies) in the db, the connection must be closed
                dbConnection12.Close();

                return queryResult;
            }
            catch
            {
                MessageBox.Show("please Modify a different ScreeningRoom");

                NpgsqlConnection dbConnection12 = CreateDBConnection(DbServerHost, DbUsername, DbUuserPassword, DbName);

                dbConnection12.Close();

                return 0;
            }
        }

        private int DeleteScreeningRoomInDB(ScreeningRoom ScreeningRoom)
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
                string sqlQuery = "DELETE FROM screening_room WHERE code = '" + ScreeningRoom.Code + "';" + "DELETE FROM showtime WHERE s_room_code = '" + ScreeningRoom.Code + "';";
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


        private void screeningRoomsListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (screeningRoomsListbox.SelectedIndices.Count <= 0)
                {
                    return;
                }

                int index = screeningRoomsListbox.SelectedIndices[0];

                codeTextBox.Text = foundScreeningRoom[index].Code;
                capacityTextBox.Text = foundScreeningRoom[index].Capacity.ToString();
                descriptionTextBox.Text = foundScreeningRoom[index].Description;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            ScreeningRoom NewScreeningRoom = new ScreeningRoom();

            NewScreeningRoom.Code = codeTextBox.Text;
            NewScreeningRoom.Capacity = int.Parse(capacityTextBox.Text);
            NewScreeningRoom.Description = descriptionTextBox.Text;

            foundScreeningRoom.Clear();
            InsertScreeningRoomInDB(NewScreeningRoom);
            screeningRoomsListbox.Items.Clear();
            GetScreeningRoomFromDB();
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            ScreeningRoom ModifyScreeningRoom = new ScreeningRoom();

            ModifyScreeningRoom.Code = codeTextBox.Text;
            ModifyScreeningRoom.Capacity = int.Parse(capacityTextBox.Text);
            ModifyScreeningRoom.Description = descriptionTextBox.Text;

            ModifyScreeningRoomInDB(ModifyScreeningRoom);
            screeningRoomsListbox.Items.Clear();
            foundScreeningRoom.Clear();
            GetScreeningRoomFromDB();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            ScreeningRoom DeleteScreeningRoom = new ScreeningRoom();

            DeleteScreeningRoom.Code = codeTextBox.Text;
            DeleteScreeningRoom.Capacity = int.Parse(capacityTextBox.Text);
            DeleteScreeningRoom.Description = descriptionTextBox.Text;

            DeleteScreeningRoomInDB(DeleteScreeningRoom);
            screeningRoomsListbox.Items.Clear();
            foundScreeningRoom.Clear();
            GetScreeningRoomFromDB();
        }
    }
}
