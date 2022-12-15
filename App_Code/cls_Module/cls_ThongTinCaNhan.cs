using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_NewsCate
/// </summary>
public class cls_ThongTinCaNhan
{
    dbcsdlDataContext db = new dbcsdlDataContext();
	public cls_ThongTinCaNhan()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool Linq_Xoa( int newscate_id)
    {
        admin_User delete = db.admin_Users.Where(x => x.username_id == newscate_id).FirstOrDefault();
        db.admin_Users.DeleteOnSubmit(delete);
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