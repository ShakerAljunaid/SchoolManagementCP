using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjialAlsafa.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public int SetYearId(int yearId)
        {
            Session["yearId"] = yearId;
            return (int)Session["yearId"];
        }
        public int SetSchoolId(int schoolId)
        {
            Session["schoolId"] = schoolId;
            return (int)Session["schoolId"];
        }
        public int SetTermId(int termId)
        {
            Session["termId"] = termId;
            return (int)Session["termId"];
        }
        public int SetBranchId(int bracnchId)
        {
            Session["bracnchId"] = bracnchId;
            return (int)Session["bracnchId"];
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}