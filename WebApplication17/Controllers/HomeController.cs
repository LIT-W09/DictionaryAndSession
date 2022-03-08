using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication17.Models;

namespace WebApplication17.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CountLetters(string text)
        {
            var vm = new CountsViewModel
            {
                Counts = GetCounts(text),
                Text = text
            };
            return View(vm);
        }

        private Dictionary<char, int> GetCounts(string text)
        {
            Dictionary<char, int> counts = new();
            foreach(var letter in "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
            {
                counts.Add(letter, 0);
            }

            foreach(char letter in text.ToUpper())
            {
                if (counts.ContainsKey(letter))
                {
                    counts[letter]++;
                }
                else
                {
                    counts.Add(letter, 1);
                }
            }

            return counts;
        }

    }
}
