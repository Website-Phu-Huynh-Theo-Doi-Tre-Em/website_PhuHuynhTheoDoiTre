using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Slide
/// </summary>
public class cls_NhanVienThuViec
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_NhanVienThuViec()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    
    public bool Sua_NhanVienThuViec(int hosothuviec_id, string ngaybatdau, string ngayketthuc, string sohdtv )
    {

        tbQuanLyNhanSu_HopDongThuViec update = db.tbQuanLyNhanSu_HopDongThuViecs.Where(x => x.hopdongthuviec_id == hosothuviec_id).FirstOrDefault();
        //update.slidecate_id = slidecate;
        update.hopdongthuviec_ngaythangnambatdau = Convert.ToDateTime(ngaybatdau);
        update.hopdongthuviec_ngaythangnamketthuc = Convert.ToDateTime(ngayketthuc);
        update.hopdongthuviec_soHDTV = sohdtv;
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
    public bool Sua_HopDonglaoDong(int hosothuviec_id, string ngaybatdau, string ngayketthuc, string sohdtv)
    {

        tbQuanLyNhanSu_HopDongLaoDong update = db.tbQuanLyNhanSu_HopDongLaoDongs.Where(x => x.hopdonglaodong_id == hosothuviec_id).FirstOrDefault();
        //update.slidecate_id = slidecate;
        update.hopdonglaodong_ngaythangnambatdau = Convert.ToDateTime(ngaybatdau);
        update.hopdonglaodong_ngaythangnamketthuc = Convert.ToDateTime(ngayketthuc);
        update.hopdonglaodong_soHDLD = sohdtv;
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