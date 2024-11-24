using SolidPrincipalWithDecoratorPatternAndDbContext.Decorator;
using SolidPrincipalWithDecoratorPatternAndDbContext.Factory;
using SolidPrincipalWithDecoratorPatternAndDbContext.Service;
using SolidPrincipalWithGenericDbContext.Model;
using SolidPrincipalWithGenericDbContext.Repository;
using System.Xml;

namespace SolidPrincipalWithGenericDbContext.Service
{
    public class EntityService : IEntityService
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public EntityService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public async Task<IEnumerable<MyEntity>> GetAllEntitiesAsync(string tenantId)
        {
            var repository = _repositoryFactory.CreateRepository<MyEntity>(tenantId);
            return await repository.GetAllAsync();
        }

        public async Task<MyEntity> AddEntityAsync(string tenantId, MyEntity newEntity)
        {
            var repository = _repositoryFactory.CreateRepository<MyEntity>(tenantId);
            await repository.AddAsync(newEntity);
            return newEntity;
        }

        public async Task<MyEntity> UpdateEntityAsync(string tenantId, string id, MyEntity updatedEntity)
        {
            var repository = _repositoryFactory.CreateRepository<MyEntity>(tenantId);
            var entity = await repository.GetByIdAsync(id);

            if (entity == null)
                throw new KeyNotFoundException($"Entity with ID {id} not found.");

            //entity.Name = updatedEntity.Name; // Example of updating a property
            await repository.UpdateAsync(id, entity);
            return entity;
        }

        public async Task<bool> DeleteEntityAsync(string tenantId, string id)
        {
            var repository = _repositoryFactory.CreateRepository<MyEntity>(tenantId);
            var entity = await repository.GetByIdAsync(id);

            if (entity == null)
                throw new KeyNotFoundException($"Entity with ID {id} not found.");

            await repository.DeleteAsync(id);
            return true;
        }       
    }
}
