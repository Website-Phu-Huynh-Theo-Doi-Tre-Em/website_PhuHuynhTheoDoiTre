using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_News
/// </summary>
public class cls_QuanLyLop
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_QuanLyLop()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(string tenLop, int khoi, int coso)
    {
        tbLop l = new tbLop();
        l.lop_name = tenLop;
        l.khoi_id = khoi;
        l.coso_id = coso;
        l.hidden = false;
        db.tbLops.InsertOnSubmit(l);
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
    public bool Linq_Sua(int lop_id, string tenLop, int khoi, int coso)
    {

        tbLop l = db.tbLops.Where(x => x.lop_id == lop_id).FirstOrDefault();
        l.lop_name = tenLop;
        l.khoi_id = khoi;
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
        tbLop delete = db.tbLops.Where(x => x.lop_id == news_id).FirstOrDefault();
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
}