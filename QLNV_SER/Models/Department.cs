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
    
    public partial class Department
    {
        public string AACreate { get; set; }
        public Nullable<System.DateTime> AACreateDate { get; set; }
        public string AAStatus { get; set; }
        public Nullable<bool> AASelection { get; set; }
        public Nullable<int> AAOrder { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string FK_CompCode { get; set; }
        public Nullable<System.Guid> AAGuid { get; set; }
        public string FK_AreaCode { get; set; }
    }
}
