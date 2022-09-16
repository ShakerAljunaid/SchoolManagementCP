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
    public class TermsRoundsController : Controller
    {
        // GET: TermsRounds
        SchoolTermRoundsDBOperations db = new SchoolTermRoundsDBOperations();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListRoundsBasedOnTerms(int schoolId, int yearId,int termId)
        {
            string json = JsonConvert.SerializeObject(db.GetActiveSchoolTermRounds(schoolId,yearId), Formatting.Indented);
            return Content(json, "application/json");
        }


        public int Create(SchoolTermRound termRound)
        {

            return db.Create(termRound);
        }
        public int Edit(SchoolTermRound termRound, int id)
        {
            return db.Edit(termRound) ? 1 : 0; ;
        }
        public int Delete(int id)
        {
            return db.Delete(id); ;
        }
    }
}