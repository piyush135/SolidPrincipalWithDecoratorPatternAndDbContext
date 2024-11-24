namespace SolidPrincipalWithDecoratorPatternAndDbContext.Provider
{
    public class TenantConfigurationProvider : ITenantConfigurationProvider
    {
        private readonly Dictionary<string, string> _tenantDbMapping = new()
        {
            { "TenantA", "SQL" },
            { "TenantB", "NoSQL" }
        };

        public string GetDatabaseType(string tenantId)
        {
            return _tenantDbMapping.TryGetValue(tenantId, out var dbType) ? dbType : "SQL"; // Default to SQL
        }
    }
}
