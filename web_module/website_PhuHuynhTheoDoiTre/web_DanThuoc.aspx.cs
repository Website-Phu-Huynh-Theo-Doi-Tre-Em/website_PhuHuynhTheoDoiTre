using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_module_website_website_VietNhatKis_web_DanThuoc : System.Web.UI.Page
{
    dbcsdlDataContext dbcsdlDataContext = new dbcsdlDataContext();
    public int stt = 1;
    cls_Alert alert = new cls_Alert();
    string sdt = "";
    int id_HocSinh = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["web_hocsinh"] != null)
        {
             sdt = Request.Cookies["web_hocsinh"].Value;
            var getNamHoc = (from nh in dbcsdlDataContext.tbHoctap_NamHocs
                             orderby nh.namhoc_id descending
                             select nh).First();
            lblNam.Text = getNamHoc.namhoc_nienkhoa;
            var getData = from hs in dbcsdlDataContext.tbHocSinhs
                          join hstl in dbcsdlDataContext.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                          join dt in dbcsdlDataContext.tbDanDoThuocs on hstl.hstl_id equals dt.hstl_id
                          join nh in dbcsdlDataContext.tbHoctap_NamHocs on dt.namhoc_id equals nh.namhoc_id
                          where hs.hocsinh_taikhoan == sdt
                          orderby dt.phuhuynhdandothuoc_id descending
                          select new
                          {
                              danthuoc_RegisterDate = dt.phuhuynhdandothuoc_ngaydangki,
                              danthuoc_status = dt.phuhuynhdandothuoc_tinhtrang == true ? " <i title=\"Đã xác nhận\" class='fas fa-check-circle'></i>" : "<i title=\"Chờ xác nhận\" style=\"color:#ffc107\" class='fas fa-hourglass'></i>",
                              danthuoc_disease = dt.phuhuynhdandothuoc_Lydo,
                              danthuoc_id = dt.phuhuynhdandothuoc_id,
                              danthuoc_StartDate = dt.phuhuynhdandothuoc_ngaybatdau,
                              danthuoc_EndDate = dt.phuhuynhdandothuoc_ngayketthuc,
                              danthuoc_content = dt.phuhuynhdandothuoc_noidungdando,
                              id_HocSinh = dt.hstl_id,

                          };
           
            rpDanThuoc.DataSource = getData;
            rpDanThuoc.DataBind();

            rpChiTietDanThuoc.DataSource = getData;
            rpChiTietDanThuoc.DataBind();
        }
        else
        {
            Response.Redirect("/website-dang-nhap");
        }
    }
    public void getData(object sender, EventArgs e)
    {

    }
    protected void btnGui_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["web_hocsinh"] != null)
        {
            if (txtDanDo.Value !="" && dteTuNgay.Value !="" && dteDenNgay.Value != "" && txtBenh.Value != "")
            {

                var getData = (from hs in dbcsdlDataContext.tbHocSinhs
                              join hstl in dbcsdlDataContext.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                              join dt in dbcsdlDataContext.tbDanDoThuocs on hstl.hstl_id equals dt.hstl_id
                              join nh in dbcsdlDataContext.tbHoctap_NamHocs on dt.namhoc_id equals nh.namhoc_id
                              where hs.hocsinh_taikhoan == sdt 
                               select new
                              {
                                  danthuoc_RegisterDate = dt.phuhuynhdandothuoc_ngaydangki,
                                  danthuoc_status = dt.phuhuynhdandothuoc_tinhtrang == false ? "Chờ xác nhận" : "Đã xác nhận",
                                  danthuoc_disease = dt.phuhuynhdandothuoc_Lydo,
                                  danthuoc_id = dt.phuhuynhdandothuoc_id,
                                  danthuoc_StartDate = dt.phuhuynhdandothuoc_ngaybatdau,
                                  danthuoc_EndDate = dt.phuhuynhdandothuoc_ngayketthuc,
                                  danthuoc_content = dt.phuhuynhdandothuoc_noidungdando,
                                  dt.hstl_id,
                                  dt.lop_id,
                                  dt.namhoc_id,

                               }).FirstOrDefault();
                tbDanDoThuoc insert = new tbDanDoThuoc();
                insert.phuhuynhdandothuoc_noidungdando = txtDanDo.Value;
                insert.phuhuynhdandothuoc_ngaybatdau = Convert.ToDateTime(dteTuNgay.Value);
                insert.phuhuynhdandothuoc_ngayketthuc = Convert.ToDateTime(dteDenNgay.Value);
                insert.phuhuynhdandothuoc_Lydo = txtBenh.Value;
                insert.hstl_id = getData.hstl_id;
                insert.lop_id = getData.lop_id;
                insert.namhoc_id=getData.namhoc_id;
                insert.phuhuynhdandothuoc_ngaydangki = Convert.ToDateTime(DateTime.Now);
                insert.phuhuynhdandothuoc_tinhtrang =false;
                dbcsdlDataContext.tbDanDoThuocs.InsertOnSubmit(insert);
                dbcsdlDataContext.SubmitChanges();
                dteTuNgay.Value = "";
                dteDenNgay.Value = "";
                txtDanDo.Value = "";
                txtBenh.Value = "";
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Gửi thành công!','','success').then(function(){window.location.reload(); HiddenLoadingIcon()})", true);
            }
            else
            {
                alert.alert_Error(Page, "Vui lòng nhập đầy đủ thông tin dặn thuốc", " ");
            }
        }
    }

    protected void btnCapNhat_ServerClick(object sender, EventArgs e)
    {
        tbDanDoThuoc update = (from hs in dbcsdlDataContext.tbHocSinhs
                                                    join hstl in dbcsdlDataContext.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                                                    join dt in dbcsdlDataContext.tbDanDoThuocs on hstl.hstl_id equals dt.hstl_id
                                                    join nh in dbcsdlDataContext.tbHoctap_NamHocs on dt.namhoc_id equals nh.namhoc_id
                                                    where hs.hocsinh_taikhoan == sdt && dt.phuhuynhdandothuoc_id == Convert.ToInt32(txtIDCapNhat.Value)
                                                    orderby dt.phuhuynhdandothuoc_id descending
                                                    select dt).FirstOrDefault();
        update.phuhuynhdandothuoc_ngaydangki = DateTime.Now;
        update.phuhuynhdandothuoc_noidungdando = txtNDCapNhat.Value;
        update.phuhuynhdandothuoc_ngaybatdau = Convert.ToDateTime(txtNgayBDCapNhat.Value);
        update.phuhuynhdandothuoc_ngayketthuc = Convert.ToDateTime(txtNgayKTCapNhat.Value);
        update.phuhuynhdandothuoc_Lydo = txtTenCapNhat.Value;
        update.phuhuynhdandothuoc_tinhtrang = false;
        dbcsdlDataContext.SubmitChanges();
        alert.alert_Success(Page, "Cập nhật thành công!", "");

        var getData = from hs in dbcsdlDataContext.tbHocSinhs
                      join hstl in dbcsdlDataContext.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                      join dt in dbcsdlDataContext.tbDanDoThuocs on hstl.hstl_id equals dt.hstl_id
                      join nh in dbcsdlDataContext.tbHoctap_NamHocs on dt.namhoc_id equals nh.namhoc_id
                      where hs.hocsinh_taikhoan == sdt
                      orderby dt.phuhuynhdandothuoc_id descending
                      select new
                      {
                          danthuoc_RegisterDate = dt.phuhuynhdandothuoc_ngaydangki,
                          danthuoc_status = dt.phuhuynhdandothuoc_tinhtrang == true ? " <i title=\"Đã xác nhận\" class='fas fa-check-circle'></i>" : "<i title=\"Chờ xác nhận\" style=\"color:#03a9f4\" class='fas fa-hourglass'></i>",
                          danthuoc_disease = dt.phuhuynhdandothuoc_Lydo,
                          danthuoc_id = dt.phuhuynhdandothuoc_id,
                          danthuoc_StartDate = dt.phuhuynhdandothuoc_ngaybatdau,
                          danthuoc_EndDate = dt.phuhuynhdandothuoc_ngayketthuc,
                          danthuoc_content = dt.phuhuynhdandothuoc_noidungdando,
                          id_HocSinh = dt.hstl_id,
                      };
        
        rpDanThuoc.DataSource = getData;
        rpDanThuoc.DataBind();
         rpChiTietDanThuoc.DataSource = getData;
            rpChiTietDanThuoc.DataBind();

    }
}