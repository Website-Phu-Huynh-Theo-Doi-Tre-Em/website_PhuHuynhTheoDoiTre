using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_webXinNghi
/// </summary>
public class cls_webXinNghi
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_webXinNghi()
    {

    }
    public bool Them_XinNghi(DateTime ngaybatdau, DateTime ngayketthuc, string lydo, int hstl_id, int lop_id, int id_nam)
    {
        tbPhuHuynhXinNghi insert = new tbPhuHuynhXinNghi();
        insert.phuhuynhxinnghi_ngaydangki = Convert.ToDateTime(DateTime.Now);
        insert.phuhuynhxinnghi_ngaybatdau = Convert.ToDateTime(ngaybatdau);
        insert.phuhuynhxinnghi_ngayketthuc = Convert.ToDateTime(ngayketthuc);
        insert.phuhuynhxinnghi_lydo = lydo;
        insert.hstl_id = hstl_id;
        insert.lop_id = lop_id;
        insert.namhoc_id = id_nam;
        insert.phuhuynhxinnghi_xacnhan = false;
        db.tbPhuHuynhXinNghis.InsertOnSubmit(insert);
        try { 
            db.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}