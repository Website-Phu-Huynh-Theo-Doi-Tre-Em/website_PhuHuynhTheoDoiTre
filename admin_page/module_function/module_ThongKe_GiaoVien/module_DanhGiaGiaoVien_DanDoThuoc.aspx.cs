using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_VietNhatKids_module_DanhGiaGiaoVien_TaoBaiVietAlbumAnh : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public string title_name;
    public int STTDiemDanhHangNgay = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rpCoSo.DataSource = from cs in db.tbCoSoVietNhats select cs;
            rpCoSo.DataBind();
        }
    }

    protected void getData(int cs_id)
    {
        var getDiemTaoBaiViet = from u in db.admin_Users
                                where u.coso_id == Convert.ToInt16(cs_id) && u.username_active == true
                                select new
                                {
                                    u.username_id,
                                    u.username_fullname,
                                    diemtichluy = (from ls in db.tbVietNhatKids_PhuHuynhDanDoThuocs
                                                   join hstl in db.tbHocSinhTrongLops on ls.hstl_id equals hstl.hstl_id
                                                   join l in db.tbLops on hstl.lop_id equals l.lop_id
                                                   join gvtl in db.tbGiaoVienTrongLops on l.lop_id equals gvtl.lop_id
                                                   where gvtl.taikhoan_id == u.username_id && ls.namhoc_id == 11 select ls).Sum(x => x.phuhuynhdandothuoc_diemtichluy),
                                    TongSoLuongBaiTao = (from ls in db.tbVietNhatKids_PhuHuynhDanDoThuocs
                                                         join hstl in db.tbHocSinhTrongLops on ls.hstl_id equals hstl.hstl_id
                                                         join l in db.tbLops on hstl.lop_id equals l.lop_id
                                                         join gvtl in db.tbGiaoVienTrongLops on l.lop_id equals gvtl.lop_id
                                                         where gvtl.taikhoan_id == u.username_id && ls.namhoc_id == 11
                                                         select ls).Count()
                                  };
        rpDiemDanHangNgay.DataSource = getDiemTaoBaiViet;
        rpDiemDanHangNgay.DataBind();
        rpGiaoVienNhaXetThuongXuyen.DataSource = getDiemTaoBaiViet;
        rpGiaoVienNhaXetThuongXuyen.DataBind();
    }

    protected void rpGiaoVienNhaXetThuongXuyen_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        Repeater rpChiTietNhanXetHangNgay = e.Item.FindControl("rpChiTietNhanXetHangNgay") as Repeater;
        int username_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "username_id").ToString());
        var getChiTiet = from ls in db.tbVietNhatKids_PhuHuynhDanDoThuocs
                         join hstl in db.tbHocSinhTrongLops on ls.hstl_id equals hstl.hstl_id
                         join l in db.tbLops on hstl.lop_id equals l.lop_id
                         join gvtl in db.tbGiaoVienTrongLops on l.lop_id equals gvtl.lop_id
                         where gvtl.taikhoan_id == username_id  
                         select new { 
                         ls.phuhuynhdandothuoc_createdate
                         };
        rpChiTietNhanXetHangNgay.DataSource = getChiTiet;
        rpChiTietNhanXetHangNgay.DataBind();
    }


    protected void btnXemCoSo_ServerClick(object sender, EventArgs e)
    {
        getData(Convert.ToInt16(txtCoSo_Id.Value));
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "setActive('" + Convert.ToInt32(txtCoSo_Id.Value) + "')", true);
    }
}