// <copyright file="OwnerLogicTests.cs" company="PlaceholderCompany">
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
    public class OwnerLogicTests
    {
        /// <summary>
        /// Tests.
        /// </summary>
        [Test]
        public void OwnerLogicCarListTest()
        {
            Mock<IOwnerRepository> ownerRepo = new Mock<IOwnerRepository>();
            Mock<ICarRepository> carRepo = new Mock<ICarRepository>();

            List<Car> cars = new List<Car>()
            {
                new Car() { CarId = 4, Manufacturer = "Lamborghini", Model = "Huracan", Class = "Hypercar", Production = new DateTime(2019, 1, 1), IsOperational = true, RentalId = null },
                new Car() { CarId = 1, Manufacturer = "Ferrari", Model = "F40", Class = "Supercar", Production = new DateTime(1990, 1, 1), IsOperational = true, RentalId = null },
                new Car() { CarId = 2, Manufacturer = "Lamborghini", Model = "Aventador", Class = "Hypercar", Production = new DateTime(2015, 1, 1), IsOperational = true, RentalId = null },
                new Car() { CarId = 3, Manufacturer = "Lamborghini", Model = "Urus", Class = "SUV", Production = new DateTime(2018, 1, 1), IsOperational = false, RentalId = null },
            };

            carRepo.Setup(repo => repo.GetAll()).Returns(cars.AsQueryable());

            Owner o1 = new Owner() { OwnerId = 2, FirstName = "Lakatos", LastName = "Ákánegyvenhét", BirthDate = new DateTime(1992, 04, 12), PhoneNumber = "06201494124", RentalCompany = "HungarianRentals kft.", Location = "Budapest" };

            OwnerLogic owner = new OwnerLogic(ownerRepo.Object, carRepo.Object);

            var result = owner.CarList();
            carRepo.Verify(repo => repo.GetAll(), Times.Once);
        }
    }
}
