using chinhlytailieu.Helper;
using chinhlytailieu.Models.admin;
using chinhlytailieu.Models.users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace chinhlytailieu.Controllers.hethong
{
    public class hethongController : Controller
    {
        // GET: hethong
        public ActionResult Index(int? id)
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

        //quanlynguoidung
        public ActionResult quanlyphongban()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(),"quanlyphongban"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
            
        }
        public ActionResult quanlychucvu()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "quanlychucvu"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }
        public ActionResult quanlynguoidung()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "quanlynguoidung"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }
        public ActionResult quanlynhom()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "quanlynhom"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }

        //phanquyen
        public ActionResult phanquyentruycaptailieu()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "phanquyentruycaptailieu"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }
        public ActionResult phanquyenchucnang()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "phanquyenchucnang"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }

        //thietlapquytrinh
        public ActionResult quanlyquytrinh()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "quanlyquytrinh"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }
        public ActionResult quanlyloaihinhkhaithac()
        {
            return View();
        }
        public ActionResult phanquyenxulyquytrinh()
        {
            return View();
        }

        //cauhinhhethong
        public ActionResult cauhinhdangnhap()
        {
            return View();
        }
        public ActionResult cauhinhkhac()
        {
            return View();
        }
        public ActionResult cauhinhvitriluutru()
        {
            return View();
        }

        public ActionResult backupcosodulieu()
        {
            return View();
        }

        //nhatky
        public ActionResult nhatkyhethong()
        {
            return View();
        }
        public ActionResult nhatkythaydoitailieu()
        {
            return View();
        }
        public ActionResult nhatkydocgia()
        {
            return View();
        }


//============ QUAN LY NGUOI DUNG ===========

        //====== QUAN LY CHUC VU ======
        public string DanhSachChucVu()
        {
            string result =  dataAsset.data.outputdata("ht_qlchucvu_load");
            return result;
        }

        [HttpPost]
        public JsonResult quanlychucvuThemSua(int type,chucvu cv)
        {
            string[] namepara = { "@machucvu", "@tenchucvu" };
            object[] valuepara = { cv.Machucvu, cv.Tenchucvu };
            string result = string.Empty;

            switch (type)
            {
                case 1:
                    if (dataAsset.data.inputdata("ht_qlchucvu_them", namepara, valuepara)){ result = "1"; } else { result = "-1"; }
                    break;
                case 2:
                    if (dataAsset.data.inputdata("ht_qlchucvu_sua", namepara, valuepara)){ result = "1"; } else { result = "-1"; }
                    break;
            } 
            return Json(result, JsonRequestBehavior.AllowGet);
        }





        //====== QUAN LY NGUOI DUNG ======
        public string ht_qlnguoidung_qlnguoidung_load()
        {
            return dataAsset.data.outputdata("ht_qlnguoidung_qlnguoidung_load");
        }

        public string users_coquan_load()
        {
            return dataAsset.data.outputdata("users_coquan_load");
        }

        
        public string coquanLam(string id)
        {
            string[] namepara = { "@macoquan" };
            object[] valuepara = { id };
            return dataAsset.data.outputdata("users_bophan_idcoquan",namepara,valuepara);
        }

        public string LoadNguoiDungTheoBoPhan(string id)
        {
            string[] namepara = { "@mabophan" };
            object[] valuepara = { id };
            return dataAsset.data.outputdata("ht_quanlynguoidung_loadNguoiDungTheoBoPhan", namepara, valuepara);
        }

        //them nguoi dung moi
        public JsonResult themsuanguoidung(int type,nguoidung n)
        {
            string[] namepara = { "@ID", "@USERNAME","@PASSWORD", "@EMAIL", "@HOLOT", "@TEN", "@NGAYTAO", "@KHOA", "@CHUCVU", "@BOPHAN", "@UYQUYEN", "@NGAYUQ", "@KETTHUCUQ", "@HANCHE", "@FILEANH" };
            string ngaytao = DateTime.Now.ToShortDateString();
            bool khoa = true;
            string id = dataAsset.data.RandomString(10, true);
            string pass = dataAsset.data.encryption(n.Password);
            if (n.Khoa == null){ khoa = false; } else { khoa = n.Khoa; }
            if (n.Hanche == null) { khoa = false; } else { khoa = n.Hanche; }
            object[] valuepara = { id, n.Username, pass, n.Email, n.Holot, n.Ten, ngaytao, khoa, n.Chucvu, n.Bophan, "", "", "", n.Hanche, "" };
            string result = string.Empty;
            switch (type)
            {
                case 1:
                    if (dataAsset.data.inputdata("ht_quanlynguoidung_Them", namepara, valuepara)) { result = "1"; }
                    break;
                case 2:
                    if (dataAsset.data.inputdata("ht_quanlynguoidung_Sua", namepara, valuepara)) { result = "1"; }
                    break;

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult checkUsername(string username)
        {
            string[] namepara = { "@username" };
            object[] valuepara = { username };
            DataTable dt = dataAsset.data.outputdataTable("checkUsername", namepara, valuepara);
            string result = string.Empty;
            if (dt.Rows.Count > 0)
            {
                result = "1";
            }
            else { result = "-1"; }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ht_quanlynguoidung_DoiMK(string username, string pass)
        {
            string mk = dataAsset.data.encryption(pass);
            string[] namepara = { "@username", "@password" };
            object[] valuepara = { username, mk };
            if (dataAsset.data.inputdata("ht_quanlynguoidung_DoiMK", namepara, valuepara)) { return Json("1", JsonRequestBehavior.AllowGet); }
            else { return Json("1", JsonRequestBehavior.AllowGet); }
        }

    }
}