using Dapper;
using ParkeringHus.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ParkeringHus
{
    internal class DatabasDapper
    {
        static string connString = "data source=.\\SQLEXPRESS; initial catalog = Parking10; persist security info = True; Integrated Security = True;";

        public static List<Car> GetAllCars()
        {
            string sql = "SELECT * FROM Cars";
            List<Car> cars = new List<Car>();

            using (var connection = new SqlConnection(connString))
            {
                cars = connection.Query<Car>(sql).ToList();
            }
            return cars;
        }
        public static List<Cities> GetAllCities()
        {
            string sql = "SELECT * FROM Cities";
            List<Cities> City = new List<Cities>();

            using (var connection = new SqlConnection(connString))
            {
                City = connection.Query<Cities>(sql).ToList();
            }
            return City;
        }
        public static List<ParkingHouses> GetAllParkingHouses()
        {
            String sql = "SELECT * FROM ParkingHouses";
            List<ParkingHouses> parkingHouse = new List<ParkingHouses>();

            using (var connection = new SqlConnection(connString))
            {
                parkingHouse = connection.Query<ParkingHouses>(sql).ToList();
            }
            return parkingHouse;
        }
        public static int InsertCity()
        {
            Console.WriteLine("Tryck C för att skapa en ny stad");
            Console.WriteLine("Tryck B för att gå tillbaka");
            var key = Console.ReadKey();
            Console.Clear();
            switch (key.KeyChar)
            {
                case 'c':
                    Console.WriteLine("Namnge staden");
                    string cities = Console.ReadLine();

                    int affectedRows = 0;
                    string sql = $"INSERT INTO Cities(CityName) VALUES ('{cities}')";
                    using (var connection = new SqlConnection(connString))
                    {
                        affectedRows = connection.Execute(sql);
                    }
                    Console.WriteLine("Antal städer som har skapats som skapats: " + affectedRows);

                    break;
                case 'b':
                    break;
            }
            return 0;
        }

            public static int InsertCar()
        {
            Console.WriteLine("Tryck C för att skapa en bil");
            Console.WriteLine("Tryck B för att gå tillbaka");
            var key = Console.ReadKey();
            Console.Clear();
            switch (key.KeyChar)
            {
                case 'c':
                    Random rnd = new Random();
                    Models.Car car = new Models.Car
                    {
                        Plate = "XPQ" + rnd.Next(100, 999),
                        Make = "Tesla",
                        Color = "Röd"
                    };
                    int affectedRows = 0;
                    string sql = $"INSERT INTO Cars(Plate, Make, Color) VALUES ('{car.Plate}', '{car.Make}', '{car.Color}')";
                    using (var connection = new SqlConnection(connString))
                    {
                        affectedRows = connection.Execute(sql);
                    }
                    Console.WriteLine("Antal bilar som skapats: " + affectedRows);

                    break;
                case 'b':
                    break;
            }
            return 0;
        }
        public static int InsertParkingHouse()
        {
            Console.WriteLine("Tryck C för att skapa ett nytt parkeringhus");
            Console.WriteLine("Tryck P för att lägga till parkerings plats");
            Console.WriteLine("Tryck B för att gå tillbaka");
            var key = Console.ReadKey();
            Console.Clear();
            switch (key.KeyChar)
            {
                case 'c':
                    Console.WriteLine("Namnge Parkeringshuset");
                    string ParkingHouse = Console.ReadLine();
                    GetAllCities();
                    Console.WriteLine("Välj en stad:");
                    string Cities = Console.ReadLine();
                    Console.WriteLine("Välj antal platser");
                    int Slots = int.Parse(Console.ReadLine());

                    int affectedRows1 = 0;
                    int affectedRows2 = 0;
                    string sql1 = $"INSERT INTO ParkingHouses(HouseName, CityId) VALUES ('{ParkingHouse}', '{Cities}')";
                    
                    string sql2 = $"DECLARE @MaxParkingHouse INT; SELECT @MaxParkingHouse = MAX(Id) FROM ParkingHouses; DECLARE @MaxSlotNumber INT; SELECT @MaxSlotNumber = MAX(Slotnumber) FROM ParkingSlots WHERE ParkingHouseId = @MaxParkingHouse + 1; INSERT INTO ParkingSlots(SlotNumber, ElectricOutlet, ParkingHouseId) VALUES (@MaxSlotNumber + 1,'1',@MaxParkingHouse)";
                    using (var connection = new SqlConnection(connString))
                    {
                        affectedRows1 = connection.Execute(sql1);
                        for (int i = 0; Slots >= i; i++)
                            {
                            affectedRows2 = connection.Execute(sql2);
                            };
                    }

                        Console.WriteLine("Antal parkeringHouse som har skapats som skapats: " + affectedRows1);
                        Console.WriteLine("Antal parkering plaster som har skapats som skapats: " + affectedRows2);
                        break;

                case 'p':
                    GetAllParkingHouses();
                    Console.WriteLine("välj ett parkeringshus");
                    string ParkingHouses = Console.ReadLine();


                    int affectedRows3 = 0;
                    string sql4 = $"Declare @MaxSlotNumber INT; SELECT @MaxSlotNumber = MAX(Slotnumber) FROM ParkingSlots WHERE ParkingHouseId = '{ParkingHouses}'";
                    string sql5 = $"INSERT INTO ParkingSlots(SlotNumber, ElectricOutlet, ParkingHouseId) VALUES (@MaxSlotNumber + 1,'1','{ParkingHouses}')";
                    using (var connection = new SqlConnection(connString))
                    {
                        connection.Execute(sql4);
                        affectedRows3 = connection.Execute(sql5);
                    }
                    Console.WriteLine("Antal parkering plaster som har skapats som skapats: " + affectedRows3 + " i parkering huset: " + ParkingHouses);
                    break;
                 case 'b':
                    break;
            }
            return 0;
        }
    }
}
