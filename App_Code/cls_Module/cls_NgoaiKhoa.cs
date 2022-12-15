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
    public bool Linq_Them(string news_title, string des, string news_content, int coso, DateTime create_date, int khoi_id)
    {
        tbVietNhatKids_NgoaiKhoa insert = new tbVietNhatKids_NgoaiKhoa();
        insert.ngoaikhoa_name = news_title;
        insert.ngoaikhoa_description = des;
        insert.ngoaikhoa_content = news_content;
        insert.ngoaikhoa_coso = coso;
        insert.ngoaikhoa_createdate = create_date;
        insert.khoi_id = khoi_id;
        db.tbVietNhatKids_NgoaiKhoas.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int news_id, string news_title, string des, string news_content, int coso, DateTime create_date)
    {
        tbVietNhatKids_NgoaiKhoa update = db.tbVietNhatKids_NgoaiKhoas.Where(x => x.ngoaikhoa_id == news_id).FirstOrDefault();
        update.ngoaikhoa_name = news_title;
        update.ngoaikhoa_description = des;
        update.ngoaikhoa_content = news_content;
        update.ngoaikhoa_coso = coso;
        update.ngoaikhoa_dateupdate = create_date;
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
        tbVietNhatKids_NgoaiKhoa delete = db.tbVietNhatKids_NgoaiKhoas.Where(x => x.ngoaikhoa_id == news_id).FirstOrDefault();
        db.tbVietNhatKids_NgoaiKhoas.DeleteOnSubmit(delete);
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