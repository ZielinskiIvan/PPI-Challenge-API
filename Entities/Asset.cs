namespace PPI_Challenge_API.Entities
{
    public class Asset : EntityBase
    {
        public string Ticker { get; set; }
        public string Name { get; set; }

        public int AssetTypeID { get; set; }
        public AssetType AssetType { get; set; }

        public double UnitPrice { get; set; }


    }
}
