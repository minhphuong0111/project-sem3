//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace aptech.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BuoiHoc
    {
        public BuoiHoc()
        {
            this.DiemDanhs = new HashSet<DiemDanh>();
        }
    
        public string bhID { get; set; }
        public string mhmID { get; set; }
        public int buoi { get; set; }
        public Nullable<System.DateTime> bhNgay { get; set; }
    
        public virtual MonHocMo MonHocMo { get; set; }
        public virtual ICollection<DiemDanh> DiemDanhs { get; set; }
    }
}
