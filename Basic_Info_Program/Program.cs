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
using MySql.Data.MySqlClient;
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

            string connectionString = "server=127.0.0.1;database=InfoDB;user=root;password=bryankinnot;";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine("Database connection successful!");

                    string query = "INSERT INTO UserInformation (FirstName, LastName, BirthDate, Age, HouseNumber, Street, Barangay, City, Municipality, Country) " +
                                   "VALUES (@FirstName, @LastName, @BirthDate, @Age, @HouseNumber, @Street, @Barangay, @City, @Municipality, @Country)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", Info.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", Info.LastName);
                        cmd.Parameters.AddWithValue("@BirthDate", birthDate);
                        cmd.Parameters.AddWithValue("@Age", Info.YearsOld);
                        cmd.Parameters.AddWithValue("@HouseNumber", Info.HouseNumber);
                        cmd.Parameters.AddWithValue("@Street", Info.Street);
                        cmd.Parameters.AddWithValue("@Barangay", Info.Barangay);
                        cmd.Parameters.AddWithValue("@City", Info.City);
                        cmd.Parameters.AddWithValue("@Municipality", Info.Municipality);
                        cmd.Parameters.AddWithValue("@Country", Info.Country);

                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Data successfully inserted!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
            }
        }
    }
}