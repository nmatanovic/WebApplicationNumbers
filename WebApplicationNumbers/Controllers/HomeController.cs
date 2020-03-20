using System;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApplicationNumbers.Models;

namespace WebApplicationNumbers.Controllers
{
    public class HomeController : Controller
    {

        private static NMockList m_List = new NMockList();
        private static string m_SessionID;

        
        public HomeController()
        {
            var SessionID = System.Web.HttpContext.Current.Session.SessionID;

            m_SessionID = SessionID;
            ViewBag.SessionID = SessionID;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(m_List);
        }

        //
        //
        //
        //[HttpDelete]
        [HttpPost]
        public ActionResult ResetAll()
        {
            m_List.Clear();

            return Content("Clear all data");
        }

        //
        //
        //
        [HttpPost]
        public ActionResult AddNumber(int number)
        {
            var SessionID = System.Web.HttpContext.Current.Session.SessionID;

            m_List.Add(SessionID, number);

            return Content("Added number:" + number + " for user with ID:" + SessionID);
        }

        //
        //
        //
        [HttpGet]
        public ActionResult AllNumbers()
        {
            return PartialView("AllNumbers", m_List);
        }

        //
        //
        //
        [HttpGet]
        public ActionResult NumbersForUser()
        {
            return PartialView("UserNumbers", m_List.NumberForUser(m_SessionID));
        }

        [HttpGet]
        public JsonResult Statictics()
        {
            var serializer = new JavaScriptSerializer();

            var s = m_List.Sum();
            var u = m_List.Uniques();
            var r = m_List.Repetitions();

            var result = new { Sum = s, Uniques = u, Repetitions = r };
           
            var jsonResult = serializer.Serialize(result);

            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
    }
}