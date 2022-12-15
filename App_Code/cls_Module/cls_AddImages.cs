using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ctl_newbuilding
/// </summary>
public class cls_AddImages
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_AddImages()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    // one product
    public bool InsertImageOneProduct(string image, int lop_id)
    {
        tbImageLibrary insert = new tbImageLibrary();
        insert.imagelib_image = image;
        insert.lop_id = lop_id;
        insert.imagelib_parent = 1;
        DateTime date = DateTime.Now;
        string now = date.ToString("dd/MM/yyyy");
        insert.imagelib_datecreate = Convert.ToDateTime(now);
        insert.hidden = true;
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
    //xóa image
    //public bool Image_xoa(int image_id)
    //{
    //    tbCollectionImage delete = db.tbCollectionImages.Where(x => x.collection_id == image_id).FirstOrDefault();
    //    db.tbCollectionImages.DeleteOnSubmit(delete);
    //    try
    //    {
    //        db.SubmitChanges();
    //        return true;
    //    }
    //    catch
    //    {
    //        return false;
    //    }
    //}
    //thêm video
    //public bool Video_them(string link, string image)
    //{
    //    tbCollectionImage insert = new tbCollectionImage();
    //    insert.collection_youtube = link;
    //    insert.collection_avatar = image;
    //    db.tbCollectionImages.InsertOnSubmit(insert);
    //    try
    //    {
    //        db.SubmitChanges();
    //        return true;
    //    }
    //    catch
    //    {
    //        return false;
    //    }
    //}
    //sửa image
    public bool Linq_suaimage(int imagelib_id, string image, int lop_id)
    {
        tbImageLibrary update = db.tbImageLibraries.Where(x => x.imagelib_id == imagelib_id).FirstOrDefault();
        if (image != null)
        {
            update.imagelib_image = image;
            update.lop_id = lop_id;
            update.imagelib_datecreate = DateTime.Now;
        }
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
    public bool Linq_suavideo(int imagelib_id, string link, string image, int lop_id)
    {
        tbImageLibrary update = db.tbImageLibraries.Where(x => x.imagelib_id == imagelib_id).FirstOrDefault();
        if (link!=null)
        {
            update.imagelib_link = link;
            update.lop_id = lop_id;
            DateTime date = DateTime.Now;
            string now = date.ToString("dd/MM/yyyy");
            update.imagelib_datecreate = Convert.ToDateTime(now);
        }
        //else
        //{
        //    update.collection_youtube = link;
        //}
        if (image != null)
        {
            update.imagelib_image = image;
        }
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
    public bool Linq_xoa(int imagelib_id)
    {
        tbImageLibrary delete = db.tbImageLibraries.Where(x => x.imagelib_id == imagelib_id).FirstOrDefault();
        db.tbImageLibraries.DeleteOnSubmit(delete);
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