using API.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class BaseRepository<TEntity> : IDisposable where TEntity : class
    {
        protected readonly NiboContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(NiboContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void AddAsync(TEntity obj) => DbSet.AddAsync(obj);

        public virtual async Task<bool> AddAsync(IEnumerable<TEntity> obj)
        {
            DbSet.AddRange(obj);
            return await SaveChangesAsync();
        }

        public virtual async Task<bool> SaveAsync(TEntity obj)
        {
            DbSet.Add(obj);
            return await SaveChangesAsync();
        }

        public virtual async Task<TEntity> GetAsync(int id) => await DbSet.FindAsync(id);

        public virtual async Task<IEnumerable<TEntity>> GetAsync() => await DbSet.ToListAsync();

        public virtual void Update(TEntity obj) => DbSet.Update(obj);

        public virtual async Task<bool> UpdateAsync(TEntity obj)
        {
            DbSet.Update(obj);
            return await SaveChangesAsync();
        }

        public virtual async Task<bool> RemoveAsync(int id)
        {
            DbSet.Remove(DbSet.Find(id));
            return await SaveChangesAsync();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<bool> SaveChangesAsync() => await Db.SaveChangesAsync() > 0;
    }
}
