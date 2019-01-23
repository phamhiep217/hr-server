using QLNV_SER.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using QLNV_SER.Models;

namespace QLNV_SER.BUS
{
    public class NhanVienAccess
    {
        string maNV;
        string tenNV;
        string maChamCong;
        string tenChamCong;
        int gioiTinh;
        string maCty;
        string maKhuVuc;
        string maPhongBan;
        bool nghiViec;

        public string MaNV
        {
            get
            {
                return maNV;
            }

            set
            {
                maNV = value;
            }
        }
        public string TenNV
        {
            get
            {
                return tenNV;
            }

            set
            {
                tenNV = value;
            }
        }
        public string MaChamCong
        {
            get
            {
                return maChamCong;
            }

            set
            {
                maChamCong = value;
            }
        }
        public string TenChamCong
        {
            get
            {
                return tenChamCong;
            }

            set
            {
                tenChamCong = value;
            }
        }
        public int GioiTinh
        {
            get
            {
                return gioiTinh;
            }

            set
            {
                gioiTinh = value;
            }
        }
        public string MaCty
        {
            get
            {
                return maCty;
            }

            set
            {
                maCty = value;
            }
        }
        public string MaKhuVuc
        {
            get
            {
                return maKhuVuc;
            }

            set
            {
                maKhuVuc = value;
            }
        }
        public string MaPhongBan
        {
            get
            {
                return maPhongBan;
            }

            set
            {
                maPhongBan = value;
            }
        }
        public bool NghiViec
        {
            get
            {
                return nghiViec;
            }

            set
            {
                nghiViec = value;
            }
        }
    }
    public class ChamCong
    {
        private HumanResourceEntities db = new HumanResourceEntities();
        public ChamCong() { }

        public List<NhanVienAccess> GetChamCongByAccess()
        {
            DataTable dt = new DataTable();
            int iCode = GetMaxTimekeepCode();
            string strQuery = String.Format("select * from NhanVien where MaChamCong > {0}", iCode);
            dt = DataProvider.Instance.ExecuteQuery(strQuery);
            List<NhanVienAccess> lstNV = new List<NhanVienAccess>();
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    NhanVienAccess nv = new NhanVienAccess();
                    nv.MaNV = dr["MaNhanVien"].ToString();
                    nv.TenNV = dr["TenNhanVien"].ToString();
                    nv.MaChamCong = dr["MaChamCong"].ToString();
                    nv.TenChamCong = dr["TenChamCong"].ToString();
                    // nv.GioiTinh = dr["GioiTinh"];
                    bool gt = Convert.ToBoolean(dr["GioiTinh"]);
                    if (gt)
                        nv.GioiTinh = 1;
                    else
                        nv.GioiTinh = 0;
                    nv.MaCty = dr["MaCongTy"].ToString();
                    nv.MaKhuVuc = dr["MaKhuVuc"].ToString();
                    nv.MaPhongBan = dr["MaPhongBan"].ToString();
                    nv.NghiViec = Convert.ToBoolean(dr["NghiViecTamThoi"]);
                    lstNV.Add(nv);
                }
            }
            return lstNV;
        }

        public int GetMaxTimekeepCode()
        {
            int iCode = 0;
            try
            {
                var maxCode = db.Emps.Max(x => x.EmpTimekeepCode);
                iCode = Int32.Parse(maxCode);
                return iCode;
            }
            catch { return iCode;}  
        }

        public void ImportAcToEmp()
        {
            List<NhanVienAccess> lstNV = new List<NhanVienAccess>();
            lstNV = GetChamCongByAccess();
            if (lstNV !=null && lstNV.Count > 0)
            {
                foreach (NhanVienAccess nv in lstNV)
                {
                    Emp objEmp = new Emp();
                    objEmp.AACreate = System.Environment.MachineName;
                    objEmp.AACreateDate = DateTime.Today;
                    objEmp.AASelection = false;
                    objEmp.AAStatus = Util.strAAStatusActive;
                    objEmp.AAGuid = Guid.NewGuid();
                    objEmp.EmpCode = nv.MaNV;
                    objEmp.EmpName = nv.TenNV;
                    objEmp.EmpTimekeepCode = nv.MaChamCong;
                    objEmp.EmpTimekeepName = nv.TenChamCong;
                    objEmp.FK_CompCode = nv.MaCty;
                    objEmp.FK_DeptCode = nv.MaPhongBan;
                    objEmp.FK_AreaCode = nv.MaKhuVuc;
                    objEmp.EmpGender = nv.GioiTinh;
                    if (nv.NghiViec)
                        objEmp.EmpStatus = Util.strStatusNghiViec ;
                    else
                        objEmp.EmpStatus = Util.strStatusLamViec ;
                    db.Emps.Add(objEmp);
                }
                    db.SaveChanges();
            }
        }

    }
}