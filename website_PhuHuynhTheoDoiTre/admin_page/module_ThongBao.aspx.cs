using DevExpress.Web.ASPxHtmlEditor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class website_PhuHuynhTheoDoiTre_admin_page_module_ThongBao : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
    private static int _idUser;
    private static int _idNamHoc;
    private static int id_Lop;
    protected void Page_Load(object sender, EventArgs e)
    {
        edtnoidung.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
        if (Request.Cookies["UserName"] != null)
        {
            var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
            var checkNamHoc = (from nh in db.tbHoctap_NamHocs orderby nh.namhoc_id descending select nh).First();
            id_Lop = Convert.ToInt32((from u in db.admin_Users
                                      join gvtl in db.tbGiaoVienTrongLops on u.username_id equals gvtl.taikhoan_id
                                      where u.username_username == Request.Cookies["UserName"].Value
                                      && gvtl.namhoc_id == checkNamHoc.namhoc_id
                                      select gvtl).FirstOrDefault().lop_id);
            _idUser = checkuserid.username_id;
            _idNamHoc = checkNamHoc.namhoc_id;
            // id_Lop = Convert.ToInt32(checkuserid.lop);
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
        var checkNamHoc = (from nh in db.tbHoctap_NamHocs
                           orderby nh.namhoc_id descending
                           select nh).First();
        // load data đổ vào var danh sách
        var getData = from nc in db.tbThongBaos
                      join u in db.admin_Users on nc.username_id equals u.username_id
                      join gvtl in db.tbGiaoVienTrongLops on u.username_id equals gvtl.taikhoan_id
                      where nc.lop_id == id_Lop && gvtl.namhoc_id == checkNamHoc.namhoc_id
                      orderby nc.thongbao_hidden ascending, nc.thongbao_datecreate descending
                      select new
                      {
                          nc.thongbao_id,
                          nc.thongbao_title,
                          //thongbao_datecreate = nc.thongbao_datecreate.Value.ToString("dd/MM/yyyy hh:MM tt", CultureInfo.InvariantCulture),
                          trangthai = nc.thongbao_tinhtrang == 0 ? "Chưa duyệt" : "Đã duyệt",
                          u.username_fullname,
                          //slide_active = nc.slide_active == true ? "Đã hiển thị" : "Chưa hiển thị",
                      };
        // đẩy dữ liệu vào gridivew

        grvList.DataSource = getData;
        grvList.DataBind();
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
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupControl.Show();", true);
        loadData();
    }

    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        // get value từ việc click vào gridview
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "thongbao_id" }));
        // đẩy id vào session
        Session["_id"] = _id;
        var getData = (from nc in db.tbThongBaos
                       where nc.thongbao_id == _id
                       select new
                       {
                           nc.thongbao_id,
                           nc.thongbao_title,
                           nc.thongbao_content,
                           nc.thongbao_datecreate,
                           nc.thongbao_tinhtrang,
                           nc.username_id,
                       }).Single();
        txtTitle.Text = getData.thongbao_title;
        edtnoidung.Html = getData.thongbao_content;
        if (getData.thongbao_tinhtrang > 0 || getData.username_id != _idUser)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "myKhoaCapNhat()", true);
        }
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show();", true);
        loadData();
    }

    public bool checknull()
    {
        if (txtTitle.Text != "")
            return true;
        else return false;
    }

    public void delete(string sFileName)
    {
        if (sFileName != String.Empty)
        {
            if (File.Exists(sFileName))

                File.Delete(sFileName);
        }
    }

    protected void btnXoa_Click(object sender, EventArgs e)
    {
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "thongbaoLop_id" });
        if (selectedKey.Count == 0)
        {
            alert.alert_Warning(Page, "Bạn chưa chọn dữ liệu!", "");
        }
        else if (selectedKey.Count > 1)
        {
            alert.alert_Warning(Page, "Chỉ được chọn 1 dữ liệu để xóa!", "");
        }
        else
        {
            var getData = (from nc in db.tbThongBaos
                           where nc.thongbao_id == Convert.ToInt32(selectedKey[0])
                           select nc).Single();
            if (getData.thongbao_tinhtrang > 0)
            {
                alert.alert_Error(Page, "Không thể xóa dữ liệu đã được duyệt", "");
            }
            else if (getData.username_id != _idUser)
            {
                alert.alert_Error(Page, "Bạn không thể xóa dữ liệu này", "");
            }
            else
            {
                db.tbThongBaos.DeleteOnSubmit(getData);
                db.SubmitChanges();
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Xóa thành công','','success').then(function(){grvList.Refresh();})", true);
            }
        }
    }
    private bool SendMail(string email, string message)
    {
        if (email != "")
        {
            try
            {
                var fromAddress = "thongbaovietnhatschool@gmail.com";//  Email Address from where you send the mail 
                var toAddress = email;
                const string fromPassword = "neiabcekdjluofid";
                string subject, title;
                title = "Thông báo";
                subject = "<!DOCTYPE html><html><head><title></title></head><body ><div>" +
                "<h3 style=\"margin-top:0px; text-align:center; color:#029ada\">" + message + "</h3>" +
                "</div></body></html>";
                var smtp = new System.Net.Mail.SmtpClient();
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                    smtp.Timeout = 20000;
                }
                MailMessage mm = new MailMessage();
                mm.From = new MailAddress(fromAddress, "Trường Mầm non Việt Nhật");
                mm.Subject = title;
                mm.To.Add(toAddress);
                mm.IsBodyHtml = true;
                mm.Body = subject;
                smtp.Send(mm);
                return true;
            }
            catch
            {
                return false;
            }
        }
        else
            return false;
    }

    protected void btnLuu_Click(object sender, EventArgs e)
    {
        cls_ThongBao cls = new cls_ThongBao();

        if (checknull() == false)
            alert.alert_Warning(Page, "Tiêu đề không được để trống!", "");
        else
        {
            var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
            if (Session["_id"].ToString() == "0")
            {
                if (cls.Linq_Them(txtTitle.Text, edtnoidung.Html, id_Lop, _idUser, _idNamHoc))
                {
                    var getEmail = from u in db.admin_Users
                                   select u;
                    string listEmail = string.Join(",", getEmail.Select(x => x.username_email).ToArray());
                    alert.alert_Success(Page, "Thêm thành công", "");
                    popupControl.ShowOnPageLoad = false;
                    loadData();
                    string message = "Bạn có thông báo mới cần xác nhận. Xem chi tiết <a href='http://quantrimamnon.vietnhatschool.edu.vn/thong-bao-lop-duyet'>tại đây.</a>";
                    //SendMail(listEmail + ", quyetlv@vjis.edu.vn", message);
                }
                else alert.alert_Error(Page, "Thêm thất bại", "");

            }
            else
                if (cls.Linq_Sua(Convert.ToInt32(Session["_id"].ToString()), txtTitle.Text, edtnoidung.Html))
            {
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Cập nhật thành công','','success').then(function(){grvList.Refresh();})", true);
                popupControl.ShowOnPageLoad = false;
                loadData();
            }
            else alert.alert_Error(Page, "Cập nhật thất bại", "");
        }

        loadData();
    }
}