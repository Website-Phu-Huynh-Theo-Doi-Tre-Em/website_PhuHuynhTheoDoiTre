﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_module_website_website_VietNhatKis_web_DangKyNgoaiKhoa : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int namhoc_id;
    private int _Id_HocSinh;
    private int _Id_CoSo;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["web_hocsinh"] != null)
        {
            namhoc_id = (from nm in db.tbHoctap_NamHocs
                         orderby nm.namhoc_id descending
                         select nm.namhoc_id).First();
            var getlist = from hs in db.tbHocSinhs
                          join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                          join l in db.tbLops on hstl.lop_id equals l.lop_id
                          join dn in db.tbVietNhatKids_NgoaiKhoas on l.khoi_id equals dn.khoi_id
                          where hs.hocsinh_taikhoan == Request.Cookies["web_hocsinh"].Value
                          && hstl.namhoc_id == namhoc_id
                          orderby dn.ngoaikhoa_id descending
                          select new
                          {
                              dn.ngoaikhoa_id,
                              dn.ngoaikhoa_name,
                              dn.ngoaikhoa_content,
                              dn.ngoaikhoa_description,
                              style = (from ls in db.tbVietNhatKids_NgoaiKhoa_LichSus
                                       where ls.ngoaikhoa_id == dn.ngoaikhoa_id
                                       && ls.hstl_id == hstl.hstl_id
                                       select ls).Count() > 0 ? "display:none" : " ",
                              hs.hocsinh_id,
                              hstl.hstl_id,
                              l.lop_id,
                          };
            tbVietNhatKids_NgoaiKhoa_LichSu insert = new tbVietNhatKids_NgoaiKhoa_LichSu();
            insert.hocsinh_id = getlist.FirstOrDefault().hocsinh_id;
            insert.hstl_id = getlist.FirstOrDefault().hstl_id;
            insert.lop_id = getlist.FirstOrDefault().lop_id;
            insert.ngoaikhoa_lichsu_ngayxem = DateTime.Now;
            if (!IsPostBack)
            {
                //rpDaNgoai.DataSource = getlist;
                //rpDaNgoai.DataBind();
                //rpDaNgoaiChiTiet.DataSource = getlist.Take(1);
                //rpDaNgoaiChiTiet.DataBind();
                txtngoaiKhoa_id.Value = getlist.Take(1).FirstOrDefault().ngoaikhoa_id+"";
               // insert.ngoaikhoa_id = getlist.Take(1).FirstOrDefault().ngoaikhoa_id;
            }
            if (txtngoaiKhoa_id.Value != "")
            {
                int id = Convert.ToInt32(txtngoaiKhoa_id.Value);
                var getChiTiet = getlist.Where(x => x.ngoaikhoa_id == id);
                rpDaNgoai.DataSource = getlist;
                rpDaNgoai.DataBind();
                rpDaNgoaiChiTiet.DataSource = getChiTiet;
                rpDaNgoaiChiTiet.DataBind();
                insert.ngoaikhoa_id = id;
            }
            db.tbVietNhatKids_NgoaiKhoa_LichSus.InsertOnSubmit(insert);
            db.SubmitChanges();
        }
        else
        {
            Response.Redirect("/website-trang-chu");
        }
    }

    protected void btDangKy_ServerClick(object sender, EventArgs e)
    {
        var checkNamHoc = (from nh in db.tbHoctap_NamHocs orderby nh.namhoc_id descending select nh).First();
        var checkUserId = (from hs in db.tbHocSinhs
                           where hs.hocsinh_taikhoan == Request.Cookies["web_hocsinh"].Value
                           select hs).First();
        var getHocSinh = (from hs in db.tbHocSinhs
                          join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                          join l in db.tbLops on hstl.lop_id equals l.lop_id
                          where hstl.hocsinh_id == checkUserId.hocsinh_id &&
                          hstl.namhoc_id == checkNamHoc.namhoc_id
                          orderby hstl.hocsinh_id descending
                          select new
                          {
                              hstl.hstl_id,
                              hs.hocsinh_name,
                              hs.hocsinh_id,
                              l.lop_id,
                              hstl.namhoc_id,
                              l.coso_id
                          }).FirstOrDefault();
        var getMail = (from a in db.admin_Users
                       join gvtl in db.tbGiaoVienTrongLops on a.username_id equals gvtl.taikhoan_id
                       where gvtl.namhoc_id == checkNamHoc.namhoc_id && gvtl.lop_id == checkNamHoc.namhoc_id
                       select a);
        String listMail = String.Join(",", getMail.Select(x => x.username_email).ToArray());

        if (db.tbVietNhatKids_DangKyNgoaiKhoas.Any(x => x.hstl_id == getHocSinh.hstl_id
                                                  && x.namhoc_id == checkNamHoc.namhoc_id
                                                  && x.ngoaikhoa_id == Convert.ToInt32(txtngoaiKhoa_id.Value)
                                                  && x.dangkingoaikhoa_cate == "dang ki"))
            alert.alert_Warning(Page, "Ba mẹ đã đăng ký chương trình này! Vui lòng chờ xác nhận từ nhà trường", "");
        else
        {
            tbVietNhatKids_DangKyNgoaiKhoa insert = new tbVietNhatKids_DangKyNgoaiKhoa();
            insert.hstl_id = getHocSinh.hstl_id;
            insert.lop_id = getHocSinh.lop_id;
            insert.namhoc_id = getHocSinh.namhoc_id;
            insert.hocsinh_id = getHocSinh.hocsinh_id;
            insert.namhoc_id = checkNamHoc.namhoc_id;
            insert.ngoaikhoa_id = Convert.ToInt32(txtngoaiKhoa_id.Value);
            insert.dangkingoaikhoa_cate = "dang ki";
            insert.dangkyngoaikhoa_tinhtrang = 0;
            db.tbVietNhatKids_DangKyNgoaiKhoas.InsertOnSubmit(insert);
            db.SubmitChanges();
            alert.alert_Success(Page, "Đăng ký thành công! Vui lòng chờ xác nhận của nhà trường", "");
            String message = "Bạn có thông tin đăng ký ngoại khóa mới từ phụ huynh bé" + checkUserId.hocsinh_name + ".  Xem chi tiết <a href='http://quantrimamnon.vietnhatschool.edu.vn/admin-danh-sach-dang-ky-chuong-trinh-ngoai-khoa'>tại đây.</a>";
            // SendMail(listEmail + ", ducpn@vjis.edu.vn, quyetlv@vjis.edu.vn", message);
        }
    }
    protected void btnKhongDangKy_ServerClick(object sender, EventArgs e)
    {
        var checkNamHoc = (from nh in db.tbHoctap_NamHocs orderby nh.namhoc_id descending select nh).First();
        var checkUserId = (from hs in db.tbHocSinhs
                           where hs.hocsinh_taikhoan == Request.Cookies["web_hocsinh"].Value
                           select hs).First();
        var getHocSinh = (from hs in db.tbHocSinhs
                          join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                          join l in db.tbLops on hstl.lop_id equals l.lop_id
                          where hstl.hocsinh_id == checkUserId.hocsinh_id &&
                          hstl.namhoc_id == checkNamHoc.namhoc_id
                          orderby hstl.hocsinh_id descending
                          select new
                          {
                              hstl.hstl_id,
                              hs.hocsinh_name,
                              hs.hocsinh_id,
                              l.lop_id,
                              hstl.namhoc_id,
                              l.coso_id
                          }).FirstOrDefault();

        var getMail = (from a in db.admin_Users
                       join gvtl in db.tbGiaoVienTrongLops on a.username_id equals gvtl.taikhoan_id
                       where gvtl.namhoc_id == checkNamHoc.namhoc_id && gvtl.lop_id == checkNamHoc.namhoc_id
                       select a);
        String listMail = String.Join(",", getMail.Select(x => x.username_email).ToArray());

        if (db.tbVietNhatKids_DangKyNgoaiKhoas.Any(x => x.hstl_id == getHocSinh.hstl_id
                                                && x.namhoc_id == checkNamHoc.namhoc_id
                                                && x.ngoaikhoa_id == Convert.ToInt32(txtngoaiKhoa_id.Value)
                                                && x.dangkingoaikhoa_cate == "khong dang ki"))
            alert.alert_Warning(Page, "Ba mẹ đã gửi yêu cầu không đăng ký chương trình này! Vui lòng chờ xác nhận từ nhà trường", "");
        else
        {
            tbVietNhatKids_DangKyNgoaiKhoa insert = new tbVietNhatKids_DangKyNgoaiKhoa();
            insert.hstl_id = getHocSinh.hstl_id;
            insert.lop_id = getHocSinh.lop_id;
            insert.namhoc_id = getHocSinh.namhoc_id;
            insert.hocsinh_id = getHocSinh.hocsinh_id;
            insert.namhoc_id = checkNamHoc.namhoc_id;
            insert.ngoaikhoa_id = Convert.ToInt32(txtngoaiKhoa_id.Value);
            insert.dangkingoaikhoa_cate = "khong dang ki";
            insert.dangkyngoaikhoa_tinhtrang = 0;
            db.tbVietNhatKids_DangKyNgoaiKhoas.InsertOnSubmit(insert);
            db.SubmitChanges();
            alert.alert_Success(Page, "Gửi yêu cầu thành công! Vui lòng chờ xác nhận của nhà trường", "");
            String message = "Bạn có thông tin đăng ký ngoại khóa mới từ phụ huynh bé" + checkUserId.hocsinh_name + ".  Xem chi tiết <a href='http://quantrimamnon.vietnhatschool.edu.vn/admin-danh-sach-dang-ky-chuong-trinh-ngoai-khoa'>tại đây.</a>";
            // SendMail(listEmail + ", ducpn@vjis.edu.vn, quyetlv@vjis.edu.vn", message);
        }
    }
    protected void btnTuVan_ServerClick(object sender, EventArgs e)
    {
        db.Connection.Open();
        using (var transaction = db.Connection.BeginTransaction())
        {
            db.Transaction = transaction;
            try
            {
                var checkuserid = (from u in db.tbHocSinhs 
                                   where u.hocsinh_taikhoan == Request.Cookies["web_hocsinh"].Value 
                                   select u).First();
                var checkNamHoc = (from nh in db.tbHoctap_NamHocs orderby nh.namhoc_id descending select nh).First();
                var getHocSinh = (from hs in db.tbHocSinhs
                                  join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                                  where hs.hocsinh_id == checkuserid.hocsinh_id && hstl.hidden == false
                                   && hstl.namhoc_id == checkNamHoc.namhoc_id
                                  orderby hstl.hstl_id descending
                                  select new
                                  {
                                      hs.hocsinh_name,
                                      hs.hocsinh_tenme,
                                      hstl.hstl_id,
                                      hs.hocsinh_id,
                                      hstl.lop_id,
                                  }).FirstOrDefault();

                if (db.tbVietNhatKids_Tu_Van_NgoaiKhoas.Any(x => x.hstl_id == getHocSinh.hstl_id 
                && x.ngoaikhoa_id == Convert.ToInt32(txtngoaiKhoa_id.Value) 
                && x.namhoc_id == checkNamHoc.namhoc_id))
                {
                    alert.alert_Warning(Page, "Ba mẹ đã đăng ký thông tin tư vấn chương trình này! Vui lòng chờ xác nhận từ nhà trường", "");
                }
                else
                {
                    tbVietNhatKids_Tu_Van_NgoaiKhoa insert = new tbVietNhatKids_Tu_Van_NgoaiKhoa();
                    insert.hstl_id = getHocSinh.hstl_id;
                    insert.ngoaikhoa_id =Convert.ToInt32( txtngoaiKhoa_id.Value);
                    insert.tuvan_ngoaikhoa_createdate = DateTime.Now;
                    insert.hocsinh_id = getHocSinh.hocsinh_id;
                    insert.lop_id = getHocSinh.lop_id;
                    insert.namhoc_id = checkNamHoc.namhoc_id;
                    insert.tuvan_ngoaikhoa_tinhtrang = 0; //chưa được vp xác nhận
                    db.tbVietNhatKids_Tu_Van_NgoaiKhoas.InsertOnSubmit(insert);
                    db.SubmitChanges();
                    var getEmail = from u in db.admin_Users
                                   join gvtl in db.tbGiaoVienTrongLops on u.username_id equals gvtl.taikhoan_id
                                   where gvtl.namhoc_id == checkNamHoc.namhoc_id && gvtl.lop_id == getHocSinh.lop_id
                                   select u;
                    string listEmail = string.Join(",", getEmail.Select(x => x.username_email).ToArray());
                    string message = "Bạn có 1 thông báo tư vấn ngoại khóa từ phụ huynh bé " + getHocSinh.hocsinh_name + ". Xem chi tiết <a href='http://quantrimamnon.vietnhatschool.edu.vn/admin-danh-sach-dang-ky-tu-van-ngoai-khoa'>tại đây.</a>";
                    //SendMail(listEmail + ", quyetlv@vjis.edu.vn", message);
                    alert.alert_Success(Page, "Đã gửi thông tin tư vấn đến nhà trường", "Phụ huynh vui lòng chờ nhà trường liên hệ");
                    transaction.Commit();
                }
            }
            catch
            {
                transaction.Rollback();
            }
        }
    }
    private bool SendMail(string email, string message)
    {
        if (email != "")
        {
            try
            {
                var fromAddress = "thongbaovietnhatschool@gmail.com";//  Email Address from where you send the mail 
                var toAddress = email;
                const string fromPassword = "neiabcekdjluofid";
                string subject, title;
                title = "Thông báo";
                subject = "<!DOCTYPE html><html><head><title></title></head><body ><div>" +
                "<h3 style=\"margin-top:0px; text-align:center; color:#029ada\">" + message + "</h3>" +
                "</div></body></html>";
                var smtp = new System.Net.Mail.SmtpClient();
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                    smtp.Timeout = 20000;
                }
                MailMessage mm = new MailMessage();
                mm.From = new MailAddress(fromAddress, "Trường Mầm non Việt Nhật");
                mm.Subject = title;
                mm.To.Add(toAddress);
                mm.IsBodyHtml = true;
                mm.Body = subject;
                smtp.Send(mm);
                return true;
            }
            catch
            {
                return false;
            }
        }
        else
            return false;
    }

    protected void btnXem_ServerClick(object sender, EventArgs e)
    {

    }
}