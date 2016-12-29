using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aptech.Models;

namespace aptech.Controllers
{
    public class MonHocMoController : Controller
    {

        private StudentManagementEntities _context;

        public MonHocMoController()
        {
            _context = new StudentManagementEntities();
        }
        // GET: MonHocMo
        public ActionResult Index()
        {
            return View(_context.MonHocMoes.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.MonHoc = _context.MonHocs.ToList();
            ViewBag.Gv = _context.GiangViens.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(MonHocMo mhm)
        {
            _context.MonHocMoes.Add(mhm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            ViewBag.MonHoc = _context.MonHocs.ToList();
            ViewBag.Gv = _context.GiangViens.ToList();
            return View(_context.MonHocMoes.First(c => c.mhmID == id));
        }

        [HttpPost]
        public ActionResult Edit(MonHocMo mh)
        {
            _context.Entry(mh).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}