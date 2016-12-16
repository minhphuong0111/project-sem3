using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aptech.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            /*return View("~/Views/AdminPartial/Userpage.cshtml");*/
            return View("~/Views/Admin/AdminLogin.cshtml");
        }

        public ActionResult Home()
        {
            return View("~/Views/AdminPartial/Userpage.cshtml");
        }
        public ActionResult DiemDanh()
        {
            return View("~/Views/Admin/DiemDanh.cshtml");
        }
        public ActionResult MoMonHoc()
        {
            return View("~/Views/Admin/MoMonHoc.cshtml");
        }
        public ActionResult DangKyHocLai()
        {
            return View("~/Views/Admin/dangkyhoclai.cshtml");
        }
    }
}