using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication17.Models;

namespace WebApplication17.Controllers
{
    public class SessionDemoController : Controller
    {
        public IActionResult Index()
        {


            //int? nullableCount = HttpContext.Session.GetInt32("Count");
            //int count;
            //if(nullableCount == null)
            //{
            //    count = 1;
            //}
            //else
            //{
            //    count = nullableCount.Value;
            //}
            ////int count = nullableCount.HasValue ? nullableCount.Value : 1;

            //HttpContext.Session.SetInt32("Count", count + 1);
            //var vm = new SessionCountViewModel
            //{
            //    Count = count
            //};

            SessionCountViewModel vm = HttpContext.Session.Get<SessionCountViewModel>("counts");
            if(vm == null)
            {
                vm = new SessionCountViewModel
                {
                    Count = 0
                };
            }

            vm.Count++;
            HttpContext.Session.Set("counts", vm);

            return View(vm);
        }
    }

    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }
    }
}
