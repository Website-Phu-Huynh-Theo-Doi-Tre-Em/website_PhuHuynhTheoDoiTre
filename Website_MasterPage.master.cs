using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Website_MasterPage : System.Web.UI.MasterPage
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    cls_security md5 = new cls_security();
    private int hocsinh_id;
    private int namhoc_id;
    string image, tenhocsinh;
    private string pass = "";
    public string ten = "", bietdanh = "", sothichn = "", sothicht = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["web_hocsinh"] != null)
        {
            hocsinh_id = (from hs in db.tbHocSinhs
                          where hs.hocsinh_taikhoan == Request.Cookies["web_hocsinh"].Value
                          && hs.hocsinh_tinhtrang == null
                          orderby hs.hocsinh_id descending
                          select hs.hocsinh_id).FirstOrDefault();

            var checkNamHoc = (from nh in db.tbHoctap_NamHocs
                               orderby nh.namhoc_id descending
                               select nh).First();
            namhoc_id = checkNamHoc.namhoc_id;

            liDangNhap.Style.Add("display", "none");
            liUser.Style.Add("display", "inline-block");
            var getUsername = (from u in db.tbHocSinhs
                               join hstl in db.tbHocSinhTrongLops on u.hocsinh_id equals hstl.hocsinh_id
                               where u.hocsinh_taikhoan == Request.Cookies["web_hocsinh"].Value && hstl.namhoc_id == namhoc_id
                               && u.hocsinh_tinhtrang == null
                               select u);
            lblAcount.Text = getUsername.FirstOrDefault().hocsinh_name;
            pass = getUsername.FirstOrDefault().hocsinh_pass;
            if (!IsPostBack)
            {
                //txtNamecp.Value = getData.FirstOrDefault().hocsinh_name;
                txtBietDanh.Value = getUsername.FirstOrDefault().hocsinh_bietdanh;
                txtBietDanhcp.Value = getUsername.FirstOrDefault().hocsinh_bietdanh;
                txtStNha.Value = getUsername.FirstOrDefault().hocsinh_sothichtainha;
                txtStNhacp.Value = getUsername.FirstOrDefault().hocsinh_sothichtainha;
                txtStTruong.Value = getUsername.FirstOrDefault().hocsinh_sothichtaitruong;
                txtStTruongcp.Value = getUsername.FirstOrDefault().hocsinh_sothichtaitruong;
            }

        }


    }
    private void getTinTuc()
    {
    }
    protected void btn_Login(object sender, EventArgs e)
    {
        cls_security md5 = new cls_security();
        var sdt = txtSDT.Value.Trim();
        var mk = md5.HashCode(txtMatKhau.Value.Trim());

        var check_User = from u in db.tbHocSinhs
                         where u.hocsinh_pass == mk && u.hocsinh_taikhoan == sdt && u.hocsinh_tinhtrang == null
                         select u;
        if (check_User.Count() == 1)
        {
            HttpCookie taikhoan = new HttpCookie("web_hocsinh");
            taikhoan.Value = sdt;
            taikhoan.Expires = DateTime.Now.AddDays(365);
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



    protected void btnHuy_ServerClick(object sender, EventArgs e)
    {
        //txtMKXacNhan.Value =;
        //txtMKMoi.Value = "";
        //txtMKCu.Value = "";
    }

    protected void btnCapNhat_ServerClick(object sender, EventArgs e)
    {
        if( txtMKCu.Value == pass)
        {
            if (txtMKMoi.Value == txtMKXacNhan.Value)
            {
                tbHocSinh update = (from hs in db.tbHocSinhs
                                    where hs.hocsinh_id == hocsinh_id && hs.hocsinh_tinhtrang == null
                                    select hs).FirstOrDefault();
                var mkmd5 =txtMKMoi.Value;
                update.hocsinh_pass = mkmd5;
                db.SubmitChanges();
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Cập nhật thành công !!','','success').then(function(){HiddenLoadingIcon();parent.location.href='/website-vietnhatkids-login'})", true);



            }
            else
            {
                //alert.alert_Error(Page, "Mật khẩu xác nhận không khớp!", "");
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Mật khẩu xác nhận không khớp!!','','warning').then(function(){showEditPassword();HiddenLoadingIcon()})", true);

            }
        }
        else
        {
            //alert.alert_Error(Page, "Mật khẩu cũ không đúng!", "");
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Mật khẩu cũ không đúng!!','','warning').then(function(){showEditPassword();HiddenLoadingIcon()})", true);
        }
    }



    protected void btnDangXuat_ServerClick(object sender, EventArgs e)
    {
        HttpCookie ck = new HttpCookie("web_hocsinh");
        ck.Value = "";
        ck.Expires = DateTime.Now.AddDays(-1);
        Response.Cookies.Add(ck);
        Response.Redirect("/website-trang-chu");
    }

    protected void btnCapNhatTTCaNhan_ServerClick(object sender, EventArgs e)
    {
        try
        {
            
            tbHocSinh update = (from hs in db.tbHocSinhs
                                where hs.hocsinh_id == hocsinh_id && hs.hocsinh_tinhtrang == null
                                select hs).FirstOrDefault();
            update.hocsinh_bietdanh = txtBietDanh.Value;
            update.hocsinh_sothichtainha = txtStNha.Value;
            update.hocsinh_sothichtaitruong = txtStTruong.Value;
            db.SubmitChanges();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "AlertBox", "swal('Cập nhật thành công!', '','success').then(function(){window.location = '';})", true);

        }
        catch (Exception ex)
        {
            throw;
        }
    }


    protected void liSoLienLacDienTu_ServerClick(object sender, EventArgs e)
    {
        if (Request.Cookies["web_hocsinh"] == null)
        {
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Vui lòng đăng nhập','','warning').then(function(){openForm();})", true);
        }
        else
        {
            // ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "sessionStorage.clear();sessionStorage.setItem('ID', 'ThongBao_0');parent.location.href='/website-vietnhatkids-thong-bao';", true);
            //   ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "chuyentrang", "funcActive0()", true);
            Response.Redirect("/website-thong-bao");
        }
    }
}

