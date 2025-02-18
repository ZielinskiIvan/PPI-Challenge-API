namespace PPI_Challenge_API.Entities
{
    public class CommissionTax : EntityBase
    {
        public int AssetTypeId { get; set; }
        public AssetType AssetType { get; set; } = null!;
        public decimal Commission { get; set; }
        public decimal Tax { get; set; }

    }
}
