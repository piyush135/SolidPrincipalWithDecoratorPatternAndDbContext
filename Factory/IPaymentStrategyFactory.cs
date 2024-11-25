using SolidPrincipalWithDecoratorPatternAndDbContext.Strategy;

namespace SolidPrincipalWithDecoratorPatternAndDbContext.Factory
{
    public interface IPaymentStrategyFactory
    {
        IPaymentStrategy GetPaymentStrategy(string paymentStrategyKey);
    }
}
