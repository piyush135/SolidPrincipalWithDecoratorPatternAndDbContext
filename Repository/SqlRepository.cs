using SolidPrincipalWithGenericDbContext.DbContext;
using SolidPrincipalWithGenericDbContext.Repository;

namespace SolidPrincipalWithDecoratorPatternAndDbContext.Repository
{
    public class SqlRepository<T> : IRepository<T> where T : class
    {
        private readonly IDBContext _dbContext;

        public SqlRepository(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetByIdAsync(string id) => await _dbContext.GetByIdAsync<T>(id);
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbContext.QueryAsync<T>("SELECT * FROM TableName");
        public async Task AddAsync(T entity) => await _dbContext.SaveAsync(entity);
        public async Task UpdateAsync(string id, T entity) => await _dbContext.SaveAsync(entity);
        public async Task DeleteAsync(string id) => await _dbContext.DeleteAsync<T>(id);
    }
}
