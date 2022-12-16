using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_News
/// </summary>
public class cls_formmau
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_formmau()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(string news_title, string news_image)
    {
        tbQuanTri_FormMau insert = new tbQuanTri_FormMau();
        insert.formmau_title = news_title;
        insert.formau_file = news_image;
        insert.formau_loai = "file chung";
        insert.formau_ngaycapnhat = DateTime.Now;
        insert.formau_hidden = false;
        db.tbQuanTri_FormMaus.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int news_id, string news_title, string news_image)
    {

        tbQuanTri_FormMau update = db.tbQuanTri_FormMaus.Where(x => x.formmau_id == news_id).FirstOrDefault();
        update.formmau_title = news_title;
        update.formau_file = news_image;
        //update.formau_ghichu = news_summary;
        update.formau_ngaycapnhat = DateTime.Now;
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
        tbQuanTri_FormMau delete = db.tbQuanTri_FormMaus.Where(x => x.formmau_id == news_id).FirstOrDefault();
        delete.formau_hidden = true;
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