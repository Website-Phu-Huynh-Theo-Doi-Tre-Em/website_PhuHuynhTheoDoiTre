using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_ThongKe_GiaoVien_module_ThongKeXacNhanDangKyNgoaiKhoa : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            if (!IsPostBack)
            {
                rpCoSo.DataSource = from cs in db.tbCoSoVietNhats select cs;
                rpCoSo.DataBind();
            }
        }
        else
        {
            Response.Redirect("/admin-login");
        }
    }
    //protected void loadDropDownList()
    //{
    //    var listNamHoc = from nh in db.tbHoctap_NamHocs orderby nh.namhoc_id descending select nh;
    //    ddlNamHoc.Items.Clear();
    //    ddlNamHoc.Items.Insert(0, "Chọn năm học");
    //    ddlNamHoc.AppendDataBoundItems = true;
    //    ddlNamHoc.DataTextField = "namhoc_nienkhoa";
    //    ddlNamHoc.DataValueField = "namhoc_id";
    //    ddlNamHoc.DataSource = listNamHoc;
    //    ddlNamHoc.DataBind();

    //    var listCoSo = from cs in db.tbCoSoVietNhats select cs;
    //    ddlCoSo.Items.Clear();
    //    ddlCoSo.Items.Insert(0, "Chọn cơ sở");
    //    ddlCoSo.AppendDataBoundItems = true;
    //    ddlCoSo.DataTextField = "coso_name";
    //    ddlCoSo.DataValueField = "coso_id";
    //    ddlCoSo.DataSource = listCoSo;
    //    ddlCoSo.DataBind();
    //}
    //protected void loadData()
    //{
    //    var getXacNhan = (from u in db.admin_Users
    //                      join nk in db.tbVietNhatKids_DangKyNgoaiKhoas on u.username_id equals nk.username_id
    //                      where nk.namhoc_id == Convert.ToInt32(ddlNamHoc.SelectedValue) && nk.dangkyngoaikhoa_tinhtrang == 1 && u.coso_id == Convert.ToInt32(ddlCoSo.SelectedValue)
    //                      group u by u.username_id into k
    //                      select new
    //                      {
    //                          username_fullname = (from us in db.admin_Users where us.username_id == k.Key select us.username_fullname).FirstOrDefault(),
    //                          tongXacNhan = (from nkk in db.tbVietNhatKids_DangKyNgoaiKhoas where nkk.username_id == k.Key select nkk).Count(),
    //                          tongDiem = (from nkk in db.tbVietNhatKids_DangKyNgoaiKhoas where nkk.username_id == k.Key select nkk).Count() * 1,
    //                      });

    //    rpThongKeXacNhanNgoaiKhoa.DataSource = getXacNhan;
    //    rpThongKeXacNhanNgoaiKhoa.DataBind();
    //}
    //protected void ddlNamHoc_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    loadData();
    //}

    //protected void ddlCoSo_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    loadData();
    //}
    protected void getData(int cs_id)
    {
        var getDiemNgoaiKhoa = from u in db.admin_Users
                               where u.coso_id == Convert.ToInt16(cs_id) && u.username_active == true
                               select new
                               {
                                   u.username_id,
                                   u.username_fullname,
                                   tongXacNhan = (from nkk in db.tbVietNhatKids_DangKyNgoaiKhoas
                                                  where nkk.username_id == u.username_id
                                                  && nkk.dangkyngoaikhoa_tinhtrang == 1
                                                  select nkk).Count(),
                                   tongDiem = (from nkk in db.tbVietNhatKids_DangKyNgoaiKhoas
                                               where nkk.username_id == u.username_id
                                               && nkk.dangkyngoaikhoa_tinhtrang == 1
                                               select nkk.dangkyngoaikhoa_diemtichluy).Sum(),
                               };
        rpThongKeXacNhanNgoaiKhoa.DataSource = getDiemNgoaiKhoa;
        rpThongKeXacNhanNgoaiKhoa.DataBind();
        rpGiaoVienXacNhanNgoaiKhoa.DataSource = getDiemNgoaiKhoa;
        rpGiaoVienXacNhanNgoaiKhoa.DataBind();
    }
    protected void btnXemCoSo_ServerClick(object sender, EventArgs e)
    {
        getData(Convert.ToInt32(txtCoSo_Id.Value));
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setActive('" + Convert.ToInt32(txtCoSo_Id.Value) + "')", true);
    }

    protected void rpGiaoVienXacNhanNgoaiKhoa_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpChiTietXacNhanNgoaiKhoa = e.Item.FindControl("rpChiTietXacNhanNgoaiKhoa") as Repeater;
        int username_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "username_id").ToString());
        var getChiTiet = (from nkk in db.tbVietNhatKids_DangKyNgoaiKhoas
                          where nkk.username_id == username_id && nkk.dangkyngoaikhoa_tinhtrang == 1
                          select new
                          {
                              nkk.dangkyngoaikhoa_datecreate,
                          });
        rpChiTietXacNhanNgoaiKhoa.DataSource = getChiTiet;
        rpChiTietXacNhanNgoaiKhoa.DataBind();
    }
}