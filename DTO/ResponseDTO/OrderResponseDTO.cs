using Microsoft.AspNetCore.Identity;
using PPI_Challenge_API.Entities;
using System.ComponentModel.DataAnnotations;

namespace PPI_Challenge_API.DTO.ResponseDTO
{
    public class OrderResponseDTO
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public int AssetID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Operation { get; set; }
        public int StateID { get; set; } = 1;
        public double TotalAmount { get; set; }
    }
}
