using DevExpress.Web.ASPxHtmlEditor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_WebSite_module_ThongBaoLop_Duyet : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
    private static int _idUser;
    private static int id_Lop;
    private static int id_CoSo;
    string chucvu;
    protected void Page_Load(object sender, EventArgs e)
    {
        edtnoidung.Toolbars.Add(HtmlEditorToolbar.CreateStandardToolbar1());
        if (Request.Cookies["UserName"] != null)
        {
            var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
            //id_Lop = Convert.ToInt32((from u in db.admin_Users
            //                          join gvtl in db.tbGiaoVienTrongLops on u.username_id equals gvtl.taikhoan_id
            //                          where u.username_username == Request.Cookies["UserName"].Value
            //                          select gvtl).FirstOrDefault().lop_id);
            chucvu = checkuserid.chucvu_id;
            id_CoSo = Convert.ToInt32(checkuserid.coso_id);
            _idUser = checkuserid.username_id;
            if (!IsPostBack)
            {
                Session["_id"] = 0;
            }
            if (chucvu == "Hiệu Phó")
                if (id_CoSo == 1)
                    loadDataCoSo1();
                else
                    loadData();

            if (chucvu == "Hiệu Trưởng")
                loadDataCoSo();
        }
        else
        {
            Response.Redirect("/admin-login");
        }
    }
    private void loadData()
    {
        // load data đổ vào var danh sách
        var getData = from nc in db.tbVietNhatKids_ThongBaoLops
                      join l in db.tbLops on nc.lop_id equals l.lop_id
                      join pq in db.tbQuanTriMamNon_PhanQuyenPhienChes on l.khoi_id equals pq.khoi_id
                      join u in db.admin_Users on pq.username_id equals u.username_id
                      where l.hidden == false
                      && nc.thongbaolop_tinhtrang == 0
                      && l.coso_id == id_CoSo
                      && pq.username_id == _idUser
                      orderby nc.thongbaoLop_datecreate descending
                      select new
                      {
                          nc.thongbaoLop_id,
                          nc.thongbaoLop_title,
                          thongbaolop_datecreate = nc.thongbaoLop_datecreate.Value.ToString("dd/MM/yyyy hh:MM tt", CultureInfo.InvariantCulture),
                          l.lop_name,
                          trangthai = nc.thongbaolop_tinhtrang == 0 ? "Chưa duyệt" : "Đã duyệt"
                      };
        // đẩy dữ liệu vào gridivew
        grvList.DataSource = getData;
        grvList.DataBind();
    }
    //load dữ liệu dàng riêng cho cs 1 (cô oanh duyệt hết)
    private void loadDataCoSo1()
    {
        var getData = from nc in db.tbVietNhatKids_ThongBaoLops
                      join l in db.tbLops on nc.lop_id equals l.lop_id
                      //join pq in db.tbQuanTriMamNon_PhanQuyenPhienChes on l.khoi_id equals pq.khoi_id
                      //join u in db.admin_Users on pq.username_id equals u.username_id
                      where l.hidden == false
                      && nc.thongbaolop_tinhtrang == 0
                      && l.coso_id == id_CoSo
                      //&& pq.username_id == _idUser
                      orderby nc.thongbaoLop_datecreate descending
                      select new
                      {
                          nc.thongbaoLop_id,
                          nc.thongbaoLop_title,
                          thongbaolop_datecreate = nc.thongbaoLop_datecreate.Value.ToString("dd/MM/yyyy hh:MM tt", CultureInfo.InvariantCulture),
                          l.lop_name,
                          trangthai = nc.thongbaolop_tinhtrang == 0 ? "Chưa duyệt" : "Đã duyệt"
                      };
        // đẩy dữ liệu vào gridivew
        grvList.DataSource = getData;
        grvList.DataBind();
    }
    private void loadDataCoSo()
    {
        // load data đổ vào var danh sách
        var getData = from nc in db.tbVietNhatKids_ThongBaoLops
                      join l in db.tbLops on nc.lop_id equals l.lop_id
                      where l.hidden == false && nc.thongbaolop_tinhtrang == 1 && l.coso_id == id_CoSo
                      orderby nc.thongbaoLop_datecreate descending
                      select new
                      {
                          nc.thongbaoLop_id,
                          nc.thongbaoLop_title,
                          thongbaolop_datecreate = nc.thongbaoLop_datecreate.Value.ToString("dd/MM/yyyy hh:MM tt", CultureInfo.InvariantCulture),
                          l.lop_name,
                          trangthai = nc.thongbaolop_tinhtrang != 2 ? "Chưa duyệt" : "Đã duyệt"
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
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "thongbaoLop_id" }));
        // đẩy id vào session
        Session["_id"] = _id;
        var getData = (from nc in db.tbVietNhatKids_ThongBaoLops
                       where nc.thongbaoLop_id == _id
                       select new
                       {
                           nc.thongbaoLop_id,
                           nc.thongbaoLop_title,
                           nc.thongbaoLop_content,
                           nc.thongbaoLop_datecreate,
                       }).Single();
        txtTitle.Text = getData.thongbaoLop_title;
        edtnoidung.Html = getData.thongbaoLop_content;
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
        cls_ThongBaoLop cls = new cls_ThongBaoLop();

        //if (checknull() == false)
        //    alert.alert_Warning(Page, "Hãy Tích Vào Vị trí!", "");
        //else
        //{
        //if (Session["_id"].ToString() == "0")
        //{

        //    if (cls.Linq_Them(txtTitle.Text, edtnoidung.Html, id_Lop))
        //    {

        //        alert.alert_Success(Page, "Thêm thành công", "");
        //        popupControl.ShowOnPageLoad = false;
        //        loadData();
        //    }
        //    else alert.alert_Error(Page, "Thêm thất bại", "");

        //}
        //else
        //string test_link = HttpContext.Current.Request.Url.PathAndQuery.Remove(0, 1);
        if (chucvu == "Hiệu Phó")
        {
            if (cls.Linq_DuyetHieuPho(Convert.ToInt32(Session["_id"].ToString()), id_CoSo, _idUser, txtTitle.Text))
            {
                var getEmail = from u in db.admin_Users
                               where u.coso_id == id_CoSo
                               && u.chucvu_id == "Hiệu Trưởng"
                               select u;
                string listEmail = string.Join(",", getEmail.Select(x => x.username_email).ToArray());
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Duyệt thành công','','success').then(function(){grvList.Refresh();})", true);
                popupControl.ShowOnPageLoad = false;
                loadData();
                string message = "Bạn có thông báo mới cần xác nhận. Xem chi tiết <a href='http://quantrimamnon.vietnhatschool.edu.vn/thong-bao-lop-duyet'>tại đây.</a>";
                //SendMail(listEmail + ", quyetlv@vjis.edu.vn", message);
            }
            else alert.alert_Error(Page, "Cập nhật thất bại", "");
        }
        if (chucvu == "Hiệu Trưởng")
        {
            if (cls.Linq_DuyetHieuTruong(Convert.ToInt32(Session["_id"].ToString())))
            {
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Duyệt thành công','','success').then(function(){grvList.Refresh();})", true);
                popupControl.ShowOnPageLoad = false;
                loadData();
            }
            else alert.alert_Error(Page, "Cập nhật thất bại", "");
        }
        //}

        loadData();
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
        cls_ThongBaoLop cls;
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "thongbaoLop_id" });
        if (selectedKey.Count > 0)
        {
            foreach (var item in selectedKey)
            {
                cls = new cls_ThongBaoLop();
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

    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        tbVietNhatKids_ThongBaoLop update = db.tbVietNhatKids_ThongBaoLops.Where(x => x.thongbaoLop_id == Convert.ToInt32(Session["_id"].ToString())).FirstOrDefault();
        update.thongbaoLop_title = txtTitle.Text;
        update.thongbaoLop_content = edtnoidung.Html;
        db.SubmitChanges();
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Cập nhật thành công!','','success').then(function(){grvList.UnselectRows();})", true);
        popupControl.ShowOnPageLoad = false;
    }
}