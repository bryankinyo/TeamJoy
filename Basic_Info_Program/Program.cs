using System.Runtime.ExceptionServices;
using BasicInformationLibrary;
using BasicInformationLibrary.BasicInfo;

namespace Basic_Info_Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Full Name
            Console.Write("First Name: ");
            var firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            var lastName = Console.ReadLine();

            Info.FirstName = firstName;
            Info.LastName = lastName;


            // Age
            DateTime birthDate;

            while (true)
            {
                Console.Write("Birthdate (dd-mm-yyyy): ");

                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
            }

            int age = DateTime.Now.Year - birthDate.Year;

            if (DateTime.Now < birthDate.AddYears(age))
            {
                age--;
            }

            Info.YearsOld = age;

            // Address
            Console.Write("House Number: ");
            decimal.TryParse(Console.ReadLine(), out var housenumber);
            Console.Write("Street: ");
            var street = Console.ReadLine();
            Console.Write("Barangay: ");
            var barangay = Console.ReadLine();
            Console.Write("City: ");
            var city = Console.ReadLine();
            Console.Write("Country: ");
            var country = Console.ReadLine();

            Info.HouseNumber = housenumber;
            Info.Street = street;
            Info.Barangay = barangay;
            Info.City = city;
            Info.Country = country;
            

            Console.Clear();
            Console.WriteLine(Info.FullName());
            Console.WriteLine(Info.Age());
            Console.WriteLine(Info.Residence());
        }
    }
}
