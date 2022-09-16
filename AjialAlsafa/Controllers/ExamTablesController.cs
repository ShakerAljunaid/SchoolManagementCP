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
    public class ExamTablesController : Controller
    {
        // GET: ExamTables
        ExamTablesDBOperations db = new ExamTablesDBOperations();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListExamTablesBasedOnGrade(int schoolId, int yearId, int termId,int gradeId)
        {
            string json = JsonConvert.SerializeObject(db.GetActiveExamTables(schoolId, yearId, gradeId), Formatting.Indented);
            return Content(json, "application/json");
        }


        public int Create(ExamTable examTable)
        {

            return db.Create(examTable);
        }
        public int Edit(ExamTable examTable, int id)
        {
            return db.Edit(examTable) ? 1 : 0; ;
        }
        public int Delete(int id)
        {
            return db.Delete(id); ;
        }
    }
}