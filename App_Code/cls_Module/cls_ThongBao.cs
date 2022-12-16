using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_News
/// </summary>
public class cls_ThongBao
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_ThongBao()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(string news_title,  string news_content)
    {
        tbThongBao insert = new tbThongBao();
        insert.thongbao_name = news_title;
        insert.thongbao_content = news_content;
        insert.thongbao_datecreate = DateTime.Now.Date;
        db.tbThongBaos.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int news_id, string news_title, string news_content)
    {
      
        tbThongBao update = db.tbThongBaos.Where(x => x.thongbao_id == news_id).FirstOrDefault();
        update.thongbao_name = news_title;
        update.thongbao_content = news_content;
        update.thongbao_datecreate = DateTime.Now.Date;
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
    public bool Linq_Xoa( int news_id)
    {
         tbThongBao delete = db.tbThongBaos.Where(x => x.thongbao_id == news_id).FirstOrDefault();
        db.tbThongBaos.DeleteOnSubmit(delete);
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