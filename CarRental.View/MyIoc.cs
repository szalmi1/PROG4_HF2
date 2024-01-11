// <copyright file="MyIoc.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.View
{
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Ioc;

    /// <summary>
    /// MyIoc class.
    /// </summary>
    public class MyIoc : SimpleIoc, IServiceLocator
    {
        /// <summary>
        /// Gets instance of MyIoc.
        /// </summary>
        public static MyIoc Instance { get; private set; } = new MyIoc();
    }
}
