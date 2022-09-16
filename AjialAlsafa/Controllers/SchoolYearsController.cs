using AjialAlsafa.Models;
using AjialAlsafa.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjialAlsafa.Controllers
{
    public class SchoolYearsController : Controller
    {
        // GET: SchoolYears
        SchoolYearsDBOperations db = new SchoolYearsDBOperations();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(int schoolId)
        {
            string json = JsonConvert.SerializeObject(db.GetActiveSchoolYears(schoolId), Formatting.Indented);
            return Content(json, "application/json");
        }
       

        public int Create(SchoolYear schoolYear)
        {

            return db.Create(schoolYear);
        }
        public int Edit(SchoolYear schoolYear, int id)
        {
            return db.Edit(schoolYear) ? 1 : 0; ;
        }
        public int Delete(int id)
        {
            return db.Delete(id); ;
        }
    }
}