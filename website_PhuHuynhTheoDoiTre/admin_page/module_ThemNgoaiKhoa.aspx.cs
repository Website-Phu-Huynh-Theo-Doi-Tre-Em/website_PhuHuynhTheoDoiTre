using DevExpress.Web.ASPxHtmlEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class website_PhuHuynhTheoDoiTre_admin_page_module_ThemNgoaiKhoa : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
    private static int _idUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
            _idUser = (from u in db.admin_Users
                       where u.username_username == Request.Cookies["UserName"].Value
                       select u).FirstOrDefault().username_id;


            edtnoidung.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
            if (!IsPostBack)
            {
                Session["_id"] = 0;
            }
            loadData();
        }
        else
        {
            Response.Redirect("/Admin_Default.aspx");
        }
    }
    private void loadData()
    {
        // load data đổ vào var danh sách
        var getData = from nc in db.tbNgoaiKhoas
                      join k in db.tbKhois on nc.khoi_id equals k.khoi_id
                      orderby nc.ngoaikhoa_id descending
                      select new
                      {
                          nc.ngoaikhoa_id,
                          nc.ngoaikhoa_ten,
                          nc.ngoaikhoa_mota,
                          k.khoi_name,

                      };
        // đẩy dữ liệu vào gridivew
        grvList.DataSource = getData;
        grvList.DataBind();
        var listKhoi = from scc in db.tbKhois
                       select scc;
        rpKhoi.DataSource = listKhoi;
        rpKhoi.DataBind();

    }
    private void setNULL()
    {
        txtTitle.Text = "";
        txtDes.Text = "";
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
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "ngoaikhoa_id" }));
        // đẩy id vào session
        Session["_id"] = _id;
        var getData = (from nc in db.tbNgoaiKhoas
                       where nc.ngoaikhoa_id == _id
                       select nc).Single();
        txtTitle.Text = getData.ngoaikhoa_ten;
        txtDes.Text = getData.ngoaikhoa_mota;
        edtnoidung.Html = getData.ngoaikhoa_noidung;
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

    protected void btnXoa_Click(object sender, EventArgs e)
    {
        cls_NgoaiKhoa cls;
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "ngoaikhoa_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                cls = new cls_NgoaiKhoa();
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

    protected void btnLuu_Click(object sender, EventArgs e)
    {
        cls_NgoaiKhoa cls = new cls_NgoaiKhoa();

        if (Session["_id"].ToString() == "0")
        {
            if (txtKhoi_ID.Value != "")
            {
                string[] arrKhoi = txtKhoi_ID.Value.Split(';');
                for (int i = 0; i < arrKhoi.Length; i++)
                {
                    if (cls.Linq_Them(txtTitle.Text, txtDes.Text, edtnoidung.Html, DateTime.Now, Convert.ToInt32(arrKhoi[i])))
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
            if (cls.Linq_Sua(Convert.ToInt32(Session["_id"].ToString()), txtTitle.Text, txtDes.Text, edtnoidung.Html, DateTime.Now))
        {
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Cập nhật thành công','','success').then(function(){grvList.Refresh();})", true);
            popupControl.ShowOnPageLoad = false;
            loadData();
        }
        else alert.alert_Error(Page, "Cập nhật thất bại", "");
    }
}