namespace SkogenMedArv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> forrest = new List<Animal>();

            forrest.Add(new Animal("Uggla", true, "flyger runt bland trädden"));
            forrest.Add(new Animal("Häst", false, "den travar runt"));
            forrest.Add(new Animal("Delfin", false, "den simmar runt i sjön"));

            bool day = true;

            while (true)
            {
                string key = Console.ReadKey().Key.ToString();
                Console.Clear();

                switch (key) 
                {
                    case "D":
                        day = true;
                        Console.WriteLine("Nu är det dag!");
                        break;
                    case "N":
                        day = false;
                        Console.WriteLine("Nu är det natt!");
                        break;
                }

                foreach (Animal animal in forrest) 
                {
                    animal.Move(day);
                }
            }
        }
    }
}