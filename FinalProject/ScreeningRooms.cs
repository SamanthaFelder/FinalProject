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
            GetShowTimeFromDB();
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

        private List<ScreeningRoom> GetShowTimeFromDB()
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

                foundScreeningRoom.Add(currentScreeningRoom);

            }
            dbConnection.Close();

            return foundScreeningRoom;
        }

        private void screeningRoomsListbox_SelectedIndexChanged(object sender, EventArgs e)
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
