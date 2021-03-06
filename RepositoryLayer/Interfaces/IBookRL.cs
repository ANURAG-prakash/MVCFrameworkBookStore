using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IBookRL
    {

        List<BookModel> GetAllBooks();
        CartModel AddToCart(CartModel cartModel , string email);
        WishlistModel AddToWishlist(WishlistModel wishlistModel , string email);
        List<BookModel> Search(BookModel bookModel);

    }
}
