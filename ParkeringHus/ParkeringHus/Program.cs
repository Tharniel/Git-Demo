using ParkeringHus.Models;
using System.Runtime.InteropServices;

namespace ParkeringHus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true){
            Console.WriteLine();
            Console.WriteLine("Tryck S för städer");
            Console.WriteLine("Tryck P för parkeringshus");
            Console.WriteLine("Tryck B för bilar");
            Console.WriteLine("Tryck L för lediga platser");
            Console.WriteLine("Tryck O för parkerade bilar");

            var key = Console.ReadKey();
                Console.Clear();
                switch (key.KeyChar)
                {
                    case 's':
                        List<Cities> city = DatabasDapper.GetAllCities();
                        foreach (Cities cities in city)
                        {
                            Console.WriteLine(cities.Id + "\t" + cities.CityName);
                        }
                        DatabasDapper.InsertCity();
                        break;
                    case 'p':
                        List<ParkingHouses> parkingHouse = DatabasDapper.GetAllParkingHouses();
                        foreach(ParkingHouses parkingHouses in parkingHouse)
                        {
                            Console.WriteLine(parkingHouses.Id + "\t" + parkingHouses.HouseName + "\t" + parkingHouses.CityId);
                        }
                        DatabasDapper.InsertParkingHouse();
                        break;
                    case 'b':
                        List<Car> cars = DatabasDapper.GetAllCars();
                        foreach (Car car in cars)
                        {
                            Console.WriteLine(car.Id + "\t" + car.Plate + "\t" + car.Make + "\t" + car.Color + "\t" + car.ParkingSlotsId);
                        }
                        DatabasDapper.InsertCar();
                        break;
                    case 'l':
                        break;
                    case 'o':
                        break;

                }
            }
        }
    }
}