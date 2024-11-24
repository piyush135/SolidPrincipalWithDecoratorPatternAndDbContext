using SolidPrincipalWithGenericDbContext.Repository;

namespace SolidPrincipalWithDecoratorPatternAndDbContext.Decorator
{
    public class RepositoryDecorator<T> : IRepository<T> where T : class
    {
        protected readonly IRepository<T> _innerRepository;

        public RepositoryDecorator(IRepository<T> innerRepository)
        {
            _innerRepository = innerRepository;
        }

        public virtual async Task<T> GetByIdAsync(string id) => await _innerRepository.GetByIdAsync(id);
        public virtual async Task<IEnumerable<T>> GetAllAsync() => await _innerRepository.GetAllAsync();
        public virtual async Task AddAsync(T entity) => await _innerRepository.AddAsync(entity);
        public virtual async Task UpdateAsync(string id, T entity) => await _innerRepository.UpdateAsync(id, entity);
        public virtual async Task DeleteAsync(string id) => await _innerRepository.DeleteAsync(id);
    }
}
