using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace CandidateEval.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<string> supervisees = new List<string>();
            string cmdText =
                @"  select 
                        [Supervisee].ID AS [Supervisee.ID],
                        [Supervisee].UserName AS [Supervisee.UserName],
                        [SuperVisee].[Status] AS [Supervisee.Status],
                        [SuperVisee].[FirstName] AS [Supervisee.FirstName],
                        [SuperVisee].[LastName] AS [Supervisee.LastName],
                        [SuperVisee].Lat AS [Supervisee.Lat],
                        [SuperVisee].Lng AS [Supervisee.Lng]
                    from Supervisee
                ";

            //get connection settings from config file
            string connectionString = ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString;

            // Set up connection/command.
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(cmdText, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            supervisees.Add((string)reader["Supervisee.UserName"]);
                        }
                    }
                }
            }
            ViewBag.supervisees = supervisees;
            return View();
        }

    }
}