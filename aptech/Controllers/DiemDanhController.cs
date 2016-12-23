using aptech.Models;
using aptech.Models.lmp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aptech.Controllers
{
    public class DiemDanhController : Controller
    {
        functionDiemDanh ddModel = new functionDiemDanh();
        private StudentManagementEntities _context = new StudentManagementEntities();
        // GET: DiemDanh
        public ActionResult Index()
        {
            
            ddModel.getMHbyGV(Session["user"].ToString());
            ViewBag.lstmhm = ddModel.lstmhm;

            return View();
        }

        public ActionResult lstSV(string mhmID)
        {
            List<SinhVien> lstSV = new List<SinhVien>();

            var query = 
            from svmh in _context.SinhVienMonHocs
            where
              svmh.mhmID == mhmID
            select new {
              svID = svmh.SinhVien.svID,
              svMatKhau = svmh.SinhVien.svMatKhau,
              svTen = svmh.SinhVien.svTen,
              svGioiTinh = svmh.SinhVien.svGioiTinh,
              svBirhday = svmh.SinhVien.svBirhday,
              svDiaChi = svmh.SinhVien.svDiaChi,
              svDienThoai = svmh.SinhVien.svDienThoai,
              lopID = svmh.SinhVien.lopID,
              svNghiHoc = svmh.SinhVien.svNghiHoc
            };
        
            return Json(query, JsonRequestBehavior.AllowGet);
        }
    }
}