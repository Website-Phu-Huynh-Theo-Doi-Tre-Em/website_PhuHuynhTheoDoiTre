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
    public int _idNamHoc;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["web_hocsinh"] != null)
        {
            var checkuserid = (from u in db.tbHocSinhs
                               where u.hocsinh_taikhoan == Request.Cookies["web_hocsinh"].Value
                               && u.hocsinh_tinhtrang == null
                               orderby u.hocsinh_id descending
                               select u).First();
            _Id_HocSinh = checkuserid.hocsinh_id;
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
                            where hs.hocsinh_id == _Id_HocSinh && hstl.hstl_tinhtrang == null
                             && hstl.namhoc_id == checkNamHoc.namhoc_id
                            orderby hstl.hstl_id descending
                            select new
                            {
                                hs.hocsinh_name,
                                l.lop_name,
                                hstl.hstl_id,
                                hstl.lop_id
                            }).FirstOrDefault();
        var getData = from an in db.tbDangKiAnhSangs
                      where an.hstl_id == checkHocSinh.hstl_id 
                      orderby an.ansang_id descending
                      select new
                      {
                          an.ansang_id,
                          an.ansang_ngayduyet,
                          an.ansang_thangdangky,
                          trangthai = an.dangkyansang_tinhtrang == true ? " <i title=\"Đã xác nhận\" style=\" color: forestgreen;\" class='fas fa-check-circle'></i>" : "<i title=\"Chờ xác nhận\" style=\"color:#ffc107\" class='fas fa-hourglass'></i>",
                      };
        if (getData.Count() > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "btnShow()", true);
        }
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
                                hs.hocsinh_name,
                                l.lop_name

                            }).FirstOrDefault();
        var getEmail = from u in db.admin_Users
                       join gvtl in db.tbGiaoVienTrongLops on u.username_id equals gvtl.taikhoan_id
                       join l in db.tbLops on gvtl.lop_id equals l.lop_id
                       where gvtl.lop_id == checkhocsinh.lop_id && gvtl.namhoc_id == checknamhoc.namhoc_id
                       select u;
        string listEmail = string.Join(",", getEmail.Select(x => x.username_email).ToArray());
        tbDangKiAnhSang insert = new tbDangKiAnhSang();
        //insert.ansang_datecreate = DateTime.Now;
        insert.hstl_id = checkhocsinh.hstl_id;
        insert.dangkyansang_tinhtrang = false;
        insert.ansang_thangdangky = ((DateTime.Now.Month + 1)%12) + "/" + DateTime.Now.Year;
       
        db.tbDangKiAnhSangs.InsertOnSubmit(insert);
        db.SubmitChanges();
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Đăng kí hàng thành công!','','success').then(function(){window.location.reload();parent.location.href='/website-dang-ki-an-sang';})", true);
        //ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Đăng kí thành công! Vui lòng chờ GVCN xác nhận!','','success').function(){parent.location.href='/website-dang-ki-an-sang';window.location.reload();})", true);

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
                                hs.hocsinh_name,
                                l.lop_name

                            }).FirstOrDefault();
        var getEmail = from u in db.admin_Users
                       join gvtl in db.tbGiaoVienTrongLops on u.username_id equals gvtl.taikhoan_id
                       join l in db.tbLops on gvtl.lop_id equals l.lop_id
                       where gvtl.lop_id == checkhocsinh.lop_id && gvtl.namhoc_id == checknamhoc.namhoc_id
                       select u;
        string listEmail = string.Join(",", getEmail.Select(x => x.username_email).ToArray());
        tbDangKiAnhSang del = (from a in db.tbDangKiAnhSangs
                                 where a.hstl_id == checkhocsinh.hstl_id && a.ansang_thangdangky.Substring(0, a.ansang_thangdangky.IndexOf("/")) == ((DateTime.Now.Month + 1)%12).ToString()
                                 select a).FirstOrDefault();
        db.tbDangKiAnhSangs.DeleteOnSubmit(del);

        db.SubmitChanges();
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Hủy thành công! Vui lòng chờ GVCN xác nhận!','','success').function(){window.location.reload();parent.location.href='/website-dang-ki-an-sang';})", true);
        btnHuyDangKy.Visible = false;
        btnDangKy.Visible = true;
        string message = "Bạn có đăng ký hủy ăn sáng mới từ phụ huynh bé " + checkhocsinh.hocsinh_name + ". Xem chi tiết <a href='http://quantrimamnon.vietnhatschool.edu.vn/admin-danh-sach-huy-dang-ky-an-sang'>tại đây.</a>";
        SendMail("dangbichlai21@gmail.com", message);



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