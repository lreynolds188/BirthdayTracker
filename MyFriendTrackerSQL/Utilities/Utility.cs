using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyFriendTrackerSQL.Utilities
{
    public class Utility
    {
        public static DataSet LoadBirthdays()
        {
            DataSet BirthdayData = new DataSet();
            var connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;

            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM tblBirthdays", connection);
            dataAdapter.Fill(BirthdayData);

            connection.Close();
            return BirthdayData;
        }

        public static void AddBirthday(string Name, string DoB, string Likes, string Dislikes){
            var connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;

            connection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [tblBirthdays] (Name, DateOfBirth, Likes, Dislikes) VALUES ('"+Name+"', '"+DoB+"', '"+Likes+"', '"+Dislikes+"')", connection);
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public static void UpdateBirthday(string CurrentName, string Name, string DoB, string Likes, string Dislikes)
        {
            var connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;

            connection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE tblBirthdays SET Name = '"+Name+"', DateOfBirth = '"+DoB+"', Likes = '"+Likes+"', Dislikes = '"+Dislikes+"' WHERE Name = '"+CurrentName+"'", connection);
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public static void DeleteBirthday(string Name)
        {
            var connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;
            
            connection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM tblBirthdays WHERE Name = '"+Name+"'", connection);
            cmd.ExecuteNonQuery();
            
            connection.Close();
        }

        public static int SearchBirthday(string SearchedName, DataSet BirthdayDataset)
        {
            for (int i = 0; i < BirthdayDataset.Tables[0].Rows.Count; i++)
            {
                DataRow BirthdayRow;
                BirthdayRow = BirthdayDataset.Tables[0].Rows[i];

                if (BirthdayRow.ItemArray.GetValue(1).ToString().ToLower().Equals(SearchedName) || BirthdayRow.ItemArray.GetValue(1).ToString().ToLower().Contains(SearchedName))
                {
                    return i;
                }
            }
            return -1;   
        }
    }
}
