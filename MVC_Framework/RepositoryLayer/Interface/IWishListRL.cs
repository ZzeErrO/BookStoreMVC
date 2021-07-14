using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsLayer.Models;

namespace RepositoryLayer.Interface
{
    public interface IWishListRL
    {
        List<GetWishListBooks> GetAllBooks(string email);
    }
}
