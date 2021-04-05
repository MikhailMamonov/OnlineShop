using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlieShop.Domain.Models.Entities
{
    public class CartItem
    {
        [Key]
        public string Id { get; set; }
        public string CartId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public DateTime DateCreated { get; set; }
        public string ProductId { get; set; }
        public virtual Product Product { get; set; } 
    }
}
