using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class website_PhuHuynhTheoDoiTre_admin_page_module_DanhSachDangKyNgoaiKhoa : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private static int _idNamhoc;
    private int _id;
    private static int id_CoSo;
    private static int _idUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            try
            {
                //get năm học hiện tại
                _idNamhoc = db.tbHoctap_NamHocs.Select(x => x.namhoc_id).ToList().Last();
                var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
                _idUser = checkuserid.username_id;
                if (db.tbGiaoVienTrongLops.Any(gv => gv.taikhoan_id == checkuserid.username_id && gv.namhoc_id == _idNamhoc))
                {
                    int id_Lop = Convert.ToInt32((from u in db.admin_Users
                                                  join gvtl in db.tbGiaoVienTrongLops on u.username_id equals gvtl.taikhoan_id
                                                  where u.username_username == Request.Cookies["UserName"].Value
                                                  && gvtl.namhoc_id == _idNamhoc
                                                  select gvtl).FirstOrDefault().lop_id);
                    loadDataByLop(id_Lop);
                    btnXacNhan.Visible = true;
                }
            }
            catch (Exception ex)
            {
                alert.alert_Error(Page, "Đã xảy ra lỗi, vui lòng liên hệ IT", "");
            }
        }
        else
        {
            Response.Redirect("/Admin_Default.aspx");
        }
    }
    private void loadDataByLop(int lop_id)
    {
        var getData = from dknk in db.tbDangKyNgoaiKhoas
                          //join ctnk in db.tbVietNhatKids_NgoaiKhoas on dknk.ngoaikhoa_id equals ctnk.ngoaikhoa_id
                      join l in db.tbLops on dknk.lop_id equals l.lop_id
                      join hs in db.tbHocSinhs on dknk.hocsinh_id equals hs.hocsinh_id
                      join hstl in db.tbHocSinhTrongLops on dknk.hstl_id equals hstl.hstl_id
                      join nh in db.tbHoctap_NamHocs on dknk.namhoc_id equals nh.namhoc_id
                      where l.lop_id == lop_id /*&& hstl.hidden == false*/
                      //&& dknk.namhoc_id == _idNamhoc && dknk.dangkynangkhieu_cate == ddlLoaiChuongTrinh.SelectedValue
                      orderby dknk.dangkyngoaikhoa_tinhtrang ascending, dknk.dangkyngoaikhoa_datecreate descending
                      select new
                      {
                          dknk.dangkyngoaikhoa_id,
                          dknk.dangkyngoaikhoa_datecreate,
                          //chuongtrinhdangky = dknk.dangkynangkhieu_cate == "hoc ve" ? "Học vẽ" : dknk.dangkynangkhieu_cate == "hoc tieng anh" ? "Học tiếng anh" : "Học aerobic",
                          l.lop_name,
                          l.lop_id,
                          hs.hocsinh_id,
                          hs.hocsinh_name,
                          nh.namhoc_id,
                          nh.namhoc_nienkhoa,
                          //tinhtrang = dknk.dangkyngoaikhoa_tinhtrang == 0 ? "Chưa xác nhận" : "Đã xác nhận"
                      };
        grvList.DataSource = getData;
        grvList.DataBind();
    }

    protected void btnXacNhan_Click(object sender, EventArgs e)
    {
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "dangkynangkhieu_id" }));
        var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
        tbVietNhatKids_DangKyNangKhieu update = db.tbVietNhatKids_DangKyNangKhieus.Where(x => x.dangkynangkhieu_id == _id).FirstOrDefault();
        if (update.dangkynangkhieu_tinhtrang == 1)
        {
            alert.alert_Warning(Page, "Dữ liệu đã xác nhận", "");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "HiddenLoadingIcon()", true);
        }
        else
        {
            update.dangkynangkhieu_tinhtrang = 1;
            update.username_id = checkuserid.username_id;
            update.dangkynangkhieu_diemtichluy = 1;

            var getData = (from dp in db.tbDangKyNgoaiKhoas
                           where dp.dangkynangkhieu_id == _id
                           select dp).FirstOrDefault();
            var getEmail = (from hs in db.tbHocSinhs
                            join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                            where hstl.hstl_id == getData.hstl_id
                             && hstl.namhoc_id == _idNamhoc /*&& hs.hidden == null*/
                            orderby hstl.hstl_id descending
                            select hs).FirstOrDefault();
          
            //gửi mail về cho ph
            db.SubmitChanges();
            string message = "Thông tin đăng ký ngoại khóa của phụ huynh bé " + getEmail.hocsinh_name + " đã được giáo viên chủ nhiệm xác nhận!";
            //SendMail("quyetlv@vjis.edu.vn", message);
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Đã xác nhận thành công','','success').then(function(){grvList.Refresh();grvList.UnselectRows();HiddenLoadingIcon()})", true);
            //ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Đã xác nhận thành công','','success').then(function(){grvList.Refresh();location.reload();})", true);
        }
    }