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
    public class MessagesController : Controller
    {
        MessagesDBOperations db = new MessagesDBOperations();
        // GET: Messages
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Notifications()
        { return View(); }
        public ActionResult List(int schoolId,int yearId,int gradeId)
        {
            string json = JsonConvert.SerializeObject(db.GetActiveMessage(schoolId, yearId,gradeId), Formatting.Indented);
            return Content(json, "application/json");
        }
        public ActionResult ListMessagesBaseOnGrade(int schoolId, int yearId, int gradeId)
        {
            string json = JsonConvert.SerializeObject(db.GetActiveMessage(schoolId, yearId, gradeId), Formatting.Indented);
            return Content(json, "application/json");
        }
        public int Create(Message message)
        {
            int created = db.Create(message);
            if (created > 0)
            {
              var msg= db.GetMessageById(created);
                new HelperFunctions().SendMessageFromFirebaseCloud("gradeId" + msg[0].gradeId, "msg", msg);



            }
               
            
            return created; 
        }
        public int Edit(Message message, int id)
        {
            return db.Edit(message) ? 1 : 0; ;
        }
        public int Delete(int id)
        {
            return db.Delete(id); ;
        }
    }
}