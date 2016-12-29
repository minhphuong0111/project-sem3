using aptech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace aptech.Controllers
{
    public class GiaoVuController : Controller
    {
        // GET: GiaoVu
        private StudentManagementEntities _context;
        public GiaoVuController()
        {
            _context = new StudentManagementEntities();
        }

        public ActionResult Index(int page = 1, int pageSize = 2, string name = "")
        {
            ViewBag.Name = name;
            if (name == "")
            {
                return View(_context.Quanlies.OrderByDescending(d => d.qlyID).ToPagedList(page, pageSize));
            }
            else
            {
                return View(_context.Quanlies.Where(f => f.qlyTen.Contains(name)).OrderByDescending(d => d.qlyID).ToPagedList(page, pageSize));
            }
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Quanly ql)
        {
            _context.Quanlies.Add(ql);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            return View(_context.Quanlies.First(f => f.qlyID == id));
        }

        [HttpPost]
        public ActionResult Edit(Quanly ql)
        {
            _context.Entry(ql).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult delete(string id)
        {
            var item = _context.Quanlies.First(f => f.qlyID == id);
            _context.Quanlies.Remove(item);
            _context.SaveChanges();
            return Json(item, JsonRequestBehavior.AllowGet);
        }
    }
}