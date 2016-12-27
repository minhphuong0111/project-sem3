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
        string mhmDD { get; set; }
        int bhinsert { get; set; }
        List<string> dssv = new List<string>();
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
            mhmDD = mhmID;
            Session["mhm"] = mhmID;
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
            foreach(var svinfo in query)
            {
                dssv.Add(svinfo.svID);
            }
            return Json(query, JsonRequestBehavior.AllowGet);
        }

        private bool themBuoiHoc()
        {
            
            BuoiHoc bh = new BuoiHoc();
            bh.mhmID = Session["mhm"].ToString();
            bh.bhNgay = ViewBag.ngaythang;
            _context.BuoiHocs.Add(bh);
            int kt = _context.SaveChanges();
            if(kt==0)
            {
                return false;
            }
            else
            {
                //lay buoi hoc id
                bhinsert = (from bh1 in _context.BuoiHocs
                            orderby bh1.bhID descending
                            select bh1.bhID).First();
                return true;

            }         
        }
        [HttpPost]
        public ActionResult guiDiemDanh(dynamic id)
        {
            themBuoiHoc();
            List<List<string>> diemdanhData = new List<List<string>>();
            
            int loop = dssv.Count();
            

            for (int i = 0; i < loop; i++ )
            {
                if(id[i][0] == "cp")
                {
                    DiemDanh ddEntities = new DiemDanh();
                    ddEntities.bhID = bhinsert;
                    ddEntities.svmhID = (from svmh1 in _context.SinhVienMonHocs
                                         where svmh1.mhmID == mhmDD && svmh1.svID == dssv[i]
                                         select svmh1.svmhID).First();
                    ddEntities.vang = 2;
                    ddEntities.lydo = id[i][1];
                    _context.DiemDanhs.Add(ddEntities);
                    _context.SaveChanges();
                }
                else
                {
                    if (id[i][0] == "kp")
                    {
                        DiemDanh ddEntities = new DiemDanh();
                        ddEntities.bhID = bhinsert;
                        ddEntities.svmhID = (from svmh1 in _context.SinhVienMonHocs
                                             where svmh1.mhmID == mhmDD && svmh1.svID == dssv[i]
                                             select svmh1.svmhID).First();
                        ddEntities.vang = 1;
                        ddEntities.lydo = "";
                        _context.DiemDanhs.Add(ddEntities);
                        _context.SaveChanges();
                    }
                    else if(id[i][0] == "cm")
                    {
                        DiemDanh ddEntities = new DiemDanh();
                        ddEntities.bhID = bhinsert;
                        ddEntities.svmhID = (from svmh1 in _context.SinhVienMonHocs
                                             where svmh1.mhmID == mhmDD && svmh1.svID == dssv[i]
                                             select svmh1.svmhID).First();
                        ddEntities.vang = 0;
                        ddEntities.lydo = "";
                        _context.DiemDanhs.Add(ddEntities);
                        _context.SaveChanges();
                    }
                }
            }

            return RedirectToAction("Index");

            
        }
    }
}