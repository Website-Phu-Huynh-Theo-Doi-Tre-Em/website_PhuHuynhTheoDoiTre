﻿using System;
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
        var sdt = txtSDT.Value.Trim();
        var mk = md5.HashCode(txtMatKhau.Value.Trim());

        var check_User = from u in db.tbHocSinhs
                         where u.hocsinh_pass == mk && u.hocsinh_taikhoan == sdt && u.hocsinh_tinhtrang == null
                         select u;
        if(check_User.Count() == 1)
        {
            //if (checklogin.Checked)
            //{
            //    Response.Cookies["web_hocsinh_sdt"].Value = txtSDT.Value;
            //    Response.Cookies["web_hocsinh_mk"].Value = txtMatKhau.Value;
            //    Response.Cookies["web_hocsinh_sdt"].Expires = DateTime.Now.AddDays(-1);
            //    Response.Cookies["web_hocsinh_mk"].Expires = DateTime.Now.AddDays(-1);
            //}
            //else
            //{
            //    Response.Cookies["web_hocsinh_sdt"].Expires = DateTime.Now.AddDays(-1);
            //    Response.Cookies["web_hocsinh_mk"].Expires = DateTime.Now.AddDays(-1);

            //}
            HttpCookie taikhoan = new HttpCookie("web_hocsinh");
            taikhoan.Value = sdt;
            taikhoan.Expires= DateTime.Now.AddDays(365);
            Response.Cookies.Add(taikhoan);
            Response.Redirect("/website-trang-chu");
        }
        else if (check_User.Count() > 1)
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