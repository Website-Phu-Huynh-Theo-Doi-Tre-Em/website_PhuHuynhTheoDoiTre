using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_website_VietNhatKids_web_QuenMatKhau : System.Web.UI.Page
{
    cls_Alert alert = new cls_Alert();
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_security md5 = new cls_security();

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnGui_ServerClick(object sender, EventArgs e)
    {
        // gửi mật khẩu mới về email     

        var mail = txtEmail.Value.Trim();
        var checkMail = from hs in db.tbHocSinhs
                        where (hs.hocsinh_emaillba == mail || hs.hocsinh_emailme == mail) && hs.hocsinh_tinhtrang == null
                        select hs;
        if (checkMail.Count() == 1)
        {
            Random rnd = new Random();
            string newPassword = rnd.Next(0, 1000000).ToString();
            //xác nhận mã
            string message = "Mật khẩu mới của bạn là: " + newPassword + " .Vui lòng xác nhận để đăng nhập vào hệ thống!";
            SendMail(mail, message);
            string passmd5 = md5.HashCode(newPassword);
            tbHocSinh update = checkMail.First();
            update.hocsinh_pass = passmd5;
            db.SubmitChanges();
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Gửi Email thành công! Vui lòng xác nhận và đăng nhập','','success').then(function(){parent.location.href='/website-dang-nhap';})", true);
        }
        else if (checkMail.Count() > 1)
        {
            alert.alert_Warning(Page, "Email bị trùng vui lòng kiểm tra lại!", "");
        }
        else
        {
            alert.alert_Warning(Page, "Email chưa được đăng kí tài khoản.Vui lòng liên hệ giáo viên chủ nhiệm để đăng kí!", "");
            
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

    protected void A1_ServerClick(object sender, EventArgs e)
    {

    }
}
