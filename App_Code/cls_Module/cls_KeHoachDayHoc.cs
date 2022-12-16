using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_NewsCate
/// </summary>
public class cls_KeHoachDayHoc
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_KeHoachDayHoc()
	{
		//
		// TODO: Add constructor logic here
		//
	}
     public bool Linq_Xoa( int kehoachdayhoc_id)
    {
        tbQuanTri_kehoachdayhoc delete = db.tbQuanTri_kehoachdayhocs.Where(x => x.kehoachdayhoc_id == kehoachdayhoc_id).FirstOrDefault();
        db.tbQuanTri_kehoachdayhocs.DeleteOnSubmit(delete);
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