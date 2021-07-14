using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Models
{
    public class GetCart
    {
        public int CartId { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public string BookName { get; set; }
        public string Authors { get; set; }
        public double Price { get; set; }
        public int WishlistId { get; set; }
        public string Image { get; set; }
    }
}
