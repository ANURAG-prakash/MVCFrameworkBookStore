using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ICartBL
    {
        List<GetCart> CartBooks(string email);
        bool Placeorder(string email);
    }
}
