using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class website_PhuHuynhTheoDoiTre_admin_page_admin_Profile : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public string img_src;
    private int id;
    cls_Alert alert = new cls_Alert();
    int user_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["UserName"] != null)
            {
                var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
                id = checkuserid.username_id;
                admin_User update = (from tt in db.admin_Users where tt.username_id == checkuserid.username_id select tt).SingleOrDefault();
                if (update != null)
                {
                    txtHoTen.Value = update.username_fullname;
                    ddlGioiTinh.Value = update.username_gender;
                    txtSoDienThoai.Value = update.username_phone;
                    txtEmail.Value = update.username_email;
                    txtChoOHienTai.Value = update.username_diachi;
                }
                else
                {
                    img_src = "https://quantri.vietnhatschool.edu.vn/admin_images/avatar-truong.png";
                }
            }
        }
    }

    protected void btnLuu_ServerClick(object sender, EventArgs e)
    {
        //admin_User update = (from tt in db.admin_Users where tt.username_id == Convert.ToInt16(RouteData.Values["id"].ToString()) select tt).SingleOrDefault();
        var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
        id = checkuserid.username_id;
        admin_User update = (from u in db.admin_Users where u.username_id == id select u).FirstOrDefault();
        update.username_fullname = txtHoTen.Value;
        update.username_gender = ddlGioiTinh.Value;
        //update.username_ngaysinh = Convert.ToDateTime(txtNgaySinh.Value);
        update.username_phone = txtSoDienThoai.Value;
        update.username_email = txtEmail.Value;
        update.username_diachi = txtChoOHienTai.Value;
        db.SubmitChanges();
        alert.alert_Update(Page, "Đã cập nhật xong", "");
        //try
        //{
        //    if (RouteData.Values["id"].ToString() == "0")
        //    {
        //        admin_User insert = new admin_User();
        //        insert.username_fullname = txtHoTen.Value;
        //        insert.username_gender = ddlGioiTinh.Value;
        //        //insert.username_ngaysinh = Convert.ToDateTime(txtNgaySinh.Value);
        //        insert.username_phone = txtSoDienThoai.Value;
        //        insert.username_email = txtEmail.Value;
        //        insert.username_diachi = txtChoOHienTai.Value;
        //        db.admin_Users.InsertOnSubmit(insert);
        //        db.SubmitChanges();
        //        alert.alert_Success(Page, "Đã hoàn thành", "");
        //    }
        //    else
        //    {
        //        admin_User update = (from tt in db.admin_Users where tt.username_id == Convert.ToInt16(RouteData.Values["id"].ToString()) select tt).SingleOrDefault();
        //        update.username_fullname = txtHoTen.Value;
        //        update.username_gender = ddlGioiTinh.Value;
        //        //update.username_ngaysinh = Convert.ToDateTime(txtNgaySinh.Value);
        //        update.username_phone = txtSoDienThoai.Value;
        //        update.username_email = txtEmail.Value;
        //        update.username_diachi = txtChoOHienTai.Value;
        //        db.SubmitChanges();
        //        alert.alert_Update(Page, "Đã cập nhật xong", "");
        //    }
        //}
        //catch
        //{
        //    alert.alert_Error(Page, "Có lỗi liên hệ IT", "");
        //}
    }
}