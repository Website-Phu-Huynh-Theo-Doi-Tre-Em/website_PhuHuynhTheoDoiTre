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
        tbQuanLyNhanSu_ThongTinCaNhan delete = db.tbQuanLyNhanSu_ThongTinCaNhans.Where(x => x.thongtincanhan_id == newscate_id).FirstOrDefault();
        db.tbQuanLyNhanSu_ThongTinCaNhans.DeleteOnSubmit(delete);
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