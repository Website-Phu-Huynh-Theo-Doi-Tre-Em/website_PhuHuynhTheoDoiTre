using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class website_PhuHuynhTheoDoiTre_web_module_Default : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnDangNhap_ServerClick(object sender, EventArgs e)
    {
       alert.alert_Success(Page, "ád", "");
    //    cls_security md5 = new cls_security();
    //    var user = txtUsername.Value.Trim();
    //    var pass = txtPassword.Value.Trim();
    //    alert.alert_Success(Page, "hgfd", "");
    //    var getAcount = from tk in db.tbHocSinhs
    //                    where tk.hocsinh_taikhoan == user && pass == tk.hocsinh_pass
    //                    select tk;
    //    if (getAcount.Count() == 1)
    //    {
    //        HttpCookie taikhoan = new HttpCookie("web_hocsinh");
    //        taikhoan.Value = user;
    //        taikhoan.Expires = DateTime.Now.AddDays(365);
    //        Response.Cookies.Add(taikhoan);
    //        Response.Redirect("/website_PhuHuynhTheoDoiTre/web_module/web_Trangchu.aspx");
    //        alert.alert_Success(Page, "DangNhap Thành Công", "");
    //    }
    //    else if (getAcount.Count() > 1)
    //    {
    //        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Tài khoản bị trùng!','','warning')", true);


    //    }
    //    else
    //    {
    //        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Mật khẩu hoặc số điện thoại không đúng!','','warning')", true);
    //    }
    }
}
    
