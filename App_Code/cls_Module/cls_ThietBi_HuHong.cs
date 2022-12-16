using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_News
/// </summary>
public class cls_ThietBi_HuHong
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_ThietBi_HuHong()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(string name, string ghichu, string thietbihuhong, int username, int canxuly, string tinhtrang)
    {
        
        tbQuanTri_ThietBiNhaTruong insert = new tbQuanTri_ThietBiNhaTruong();
        insert.thietbi_name = name;
        insert.thietbi_noidung = thietbihuhong;
        insert.thietbi_note = ghichu;
        insert.nhomthietbi_id = canxuly;
        insert.thietbi_createdate = DateTime.Now;
        insert.username_id = username;
        insert.thietbi_status = tinhtrang;
        db.tbQuanTri_ThietBiNhaTruongs.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int news_id, string name, string noidung, int nhom, int username, string tinhtrang)
    {
        tbQuanTri_ThietBiNhaTruong update = db.tbQuanTri_ThietBiNhaTruongs.Where(x => x.thietbi_id == news_id).FirstOrDefault();
        update.thietbi_name = name;
        update.thietbi_noidung = noidung;
        //update.thietbi_note = note;
        update.nhomthietbi_id = nhom;
        update.thietbi_createdate = DateTime.Now;
        update.username_id = username;
        update.thietbi_status = tinhtrang;
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
    public bool Linq_Xoa(int news_id)
    {
        tbQuanTri_ThietBiNhaTruong delete = db.tbQuanTri_ThietBiNhaTruongs.Where(x => x.thietbi_id == news_id).FirstOrDefault();
        db.tbQuanTri_ThietBiNhaTruongs.DeleteOnSubmit(delete);
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