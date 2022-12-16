using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_website_VietNhatKids_web_ForgetPassword : System.Web.UI.Page
{
    cls_Alert alert = new cls_Alert();
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_security md5 = new cls_security();
    protected void Page_Load(object sender, EventArgs e)
    {
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

 



    protected void btnSendEmail_ServerClick(object sender, EventArgs e)
    {

        // gửi mật khẩu mới về email     
        //random mk mới
        Random rnd = new Random();
        string newPassword = rnd.Next(0, 1000000).ToString();
        string message = "Mã OTP của bạn là:" + newPassword;
        SendMail("dangbichlai21@gmail.com", message);


    }
}