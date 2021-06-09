using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileStorage.Api.Repositories
{
    public class BaseEntityFrameworkRepository<T> : IRepository<T> where T : class
    {
        protected DbContext _db;

        public BaseEntityFrameworkRepository(DbContext context)
        {
            _db = context;
        }

        public async Task Add(T item)
        {
            await _db.Set<T>().AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = await _db.Set<T>().FindAsync(id);
            if (item == null)
            {
                throw new Exception("Здесь нет такого");
            }
            _db.Set<T>().Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public async Task Update(T item)
        {
            _db.Update(item);
            await _db.SaveChangesAsync();
        }
    }
}
