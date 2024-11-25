using SolidPrincipalWithDecoratorPatternAndDbContext.Model;

namespace SolidPrincipalWithDecoratorPatternAndDbContext.Strategy
{
    public class PayPalPaymentStrategy : IPaymentStrategy
    {
        public async Task ProcessPaymentAsync(PaymentDetails paymentDetails)
        {
            // Simulate PayPal payment logic
            Console.WriteLine("Processing PayPal Payment...");
            await Task.Delay(1000); // Simulate delay
        }
    }
}
