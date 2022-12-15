using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_HocTap_module_QuanLyLop_DiemDanh_Thongke_AnSang : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    public int soluongtuannay, soluongthangnay;
    public int STT = 1;
    private int _idCoSo;
    private int _idUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
            _idCoSo = Convert.ToInt32(checkuserid.coso_id);
            _idUser = checkuserid.username_id;
            if (!IsPostBack)
            {
                var listDangKi = (from asang in db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs
                                  where asang.coso_id == checkuserid.coso_id
                                 //&& asang.ansang_trangthaiduyet =="da duyet"
                                  select asang);
                var listHuy = (from asang in db.tbVietNhatKids_DanhSachHocSinh_HuyAnSangs
                               where asang.coso_id == checkuserid.coso_id
                               && asang.huyansang_trangthaiduyet == true
                               select asang);
                lblTongDangKi.Text = listDangKi.Count() - listHuy.Count() + "";
                lblTongHuyDangKi.Text = listHuy.Count() + "";
                //lblTongSoAnSangUongSua.Text = (from asang in db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs
                //                               where (asang.coso_id == checkuserid.coso_id
                //                               && asang.uongsua_tinhtrang == true && asang.ansang_tinhtrang == true)
                //                               || (asang.ansang_ngayapdunghuy.Value.Day > DateTime.Now.Date.AddDays(-1).Day
                //                               && asang.ansang_ngayapdunghuy.Value.Month > DateTime.Now.Month
                //                               && asang.ansang_ngayapdunghuy.Value.Year > DateTime.Now.Year)
                //                               select asang).Count() + "";
                //lblTongHuyDangKiAnSang.Text = (from asang in db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs
                //                               where (asang.coso_id == checkuserid.coso_id
                //                               && asang.ansang_tinhtrang == true && asang.uongsua_tinhtrang == null)
                //                               && (asang.ansang_ngayapdunghuy.Value.Day <= DateTime.Now.Date.AddDays(-1).Day
                //                               && asang.ansang_ngayapdunghuy.Value.Month <= DateTime.Now.Month
                //                               && asang.ansang_ngayapdunghuy.Value.Year <= DateTime.Now.Year)
                //                               select asang).Count() + "";
                //lblTongHuyDangKiUongSua.Text = (from asang in db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs
                //                                where (asang.coso_id == checkuserid.coso_id
                //                                && asang.uongsua_tinhtrang == true)
                //                                && (asang.ansang_ngayapdunghuy.Value.Day <= DateTime.Now.Date.AddDays(-1).Day
                //                                && asang.ansang_ngayapdunghuy.Value.Month <= DateTime.Now.Month
                //                                && asang.ansang_ngayapdunghuy.Value.Year <= DateTime.Now.Year)
                //                                select asang).Count() + "";
                //lblTongHuyDangKiAnSangUongSua.Text = (from asang in db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs
                //                                      where (asang.coso_id == checkuserid.coso_id
                //                                      && asang.uongsua_tinhtrang == true && asang.ansang_tinhtrang == true)
                //                                      && (asang.ansang_ngayapdunghuy.Value.Day <= DateTime.Now.Date.AddDays(-1).Day
                //                                      && asang.ansang_ngayapdunghuy.Value.Month <= DateTime.Now.Month
                //                                      && asang.ansang_ngayapdunghuy.Value.Year <= DateTime.Now.Year)
                //                                      select asang).Count() + "";
                //lblHomNay.Text = (from asang in db.tbDiemDanh_HocSinhs
                //                  where asang.diemdanh_ansang == "Không ăn sáng"
                //                  && asang.diemdanh_ngay.Value.Date == Convert.ToDateTime(DateTime.Now).Date
                //                  && asang.diemdanh_ngay.Value.Month == Convert.ToDateTime(DateTime.Now).Month
                //                  && asang.diemdanh_ngay.Value.Year == Convert.ToDateTime(DateTime.Now).Year
                //                  select asang).Count() + "";
                //var homnay = (from asang in db.tbDiemDanh_HocSinhs
                //              where asang.diemdanh_ansang == "Không ăn sáng"
                //              && asang.diemdanh_ngay.Value.Date == Convert.ToDateTime(DateTime.Now).Date
                //              && asang.diemdanh_ngay.Value.Month == Convert.ToDateTime(DateTime.Now).Month
                //              && asang.diemdanh_ngay.Value.Year == Convert.ToDateTime(DateTime.Now).Year
                //              select asang);
                //var homqua = (from asang in db.tbDiemDanh_HocSinhs
                //              where asang.diemdanh_ansang == "Không ăn sáng"
                //              && asang.diemdanh_ngay.Value.Date == Convert.ToDateTime(DateTime.Now).Date.AddDays(-1)
                //              && asang.diemdanh_ngay.Value.Month == Convert.ToDateTime(DateTime.Now).Month
                //              && asang.diemdanh_ngay.Value.Year == Convert.ToDateTime(DateTime.Now).Year
                //              select asang);
                //lbl2NgayLienTiep.Text = (from a in homnay
                //                         join b in homqua on a.hstl_id equals b.hstl_id
                //                         select a).Count() + "";
                //var listngayhomqua = from asang in db.tbDiemDanh_HocSinhs
                //                     where asang.diemdanh_ansang == "Không ăn sáng"
                //                     group asang by asang.hstl_id into playerGroup
                //                     select new
                //                     {
                //                         Team = playerGroup.Key,
                //                         Count = playerGroup.Count(),
                //                     };
                //var listngayhomnay = from asang in db.tbDiemDanh_HocSinhs
                //                     where asang.diemdanh_ansang == "Không ăn sáng"
                //                     && asang.diemdanh_ngay.Value.Day == Convert.ToDateTime(DateTime.Now).Day
                //                     && asang.diemdanh_ngay.Value.Month == Convert.ToDateTime(DateTime.Now).Month
                //                     && asang.diemdanh_ngay.Value.Year == Convert.ToDateTime(DateTime.Now).Year
                //                     select asang;
            }
        }
        else
        {
            Response.Redirect("/admin-login");
        }
    }

    //load data theo tuần hiện tại

    //protected void btnSeachHomnay_ServerClick(object sender, EventArgs e)
    //{
    //    // load data đổ vào var danh sách
    //    var getData = from l in db.tbLops
    //                  join hstl in db.tbHocSinhTrongLops on l.lop_id equals hstl.lop_id
    //                  join hs in db.tbHocSinhs on hstl.hocsinh_id equals hs.hocsinh_id
    //                  join d in db.tbDiemDanh_HocSinhs on hstl.hstl_id equals d.hstl_id
    //                  where d.diemdanh_ngay.Value.Day == Convert.ToDateTime(DateTime.Now).Day
    //                   && d.diemdanh_ngay.Value.Month == Convert.ToDateTime(DateTime.Now).Month
    //                   && d.diemdanh_ngay.Value.Year == Convert.ToDateTime(DateTime.Now).Year
    //                   && d.diemdanh_ansang != null
    //                  orderby l.lop_position
    //                  select new
    //                  {
    //                      l.lop_name,
    //                      STT = STT + 1,
    //                      hs.hocsinh_name,
    //                      hstl.hstl_id,
    //                      d.diemdanh_ngay,
    //                      tinhtrang = d.diemdanh_ansang == 1 ? "Có ăn sáng" : "Không ăn sáng"
    //                  };
    //    // đẩy dữ liệu vào gridivew
    //    rpLop.DataSource = getData;
    //    rpLop.DataBind();


    //}

    protected void btnXemDangKi_ServerClick(object sender, EventArgs e)
    {
        var listDangKi = from ds in db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs
                         join hstl in db.tbHocSinhTrongLops on ds.hstl_id equals hstl.hstl_id
                         join hs in db.tbHocSinhs on hstl.hocsinh_id equals hs.hocsinh_id
                         join l in db.tbLops on hstl.lop_id equals l.lop_id
                         where ds.coso_id == _idCoSo
                         //|| (ds.ansang_ngayapdunghuy.Value.Day > DateTime.Now.Day
                         //&& ds.ansang_ngayapdunghuy.Value.Month > DateTime.Now.Month
                         //&& ds.ansang_ngayapdunghuy.Value.Year > DateTime.Now.Year)
                         orderby l.lop_name ascending
                         select new
                         {
                             ansang_id= ds.ansang_id,
                             l.lop_name,
                             hs.hocsinh_name,
                             ngay = ds.ansang_datecreate,
                             thang = ds.ansang_thangdangky,
                             ds.ansang_tinhtrang,
                             ds.uongsua_tinhtrang,
                             trangthai = ds.ansang_trangthaiduyet == "chua duyet" ? "Chưa xác nhận" : "Đã xác nhận",
                         };
        var listHuy = (from asang in db.tbVietNhatKids_DanhSachHocSinh_HuyAnSangs
                       join hstl in db.tbHocSinhTrongLops on asang.hstl_id equals hstl.hstl_id
                       join hs in db.tbHocSinhs on hstl.hocsinh_id equals hs.hocsinh_id
                       join l in db.tbLops on hstl.lop_id equals l.lop_id
                       where asang.coso_id == _idCoSo
                      && asang.huyansang_trangthaiduyet==true
                       orderby l.lop_name ascending
                       select new
                       {
                           ansang_id= asang.huyansang_id,
                           l.lop_name,
                           hs.hocsinh_name,
                           ngay = asang.huyansang_datecreate,
                           thang = "",
                           asang.ansang_tinhtrang,
                           asang.uongsua_tinhtrang,
                           trangthai=""
                       });
        var ketqua = listDangKi.Except(listHuy);
        lblDanhSach.Text = "Danh sách học sinh đăng kí ăn sáng";
        grvList.DataSource = ketqua;
        grvList.DataBind();
    }

    protected void btnHomNay_ServerClick(object sender, EventArgs e)
    {
        //var getDanhSachHocSinhAnSang = from ds in db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs
        //                               join hstl in db.tbHocSinhTrongLops on ds.hstl_id equals hstl.hstl_id
        //                               join hs in db.tbHocSinhs on hstl.hocsinh_id equals hs.hocsinh_id
        //                               join l in db.tbLops on hstl.lop_id equals l.lop_id
        //                               join ans in db.tbDiemDanh_HocSinhs on hstl.hstl_id equals ans.hstl_id
        //                               where ans.diemdanh_ngay.Value.Date == DateTime.Now.Date
        //                               && ans.diemdanh_ngay.Value.Month == DateTime.Now.Month
        //                               && ans.diemdanh_ngay.Value.Year == DateTime.Now.Year
        //                               && ans.diemdanh_ansang == "Không ăn sáng"
        //                               orderby l.lop_position
        //                               select new
        //                               {

        //                                   l.lop_name,
        //                                   hs.hocsinh_name,

        //                               };
        //rpLop.DataSource = getDanhSachHocSinhAnSang;
        //rpLop.DataBind();
    }
    protected void btnLienTiep_ServerClick(object sender, EventArgs e)
    {
        var homnay = (from asang in db.tbDiemDanh_HocSinhs
                      where asang.diemdanh_ansang == "Không ăn sáng"
                      && asang.diemdanh_ngay.Value.Date == Convert.ToDateTime(DateTime.Now).Date
                      && asang.diemdanh_ngay.Value.Month == Convert.ToDateTime(DateTime.Now).Month
                      && asang.diemdanh_ngay.Value.Year == Convert.ToDateTime(DateTime.Now).Year
                      select asang);
        var homqua = (from asang in db.tbDiemDanh_HocSinhs
                      where asang.diemdanh_ansang == "Không ăn sáng"
                      && asang.diemdanh_ngay.Value.Date == Convert.ToDateTime(DateTime.Now).Date.AddDays(-1)
                      && asang.diemdanh_ngay.Value.Month == Convert.ToDateTime(DateTime.Now).Month
                      && asang.diemdanh_ngay.Value.Year == Convert.ToDateTime(DateTime.Now).Year
                      select asang);
        var getLienTiep = from a in homnay
                          join b in homqua on a.hstl_id equals b.hstl_id
                          join hstl in db.tbHocSinhTrongLops on a.hstl_id equals hstl.hstl_id
                          join hs in db.tbHocSinhs on hstl.hocsinh_id equals hs.hocsinh_id
                          join l in db.tbLops on hstl.lop_id equals l.lop_id
                          orderby l.lop_position
                          select new
                          {
                              l.lop_name,
                              hs.hocsinh_name,
                          };
        //rpLop.DataSource = getLienTiep;
        //rpLop.DataBind();
    }

    protected void btnHuyDangKiAnSang_ServerClick(object sender, EventArgs e)
    {

    }

    protected void btnXemHuyDangKi_ServerClick(object sender, EventArgs e)
    {

        var getDanhSachHocSinhAnSang = (from asang in db.tbVietNhatKids_DanhSachHocSinh_HuyAnSangs
                                        join hstl in db.tbHocSinhTrongLops on asang.hstl_id equals hstl.hstl_id
                                        join hs in db.tbHocSinhs on hstl.hocsinh_id equals hs.hocsinh_id
                                        join l in db.tbLops on hstl.lop_id equals l.lop_id
                                        where asang.coso_id == _idCoSo
                                       && asang.huyansang_trangthaiduyet == true
                                        orderby l.lop_name ascending
                                        select new
                                        {
                                            ansang_id = asang.huyansang_id,
                                            l.lop_name,
                                            hs.hocsinh_name,
                                            ngay = asang.huyansang_datecreate,
                                            thang = asang.huyansang_thangdangky,
                                            asang.ansang_tinhtrang,
                                            asang.uongsua_tinhtrang,
                                            trangthai = asang.huyansang_trangthaiduyet == false ? "Chưa xác nhận" : "Đã xác nhận",
                                        });
        lblDanhSach.Text = "Danh sách học sinh hủy đăng kí ăn sáng";
        grvList.DataSource = getDanhSachHocSinhAnSang;
        grvList.DataBind();

    }

    protected void btnAnSangUongSua_ServerClick(object sender, EventArgs e)
    {

    }

    protected void btnHuyDangKiUongSua_ServerClick(object sender, EventArgs e)
    {

    }

    protected void btnHuyDangKiAnSangUongSua_ServerClick(object sender, EventArgs e)
    {

    }
}