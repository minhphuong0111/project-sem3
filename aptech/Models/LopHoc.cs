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
    
    public partial class LopHoc
    {
        public LopHoc()
        {
            this.SinhViens = new HashSet<SinhVien>();
        }
    
        public string lopID { get; set; }
        public string ctID { get; set; }
    
        public virtual ChuongTrinhHoc ChuongTrinhHoc { get; set; }
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}