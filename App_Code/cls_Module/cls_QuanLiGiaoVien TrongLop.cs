using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_News
/// </summary>
public class cls_QuanLiGiaoVienTrongLop
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_QuanLiGiaoVienTrongLop()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(int txtMaTaiKhoan, int txtNamHoc, int txtMaLop)
    {
        tbGiaoVienTrongLop hs = new tbGiaoVienTrongLop();
        hs.taikhoan_id = txtMaTaiKhoan;
        hs.namhoc_id = txtNamHoc;
        hs.lop_id = txtMaLop;
        db.tbGiaoVienTrongLops.InsertOnSubmit(hs);
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
    public bool Linq_Sua(int id, int txtMaTaiKhoan, int txtNamHoc, int txtMaLop)
    {
        tbGiaoVienTrongLop hs = db.tbGiaoVienTrongLops.Where(x => x.gvtl_id == id).FirstOrDefault();
        hs.taikhoan_id = txtMaTaiKhoan;
        hs.namhoc_id = txtNamHoc;
        hs.lop_id = txtMaLop;
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
    public bool Linq_Xoa(int news_id)
    {
        tbGiaoVienTrongLop delete = db.tbGiaoVienTrongLops.Where(x => x.taikhoan_id == news_id).FirstOrDefault();
        db.tbGiaoVienTrongLops.DeleteOnSubmit(delete);
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