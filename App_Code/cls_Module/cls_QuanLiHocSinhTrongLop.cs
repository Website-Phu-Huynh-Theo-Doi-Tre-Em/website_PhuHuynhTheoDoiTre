using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_News
/// </summary>
public class cls_QuanLiHocSinhTrongLop
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_QuanLiHocSinhTrongLop()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(int txtMahocsinh, int txtTenLop, int txtNamHoc)
    {
        tbHocSinhTrongLop hs = new tbHocSinhTrongLop();
        hs.hocsinh_id = txtMahocsinh;
        hs.lop_id = txtTenLop;
        hs.namhoc_id = txtNamHoc;
        db.tbHocSinhTrongLops.InsertOnSubmit(hs);
        try
        {
            db.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool Linq_Sua(int txtMahocsinh, int txtTenLop, int txtNamHoc)
    {
       
        tbHocSinhTrongLop hs = db.tbHocSinhTrongLops.Where(x => x.hocsinh_id == txtMahocsinh).FirstOrDefault();
        hs.lop_id = txtTenLop;
        hs.namhoc_id = txtNamHoc;
        try
        {
            db.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool Linq_Xoa(int txtMahocsinh)
    {
        tbHocSinhTrongLop delete = db.tbHocSinhTrongLops.Where(x => x.hstl_id == txtMahocsinh).FirstOrDefault();
        db.tbHocSinhTrongLops.DeleteOnSubmit(delete);
        try
        {
            db.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}