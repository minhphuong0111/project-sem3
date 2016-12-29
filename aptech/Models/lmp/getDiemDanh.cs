using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aptech.Models.lmp
{
    public class lstDiemDanh
    {
        public string trangthai { get; set; }
        public string lydo { get; set; }
        
    }
    public class ttDiemDanh
    {
        public List<lstDiemDanh> dsDiemDanh { get; set; }
        public ttDiemDanh(lstDiemDanh info)
        {
            dsDiemDanh.Add(info);
        }
    }
}