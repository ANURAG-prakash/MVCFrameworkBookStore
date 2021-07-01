using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Models
{
    public class CartModel
    {
        [Key]
        public int CartId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CartBookQuantity { get; set; }
    }
}
