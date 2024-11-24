using SolidPrincipalWithDecoratorPatternAndDbContext.Decorator;
using SolidPrincipalWithDecoratorPatternAndDbContext.Provider;
using SolidPrincipalWithDecoratorPatternAndDbContext.Repository;
using SolidPrincipalWithGenericDbContext.DbContext;
using SolidPrincipalWithGenericDbContext.Repository;

namespace SolidPrincipalWithDecoratorPatternAndDbContext.Factory
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ITenantConfigurationProvider _tenantConfigProvider;

        public RepositoryFactory(IServiceProvider serviceProvider, ITenantConfigurationProvider tenantConfigProvider)
        {
            _serviceProvider = serviceProvider;
            _tenantConfigProvider = tenantConfigProvider;
        }       

        IRepository<T> IRepositoryFactory.CreateRepository<T>(string tenantId)
        {
            var dbType = _tenantConfigProvider.GetDatabaseType(tenantId);
            var dbContext = _serviceProvider.GetRequiredService<IDBContext>();           

            if (dbType == "NoSQL")
            {
                // Create NoSQL Repository and wrap it with the decorator
                var noSqlRepository = new NoSqlRepository<T>(dbContext);
                return new NoSqlRepositoryDecorator<T>(noSqlRepository, dbContext);
            }
            else
            {
                var sqlRepository = new SqlRepository<T>(dbContext);
                return new SqlRepositoryDecorator<T>(sqlRepository, dbContext);
            }
        }
    }
}
