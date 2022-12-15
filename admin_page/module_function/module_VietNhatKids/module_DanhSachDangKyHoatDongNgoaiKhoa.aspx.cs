using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_VietNhatKids_module_DanhSachDangKyHoatDongNgoaiKhoa : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private static int _idNamhoc;
    private int _id;
    private static int id_CoSo;
    private static int _idUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            try
            {
                //get năm học hiện tại
                _idNamhoc = db.tbHoctap_NamHocs.Select(x => x.namhoc_id).ToList().Last();
                var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
                id_CoSo = Convert.ToInt32(checkuserid.coso_id);
                _idUser = checkuserid.username_id;
                if (db.tbGiaoVienTrongLops.Any(gv => gv.taikhoan_id == checkuserid.username_id && gv.namhoc_id == _idNamhoc))
                {
                    int id_Lop = Convert.ToInt32((from u in db.admin_Users
                                                  join gvtl in db.tbGiaoVienTrongLops on u.username_id equals gvtl.taikhoan_id
                                                  where u.username_username == Request.Cookies["UserName"].Value
                                                  && gvtl.namhoc_id == _idNamhoc
                                                  select gvtl).FirstOrDefault().lop_id);
                    loadDataByLop(id_Lop);
                    btnXacNhan.Visible = true;
                }
                else if (checkuserid.chucvu_id == "Hiệu Phó")
                {
                    loadDataHieuPho();
                    btnXacNhan.Visible = false;
                }
                else
                {
                    loadAllData(Convert.ToInt32(checkuserid.coso_id));
                    btnXacNhan.Visible = false;
                }
            }
            catch (Exception ex)
            {
                alert.alert_Error(Page, "Đã xảy ra lỗi, vui lòng liên hệ IT", "");
            }
        }
        else
        {
            Response.Redirect("/admin-login");
        }
    }
    //load data hiệu phó chuyên môn
    private void loadDataHieuPho()
    {
        var getData = from dknk in db.tbVietNhatKids_DangKyNangKhieus
                      join l in db.tbLops on dknk.lop_id equals l.lop_id
                      join hs in db.tbHocSinhs on dknk.hocsinh_id equals hs.hocsinh_id
                      join hstl in db.tbHocSinhTrongLops on dknk.hstl_id equals hstl.hstl_id
                      join nh in db.tbHoctap_NamHocs on dknk.namhoc_id equals nh.namhoc_id
                      join pq in db.tbQuanTriMamNon_PhanQuyenPhienChes on l.khoi_id equals pq.khoi_id
                      join u in db.admin_Users on pq.username_id equals u.username_id
                      where hs.coso_id == id_CoSo && hstl.hidden == false
                       && l.coso_id == id_CoSo
                      && pq.username_id == _idUser
                      && dknk.namhoc_id == _idNamhoc && dknk.dangkynangkhieu_cate == ddlLoaiChuongTrinh.SelectedValue
                      orderby dknk.dangkynangkhieu_tinhtrang ascending, dknk.dangkynangkhieu_datecreate descending
                      select new
                      {
                          dknk.dangkynangkhieu_id,
                          dknk.dangkynangkhieu_datecreate,
                          chuongtrinhdangky = dknk.dangkynangkhieu_cate == "hoc ve" ? "Học vẽ" : dknk.dangkynangkhieu_cate == "hoc tieng anh" ? "Học tiếng anh" : "Học aerobic",
                          l.lop_name,
                          l.lop_id,
                          hs.hocsinh_id,
                          hs.hocsinh_name,
                          nh.namhoc_id,
                          nh.namhoc_nienkhoa,
                          tinhtrang = dknk.dangkynangkhieu_tinhtrang == 0 ? "Chưa xác nhận" : "Đã xác nhận"
                      };
        grvList.DataSource = getData;
        grvList.DataBind();
    }
    //load data toàn cơ sơ
    private void loadAllData(int coso_id)
    {
        var getData = from dknk in db.tbVietNhatKids_DangKyNangKhieus
                          //join ctnk in db.tbVietNhatKids_NgoaiKhoas on dknk.ngoaikhoa_id equals ctnk.ngoaikhoa_id
                      join l in db.tbLops on dknk.lop_id equals l.lop_id
                      join hs in db.tbHocSinhs on dknk.hocsinh_id equals hs.hocsinh_id
                      join hstl in db.tbHocSinhTrongLops on dknk.hstl_id equals hstl.hstl_id
                      join nh in db.tbHoctap_NamHocs on dknk.namhoc_id equals nh.namhoc_id
                      where hs.coso_id == coso_id && hstl.hidden == false
                      && dknk.namhoc_id == _idNamhoc && dknk.dangkynangkhieu_cate == ddlLoaiChuongTrinh.SelectedValue
                      orderby dknk.dangkynangkhieu_tinhtrang ascending, dknk.dangkynangkhieu_datecreate descending
                      select new
                      {
                          dknk.dangkynangkhieu_id,
                          dknk.dangkynangkhieu_datecreate,
                          chuongtrinhdangky = dknk.dangkynangkhieu_cate == "hoc ve" ? "Học vẽ" : dknk.dangkynangkhieu_cate == "hoc tieng anh" ? "Học tiếng anh" : "Học aerobic",
                          l.lop_name,
                          l.lop_id,
                          hs.hocsinh_id,
                          hs.hocsinh_name,
                          nh.namhoc_id,
                          nh.namhoc_nienkhoa,
                          tinhtrang = dknk.dangkynangkhieu_tinhtrang == 0 ? "Chưa xác nhận" : "Đã xác nhận"
                      };
        grvList.DataSource = getData;
        grvList.DataBind();
    }
    //load data theo từng lớp
    private void loadDataByLop(int lop_id)
    {
        var getData = from dknk in db.tbVietNhatKids_DangKyNangKhieus
                          //join ctnk in db.tbVietNhatKids_NgoaiKhoas on dknk.ngoaikhoa_id equals ctnk.ngoaikhoa_id
                      join l in db.tbLops on dknk.lop_id equals l.lop_id
                      join hs in db.tbHocSinhs on dknk.hocsinh_id equals hs.hocsinh_id
                      join hstl in db.tbHocSinhTrongLops on dknk.hstl_id equals hstl.hstl_id
                      join nh in db.tbHoctap_NamHocs on dknk.namhoc_id equals nh.namhoc_id
                      where l.lop_id == lop_id && hstl.hidden == false
                      && dknk.namhoc_id == _idNamhoc && dknk.dangkynangkhieu_cate == ddlLoaiChuongTrinh.SelectedValue
                      orderby dknk.dangkynangkhieu_tinhtrang ascending, dknk.dangkynangkhieu_datecreate descending
                      select new
                      {
                          dknk.dangkynangkhieu_id,
                          dknk.dangkynangkhieu_datecreate,
                          chuongtrinhdangky = dknk.dangkynangkhieu_cate == "hoc ve" ? "Học vẽ" : dknk.dangkynangkhieu_cate == "hoc tieng anh" ? "Học tiếng anh" : "Học aerobic",
                          l.lop_name,
                          l.lop_id,
                          hs.hocsinh_id,
                          hs.hocsinh_name,
                          nh.namhoc_id,
                          nh.namhoc_nienkhoa,
                          tinhtrang = dknk.dangkynangkhieu_tinhtrang == 0 ? "Chưa xác nhận" : "Đã xác nhận"
                      };
        grvList.DataSource = getData;
        grvList.DataBind();
    }
    protected void btnXacNhan_Click(object sender, EventArgs e)
    {
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "dangkynangkhieu_id" }));
        var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
        tbVietNhatKids_DangKyNangKhieu update = db.tbVietNhatKids_DangKyNangKhieus.Where(x => x.dangkynangkhieu_id == _id).FirstOrDefault();
        if (update.dangkynangkhieu_tinhtrang == 1)
        {
            alert.alert_Warning(Page, "Dữ liệu đã xác nhận", "");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "HiddenLoadingIcon()", true);
        }
        else
        {
            update.dangkynangkhieu_tinhtrang = 1;
            update.username_id = checkuserid.username_id;
            update.dangkynangkhieu_diemtichluy = 1;

            var getData = (from dp in db.tbVietNhatKids_DangKyNangKhieus
                           where dp.dangkynangkhieu_id == _id
                           select dp).FirstOrDefault();
            var getEmail = (from hs in db.tbHocSinhs
                            join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                            where hstl.hstl_id == getData.hstl_id
                             && hstl.namhoc_id == _idNamhoc && hs.hidden == null
                            orderby hstl.hstl_id descending
                            select hs).FirstOrDefault();
            tbVietNhatKids_ThongBaoPhuHuynh tb = new tbVietNhatKids_ThongBaoPhuHuynh();
            tb.hstl_id = getData.hstl_id;
            tb.namhoc_id = getData.namhoc_id;
            tb.thongbao_noidung = "Thông tin đăng ký ngoại khóa của phụ huynh đã được giáo viên xác nhận";
            tb.thongbao_ngay = DateTime.Now;
            tb.thongbao_trangthai = 0;//ph chưa xem
            tb.lop_id = getData.lop_id;
            db.tbVietNhatKids_ThongBaoPhuHuynhs.InsertOnSubmit(tb);
            //gửi mail về cho ph
            db.SubmitChanges();
            string message = "Thông tin đăng ký ngoại khóa của phụ huynh bé " + getEmail.hocsinh_name + " đã được giáo viên chủ nhiệm xác nhận!";
            SendMail("quyetlv@vjis.edu.vn", message);
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Đã xác nhận thành công','','success').then(function(){grvList.Refresh();grvList.UnselectRows();HiddenLoadingIcon()})", true);
            //ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Đã xác nhận thành công','','success').then(function(){grvList.Refresh();location.reload();})", true);
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

    protected void btnXuatExcel_ServerClick(object sender, EventArgs e)
    {
        try
        {
            _idNamhoc = db.tbHoctap_NamHocs.Select(x => x.namhoc_id).ToList().Last();
            var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
            //int id_Lop = Convert.ToInt32((from u in db.admin_Users
            //                              join gvtl in db.tbGiaoVienTrongLops on u.username_id equals gvtl.taikhoan_id
            //                              where u.username_username == Request.Cookies["UserName"].Value
            //                              && gvtl.namhoc_id == _idNamhoc
            //                              select gvtl).FirstOrDefault().lop_id);
            string constr = ConfigurationManager.ConnectionStrings["db_quantrimamnon_testConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(
                    "select hocsinh_name as [Họ và tên học sinh], " +
                    "lop_name as [Lớp], " +
                    "(case dangkynangkhieu_cate when 'hoc ve' then N'Học vẽ' when 'hoc tieng anh' then N'Học tiếng anh' else N'Học aerobic' end) as [Chương trình đăng ký], " +
                    "dangkynangkhieu_datecreate as [Ngày đăng ký], " +
                    "namhoc_nienkhoa as [Năm học], " +
                    "(case dangkynangkhieu_tinhtrang when '0' then N'Chưa xác nhận' else N'Đã xác nhận' end) as [Tình trạng] " +
                    "from tbVietNhatKids_DangKyNangKhieu,tbLop,tbHocSinh,tbHoctap_NamHoc " +
                    "where tbVietNhatKids_DangKyNangKhieu.dangkynangkhieu_cate = '" + ddlLoaiChuongTrinh.SelectedValue + "' and " +
                    "tbLop.coso_id =" + checkuserid.coso_id + " and " +
                    "tbLop.lop_id = tbVietNhatKids_DangKyNangKhieu.lop_id and " +
                    "tbHocSinh.hocsinh_id = tbVietNhatKids_DangKyNangKhieu.hocsinh_id and " +
                    "tbHoctap_NamHoc.namhoc_id = tbVietNhatKids_DangKyNangKhieu.namhoc_id and " +
                    "tbVietNhatKids_DangKyNangKhieu.namhoc_id = " + _idNamhoc +
                    "ORDER BY tbVietNhatKids_DangKyNangKhieu.dangkynangkhieu_tinhtrang ASC, tbVietNhatKids_DangKyNangKhieu.dangkynangkhieu_datecreate DESC"
                    ))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                wb.Worksheets.Add(dt, "Customers");

                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=DanhSachDangKyNgoaiKhoa_CoSo" + checkuserid.coso_id + ".xlsx");
                                Response.ContentEncoding = System.Text.Encoding.UTF8;
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }
        }
        catch { }
    }
}