using SolidPrincipalWithGenericDbContext.Model;

namespace SolidPrincipalWithDecoratorPatternAndDbContext.Service
{
    public interface IEntityService
    {
        Task<IEnumerable<MyEntity>> GetAllEntitiesAsync(string tenantId);
        Task<MyEntity> AddEntityAsync(string tenantId, MyEntity newEntity);
        Task<MyEntity> UpdateEntityAsync(string tenantId, string id, MyEntity updatedEntity);
        Task<bool> DeleteEntityAsync(string tenantId, string id);
    }
}
