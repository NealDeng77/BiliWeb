using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BiliWeb.Controllers
{
    public class AboutController : Controller
    {
        /// <summary>
        /// Create view of the controller page.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Create view of the Issue page
        /// </summary>
        /// <returns></returns>
        public IActionResult Issue()
        {
            return View();
        }

        /// <summary>
        /// Create view of the Solution page
        /// </summary>
        /// <returns></returns>
        public IActionResult Solution()
        {
            return View();
        }
    }
}