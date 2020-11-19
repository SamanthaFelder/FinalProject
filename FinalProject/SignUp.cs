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
    public partial class SignUp : Form { 

        //Constants to use when creating DB connections
        private const string DbServerHost = "localhost";
        private const string DbUsername = "postgres";
        private const string DbUuserPassword = "peteypete117";
        private const string DbName = "OOP";

        NpgsqlConnection dbConnection;
    
        public SignUp()
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

        private int InsertMemberInDB(Member member)
        {
                
                //This variable will store the number of affecter rows by the INSERT query
                int queryResult;

                //Before sending commands to the database, the connection must be opened
                dbConnection.Open();

                //This is a string representing the SQL query to execute in the db
                string sqlQuery = "INSERT INTO user_account VALUES('" + member.Id + "', '" + member.Name + "', '" + member.Password + "', '" + member.Email + "', '" + member.Type
                + "', '"+ member.SignUpTime + "', '"+ member.Username + "');";

                //This is the actual SQL containing the query to be executed
                NpgsqlCommand dbCommand = new NpgsqlCommand(sqlQuery, dbConnection);

                queryResult = dbCommand.ExecuteNonQuery();

                //After executing the query(ies) in the db, the connection must be closed
                dbConnection.Close();

                return queryResult;
            
            
        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {
            Member newMember = new Member();

            newMember.Id = int.Parse(idTextBox.Text);
            newMember.Name = nameTextBox.Text;
            newMember.Username = usernameTextBox.Text;
            newMember.Password = passwordTextBox.Text;
            newMember.Email = emailTextBox.Text;
            newMember.Type = 1;
            newMember.SignUpTime = DateTime.Now;

            InsertMemberInDB(newMember);
            this.Close();

        }
    }
}
