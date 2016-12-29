using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aptech.Models;
using PagedList;
using aptech.Models.lmp;

namespace aptech.Controllers
{
    public class GiangVienController : Controller
    {
        private StudentManagementEntities _context;

        public GiangVienController()
        {
            _context = new StudentManagementEntities();
        }
        // GET: GiangVien
        public ActionResult Index(int page = 1, int pageSize = 5, string name = "")
        {
            ViewBag.NameSearch = name;
            if (name == "")
            {
                return View(_context.GiangViens.OrderByDescending(d => d.gvID).ToPagedList(page, pageSize));
            }
            else
            {
                return View(_context.GiangViens.Where(f => f.gvTen.Contains(name)).OrderByDescending(d => d.gvID).ToPagedList(page, pageSize));
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GiangVien gv)
        {
            var function = new functionLogin();
            gv.gvMatKhau = function.hashMD5(gv.gvMatKhau);
            _context.GiangViens.Add(gv);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            var s = _context.GiangViens.First(f => f.gvID == id);
            s.gvMatKhau = "";
            return View(s);
        }

        [HttpPost]
        public ActionResult Edit(GiangVien gv)
        {
            var function = new functionLogin();
            gv.gvMatKhau = function.hashMD5(gv.gvMatKhau);
            _context.Entry(gv).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult delete(string id)
        {
            var item = _context.GiangViens.First(f => f.gvID == id);
           /* var mhm = item.MonHocMoes.ToList();
            foreach (var mhmitem in mhm)
            {
                foreach (var lt in mhmitem.LichThis.ToList())
                {
                    _context.LichThis.Remove(lt);
                }
                foreach (var svmhm in mhmitem.SinhVienMonHocs.ToList())
                {
                    foreach (var dd in svmhm.DiemDanhs.ToList())
                    {
                        _context.DiemDanhs.Remove(dd);
                    }
                    _context.SinhVienMonHocs.Remove(svmhm);
                }
                foreach (var bh in mhmitem.BuoiHocs.ToList())
                {
                    foreach (var dd in bh.DiemDanhs.ToList())
                    {
                        _context.DiemDanhs.Remove(dd);
                    }
                    _context.BuoiHocs.Remove(bh);
                }
                _context.MonHocMoes.Remove(mhmitem);
            }*/
            try
            {
                _context.GiangViens.Remove(item);
                _context.SaveChanges();
                return Json("Xoa thanh cong", JsonRequestBehavior.AllowGet);
            }
            catch (Exception) { //message
                return Json("Khong the xoa giang vien nay", JsonRequestBehavior.AllowGet);
            }
          

        }
    }
}