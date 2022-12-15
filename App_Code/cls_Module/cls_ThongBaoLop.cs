using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_News
/// </summary>
public class cls_ThongBaoLop
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_ThongBaoLop()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(string news_title, string news_content, int idlop, int username_id, int namhoc_id)
    {
        tbVietNhatKids_ThongBaoLop insert = new tbVietNhatKids_ThongBaoLop();
        insert.thongbaoLop_title = news_title;
        insert.thongbaoLop_content = news_content;
        insert.thongbaoLop_datecreate = DateTime.Now;
        insert.thongbaoLop_hidden = false;
        insert.thongbaolop_ngayketthuc = DateTime.Now.AddDays(7);
        insert.lop_id = idlop;
        insert.username_id = username_id;
        insert.namhoc_id = namhoc_id;
        insert.thongbaolop_tinhtrang = 0;//chưa được duyệt
        insert.thongbaolop_diemtichluy = 3;
        db.tbVietNhatKids_ThongBaoLops.InsertOnSubmit(insert);
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
        // int newscate_id,
        //var seodata = (from gr in db.tbWebsite_NewsCates
        //               where gr.newscate_id == newscate_id
        //               select gr).Single();
        tbVietNhatKids_ThongBaoLop update = db.tbVietNhatKids_ThongBaoLops.Where(x => x.thongbaoLop_id == news_id).FirstOrDefault();
        update.thongbaoLop_title = news_title;
        update.thongbaoLop_content = news_content;
        update.thongbaolop_dateupdate = DateTime.Now;
        update.thongbaoLop_hidden = false;
        //update.thongbaolop_ngayketthuc = DateTime.Now.AddDays(7);
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
    public bool Linq_DuyetHieuPho(int news_id, int coso_id,int user_id, string news_title)
    {

        tbVietNhatKids_ThongBaoLop update = db.tbVietNhatKids_ThongBaoLops.Where(x => x.thongbaoLop_id == news_id).FirstOrDefault();
        tbLichSuDuyet_BanGiamHieu insert = new tbLichSuDuyet_BanGiamHieu();
        if (coso_id == 1)
        {
            update.thongbaolop_tinhtrang = 2; //hiệu phó duyệt
            insert.lichsuduyet_diemtichluy = 1;
            insert.username_id = user_id;
            insert.lichsuduyet_ngayduyet = DateTime.Now;
            insert.lichsuduyet_formname = news_title;
            insert.namhoc_id = 11;
            db.tbLichSuDuyet_BanGiamHieus.InsertOnSubmit(insert);
        }
        else
        {
            update.thongbaolop_tinhtrang = 1; //hiệu phó duyệt
            insert.lichsuduyet_diemtichluy = 1;
            insert.username_id = user_id;
            insert.lichsuduyet_ngayduyet = DateTime.Now;
            insert.lichsuduyet_formname = news_title;
            insert.namhoc_id = 11;
            db.tbLichSuDuyet_BanGiamHieus.InsertOnSubmit(insert);
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
    public bool Linq_DuyetHieuTruong(int news_id)
    {
        tbVietNhatKids_ThongBaoLop update = db.tbVietNhatKids_ThongBaoLops.Where(x => x.thongbaoLop_id == news_id).FirstOrDefault();
        update.thongbaolop_tinhtrang = 2; //hiệu trưởng duyệt
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
        tbVietNhatKids_ThongBaoLop delete = db.tbVietNhatKids_ThongBaoLops.Where(x => x.thongbaoLop_id == news_id).FirstOrDefault();
        db.tbVietNhatKids_ThongBaoLops.DeleteOnSubmit(delete);
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