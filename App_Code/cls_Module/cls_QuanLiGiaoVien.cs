using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_News
/// </summary>
public class cls_QuanLiGiaoVien
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_QuanLiGiaoVien()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(string txtTenGiaoVien, int txtMaKhoi, int txtMaTaiKhoan)
    {
        tbGiaoVien hs = new tbGiaoVien();
        hs.giaovien_name = txtTenGiaoVien;
        hs.khoi_id = txtMaKhoi;
        hs.username_id = txtMaTaiKhoan;
        db.tbGiaoViens.InsertOnSubmit(hs);
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
    public bool Linq_Sua(int id, string txtTenGiaoVien, int txtMaKhoi, int txtMaTaiKhoan)
    {
        tbGiaoVien hs = db.tbGiaoViens.Where(x => x.giaovien_id == id).FirstOrDefault();
        hs.giaovien_name = txtTenGiaoVien;
        hs.khoi_id = txtMaKhoi;
        hs.username_id = txtMaTaiKhoan;
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
        tbGiaoVien delete = db.tbGiaoViens.Where(x => x.giaovien_id == news_id).FirstOrDefault();
        db.tbGiaoViens.DeleteOnSubmit(delete);
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