//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PTStoreManager2020.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MauHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MauHang()
        {
            this.Hangs = new HashSet<Hang>();
            this.NhomHangs = new HashSet<NhomHang>();
        }
    
        public string MaMH { get; set; }
        public string TenMH { get; set; }
        public string DonVi { get; set; }
        public string Anh { get; set; }
        public string ChuThich { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hang> Hangs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhomHang> NhomHangs { get; set; }
    }
}
