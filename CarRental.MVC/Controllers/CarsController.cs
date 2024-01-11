// <copyright file="CarsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.MVC.Controllers
{
    using System.Collections.Generic;
    using AutoMapper;
    using CarRental.MVC.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The Controller.
    /// </summary>
    public class CarsController : Controller
    {
        private Factory factory;
        private IMapper mapper;
        private CarListViewModel vm;

        /// <summary>
        /// Initializes a new instance of the <see cref="CarsController"/> class.
        /// </summary>
        /// <param name="factory">.</param>
        /// <param name="mapper">..</param>
        public CarsController(Factory factory, IMapper mapper)
        {
            this.factory = factory;
            this.mapper = mapper;

            this.vm = new CarListViewModel();
            this.vm.EditedCar = new Models.Car();

            var carDictionary = factory.Owner.CarList();
            var carList = new List<Data.Car>();
            foreach (var car in carDictionary)
            {
                Data.Car newCar = new Data.Car();
                newCar.Manufacturer = factory.Admin.GetManufacturer(car.Key);
                newCar.Model = factory.Admin.GetModel(car.Key);
                newCar.Class = factory.Admin.GetClass(car.Key);
                newCar.Production = factory.Admin.GetProduction(car.Key);
                newCar.IsOperational = factory.Admin.GetIsOperational(car.Key);
                newCar.CarId = car.Key;
                newCar.OwnerId = factory.Owner.GetOwner(car.Key).Key;
                carList.Add(newCar);
            }

            this.vm.ListOfCars = mapper.Map<IList<Data.Car>, List<Models.Car>>(carList);
        }

        /// <summary>
        /// Index site.
        /// </summary>
        /// <returns>Index.</returns>
        public IActionResult Index()
        {
            this.ViewData["editAction"] = "AddNew";
            return this.View("CarsIndex", this.vm);
        }

        /// <summary>
        /// Details site.
        /// </summary>
        /// <param name="id">Selected car.</param>
        /// <returns>Returns the selected car's details.</returns>
        public IActionResult Details(int id)
        {
            return this.View("CarsDetails", this.GetCarModel(id));
        }

        /// <summary>
        /// Remove site.
        /// </summary>
        /// <param name="id">Selected car.</param>
        /// <returns>To index.</returns>
        public IActionResult Remove(int id)
        {
            this.TempData["editResult"] = "Delete OK";
            try
            {
                this.factory.Manage.DeleteCar(id);
            }
            catch
            {
                this.TempData["editResult"] = "Delete Failed";
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// Edit the selected car's details.
        /// </summary>
        /// <param name="id">Selected car.</param>
        /// <returns>.</returns>
        public IActionResult Edit(int id)
        {
            this.ViewData["editAction"] = "Edit";
            this.vm.EditedCar = this.GetCarModel(id);
            return this.View("CarsIndex", this.vm);
        }

        /// <summary>
        /// Edit car.
        /// </summary>
        /// <param name="car">.</param>
        /// <param name="editAction">..</param>
        /// <returns>...</returns>
        [HttpPost]
        public IActionResult Edit(Models.Car car, string editAction)
        {
            if (this.ModelState.IsValid && car != null)
            {
                this.TempData["editResult"] = "Edit OK";
                if (editAction == "AddNew")
                {
                    try
                    {
                        this.factory.Owner.AddCar(car.Manufacturer, car.Model, "asdasd", car.Production, car.IsOperational, 1);
                    }
                    catch
                    {
                        this.TempData["editResult"] = "AddCar Failed";
                    }
                }
                else
                {
                    try
                    {
                        this.factory.Admin.ChangeManufacturer(car.Manufacturer, car.Id);
                        this.factory.Admin.ChangeModel(car.Model, car.Id);
                        this.factory.Admin.ChangeProduction(car.Production, car.Id);
                        this.factory.Admin.ChangeIsOperational(car.Id);
                    }
                    catch
                    {
                        this.TempData["editResult"] = "Edit Failed";
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }
            else
            {
                this.ViewData["editAction"] = "Edit";
                this.vm.EditedCar = car;
                return this.View("CarsIndex", this.vm);
            }
        }

        private Models.Car GetCarModel(int id)
        {
            Data.Car car = new Data.Car();
            car.Manufacturer = this.factory.Admin.GetManufacturer(id);
            car.Model = this.factory.Admin.GetModel(id);
            car.Class = this.factory.Admin.GetClass(id);
            car.Production = this.factory.Admin.GetProduction(id);
            car.IsOperational = this.factory.Admin.GetIsOperational(id);
            car.CarId = id;
            car.OwnerId = this.factory.Owner.GetOwner(id).Key;
            return this.mapper.Map<Data.Car, Models.Car>(car);
        }
    }
}
