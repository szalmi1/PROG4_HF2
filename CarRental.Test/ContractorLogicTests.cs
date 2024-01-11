// <copyright file="ContractorLogicTests.cs" company="PlaceholderCompany">
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
    public class ContractorLogicTests
    {
        /// <summary>
        /// Tests.
        /// </summary>
        [Test]
        public void ContractorLogicModifyRental()
        {
            Mock<IContractorRepository> contractorRepo = new Mock<IContractorRepository>();
            Mock<IRentalRepository> rentalRepo = new Mock<IRentalRepository>();

            Contractor contractorObj = new Contractor() { ContractorId = 3, FirstName = "Kálmán", LastName = "Kukori", BirthDate = new DateTime(1992, 04, 24), PhoneNumber = "063012235555", City = "Debrecen", Email = "kkalmanka@hotmail.com" };
            contractorRepo.Setup(repo => repo.GetOne(It.IsAny<int>())).Returns(contractorObj);

            ContractorLogic contractor = new ContractorLogic(contractorRepo.Object, rentalRepo.Object);

            contractor.ChangeFirstName("Klaudió", contractorObj.ContractorId);

            contractorRepo.Verify(repo => repo.GetOne(contractorObj.ContractorId), Times.Once);
        }
    }
}
