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
    public class SubjectTeachersController : Controller
    {

        // GET: SubjectTeachers
        SubjectTeacherDBOperations db = new SubjectTeacherDBOperations();
        public ActionResult GradesSubjects()
        {
            return View();
        }

        public ActionResult List(int gradeId,int classId)
        {
            string json = JsonConvert.SerializeObject(db.GetAllsubjectTeachers(1, gradeId,classId,2), Formatting.Indented);
            return Content(json, "application/json");
        }
        public int Create(SubjectTeacher subjectTeacher)
        {
            return db.Create(subjectTeacher) > 0 ? 1 : 0; ;
        }
        public int Edit(SubjectTeacher subjectTeacher, int id)
        {
            return db.Edit(subjectTeacher) ? 1 : 0; ;
        }
        public int Delete(int id)
        {
            return db.Delete(id); ;
        }
    }
}