using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_NewsCate
/// </summary>
public class cls_DuGio
{
    dbcsdlDataContext db = new dbcsdlDataContext();
	public cls_DuGio()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public bool Linq_Xoa( int dugio_id)
    {
        tbHocTap_DuGio delete = db.tbHocTap_DuGios.Where(x => x.dugio_id == dugio_id).FirstOrDefault();
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