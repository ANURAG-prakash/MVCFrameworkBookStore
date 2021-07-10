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
    public class CartBL : ICartBL
    {
        private readonly ICartRL cartRL;
        public CartBL(ICartRL _cartRL)
        {
            this.cartRL = _cartRL;
        }
        public List<GetCart> CartBooks(string email)
        {
            try
            {
                return this.cartRL.CartBooks(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Placeorder(string email)
        {
            try
            {
                return this.cartRL.Placeorder(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
