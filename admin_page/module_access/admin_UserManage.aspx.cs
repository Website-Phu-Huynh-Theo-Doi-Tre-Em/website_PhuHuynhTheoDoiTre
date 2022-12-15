using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_access_admin_UserManage : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
    private static int _idCoSo;
    private static int _idUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            if (!IsPostBack)
            {
                Session["_id"] = 0;
            }
            //kiểm tra nếu mà tk admin của các cơ sở thì cho thêm bth, còn không thì không được thêm
            _idCoSo = Convert.ToInt32((from u in db.admin_Users
                                       where u.username_username == Request.Cookies["UserName"].Value
                                       select u.coso_id).FirstOrDefault());
            _idUser = (from u in db.admin_Users
                       where u.username_username == Request.Cookies["UserName"].Value
                       select u.username_id).FirstOrDefault();
            if (_idUser == 2)
            {
                //div_Button.Visible = false;
                loadDataGiaoVien();
            }
            else
            {
                loadDataGiaoVienTheoCoSo();
                //div_Button.Visible = true;
            }
        }
        else
        {
            Response.Redirect("/admin-login");
        }

    }
    // Dành cho root
    private void loadData()
    {
        var getData = from gv in db.admin_Users select gv;
        grvList.DataSource = getData;
        grvList.DataBind();
    }
    // Dành cho các trung tâm
    private void loadDataTrungTam()
    {
        // admin_User logedMember = Session["AdminLogined"] as admin_User;
        var getData = from gv in db.admin_Users
                      where gv.groupuser_id == 2
                      select gv;
        grvList.DataSource = getData;
        grvList.DataBind();
    }
    // Dành cho các giáo viên
    private void loadDataGiaoVien()
    {
        var getData = from gv in db.admin_Users
                      join cs in db.tbCoSoVietNhats on gv.coso_id equals cs.coso_id
                      orderby gv.username_id descending
                      select new
                      {
                          gv.username_id,
                          gv.username_fullname,
                          gv.username_email,
                          gv.username_phone,
                          gv.username_username,
                          username_gender = gv.username_gender == true ? "Nam" : "Nữ",
                          cs.coso_id,
                          cs.coso_name,
                      };
        grvList.DataSource = getData;
        grvList.DataBind();
    }
    private void loadDataGiaoVienTheoCoSo()
    {
        var getData = from gv in db.admin_Users
                      join cs in db.tbCoSoVietNhats on gv.coso_id equals cs.coso_id
                      where cs.coso_id == _idCoSo
                      orderby gv.username_id descending
                      select new
                      {
                          gv.username_id,
                          gv.username_fullname,
                          gv.username_email,
                          gv.username_phone,
                          gv.username_username,
                          username_gender = gv.username_gender == true ? "Nam" : "Nữ",
                          cs.coso_id,
                          cs.coso_name,
                      };
        grvList.DataSource = getData;
        grvList.DataBind();

    }
    private void setNULL()
    {
        txtUserName.Text = "";
        txtFullname.Text = "";
        txtEmail.Text = "";
        txtPhone.Text = "";
        txtPass.Value = "";
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        Session["_id"] = 0;
        setNULL();
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupControl.Show();", true);
    }
    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "username_id" }));
        Session["_id"] = _id;
        var getData = (from gr in db.admin_Users
                       where gr.username_id == _id
                       select gr).Single();
        txtFullname.Text = getData.username_fullname;
        txtEmail.Text = getData.username_email;
        txtPhone.Text = getData.username_phone;
        txtUserName.Text = getData.username_username;
        //txtPass.Value = getData.username_password;
        ddlCoSo.SelectedValue = getData.coso_id + "";
        txtDiaChi.Text = getData.username_diachi;
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show();disabledInput()", true);
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {

        cls_AccountAdmin cls;
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "username_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                cls = new cls_AccountAdmin();
                if (cls.Linq_Xoa(Convert.ToInt32(item)))
                    alert.alert_Success(Page, "Xóa thành công", "");
                else
                    alert.alert_Error(Page, "Xóa thất bại", "");
            }
        }
        else
            alert.alert_Warning(Page, "Bạn chưa chọn dữ liệu", "");
    }

    //check tài khoản tồn tại
    private bool checkTaiKhoan(string username_username)
    {
        string username = username_username.ToLower();
        var check_TK = db.admin_Users.Any(x => x.username_username.ToLower() == username);
        if (check_TK == true)
            return false;
        else
            return true;

    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        cls_AccountAdmin cls = new cls_AccountAdmin();
        cls_security md5 = new cls_security();
        string passWord = txtPass.Value.Trim();
        string passmd5 = md5.HashCode(txtPass.Value);

        //if (txtUserName.Text == "" || txtPass.Text == "")
        //    alert.alert_Warning(Page, "Vui lòng nhập đầy đủ thông tin!", "");
        //else
        //{
        if (Session["_id"].ToString() == "0")
        {
            //kiểm tra tồn tại tài khoản đăng nhập hay không
            if (checkTaiKhoan(txtUserName.Text.Trim()) == false)
            {
                alert.alert_Warning(Page, "Đã tồn tại tài khoản!", "Vui lòng kiểm tra lại!");
            }
            else
            {
                if
                (cls.Linq_Them(txtUserName.Text.ToLower(), passmd5, txtFullname.Text, txtPhone.Text, txtEmail.Text, _idCoSo, txtDiaChi.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Thêm thành công','','success').then(function(){grvList.Refresh();})", true);
                }
                else
                {
                    alert.alert_Error(Page, "Thêm thất bại", "");
                }
                popupControl.ShowOnPageLoad = false;
            }
        }
        else
        {

            if (cls.Linq_Sua(Convert.ToInt32(Session["_id"].ToString()), txtUserName.Text.ToLower(), passmd5, txtFullname.Text, txtPhone.Text, txtEmail.Text, _idCoSo, txtDiaChi.Text))
                alert.alert_Success(Page, "Cập nhật thành công", "");
            else alert.alert_Error(Page, "Cập nhật thất bại", "");
            popupControl.ShowOnPageLoad = false;
        }
        loadDataGiaoVienTheoCoSo();
        //}
    }
    protected void btnImport_ServerClick(object sender, EventArgs e)
    {

        if (!fuUpload.HasFile)
            alert.alert_Warning(Page, "Vui lòng chọn file excel cần nhập!", "");
        else
        {
            string fileName = fuUpload.FileName;
            string ext = Path.GetExtension(fileName);

            if (ext.ToLower() == ".xls" || ext.ToLower().Equals(".xlsx"))
            {
                string path = string.Concat(Server.MapPath("~/Excel Files/coso_" + _idCoSo + "_" + DateTime.Now.ToString("dd-MM-yyyy_hh_mm_ss") + fileName));

                //Nếu trong thư mục trùng file (name) thì xóa và lưu file excel mới
                if (File.Exists(path))
                    File.Delete(path);
                fuUpload.SaveAs(path);

                cls_ExcelApiTest eat = new cls_ExcelApiTest(path);
                eat.OpenExcel();
                int rowCount = eat.GetRowCount("Sheet1");// Sheet phải có tên là Sheet1
                try
                {
                    for (int i = 4; i <= rowCount; i++) // i = 4 tùy thuộc vào hàng nhận giá trị đầu tiên trong File Excel
                    {
                        string ngaysinh = eat.GetCellData("Sheet1", "Ngày sinh", i).Trim();
                        if (ngaysinh != "end") // chưa phải là dòng cuối cùng (không có dữ liệu) nhưng vẫn kẻ ô 
                        {
                            DateTime username_ngaysinh = Convert.ToDateTime(ngaysinh);
                            string username_username = eat.GetCellData("Sheet1", "Tài khoản", i);
                            string username_fullname = eat.GetCellData("Sheet1", " Họ tên", i);
                            string username_email = eat.GetCellData("Sheet1", "Email", i);
                            string username_gender = eat.GetCellData("Sheet1", "Giới tính", i);
                            string username_phone = eat.GetCellData("Sheet1", "Số ĐT", i);
                            string username_diachi = eat.GetCellData("Sheet1", "Địa chỉ", i);
                            string username_chucvu = eat.GetCellData("Sheet1", "Vị trí", i);
                            //lưu dữ liệu học sinh đăng ký
                            admin_User user = new admin_User();
                            user.username_username = username_username;
                            user.username_password = "12378248145104161527610811213823414203124130"; //MD5 12345
                            user.username_fullname = username_fullname;
                            if (username_gender == "Nữ")
                            {
                                user.username_gender = false;
                            }
                            else
                            {
                                user.username_gender = true;
                            }
                            user.username_phone = username_phone;
                            user.username_email = username_email;
                            user.username_active = true;
                            user.groupuser_id = 3;
                            user.username_diachi = username_diachi;
                            user.username_ngaysinh = username_ngaysinh;
                            user.chucvu_id = username_chucvu;
                            user.coso_id = 2;
                            user.bophan_id = 4;
                            db.admin_Users.InsertOnSubmit(user);
                            db.SubmitChanges();
                        }
                        else
                            break;
                    }
                    eat.CloseExcel();
                    alert.alert_Success(Page, "Lưu dữ liệu thành công!", "");
                }
                catch
                {
                    alert.alert_Error(Page, "Đã có lỗi xảy ra, Vui lòng liên hệ IT!", "");
                    eat.CloseExcel();
                }
                loadDataGiaoVienTheoCoSo();
            }
            else
                alert.alert_Warning(Page, "File chọn không đúng định dạng!", "");
        }
    }
}