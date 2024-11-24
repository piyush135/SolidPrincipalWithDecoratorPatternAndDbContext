namespace SolidPrincipalWithDecoratorPatternAndDbContext.Provider
{
    public interface ITenantConfigurationProvider
    {
        string GetDatabaseType(string tenantId); // Returns "SQL" or "NoSQL"
    }
}
