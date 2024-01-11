// <copyright file="Car.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.View.DATA
{
    using System;
    using System.Linq;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// Owner.
    /// </summary>
    public class Car : ObservableObject
    {
        private int id;
        private string manufacturer;
        private string model;
        private DateTime production;
        private bool isOperational;
        private string carClass;
        private int? ownerId;

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { Set(ref id, value); }
        }

        /// <summary>
        /// Gets or sets manufacturer.
        /// </summary>
        public string Manufacturer
        {
            get { return manufacturer; }
            set { Set(ref manufacturer, value); }
        }

        /// <summary>
        /// Gets or sets Model.
        /// </summary>
        public string Model
        {
            get { return model; }
            set { Set(ref model, value); }
        }

        /// <summary>
        /// Gets or sets class.
        /// </summary>
        public string Class
        {
            get { return carClass; }
            set { Set(ref carClass, value); }
        }

        /// <summary>
        /// Gets or sets production.
        /// </summary>
        public DateTime Production
        {
            get { return production; }
            set { Set(ref production, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether isOperational.
        /// </summary>
        public bool IsOperational
        {
            get { return isOperational; }
            set { Set(ref isOperational, value); }
        }

        /// <summary>
        /// Gets or sets a value of ownerId.
        /// </summary>
        public int? OwnerId
        {
            get { return ownerId; }
            set { Set(ref ownerId, value); }
        }

        /// <summary>
        /// Copies a Car into another.
        /// </summary>
        /// <param name="other">Other car.</param>
        public void CopyFrom(Car other)
        {
                this.GetType().GetProperties().ToList().ForEach(
                property => property.SetValue(this, property.GetValue(other)));
        }
    }
}
