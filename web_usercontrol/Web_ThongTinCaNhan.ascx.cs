using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_usercontrol_Web_ThongTinCaNhan : System.Web.UI.UserControl
{
   
   
        dbcsdlDataContext db = new dbcsdlDataContext();
    public string sdt = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["web_hocsinh"] != null)
        {
            sdt = Request.Cookies["web_hocsinh"].Value;
            //lấy năm học hiện tại
            var checkNamHoc = (from nh in db.tbHoctap_NamHocs
                               orderby nh.namhoc_id descending
                               select nh).First();
            var getData = (from hs in db.tbHocSinhs
                           join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                           join l in db.tbLops on hstl.lop_id equals l.lop_id
                           where hs.hocsinh_taikhoan == sdt && hs.hocsinh_tinhtrang == null
                           && hstl.namhoc_id == checkNamHoc.namhoc_id 
                           orderby hs.hocsinh_id descending
                           select new
                           {
                               hs.hocsinh_name,
                               l.lop_name,
                               hs.hocsinh_bietdanh,
                               hs.hocsinh_sothichtainha,
                               hs.hocsinh_sothichtaitruong,
                               tuoi = DateTime.Now.Year - hs.hocsinh_ngaysinh.Value.Year + " tuổi",
                               hstl.lop_id
                           });
            lblHoTen.Text = getData.FirstOrDefault().hocsinh_name;
            //lblHoTencp.Text = getData.FirstOrDefault().hocsinh_name;
            lblLop.Text = getData.FirstOrDefault().lop_name;
            lblBietDanh.Text = getData.FirstOrDefault().hocsinh_bietdanh;
            lblSoThichONha.Text = getData.FirstOrDefault().hocsinh_sothichtainha;
            lblSoThichOTruong.Text = getData.FirstOrDefault().hocsinh_sothichtaitruong;
            lblTuoi.Text = getData.FirstOrDefault().tuoi;
            lblLop2.Text = getData.FirstOrDefault().lop_name;
            //lblLop2cp.Text = "Giáo viên:";
            //rpAnh.DataSource = getData;
            //rpAnh.DataBind();
            //var getGiaoVien = from gvtl in db.tbGiaoVienTrongLops
            //                  join u in db.admin_Users on gvtl.taikhoan_id equals u.username_id
            //                  where gvtl.namhoc_id == checkNamHoc.namhoc_id && gvtl.lop_id == getData.FirstOrDefault().lop_id
            //                  select new
            //                  {
            //                      giaovien_name = u.username_fullname,
            //                      u.username_phone,
            //                  };
            //rpGiaoVien.DataSource = getGiaoVien;
            //rpGiaoVien.DataBind();
            //rpGiaoViencp.DataSource = getGiaoVien;
            //rpGiaoViencp.DataBind();

        }
        else
        {
            //Response.Redirect("/website-trang-chu");
        }
    }
}