/*
Group Name: Team Joy
Group Members: Quiño, Bryan E.
               Syllanto, Mary Jocelyn
               Verano, Kierstien
               Villareal, Ivan Vincent
               Rebese, Vincent
               Moreno, Rimark
Subject: PROGRAMMING
 */
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
            

           
            Console.Write("Birthdate (dd-mm-yyyy): ");

            Info.Birthday = Info.BirthDay(Console.ReadLine());

            // Address
            Console.Write("House Number: ");
            var housenumber = Console.ReadLine();
            Console.Write("Street: ");
            var street = Console.ReadLine();
            Console.Write("Barangay: ");
            var barangay = Console.ReadLine();
            Console.Write("City: ");
            var city = Console.ReadLine();
            Console.Write("Municipality: ");
            var municipality = Console.ReadLine();
            Console.Write("Country: ");
            var country = Console.ReadLine();

            Info.HouseNumber = housenumber;
            Info.Street = street;
            Info.Barangay = barangay;
            Info.City = city;
            Info.Municipality = municipality;
            Info.Country = country;


            Console.Clear();
            Console.WriteLine(Info.FullName());
            Console.WriteLine(Info.Age());
            Console.WriteLine(Info.Residence());
        }
    }
}