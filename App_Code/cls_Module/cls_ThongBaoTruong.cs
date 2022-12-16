using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_News
/// </summary>
public class cls_ThongBaoTruong
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_ThongBaoTruong()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(string news_title, string news_content, int newscate_id, int coso_id, int username_id, int namhoc_id)
    {
        tbVietNhatKids_ThongBaoTruong insert = new tbVietNhatKids_ThongBaoTruong();
        insert.thongbaotruong_title = news_title;
        insert.thongbaotruong_content = news_content;
        insert.thongbaotruong_datecreate = DateTime.Now;
        insert.thongbaotruong_ngayketthuc = DateTime.Now.AddDays(7);
        insert.khoi_id = newscate_id;
        insert.coso_id = coso_id;
        insert.thongbaotruong_diemtichluy = 3;
        insert.namhoc_id= namhoc_id;
        insert.username_id= username_id;
        db.tbVietNhatKids_ThongBaoTruongs.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int news_id, string news_title, string news_content, int coso_id)
    {
        tbVietNhatKids_ThongBaoTruong update = db.tbVietNhatKids_ThongBaoTruongs.Where(x => x.thongbaotruong_id == news_id).FirstOrDefault();
        update.thongbaotruong_title = news_title;
        update.thongbaotruong_content = news_content;
        update.thongbaotruong_dateupdate = DateTime.Now;
        //update.thongbaotruong_ngayketthuc = DateTime.Now.AddDays(7);
        //update.khoi_id = newscate_id;
        update.coso_id = coso_id;
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
        tbVietNhatKids_ThongBaoTruong delete = db.tbVietNhatKids_ThongBaoTruongs.Where(x => x.thongbaotruong_id == news_id).FirstOrDefault();
        db.tbVietNhatKids_ThongBaoTruongs.DeleteOnSubmit(delete);
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