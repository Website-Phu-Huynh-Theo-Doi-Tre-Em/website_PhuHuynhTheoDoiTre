using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_access_admin_Profile : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public string img_src;
    cls_Alert alert = new cls_Alert();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["UserName"] != null)
            {
                var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
                tbQuanLyNhanSu_ThongTinCaNhan update = (from tt in db.tbQuanLyNhanSu_ThongTinCaNhans where tt.username_id == checkuserid.username_id select tt).SingleOrDefault();
                if (update != null)
                {

                    ddlOngBa.Value = update.thongtincanhan_ongba;
                    txtHoTen.Value = update.thongtincanhan_hotenThuong;
                    //txtHoTen.Value = update.thongtincanhan_hotenThuong;
                    ddlGioiTinh.Value = update.thongtincanhan_gioitinh;
                    dteNgaySinh.Value = update.thongtincanhan_ngaythangnamsinh.Value.ToString("yyyy-MM-dd").Replace(' ', 'T');
                    txtNoiSinh.Value = update.thongtincanhan_noisinh;
                    txtSoDienThoai.Value = update.thongtincanhan_sodienthoai;
                    txtEmail.Value = update.thongtincanhan_email;
                    txtChoOHienTai.Value = update.thongtincanhan_choohientai;
                    txtDiaChiThuowngTru.Value = update.thongtincanhan_diachithuongtru;
                    txtQuocTich.Value = update.thongtincanhan_quoctinh;
                    txtCMND.Value = update.thongtincanhan_CMND;
                    dteNgaycap.Value = update.thongtincanhan_ngaycap;
                    txtNoiCap.Value = update.thongtincanhan_noicap;
                    txtChucVu.Value = update.thongtincanhan_chucvu;
                    txtBoPhan.Value = update.thongtincanhan_bophan;
                    txtTrinhDo.Value = update.thongtincanhan_trinhdo;
                    txtNoiDaoTao.Value = update.thongtincanhan_noidaotao;
                    txtBangCapChuyenMon.Value = update.thongtincanhan_bangcapchuyenmon;
                    txtBangCapKhac.Value = update.thongtincanhan_bangcapkhac;
                    txtTrinhDoTiengAnh.Value = update.thongtincanhan_trinhdotienanh;
                }
                else
                {
                    img_src = "https://quantri.vietnhatschool.edu.vn/admin_images/avatar-truong.png";
                }
            }
        }
    }
    protected void btnLuu_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (RouteData.Values["id"].ToString() == "0")
            {
                tbQuanLyNhanSu_ThongTinCaNhan insert = new tbQuanLyNhanSu_ThongTinCaNhan();
                insert.thongtincanhan_ongba = ddlOngBa.Value;
                insert.thongtincanhan_hotenThuong = txtHoTen.Value;
                insert.thongtincanhan_hotenHoa = txtHoTen.Value.ToUpper();
                //txtHoTen.Value.ToUpper() = update.thongtincanhan_hotenThuong;
                insert.thongtincanhan_gioitinh = ddlGioiTinh.Value;
                insert.thongtincanhan_ngaythangnamsinh = Convert.ToDateTime(dteNgaySinh.Value);
                insert.thongtincanhan_ngaysinh = Convert.ToInt16(Convert.ToDateTime(dteNgaySinh.Value).Day);
                insert.thongtincanhan_thangsinh = Convert.ToInt16(Convert.ToDateTime(dteNgaySinh.Value).Month);
                insert.thongtincanhan_namsinh = Convert.ToInt16(Convert.ToDateTime(dteNgaySinh.Value).Year);
                insert.thongtincanhan_noisinh = txtNoiSinh.Value;
                insert.thongtincanhan_sodienthoai = txtSoDienThoai.Value;
                insert.thongtincanhan_email = txtEmail.Value;
                insert.thongtincanhan_choohientai = txtChoOHienTai.Value;
                insert.thongtincanhan_diachithuongtru = txtDiaChiThuowngTru.Value;
                insert.thongtincanhan_quoctinh = txtQuocTich.Value;
                insert.thongtincanhan_CMND = txtCMND.Value;
                insert.thongtincanhan_ngaycap = dteNgaycap.Value;
                insert.thongtincanhan_noicap = txtNoiCap.Value;
                insert.thongtincanhan_chucvu = txtChucVu.Value;
                insert.thongtincanhan_bophan = txtBoPhan.Value;
                insert.thongtincanhan_trinhdo = txtTrinhDo.Value;
                insert.thongtincanhan_noidaotao = txtNoiDaoTao.Value;
                insert.thongtincanhan_bangcapchuyenmon = txtBangCapChuyenMon.Value;
                insert.thongtincanhan_bangcapkhac = txtBangCapKhac.Value;
                insert.thongtincanhan_trinhdotienanh = txtTrinhDoTiengAnh.Value;
                db.tbQuanLyNhanSu_ThongTinCaNhans.InsertOnSubmit(insert);
                db.SubmitChanges();
                tbQuanLyNhanSu_HopDongThuViec insertThuViec = new tbQuanLyNhanSu_HopDongThuViec();
                insertThuViec.thongtincanhan_id = insert.thongtincanhan_id;
                db.tbQuanLyNhanSu_HopDongThuViecs.InsertOnSubmit(insertThuViec);
                db.SubmitChanges();
                tbQuanLyNhanSu_HopDongLaoDong insertLaoDong = new tbQuanLyNhanSu_HopDongLaoDong();
                insertLaoDong.thongtincanhan_id = insert.thongtincanhan_id;
                db.tbQuanLyNhanSu_HopDongLaoDongs.InsertOnSubmit(insertLaoDong);
                db.SubmitChanges();
                alert.alert_Success(Page, "Đã hoàn thành", "");
            }
            else
            {
                tbQuanLyNhanSu_ThongTinCaNhan update = (from tt in db.tbQuanLyNhanSu_ThongTinCaNhans where tt.thongtincanhan_id == Convert.ToInt16(RouteData.Values["id"].ToString()) select tt).SingleOrDefault();
                update.thongtincanhan_ongba = ddlOngBa.Value;
                update.thongtincanhan_hotenThuong = txtHoTen.Value;
                update.thongtincanhan_hotenHoa = txtHoTen.Value.ToUpper();
                //txtHoTen.Value.ToUpper() = update.thongtincanhan_hotenThuong;
                update.thongtincanhan_gioitinh = ddlGioiTinh.Value;
                update.thongtincanhan_ngaythangnamsinh = Convert.ToDateTime(dteNgaySinh.Value);
                update.thongtincanhan_ngaysinh = Convert.ToInt16(Convert.ToDateTime(dteNgaySinh.Value).Day);
                update.thongtincanhan_thangsinh = Convert.ToInt16(Convert.ToDateTime(dteNgaySinh.Value).Month);
                update.thongtincanhan_namsinh = Convert.ToInt16(Convert.ToDateTime(dteNgaySinh.Value).Year);
                update.thongtincanhan_noisinh = txtNoiSinh.Value;
                update.thongtincanhan_sodienthoai = txtSoDienThoai.Value;
                update.thongtincanhan_email = txtEmail.Value;
                update.thongtincanhan_choohientai = txtChoOHienTai.Value;
                update.thongtincanhan_diachithuongtru = txtDiaChiThuowngTru.Value;
                update.thongtincanhan_quoctinh = txtQuocTich.Value;
                update.thongtincanhan_CMND = txtCMND.Value;
                update.thongtincanhan_ngaycap = dteNgaycap.Value;
                update.thongtincanhan_noicap = txtNoiCap.Value;
                update.thongtincanhan_chucvu = txtChucVu.Value;
                update.thongtincanhan_bophan = txtBoPhan.Value;
                update.thongtincanhan_trinhdo = txtTrinhDo.Value;
                update.thongtincanhan_noidaotao = txtNoiDaoTao.Value;
                update.thongtincanhan_bangcapchuyenmon = txtBangCapChuyenMon.Value;
                update.thongtincanhan_bangcapkhac = txtBangCapKhac.Value;
                update.thongtincanhan_trinhdotienanh = txtTrinhDoTiengAnh.Value;
                db.SubmitChanges();
                alert.alert_Update(Page, "Đã cập nhật xong", "");
            }
        }
        catch
        {
            alert.alert_Error(Page, "Có lỗi liên hệ IT", "");
        }
    }
}