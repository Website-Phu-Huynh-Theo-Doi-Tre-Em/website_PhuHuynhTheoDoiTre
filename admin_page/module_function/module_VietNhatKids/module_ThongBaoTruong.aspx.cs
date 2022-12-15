using DevExpress.Web.ASPxHtmlEditor;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_WebSite_module_ThongBaoTruong : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
    private static int _idUser;
    private static int _idNamHoc;
    private static int CoSo;
    string chucvu;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
            var checkNamHoc = (from nh in db.tbHoctap_NamHocs orderby nh.namhoc_id descending select nh).First();

            _idUser = (from u in db.admin_Users
                       where u.username_username == Request.Cookies["UserName"].Value
                       select u).FirstOrDefault().username_id;
            _idNamHoc = checkNamHoc.namhoc_id;
            CoSo = Convert.ToInt32(checkuserid.coso_id);
            chucvu = checkuserid.chucvu_id;
            edtnoidung.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            //if (!IsPostBack)
            //{
            //    Session["_id"] = 0;
            //}
            //loadData();
            if (!IsPostBack)
            {
                Session["_id"] = 0;
            }
            if (chucvu == "Văn Thư")
            {
                loadData();
            }
            else
            {
                Response.Redirect("/admin-login");
                //btnThem.Visible = false;
            }
        }
        else
        {
            Response.Redirect("/admin-login");
        }
    }
    private void loadData()
    {
        // load data đổ vào var danh sách
        var getData = from nc in db.tbVietNhatKids_ThongBaoTruongs
                      join sc in db.tbKhois on nc.khoi_id equals sc.khoi_id
                      //join u in db.admin_Users on nc.username_id equals u.username_id
                      where nc.coso_id == CoSo
                      orderby nc.thongbaotruong_datecreate descending
                      select new
                      {
                          nc.thongbaotruong_id,
                          nc.thongbaotruong_title,
                          nc.thongbaotruong_datecreate,
                          //u.username_fullname,
                          sc.khoi_name
                          //slide_active = nc.slide_active == true ? "Đã hiển thị" : "Chưa hiển thị",
                      };
        // đẩy dữ liệu vào gridivew
        grvList.DataSource = getData;
        grvList.DataBind();
        var listKhoi = from scc in db.tbKhois
                       where scc.coso_id == CoSo
                       select scc;
        //ddlloaitrang.DataSource = listKhoi;
        //ddlloaitrang.DataBind();
        rpKhoi.DataSource = listKhoi;
        rpKhoi.DataBind();
    }
    private void setNULL()
    {
        txtTitle.Text = "";
        edtnoidung.Html = "";

    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        // Khi nhấn nút thêm thì mật định session id = 0 để thêm mới
        Session["_id"] = 0;
        // gọi hàm setNull để trả toàn bộ các control về rỗng
        setNULL();
        div_Khoi.Visible = true;
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupControl.Show();", true);
        loadData();
    }

    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        // get value từ việc click vào gridview
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "thongbaotruong_id" }));
        // đẩy id vào session
        Session["_id"] = _id;
        var getData = (from nc in db.tbVietNhatKids_ThongBaoTruongs
                       join sc in db.tbKhois on nc.khoi_id equals sc.khoi_id
                       where nc.thongbaotruong_id == _id
                       select new
                       {
                           nc.thongbaotruong_id,
                           nc.thongbaotruong_title,
                           nc.thongbaotruong_content,
                           nc.thongbaotruong_datecreate,
                           sc.khoi_name,
                           sc.khoi_id,
                       }).Single();
        txtTitle.Text = getData.thongbaotruong_title;
        txtKhoi_ID.Value = getData.khoi_id + "";
        edtnoidung.Html = getData.thongbaotruong_content;
        div_Khoi.Visible = false;
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show();", true);
        loadData();
    }
    public bool checknull()
    {
        if (txtTitle.Text != "")
            return true;
        else return false;
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        cls_ThongBaoTruong cls = new cls_ThongBaoTruong();
        if (Session["_id"].ToString() == "0")
        {
            if (txtKhoi_ID.Value != "")
            {
                string[] arrKhoi = txtKhoi_ID.Value.Split(';');
                for (int i = 0; i < arrKhoi.Length; i++)
                {
                    if (cls.Linq_Them(txtTitle.Text, edtnoidung.Html, Convert.ToInt32(arrKhoi[i]), CoSo, _idUser, _idNamHoc))
                    {
                        alert.alert_Success(Page, "Thêm thành công", "");
                        popupControl.ShowOnPageLoad = false;
                        loadData();
                    }
                    else alert.alert_Error(Page, "Thêm thất bại", "");
                }
            }
            else
            {
                alert.alert_Warning(Page, "Vui lòng chọn khối", "");
            }
        }
        else
        {
            if (cls.Linq_Sua(Convert.ToInt32(Session["_id"].ToString()), txtTitle.Text, edtnoidung.Html, CoSo))
            {
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Cập nhật thành công','','success').then(function(){grvList.Refresh();})", true);
                popupControl.ShowOnPageLoad = false;
                loadData();
            }
            else alert.alert_Error(Page, "Cập nhật thất bại", "");
        }
        loadData();
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        cls_ThongBaoTruong cls;
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "thongbaotruong_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                cls = new cls_ThongBaoTruong();
                if (cls.Linq_Xoa(Convert.ToInt32(item)))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Xóa thành công','','success').then(function(){grvList.Refresh();})", true);
                }
                else
                    alert.alert_Error(Page, "Xóa thất bại", "");
            }
        }
        else
            alert.alert_Warning(Page, "Bạn chưa chọn dữ liệu", "");
    }

    //protected void ddlCoSo_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ddlloaitrang.DataSource = from k in db.tbKhois where k.coso_id == Convert.ToInt16(ddlCoSo.Value) select k;
    //    ddlloaitrang.DataBind();

    //}
}