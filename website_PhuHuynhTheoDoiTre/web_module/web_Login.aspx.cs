using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_website_VietNhatKids_web_Login : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_Gui_ServerClick(object sender, EventArgs e)
    {
        cls_security md5 = new cls_security();
        var user = txtSDT.Value.Trim();
        //var pass = md5.HashCode(txtMatKhau.Value.Trim());
        var pass = txtMatKhau.Value.Trim();

        var getAcount = from tk in db.tbHocSinhs
                        where tk.hocsinh_taikhoan == user && pass == tk.hocsinh_pass
                        select tk;
        if (getAcount.Count() == 1)
        {
            HttpCookie taikhoan = new HttpCookie("PhuHuynhHocSinh");
            taikhoan.Value = user;
            taikhoan.Expires = DateTime.Now.AddDays(365);
            Response.Cookies.Add(taikhoan);
            Response.Redirect("/website_PhuHuynhTheoDoiTre/web_module/web_Trangchu.aspx");
        }
        else if (getAcount.Count() > 1)
        {
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Tài khoản bị trùng!','','warning')", true);


        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Mật khẩu hoặc số điện thoại không đúng!','','warning')", true);
        }
    }

    protected void Unnamed_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("/website-vietnhatkids-ForgetPassword");
    }
}