using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_phienchenamhoc
/// </summary>
public class cls_phienchenamhoc
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_phienchenamhoc()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(string news_title, string news_image, int namhoc_id, int khoi_id)
    {
        tbQuanTri_PhienCheNamHoc insert = new tbQuanTri_PhienCheNamHoc();
        insert.phienche_name = news_title;
        insert.phienche_content = news_image;
        insert.namhoc_id = namhoc_id;
        insert.khoi_id = khoi_id;
        //insert.coso_id = coso_id;
        db.tbQuanTri_PhienCheNamHocs.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int news_id, string news_title, string news_image, int namhoc_id, int khoi_id)
    {

        tbQuanTri_PhienCheNamHoc update = db.tbQuanTri_PhienCheNamHocs.Where(x => x.phienche_id == news_id).FirstOrDefault();
        update.phienche_name = news_title;
        update.phienche_content = news_image;
        update.namhoc_id = namhoc_id;
        update.khoi_id = khoi_id;
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
        tbQuanTri_PhienCheNamHoc delete = db.tbQuanTri_PhienCheNamHocs.Where(x => x.phienche_id == news_id).FirstOrDefault();
        delete.phienche_hidden = true;
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