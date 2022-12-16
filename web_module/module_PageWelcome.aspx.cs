using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_VietNhatKids_module_PageWelcome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["HocSinh"] != null)
            {
                Response.Redirect("/login-viet-nhat-kids");
            }
        }
    }
}