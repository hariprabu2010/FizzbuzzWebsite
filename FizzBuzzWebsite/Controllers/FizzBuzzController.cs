
namespace FizzBuzzWebsite.Controllers
{
    using FizzBuzzBL;
    using FizzBuzzWebsite.Models;
    using System;
    using System.Web.Mvc;
    using System.Configuration;
    using System.Linq;

    public class FizzBuzzController : Controller
    {
        private IFizzBuzzManager _fizzBuzzManager;
        MapperClass mappingClass = new MapperClass();

        public FizzBuzzController(IFizzBuzzManager fizzBuzzManager)
        {
            this._fizzBuzzManager = fizzBuzzManager;
        }
        //
        // GET: /FizzBuzz/
        /// <summary>
        /// Get Method - returns empty view
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Display()
        {
            return View();
        }

        /// <summary>
        /// post method - redirects to Get as per PRG
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [HandleError]
        public ActionResult Display(FizzBuzzViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Post-Redirect-Get Pattern
                return RedirectToAction("DisplayFizzBuzz", model);
            }
            return View("Display");
        }

        /// <summary>
        /// HTTP Get method to handle the PRG redirect. Returns the collection
        /// </summary>
        /// <param name="inputNumber"></param>
        /// <param name="model"></param>
        /// <returns>Model collection</returns>
        [HttpGet]
        public ActionResult DisplayFizzBuzz(FizzBuzzViewModel model)
        {

            model.PageSize = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Pagesize"));
            model.PageCount = Convert.ToInt32(Math.Ceiling((double)(Convert.ToDouble(model.InputNumber) / Convert.ToDouble(model.PageSize))));
            model.DisplayList = mappingClass.Map(_fizzBuzzManager.Generate(model.InputNumber)).DisplayList;
            model.FizzBuzzPagedList = model.DisplayList.Skip(model.CurrentPageIndex * model.PageSize).Take(model.PageSize).ToList();


            if (model.FizzBuzzPagedList != null)
            {
                return View("Display", model);
            }

            return View("Display");

        }
    }
}
