using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_NewsCate
/// </summary>
public class cls_NhomThietBi
{
    dbcsdlDataContext db = new dbcsdlDataContext();
	public cls_NhomThietBi()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool Linq_Them( string nhomthietbi_name)
    {
        tbQuanTri_NhomThietBiNhaTruong insert = new tbQuanTri_NhomThietBiNhaTruong();
        insert.nhomthietbi_name = nhomthietbi_name;
        db.tbQuanTri_NhomThietBiNhaTruongs.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int newscate_id, string nhomthietbi_name)
    {
        tbQuanTri_NhomThietBiNhaTruong update = db.tbQuanTri_NhomThietBiNhaTruongs.Where(x => x.nhomthietbi_id == newscate_id).FirstOrDefault();
        update.nhomthietbi_name = nhomthietbi_name;
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
        tbQuanTri_NhomThietBiNhaTruong delete = db.tbQuanTri_NhomThietBiNhaTruongs.Where(x => x.nhomthietbi_id == newscate_id).FirstOrDefault();
        db.tbQuanTri_NhomThietBiNhaTruongs.DeleteOnSubmit(delete);
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