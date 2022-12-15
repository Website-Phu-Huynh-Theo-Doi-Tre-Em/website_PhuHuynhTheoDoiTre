using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_DiemDanh_module_DanhSachHocSinh_HuyDangKi_AnSang_UongSua : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
    private int _idCoSo;
    private int _idUser;
    private int id_NamHoc;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
            _idCoSo = Convert.ToInt32(checkuserid.coso_id);
            _idUser = checkuserid.username_id;
            if (!IsPostBack)
            {
                Session["_id"] = 0;
            }
            loadData();
        }
        else
        {
            Response.Redirect("/admin-login");
        }

    }
    private void loadData()
    {
        var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
        var checkNamHoc = (from nh in db.tbHoctap_NamHocs orderby nh.namhoc_id descending select nh).First();
        id_NamHoc = checkNamHoc.namhoc_id;
        var getData = from hs in db.tbHocSinhs
                      join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                      join l in db.tbLops on hstl.lop_id equals l.lop_id
                      join gvtl in db.tbGiaoVienTrongLops on l.lop_id equals gvtl.lop_id
                      join an in db.tbVietNhatKids_DanhSachHocSinh_HuyAnSangs on hstl.hstl_id equals an.hstl_id
                      where hstl.namhoc_id == checkNamHoc.namhoc_id
                      && gvtl.namhoc_id == checkNamHoc.namhoc_id
                      && gvtl.taikhoan_id == checkuserid.username_id
                      select new
                      {
                          an.huyansang_id,
                          hs.hocsinh_name,
                          an.huyansang_datecreate,
                          l.lop_name,
                          an.huyansang_thangdangky,
                          tinhtrang = an.huyansang_trangthaiduyet == false ? "Chưa xác nhận" : "Đã xác nhận"
                      };
        lblTongHocSinh.Text = getData.Count() + "";
        grvList.DataSource = getData;
        grvList.DataBind();
    }
    protected void btnXacNhan_Click(object sender, EventArgs e)
    {
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "huyansang_id" });
        if (selectedKey.Count == 0)
        {
            alert.alert_Warning(Page, "Bạn chưa chọn dữ liệu", "");
        }
        else if (selectedKey.Count > 1)
        {
            alert.alert_Warning(Page, "Bạn chỉ được chọn 1 dữ liệu để xác nhận", "");
        }
        else
        {
            tbVietNhatKids_DanhSachHocSinh_HuyAnSang xacnhan = db.tbVietNhatKids_DanhSachHocSinh_HuyAnSangs.Where(x => x.huyansang_id == Convert.ToInt32(selectedKey[0])).FirstOrDefault();
            if (xacnhan.huyansang_trangthaiduyet == false)
            {
                xacnhan.huyansang_trangthaiduyet = true;
                xacnhan.huyansang_ngayduyet = DateTime.Now;
                xacnhan.username_id = _idUser;
                var getEmail = (from hs in db.tbHocSinhs
                                join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                                where hstl.hstl_id == xacnhan.hstl_id
                                 && hstl.namhoc_id == id_NamHoc
                                select hs).FirstOrDefault();
                db.SubmitChanges();
                string message = "Thông tin đăng ký ăn sáng của phụ huynh bé " + getEmail.hocsinh_name + " đã được giáo viên chủ nhiệm xác nhận.";
                SendMail(", ducpn@vjis.edu.vn, quyetlv@vjis.edu.vn", message);
            }
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Xác nhận thành công và đã gửi email về cho phụ huynh','','success').then(function(){grvList.UnselectRows();})", true);
            loadData();
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
}