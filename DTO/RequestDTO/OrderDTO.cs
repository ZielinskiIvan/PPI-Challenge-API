namespace PPI_Challenge_API.DTO.RequestDTO
{
    public class OrderDTO
    {
        public int AssetID { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string Operation { get; set; }
    }
}
