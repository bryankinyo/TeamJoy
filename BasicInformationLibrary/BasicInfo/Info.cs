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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInformationLibrary.BasicInfo
{
    public static class Info
    {
        public static string? FirstName { get; set; }
        public static string? LastName { get; set; }
        public static string? Birthday { get; set; }
        public static decimal YearsOld { get; set; }
        public static string? HouseNumber { get; set; }
        public static string? Street { get; set; }
        public static string? Barangay { get; set; }
        public static string? Municipality { get; set; }
        public static string? City { get; set; }
        public static string? Country { get; set; }


        public static string FullName()
        {
            return $"Full Name: {FirstName} {LastName}";
        }

        public static string BirthDay(string inputDate = null)
        {
            DateTime birthday;
            DateTime today = DateTime.Today;

            while (true)
            {
                string dateToValidate = inputDate ?? Console.ReadLine();

                if (DateTime.TryParse(dateToValidate, out birthday))
                {
                    if (birthday > today)
                    {
                        Console.WriteLine("Invalid input: Birthday cannot be a future date.");
                    }
                    else
                    {
                        Birthday = birthday.ToString("yyyy-MM-dd");
                        return Birthday;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please enter a valid date (YYYY-MM-DD).");
                }

                inputDate = null;
            }
        }

       

        public static int Age()
        {
            DateTime today = DateTime.Today;
            DateTime birthdate = DateTime.Parse(Birthday);

            int age = today.Year - birthdate.Year;

            if (birthdate > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        public static string Residence()
        {
            return $"Address: {HouseNumber} {Street}., {Barangay}, {City}, {Municipality}, {Country}";
        }
    }
}

