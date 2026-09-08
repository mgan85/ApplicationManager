using Microsoft.EntityFrameworkCore;

namespace DataLogic.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
  
        public virtual async Task<List<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public virtual async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public virtual void Remove(T entity) => _dbSet.Remove(entity);   

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
