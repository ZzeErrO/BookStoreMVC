using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsLayer.Models;

namespace BusinessLayer.Interface
{
    public interface ICartBL
    {
        List<GetCartBooks> GetAllBooks();
    }
}
