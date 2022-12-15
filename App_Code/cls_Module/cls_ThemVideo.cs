using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_ThemVideo
/// </summary>
public class cls_ThemVideo
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_ThemVideo()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Video_them(string link, string image, int lop_id)
    {
        tbImageLibrary insert = new tbImageLibrary();
        insert.imagelib_link = link;
        insert.imagelib_image = image;
        insert.lop_id = lop_id;
        insert.hidden = true;
        DateTime date = DateTime.Now;
        string now = date.ToString("dd/MM/yyyy");
        insert.imagelib_datecreate = Convert.ToDateTime( now);
        insert.imagelib_parent = 2;
        db.tbImageLibraries.InsertOnSubmit(insert);
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