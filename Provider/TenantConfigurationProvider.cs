namespace SolidPrincipalWithDecoratorPatternAndDbContext.Provider
{
    public class TenantConfigurationProvider : ITenantConfigurationProvider
    {
        private readonly Dictionary<string, string> _tenantDbMapping = new()
        {
            { "TenantA", "SQL" },
            { "TenantB", "NoSQL" }
        };

        private readonly Dictionary<string, string> _tenantPaymentStrategyMapping = new()
        {
            { "TenantA", "CreditCard" },
            { "TenantB", "UPI" }
        };

        public string GetDatabaseType(string tenantId)
        {
            return _tenantDbMapping.TryGetValue(tenantId, out var dbType) ? dbType : "SQL"; // Default to SQL
        }        

        public string GetPaymentStrategy(string tenantId)
        {
            return _tenantPaymentStrategyMapping.TryGetValue(tenantId, out var dbType) ? dbType : "CreditCard"; // Default to SQL
        }
    }
}
