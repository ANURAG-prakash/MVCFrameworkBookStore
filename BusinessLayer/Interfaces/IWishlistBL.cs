using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
   
        public interface IWishlistBL
        {
            List<GetWishlist> WishlistBooks();
        CartModel WishlistToCart(CartModel cartModel, string email);
    }
    
}
