using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IWishlistRL
    {
        List<GetWishlist> WishlistBooks();
        CartModel WishlistToCart(CartModel cartModel, string email);
    }
}
