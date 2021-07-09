using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using ModelsLayer.Models;
using RepositoryLayer.Interface;

namespace BusinessLayer.Services
{
    public class CartBL : ICartBL
    {
        private readonly ICartRL cartRL;
        public CartBL(ICartRL _cartRL)
        {
            this.cartRL = _cartRL;
        }

        public List<GetCartBooks> GetAllBooks()
        {
            try
            {
                return this.cartRL.GetAllBooks();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Checkout(string email)
        {
            try
            {
                return this.cartRL.Checkout(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
