using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_News
/// </summary>
public class cls_QuanLyNamHoc
{
    dbcsdlDataContext db = new dbcsdlDataContext();

    public cls_QuanLyNamHoc()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(string namhoc_nienkhoa)
    {

        tbHoctap_NamHoc insert = new tbHoctap_NamHoc();
        insert.namhoc_nienkhoa = namhoc_nienkhoa;
        db.tbHoctap_NamHocs.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int id,string nienkhoa)
    {
        tbHoctap_NamHoc update = db.tbHoctap_NamHocs.Where(x => x.namhoc_id == id).FirstOrDefault();
        update.namhoc_nienkhoa = nienkhoa;
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
    public bool Linq_Xoa(int id)
    {
        tbHoctap_NamHoc delete = db.tbHoctap_NamHocs.Where(x => x.namhoc_id == id).FirstOrDefault();
        db.tbHoctap_NamHocs.DeleteOnSubmit(delete);
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