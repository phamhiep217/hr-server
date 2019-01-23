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
    
    public partial class Emp
    {
        public int EmpID { get; set; }
        public string EmpTimekeepCode { get; set; }
        public string EmpTimekeepName { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public Nullable<int> EmpGender { get; set; }
        public string EmpAddress1 { get; set; }
        public string EmpAddress2 { get; set; }
        public string EmpAddress3 { get; set; }
        public string EmpPhone1 { get; set; }
        public string EmpPhone2 { get; set; }
        public Nullable<System.DateTime> EmpBirth { get; set; }
        public string EmpBirthPlace { get; set; }
        public string EmpIDCard { get; set; }
        public string EmpNationality { get; set; }
        public string EmpEthnic { get; set; }
        public string EmpDegree { get; set; }
        public string EmpIDCardPlace { get; set; }
        public Nullable<System.DateTime> EmpIDCardDate { get; set; }
        public string EmpEmail { get; set; }
        public string EmpType { get; set; }
        public string EmpStatus { get; set; }
        public string EmpNote { get; set; }
        public Nullable<System.DateTime> EmpWorkBeginDate { get; set; }
        public Nullable<System.DateTime> EmpWorkEndDate { get; set; }
        public string FK_DeptCode { get; set; }
        public string FK_CompCode { get; set; }
        public string FK_PositionCode { get; set; }
        public string FK_PositionName { get; set; }
        public Nullable<int> FK_UserID { get; set; }
        public Nullable<double> EmpAnnualLeave { get; set; }
        public Nullable<decimal> EmpSalary { get; set; }
        public Nullable<decimal> EmpSalaryContract { get; set; }
        public Nullable<decimal> EmpSalaryIns { get; set; }
        public byte[] EmpImg { get; set; }
        public string AACreate { get; set; }
        public Nullable<System.DateTime> AACreateDate { get; set; }
        public string AAStatus { get; set; }
        public Nullable<bool> AASelection { get; set; }
        public Nullable<System.Guid> AAGuid { get; set; }
        public string FK_AreaCode { get; set; }
        public Nullable<System.DateTime> EmpIDCardDateExp { get; set; }
        public string EmpPathImg { get; set; }
        public Nullable<int> FK_DeptID { get; set; }
        public Nullable<int> FK_CompID { get; set; }
        public Nullable<int> FK_PositionID { get; set; }
        public string FK_AreaID { get; set; }
        public Nullable<int> FK_MarriageID { get; set; }
        public Nullable<int> FK_ReligionID { get; set; }
    }
}
