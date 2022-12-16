using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_TuanHoc
/// </summary>
public class cls_TuanHoc
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_TuanHoc()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(string tuan_name, int namhoc_id, DateTime tuan_tungay, DateTime tuan_denngay)
    {
        tbHocTap_Tuan insert = new tbHocTap_Tuan();
        insert.tuan_name = tuan_name;
        insert.namhoc_id = namhoc_id;
        insert.tuan_hidden = false;
        insert.tuan_tungay = tuan_tungay;
        insert.tuan_denngay = tuan_denngay;
        db.tbHocTap_Tuans.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int tuan_id, string tuan_name, int namhoc_id, DateTime tuan_tungay, DateTime tuan_denngay)
    {
        tbHocTap_Tuan update = db.tbHocTap_Tuans.Where(x => x.tuan_id == tuan_id).FirstOrDefault();
        update.tuan_name = tuan_name;
        update.namhoc_id = namhoc_id;
        update.tuan_tungay = tuan_tungay;
        update.tuan_denngay = tuan_denngay;
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
    public bool Linq_Xoa(int tuan_id)
    {
        tbHocTap_Tuan delete = db.tbHocTap_Tuans.Where(x => x.tuan_id == tuan_id).FirstOrDefault();
        delete.tuan_hidden = true;
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