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
    
    public partial class DiemDanh
    {
        public int bhID { get; set; }
        public int svmhID { get; set; }
        public Nullable<int> vang { get; set; }
        public string lydo { get; set; }
    
        public virtual BuoiHoc BuoiHoc { get; set; }
        public virtual SinhVienMonHoc SinhVienMonHoc { get; set; }
    }
}
