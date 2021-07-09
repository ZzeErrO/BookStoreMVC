using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsLayer.Models;

namespace BusinessLayer.Interface
{
    public interface IBooksBL
    {
        List<Books> GetAllBooks();
        List<Books> GetSearchBooks(string value);
        Cart AddToCart(Cart cartModel, string email);
        WishList AddToWishList(WishList wishlistModel, string email);
        bool UploadImage(int BookId, string imageUpload);
    }
}
