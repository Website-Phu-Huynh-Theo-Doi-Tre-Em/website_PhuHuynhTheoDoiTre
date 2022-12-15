using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_DiemDanh_module_QuanLyLop_DangKyUongSua : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["_id"] = 0;
        }
        loadData();

    }
    private void loadData()
    {
        var getData = from hs in db.tbHocSinhs
                      join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                      join l in db.tbLops on hstl.lop_id equals l.lop_id
                      join an in db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs on hstl.hstl_id equals an.hstl_id
                      where an.ansang_hidden== null
                      //orderby an.ansang_id descending
                      select new
                      {
                          an.ansang_id,
                          hs.hocsinh_name,
                          an.ansang_datecreate,
                          an.ansang_dateend,
                          l.lop_name,
                          an.ansang_dot
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
                    alert.alert_Success(Page, "Xóa thành công", "");
                else
                    alert.alert_Error(Page, "Xóa thất bại", "");
            }
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
    protected void btnKetThuc_Click(object sender, EventArgs e)
    {
         List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "ansang_id" });
         if (selectedKey.Count > 0)
         {
             foreach (var item in selectedKey)
             {
                 tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSang update = (from a in db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs
                                                                       where a.ansang_id == Convert.ToInt32(item)
                                                                       select a).SingleOrDefault();
                 if (update.ansang_dot>=3)
                 {
                     update.ansang_hidden = true;
                 }
                 else
                 {
                     update.ansang_hidden = false;
                     update.ansang_dot = update.ansang_dot + 1;
                 }
                 update.ansang_dateend = DateTime.Now;
                 
                 db.SubmitChanges();
             }
            
             ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Đã kết thúc ăn sáng!','','success').then(function(){grvList.UnselectRows();})", true);
           
         }
    }
}