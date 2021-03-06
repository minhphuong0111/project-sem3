﻿using aptech.Models;
using aptech.Models.lmp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Office.Interop;
using System.IO;
using System.Data;
using System.Data.Entity;

namespace aptech.Controllers
{
    public class MonHocController : Controller
    {
        /*
        // GET: MonHoc
        monhocModel mhModel = new monhocModel();
        public ActionResult Index()
        {
            
            return View(mhModel.layDS());
        }

        
    
        public ActionResult ThemMon()
        {
            GenerateID generID = new GenerateID();
            generID.generateID("monhoc");
            MonHoc mh = new MonHoc();
            mh.mhID = generID.ID;
            return View(mh);
        }

        [HttpPost]
        public ActionResult ThemMon(MonHoc objMonhoc)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Vui long nhap du lieu hop le";
                return View();
            }
            else
            {
                int success = monhocModel.themMon(objMonhoc);
                if (success > 0)
                {
                    var lstTK = mhModel.layDS();
                    return View("~/Views/MonHoc/Index.cshtml", lstTK);
                }
                return View(objMonhoc);
            }
        }

        //Edit
        public ActionResult SuaMon(string monID)
        {
            var obj = monhocModel.GetMonHocByID(monID);
            if (obj == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(obj);
        }

        [HttpPost]
        public ActionResult SuaMon(MonHoc objMonHoc)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Vui long nhap du lieu hop le";
                return View();
            }
            else
            {
                int success = monhocModel.EditMonHoc(objMonHoc);
                if (success > 0)
                {
                    var lstTK = mhModel.layDS();
                    return View("~/Views/MonHoc/Index.cshtml", lstTK);
                }
                return View(objMonHoc);
            }
        }

        //delete
        public ActionResult XoaMon(string monid)
        {
            var obj = monhocModel.GetMonHocByID(monid);
            if (obj == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(obj);
        }

        [HttpPost, ActionName("XoaMon")]
        public ActionResult XoaMonConfirmed(string monid)
        {
            int success = monhocModel.DeleteMonHocByID(monid);
            if (success > 0)
            {
                var lstTK = mhModel.layDS();
                return View("~/Views/MonHoc/Index.cshtml", lstTK);
            }
            return View();
        }

        //export excel
        public void exportExcel()
        {
            List<MonHoc> lstdata = mhModel.layDS();
            

            Microsoft.Office.Interop.Excel.Application xlsFile = new Microsoft.Office.Interop.Excel.Application();
            if(xlsFile == null)
            {
                //chua cai dat
            }
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlsFile.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            //gan du lieu
            int i = 1;
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", string.Format("attachment; filename=C#cornerVithalWadje.xls")); 
            foreach(MonHoc p in lstdata)
            {
                /*
                xlWorkSheet.Cells[i, 1] = p.mhID;
                xlWorkSheet.Cells[i, 2] = p.mhTen;
                i++;
                 * */
   //             Response.Write(p.mhID + "\t");
   //             Response.Write(p.mhTen + "\n");
   //         }
   //         Response.End();  
            /*
            using(MemoryStream MyMemoryStream = new MemoryStream())
                        {
                            xlWorkBook.SaveAs(MyMemoryStream);
                            MyMemoryStream.WriteTo(Response.OutputStream);
                            Response.Flush();
                            Response.End();
                        }
            */
            
   //     }
        StudentManagementEntities _context = new StudentManagementEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult layMonHoc()
        {
            var monhoc = from MonHocs in _context.MonHocs
                         select new
                         {
                             mhID = MonHocs.mhID,
                             mhTen = MonHocs.mhTen
                         };
            return Json(monhoc, JsonRequestBehavior.AllowGet);
        }

        public ActionResult layMonHocID(string id)
        {
            var monhoc = from MonHocs in _context.MonHocs
                         where MonHocs.mhID == id
                         select new
                         {
                             mhID = MonHocs.mhID,
                             mhTen = MonHocs.mhTen
                         };
            return Json(monhoc, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult themMH(MonHoc mh)
        {
            if(ModelState.IsValid)
            {
                _context.MonHocs.Add(mh);
                _context.SaveChanges();
            }
            return Json(mh, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult suaMH(MonHoc mh)
        {
            if(ModelState.IsValid)
            {
                _context.Entry(mh).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return Json(mh, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult xoaMH(string id)
        {
            var mh = _context.MonHocs.ToList().Find(m => m.mhID == id);
            if(mh != null)
            {
                _context.MonHocs.Remove(mh);
                _context.SaveChanges();
            }
            return Json(mh, JsonRequestBehavior.AllowGet);
        }

    }
     
}