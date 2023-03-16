namespace NotesApplication.Data;

/// <summary>
/// Interface IRepository
/// </summary>
/// <typeparam name="TEntity">The type of the t entity.</typeparam>
public interface IRepository<TEntity> where TEntity : class, new()
{
    /// <summary>
    /// Gets all.
    /// </summary>
    /// <returns>IQueryable&lt;TEntity&gt;.</returns>
    IQueryable<TEntity> GetAll();

    /// <summary>
    /// Finds the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>TEntity.</returns>
    TEntity? Find(string id);

    /// <summary>
    /// Adds the asynchronous.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>Task&lt;TEntity&gt;.</returns>
    Task<TEntity> AddAsync(TEntity entity);

    /// <summary>
    /// Updates the asynchronous.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>Task&lt;TEntity&gt;.</returns>
    Task<TEntity> UpdateAsync(TEntity entity);
}