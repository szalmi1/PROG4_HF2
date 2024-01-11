// <copyright file="ManageLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;
    using System.Collections.Generic;
    using CarRental.Data;
    using CarRental.Repository;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Class implements Tests.
    /// </summary>
    [TestFixture]
    public class ManageLogicTests
    {
        /// <summary>
        /// Tests.
        /// </summary>
        [Test]
        public void ManageLogicAddRental()
        {
            Mock<IOwnerRepository> ownerRepo = new Mock<IOwnerRepository>();
            Mock<ICarRepository> carRepo = new Mock<ICarRepository>();
            Mock<IContractorRepository> contractorRepo = new Mock<IContractorRepository>();
            Mock<IRentalRepository> rentalRepo = new Mock<IRentalRepository>();

            List<string> input = new List<string>()
            {
                "KBéla",
                "Kiss",
                "1990.01.01",
                "06201234567",
                "ASD",
                "Budapest",
            };

            string vnev = FormatLogic.FormatString(input[0], 20);
            string knev = FormatLogic.FormatString(input[1], 20);
            DateTime birth = FormatLogic.FormatDate(input[2]);
            string tel = FormatLogic.FormatPhoneNumber(input[3]);
            string comp = FormatLogic.FormatString(input[4], 50);
            string loc = FormatLogic.FormatString(input[0], 20);

            ownerRepo.Setup(repo => repo.Add(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            ownerRepo.Setup(repo => repo.Add(It.IsAny<Owner>()));

            ManageLogic manage = new ManageLogic(ownerRepo.Object, carRepo.Object, contractorRepo.Object, rentalRepo.Object);

            manage.AddOwner(input);

            ownerRepo.Verify(repo => repo.Add(vnev, knev, birth, tel, comp, loc), Times.Once);
        }

        /// <summary>
        /// Tests.
        /// </summary>
        [Test]
        public void ManageLogicDeleteCar()
        {
            Mock<IOwnerRepository> ownerRepo = new Mock<IOwnerRepository>();
            Mock<ICarRepository> carRepo = new Mock<ICarRepository>();
            Mock<IContractorRepository> contractorRepo = new Mock<IContractorRepository>();
            Mock<IRentalRepository> rentalRepo = new Mock<IRentalRepository>();

            Car car = new Car() { CarId = 1, Manufacturer = "Chevrolette", Model = "Corvette", Class = "Supercar", Production = new DateTime(2019, 1, 1), IsOperational = true, RentalId = null };

            carRepo.Setup(repo => repo.GetOne(It.IsAny<int>())).Returns(car);
            carRepo.Setup(repo => repo.Delete(car));

            ManageLogic manage = new ManageLogic(ownerRepo.Object, carRepo.Object, contractorRepo.Object, rentalRepo.Object);

            manage.DeleteCar(car.CarId);

            carRepo.Verify(repo => repo.Delete(car.CarId), Times.Once);
        }
    }
}
