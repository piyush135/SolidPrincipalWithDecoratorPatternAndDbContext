using SolidPrincipalWithDecoratorPatternAndDbContext.Model;

namespace SolidPrincipalWithDecoratorPatternAndDbContext.Strategy
{
    public class UPIStrategy : IPaymentStrategy
    {
        public async Task ProcessPaymentAsync(PaymentDetails paymentDetails)
        {
            // Simulate Crypto payment logic
            Console.WriteLine("Processing UPI Payment...");
            await Task.Delay(1000); // Simulate delay
        }
    }
}
