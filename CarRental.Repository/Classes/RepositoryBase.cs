// <copyright file="RepositoryBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CarRental.Repository
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Repository generic class.
    /// </summary>
    /// <typeparam name="T">Gets a child class as parameter.</typeparam>
    public abstract class RepositoryBase<T> : IRepository<T>
            where T : class
    {
        /// <summary>
        /// DBContext instance.
        /// </summary>
        private DbContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{T}"/> class.
        /// </summary>
        /// <param name="ctx">DBContext.</param>
        protected RepositoryBase(DbContext ctx)
        {
            this.ctx = ctx;
        }

        /// <summary>
        /// Adds a new instance to the Database, by reaching Data layer.
        /// </summary>
        /// <param name="newInstance">New instance.</param>
        public void Add(T newInstance)
        {
            this.ctx.Add(newInstance);
            this.Save();
        }

        /// <summary>
        /// Gets all of the object of the selected Table, by reaching Data layer.
        /// </summary>
        /// <returns><see cref="IQueryable{T}"/> from table data.</returns>
        public IQueryable<T> GetAll()
        {
            return this.ctx.Set<T>();
        }

        /// <summary>
        /// Gets the object of the selected Table by id, by reaching Data layer.
        /// </summary>
        /// <param name="id">The object's id.</param>
        /// <returns>Object by id.</returns>
        public abstract T GetOne(int id);

        // public abstract void Set(int id, T instance);

        /// <summary>
        /// Delete the object of the selected Table by id, by reaching Data layer.
        /// </summary>
        /// <param name="oldInstance">The object.</param>
        public void Delete(T oldInstance)
        {
            this.ctx.Remove(oldInstance);
            this.Save();
        }

        /// <summary>
        /// Delete the object of the selected Table by id, by reaching Data layer.
        /// </summary>
        /// <param name="id">The object.</param>
        public void Delete(int id)
        {
            this.ctx.Remove(this.GetOne(id));
            this.Save();
        }

        /// <summary>
        /// Saves the changes made on the database.
        /// </summary>
        public void Save()
        {
            this.ctx.SaveChanges();
        }
    }
}