//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PropertyManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Property_Status
    {
        public Property_Status()
        {
            this.Properties = new HashSet<Property>();
        }
    
        public int ID { get; set; }
        public string Property_Status_Name { get; set; }
    
        public virtual ICollection<Property> Properties { get; set; }
    }
}
