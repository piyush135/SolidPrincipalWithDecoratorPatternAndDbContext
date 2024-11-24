using SolidPrincipalWithDecoratorPatternAndDbContext.Repository;
using SolidPrincipalWithGenericDbContext.DbContext;

namespace SolidPrincipalWithDecoratorPatternAndDbContext.Decorator
{
    public class SqlRepositoryDecorator<T> : SqlRepository<T> where T : class
    {
        private SqlRepository<T> sqlRepository;

        public SqlRepositoryDecorator(SqlRepository<T> sqlRepository, IDBContext dbContext) : base(dbContext)
        {
            this.sqlRepository = sqlRepository;
        }

        public void SpecificSqlMethod()
        {
            Console.WriteLine($"Executing SQL-specific method for {typeof(T).Name}");
        }
    }    
}
