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
    
    public partial class GiangVien
    {
        public GiangVien()
        {
            this.MonHocMoes = new HashSet<MonHocMo>();
        }
    
        public string gvID { get; set; }
        public string gvTen { get; set; }
        public bool gvGioiTinh { get; set; }
        public Nullable<System.DateTime> gvNgaySinh { get; set; }
        public string gvDiaChi { get; set; }
        public string gvDienThoai { get; set; }
        public string gvMatKhau { get; set; }
        public Nullable<System.DateTime> gvThoiViec { get; set; }
    
        public virtual ICollection<MonHocMo> MonHocMoes { get; set; }
    }
}
