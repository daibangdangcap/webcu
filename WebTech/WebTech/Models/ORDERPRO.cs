//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebTech.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ORDERPRO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDERPRO()
        {
            this.ORDERDETAILs = new HashSet<ORDERDETAIL>();
        }
    
        public int ID_ORDER { get; set; }
        public string USERNAME { get; set; }
        public string SDT { get; set; }
        public string ORDER_ADDRESS { get; set; }
        public Nullable<System.DateTime> DATEORDER { get; set; }
        public string NAMECUSTOMER { get; set; }
        public Nullable<decimal> PRICE { get; set; }
    
        public virtual CUSTOMER CUSTOMER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDERDETAIL> ORDERDETAILs { get; set; }
    }
}