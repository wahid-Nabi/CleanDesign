namespace CleanDesign.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Create an entity of type T
        /// </summary>
        /// <param name="entity">Entity object to be created in database</param>
        /// <returns>returns the newly created object if successfull otherwise error</returns>
        Task CreateAsync(T entity);

        /// <summary>
        /// Update an existing T object
        /// </summary>
        /// <param name="entity">Object to be updated</param>
        /// <returns>returns the updated object if successfull otherwise error</returns>
        void  Update(T entity);

        /// <summary>
        /// Delete a particular entity of type T
        /// </summary>
        /// <param name="entity">Entity to be deleted</param>
        /// <returns>returns the id of a user</returns>
        void Delete(T entity);

        /// <summary>
        /// Get a particular object of type T
        /// </summary>
        /// <param name="id">Id of the object that needs to be found from database</param>
        /// <returns>returns the object if found otherwise notFound error</returns>
        Task<T> GetAsync(Guid id);

        /// <summary>
        /// Get all items from table T
        /// </summary>
        /// <returns>all items from entity T if exists otherwise notfound error</returns>
        Task<IEnumerable<T>> GetAsync();
    }
}
