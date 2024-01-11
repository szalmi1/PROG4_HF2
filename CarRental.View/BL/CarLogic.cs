// <copyright file="CarLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.View.BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CarRental.View.DATA;
    using GalaSoft.MvvmLight.Messaging;

    /// <inheritdoc/>
    public class CarLogic : ICarLogic
    {
        private IEditorService editorService;
        private IMessenger messengerService;
        private Factory factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CarLogic"/> class.
        /// </summary>
        /// <param name="editorService">IEditorService.</param>
        /// <param name="messengerService">IMessenger.</param>
        /// <param name="factory">Factory.</param>
        public CarLogic(IEditorService editorService, IMessenger messengerService, Factory factory)
        {
            this.editorService = editorService;
            this.messengerService = messengerService;
            this.factory = factory;
        }

        /// <summary>
        /// Checks the cars parameters.
        /// </summary>
        /// <param name="car">Car.</param>
        /// <returns>true or false, if the parameters was correct.</returns>
        public static bool CarIsOk(Car car)
        {
            bool isOk = true;
            if (car != null)
            {
                if (car.Manufacturer == null)
                {
                    isOk = false;
                }
                else if (car.Manufacturer.Length < 2)
                {
                    isOk = false;
                }

                if (car.Model == null)
                {
                    isOk = false;
                }
                else if (car.Model.Length < 2)
                {
                    isOk = false;
                }

                if (car.Class == null)
                {
                    isOk = false;
                }
                else if (car.Class.Length < 2)
                {
                    isOk = false;
                }
            }
            else
            {
                isOk = false;
            }

            return isOk;
        }

        /// <summary>
        /// Add car operation.
        /// </summary>
        /// <param name="list">Car list.</param>
        public void AddCar(IList<Car> list)
        {
            Car newCar_WPF = new Car();
            int maxId = this.factory.Owner.CarList().Last().Key;
            if (this.editorService.EditCar(newCar_WPF) == true)
            {
                if (list != null && CarIsOk(newCar_WPF))
                {
                    list.Add(newCar_WPF);
                    this.factory.Owner.AddCar(newCar_WPF.Manufacturer, newCar_WPF.Model, newCar_WPF.Class, newCar_WPF.Production, newCar_WPF.IsOperational, newCar_WPF.OwnerId);
                    messengerService.Send("Car successfully added", "LogicResult");
                }
                else
                {
                    messengerService.Send("Add failed", "LogicResult");
                }
            }
            else
            {
                messengerService.Send("Add cancelled", "LogicResult");
            }
        }

        /// <summary>
        /// Modify car operation.
        /// </summary>
        /// <param name="car">Car to modify.</param>
        public void ModCar(Car car)
        {
            if (car == null)
            {
                messengerService.Send("Edit failed", "LogicResult");
            }
            else
            {
                Car clone = new Car();
                clone.CopyFrom(car);
                int id = car.Id;
                if (editorService.EditCar(clone) == true)
                {
                    if (CarIsOk(clone) && id < this.factory.Owner.CarList().Keys.Last() + 1)
                    {
                        car.CopyFrom(clone);
                        this.factory.Admin.ChangeManufacturer(car.Manufacturer, id);
                        this.factory.Admin.ChangeModel(car.Model, id);
                        this.factory.Admin.ChangeProduction(car.Production, id);
                        this.factory.Admin.ChangeClass(car.Class, id);
                        if (clone.IsOperational != car.IsOperational)
                        {
                            this.factory.Admin.ChangeIsOperational(id);
                        }

                        messengerService.Send("Car successfully edited", "LogicResult");
                    }
                    else
                    {
                        messengerService.Send("Edit cancelled", "LogicResult");
                    }
                }
                else
                {
                    messengerService.Send("Edit failed", "LogicResult");
                }
            }
        }

        /// <summary>
        /// Delete car operation.
        /// </summary>
        /// <param name="list">Car list.</param>
        /// <param name="car">List to modify.</param>
        public void DelCar(IList<Car> list, Car car)
        {
            if (car != null && list != null && list.Remove(car))
            {
                this.factory.Manage.DeleteCar(car.Id);
                messengerService.Send("Car successfully deleted", "LogicResult");
            }
            else
            {
                messengerService.Send("Delete failed", "LogicResult");
            }
        }

        /// <summary>
        /// Gets all cars.
        /// </summary>
        /// <returns>All cars.</returns>
        public IList<Car> GetAllCars()
        {
            throw new NotImplementedException();
        }
    }
}
