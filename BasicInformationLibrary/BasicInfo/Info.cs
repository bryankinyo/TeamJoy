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
        public static decimal YearsOld { get; set; }
        public static decimal HouseNumber { get; set; }
        public static string? Street { get; set; }
        public static string? Barangay { get; set; }
        public static string? City { get; set; }
        public static string? Country { get; set; }


        public static string FullName()
        {
            return $"Full Name: {FirstName} {LastName}";
        }
        public static string Age()
        {
            return $"Age: {YearsOld}";
        }

        public static string Residence()
        {
            return $"Address: {HouseNumber} {Street}., {Barangay}, {City}, {Country}";
        }
    }
}

