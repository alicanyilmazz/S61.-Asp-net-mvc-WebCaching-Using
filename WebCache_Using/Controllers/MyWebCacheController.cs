using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace WebCache_Using.Controllers
{
    public class MyWebCacheController : Controller
    {
        // GET: MyWebCache
        public ActionResult Index()
        {
            string time = WebCache.Get("zaman");

            if (string.IsNullOrEmpty(time))
            {
                time = DateTime.Now.ToString();
                WebCache.Set(key: "zaman", value: time, minutesToCache: 1, slidingExpiration: true);
            }

            ViewBag.simdi = time;

            return View();
        }

        public ActionResult RemoveCache()
        {
            WebCache.Remove("zaman");
            return RedirectToAction("Index");
        }

    }
}

//Örnegin menüdeki kategoriler sürekli değişmiyorsa veya sürekli değişmeyen menüler vs Cache den cekilebilir.