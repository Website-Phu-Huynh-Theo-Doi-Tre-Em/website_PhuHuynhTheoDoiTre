using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_usercontrol_WebUserControl : System.Web.UI.UserControl
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert Al = new cls_Alert();
    private static int id_Lop;
    private static int id_nam;
    public int sothongbao, namhoc_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        //check đã đọc thông báo chưa
        // nếu chưa đọc thì hiển thị số thông báo mới lên
        // nếu đọc rồi thì mất số luôn
        if (Request.Cookies["web_hocsinh"] != null)
        {
           
                namhoc_id = (from nm in db.tbHoctap_NamHocs
                             orderby nm.namhoc_id descending
                             select nm.namhoc_id).First();

                //Lay so thong bao moi
                
        }
        else
        {
            Response.Redirect("/website-vietnhatkids-login");
        }
    }

 
}