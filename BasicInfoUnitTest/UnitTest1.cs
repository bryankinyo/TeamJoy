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
        public void TestFullName()
        {
            Info.FirstName = "John";
            Info.LastName = "Doe";

            // Act
            var result = Info.FullName();

            // Assert
            Assert.AreEqual("Full Name: John Doe", result);
        }

        [TestMethod]
        public void TestAge()
        {
            Info.YearsOld = 25;

            // Act
            var result = Info.Age();

            // Assert
            Assert.AreEqual("Age: 25", result);
        }
        [TestMethod]
        public void TestResidence()
        {
            Info.HouseNumber = 23;
            Info.Street = "Bayabas St";
            Info.Barangay = "Mambaling";
            Info.City = "Cebu";
            Info.Country = "Ph";

            var result = Info.Residence();

            Assert.AreEqual("Address: 23 Bayabas St., Mambaling, Cebu, Ph", result);
        }
    }
}
