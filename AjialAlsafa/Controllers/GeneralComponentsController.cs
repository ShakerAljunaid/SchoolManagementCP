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
    public class GeneralComponentsController : Controller
    {
        GeneralComponentsDBOperations db = new GeneralComponentsDBOperations();
        // GET: GeneralComponents
        public ActionResult Index(int typeId)
        {
            ViewBag.TypeId = typeId;
            return View();
        }
       
       
    public ActionResult List(int typeId)
        {
            string json = JsonConvert.SerializeObject(db.GetAllGeneralComponents(typeId), Formatting.Indented);
            return Content(json, "application/json");
        }
        public int Create(GeneralComponent generalComponent)
        {
            return db.Create(generalComponent) > 0 ? 1 : 0; ;
        }
        public int Edit(GeneralComponent generalComponent, int id)
        {
            return db.Edit(generalComponent) ? 1 : 0; ;
        }
        public int Delete(int id)
        {
            return db.Delete(id); ;
        }
    }
}