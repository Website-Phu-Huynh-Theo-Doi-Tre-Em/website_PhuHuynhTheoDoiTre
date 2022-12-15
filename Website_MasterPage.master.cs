using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Wensite_MasterPage2 : System.Web.UI.MasterPage
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
            liDangNhap.Style.Add("display", "none");
            liUser.Style.Add("display", "inline-block");
            //lấy id học sinh
            hocsinh_id = (from hs in db.tbHocSinhs
                          where hs.hocsinh_taikhoan == Request.Cookies["web_hocsinh"].Value
                          && hs.hidden == null
                          orderby hs.hocsinh_id descending
                          select hs.hocsinh_id).FirstOrDefault();
            //lấy năm hiện tại
            var checkNamHoc = (from nh in db.tbHoctap_NamHocs
                               orderby nh.namhoc_id descending
                               select nh).First();
            namhoc_id = checkNamHoc.namhoc_id;
            //lấy thông tin hs
            var getData = (from hs in db.tbHocSinhs
                           join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                           join l in db.tbLops on hstl.lop_id equals l.lop_id
                           where hs.hocsinh_taikhoan == Request.Cookies["web_hocsinh"].Value && hs.hidden == null
                           && hstl.namhoc_id == checkNamHoc.namhoc_id && hstl.hidden == false
                           //orderby hs.hocsinh_id descending
                           select new
                           {
                               hs.hocsinh_name,
                               hs.hocsinh_bietdanh,
                               hs.hocsinh_sothichtainha,
                               hs.hocsinh_sothichtaitruong,
                               hs.hocsinh_pass,
                               avartar_path = (db.tbVietNhatKids_AvatarHocSinhs.Any(x => x.hocsinh_id == hs.hocsinh_id)) ? (from img in db.tbVietNhatKids_AvatarHocSinhs
                                                                                                                            where img.hocsinh_id == hs.hocsinh_id
                                                                                                                            select img.avartar_path).FirstOrDefault() : "/admin_images/logo_mamnon.png"


                           });
            lblAcount.Text = getData.FirstOrDefault().hocsinh_name;
            lblHoTen.Text = getData.FirstOrDefault().hocsinh_name;
            rpAnh.DataSource = getData;
            rpAnh.DataBind();
            if (!IsPostBack)
            {
                txtName.Value = getData.FirstOrDefault().hocsinh_name;
                //txtNamecp.Value = getData.FirstOrDefault().hocsinh_name;
                txtBietDanh.Value = getData.FirstOrDefault().hocsinh_bietdanh;
                txtBietDanhcp.Value = getData.FirstOrDefault().hocsinh_bietdanh;
                txtStNha.Value = getData.FirstOrDefault().hocsinh_sothichtainha;
                txtStNhacp.Value = getData.FirstOrDefault().hocsinh_sothichtainha;
                txtStTruong.Value = getData.FirstOrDefault().hocsinh_sothichtaitruong;
                txtStTruongcp.Value = getData.FirstOrDefault().hocsinh_sothichtaitruong;
                img_avatar.Attributes["src"] = getData.FirstOrDefault().avartar_path;
            }
            //rpEdit.DataSource = getData;
            //rpEdit.DataBind();
            pass = getData.FirstOrDefault().hocsinh_pass;
            //lblUser.Text = getData.FirstOrDefault().hocsinh_name;
        }
    }
    private void getTinTuc()
    {
        //var getDataMenu = from mn in db.tbWebsite_NewsCates
        //                  select new
        //                  {
        //                      mn.newscate_title,
        //                      mn.newscate_id
        //                  };
        //rpTinTuc.DataSource = getDataMenu;
        //rpTinTuc.DataBind();
    }
    protected void btn_Login(object sender, EventArgs e)
    {
        cls_security md5 = new cls_security();
        var sdt = txtSDT.Value.Trim();
        var mk = md5.HashCode(txtMatKhau.Value.Trim());
        var checkUser = from u in db.tbHocSinhs
                        where u.hocsinh_taikhoan == sdt && u.hidden == null && u.hocsinh_pass == mk
                        select u;
        if (checkUser.Count() == 1)
        {
            HttpCookie taikhoan = new HttpCookie("web_hocsinh");
            taikhoan.Value = sdt;
            taikhoan.Expires = DateTime.Now.AddDays(365);
            Response.Cookies.Add(taikhoan);
            if (Request.Cookies["URL"] != null)
            {
                string url = Request.Cookies["URL"].Value;
                url = url.Substring(27);
                string id = url.Remove(url.Length - 1, 1);
                Response.Cookies["URL"].Expires = DateTime.Now.AddDays(-1);
                Response.Redirect("/hoc-tap-chu-de-loai-game-"+id);
            }
            else
            {
                Response.Redirect("/website-trang-chu");
            }

        }
        else if (checkUser.Count() > 1)
        {
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Tài khoản bị trùng!','','warning').then(function(){openForm()})", true);

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Mật khẩu hoặc số điện thoại không đúng!','','warning').then(function(){openForm()})", true);

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
        if (md5.HashCode(txtMKCu.Value) == pass)
        {
            if (txtMKMoi.Value == txtMKXacNhan.Value)
            {
                tbHocSinh update = (from hs in db.tbHocSinhs
                                    where hs.hocsinh_id == hocsinh_id && hs.hidden == null
                                    select hs).FirstOrDefault();
                var mkmd5 = md5.HashCode(txtMKMoi.Value);
                update.hocsinh_pass = mkmd5;
                db.SubmitChanges();
                //ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Cập nhật thành công!','','warning')", true);
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
            if (Page.IsValid && FileUpload1.HasFile)
            {
                String folderUser = Server.MapPath("~/uploadimages/avatar_hocsinh/" + tenhocsinh + "");
                if (!Directory.Exists(folderUser))
                {
                    Directory.CreateDirectory(folderUser);
                }
                //string filename;
                string ulr = "/uploadimages/avatar_hocsinh/" + tenhocsinh + "/";
                HttpFileCollection hfc = Request.Files;
                string filename = ulr + Path.GetRandomFileName() + Path.GetExtension(FileUpload1.FileName);
                string path = HttpContext.Current.Server.MapPath("~/" + filename);
                FileUpload1.SaveAs(path);
                image = filename;

                if (db.tbVietNhatKids_AvatarHocSinhs.Any(x => x.hocsinh_id == hocsinh_id))
                {
                    tbVietNhatKids_AvatarHocSinh upImage = (from img in db.tbVietNhatKids_AvatarHocSinhs
                                                            where img.hocsinh_id == hocsinh_id
                                                            select img).First();
                    upImage.avartar_path = image;
                    db.SubmitChanges();


                }
                else
                {
                    tbVietNhatKids_AvatarHocSinh insert = new tbVietNhatKids_AvatarHocSinh();
                    insert.hocsinh_id = hocsinh_id;
                    insert.avartar_path = image;
                    db.tbVietNhatKids_AvatarHocSinhs.InsertOnSubmit(insert);
                    db.SubmitChanges();
                }
            }
            tbHocSinh update = (from hs in db.tbHocSinhs
                                where hs.hocsinh_id == hocsinh_id && hs.hidden == null
                                select hs).FirstOrDefault();
            //update.hocsinh_name = txtName.Value;
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
            Response.Redirect("/website-vietnhatkids-thong-bao");
        }
    }
}
