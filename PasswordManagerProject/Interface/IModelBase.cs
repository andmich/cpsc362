using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PasswordManagerProject.Interface
{
    /// <summary>
    /// model base.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IModelBase<T>
    {
        /* Standard GetAll, GetSingleOrDefault Method(s) (Lambda based) */

        /// <summary>
        /// get all class objects.
        /// </summary>
        /// <returns>
        /// </returns>
        IQueryable<T> GetAllClassObjects();

        /// <summary>
        /// get single class object by class ref.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// </returns>
        T GetSingleClassObjectByClassRef(Guid guid);

        /* Standard LINQ Querying Operations */

        /// <summary>
        /// add.
        /// </summary>
        /// <param name="__class">
        /// The __class.
        /// </param>
        void Add(T __class);

        /// <summary>
        /// delete.
        /// </summary>
        /// <param name="__class">
        /// The __class.
        /// </param>
        void Delete(T __class);

        /// <summary>
        /// update.
        /// </summary>
        void Update();

    }
}
