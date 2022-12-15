﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class web_module_module_website_website_VietNhatKis_web_XinNghi : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    public int STT = 1;
    string _sdtHocSinh = "";
    int id_HocSinh = 0;
    int _idNamHoc = 0;
    string s;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["web_hocsinh"] != null)
        {
           
            _sdtHocSinh = Request.Cookies["web_hocsinh"].Value;
            var getIDHS = (from u in db.tbHocSinhs
                           where u.hocsinh_taikhoan == _sdtHocSinh
                           && u.hidden == null
                           orderby u.hocsinh_id descending
                           select u).First();
            id_HocSinh = getIDHS.hocsinh_id;
            var getNamHoc = (from nh in db.tbHoctap_NamHocs
                             orderby nh.namhoc_id descending
                             select nh).First();
            _idNamHoc = getNamHoc.namhoc_id;
            //if (!IsPostBack) { 
            //ddlNam.DataSource = getNamHoc;
            //ddlNam.DataTextField = "_namHoc_nienkhoa";
            //ddlNam.DataValueField = "_namhoc_id";
            //ddlNam.DataBind();
            //_idNamHoc = _idNamHoc;
            //lblNam.Text = (ddlNam.SelectedItem).ToString();
            ////xuat lịch sử xn
            //}
            var getListXinNghi = from hs in db.tbHocSinhs
                                 join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id //thong qua hstl để join phxn
                                 join phxn in db.tbVietNhatKids_PhuHuynhXinNghis on hstl.hstl_id equals phxn.hstl_id
                                 join nh in db.tbHoctap_NamHocs on phxn.namhoc_id equals nh.namhoc_id
                                 where hs.hocsinh_taikhoan == _sdtHocSinh && nh.namhoc_id == _idNamHoc
                                 orderby phxn.phuhuynhxinnghi_id descending
                                 select new
                                 {
                                     phxn.phuhuynhxinnghi_content,
                                     phxn.phuhuynhxinnghi_dateend,
                                     phxn.phuhuynhxinnghi_datestart,
                                     phxn.phuhuynhxinnghi_id,
                                     phxn.phuhuynhxinnghi_ngaydangki,
                                     hs.hocsinh_id,
                                     tinhtrang = phxn.phuhuynhxinnghi_xacnhan == true? " <i title=\"Đã xác nhận\" class='fas fa-check-circle'></i>" : "<i title=\"Chờ xác nhận\" style=\"color:#ffc107\" class='fas fa-hourglass'></i>"

                                 };

            rpXinNghi.DataSource = getListXinNghi;
            rpXinNghi.DataBind();
            rpChiTietXinNghi.DataSource = getListXinNghi;
            rpChiTietXinNghi.DataBind();
            var getDate = (from hs in db.tbHocSinhs
                           join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                           join xn in db.tbVietNhatKids_PhuHuynhXinNghis on hstl.hstl_id equals xn.hstl_id
                           where hs.hocsinh_id == id_HocSinh
                           && hstl.namhoc_id == _idNamHoc && hstl.hidden == false
                           && xn.phuhuynhxinnghi_xacnhan == true
                           orderby xn.phuhuynhxinnghi_id descending
                           select new
                           {
                               xn.phuhuynhxinnghi_datestart,
                               xn.phuhuynhxinnghi_dateend,
                           });
            if (getDate.Count() > 0)
            {
                txtNgayBatDau.Value = string.Join(";", getDate.Select(x => x.phuhuynhxinnghi_datestart.Value.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));
                txtNgayKetThuc.Value = string.Join(";", getDate.Select(x => x.phuhuynhxinnghi_dateend.Value.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));
            }

        }
        else
        {
            Response.Redirect("/website-trang-chu");
        }
    }

    
    protected void setNull()
    {

        dteTuNgay.Value = " ";
        dteDenNgay.Value = "";
        txtDanDo.Value = "";
    }
    protected void btnGui_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["web_hocsinh"] != null)
        {
            db.Connection.Open();
            using (var transaction = db.Connection.BeginTransaction())
            {
                db.Transaction = transaction;
                try
                {
                    //if (dteDenNgay.Value != "" && dteTuNgay.Value != "" && txtDanDo.Value != "")
                    //{
                        var getData = (from hs in db.tbHocSinhs
                                       join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id //thong qua hstl để join phxn
                                       join phxn in db.tbVietNhatKids_PhuHuynhXinNghis on hstl.hstl_id equals phxn.hstl_id
                                       join nh in db.tbHoctap_NamHocs on phxn.namhoc_id equals nh.namhoc_id
                                       where hs.hocsinh_taikhoan == _sdtHocSinh && nh.namhoc_id == _idNamHoc && hstl.hidden == false
                                       select new
                                       {
                                           hstl.hocsinh_id,
                                           hstl.lop_id,
                                           hstl.namhoc_id,
                                           nh.namhoc_hocky,
                                           phxn.hstl_id,
                                           hs.hocsinh_name
                                       }).FirstOrDefault();
                        
                        tbVietNhatKids_PhuHuynhXinNghi insert = new tbVietNhatKids_PhuHuynhXinNghi();
                        insert.phuhuynhxinnghi_ngaydangki = Convert.ToDateTime(DateTime.Now);
                        insert.phuhuynhxinnghi_datestart = Convert.ToDateTime  (dteTuNgay.Value);
                        insert.phuhuynhxinnghi_dateend = Convert.ToDateTime(dteDenNgay.Value);
                        insert.phuhuynhxinnghi_content = txtDanDo.Value;
                        insert.hstl_id = getData.hstl_id;
                        insert.lop_id = getData.lop_id;
                        insert.namhoc_id = getData.namhoc_id;
                        insert.phuhuynhxinnghi_xacnhan = false;
                        db.tbVietNhatKids_PhuHuynhXinNghis.InsertOnSubmit(insert);
                        db.SubmitChanges();
                        setNull();
                        // alert.alert_Success(Page, "Gửi đơn thành công", "");
                        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Gửi đơn xin phép thành công!','','success').then(function(){window.location.reload();})", true);
                        var checkNamHoc = (from nh in db.tbHoctap_NamHocs orderby nh.namhoc_id descending select nh).First();
                        var getEmail = from u in db.admin_Users
                                       join gvtl in db.tbGiaoVienTrongLops on u.username_id equals gvtl.taikhoan_id
                                       join l in db.tbLops on gvtl.lop_id equals l.lop_id
                                       where gvtl.lop_id == getData.lop_id && gvtl.namhoc_id == checkNamHoc.namhoc_id
                                       select u;
                        string listEmail = string.Join(",", getEmail.Select(x => x.username_email).ToArray());
                        string message = "Bạn có thông báo mới xin nghỉ từ phụ huynh bé " + getData.hocsinh_name + ". Xem chi tiết <a href='http://quantrimamnon.vietnhatschool.edu.vn/admin-phu-huynh-xin-nghi'>tại đây.</a>";
                        //SendMail("ducpn@vjis.edu.vn, quyetlv@vjis.edu.vn", message);
                        //SendMail(listEmail + ", ducpn@vjis.edu.vn, quyetlv@vjis.edu.vn", message);
                        transaction.Commit();
                    //}
                    //else if (dteTuNgay.Value == "")
                    //{
                    //    alert.alert_Error(Page, "Vui lòng nhập ngày bắt đầu xin nghỉ!", " ");
                    //}
                    //else if (dteDenNgay.Value == "")
                    //{
                    //    alert.alert_Error(Page, "Vui lòng nhập ngày kết thúc  xin nghỉ!", " ");
                    //}
                    //else if (txtDanDo.Value == "")
                    //{
                    //    alert.alert_Error(Page, "Vui lòng nhập lý do xin nghỉ!", " ");
                    //}

                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }
        else

        {
            Response.Redirect("/website-trang-chu");
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