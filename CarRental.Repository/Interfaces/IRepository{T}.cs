// <copyright file="IRepository{T}.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Repository
{
    using System.Linq;

    /// <summary>
    /// Parent class.
    /// </summary>
    /// <typeparam name="T">Object type.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Adds a new instance to the Database, by reaching Data layer.
        /// </summary>
        /// <param name="newInstance">New instance.</param>
        void Add(T newInstance);

        /// <summary>
        /// Delete the object of the selected Table by id, by reaching Data layer.
        /// </summary>
        /// <param name="oldInstance">The object.</param>
        void Delete(T oldInstance);

        /// <summary>
        /// Delete the object of the selected Table by id, by reaching Data layer.
        /// </summary>
        /// <param name="id">The object.</param>
        void Delete(int id);

        /// <summary>
        /// Gets the object of the selected Table by id, by reaching Data layer.
        /// </summary>
        /// <param name="id">The object's id.</param>
        /// <returns>Object by id.</returns>
        T GetOne(int id);

        /// <summary>
        /// Gets all of the object of the selected Table, by reaching Data layer.
        /// </summary>
        /// <returns><see cref="IQueryable{T}"/> from table data.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Saves the changes made on the database.
        /// </summary>
        void Save();
    }
}