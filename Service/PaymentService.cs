using SolidPrincipalWithDecoratorPatternAndDbContext.Factory;
using SolidPrincipalWithDecoratorPatternAndDbContext.Model;
using SolidPrincipalWithDecoratorPatternAndDbContext.Provider;
using SolidPrincipalWithGenericDbContext.Repository;

namespace SolidPrincipalWithDecoratorPatternAndDbContext.Service
{
    public class PaymentService
    {
        private readonly IPaymentStrategyFactory _paymentStrategyFactory;
        private readonly ITenantConfigurationProvider _tenantConfigurationProvider;
        private readonly IRepository<PaymentDetails> _repository;

        public PaymentService(
            IPaymentStrategyFactory paymentStrategyFactory,
            ITenantConfigurationProvider tenantConfigurationProvider,
            IRepository<PaymentDetails> repository)
        {
            _paymentStrategyFactory = paymentStrategyFactory;
            _tenantConfigurationProvider = tenantConfigurationProvider;
            _repository = repository;
        }

        public async Task ProcessAndSavePaymentAsync(string tenantId, PaymentDetails paymentDetails)
        {
            // Fetch tenant configuration
            var tenantPaymentStrategy = _tenantConfigurationProvider.GetPaymentStrategy(tenantId);
            if (tenantPaymentStrategy == null)
            {
                throw new ArgumentException($"Tenant configuration not found for TenantId: {tenantId}");
            }

            // Resolve the appropriate payment strategy
            var paymentStrategy = _paymentStrategyFactory.GetPaymentStrategy(tenantPaymentStrategy);

            // Process payment
            await paymentStrategy.ProcessPaymentAsync(paymentDetails);

            // Save payment details
            await _repository.AddAsync(paymentDetails);           
        }
    }
}
