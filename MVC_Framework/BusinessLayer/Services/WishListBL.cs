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
    public class WishListBL : IWishListBL
    {
        private readonly IWishListRL wishlistRL;
        public WishListBL(IWishListRL _cartRL)
        {
            this.wishlistRL = _cartRL;
        }
        public List<GetWishListBooks> GetAllBooks()
        {
            try
            {
                return this.wishlistRL.GetAllBooks();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
