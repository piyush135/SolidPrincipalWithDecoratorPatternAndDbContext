using SolidPrincipalWithDecoratorPatternAndDbContext.Strategy;

namespace SolidPrincipalWithDecoratorPatternAndDbContext.Factory
{
    public class PaymentStrategyFactory : IPaymentStrategyFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public PaymentStrategyFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IPaymentStrategy GetPaymentStrategy(string paymentStrategyKey)
        {
            return paymentStrategyKey switch
            {
                "CreditCard" => _serviceProvider.GetRequiredService<CreditCardPaymentStrategy>(),
                "PayPal" => _serviceProvider.GetRequiredService<PayPalPaymentStrategy>(),
                "UPI" => _serviceProvider.GetRequiredService<UPIStrategy>(),
                _ => throw new ArgumentException($"Invalid payment strategy: {paymentStrategyKey}")
            };
        }
    }
}
