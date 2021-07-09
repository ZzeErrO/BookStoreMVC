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
    public class BooksBL : IBooksBL
    {
        private readonly IBooksRL booksRL;
        public BooksBL(IBooksRL _booksRL)
        {
            booksRL = _booksRL;
        }
        public List<Books> GetAllBooks()
        {
            return this.booksRL.GetAllBooks();
        }
        public List<Books> GetSearchBooks(string value)
        {
            return this.booksRL.GetSearchBooks(value);
        }
        public Cart AddToCart(Cart cartModel, string email)
        {
            return this.booksRL.AddToCart(cartModel, email);
        }
        public WishList AddToWishList(WishList wishlistModel, string email)
        {
            return this.booksRL.AddToWishList(wishlistModel, email);
        }
        public bool UploadImage(int BookId, string imageUpload)
        {
            return this.booksRL.UploadImage(BookId, imageUpload);
        }
    }
}
