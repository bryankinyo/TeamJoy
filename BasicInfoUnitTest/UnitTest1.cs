using BasicInformationLibrary;
using BasicInformationLibrary.BasicInfo;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.NetworkInformation;
using System.IO;

namespace BasicInfo_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Bryan()
        {
            // Name Testing
            Info.FirstName = "Bryan";
            Info.LastName = "Quiño";
            var NameResult = Info.FullName();
            Assert.AreEqual("Full Name: Bryan Quiño", NameResult);

            // Age Testing
            Info.YearsOld = 19;
            var AgeResult = Info.Age();
            Assert.AreEqual("Age: 19", AgeResult);

            // Address Testing
            Info.HouseNumber = 853;
            Info.Street = "Bayabas St";
            Info.Barangay = "Mambaling";
            Info.City = "Cebu City";
            Info.Country = "Philippines";
            var ResidenceResult = Info.Residence();
            Assert.AreEqual("Address: 853 Bayabas St., Mambaling, Cebu City, Philippines", ResidenceResult);
        }

        [TestMethod]
        public void MaryJocelyn()
        {
            // Name Testing
            Info.FirstName = "Mary Jocelyn";
            Info.LastName = "Syllanto";
            var NameResult = Info.FullName();
            Assert.AreEqual("Full Name: Mary Jocelyn Syllanto", NameResult);

            // Age Testing
            Info.YearsOld = 21;
            var AgeResult = Info.Age();
            Assert.AreEqual("Age: 21", AgeResult);

            // Address Testing
            Info.HouseNumber = 24;
            Info.Street = "Jumalon St";
            Info.Barangay = "Basak Pardo";
            Info.City = "Cebu City";
            Info.Country = "Philippines";
            var ResidenceResult = Info.Residence();
            Assert.AreEqual("Address: 24 Jumalon St., Basak Pardo, Cebu City, Philippines", ResidenceResult);
        }
        [TestMethod]
        public void RimarkMoreno()
        {
            // Name Testing
            Info.FirstName = "Rimark";
            Info.LastName = "Moreno";
            var NameResult = Info.FullName();
            Assert.AreEqual("Full Name: Rimark Moreno", NameResult);

            // Age Testing
            Info.YearsOld = 20;
            var AgeResult = Info.Age();
            Assert.AreEqual("Age: 20", AgeResult);

            // Address Testing
            Info.HouseNumber = 20;
            Info.Street = "Bayabas Extension St";
            Info.Barangay = "Punta Princesa";
            Info.City = "Cebu City";
            Info.Country = "Philippines";
            var ResidenceResult = Info.Residence();
            Assert.AreEqual("Address: 20 Bayabas Extension St., Punta Princesa, Cebu City, Philippines", ResidenceResult);
        }
        [TestMethod]
        public void Ivan()
        {
            // Name Testing
            Info.FirstName = "Ivan Vincent";
            Info.LastName = "Villareal";
            var NameResult = Info.FullName();
            Assert.AreEqual("Full Name: Ivan Vincent Villareal", NameResult);

            // Age Testing
            Info.YearsOld = 23;
            var AgeResult = Info.Age();
            Assert.AreEqual("Age: 23", AgeResult);

            // Address Testing
            Info.HouseNumber = 11;
            Info.Street = "Tabada St";
            Info.Barangay = "Mambaling";
            Info.City = "Cebu City";
            Info.Country = "Philippines";
            var ResidenceResult = Info.Residence();
            Assert.AreEqual("Address: 11 Tabada St., Mambaling, Cebu City, Philippines", ResidenceResult);
        }
        [TestMethod]
        public void Kierstien()
        {
            // Name Testing
            Info.FirstName = "Kierstien";
            Info.LastName = "Verano";
            var NameResult = Info.FullName();
            Assert.AreEqual("Full Name: Kierstien Verano", NameResult);

            // Age Testing
            Info.YearsOld = 19;
            var AgeResult = Info.Age();
            Assert.AreEqual("Age: 19", AgeResult);

            // Address Testing
            Info.HouseNumber = 123;
            Info.Street = "Bisag Asa";
            Info.Barangay = "Day-as";
            Info.City = "Cebu City";
            Info.Country = "Philippines";
            var ResidenceResult = Info.Residence();
            Assert.AreEqual("Address: 123 Bisag Asa., Day-as, Cebu City, Philippines", ResidenceResult);
        }
    }
}
