using NotesPresistence;

namespace NotesWebApi.Data;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
{
    private readonly NotesDbContext _dbContext;

    public Repository(NotesDbContext notesDbContext)
    {
        _dbContext = notesDbContext;
    }

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
}