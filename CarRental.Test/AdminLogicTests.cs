// <copyright file="AdminLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;
    using CarRental.Data;
    using CarRental.Repository;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Class implements Tests.
    /// </summary>
    [TestFixture]
    public class AdminLogicTests
    {
        /// <summary>
        /// Tests.
        /// </summary>
        [Test]
        public void AdminLogicGetManufacturer()
        {
            Mock<IOwnerRepository> ownerRepo = new Mock<IOwnerRepository>();
            Mock<ICarRepository> carRepo = new Mock<ICarRepository>();
            Mock<IContractorRepository> contractorRepo = new Mock<IContractorRepository>();
            Mock<IRentalRepository> rentalRepo = new Mock<IRentalRepository>();

            Car car = new Car() { CarId = 7, Manufacturer = "Chevrolette", Model = "Corvette", Class = "Supercar", Production = new DateTime(2019, 1, 1), IsOperational = true, RentalId = null };
            carRepo.Setup(repo => repo.GetOne(It.IsAny<int>())).Returns(car);

            AdminLogic admin = new AdminLogic(ownerRepo.Object, carRepo.Object, contractorRepo.Object, rentalRepo.Object);

            var result = admin.GetManufacturer((int)car.CarId);

            Assert.That(result, Is.EqualTo(car.Manufacturer));
            carRepo.Verify(repo => repo.GetOne((int)car.CarId), Times.Once);
        }
    }
}
