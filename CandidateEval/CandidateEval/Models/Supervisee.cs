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
            ID = dataReader.GetValue<int>(nameof(ID));
            UserName = dataReader.GetValue<string>(nameof(UserName));
            Status = dataReader.GetValue<string>(nameof(Status));
            FirstName = dataReader.GetValue<string>(nameof(FirstName));
            LastName = dataReader.GetValue<string>(nameof(LastName));
            Lat = dataReader.GetValue<double>(nameof(Lat));
            Lng = dataReader.GetValue<double>(nameof(Lng));
        }

        public int ID { get; private set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        

        public static List<Supervisee> GetList()
        {
            var supervisees = new List<Supervisee>();
            
            var connectionString = ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString;
            
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (IDbCommand command = connection.CreateStoredProcedure($"{nameof(Supervisee)}_{nameof(GetList)}"))
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        supervisees.Add(new Supervisee(reader));
                    }
                }
            }
            
            return supervisees;
        }
    }
}