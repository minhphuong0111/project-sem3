using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aptech.Models.lmp
{
    public class monhocModel
    {
        public List<MonHoc> layDS()
        {
            using (var dbContext = new StudentManagementEntities())
            {
                var data = (from p in dbContext.MonHocs
                            select p).ToList();
                return data;
            }
        }

        public static int themMon(MonHoc objMonHoc)
        {
            using (StudentManagementEntities objQuanLy = new StudentManagementEntities())
            {
                objQuanLy.MonHocs.Add(objMonHoc);
                return objQuanLy.SaveChanges();
            }
        }

        public static int EditMonHoc(MonHoc objMonHoc)
        {
            using (StudentManagementEntities context = new StudentManagementEntities())
            {
                var obj = context.MonHocs.FirstOrDefault(p => p.mhID == objMonHoc.mhID);
                if (obj != null)
                {
                    obj.mhTen = objMonHoc.mhTen;
                }
                return context.SaveChanges();
            }
        }

        public static MonHoc GetMonHocByID(string id)
        {
            using (StudentManagementEntities context = new StudentManagementEntities())
            {
                var obj = context.MonHocs.FirstOrDefault(p => p.mhID == id);
                return obj;
            }
        }

        public static int DeleteMonHocByID(string id)
        {
            using (StudentManagementEntities context = new StudentManagementEntities())
            {
                var obj = context.MonHocs.FirstOrDefault(p => p.mhID == id);

                context.MonHocs.Remove(obj);
                return context.SaveChanges();

            }
        }
    }
}