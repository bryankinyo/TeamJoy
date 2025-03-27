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
using BasicInformationLibrary;
using BasicInformationLibrary.BasicInfo;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BasicInfo_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly MyDbContext _context; 
        
        public UnitTest1()
        {
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;
            _context = new MyDbContext(options);
        }

        private void InsertToDB(UserInformation userInfo) 
        {
            _context.UserInformation.Add(userInfo);
            _context.SaveChanges();

            var retrievedUser = _context.UserInformation
                .FirstOrDefault(u => u.FirstName == userInfo.FirstName);

            Assert.IsNotNull(retrievedUser);
            Assert.AreEqual(userInfo.FirstName, retrievedUser.FirstName);
            Assert.AreEqual(userInfo.LastName, retrievedUser.LastName);
            Assert.AreEqual(userInfo.Age, retrievedUser.Age);
            Assert.AreEqual(userInfo.HouseNumber, retrievedUser.HouseNumber);
            Assert.AreEqual(userInfo.Street, retrievedUser.Street);
            Assert.AreEqual(userInfo.Barangay, retrievedUser.Barangay);
            Assert.AreEqual(userInfo.City, retrievedUser.City);
            Assert.AreEqual(userInfo.Municipality, retrievedUser.Municipality);
            Assert.AreEqual(userInfo.Country, retrievedUser.Country);

            _context.UserInformation.Remove(retrievedUser);
            _context.SaveChanges();
        }
        [TestMethod]
        public void Bryan()
        {
            // Name Testing
            Info.FirstName = "Bryan";
            Info.LastName = "Quiño";
            var NameResult = Info.FullName();
            Assert.AreEqual("Full Name: Bryan Quiño", NameResult);

            //Birthday Testing
            var ValidBirthday = Info.BirthDay("2005-05-16");
            Assert.AreEqual("2005-05-16", ValidBirthday);

            // Age Testing
            Info.YearsOld = 19;
            var AgeResult = Info.Age();
            Assert.AreEqual(AgeResult, 19);

            // Address Testing
            Info.HouseNumber = "853-B";
            Info.Street = "Bayabas St";
            Info.Barangay = "Mambaling";
            Info.City = "Cebu City";
            Info.Municipality = "Cebu";
            Info.Country = "Philippines";
            var ResidenceResult = Info.Residence();
            Assert.AreEqual("Address: 853-B Bayabas St., Mambaling, Cebu City, Cebu, Philippines", ResidenceResult);
            InsertToDB();
        }

        [TestMethod]
        public void MaryJocelyn()
        {
            // Name Testing
            Info.FirstName = "Mary Jocelyn";
            Info.LastName = "Syllanto";
            var NameResult = Info.FullName();
            Assert.AreEqual("Full Name: Mary Jocelyn Syllanto", NameResult);


            //Birthday Testing
            var ValidBirthday = Info.BirthDay("2004-02-24");
            Assert.AreEqual("2004-02-24", ValidBirthday);

            // Age Testing
            
            var AgeResult = Info.Age();
            Assert.AreEqual(AgeResult, 21);

            // Address Testing
            Info.HouseNumber = "24";
            Info.Street = "Jumalon St";
            Info.Barangay = "Basak Pardo";
            Info.City = "Cebu City";
            Info.Municipality = "Cebu";
            Info.Country = "Philippines";
            var ResidenceResult = Info.Residence();
            Assert.AreEqual("Address: 24 Jumalon St., Basak Pardo, Cebu City, Cebu, Philippines", ResidenceResult);
            InsertToDB();
        }
        [TestMethod]
        public void RimarkMoreno()
        {
            // Name Testing
            Info.FirstName = "Rimark";
            Info.LastName = "Moreno";
            var NameResult = Info.FullName();
            Assert.AreEqual("Full Name: Rimark Moreno", NameResult);


            //Birthday Testing
            var ValidBirthday = Info.BirthDay("2004-04-19");
            Assert.AreEqual("2004-04-19", ValidBirthday);

            // Age Testing

            var AgeResult = Info.Age();
            Assert.AreEqual(AgeResult, 20);

            // Address Testing
            Info.HouseNumber = "20";
            Info.Street = "Bayabas Extension St";
            Info.Barangay = "Punta Princesa";
            Info.City = "Cebu City";
            Info.Municipality = "Cebu";
            Info.Country = "Philippines";
            var ResidenceResult = Info.Residence();
            Assert.AreEqual("Address: 20 Bayabas Extension St., Punta Princesa, Cebu City, Cebu, Philippines", ResidenceResult);
            InsertToDB(UserInfo);
        }
        [TestMethod]
        public void Ivan()
        {
            // Name Testing
            Info.FirstName = "Ivan Vincent";
            Info.LastName = "Villareal";
            var NameResult = Info.FullName();
            Assert.AreEqual("Full Name: Ivan Vincent Villareal", NameResult);

            //Birthday Testing
            var ValidBirthday = Info.BirthDay("2002-01-31");
            Assert.AreEqual("2002-01-31", ValidBirthday);

            // Age Testing

            var AgeResult = Info.Age();
            Assert.AreEqual(AgeResult, 23);

            // Address Testing
            Info.HouseNumber = "11";
            Info.Street = "Tabada St";
            Info.Barangay = "Mambaling";
            Info.City = "Cebu City";
            Info.Municipality = "Cebu";
            Info.Country = "Philippines";
            var ResidenceResult = Info.Residence();
            Assert.AreEqual("Address: 11 Tabada St., Mambaling, Cebu City, Cebu, Philippines", ResidenceResult);
            InsertToDB();
        }
        [TestMethod]
        public void Kierstien()
        {
            // Name Testing
            Info.FirstName = "Kierstien";
            Info.LastName = "Verano";
            var NameResult = Info.FullName();
            Assert.AreEqual("Full Name: Kierstien Verano", NameResult);

            //Birthday Testing
            var ValidBirthday = Info.BirthDay("2006-05-15");
            Assert.AreEqual("2006-05-15", ValidBirthday);

            // Age Testing

            var AgeResult = Info.Age();
            Assert.AreEqual(AgeResult, 18);

            // Address Testing
            Info.HouseNumber = "123";
            Info.Street = "Bisag Asa";
            Info.Barangay = "Day-as";
            Info.City = "Cebu City";
            Info.Municipality = "Cebu";
            Info.Country = "Philippines";
            var ResidenceResult = Info.Residence();
            Assert.AreEqual("Address: 123 Bisag Asa., Day-as, Cebu City, Cebu, Philippines", ResidenceResult);
            InsertToDB();
        }
    }
}
