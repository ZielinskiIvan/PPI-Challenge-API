using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PPI_Challenge_API.Entities
{
    public class Order : EntityBase
    {

        [Required]
        public string UserID { get; set; }
        public IdentityUser User { get; set; }
        public int AssetID { get; set; }
        public Asset Asset { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        [StringLength(1)]
        [RegularExpression(@"^[CV]$")]
        public string Operation { get; set; }
        public int StateID { get; set; } = 1;
        public State State { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal TotalAmount { get; set; }
    }
}
