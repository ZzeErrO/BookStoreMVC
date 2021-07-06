using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Models
{
    public class Books
    {
        [Key]
        [Required]
        public int BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Authors { get; set; }
        [Required]
        public DateTime Arrivals { get; set; }
        [Required]
        public int AvailabeBooks { get; set; }
        [Required]
        public string ImagePath { get; set; }
    }
}
