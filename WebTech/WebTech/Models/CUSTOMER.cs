﻿//------------------------------------------------------------------------------
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
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;

    public partial class CUSTOMER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUSTOMER()
        {
            this.ORDERPROes = new HashSet<ORDERPRO>();
        }
        
        public string NAME_CUS { get; set; }
        
        public string EMAIL { get; set; }
        
        public string ADDRESS { get; set; }
        
        public string SDT { get; set; }
        
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public int ID { get; set; }
        public string IMAGE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDERPRO> ORDERPROes { get; set; }
    }
}