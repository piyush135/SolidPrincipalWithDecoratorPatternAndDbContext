namespace SolidPrincipalWithDecoratorPatternAndDbContext.Provider
{
    public interface ITenantConfigurationProvider
    {
        string GetDatabaseType(string tenantId); // Returns "SQL" or "NoSQL"

        string GetPaymentStrategy(string tenantId); // Returns "CreditCard" "UPI" "So no"
    }
}
