using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication17.Models
{
    public class CountsViewModel
    {
        public Dictionary<char, int> Counts { get; set; }
        public string Text { get; set; }
    }
}
