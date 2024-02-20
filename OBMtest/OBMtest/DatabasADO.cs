using OBMtest.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace OBMtest
{
    internal class DatabasADO
    {
        public static List<Models.Car> GetAllCars()
        {
            string connString = "data source = .\\SQLExpress;" +
                "initial catalog = parking10;" +
                "persist security info = True;" +
                "Integrated Security = True;";
            string sql = "SELECT * FROM Cars";
            List<Models.Car> cars = new List<Models.Car>();

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    using(var reader = command.ExecuteReader()) 
                    { 
                        while(reader.Read()) 
                        {
                            var car = new Models.Car()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Plate = reader.GetString(reader.GetOrdinal("Plate")),
                                Make = reader.GetString(reader.GetOrdinal("Make")),
                                Color = reader.GetString(reader.GetOrdinal("Color")),
                                ParkingSlotsId = reader.IsDBNull(reader.GetOrdinal("ParkingSlotsId")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ParkingSlotsId"))
                            };
                        cars.Add(car);
                        }
                    }
                }connection.Close();
            }
            return cars;
        }
    }
}
