using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_Slide
/// </summary>
public class cls_Content
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_Content()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Them_Intro( string content_title, string content_summary, string content_image, string content_content, string SEO_KEYWORD, string SEO_TITLE, string SEO_LINK, string SEO_DEP, string SEO_IMAGE)
    {
       
        tbContentBlock insert = new tbContentBlock();
        insert.content_image = content_image;
        insert.content_title = content_title;
        insert.content_summary = content_summary;
        insert.content_content = content_content;
        db.tbContentBlocks.InsertOnSubmit(insert);
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
    public bool Sua_Content(int content_id, string content_title, string content_summary, string content_image, string content_content, string SEO_KEYWORD, string SEO_TITLE, string SEO_LINK, string SEO_DEP, string SEO_IMAGE)
    {
     
        tbContentBlock update = db.tbContentBlocks.Where(x => x.content_id == content_id).FirstOrDefault();
        if (content_image != null)
            update.content_image = content_image;
        //update.slidecate_id = slidecate;
        update.content_title = content_title;
        update.content_summary = content_summary;
        update.content_content = content_content;
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
    public bool Intro_SuaImage(int content_id, string content_image)
    {
        tbContentBlock update = db.tbContentBlocks.Where(x => x.content_id == content_id).FirstOrDefault();
        update.content_image = content_image;
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
    public bool Content_Xoa(int content_id)
    {
        tbContentBlock delete = db.tbContentBlocks.Where(x => x.content_id == content_id).FirstOrDefault();
        db.tbContentBlocks.DeleteOnSubmit(delete);
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
    //public bool Sua_Img(int img_id, string img_name)
    //{
    //    tbImageIntroduce update = db.tbImageIntroduces.Where(x => x.img_id == img_id).FirstOrDefault();
    //    update.img_name = img_name;
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
}