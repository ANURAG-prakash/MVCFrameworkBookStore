using BusinessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class WishlistBL : IWishlistBL
    {
        private readonly IWishlistRL wishlistRL;
        public WishlistBL(IWishlistRL _cartRL)
        {
            this.wishlistRL = _cartRL;
        }
        public List<GetWishlist> WishlistBooks()
        {
            try
            {
                return this.wishlistRL.WishlistBooks();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CartModel WishlistToCart(CartModel cartModel, string email)
        {
            return this.wishlistRL.WishlistToCart(cartModel, email);
        }
    }
}
