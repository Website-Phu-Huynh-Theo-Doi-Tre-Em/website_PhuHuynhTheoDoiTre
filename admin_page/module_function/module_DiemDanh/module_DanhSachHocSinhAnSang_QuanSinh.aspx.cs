using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_DiemDanh_module_DanhSachHocSinhAnSang_QuanSinh : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var listNV = from l in db.tbLops
                         join gvtl in db.tbGiaoVienTrongLops on l.lop_id equals gvtl.lop_id
                         orderby l.khoi_id
                         select l;
            ddlLop.Items.Clear();
            ddlLop.Items.Insert(0, "Chọn Lớp");
            ddlLop.AppendDataBoundItems = true;
            ddlLop.DataTextField = "lop_name";
            ddlLop.DataValueField = "lop_id";
            ddlLop.DataSource = listNV;
            ddlLop.DataBind();
            Session["_id"] = 0;
        }
        loadData();

    }
    private void loadData()
    {
        if (ddlLop.SelectedValue == "0" || ddlLop.SelectedValue == "Chọn Lớp")
        {
            
        }
        else
        {
            var checkNamHoc = (from nh in db.tbHoctap_NamHocs orderby nh.namhoc_id descending select nh).FirstOrDefault();
            var getData = from hs in db.tbHocSinhs
                          join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                          join an in db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs on hstl.hstl_id equals an.hstl_id
                          join l in db.tbLops on hstl.lop_id equals l.lop_id
                          where hstl.namhoc_id == checkNamHoc.namhoc_id && l.lop_id == Convert.ToInt16(ddlLop.SelectedValue)
                          //&& an.ansang_datecreate <= DateTime.Now 
                          select new
                          {
                              hs.hocsinh_name,
                              l.lop_name,
                              hstl.hstl_id,
                              an.ansang_datecreate,
                             
                          };
            var getDataCheckAnSang = from hs in db.tbHocSinhs
                                     join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                                     join l in db.tbLops on hstl.lop_id equals l.lop_id
                                     join an in db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs on hstl.hstl_id equals an.hstl_id
                                     join ck in db.tbDiemDanh_HocSinhs on hstl.hstl_id equals ck.hstl_id
                                     where hstl.namhoc_id == checkNamHoc.namhoc_id && l.lop_id == Convert.ToInt16(ddlLop.SelectedValue)
                                     && ck.diemdanh_ansang != null
                                     && an.ansang_datecreate <= DateTime.Now
                                     && ck.diemdanh_ngay.Value.Date == Convert.ToDateTime(dteNgay.Value).Date
                                     && ck.diemdanh_ngay.Value.Month == Convert.ToDateTime(dteNgay.Value).Month
                                     && ck.diemdanh_ngay.Value.Year == Convert.ToDateTime(dteNgay.Value).Year
                                     select new
                                     {
                                         hs.hocsinh_name,
                                         l.lop_name,
                                         hstl.hstl_id,
                                         an.ansang_datecreate,
                                     };
            var ketqua = getData.Except(getDataCheckAnSang);
            grvList.DataSource = ketqua;
            grvList.DataBind();
           
        }
    }
    protected void btnAnSang_Click(object sender, EventArgs e)
    {
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "hstl_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                tbDiemDanh_HocSinh checkNgayAnSang = (from an in db.tbDiemDanh_HocSinhs
                                                        where an.diemdanh_ngay.Value.Date == Convert.ToDateTime(dteNgay.Value).Date
                                                        && an.diemdanh_ngay.Value.Month == Convert.ToDateTime(dteNgay.Value).Month
                                                        && an.diemdanh_ngay.Value.Year == Convert.ToDateTime(dteNgay.Value).Year
                                                        && an.hstl_id == Convert.ToInt32(item)
                                                        select an).SingleOrDefault();
                if (checkNgayAnSang != null)
                {
                    checkNgayAnSang.diemdanh_ngay = Convert.ToDateTime(dteNgay.Value);
                    checkNgayAnSang.diemdanh_ansang = 1;
                    checkNgayAnSang.hstl_id = Convert.ToInt32(item);
                    db.SubmitChanges();
                }
                else
                {
                    tbDiemDanh_HocSinh insert = new tbDiemDanh_HocSinh();
                    insert.hstl_id = Convert.ToInt32(item);
                    insert.diemdanh_ngay = Convert.ToDateTime(dteNgay.Value);
                    insert.diemdanh_ansang = 1;
                    db.tbDiemDanh_HocSinhs.InsertOnSubmit(insert);
                    db.SubmitChanges();
                }
            }
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Đã hoàn thành!','','success').then(function(){grvList.UnselectRows();})", true);
        }
    }
    protected void btnKoAnSang_Click(object sender, EventArgs e)
    {
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "hstl_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                tbDiemDanh_HocSinh checkNgayAnSang = (from an in db.tbDiemDanh_HocSinhs
                                                        where an.diemdanh_ngay.Value.Date == Convert.ToDateTime(dteNgay.Value).Date
                                                            && an.diemdanh_ngay.Value.Month == Convert.ToDateTime(dteNgay.Value).Month
                                                            && an.diemdanh_ngay.Value.Year == Convert.ToDateTime(dteNgay.Value).Year
                                                            && an.hstl_id == Convert.ToInt32(item)
                                                        select an).SingleOrDefault();
                if (checkNgayAnSang != null)
                {
                    checkNgayAnSang.diemdanh_ngay = Convert.ToDateTime(dteNgay.Value);
                    checkNgayAnSang.diemdanh_ansang = 2;
                    checkNgayAnSang.hstl_id = Convert.ToInt32(item);
                    db.SubmitChanges();
                }
                else
                {
                    tbDiemDanh_HocSinh insert = new tbDiemDanh_HocSinh();
                    insert.hstl_id = Convert.ToInt32(item);
                    insert.diemdanh_ngay = Convert.ToDateTime(dteNgay.Value);
                    insert.diemdanh_ansang = 2;
                    db.tbDiemDanh_HocSinhs.InsertOnSubmit(insert);
                    db.SubmitChanges();
                }
            }
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Đã hoàn thành!','','success').then(function(){grvList.UnselectRows();})", true);
        }
    }
}