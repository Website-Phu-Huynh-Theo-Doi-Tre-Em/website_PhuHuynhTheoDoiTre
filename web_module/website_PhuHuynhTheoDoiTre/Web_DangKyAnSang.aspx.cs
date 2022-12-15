using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_website_VietNhatKids_Web_DangKyAnSang : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _Id_HocSinh;
    private int _Id_CoSo;
    public int _idNamHoc;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["web_hocsinh"] != null)
        {
            var checkuserid = (from u in db.tbHocSinhs
                               where u.hocsinh_taikhoan == Request.Cookies["web_hocsinh"].Value
                               && u.hidden == null
                               orderby u.hocsinh_id descending
                               select u).First();
            _Id_HocSinh = checkuserid.hocsinh_id;
            _Id_CoSo = Convert.ToInt32(checkuserid.coso_id);
            loadLichSu();
            var getNam = (from nh in db.tbHoctap_NamHocs
                          orderby nh.namhoc_id descending
                          select nh).First();
            _idNamHoc = getNam.namhoc_id;
            lblNam.Text = getNam.namhoc_nienkhoa;


        }
        else
        {
            Response.Redirect("/website-trang-chu");
        }
    }
    private void loadLichSu()
    {
        var checkNamHoc = (from nh in db.tbHoctap_NamHocs orderby nh.namhoc_id descending select nh).First();
        lblNam.Text = checkNamHoc.namhoc_nienkhoa;
        var checkHocSinh = (from hs in db.tbHocSinhs
                            join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                            join l in db.tbLops on hstl.lop_id equals l.lop_id
                            where hs.hocsinh_id == _Id_HocSinh && hstl.hidden == false
                             && hstl.namhoc_id == checkNamHoc.namhoc_id
                            orderby hstl.hstl_id descending
                            select new
                            {
                                hs.hocsinh_name,
                                l.lop_name,
                                hstl.hstl_id,
                                hs.coso_id,
                                hstl.lop_id
                            }).FirstOrDefault();
        var getData = from an in db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs
                      where an.hstl_id == checkHocSinh.hstl_id 
                      orderby an.ansang_datecreate descending
                      select new
                      {
                          an.ansang_id,
                          an.ansang_datecreate,
                          an.ansang_thangdangky,
                          ansang_tinhtrang = an.ansang_tinhtrang == true ? "checked" : "",
                          uongsua_tinhtrang = an.uongsua_tinhtrang == true ? "checked" : "",
                          trangthai = an.ansang_trangthaiduyet == "da duyet" ? " <i title=\"Đã xác nhận\" style=\" color: forestgreen;\" class='fas fa-check-circle'></i>" : "<i title=\"Chờ xác nhận\" style=\"color:#ffc107\" class='fas fa-hourglass'></i>",
                      };
        if (getData.Count() > 0)
        {
            rpDanhSach.DataSource = getData;
            rpDanhSach.DataBind();
            rpChiTiet.DataSource = getData;
            rpChiTiet.DataBind();
            txtKhongDuLieu.Visible = false;
           
        }
        else
        {
            rpDanhSach.DataSource = null;
            rpDanhSach.DataBind();
            rpChiTiet.DataSource = null;
            rpChiTiet.DataBind();
            txtKhongDuLieu.Visible = true;
        }

    }
    protected void btnDangKy_ServerClick(object sender, EventArgs e)
    {
        String tinhtrang = txtTinhTrang.Value;
        db.Connection.Open();
        var checknamhoc = (from n in db.tbHoctap_NamHocs orderby n.namhoc_id descending select n).First();
        var checkhocsinh = (from hs in db.tbHocSinhs
                            join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                            join l in db.tbLops on hstl.lop_id equals l.lop_id
                            where hs.hocsinh_id == _Id_HocSinh && hstl.namhoc_id == checknamhoc.namhoc_id
                            orderby hstl.hocsinh_id descending
                            select new
                            {
                                hstl.hocsinh_id,
                                hstl.hstl_id,
                                hstl.lop_id,
                                hs.coso_id,
                                hs.hocsinh_name,
                                l.lop_name

                            }).FirstOrDefault();
        var getEmail = from u in db.admin_Users
                       join gvtl in db.tbGiaoVienTrongLops on u.username_id equals gvtl.taikhoan_id
                       join l in db.tbLops on gvtl.lop_id equals l.lop_id
                       where gvtl.lop_id == checkhocsinh.lop_id && gvtl.namhoc_id == checknamhoc.namhoc_id
                       select u;
        string listEmail = string.Join(",", getEmail.Select(x => x.username_email).ToArray());
        tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSang insert = new tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSang();
        insert.ansang_datecreate = DateTime.Now;
        if (tinhtrang == "an")
        {
            insert.ansang_tinhtrang = true;
        }
        else if (tinhtrang == "uong")
        {
            insert.uongsua_tinhtrang = true;
        }
        else
        {
            insert.ansang_tinhtrang = true;
            insert.uongsua_tinhtrang = true;
        }
        insert.hstl_id = checkhocsinh.hstl_id;
        insert.coso_id = checkhocsinh.coso_id;
        insert.ansang_trangthaiduyet = "chua duyet";
        insert.ansang_thangdangky = (DateTime.Now.Month + 1) + "/" + DateTime.Now.Year;

        db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs.InsertOnSubmit(insert);
        db.SubmitChanges();
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Gửi thành công! Vui lòng chờ GVCN xác nhận!','','success').then(function(){parent.location.href='/website-vietnhatkids-an-sang-uong-sua';})", true);
        btnDangKy.Visible = false;
        btnHuyDangKy.Visible = true;
    }
    protected void btnHuyDangKy_ServerClick(object sender, EventArgs e)
    {
        db.Connection.Open();
        var checknamhoc = (from n in db.tbHoctap_NamHocs orderby n.namhoc_id descending select n).First();
        var checkhocsinh = (from hs in db.tbHocSinhs
                            join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                            join l in db.tbLops on hstl.lop_id equals l.lop_id
                            where hs.hocsinh_id == _Id_HocSinh && hstl.namhoc_id == checknamhoc.namhoc_id
                            orderby hstl.hocsinh_id descending
                            select new
                            {
                                hstl.hocsinh_id,
                                hstl.hstl_id,
                                hstl.lop_id,
                                hs.coso_id,
                                hs.hocsinh_name,
                                l.lop_name

                            }).FirstOrDefault();
        var getEmail = from u in db.admin_Users
                       join gvtl in db.tbGiaoVienTrongLops on u.username_id equals gvtl.taikhoan_id
                       join l in db.tbLops on gvtl.lop_id equals l.lop_id
                       where gvtl.lop_id == checkhocsinh.lop_id && gvtl.namhoc_id == checknamhoc.namhoc_id
                       select u;
        string listEmail = string.Join(",", getEmail.Select(x => x.username_email).ToArray());
        tbVietNhatKids_DanhSachHocSinh_HuyAnSang insert = new tbVietNhatKids_DanhSachHocSinh_HuyAnSang();
        insert.hstl_id = checkhocsinh.hstl_id;
        insert.coso_id = checkhocsinh.coso_id;
        insert.huyansang_thangdangky = (DateTime.Now.Month + 1) + "/" + DateTime.Now.Year;
        insert.huyansang_trangthaiduyet = false;
        db.tbVietNhatKids_DanhSachHocSinh_HuyAnSangs.InsertOnSubmit(insert);
        db.SubmitChanges();
        alert.alert_Success(Page, "Gửi thành công! Vui lòng chờ GVCN xác nhận", "");
        btnHuyDangKy.Visible = false;
        btnDangKy.Visible = true;
        string message = "Bạn có đăng ký hủy ăn sáng mới từ phụ huynh bé " + checkhocsinh.hocsinh_name + ". Xem chi tiết <a href='http://quantrimamnon.vietnhatschool.edu.vn/admin-danh-sach-huy-dang-ky-an-sang'>tại đây.</a>";
        //SendMail("ducpn@vjis.edu.vn, quyetlv@vjis.edu.vn", message);
        //SendMail(listEmail + ",ducpn@vjis.edu.vn, quyetlv@vjis.edu.vn", message);


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
}