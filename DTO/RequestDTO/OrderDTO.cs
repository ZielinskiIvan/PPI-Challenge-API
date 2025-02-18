namespace PPI_Challenge_API.DTO.RequestDTO
{
    public class OrderDTO
    {
        public int AssetID { get; set; }
        public int Quantity { get; set; }

        public double Price { get; set; }

        public char Operation { get; set; }
    }
}
