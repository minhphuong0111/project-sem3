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
    
    public partial class LichThi
    {
        public string ltID { get; set; }
        public string mhmID { get; set; }
        public Nullable<System.DateTime> ngaythi { get; set; }
        public Nullable<int> lanthi { get; set; }
    
        public virtual MonHocMo MonHocMo { get; set; }
    }
}
