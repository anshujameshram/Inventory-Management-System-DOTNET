//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AOrder
    {
        public int id { get; set; }
        public string ordname { get; set; }
        public Nullable<int> qty { get; set; }
        public Nullable<System.DateTime> orddate { get; set; }
        public Nullable<System.DateTime> duedate { get; set; }
        public Nullable<int> cust_id { get; set; }
        public string status { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> item_id { get; set; }
    
        public virtual ACustomer ACustomer { get; set; }
        public virtual Anshuja Anshuja { get; set; }
        public virtual AItem AItem { get; set; }
    }
}
