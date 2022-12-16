using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Slide
/// </summary>
public class cls_AlbumImage
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_AlbumImage()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Them_Intro(string intro_title, string intro_content, string intro_image, int gvtl, int lop_id, int namHoc, int username_id)
    {
        tbVietNhatKids_AlbumImage insert = new tbVietNhatKids_AlbumImage();
        insert.namhoc_id = namHoc;
        insert.albumimage_title = intro_title;
        insert.albumimage_image = intro_image;
        insert.albumimage_content = intro_content;
        insert.albumImage_diemtichluy = 3;
        insert.gvtl_id = gvtl;
        insert.lop_id = lop_id;
        insert.username_id = username_id;
        insert.albumimage_datecreate = DateTime.Now;
        db.tbVietNhatKids_AlbumImages.InsertOnSubmit(insert);
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
    public bool Sua_slide(int intro_id, string intro_title, string intro_content, string intro_image, int gvtl, int lop_id)
    {

        tbVietNhatKids_AlbumImage update = db.tbVietNhatKids_AlbumImages.Where(x => x.albumimage_id == intro_id).FirstOrDefault();
        if (intro_image != null)
        {
            update.albumimage_image = intro_image;
        }
        update.albumimage_title = intro_title;
        update.albumimage_content = intro_content;
        update.gvtl_id = gvtl;
        update.lop_id = lop_id;
        update.albumimage_dateupdate = DateTime.Now;
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

    public bool albumimage_Xoa(int intro_id)
    {
        tbVietNhatKids_AlbumImage delete = db.tbVietNhatKids_AlbumImages.Where(x => x.albumimage_id == intro_id).FirstOrDefault();
        db.tbVietNhatKids_AlbumImages.DeleteOnSubmit(delete);
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
    public bool InsertImageHocSinh(int albumimage_id, string image_link)
    {
        tbVietNhatKids_AlbumImage_HocSinh insert = new tbVietNhatKids_AlbumImage_HocSinh();
        insert.albumimage_id = albumimage_id;
        insert.albumimage_hocsinh_image = image_link;
        db.tbVietNhatKids_AlbumImage_HocSinhs.InsertOnSubmit(insert);
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