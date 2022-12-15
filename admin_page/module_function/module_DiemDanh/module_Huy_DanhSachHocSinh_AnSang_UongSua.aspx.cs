using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_DiemDanh_module_Huy_DanhSachHocSinh_AnSang_UongSua : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    cls_AnSang cls = new cls_AnSang();
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
        var checkNamHoc = (from nh in db.tbHoctap_NamHocs orderby nh.namhoc_id descending select nh).FirstOrDefault();
        //(from gvtl in db.tbGiaoVienTrongLops
        // join l in db.tbLops on gvtl.lop_id equals l.lop_id
        // join user in db.admin_Users on gvtl.taikhoan_id equals user.username_id
        // where user.username_username == Request.Cookies["UserName"].Value
        // && gvtl.namhoc_id == checkNamHoc.namhoc_id
        // select l).SingleOrDefault().lop_name;
        var getData = from hs in db.tbHocSinhs
                      join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                      join gvtl in db.tbGiaoVienTrongLops on hstl.lop_id equals gvtl.lop_id
                      join user in db.admin_Users on gvtl.taikhoan_id equals user.username_id
                      join l in db.tbLops on hstl.lop_id equals l.lop_id
                      join an in db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs on hstl.hstl_id equals an.hstl_id
                      where hstl.namhoc_id == checkNamHoc.namhoc_id && gvtl.namhoc_id == checkNamHoc.namhoc_id
                      && user.username_username == Request.Cookies["UserName"].Value
                      && an.coso_id == _idCoSo && an.ansang_ngayapdunghuy ==null
                      select new
                      {
                          an.ansang_id,
                          hs.hocsinh_name,
                          an.ansang_datecreate,
                          an.ansang_dateend,
                          l.lop_name,
                          an.ansang_tinhtrang,
                          an.uongsua_tinhtrang
                      };
        grvList.DataSource = getData;
        grvList.DataBind();
    }
    protected void btnHuyAnSang_Click(object sender, EventArgs e)
    {

        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "ansang_id" });
        if (dteNgayBatDau.Value == "")
        {
            alert.alert_Warning(Page, "Vui lòng chọn ngày bắt đầu", "");
        }
        else if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                if (cls.Linq_HuyAnSang(Convert.ToInt32(item), Convert.ToDateTime(dteNgayBatDau.Value)))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Hủy thành công!','','success').then(function(){grvList.UnselectRows();})", true);
                    loadData();
                }
                else
                    alert.alert_Error(Page, "Hủy thất bại", "");
            }
        }
        else
            alert.alert_Warning(Page, "Bạn chưa chọn dữ liệu", "");
    }

    protected void btnHuyUongSua_Click(object sender, EventArgs e)
    {
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "ansang_id" });
        if (dteNgayBatDau.Value == "")
        {
            alert.alert_Warning(Page, "Vui lòng chọn ngày bắt đầu", "");
        }
        else if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                if (cls.Linq_HuyUongSua(Convert.ToInt32(item), Convert.ToDateTime(dteNgayBatDau.Value)))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Hủy thành công!','','success').then(function(){grvList.UnselectRows();})", true);
                    loadData();
                }
                else
                    alert.alert_Error(Page, "Hủy thất bại", "");
            }
        }
        else
            alert.alert_Warning(Page, "Bạn chưa chọn dữ liệu", "");
    }

    protected void btnHuyAnSangUongSua_Click(object sender, EventArgs e)
    {
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "ansang_id" });
        if (dteNgayBatDau.Value == "")
        {
            alert.alert_Warning(Page, "Vui lòng chọn ngày bắt đầu hủy", "");
        }
        else if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                if (cls.Linq_HuyAnSanUongSua(Convert.ToInt32(item), Convert.ToDateTime(dteNgayBatDau.Value)))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Hủy thành công!','','success').then(function(){grvList.UnselectRows();})", true);
                    loadData();
                }
                else
                    alert.alert_Error(Page, "Hủy thất bại", "");
            }
        }
        else
            alert.alert_Warning(Page, "Bạn chưa chọn dữ liệu", "");
    }
}