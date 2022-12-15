using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_News
/// </summary>
public class cls_HocSinh
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_HocSinh()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(string hocsinh_name, DateTime hocsinh_namsinh, int hocsinh_phone, string hocsinh_phuhuynh)
    {
        var insert = new tbHocSinh();
        insert.hocsinh_name = hocsinh_name;
        insert.hidden = false;
        db.tbHocSinhs.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int hocsinh_id, string hocsinh_name, DateTime hocsinh_namsinh, int hocsinh_phone, string hocsinh_phuhuynh)
    {
        tbHocSinh update = db.tbHocSinhs.Where(x => x.hocsinh_id == hocsinh_id).FirstOrDefault();
        update.hocsinh_name = hocsinh_name;
        //update.account_namsinh = hocsinh_namsinh;
        //update.account_phone = hocsinh_phone.ToString();
        //update.account_phuhuynh = hocsinh_phuhuynh;


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
    public bool Linq_Xoa(int hocsinh_id)
    {
        tbHocSinh delete = db.tbHocSinhs.Where(x => x.hocsinh_id == hocsinh_id).FirstOrDefault();
        delete.hidden = true;
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
    public bool Linq_Insert_DanhSach(string cophep, string ghichu, int mahstl)
    {
        tbDiemDanh_HocSinh insert = new tbDiemDanh_HocSinh();
        insert.diemdanh_ngay = DateTime.Now;
        insert.tinhtrang = cophep;
        insert.diemdanh_lydo = ghichu;
        insert.hstl_id = mahstl;
        db.tbDiemDanh_HocSinhs.InsertOnSubmit(insert);
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
    public bool Linq_Insert_DanhSach_Ve(string cophep, string ghichu, int mahstl)
    {
        tbDiemDanh_Ve insert = new tbDiemDanh_Ve();
        insert.diemdanhve_ngay = DateTime.Now;
        insert.diemdanhve_tinhtrang = cophep;
        insert.diemdanhve_lydo = ghichu;
        insert.hstl_id = mahstl;
        db.tbDiemDanh_Ves.InsertOnSubmit(insert);
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
    public bool Linq_Insert_DanhSach_Ve_Muon(string cophep, string ghichu, int mahstl, int gvid)
    {
        tbDiemDanh_Ve_Muon insert = new tbDiemDanh_Ve_Muon();
        insert.diemdanhvemuon_ngay = DateTime.Now;
        insert.diemdanhvemuon_tinhtrang = cophep;
        insert.diemdanhvemuon_lydo = ghichu;
        insert.hstl_id = mahstl;
        insert.giaovien_id = gvid;
        db.tbDiemDanh_Ve_Muons.InsertOnSubmit(insert);
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
    public bool Linq_CapNhatDiemDanh(int mahstl, string cophep, string ghichu, int giaovien_id)
    {
        tbDiemDanh_HocSinh update = (from ck in db.tbDiemDanh_HocSinhs
                                     where ck.hstl_id == mahstl
                                     && ck.diemdanh_ngay.Value.Date == Convert.ToDateTime(DateTime.Now).Date
                                     && ck.diemdanh_ngay.Value.Month == Convert.ToDateTime(DateTime.Now).Month
                                     && ck.diemdanh_ngay.Value.Year == Convert.ToDateTime(DateTime.Now).Year
                                     select ck).FirstOrDefault();
        update.diemdanh_ngay = DateTime.Now;
        update.tinhtrang = cophep;
        update.diemdanh_lydo = ghichu;
        update.username_id = giaovien_id;
        //insert.hstl_id = mahstl;
        //db.tbDiemDanh_HocSinhs.InsertOnSubmit(insert);
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
    public bool Linq_CapNhat_DanhSach_Ve(string cophep, string ghichu, int mahstl)
    {
        tbDiemDanh_Ve update = (from ck in db.tbDiemDanh_Ves
                                where ck.hstl_id == mahstl
                                   && ck.diemdanhve_ngay.Value.Date == Convert.ToDateTime(DateTime.Now).Date
                                   && ck.diemdanhve_ngay.Value.Month == Convert.ToDateTime(DateTime.Now).Month
                                   && ck.diemdanhve_ngay.Value.Year == Convert.ToDateTime(DateTime.Now).Year
                                select ck).FirstOrDefault();
        update.diemdanhve_ngay = DateTime.Now;
        update.diemdanhve_tinhtrang = cophep;
        update.diemdanhve_lydo = ghichu;
        // insert.hstl_id = mahstl;
        //db.tbDiemDanh_Ves.InsertOnSubmit(insert);
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