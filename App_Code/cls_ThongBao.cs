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
    public bool Linq_Them(string news_title, string news_content, int idlop, int username_id, int namhoc_id)
    {
        tbThongBao insert = new tbThongBao();
        insert.thongbao_title = news_title;
        insert.thongbao_content = news_content;
        insert.thongbao_datecreate = DateTime.Now;
        insert.thongbao_hidden = false;
        insert.thongbao_ngayketthuc = DateTime.Now.AddDays(7);
        insert.lop_id = idlop;
        insert.username_id = username_id;
        insert.namhoc_id = namhoc_id;
        insert.thongbao_tinhtrang = 0;//chưa được duyệt
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
        // int newscate_id,
        //var seodata = (from gr in db.tbWebsite_NewsCates
        //               where gr.newscate_id == newscate_id
        //               select gr).Single();
        tbThongBao update = db.tbThongBaos.Where(x => x.thongbao_id == news_id).FirstOrDefault();
        update.thongbao_title = news_title;
        update.thongbao_content = news_content;
        update.thongbao_dateupdate = DateTime.Now;
        update.thongbao_hidden = false;
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
    //public bool Linq_DuyetHieuPho(int news_id, int coso_id,int user_id, string news_title)
    //{

    //    tbThongBao update = db.tbVietNhatKids_ThongBaoLops.Where(x => x.thongbaoLop_id == news_id).FirstOrDefault();
    //    tbLichSuDuyet_BanGiamHieu insert = new tbLichSuDuyet_BanGiamHieu();
    //    if (coso_id == 1)
    //    {
    //        update.thongbaolop_tinhtrang = 2; //hiệu phó duyệt
    //        insert.lichsuduyet_diemtichluy = 1;
    //        insert.username_id = user_id;
    //        insert.lichsuduyet_ngayduyet = DateTime.Now;
    //        insert.lichsuduyet_formname = news_title;
    //        insert.namhoc_id = 11;
    //        db.tbLichSuDuyet_BanGiamHieus.InsertOnSubmit(insert);
    //    }
    //    else
    //    {
    //        update.thongbaolop_tinhtrang = 1; //hiệu phó duyệt
    //        insert.lichsuduyet_diemtichluy = 1;
    //        insert.username_id = user_id;
    //        insert.lichsuduyet_ngayduyet = DateTime.Now;
    //        insert.lichsuduyet_formname = news_title;
    //        insert.namhoc_id = 11;
    //        db.tbLichSuDuyet_BanGiamHieus.InsertOnSubmit(insert);
    //    }
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
    //public bool Linq_DuyetHieuTruong(int news_id)
    //{
    //    tbVietNhatKids_ThongBaoLop update = db.tbVietNhatKids_ThongBaoLops.Where(x => x.thongbaoLop_id == news_id).FirstOrDefault();
    //    update.thongbaolop_tinhtrang = 2; //hiệu trưởng duyệt
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
    public bool Linq_Xoa(int news_id)
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