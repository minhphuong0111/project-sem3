using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aptech.Models.lmp
{
    public class GenerateID
    {
        public string ID { get; set; }

        public void generateID(string table)
        {
           // string lastID = "";
            int iSubID = 0 ;
           // table.ToLower();

            switch(table)
            {
                case "quanly": using(var dbContext = new StudentManagementEntities())
                    {
                        var lastID = (from p in dbContext.Quanlies
                                      orderby p.qlyID descending
                                      select p.qlyID).First();
                        ID = "QL";
                        string subID = lastID.Substring(2);
                        iSubID = Convert.ToInt32(subID);
                    }
                    break;
                case "giangvien": using (var dbContext = new StudentManagementEntities())
                    {
                        var lastID = (from p in dbContext.GiangViens
                                      orderby p.gvID descending
                                      select p.gvID).First();
                        ID = "GV";
                        string subID = lastID.Substring(2);
                        iSubID = Convert.ToInt32(subID);
                    }
                    break;
                case "sinhvien": using (var dbContext = new StudentManagementEntities())
                    {
                        var lastID = (from p in dbContext.SinhViens orderby p.svID descending select p.svID).First();
                        ID = "SV";
                        string subID = lastID.Substring(2);
                        iSubID = Convert.ToInt32(subID);
                    }
                    break;
                case "monhoc": using (var dbContext = new StudentManagementEntities())
                    {
                        var lastID = (from p in dbContext.MonHocs orderby p.mhID descending select p.mhID).First();
                        ID = "MH";
                        string subID = lastID.Substring(2);
                        iSubID = Convert.ToInt32(subID);
                    }
                    break;
                case "monhocmo": using (var dbContext = new StudentManagementEntities())
                    {
                        var lastID = (from p in dbContext.MonHocMoes
                                      orderby p.mhmID descending
                                      select p.mhmID).First();
                        ID = "MHM";
                        string subID = lastID.Substring(2);
                        iSubID = Convert.ToInt32(subID);
                    }
                    break;    
            }
            if (iSubID < 10)
            {
                ID += "00" + (iSubID + 1);
            }
            else if(iSubID <100)
            {
                ID += "0" + (iSubID + 1);
            }
            else
            {
                ID += "" + (iSubID + 1);
            }
        }

    }
}