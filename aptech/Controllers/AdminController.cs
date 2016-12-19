using aptech.Models.lmp;
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
        
        
        public ActionResult Index(int id, string passdata)
        {
            
            /*return View("~/Views/AdminPartial/Userpage.cshtml");*/
            ViewBag.loi = passdata;
            return View("~/Views/Admin/AdminLogin.cshtml");
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult ktrDangNhap(string user, string pass, string chkgv)
        {
            // string usr = Convert.ToString(Request["user"]);
            //  string pwd = Convert.ToString(Request["pass"]);
            //  bool isGv = (Convert.ToBoolean(Request["chkgv"]) == true ? true : false);
            bool isGV = false;
            string sLoi = "";
            
            if(user.TrimStart() == "" || pass.TrimStart() == "")
            {
                sLoi = "Tên đăng nhập và mật khẩu không được trống";
                return RedirectToAction("Index", "Admin", new { id = 0, passdata = sLoi });
            }
            else if (chkgv != null) isGV = true;
            {
                functionLogin fncLogin = new functionLogin();
                bool ktra = fncLogin.checkDB(isGV, user, pass);
                if (ktra)
                {
                    Session["user"] = user;
                    return RedirectToAction("Home", "Admin");
                }
                else
                {
                    sLoi = "Sai tên đăng nhập hoặc mật khẩu";
                    
                }
            }


            return RedirectToAction("Index", "Admin", new { id = 0 , passdata = sLoi });
        }

        public ActionResult Home()
        {
            if(Session["user"] == null)
            {
                return RedirectToAction("Index", "Admin");
            }

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