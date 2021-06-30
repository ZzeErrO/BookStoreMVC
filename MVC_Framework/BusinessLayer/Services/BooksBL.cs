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
    }
}
