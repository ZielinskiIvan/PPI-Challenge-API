namespace PPI_Challenge_API.Entities
{
    public class CommissionTax : EntityBase
    {
        public int AssetTypeId { get; set; }
        public AssetType AssetType { get; set; } = null!;
        public double Commission { get; set; }
        public double Tax { get; set; }

    }
}
