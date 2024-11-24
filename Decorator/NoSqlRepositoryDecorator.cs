using SolidPrincipalWithDecoratorPatternAndDbContext.Repository;
using SolidPrincipalWithGenericDbContext.DbContext;
using SolidPrincipalWithGenericDbContext.Repository;

namespace SolidPrincipalWithDecoratorPatternAndDbContext.Decorator
{
    public class NoSqlRepositoryDecorator<T> : NoSqlRepository<T> where T : class
    {
        private readonly IRepository<T> _decoratedRepository;
        public NoSqlRepositoryDecorator(IRepository<T> decoratedRepository, IDBContext dbContext) : base(dbContext)
        {
            _decoratedRepository = decoratedRepository ?? throw new ArgumentNullException(nameof(decoratedRepository));
        }


        public void SpecificNoSqlMethod()
        {
            Console.WriteLine($"Executing NoSQL-specific method for {typeof(T).Name}");
        }
    }
}
