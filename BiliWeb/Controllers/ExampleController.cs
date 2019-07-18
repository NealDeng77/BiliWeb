using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BiliWeb.Models;

namespace BiliWeb.Controllers
{
    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var data = new ExampleModel();
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("" +
            "ExampleID,"+
            "Name,"+
            "")] ExampleModel data)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            // Todo Save Change
            //data.ExampleID;
            //await SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}