using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aptech.Models.lmp
{
    public class functionDiemDanh
    {
        //ma giao vien: session
        public List<LopHoc> lstLopHoc { get; set; }
        public List<MonHoc> lstMonHoc { get; set; }
        public List<MonHocMo> lstMHM { get; set; }
        public List<SinhVien> lstSinhVien { get; set; }
        public List<string> lstsv { get; set; }
        public List<string> lstmhm { get; set; }
        public List<string> lstlh { get; set; }

        public void getLstLH(string gvID)
        {
            using(var dbContext = new StudentManagementEntities())
            {
                lstMHM = (from p in dbContext.MonHocMoes
                            where p.gvID == gvID
                            select p).ToList();
                foreach(MonHocMo mhm in lstMHM)
                {
                    lstmhm.Add(mhm.mhmID);
                }
                lstsv = (from svmh in dbContext.SinhVienMonHocs
                             where lstmhm.Contains(svmh.mhmID)
                             select svmh.svID).Distinct().ToList();

                lstlh = (from sv in dbContext.SinhViens
                         where lstsv.Contains(sv.svID)
                         select sv.lopID).Distinct().ToList();

            }

        }
        /*
        public void getLstMHM(string lhID)
        {
            using(var dbContext = new StudentManagementEntities())
            {
                string firstsv = (from p in dbContext.SinhViens
                               where p.lopID == lhID
                               select p.svID).First();
                //lstMHM = (from )
            }
        }
         * */
        public void getMHbyGV(string gvID)
        {
            using(var dbContext = new StudentManagementEntities())
            {
                lstmhm = (from p in dbContext.MonHocMoes
                             where p.gvID == gvID && p.ketthuc == false
                             select p.mhmID).ToList();
                
            }
        }
        
        public void getLstSV(string mhmSelected)
        {
            lstSinhVien = new List<SinhVien>();
            using (var dbContext = new StudentManagementEntities())
            {

                lstsv = (from p in dbContext.SinhVienMonHocs
                         where p.mhmID == mhmSelected
                         select p.svID).ToList();
                foreach(string sv in lstsv)
                {
                    lstSinhVien.Add((from isv in dbContext.SinhViens where isv.svID == sv select isv).FirstOrDefault());
                }
            }
        }
    }
}