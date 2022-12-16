using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_NewsCate
/// </summary>
public class cls_CongVanDi
{
    dbcsdlDataContext db = new dbcsdlDataContext();
	public cls_CongVanDi()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //public bool Linq_Them( string congvan_name, string file, DateTime date_create, int username_id)
    //{
    //    tbQuanLyCongVanDi insert = new tbQuanLyCongVanDi();
    //    insert.congvandi_name = congvan_name;
    //    insert.congvandi_file = file;
    //    //insert.congvandi_content = congvan_content;
    //    insert.congvandi_createdate = date_create;
    //    insert.username_id = username_id;
    //    db.tbQuanLyCongVanDis.InsertOnSubmit(insert);
    //    try
    //    {
    //        db.SubmitChanges();
    //        return true;
    //    }
    //    catch
    //    {
    //        return false;
    //    }
    //}
    //public bool Linq_Sua(int newscate_id, int newscate_position, string newscate_title, bool newscate_active, string SEO_KEYWORD, string SEO_TITLE, string SEO_LINK, string SEO_DEP, string SEO_IMAGE)
    //{
       
        //update.newscate_title = newscate_title;
        //update.newscate_position = newscate_position;
        //update.newscate_active= newscate_active;
        //try
        //{
        //    db.SubmitChanges();
        //    return true;
        //}
        //catch
        //{
        //    return false;
        //}
    //}
    public bool Linq_Xoa( int congvan_id)
    {
        tbQuanLyCongVanDi delete = db.tbQuanLyCongVanDis.Where(x => x.congvandi_id == congvan_id).FirstOrDefault();
        db.tbQuanLyCongVanDis.DeleteOnSubmit(delete);
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