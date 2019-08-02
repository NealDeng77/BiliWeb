using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BiliWeb.Models;
using BiliWeb.Backend;

namespace BiliWeb.Controllers
{
    public class PhoneController : Controller
    {
        PhoneBackend Backend = PhoneBackend.Instance;

        /// <summary>
        /// Show all the data
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var data = Backend.Index();
            return View(data);
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

            //Look up the ID
            var data = Backend.Read(id);
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
            var data = new PhoneModel();
            return View(data);
        }

        /// <summary>
        /// Receive a post for a new record
        /// </summary>
        /// <param name="data">The data to create</param>
        /// <returns>Redirects to Index page</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(
            [Bind("" +
            "ID,"+
            "Date,"+

            "ClinicID,"+
            "DeviceModel," +
            "SerialNumber," +
            "TimeOut," +
            "ReadingCaptureCount," +
            "TransmitSuccessImage,"+
            "TransmitFailImage,"+

            // TODO, Add your attributes here.  Make sure to include the comma , after the attribute name
            
            "")] PhoneModel data)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            // Todo Save Change
            var result = Backend.Create(data);
            if (result == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Returns a blank Update page with a pre-populated guid for the record
        /// </summary>
        /// <returns>new data model</returns>
        [HttpGet]
        public IActionResult Update(string id)
        {
            //Look up the ID
            var data = Backend.Read(id);
            if (data == null)
            {
                return NotFound();
            }

            ViewData["ClinicIDList"] = BiliWeb.Backend.ClinicHelper.ToSelectListItems(ClinicBackend.Instance.Index(), null);

            return View(data);
        }

        /// <summary>
        /// Receive a post for a new record
        /// </summary>
        /// <param name="data">The data to Update</param>
        /// <returns>Redirects to Index page</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(
            [Bind("" +
            "ID,"+
            "Date,"+

            "ClinicID,"+
            "DeviceModel,"+
            "SerialNumber,"+
            "TimeOut,"+
            "ReadingCaptureCount," +
            "TransmitSuccessImage,"+
            "TransmitFailImage,"+

            // TODO, Add your attributes here.  Make sure to include the comma , after the attribute name

            "")] PhoneModel data)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            //Look up the ID
            var dataExist = Backend.Read(data.ID);
            if (dataExist == null)
            {
                return NotFound();
            }

            var dataResult = Backend.Update(data);
            if (dataResult == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Delete Method, is like Read where it returns the data
        /// Delete Confirm is where it is deleted.
        /// </summary>
        /// <param name="id">the guid of the item to delete</param>
        /// <param name="saveChangesError">Shows error message of failed delete</param>
        /// <returns></returns>
        public IActionResult Delete(string id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            /// Find the data
            var data = Backend.Read(id);
            if (data == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(data);
        }

        /// <summary>
        /// Confirm the Delete does the action
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Redirects to Index on success</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Error", "Home");
            }

            // Check to see if it Exists
            var data = Backend.Read(id);
            if (data == null)
            {
                return NotFound();
            }

            // Try to Delete it
            var result = Backend.Delete(id);
            if (result == false)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id, saveChangesError = true });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}