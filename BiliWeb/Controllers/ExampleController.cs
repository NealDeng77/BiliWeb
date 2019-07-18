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
        /// <summary>
        /// Show all the data
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Return the data for the ID passed in
        /// </summary>
        /// <returns>Data record, or redirects to error</returns>
        [HttpGet]
        public IActionResult Read(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            //TODO Look up the ID
            var data = new ExampleModel();

            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        /// <summary>
        /// Returns a blank create page with a pre-populated guid for the record
        /// </summary>
        /// <returns>new data model</returns>
        [HttpGet]
        public IActionResult Create()
        {
            var data = new ExampleModel();
            return View(data);
        }

        /// <summary>
        /// Receive a post for a new record
        /// </summary>
        /// <param name="data">The data to create</param>
        /// <returns>Redirects to Index page</returns>
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