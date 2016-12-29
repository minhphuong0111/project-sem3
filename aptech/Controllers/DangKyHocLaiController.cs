using aptech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aptech.Controllers
{
    public class DangKyHocLaiController : Controller
    {

        private aptech.Models.StudentManagementEntities _context;

        public DangKyHocLaiController()
        {
            _context = new Models.StudentManagementEntities();
        }
        // GET: DangKyHocLai
        public ActionResult Index()
        {
            ViewBag.MHM = _context.MonHocMoes.ToList();
            return View();
        }

        public ActionResult GetMonHoc(string id)
        {
            var mh = _context.MonHocMoes.First(f => f.mhmID == id);
            string ngay = mh.ngayBatDau.Value.Day + "/" + mh.ngayBatDau.Value.Month + "/" + mh.ngayBatDau.Value.Year;
            DangKyHoLaiViewModel view = new DangKyHoLaiViewModel() { GV = mh.GiangVien.gvTen, TGH = ngay, GH = mh.giohoc };
            return Json(view, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DangKy(string idmhm)
        {
            Session["user"] = "SV0001";
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "DangkyHocLai");
            }
            else
            {
                string username = Session["user"].ToString();
                //var userhientai = _context.SinhViens.First(f => f.svID == username);
                var svm = _context.SinhVienMonHocs.Where(f => f.svID == username && f.ketqua == true && f.mhmID == idmhm).ToList();
                if (svm.Count > 0)
                {
                    ViewBag.TB = "Ban da dau mon hoc nay!";
                    ViewBag.MHM = _context.MonHocMoes.ToList();
                    return View("Index");
                }
                else
                {
                    var svmh = new SinhVienMonHoc() { mhmID = idmhm, svID = username };
                    _context.SinhVienMonHocs.Add(svmh);
                    _context.SaveChanges();
                    ViewBag.TB = "Dang ky thanh cong!";
                    ViewBag.MHM = _context.MonHocMoes.ToList();
                    return View("Index");
                }
            }
        }

        public ActionResult Dangky()
        {
            return RedirectToAction("Index");
        }
    }
}