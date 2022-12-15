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

public partial class admin_page_module_function_module_WebSite_module_PhuHuynhXinNghi : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
    private static int _idUser;
    private static int id_Lop;
    private static int id_NamHoc;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
            _idUser = checkuserid.username_id;
            var checkNamHoc = (from nh in db.tbHoctap_NamHocs orderby nh.namhoc_id descending select nh).First();
            id_NamHoc = checkNamHoc.namhoc_id;
            if (!IsPostBack)
            {
                Session["_id"] = 0;
            }
            if (db.tbGiaoVienTrongLops.Any(x => x.taikhoan_id == checkuserid.username_id && x.namhoc_id == checkNamHoc.namhoc_id))
            {
                id_Lop = Convert.ToInt32((from u in db.admin_Users
                                          join gvtl in db.tbGiaoVienTrongLops on u.username_id equals gvtl.taikhoan_id
                                          where u.username_username == Request.Cookies["UserName"].Value
                                          && gvtl.namhoc_id == checkNamHoc.namhoc_id
                                          select gvtl).FirstOrDefault().lop_id);
                var listHocSinh = from hs in db.tbHocSinhs
                                  join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                                  join l in db.tbLops on hstl.lop_id equals l.lop_id
                                  where hstl.namhoc_id == checkNamHoc.namhoc_id && l.lop_id == id_Lop
                                  && hstl.hidden == false
                                  select hs;
                ddlHocSinh.DataSource = listHocSinh;
                ddlHocSinh.DataBind();
                loadData();
            }
            else
                Response.Redirect("/admin-home");
        }
        else
        {
            Response.Redirect("/admin-login");
        }
    }
    private void loadData()
    {
        // load data đổ vào var danh sách
        var getData = from hs in db.tbHocSinhs
                      join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                      join xn in db.tbVietNhatKids_PhuHuynhXinNghis on hstl.hstl_id equals xn.hstl_id
                      where hstl.lop_id == id_Lop
                      && xn.namhoc_id == id_NamHoc
                      && hstl.hidden == false
                      orderby xn.phuhuynhxinnghi_id descending, xn.phuhuynhxinnghi_xacnhan ascending
                      select new
                      {
                          xn.phuhuynhxinnghi_id,
                          hs.hocsinh_name,
                          xn.phuhuynhxinnghi_datestart,
                          xn.phuhuynhxinnghi_dateend,
                          xn.phuhuynhxinnghi_content,
                          phuhuynhxinnghi_ngaydangki = xn.phuhuynhxinnghi_ngaydangki.Value.ToString("dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                          phuhuynhxinnghi_xacnhan = xn.phuhuynhxinnghi_xacnhan == false ? "Chưa xác nhận" : "Đã xác nhận"
                      };
        // đẩy dữ liệu vào gridivew
        grvList.DataSource = getData;
        grvList.DataBind();
    }


    protected void btnChiTiet_Click(object sender, EventArgs e)
    {
        // get value từ việc click vào gridview
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "phuhuynhxinnghi_id" }));
        // đẩy id vào session
        Session["_id"] = _id;
        var getData = (from hs in db.tbHocSinhs
                       join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                       join xn in db.tbVietNhatKids_PhuHuynhXinNghis on hstl.hstl_id equals xn.hstl_id
                       where hstl.lop_id == id_Lop
                       orderby xn.phuhuynhxinnghi_id descending
                       select new
                       {
                           hs.hocsinh_name,
                           xn.phuhuynhxinnghi_datestart,
                           xn.phuhuynhxinnghi_dateend,
                           xn.phuhuynhxinnghi_content,
                           phuhuynhxinnghi_xacnhan = xn.phuhuynhxinnghi_xacnhan == false ? "Chưa xác nhận" : "Đã xác nhận"
                       }).Single();
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show();", true);
        loadData();
    }


    protected void btnXacNhan_Click(object sender, EventArgs e)
    {
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "phuhuynhxinnghi_id" }));
        tbVietNhatKids_PhuHuynhXinNghi update = (from xn in db.tbVietNhatKids_PhuHuynhXinNghis
                                                 where xn.phuhuynhxinnghi_id == _id
                                                 select xn).SingleOrDefault();
        if (update.phuhuynhxinnghi_xacnhan == true)
        {
            alert.alert_Warning(Page, "Dữ liệu đã xác nhận", "");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "HiddenLoadingIcon()", true);
        }
        else
        {
            update.phuhuynhxinnghi_diemtichluy = 1;
            update.phuhuynhxinnghi_xacnhan = true;
            update.username_id = _idUser;
            //tbVietNhatKids_XacNhanNghi insert = new tbVietNhatKids_XacNhanNghi();

            var getData = (from phxn in db.tbVietNhatKids_PhuHuynhXinNghis
                           where phxn.phuhuynhxinnghi_id == _id
                           select phxn
                           ).FirstOrDefault();
            DateTime ngayBatDau = Convert.ToDateTime(getData.phuhuynhxinnghi_datestart);
            DateTime ngayKetThuc = Convert.ToDateTime(getData.phuhuynhxinnghi_dateend);

            TimeSpan soNgayNghi = ngayKetThuc - ngayBatDau;
            //for (int i = 0; i <= soNgayNghi.Days; i++)
            //{
            //    tbVietNhatKids_XacNhanNghi insert = new tbVietNhatKids_XacNhanNghi();
            //    insert.hstl_id = getData.hstl_id;
            //    insert.phuhuynhxinnghi_datestart = ngayBatDau.AddDays(i);
            //    insert.phuhuynhxinnghi_id = _id;
            //    db.tbVietNhatKids_XacNhanNghis.InsertOnSubmit(insert);
            //}
            //lưu thông báo cho phụ huynh
            var getEmail = (from hs in db.tbHocSinhs
                            join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                            where hstl.hstl_id == getData.hstl_id
                             && hstl.namhoc_id == id_NamHoc
                            select hs).FirstOrDefault();
            tbVietNhatKids_ThongBaoPhuHuynh tb = new tbVietNhatKids_ThongBaoPhuHuynh();
            tb.hstl_id = getData.hstl_id;
            tb.namhoc_id = getData.namhoc_id;
            tb.thongbao_noidung = "Xin nghỉ học của phụ huynh đã được giáo viên xác nhận";
            tb.thongbao_ngay = DateTime.Now;
            tb.thongbao_trangthai = 0;//ph chưa xem
            tb.lop_id = getData.lop_id;
            tb.thongbao_link = "/vietnhatkids-xin-nghi";
            db.tbVietNhatKids_ThongBaoPhuHuynhs.InsertOnSubmit(tb);
            //gửi mail về cho ph
            db.SubmitChanges();
            alert.alert_Success(Page, "Đã gửi mail thông báo xác nhận về phụ huynh", "");
            string message = "Thông báo xin nghỉ học của phụ huynh bé " + getEmail.hocsinh_name + " đã được giáo viên chủ nhiệm xác nhận. Xem chi tiết <a href='http://quantrimamnon.vietnhatschool.edu.vn/vietnhatkids-xin-nghi'>tại đây.</a>";
            SendMail(getEmail.hocsinh_email + ", ducpn@vjis.edu.vn, quyetlv@vjis.edu.vn", message);
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "grvList.Refresh();HiddenLoadingIcon()", true);
            // đẩy dữ liệu vào gridivew
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

    protected void btnCapNhatNgayNghi_Click(object sender, EventArgs e)
    {
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "phuhuynhxinnghi_id" }));
        // đẩy id vào session
        Session["_id"] = _id;
        var getData = (from nc in db.tbVietNhatKids_PhuHuynhXinNghis
                       join hstl in db.tbHocSinhTrongLops on nc.hstl_id equals hstl.hstl_id
                       join hs in db.tbHocSinhs on hstl.hocsinh_id equals hs.hocsinh_id
                       where nc.phuhuynhxinnghi_id == _id
                       select new
                       {
                           nc.phuhuynhxinnghi_id,
                           nc.phuhuynhxinnghi_dateend,
                           nc.phuhuynhxinnghi_datestart,
                           hs.hocsinh_name,

                       }).Single();
        txtHoTen.Text = getData.hocsinh_name;
        txtTuNgay.Value = getData.phuhuynhxinnghi_datestart.Value.ToString("yyyy-MM-dd").Replace(' ', 'T');
        txtDenNgay.Value = getData.phuhuynhxinnghi_dateend.Value.ToString("yyyy-MM-dd").Replace(' ', 'T');
        div_ThemMoi.Visible = false;
        div_CapNhat.Visible = true;
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupControl.Show();", true);
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        try
        {
            tbVietNhatKids_PhuHuynhXinNghi update = (from xn in db.tbVietNhatKids_PhuHuynhXinNghis
                                                     where xn.phuhuynhxinnghi_id == Convert.ToInt32(Session["_id"].ToString())
                                                     select xn).SingleOrDefault();
            update.phuhuynhxinnghi_datestart = Convert.ToDateTime(txtTuNgay.Value);
            update.phuhuynhxinnghi_dateend = Convert.ToDateTime(txtDenNgay.Value);
            db.SubmitChanges();
            alert.alert_Success(Page, "Cập nhật thành công!", "");
            loadData();
            popupControl.ShowOnPageLoad = false;
            string message = "Giáo viên chủ nhiệm đã cập nhật lại ngày nghỉ của bé. Xem chi tiết <a href='http://quantrimamnon.vietnhatschool.edu.vn/vietnhatkids-xin-nghi'>tại đây.</a>";
            SendMail("ducpn@vjis.edu.vn", message);
        }
        catch { }
    }

    private void setNull()
    {
        dteTuNgay.Value = "";
        dteDenNgay.Value = "";
        txtLyDo.Value = "";
    }
    protected void btnThemMoi_Click(object sender, EventArgs e)
    {
        // Khi nhấn nút thêm thì mật định session id = 0 để thêm mới
        Session["_id"] = 0;
        setNull();
        div_ThemMoi.Visible = true;
        div_CapNhat.Visible = false;
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Insert", "popupControl.Show();", true);
    }

    protected void btnLuuThemMoi_Click(object sender, EventArgs e)
    {
        try
        {
            div_CapNhat.Visible = false;
            if (Session["_id"].ToString() == "0")
            {
                if (ddlHocSinh.Value == null)
                {
                    alert.alert_Warning(Page, "Vui lòng chọn học sinh cần xin nghỉ", "");
                }
                else if (dteDenNgay.Value == "")
                {
                    alert.alert_Warning(Page, "Vui lòng chọn ngày kết thúc", "");
                }
                else
                {
                    var checkHS = (from hstl in db.tbHocSinhTrongLops
                                   where hstl.hocsinh_id == Convert.ToInt32(ddlHocSinh.SelectedItem.Value)
                                   && hstl.namhoc_id == id_NamHoc
                                   select hstl).First();
                    tbVietNhatKids_PhuHuynhXinNghi insert = new tbVietNhatKids_PhuHuynhXinNghi();
                    //Gắn dữ liệu vào
                    insert.phuhuynhxinnghi_datestart = Convert.ToDateTime(dteTuNgay.Value);
                    insert.phuhuynhxinnghi_dateend = Convert.ToDateTime(dteDenNgay.Value);
                    insert.phuhuynhxinnghi_content = txtLyDo.Value;
                    insert.hstl_id = checkHS.hstl_id;
                    insert.lop_id = id_Lop;
                    insert.namhoc_id = id_NamHoc;
                    insert.hocki_id = 1;
                    insert.phuhuynhxinnghi_xacnhan = true;
                    insert.phuhuynhxinnghi_diemtichluy = 1;
                    insert.username_id = _idUser;
                    insert.phuhuynhxinnghi_ngaydangki = DateTime.Now;
                    //Insert data
                    db.tbVietNhatKids_PhuHuynhXinNghis.InsertOnSubmit(insert);
                    //Sava data
                    db.SubmitChanges();
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Đăng ký thành công!','','success').then(function(){grvList.Refresh();})", true);
                    popupControl.ShowOnPageLoad = false;
                }
            }
            else
            {
                tbVietNhatKids_PhuHuynhXinNghi update = (from xn in db.tbVietNhatKids_PhuHuynhXinNghis
                                                         where xn.phuhuynhxinnghi_id == Convert.ToInt32(Session["_id"].ToString())
                                                         select xn).SingleOrDefault();
                update.phuhuynhxinnghi_datestart = Convert.ToDateTime(txtTuNgay.Value);
                update.phuhuynhxinnghi_dateend = Convert.ToDateTime(txtDenNgay.Value);
                db.SubmitChanges();
                alert.alert_Success(Page, "Cập nhật thành công!", "");
                loadData();
                popupControl.ShowOnPageLoad = false;
                string message = "Giáo viên chủ nhiệm đã cập nhật lại ngày nghỉ của bé. Xem chi tiết <a href='http://quantrimamnon.vietnhatschool.edu.vn/vietnhatkids-xin-nghi'>tại đây.</a>";
                SendMail("ducpn@vjis.edu.vn, quyetlv@vjis.edu.vn", message);
            }
        }
        catch (Exception ex)
        {
            alert.alert_Error(Page, "Đã có lỗi xảy ra, vui lòng liên hệ IT", "");
        }

    }
}