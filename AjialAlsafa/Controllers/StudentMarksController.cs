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
    public class StudentMarksController : Controller
    {
        // GET: StudentMarks
        StudentMarksDBOperations db = new StudentMarksDBOperations();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListStudentMarsk(int schoolId, int yearId, int termId,int studentId)
        {
            string json = JsonConvert.SerializeObject(db.GetActiveStudentMarks(schoolId, yearId,studentId), Formatting.Indented);
            return Content(json, "application/json");
        }


        public int Create(StudentMark studentMark)
        {

            return db.Create(studentMark);
        }
        public int Edit(StudentMark studentMark, int id)
        {
            return db.Edit(studentMark) ? 1 : 0; ;
        }
        public int Delete(int id)
        {
            return db.Delete(id); ;
        }
    }
}