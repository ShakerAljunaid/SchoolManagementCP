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
    public class SchoolTermsController : Controller
    {
        // GET: SchoolTerms
        SchoolTermsDBOperations db = new SchoolTermsDBOperations();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListTermsBaseOnYears(int schoolId,int yearId)
        {
            string json = JsonConvert.SerializeObject(db.GetActiveSchoolTerms(schoolId,yearId), Formatting.Indented);
            return Content(json, "application/json");
        }


        public int Create(SchoolTerm schoolTerm)
        {

            return db.Create(schoolTerm);
        }
        public int Edit(SchoolTerm schoolTerm, int id)
        {
            return db.Edit(schoolTerm) ? 1 : 0; ;
        }
        public int Delete(int id)
        {
            return db.Delete(id); ;
        }
    }
}