using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_ThongKe_GiaoVien_module_ThongKeGiaoVienNhapSucKhoeHangThang : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    private int _IdNamHoc;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Cookies["UserName"] != null)
        {
            var checkNamHoc = (from nh in db.tbHoctap_NamHocs orderby nh.namhoc_id descending select nh).FirstOrDefault();
            _IdNamHoc = checkNamHoc.namhoc_id;
            if (!IsPostBack)
            {
                var listThang = from t in db.tbImage_Liches where t.image_group == 2 select t;
                ddlThang.Items.Clear();
                ddlThang.Items.Insert(0, "Chọn tháng");
                ddlThang.AppendDataBoundItems = true;
                ddlThang.DataTextField = "image_link";
                ddlThang.DataValueField = "image_lich";
                ddlThang.DataSource = listThang;
                ddlThang.DataBind();
            }
            //var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
            //if (checkuserid.coso_id != null)
            //{
            //    div_CoSo.Visible = false;
            //    getData(Convert.ToInt32(checkuserid.coso_id));
            //    txtCoSo_Id.Value = checkuserid.coso_id + "";
            //}
            //else
            //{
            //    div_CoSo.Visible = true;
            //}
        }
        else
        {
            Response.Redirect("/admin-login");
        }
    }
    private void getData(int coso_id)
    {
        var getData = (from sk in db.tbVietNhatKids_SucKhoes
                       join l in db.tbLops on sk.lop_id equals l.lop_id
                       where l.coso_id == coso_id && sk.namhoc_id == _IdNamHoc
                       && sk.suckhoe_thang == ddlThang.SelectedValue
                       group sk by sk.lop_id into k
                       select new
                       {
                           lop_id = k.Key,
                           lop_name = (from lop in db.tbLops
                                       where lop.lop_id == k.Key
                                       select lop.lop_name).FirstOrDefault(),
                           suckhoe_ngay = k.First().suckhoe_ngay,
                       });
        rpDSLopDaNhap.DataSource = getData.OrderBy(x => x.lop_name);
        rpDSLopDaNhap.DataBind();
        rpChiTietSucKhoe.DataSource = getData.OrderBy(x => x.lop_name);
        rpChiTietSucKhoe.DataBind();

    }
    protected void btnXemCoSo_ServerClick(object sender, EventArgs e)
    {
        getData(Convert.ToInt16(txtCoSo_Id.Value));
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setActive('" + Convert.ToInt32(txtCoSo_Id.Value) + "'); HiddenLoadingIcon()", true);
    }

    protected void ddlThang_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlThang.SelectedValue != "Chọn tháng")
        {
            var getData = from cs in db.tbCoSoVietNhats
                          select new
                          {
                              cs.coso_id,
                              cs.coso_name,
                              solopdanhap = (from sk in db.tbVietNhatKids_SucKhoes
                                             join l in db.tbLops on sk.lop_id equals l.lop_id
                                             where l.coso_id == cs.coso_id && sk.namhoc_id == _IdNamHoc
                                             && sk.suckhoe_thang == ddlThang.SelectedValue
                                             group sk by sk.lop_id into k
                                             select k).Count(),
                              tongsolop = (from l in db.tbLops
                                           where l.coso_id == cs.coso_id && l.hidden == false
                                           select l).Count(),
                          };
            rpCoSo.DataSource = getData;
            rpCoSo.DataBind();
            rpDSLopDaNhap.DataSource = null;
            rpDSLopDaNhap.DataBind();
            rpChiTietSucKhoe.DataSource = null;
            rpChiTietSucKhoe.DataBind();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "HiddenLoadingIcon()", true);
        }
    }

    protected void rpChiTietSucKhoe_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpDanhSachHocSinh = e.Item.FindControl("rpDanhSachHocSinh") as Repeater;
        int lop_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "lop_id").ToString());
        var getData = from hs in db.tbHocSinhs
                      join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                      where hstl.lop_id == lop_id
                      && hstl.namhoc_id == _IdNamHoc
                      && hstl.hidden == false
                      select new
                      {
                          hocsinh_fullname = hs.hocsinh_name,
                          hocsinh_cannang = (from cn in db.tbVietNhatKids_SucKhoes
                                             where cn.hocsinh_id == hs.hocsinh_id && cn.suckhoe_thang == ddlThang.SelectedValue
                                             && cn.namhoc_id == _IdNamHoc
                                             orderby cn.suckhoe_id descending
                                             select cn.suckhoe_cannang).FirstOrDefault(),
                          hocsinh_chieucao = (from cn in db.tbVietNhatKids_SucKhoes
                                              where cn.hocsinh_id == hs.hocsinh_id && cn.suckhoe_thang == ddlThang.SelectedValue
                                              && cn.namhoc_id == _IdNamHoc
                                              orderby cn.suckhoe_id descending
                                              select cn.suckhoe_chieucao).FirstOrDefault(),
                          hocsinh_ghichu = (from cn in db.tbVietNhatKids_SucKhoes
                                            where cn.hocsinh_id == hs.hocsinh_id && cn.suckhoe_thang == ddlThang.SelectedValue
                                            && cn.namhoc_id == _IdNamHoc
                                            orderby cn.suckhoe_id descending
                                            select cn.suckhoe_ghichu).FirstOrDefault(),
                      };
        // đẩy dữ liệu vào gridivew
        rpDanhSachHocSinh.DataSource = getData;
        rpDanhSachHocSinh.DataBind();
    }
}
