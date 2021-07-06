using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsLayer.Models;

namespace RepositoryLayer.Interface
{
    public interface IBooksRL
    {
        List<Books> GetAllBooks();
        Cart AddToCart(Cart cartModel);
        WishList AddToWishList(WishList wishlistModel);
        bool UploadImage(int BookId, string imageUpload);

    }
}
