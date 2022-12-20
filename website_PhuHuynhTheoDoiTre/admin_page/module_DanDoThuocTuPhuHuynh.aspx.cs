using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class website_PhuHuynhTheoDoiTre_admin_page_module_DanDoThuocTuPhuHuynh : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
    private static int _idUser;
    private static int CoSo;
    private static int id_Lop;
    private static int id_NamHoc;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
            var checkNamHoc = (from nh in db.tbHoctap_NamHocs orderby nh.namhoc_id descending select nh).First();
            id_NamHoc = checkNamHoc.namhoc_id;
            _idUser = (from u in db.admin_Users
                       where u.username_username == Request.Cookies["UserName"].Value
                       select u).FirstOrDefault().username_id;
            //CoSo = Convert.ToInt32(checkuserid.coso_id);
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
                loadData(id_Lop);
            }
            //else
                //Response.Redirect("/admin-home");
            //loadData();
        }
        else
        {
            Response.Redirect("/admin-login");
        }
    }
    private void loadData(int id_lop)
    {
        // load data đổ vào var danh sách
        var getData = from nc in db.tbDanDoThuocs
                      join hstl in db.tbHocSinhTrongLops on nc.hstl_id equals hstl.hstl_id
                      join hs in db.tbHocSinhs on hstl.hocsinh_id equals hs.hocsinh_id
                      where hstl.lop_id == id_Lop
                      && hstl.namhoc_id == id_NamHoc
                      //&& hstl.hidden == false
                      orderby nc.phuhuynhdandothuoc_tinhtrang ascending, nc.phuhuynhdandothuoc_ngaybatdau descending
                      select new
                      {
                          hs.hocsinh_name,
                          nc.phuhuynhdandothuoc_Lydo,
                          nc.phuhuynhdandothuoc_id,
                          nc.phuhuynhdandothuoc_ngaybatdau,
                          nc.phuhuynhdandothuoc_ngayketthuc,
                          nc.phuhuynhdandothuoc_noidungdando,
                          phuhuynhdandothuoc_tinhtrang = nc.phuhuynhdandothuoc_tinhtrang == true ? "Đã xác nhận" : "Chưa xác nhận"
                      };
        // đẩy dữ liệu vào gridivew
        grvList.DataSource = getData;
        grvList.DataBind();

    }

    protected void btnXacNhan_Click(object sender, EventArgs e)
    {
        _id = Convert.ToInt32(grvList.GetRowValues(grvList.FocusedRowIndex, new string[] { "phuhuynhdandothuoc_id" }));
        tbDanDoThuoc update = db.tbDanDoThuocs.Where(x => x.phuhuynhdandothuoc_id == _id).FirstOrDefault();
        if (update.phuhuynhdandothuoc_tinhtrang == true)
        {
            alert.alert_Warning(Page, "Dữ liệu đã xác nhận", "");
            // load trang
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "HiddenonLoad()", true);
        }
        else
        { 
            update.phuhuynhdandothuoc_tinhtrang = true;
            var getData = (from dp in db.tbDanDoThuocs
                           where dp.phuhuynhdandothuoc_id == _id
                           select dp).FirstOrDefault();
            var getEmail = (from hs in db.tbHocSinhs
                            join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                            where hstl.hstl_id == getData.hstl_id
                            && hstl.namhoc_id == id_NamHoc /*&& hs.hidden == null*/
                            orderby hstl.hstl_id descending
                            select hs).FirstOrDefault();
           
            //db.tbVietNhatKids_ThongBaoPhuHuynhs.InsertOnSubmit(tb);
            db.SubmitChanges();
            string message = "Thông tin dặn thuốc của phụ huynh bé " + getEmail.hocsinh_name + " đã được giáo viên chủ nhiệm xác nhận!";
            SendMail(getEmail.hocsinh_emaillba + "," + getEmail.hocsinh_emaillba, message);
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Đã xác nhận thành công','','success').then(function(){HiddenonLoad();grvList.Refresh();grvList.UnselectRows();})", true);
            loadData(id_Lop);

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
}
   