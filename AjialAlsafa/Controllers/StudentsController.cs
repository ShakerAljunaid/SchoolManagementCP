
using AjialAlsafa.Models;
using AjialAlsafa.Services;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjialAlsafa.Controllers
{
    public class StudentsController : Controller
    {
        StudentsDBOperations db = new StudentsDBOperations();
        // GET: Students
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(int schoolId)
        {
            string json = JsonConvert.SerializeObject(db.GetAllStudents(schoolId), Formatting.Indented);
            return Content(json, "application/json");
        }
        public ActionResult ListStudentData(string code)
        {
            string json = JsonConvert.SerializeObject(db.GetStudentByCode(code), Formatting.Indented);
            return Content(json, "application/json");
        }
        public ActionResult ListStudentByCode(string code)
        {
            ArrayList studentDataCollection = new ArrayList();
            var studentData = db.GetStudentByCode(code);
              studentDataCollection.Add(new
            {
                student = studentData,
                year = new SchoolYearsDBOperations().GetActiveSchoolYears(studentData[0].schoolId),
                terms = new SchoolTermsDBOperations().GetActiveSchoolTerms(studentData[0].schoolId, studentData[0].yearId),
                rounds=new SchoolTermRoundsDBOperations().GetActiveSchoolTermRounds(studentData[0].schoolId, studentData[0].yearId),
                examTable=new ExamTablesDBOperations().GetActiveExamTables(studentData[0].schoolId, studentData[0].yearId,studentData[0].gradeId),
                marks=new StudentMarksDBOperations().GetActiveStudentMarks(studentData[0].schoolId, studentData[0].yearId, studentData[0].id)


            }) ;
            string json = JsonConvert.SerializeObject(studentDataCollection, Formatting.Indented);
            return Content(json, "application/json");
        }

        public int Create(Student student)
        {
            
            return db.Create(student);
        }
        public int Edit(Student student, int id)
        {
            return db.Edit(student) ? 1 : 0; ;
        }
        public int Delete(int id)
        {
            return db.DeleteStudent(id); ;
        }
    }
}