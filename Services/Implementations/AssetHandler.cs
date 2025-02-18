using PPI_Challenge_API.Services.Interfaces;

namespace PPI_Challenge_API.Services.Implementations
{
    public class AssetHandler : IAssetHandler
    {
        private readonly IServiceProvider _serviceProvider;
        public AssetHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<IAssetAmountCalculator> GetCalculator(int assetTypeId)
        {
            IAssetAmountCalculator a = _serviceProvider.GetService<ShareAmountCalculator>();

            return assetTypeId switch
            {
                1 => _serviceProvider.GetService<IShareAmountCalculator>(),
                2 => _serviceProvider.GetService<IBondAmountCalculator>(),
                3 => _serviceProvider.GetService<IFciAmountCalculator>(),
                _ => throw new ArgumentException("Tipo de activo no válido.")
            };
        }
    }
}
