//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLNV_SER.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AllowanceSub
    {
        public Nullable<int> FK_AllowanceID { get; set; }
        public Nullable<int> FK_EmpID { get; set; }
        public int AllowanceSubID { get; set; }
        public Nullable<decimal> AllowanceSubSalary { get; set; }
        public Nullable<System.Guid> AAGuid { get; set; }
    }
}