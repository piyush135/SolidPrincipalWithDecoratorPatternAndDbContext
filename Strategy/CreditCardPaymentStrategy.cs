using SolidPrincipalWithDecoratorPatternAndDbContext.Model;

namespace SolidPrincipalWithDecoratorPatternAndDbContext.Strategy
{
    public class CreditCardPaymentStrategy : IPaymentStrategy
    {
        public async Task ProcessPaymentAsync(PaymentDetails paymentDetails)
        {
            Console.WriteLine("Processing Credit Card Payment...");
            await Task.Delay(1000); // Simulate delay
        }
    }
}
