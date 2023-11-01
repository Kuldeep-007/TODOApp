using Microsoft.EntityFrameworkCore;

namespace TODOApp.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected TODOAppDbContext context;
        public DbSet<T> dbSet;

        public GenericRepository(TODOAppDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task Add(T entity)
        {
            await dbSet.AddAsync(entity);
            await Save();
        }

        public virtual async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                await Save();
            }
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task Upsert(T entity)
        {
            if (await dbSet.FirstOrDefaultAsync(x => x == entity) == null)
            {
                await Add(entity);
                await Save();
            }
            else
            {
                dbSet.Remove(entity);
                await Save();

                await Add(entity);
                await Save();
            }
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
