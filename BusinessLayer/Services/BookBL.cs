﻿using BusinessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class BookBL : IBookBL
    {
        private readonly IBookRL book;

        public BookBL(IBookRL book)
        {
            this.book = book;
        }

        public CartModel AddToCart(CartModel cartModel)
        {
            return this.book.AddToCart(cartModel);
        }

        public WishlistModel AddToWishlist(WishlistModel wishlistModel)
        {
            return this.book.AddToWishlist(wishlistModel);
        }

        public List<BookModel> GetAllBooks()
        {
            return this.book.GetAllBooks();
        }

        public List<BookModel> Search(BookModel bookModel)
        {
            return this.book.Search(bookModel);
        }
    }
}
