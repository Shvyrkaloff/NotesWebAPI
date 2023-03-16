using NotesPresistence;
using NotesPresistence.Base;

namespace NotesApplication.Data;

/// <summary>
/// Class Repository.
/// Implements the <see cref="NotesApplication.Data.IRepository{TEntity}" />
/// </summary>
/// <typeparam name="TEntity">The type of the t entity.</typeparam>
/// <seealso cref="NotesApplication.Data.IRepository{TEntity}" />
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IHaveId, new() 
{
    /// <summary>
    /// The database context
    /// </summary>
    private readonly NotesDbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="Repository{TEntity}" /> class.
    /// </summary>
    /// <param name="notesDbContext">The notes database context.</param>
    public Repository(NotesDbContext notesDbContext)
    {
        _dbContext = notesDbContext;
    }

    /// <summary>
    /// Gets all.
    /// </summary>
    /// <returns>IQueryable&lt;TEntity&gt;.</returns>
    /// <exception cref="NotesApplication.Common.Exception">Couldn't retrieve entities</exception>
    public IQueryable<TEntity> GetAll()
    {
        try
        {
            var ret = _dbContext.Set<TEntity>();
            return ret;
        }
        catch (Exception)
        {
            throw new Exception("Couldn't retrieve entities");
        }
    }

    /// <summary>
    /// Finds the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>TEntity.</returns>
    public TEntity? Find(string id)
    {
        var ret = _dbContext.Set<TEntity>().Find(id);
        return ret;
    }

    /// <summary>
    /// Add as an asynchronous operation.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>A Task&lt;TEntity&gt; representing the asynchronous operation.</returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    /// <exception cref="NotesApplication.Common.Exception"></exception>
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
        }
        try
        {
            await ((NotesDbContext)_dbContext).AddAsync(entity);
            await ((NotesDbContext)_dbContext).SaveChangesAsync();

            return entity;
        }
        catch (Exception)
        {
            throw new Exception($"{nameof(entity)} could not be saved");
        }
    }

    /// <summary>
    /// Update as an asynchronous operation.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>A Task&lt;TEntity&gt; representing the asynchronous operation.</returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    /// <exception cref="NotesApplication.Common.Exception"></exception>
    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
        }

        try
        {
            ((NotesDbContext)_dbContext).Update(entity);
            await ((NotesDbContext)_dbContext).SaveChangesAsync();

            return entity;
        }
        catch (Exception)
        {
            throw new Exception($"{nameof(entity)} could not be updated");
        }
    }
    /// <summary>
    /// Delete as an asynchronous operation.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>A Task&lt;TEntity&gt; representing the asynchronous operation.</returns>
    /// <exception cref="NotesApplication.Common.Exception"></exception>
    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        try
        {
            ((NotesDbContext)_dbContext).Remove(entity);
            await ((NotesDbContext)_dbContext).SaveChangesAsync();

            return entity;
        }
        catch (Exception)
        {
            throw new Exception($"{nameof(entity)} could not be removed");
        }
    }
}