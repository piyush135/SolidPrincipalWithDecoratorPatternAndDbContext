using SolidPrincipalWithDecoratorPatternAndDbContext.Model;

namespace SolidPrincipalWithDecoratorPatternAndDbContext.Strategy
{
    public interface IPaymentStrategy
    {
        Task ProcessPaymentAsync(PaymentDetails paymentDetails);
    }
}
