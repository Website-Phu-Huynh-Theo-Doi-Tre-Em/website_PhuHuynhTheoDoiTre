﻿using System;
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
                          join dt in dbcsdlDataContext.tbVietNhatKids_PhuHuynhDanDoThuocs on hstl.hstl_id equals dt.hstl_id
                          join nh in dbcsdlDataContext.tbHoctap_NamHocs on dt.namhoc_id equals nh.namhoc_id
                          where hs.hocsinh_taikhoan == sdt
                          orderby dt.phuhuynhdandothuoc_id descending
                          select new
                          {
                              danthuoc_RegisterDate = dt.phuhuynhdandothuoc_ngaydangki,
                              danthuoc_status = dt.phuhuynhdandothuoc_tinhtrang == true ? " <i title=\"Đã xác nhận\" class='fas fa-check-circle'></i>" : "<i title=\"Chờ xác nhận\" style=\"color:#ffc107\" class='fas fa-hourglass'></i>",
                              danthuoc_disease = dt.phuhuynhdandothuoc_name,
                              danthuoc_id = dt.phuhuynhdandothuoc_id,
                              danthuoc_StartDate = dt.phuhuynhdandothuoc_createdate,
                              danthuoc_EndDate = dt.phuhuynhdandothuoc_enddate,
                              danthuoc_content = dt.phuhuynhdandothuoc_content,
                              id_HocSinh = dt.hstl_id,

                          };
           
            rpDanThuoc.DataSource = getData;
            rpDanThuoc.DataBind();

            rpChiTietDanThuoc.DataSource = getData;
            rpChiTietDanThuoc.DataBind();
        }
        else
        {
            Response.Redirect("/website-vietnhatkids-login");
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
                              join dt in dbcsdlDataContext.tbVietNhatKids_PhuHuynhDanDoThuocs on hstl.hstl_id equals dt.hstl_id
                              join nh in dbcsdlDataContext.tbHoctap_NamHocs on dt.namhoc_id equals nh.namhoc_id
                              where hs.hocsinh_taikhoan == sdt 
                               select new
                              {
                                  danthuoc_RegisterDate = dt.phuhuynhdandothuoc_ngaydangki,
                                  danthuoc_status = dt.phuhuynhdandothuoc_tinhtrang == false ? "Chờ xác nhận" : "Đã xác nhận",
                                  danthuoc_disease = dt.phuhuynhdandothuoc_name,
                                  danthuoc_id = dt.phuhuynhdandothuoc_id,
                                  danthuoc_StartDate = dt.phuhuynhdandothuoc_createdate,
                                  danthuoc_EndDate = dt.phuhuynhdandothuoc_enddate,
                                  danthuoc_content = dt.phuhuynhdandothuoc_content,
                                  dt.hstl_id,
                                  dt.lop_id,
                                  dt.namhoc_id,

                               }).FirstOrDefault();               
                tbVietNhatKids_PhuHuynhDanDoThuoc insert = new tbVietNhatKids_PhuHuynhDanDoThuoc();
                insert.phuhuynhdandothuoc_content = txtDanDo.Value;
                insert.phuhuynhdandothuoc_createdate = Convert.ToDateTime(dteTuNgay.Value);
                insert.phuhuynhdandothuoc_enddate = Convert.ToDateTime(dteDenNgay.Value);
                insert.phuhuynhdandothuoc_name = txtBenh.Value;
                insert.hstl_id = getData.hstl_id;
                insert.lop_id = getData.lop_id;
                insert.namhoc_id=getData.namhoc_id;
                insert.phuhuynhdandothuoc_ngaydangki = Convert.ToDateTime(DateTime.Now);
                insert.phuhuynhdandothuoc_tinhtrang =false;
                dbcsdlDataContext.tbVietNhatKids_PhuHuynhDanDoThuocs.InsertOnSubmit(insert);
                dbcsdlDataContext.SubmitChanges();
                dteTuNgay.Value = "";
                dteDenNgay.Value = "";
                txtDanDo.Value = "";
                txtBenh.Value = "";
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Gửi thành công!','','success').then(function(){window.location.reload();})", true);
            }
            else
            {
                alert.alert_Error(Page, "Vui lòng nhập đầy đủ thông tin dặn thuốc", " ");
            }
        }
    }

    protected void btnCapNhat_ServerClick(object sender, EventArgs e)
    {
        tbVietNhatKids_PhuHuynhDanDoThuoc update = (from hs in dbcsdlDataContext.tbHocSinhs
                                                    join hstl in dbcsdlDataContext.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                                                    join dt in dbcsdlDataContext.tbVietNhatKids_PhuHuynhDanDoThuocs on hstl.hstl_id equals dt.hstl_id
                                                    join nh in dbcsdlDataContext.tbHoctap_NamHocs on dt.namhoc_id equals nh.namhoc_id
                                                    where hs.hocsinh_taikhoan == sdt && dt.phuhuynhdandothuoc_id == Convert.ToInt32(txtIDCapNhat.Value)
                                                    orderby dt.phuhuynhdandothuoc_id descending
                                                    select dt).FirstOrDefault();
        update.phuhuynhdandothuoc_ngaydangki = DateTime.Now;
        update.phuhuynhdandothuoc_content = txtNDCapNhat.Value;
        update.phuhuynhdandothuoc_createdate = Convert.ToDateTime(txtNgayBDCapNhat.Value);
        update.phuhuynhdandothuoc_enddate = Convert.ToDateTime(txtNgayKTCapNhat.Value);
        update.phuhuynhdandothuoc_name = txtTenCapNhat.Value;
        update.phuhuynhdandothuoc_tinhtrang = false;
        dbcsdlDataContext.SubmitChanges();
        alert.alert_Success(Page, "Cập nhật thành công!", "");

        var getData = from hs in dbcsdlDataContext.tbHocSinhs
                      join hstl in dbcsdlDataContext.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                      join dt in dbcsdlDataContext.tbVietNhatKids_PhuHuynhDanDoThuocs on hstl.hstl_id equals dt.hstl_id
                      join nh in dbcsdlDataContext.tbHoctap_NamHocs on dt.namhoc_id equals nh.namhoc_id
                      where hs.hocsinh_taikhoan == sdt
                      orderby dt.phuhuynhdandothuoc_id descending
                      select new
                      {
                          danthuoc_RegisterDate = dt.phuhuynhdandothuoc_ngaydangki,
                          danthuoc_status = dt.phuhuynhdandothuoc_tinhtrang == true ? " <i title=\"Đã xác nhận\" class='fas fa-check-circle'></i>" : "<i title=\"Chờ xác nhận\" style=\"color:#03a9f4\" class='fas fa-hourglass'></i>",
                          danthuoc_disease = dt.phuhuynhdandothuoc_name,
                          danthuoc_id = dt.phuhuynhdandothuoc_id,
                          danthuoc_StartDate = dt.phuhuynhdandothuoc_createdate,
                          danthuoc_EndDate = dt.phuhuynhdandothuoc_enddate,
                          danthuoc_content = dt.phuhuynhdandothuoc_content,
                          id_HocSinh = dt.hstl_id,
                      };
        
        rpDanThuoc.DataSource = getData;
        rpDanThuoc.DataBind();
         rpChiTietDanThuoc.DataSource = getData;
            rpChiTietDanThuoc.DataBind();

    }
}