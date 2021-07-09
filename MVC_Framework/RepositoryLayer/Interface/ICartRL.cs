using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsLayer.Models;

namespace RepositoryLayer.Interface
{
    public interface ICartRL
    {
        List<GetCartBooks> GetAllBooks();
        bool Checkout(string email);
    }
}
