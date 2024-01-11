// <copyright file="RelationLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CarRental.Data;
    using CarRental.Repository;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Class implements Tests.
    /// </summary>
    [TestFixture]
    public class RelationLogicTests
    {
        private Mock<IOwnerRepository> ownerRepo;
        private Mock<ICarRepository> carRepo;
        private Mock<IContractorRepository> contractorRepo;
        private Mock<IRentalRepository> rentalRepo;
        private List<Owner> owners;
        private List<Car> cars;
        private List<Contractor> contractors;
        private List<Rental> rentals;

        /// <summary>
        /// Tests.
        /// </summary>
        [Test]
        public void RelationLogicNeedToReturn()
        {
            RelationLogic relation = this.CreateRelationLogicWithData();

            var testResults = relation.NeedToReturn(1);

            var data1 = $"{"Chevrolette Corvette".PadRight(45)}" +
                        $"{"Class: Supercar".PadRight(50) + "\n"}" +
                        $"{"    Production: 2019",-49}" +
                        $"{"Operational: Working".PadRight(50)}\n";

            Dictionary<int, string> expectedResults = new Dictionary<int, string>();

            expectedResults.Add(6, data1);

            Assert.That(testResults, Is.EquivalentTo(expectedResults));

            this.carRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.contractorRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.rentalRepo.Verify(repo => repo.GetAll(), Times.Once);
        }

        /// <summary>
        /// Tests WhereAreMyCars() method.
        /// </summary>
        [Test]
        public void RelationLogicWhereAreMyCars()
        {
            RelationLogic relation = this.CreateRelationLogicWithData();

            var testResults = relation.WhereAreMyCars(2);

            int daysRemaining = (int)(new DateTime(2020, 7, 20) - DateTime.Now).TotalDays;

            var data = $"{"Lamborghini Huracan".PadRight(45)}" +
                       $"{"Rented by: Dean Cortez".PadRight(50) + "\n"}" +
                       $"{("    Location: " + "Budapest").PadRight(49)}" +
                       $"{("Remaining: " + daysRemaining).PadRight(50)}\n";

            Dictionary<int, string> expectedResults = new Dictionary<int, string>();
            expectedResults.Add(5, data);

            Assert.That(testResults, Is.EquivalentTo(expectedResults));

            this.carRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.rentalRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.contractorRepo.Verify(repo => repo.GetAll(), Times.Once);
        }

        /// <summary>
        /// Tests.
        /// </summary>
        [Test]
        public void RelationLogicNearbyRentables()
        {
            RelationLogic relation = this.CreateRelationLogicWithData();

            var testResults = relation.NearbyRentables(1);
            var data1 = $"{"Lamborghini Urus".PadRight(45)}" +
                        $"{("Production:" + "2018.").PadRight(50) + "\n"}" +
                        $"{("    Location: " + "Budapest").PadRight(49)}" +
                        $"{"For rent: YES ".PadRight(50)}\n";

            var data2 = $"{"McLaren P1".PadRight(45)}" +
                        $"{("Production:" + "2018.").PadRight(50) + "\n"}" +
                        $"{("    Location: " + "Budapest").PadRight(49)}" +
                        $"{"For rent: YES ".PadRight(50)}\n";

            var data3 = $"{"Chevrolette Corvette".PadRight(45)}" +
                        $"{("Production:" + "2019.").PadRight(50) + "\n"}" +
                        $"{("    Location: " + "Budapest").PadRight(49)}" +
                        $"{"For rent: YES ".PadRight(50)}\n";

            Dictionary<int, string> expectedResults = new Dictionary<int, string>();

            expectedResults.Add(3, data1);
            expectedResults.Add(4, data2);
            expectedResults.Add(7, data3);

            Assert.That(testResults, Is.EquivalentTo(expectedResults));

            this.carRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.ownerRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.contractorRepo.Verify(repo => repo.GetAll(), Times.Once);
        }

        private RelationLogic CreateRelationLogicWithData()
        {
            this.ownerRepo = new Mock<IOwnerRepository>();
            this.carRepo = new Mock<ICarRepository>();
            this.contractorRepo = new Mock<IContractorRepository>();
            this.rentalRepo = new Mock<IRentalRepository>();

            Owner o0 = new Owner() { OwnerId = 1, FirstName = "Adil", LastName = "F. Sahar", BirthDate = new DateTime(1990, 01, 10), PhoneNumber = "06201124124", RentalCompany = "HungarianRentals kft.", Location = "Budapest" };
            Owner o1 = new Owner() { OwnerId = 2, FirstName = "Lakatos", LastName = "Ákánegyvenhét", BirthDate = new DateTime(1992, 04, 12), PhoneNumber = "06201494124", RentalCompany = "HungarianRentals kft.", Location = "Budapest" };
            Owner o2 = new Owner() { OwnerId = 3, FirstName = "James", LastName = "Morgan", BirthDate = new DateTime(1990, 01, 10), PhoneNumber = "06201774124", RentalCompany = "RentalPro kft.", Location = "Budapest" };
            Owner o3 = new Owner() { OwnerId = 4, FirstName = "Sakur", LastName = "D. Cortez", BirthDate = new DateTime(1990, 01, 10), PhoneNumber = "06201123124", RentalCompany = "RentalPro kft.", Location = "Budapest" };

            Car c6 = new Car() { CarId = 7, Manufacturer = "Chevrolette", Model = "Corvette", Class = "Supercar", Production = new DateTime(2019, 1, 1), IsOperational = true, RentalId = null };
            Car c5 = new Car() { CarId = 6, Manufacturer = "Audi", Model = "R8", Class = "Sportcar", Production = new DateTime(2020, 1, 1), IsOperational = true, RentalId = null };
            Car c3 = new Car() { CarId = 4, Manufacturer = "McLaren", Model = "P1", Class = "Hypercar", Production = new DateTime(2018, 1, 1), IsOperational = false, RentalId = null };
            Car c4 = new Car() { CarId = 5, Manufacturer = "Lamborghini", Model = "Huracan", Class = "Hypercar", Production = new DateTime(2019, 1, 1), IsOperational = true, RentalId = null };
            Car c0 = new Car() { CarId = 1, Manufacturer = "Ferrari", Model = "F40", Class = "Supercar", Production = new DateTime(1990, 1, 1), IsOperational = true, RentalId = null };
            Car c1 = new Car() { CarId = 2, Manufacturer = "Lamborghini", Model = "Aventador", Class = "Hypercar", Production = new DateTime(2015, 1, 1), IsOperational = true, RentalId = null };
            Car c2 = new Car() { CarId = 3, Manufacturer = "Lamborghini", Model = "Urus", Class = "SUV", Production = new DateTime(2018, 1, 1), IsOperational = false, RentalId = null };
            Car c7 = new Car() { CarId = 8, Manufacturer = "Chevrolette", Model = "Corvette", Class = "Supercar", Production = new DateTime(2019, 1, 1), IsOperational = true, RentalId = 5 };

            Contractor co0 = new Contractor() { ContractorId = 1, FirstName = "Dean", LastName = "Cortez", BirthDate = new DateTime(1990, 01, 10), PhoneNumber = "067012415555", City = "Budapest", Email = "deancortez@boss.com" };
            Contractor co1 = new Contractor() { ContractorId = 2, FirstName = "Huanita", LastName = "Perez", BirthDate = new DateTime(1982, 11, 20), PhoneNumber = "062012415205", City = "Miskolc", Email = "huanitap@gmail.com" };
            Contractor co2 = new Contractor() { ContractorId = 3, FirstName = "Kálmán", LastName = "Kukori", BirthDate = new DateTime(1992, 04, 24), PhoneNumber = "063012235555", City = "Debrecen", Email = "kkalmanka@hotmail.com" };

            Rental r0 = new Rental() { RentalId = 1, Start = new DateTime(2020, 08, 8), End = new DateTime(2020, 10, 10), Paid = false };
            Rental r1 = new Rental() { RentalId = 2, Start = new DateTime(2020, 09, 11), End = new DateTime(2020, 10, 21), Paid = false };
            Rental r2 = new Rental() { RentalId = 3, Start = new DateTime(2020, 06, 20), End = new DateTime(2020, 7, 20), Paid = true };
            Rental r3 = new Rental() { RentalId = 4, Start = new DateTime(2020, 04, 30), End = new DateTime(2020, 06, 11), Paid = true };
            Rental r4 = new Rental() { RentalId = 5, Start = new DateTime(2020, 10, 21), End = new DateTime(2020, 12, 31), Paid = false };
            Rental r5 = new Rental() { RentalId = 6, Start = new DateTime(2020, 01, 21), End = new DateTime(2030, 12, 31), Paid = false, CarReturned = false };

            c0.OwnerId = c1.OwnerId = c2.OwnerId = o0.OwnerId;
            c3.OwnerId = c4.OwnerId = o1.OwnerId;
            c5.OwnerId = o2.OwnerId;
            c6.OwnerId = o3.OwnerId;

            r5.ContractorId = co0.ContractorId;
            r5.CarId = c7.CarId;

            c0.RentalId = r0.RentalId;
            c1.RentalId = r1.RentalId;
            c4.RentalId = r2.RentalId;
            c5.RentalId = r3.RentalId;

            r0.ContractorId = co1.ContractorId;
            r1.ContractorId = co2.ContractorId;
            r2.ContractorId = co0.ContractorId;
            r3.ContractorId = co2.ContractorId;

            this.owners = new List<Owner>()
            {
                o0, o1, o2, o3,
            };

            this.cars = new List<Car>()
            {
                c0, c1, c2, c3, c4, c5, c6, c7,
            };
            this.contractors = new List<Contractor>()
            {
                co0, co1, co2,
            };
            this.rentals = new List<Rental>()
            {
                r0, r1, r2, r3, r5,
            };

            this.ownerRepo.Setup(repo => repo.GetAll()).Returns(this.owners.AsQueryable());
            this.carRepo.Setup(repo => repo.GetAll()).Returns(this.cars.AsQueryable());
            this.contractorRepo.Setup(repo => repo.GetAll()).Returns(this.contractors.AsQueryable());
            this.rentalRepo.Setup(repo => repo.GetAll()).Returns(this.rentals.AsQueryable());

            return new RelationLogic(this.ownerRepo.Object, this.carRepo.Object, this.contractorRepo.Object, this.rentalRepo.Object);
        }
    }
}
