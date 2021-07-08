using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Models
{
    public class Tokens
    {
        [Required]
        public string Token { get; set; }
    }
}
