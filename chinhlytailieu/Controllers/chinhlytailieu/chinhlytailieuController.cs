using chinhlytailieu.Models.admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chinhlytailieu.Controllers.chinhlytailieu
{
    public class chinhlytailieuController : Controller
    {
        // GET: chinhlytailieu
        public ActionResult index(int? id)
        {
            List<nhomchucnang> list = dataAsset.loadallchucnang.nhomchucnang(Session["username"].ToString(), id);
            return View(list);
        }

        public PartialViewResult chucnang(int id)
        {
            List<chucnang> cm = dataAsset.loadallchucnang.Loadchucnang(Session["username"].ToString(), id);
            ViewBag.Count = cm.Count();
            return PartialView("chucnang", cm);
        }

        public ActionResult phanheQLthuthapTL(int? id)
        {
            
            return View();
        }

        public ActionResult lapkehoachchinhly()
        {
            return View();
        }

        public ActionResult taomucluc()
        {
            return View();
        }

        public ActionResult nhaphoso()
        {
            return View();
        }

        public ActionResult nhaphosothem()
        {
            return View();
        }

        public ActionResult nhapvanban()
        {
            return View();
        }

        public ActionResult importhoso()
        {
            return View();
        }

        public ActionResult importvanban()
        {
            return View();
        }

        public ActionResult taohop()
        {
            return View();
        }

        public ActionResult xephosovaohop()
        {
            return View();
        }

        public ActionResult kiemtrahosochinhly()
        {
            return View();
        }

        public ActionResult giaotailieuvaokho()
        {
            return View();
        }
    }
}