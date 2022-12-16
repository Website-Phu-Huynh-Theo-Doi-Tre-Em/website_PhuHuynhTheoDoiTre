using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_NewsCate
/// </summary>
public class cls_GiaoVienMonHoc
{
    dbcsdlDataContext db = new dbcsdlDataContext();
	public cls_GiaoVienMonHoc()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool Linq_Them(int gvid, int mhid)
    {
        tbHocTap_GiaoVien_MonHoc insert = new tbHocTap_GiaoVien_MonHoc();
        insert.giaovien_id = gvid;
        insert.monhoc_id = mhid;
        db.tbHocTap_GiaoVien_MonHocs.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int newscate_id, int gvid, int mhid)
    {
        tbHocTap_GiaoVien_MonHoc update = db.tbHocTap_GiaoVien_MonHocs.Where(x => x.gvmh_id == newscate_id).FirstOrDefault();
        update.giaovien_id = gvid;
        update.monhoc_id = mhid;
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
    public bool Linq_Xoa( int newscate_id)
    {
        tbHocTap_GiaoVien_MonHoc delete = db.tbHocTap_GiaoVien_MonHocs.Where(x => x.gvmh_id == newscate_id).FirstOrDefault();
        db.tbHocTap_GiaoVien_MonHocs.DeleteOnSubmit(delete);
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