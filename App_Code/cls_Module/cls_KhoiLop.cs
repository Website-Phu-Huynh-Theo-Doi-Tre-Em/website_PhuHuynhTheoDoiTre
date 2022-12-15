using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_News
/// </summary>
public class cls_KhoiLop
{
    dbcsdlDataContext db = new dbcsdlDataContext();

    public cls_KhoiLop()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(string khoi_name, int coso_id)
    {

        tbKhoi insert = new tbKhoi();
        insert.khoi_name = khoi_name;
        db.tbKhois.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int khoi_id, string khoi_name)
    {
        tbKhoi update = db.tbKhois.Where(x => x.khoi_id == khoi_id).FirstOrDefault();
        update.khoi_name = khoi_name;
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
    //public bool Linq_Xoa(int khoi_id)
    //{
    //    tbKhoi delete = db.tbKhois.Where(x => x.khoi_id == khoi_id).FirstOrDefault();
    //    //delete.hidden = true;
    //    //try
    //    //{
    //    //    db.SubmitChanges();
    //    //    return true;
    //    //}
    //    //catch
    //    //{
    //    //    return false;
    //    //}
    //}
}