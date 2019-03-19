using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CandidateEval.Models
{
    public class Supervisee
    {
        private Supervisee(IDataReader dataReader)
        {
            ID = (int)dataReader["ID"];
            UserName = (string)dataReader["UserName"];
            Status = (string)dataReader["Status"];
            FirstName = (string)dataReader["FirstName"];
            LastName = (string)dataReader["UserName"];
            Lat = (double)dataReader["Lat"];
            Lng = (double)dataReader["Lng"];
        }

        public int ID { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }

        public static List<Supervisee> GetList()
        {
            List<Supervisee> supervisees = new List<Supervisee>();

            string cmdText = @"
                SELECT 
                    ID,
                    UserName,
                    Status,
                    FirstName,
                    LastName,
                    Lat,
                    Lng
                FROM
                    Supervisee";
            
            string connectionString = ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString;
            
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(cmdText, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Supervisee supervisee = new Supervisee(reader);
                            supervisees.Add(supervisee);
                        }
                    }
                }
            }

            return supervisees;
        }
    }
}