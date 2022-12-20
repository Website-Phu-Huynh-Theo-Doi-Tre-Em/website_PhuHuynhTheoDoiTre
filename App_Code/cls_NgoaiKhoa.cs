using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_News
/// </summary>
public class cls_NgoaiKhoa
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_NgoaiKhoa()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(string news_title, string des, string news_content, DateTime create_date, int khoi_id)
    {
        tbNgoaiKhoa insert = new tbNgoaiKhoa();
        insert.ngoaikhoa_ten = news_title;
        insert.ngoaikhoa_mota = des;
        insert.ngoaikhoa_noidung = news_content;
        insert.ngoaikhoa_ngaytao = create_date;
        insert.khoi_id = khoi_id;
        db.tbNgoaiKhoas.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int news_id, string news_title, string des, string news_content, DateTime create_date)
    {
        tbNgoaiKhoa update = db.tbNgoaiKhoas.Where(x => x.ngoaikhoa_id == news_id).FirstOrDefault();
        update.ngoaikhoa_ten = news_title;
        update.ngoaikhoa_mota = des;
        update.ngoaikhoa_noidung = news_content;
        update.ngoaikhoa_capnhat = create_date;
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
        tbNgoaiKhoa delete = db.tbNgoaiKhoas.Where(x => x.ngoaikhoa_id == news_id).FirstOrDefault();
        db.tbNgoaiKhoas.DeleteOnSubmit(delete);
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