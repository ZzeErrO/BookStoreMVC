using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Models
{
    public class GetCartBooks
    {
        public int CartId { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public string BookName { get; set; }
        public string Authors { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
    }
}
