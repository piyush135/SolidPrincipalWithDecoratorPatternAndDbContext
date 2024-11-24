using SolidPrincipalWithGenericDbContext.Repository;

namespace SolidPrincipalWithDecoratorPatternAndDbContext.Factory
{
    public interface IRepositoryFactory
    {
        IRepository<T> CreateRepository<T>(string tenantId) where T : class;
    }
}
