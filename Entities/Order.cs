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
        public char Operation { get; set; }
        public int StateID { get; set; } = 1; // Tomamos 1 como en proceso(enunciado), se puede poner tambien como una variable estatica, pero si cambia la tabla de States, tendremos que cambiar el valor tambien
        public State State { get; set; }

        [Range(0.01, double.MaxValue)]
        public double TotalAmount { get; set; }
    }
}
