namespace PPI_Challenge_API.Services.Interfaces
{
    public interface IAssetHandler
    {
        Task<IAssetAmountCalculator> GetCalculator(int assetTypeId);
    }
}
