using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_DiemDanh_module_DanhSachHocSinhAnSang : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
    private int _idCoSo;
    private int _idUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
            _idCoSo = Convert.ToInt32(checkuserid.coso_id);
            _idUser = checkuserid.username_id;
            if (!IsPostBack)
            {
                Session["_id"] = 0;
            }
            loadData();
        }
        else
        {
            Response.Redirect("/admin-login");
        }

    }
    private void loadData()
    {
        var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
        var checkNamHoc = (from nh in db.tbHoctap_NamHocs orderby nh.namhoc_id descending select nh).First();
        var getData = from hs in db.tbHocSinhs
                      join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                      join l in db.tbLops on hstl.lop_id equals l.lop_id
                      join gvtl in db.tbGiaoVienTrongLops on l.lop_id equals gvtl.lop_id
                      join an in db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs on hstl.hstl_id equals an.hstl_id
                      where an.ansang_hidden == null
                      && hstl.namhoc_id == checkNamHoc.namhoc_id
                      && gvtl.namhoc_id == checkNamHoc.namhoc_id && gvtl.taikhoan_id == checkuserid.username_id
                      //&& an.coso_id== _idCoSo
                      //orderby an.ansang_id descending
                      select new
                      {
                          an.ansang_id,
                          hs.hocsinh_name,
                          an.ansang_datecreate,
                          an.ansang_dateend,
                          l.lop_name,
                          an.ansang_tinhtrang,
                          an.uongsua_tinhtrang,
                          trangthaihuy = an.ansang_ngayapdunghuy!=null?"Đã đăng kí hủy":"",
                      };
        lblTongHocSinh.Text = getData.Count() + "";
        grvList.DataSource = getData;
        grvList.DataBind();
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        cls_AnSang cls;
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "ansang_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                cls = new cls_AnSang();
                if (cls.Linq_Xoa(Convert.ToInt32(item)))
                {
                    alert.alert_Success(Page, "Xóa thành công", "");
                    //loadData();
                }
                else
                    alert.alert_Error(Page, "Xóa thất bại", "");
            }
            loadData();
        }
        else
            alert.alert_Warning(Page, "Bạn chưa chọn dữ liệu", "");

    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        //cls_NewsCate cls = new cls_NewsCate();

    }
    protected void btnNhap_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin-dang-ki-an-sang");
    }

}