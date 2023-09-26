using AntraMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace AntraMVC.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {


        private readonly AntraDbContext _db;
        private readonly DbSet<T> _entities;
        public BaseRepository(AntraDbContext db) {
            _db = db;
            _entities = _db.Set<T>();
        }
        public async Task<bool> AddAsync(T entity)
        {
            var result=_entities.AddAsync(entity);
            if (result != null)
            {
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {

            var deletedObj=await _entities.FindAsync(id);

            if (deletedObj!=null)
            {
                _entities.Remove(deletedObj);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _entities.Update(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
