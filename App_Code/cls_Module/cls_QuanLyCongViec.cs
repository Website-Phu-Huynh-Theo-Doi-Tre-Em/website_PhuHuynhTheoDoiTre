using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Slide
/// </summary>
public class cls_QuanLyCongViec
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_QuanLyCongViec()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool insert_CongViec( int user_id, string intro_title,DateTime ngaytao, DateTime ngayketthuc, bool riengtu)
    {
      
        tbQuanLyCongViec insert = new tbQuanLyCongViec();
        insert.quanlycongviec_name = intro_title;
        insert.quanlycongviec_createdate = ngaytao;
        insert.quanlycongviec_enddate = ngayketthuc;
        insert.username_id = user_id;
        insert.quanlycongviec_private = riengtu;
        db.tbQuanLyCongViecs.InsertOnSubmit(insert);
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
    public bool update_CongViec(int congviec_id, string intro_title, DateTime ngaytao, DateTime ngayketthuc, bool riengtu)
    {

        tbQuanLyCongViec update = db.tbQuanLyCongViecs.Where(x => x.quanlycongviec_id == congviec_id).FirstOrDefault();
        update.quanlycongviec_name = intro_title;
        update.quanlycongviec_createdate = ngaytao;
        update.quanlycongviec_enddate = ngayketthuc;
        update.quanlycongviec_private = riengtu;
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
    public bool update_CongViec1(int congviec_id, string intro_title,bool riengtu)
    {

        tbQuanLyCongViec update = db.tbQuanLyCongViecs.Where(x => x.quanlycongviec_id == congviec_id).FirstOrDefault();
        update.quanlycongviec_name = intro_title;
        update.quanlycongviec_private = riengtu;
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
    public bool delete_CongViec(int congviec_id)
    {
        tbQuanLyCongViec delete = db.tbQuanLyCongViecs.Where(x => x.quanlycongviec_id == congviec_id).FirstOrDefault();
        db.tbQuanLyCongViecs.DeleteOnSubmit(delete);
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