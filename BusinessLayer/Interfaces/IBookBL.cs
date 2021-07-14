using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IBookBL
    {
        List<BookModel> GetAllBooks();
        CartModel AddToCart(CartModel cartModel , string Email);
        WishlistModel AddToWishlist(WishlistModel wishlistModel , string email);

        List<BookModel> Search(BookModel bookModel);

    }
}
