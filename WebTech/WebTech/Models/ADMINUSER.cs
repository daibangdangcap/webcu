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
    
    public partial class ADMINUSER
    {
        public int ID { get; set; }
        public string USER_AD { get; set; }
        public string NAME { get; set; }
        public string PASSWORD_AD { get; set; }
        public string ROLLUSER { get; set; }
    
        public virtual ROLEUSER ROLEUSER { get; set; }
    }
}
