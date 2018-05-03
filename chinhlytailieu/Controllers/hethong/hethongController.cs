﻿using chinhlytailieu.Helper;
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
                List<coquan> cq = ht_qlphongban_LoadCoQuan();
                return View(cq);
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
            
        }

        public PartialViewResult phongcon(string id)
        {
            List<coquan> cq = ht_quanlyphong_loadcoquancon(id);
            ViewBag.Count = cq.Count();
            return PartialView("phongcon", cq);
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
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "quanlyloaihinhkhaithac"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }
        public ActionResult phanquyenxulyquytrinh()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "phanquyenxulyquytrinh"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }

        //cauhinhhethong
        public ActionResult cauhinhdangnhap()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "cauhinhdangnhap"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }
        public ActionResult cauhinhkhac()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "cauhinhkhac"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }
        public ActionResult cauhinhvitriluutru()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "cauhinhvitriluutru"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }

        public ActionResult backupcosodulieu()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "backupcosodulieu"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }

        //nhatky
        public ActionResult nhatkyhethong()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "nhatkyhethong"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }
        public ActionResult nhatkythaydoitailieu()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "nhatkythaydoitailieu"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }
        public ActionResult nhatkydocgia()
        {
            if (Helper.phanquyen.checkUrlUser(Session["username"].ToString(), "nhatkydocgia"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("ERROR_502", "error");
            }
        }


//============ QUAN LY NGUOI DUNG ===========

        //====== QUAN LY PHONG BAN ======
        public List<coquan> ht_qlphongban_LoadCoQuan()
        {
            List<coquan> cq = new List<coquan>();
            DataTable dt = dataAsset.data.outputdataTable("ht_qlphongban_LoadCoQuan");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["CQQUANLY"].ToString() == "")
                {
                    coquan cquan = new coquan();
                    cquan.Macoquan = dt.Rows[i]["MACOQUAN"].ToString();
                    cquan.Tencoquan = dt.Rows[i]["TENCOQUAN"].ToString();
                    cq.Add(cquan);
                }
            }
            return cq;
        }

        public List<coquan> ht_quanlyphong_loadcoquancon(string cqquanly)
        {
            string[] namepara = { "@cqquanly" };
            object[] valuepara = { cqquanly };

            List<coquan> cq = new List<coquan>();
            DataTable dt = dataAsset.data.outputdataTable("ht_quanlyphong_loadcoquancon", namepara, valuepara);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                coquan cquan = new coquan();
                cquan.Macoquan = dt.Rows[i]["MACOQUAN"].ToString();
                cquan.Tencoquan = dt.Rows[i]["TENCOQUAN"].ToString();
                cq.Add(cquan);
            }
            return cq;
        }

        public JsonResult ht_qlphongban_LoadCoQuanJson()
        {
            List<coquan> cq = new List<coquan>();
            DataTable dt = dataAsset.data.outputdataTable("ht_qlphongban_LoadCoQuan");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["CQQUANLY"].ToString() == "")
                {
                    coquan cquan = new coquan();
                    cquan.Macoquan = dt.Rows[i]["MACOQUAN"].ToString();
                    cquan.Tencoquan = dt.Rows[i]["TENCOQUAN"].ToString();
                    cq.Add(cquan);
                }
            }
            return Json(cq, JsonRequestBehavior.AllowGet);
        }

        public string ht_quanlyphong_loadBoPhanTheoCoQuan(string madonvi)
        {
            string[] namepara = { "@madonvi" };
            object[] valuepara = { madonvi };
            return dataAsset.data.outputdata("ht_quanlyphong_loadBoPhanTheoCoQuan", namepara, valuepara);
        }

        public JsonResult ht_qlphongban_them_sua(int type,bophan phong)
        {
            string[] namepara = { "@maphong", "@tenphong", "@dvquanly", "@madonvi" };
            if (phong.Dvquanly == null) { phong.Dvquanly = ""; }
            object[] valuepara = { phong.Maphong, phong.Tenphong, phong.Dvquanly, phong.Madonvi };
            
            string result = string.Empty;

            switch (type)
            {
                case 1:
                    if (dataAsset.data.inputdata("ht_qlphongban_them", namepara, valuepara)) { result = "1"; } else { result = "-1"; }
                    break;
                case 2:
                    if (dataAsset.data.inputdata("ht_qlphongban_sua", namepara, valuepara)) { result = "1"; } else { result = "-1"; }
                    break;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
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

        public JsonResult ht_quanlynguoidung_Khoa(string username, int khoa)
        {
            string[] namepara = { "@username", "@khoa" };
            object[] valuepara = { username, khoa };
            if (dataAsset.data.inputdata("ht_quanlynguoidung_Khoa", namepara, valuepara)) { return Json("1", JsonRequestBehavior.AllowGet); }
            else { return Json("1", JsonRequestBehavior.AllowGet); }
        }


        //====== QUAN LY NHOM NGUOI DUNG ======
        public string ht_qlnhomnguoidung_Load()
        {
            return dataAsset.data.outputdata("ht_qlnhomnguoidung_Load");
        }

        public string ht_qlnhomnguoidung_LoadDSTaikhoan(string manhom)
        {
            string[] namepara = { "@manhom" };
            object[] valuepara = { manhom };
            return dataAsset.data.outputdata("ht_qlnhomnguoidung_LoadDSTaikhoan", namepara, valuepara);
        }

        public JsonResult ht_qlnhomnguoidung_ThemSua(int type, nhom n)
        {
            string[] namepara = { "@MANHOM", "@TENNHOM" };
            object[] valuepara = { n.Manhom, n.Tennhom };
            string result = string.Empty;
            switch (type)
            {
                case 1:
                    if (dataAsset.data.inputdata("ht_qlnhomnguoidung_Them", namepara, valuepara)) { result = "1"; }
                    else { result = "-1"; }
                    break;
                case 2:
                    if (dataAsset.data.inputdata("ht_qlnhomnguoidung_Sua", namepara, valuepara)) { result = "1"; }
                    else { result = "-1"; }
                    break;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //check ma nhom ton tai
        public JsonResult ht_qlnhomnguoidung_CheckMaNhom(string manhom)
        {
            string[] namepara = { "@manhom" };
            object[] valuepara = { manhom };
            DataTable dt = dataAsset.data.outputdataTable("ht_qlnhomnguoidung_CheckMaNhom", namepara, valuepara);
            if (dt.Rows.Count > 0) { return Json("1", JsonRequestBehavior.AllowGet); }
            else { return Json("-1", JsonRequestBehavior.AllowGet); }
        }

        public JsonResult ht_qlnhomnguoidung_themnguoidungvaonhom(string[] username, string manhom)
        {
            // check nguoi dung co thuoc nhom hay chua
            string result = "1";
            for (int i = 0; i < username.Length; i++)
            {
                string[] namepara = { "@username", "@manhom" };
                object[] valuepara = { username[i], manhom };
                DataTable dt = dataAsset.data.outputdataTable("ht_qlnhomnguoidung_Checknguoidungthuocnhom", namepara, valuepara);
                if (dt.Rows.Count == 0)
                {
                    string[] namepara2 = { "@manhom", "@username" };
                    object[] valuepara2 = { manhom, username[i] };
                    if (dataAsset.data.inputdata("ht_qlnhomnguoidung_themnguoidungvaonhom", namepara2, valuepara2))
                        result = "1"; // them thanh cong
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public string ht_qlnhomnguoidung_loadnguoidung_bophan_thuocnhomnguoidung(string maphong, string manhom)
        {
            string[] namepara = { "@maphong", "@manhom" };
            object[] valuepara = { maphong, manhom };
            return dataAsset.data.outputdata("ht_qlnhomnguoidung_loadnguoidung_bophan_thuocnhomnguoidung", namepara, valuepara);
        }

    
        public JsonResult ht_qlnhomnguoidung_Loaibo(string username)
        {
            string[] namepara = { "@username" };
            object[] valuepara = { username };
            if (dataAsset.data.inputdata("ht_qlnhomnguoidung_Loaibo", namepara, valuepara)) { return Json("1", JsonRequestBehavior.AllowGet); }
            else { return Json("-1", JsonRequestBehavior.AllowGet); }
        }


    }
}