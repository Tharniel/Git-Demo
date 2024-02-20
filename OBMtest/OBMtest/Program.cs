namespace OBMtest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Databas via ADO");

            List<Models.Car> cars = DatabasADO.GetAllCars();

            foreach(Models.Car car in cars)
            {
                Console.WriteLine($"{car.Id}\t{car.Plate}\t{car.Make}\t{car.Color}\t{car.ParkingSlotsId}");
            }
        }
    }
}