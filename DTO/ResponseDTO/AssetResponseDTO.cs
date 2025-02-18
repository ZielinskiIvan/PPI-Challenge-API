namespace PPI_Challenge_API.DTO.ResponseDTO
{
    public class AssetResponseDTO
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        public string Name { get; set; }

        public int AssetTypeID { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
