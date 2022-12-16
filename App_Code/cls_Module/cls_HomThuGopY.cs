using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_NewsCate
/// </summary>
public class cls_HomThuGopY
{
    dbcsdlDataContext db = new dbcsdlDataContext();
	public cls_HomThuGopY()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool Linq_Them(string title, string content, int user_id)
    {
        tbQuanTri_HomThuGopY insert = new tbQuanTri_HomThuGopY();
        insert.homthugopy_title = title;
        insert.homthugopy_content = content;
        insert.homthugopy_creatdate = DateTime.Now;
        insert.homthugopy_status = "Chưa xem";
        insert.username_id = user_id;
        db.tbQuanTri_HomThuGopies.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int gopy_id, string title, string content, int user_id)
    {
        tbQuanTri_HomThuGopY update = db.tbQuanTri_HomThuGopies.Where(x => x.homthugopy_id == gopy_id).FirstOrDefault();
        update.homthugopy_title = title;
        update.homthugopy_content = content;
        update.homthugopy_creatdate = DateTime.Now;
        update.homthugopy_status = "Chưa xem";
        update.username_id = user_id;
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
    public bool Linq_Xoa( int gopy_id)
    {
        tbQuanTri_HomThuGopY delete = db.tbQuanTri_HomThuGopies.Where(x => x.homthugopy_id == gopy_id).FirstOrDefault();
        db.tbQuanTri_HomThuGopies.DeleteOnSubmit(delete);
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