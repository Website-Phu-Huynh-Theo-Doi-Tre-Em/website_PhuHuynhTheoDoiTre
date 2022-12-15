using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public int STT;
    cls_Alert alert = new cls_Alert();
    private static int _idUser;
    private static int CoSo;
    private static int _idNamhoc;
    public int tong_filechung = 0, tong_file_coso1 = 0, tong_file_coso2 = 0, tong_file_coso3 = 0;
    public string ten_tuan, phienche_namhoc;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
            var getDaTaCV = from cv in db.tbDanhSachCongViecs
                            select new
                            {
                                cv.danhsachcongviec_name,
                                cv.danhsachcongviec_id,
                                cv.danhsachcongviec_content,
                                cv.danhsachcongviec_link,
                                mau = (from ls in db.tbLichSus
                                       join u in db.admin_Users on ls.username_id equals u.username_id
                                       where ls.danhsachcongviec_id == cv.danhsachcongviec_id
                                       && ls.username_id == checkuserid.username_id
                                       && ls.lichsu_date.Value.Day == DateTime.Now.Day
                                       && ls.lichsu_date.Value.Month == DateTime.Now.Month
                                       && ls.lichsu_date.Value.Year == DateTime.Now.Year
                                       select ls).Count() > 0 ? ".time_line_5cf90ca818fc83" : "black-white"
                            };
            rpCongViec.DataSource = getDaTaCV;
            rpCongViec.DataBind();
            STT = 1;
            _idUser = (from u in db.admin_Users
                       where u.username_username == Request.Cookies["UserName"].Value
                       select u).FirstOrDefault().username_id;
            CoSo = Convert.ToInt32(checkuserid.coso_id);
            int namhoc_id = db.tbHoctap_NamHocs.Select(x => x.namhoc_id).ToList().Last();
            //biểu đồ sức khỏe học sinh
            if (db.tbGiaoVienTrongLops.Any(gv => gv.taikhoan_id == _idUser && gv.namhoc_id == namhoc_id))
            {
                div_SucKhoeHocSinh.Visible = true;
                div_CongViecHangNgay.Visible = true;
                div_DiemDanhNhanXetHangNgay.Visible = false;

                //tính điểm tích lũy những công việc hàng ngày
                var getDiemDanhHangNgay = from u in db.admin_Users
                                          where u.coso_id == checkuserid.coso_id && u.username_active == true && u.groupuser_id == 3
                                          select new
                                          {
                                              u.username_id,
                                              u.username_fullname,
                                              diemtichluy = (from ls in db.tbLichSus
                                                             where ls.username_id == u.username_id
                                                             && ls.lichsu_date.Value.Month == DateTime.Now.Month
                                                             select ls).Sum(x => x.lichsu_diemtichluy),
                                          };


                var getDiemThuocPhuHuynh = from u in db.admin_Users
                                           where u.coso_id == checkuserid.coso_id && u.username_active == true
                                           && u.groupuser_id == 3
                                           select new
                                           {
                                               u.username_id,
                                               u.username_fullname,
                                               diemtichluy = (from ls in db.tbVietNhatKids_PhuHuynhDanDoThuocs
                                                              join hstl in db.tbHocSinhTrongLops on ls.hstl_id equals hstl.hstl_id
                                                              join l in db.tbLops on hstl.lop_id equals l.lop_id
                                                              join gvtl in db.tbGiaoVienTrongLops on l.lop_id equals gvtl.lop_id
                                                              where gvtl.taikhoan_id == u.username_id && ls.namhoc_id == 11 && gvtl.namhoc_id == 11
                                                              && ls.phuhuynhdandothuoc_ngaydangki.Value.Month == DateTime.Now.Month
                                                              select ls).Sum(x => x.phuhuynhdandothuoc_diemtichluy),
                                           };

                var getDiemTaoBaiViet = from u in db.admin_Users
                                        where u.coso_id == checkuserid.coso_id && u.username_active == true
                               && u.groupuser_id == 3
                                        select new
                                        {
                                            u.username_id,
                                            u.username_fullname,
                                            diemtichluy = (from ls in db.tbVietNhatKids_AlbumImages
                                                           join gvtl in db.tbGiaoVienTrongLops on ls.gvtl_id equals gvtl.gvtl_id
                                                           where gvtl.taikhoan_id == u.username_id && ls.namhoc_id == 11 && gvtl.namhoc_id == 11
                                                           && ls.albumimage_datecreate.Value.Month == DateTime.Now.Month && ls.albumimage_tinhtrang == true
                                                           select ls).Sum(x => x.albumImage_diemtichluy),

                                        };
                var getDiemXacNhanXinNghi = from u in db.admin_Users
                                            where u.coso_id == checkuserid.coso_id && u.username_active == true
                               && u.groupuser_id == 3
                                            select new
                                            {
                                                u.username_id,
                                                u.username_fullname,
                                                diemtichluy = (from ls in db.tbVietNhatKids_PhuHuynhXinNghis
                                                               join hstl in db.tbHocSinhTrongLops on ls.hstl_id equals hstl.hstl_id
                                                               join l in db.tbLops on hstl.lop_id equals l.lop_id
                                                               join gvtl in db.tbGiaoVienTrongLops on l.lop_id equals gvtl.lop_id
                                                               where gvtl.taikhoan_id == u.username_id && ls.namhoc_id == 11 && gvtl.namhoc_id == 11
                                                               && ls.phuhuynhxinnghi_ngaydangki.Value.Month == DateTime.Now.Month
                                                               select ls).Sum(x => x.phuhuynhxinnghi_diemtichluy),
                                            };
                var getThemThongBaoLop = from u in db.admin_Users
                                         where u.coso_id == checkuserid.coso_id && u.username_active == true
                              && u.groupuser_id == 3
                                         select new
                                         {
                                             u.username_id,
                                             u.username_fullname,
                                             diemtichluy = (from ls in db.tbVietNhatKids_ThongBaoLops
                                                            join lop in db.tbLops on ls.lop_id equals lop.lop_id
                                                            join gvtl in db.tbGiaoVienTrongLops on ls.lop_id equals gvtl.lop_id
                                                            where gvtl.taikhoan_id == u.username_id && ls.namhoc_id == 11 && gvtl.namhoc_id == 11
                                                            && ls.thongbaoLop_datecreate.Value.Month == DateTime.Now.Month
                                                            && ls.username_id == u.username_id
                                                            select ls).Sum(x => x.thongbaolop_diemtichluy),
                                         };
                var getThemThongBaoTruong = from u in db.admin_Users
                                            where u.coso_id == checkuserid.coso_id && u.username_active == true
                             && u.groupuser_id == 3
                                            select new
                                            {
                                                u.username_id,
                                                u.username_fullname,
                                                diemtichluy = (from ls in db.tbVietNhatKids_ThongBaoTruongs
                                                               where ls.username_id == u.username_id && ls.namhoc_id == 11
                                                               && ls.thongbaotruong_datecreate.Value.Month == DateTime.Now.Month
                                                               select ls).Sum(x => x.thongbaotruong_diemtichluy),
                                            };
                var getDuyetThongBaoLop = from u in db.admin_Users
                                          where u.coso_id == checkuserid.coso_id && u.username_active == true
                                && u.groupuser_id == 3
                                          select new
                                          {
                                              u.username_id,
                                              u.username_fullname,
                                              diemtichluy = (from ls in db.tbLichSuDuyet_BanGiamHieus
                                                             where ls.username_id == u.username_id && ls.namhoc_id == 11
                                                             && ls.lichsuduyet_ngayduyet.Value.Month == DateTime.Now.Month
                                                             select ls).Sum(x => x.lichsuduyet_diemtichluy),
                                          };

                var getXacNhanNgoaiKhoa = from u in db.admin_Users
                                          where u.coso_id == checkuserid.coso_id && u.username_active == true
                             && u.groupuser_id == 3
                                          select new
                                          {
                                              u.username_id,
                                              u.username_fullname,
                                              diemtichluy = (from ls in db.tbVietNhatKids_DangKyNgoaiKhoas
                                                             join hstl in db.tbHocSinhTrongLops on ls.hstl_id equals hstl.hstl_id
                                                             join l in db.tbLops on hstl.lop_id equals l.lop_id
                                                             join gvtl in db.tbGiaoVienTrongLops on l.lop_id equals gvtl.lop_id
                                                             where gvtl.taikhoan_id == u.username_id && ls.namhoc_id == 11 && gvtl.namhoc_id == 11
                                                             && ls.dangkyngoaikhoa_datecreate.Value.Month == DateTime.Now.Month
                                                             select ls).Sum(x => x.dangkyngoaikhoa_diemtichluy),
                                          };

                var getTaoLichBaoGiang = from u in db.admin_Users
                                         where u.coso_id == checkuserid.coso_id && u.username_active == true
                               && u.groupuser_id == 3
                                         select new
                                         {
                                             u.username_id,
                                             u.username_fullname,
                                             diemtichluy = (from ls in db.tbLichBaoGiangs
                                                            where ls.username_id == u.username_id && ls.namhoc_id == 11
                                                            && ls.lichbaogiang_ngaytao.Value.Month == DateTime.Now.Month
                                                            && ls.hidden == false
                                                            select ls).Sum(x => x.lichbaogiang_diemtichluy),

                                         };
                //load thống kê điểm tích lũy giáo viên
                var getTong = from u in db.admin_Users
                              where u.coso_id == checkuserid.coso_id && u.username_active == true
                              && u.groupuser_id == 3
                              select new
                              {
                                  u.username_id,
                                  u.username_fullname,
                                  diemtichluy = getDiemDanhHangNgay.Where(hn => hn.username_id == u.username_id).Select(x => x.diemtichluy ?? 0).Sum()
                                  + getDiemThuocPhuHuynh.Where(dt => dt.username_id == u.username_id).Select(x => x.diemtichluy ?? 0).Sum()
                                  + getThemThongBaoLop.Where(tbl => tbl.username_id == u.username_id).Select(x => x.diemtichluy ?? 0).Sum()
                                  + getDiemTaoBaiViet.Where(tbv => tbv.username_id == u.username_id).Select(x => x.diemtichluy ?? 0).Sum()
                                  + getDiemXacNhanXinNghi.Where(xn => xn.username_id == u.username_id).Select(x => x.diemtichluy ?? 0).Sum()
                                  + getThemThongBaoTruong.Where(tbt => tbt.username_id == u.username_id).Select(x => x.diemtichluy ?? 0).Sum()
                                  + getDuyetThongBaoLop.Where(dtb => dtb.username_id == u.username_id).Select(x => x.diemtichluy ?? 0).Sum()
                                  + getTaoLichBaoGiang.Where(tbg => tbg.username_id == u.username_id).Select(x => x.diemtichluy ?? 0).Sum()
                                  //   + getTaoAlbumCaNhan.Where(acn => acn.username_id == u.username_id).Select(x => x.diemtichluy ?? 0).Sum()
                                  + getXacNhanNgoaiKhoa.Where(nk => nk.username_id == u.username_id).Select(x => x.diemtichluy ?? 0).Sum(),
                              };
                rpTongDiemTichLuyGiaoVien.DataSource = getTong.OrderByDescending(x => x.diemtichluy);
                rpTongDiemTichLuyGiaoVien.DataBind();
                rpGiaoVienNhaXetThuongXuyen.DataSource = getTong;
                rpGiaoVienNhaXetThuongXuyen.DataBind();
            }
            else
            {
                div_SucKhoeHocSinh.Visible = false;
                div_CongViecHangNgay.Visible = false;
                div_DiemDanhNhanXetHangNgay.Visible = true;
                //điểm danh nhận xét hàng ngày
                var getDiemDanhHangNgay = from u in db.admin_Users
                                          join gvtl in db.tbGiaoVienTrongLops on u.username_id equals gvtl.taikhoan_id
                                          where u.coso_id == checkuserid.coso_id && u.username_active == true
                                          && gvtl.namhoc_id == namhoc_id
                                          select new
                                          {
                                              u.username_id,
                                              u.username_fullname,
                                              u.username_avatar,
                                              gvtl.lop_id,
                                              lop_name = (from l in db.tbLops where l.lop_id == gvtl.lop_id select l.lop_name).FirstOrDefault(),
                                              SoLuongDiemDanhHangNgay = (from ls in db.tbLichSus
                                                                         where ls.username_id == u.username_id
                                                 && ls.lichsu_date.Value.Day == DateTime.Now.Day && ls.lichsu_date.Value.Month == DateTime.Now.Month
                                                 && ls.lichsu_date.Value.Year == DateTime.Now.Year
                                                                         select ls).Count(),
                                              TongSoLuongDiemDanhHangNgay = 5,
                                          };
                rpDiemDanhHangNgay.DataSource = getDiemDanhHangNgay.OrderBy(x => x.lop_name);
                rpDiemDanhHangNgay.DataBind();
                rpGiaoVienNhanXetThuongXuyen.DataSource = getDiemDanhHangNgay;
                rpGiaoVienNhanXetThuongXuyen.DataBind();
            }
            /*get data lịch công tác của từng cơ sở*/
            if (CoSo != 0)
            {
                div_LichCongTacCoSo.Visible = true;
                div_LichCongTac_QuanTri.Visible = false;
                //get lịch công tác tuần
                var LCT_tuan = (from lct in db.tbLichCongTacs
                                where lct.coso_id == CoSo && lct.lichcongtac_hidden == false
                                && lct.lichcongtac_status == 1
                                orderby lct.lichcongtac_id descending
                                select new
                                {
                                    lct.lichcongtac_id,
                                    lct.lichcongtac_tuan,
                                    songuoixem = (from ls in db.tbQuantri_LichSuXemLichCongTacTuans
                                                  where ls.lichcongtactuan_id == lct.lichcongtac_id
                                                  group ls by new
                                                  {
                                                      ls.username_id
                                                  } into g
                                                  select g).Count(),
                                    tonggiaovien = (from u in db.admin_Users
                                                    where u.coso_id == CoSo
                                                    && u.username_active == true
                                                    select u).Count(),
                                    //kiểm tra xem đã xem lịch công tác chưa, nếu chưa thì hiện thông báo mới
                                    thongbaomoi = db.tbQuanTri_XemLichCongTacTuans.Any(x => x.username_id == checkuserid.username_id && x.lichcongtactuan_id == lct.lichcongtac_id) == true ? "chuaxem" : "daxem",
                                }).Take(1);
                rpLichCongTacTuan.DataSource = LCT_tuan;
                rpLichCongTacTuan.DataBind();
                //get lịch công tác tháng
                var LCT_Thang = (from lct in db.tbLichCongTac_Thangs
                                 join i in db.tbImage_Liches on lct.image_id equals i.image_lich
                                 where lct.coso_id == CoSo && lct.lichcongtac_thang_hidden == false
                                 && lct.lichcongtac_thang_status == true && lct.namhoc_id == namhoc_id
                                 orderby lct.lichcongtac_thang_ngaytao descending
                                 select new
                                 {
                                     lct.lichcongtac_thang_id,
                                     i.image_link,
                                     songuoixem = (from ls in db.tbQuanTri_XemLichCongTacThangs
                                                   where ls.lichcongtacthang_id == lct.lichcongtac_thang_id
                                                   select ls).Count(),
                                     tonggiaovien = (from u in db.admin_Users
                                                     where u.coso_id == CoSo
                                                     && u.username_active == true
                                                     select u).Count(),
                                     //kiểm tra xem đã xem lịch công tác chưa, nếu chưa thì hiện thông báo mới
                                     thongbaomoi = db.tbQuanTri_XemLichCongTacThangs.Any(x => x.username_id == checkuserid.username_id) == true ? "chuaxem" : "daxem",
                                 }).Take(1);
                rpLichCongTacThang.DataSource = LCT_Thang;
                rpLichCongTacThang.DataBind();
                //rpt lịch báo  giảng cơ sơ
                var getLichBaoGiang = (from lbg in db.tbLichBaoGiangs
                                       where lbg.hidden == false
                                       select new
                                       {
                                           giaoviendanhap = (from gv in db.tbLichBaoGiangs
                                                             join u in db.admin_Users on gv.username_id equals u.username_id
                                                             where u.coso_id == CoSo && gv.lichbaogiang_trangthai == 1//đã được duyệt
                                                             select u).Count(),
                                           tonggiaovien = (from u in db.admin_Users
                                                           where u.groupuser_id == 3 && u.coso_id == CoSo
                                                           select u).Count(),
                                       }).Take(1);
                rpLichBaoGiangCoSo.DataSource = getLichBaoGiang;
                rpLichBaoGiangCoSo.DataBind();
                div_LichBaoGiangCoSo.Visible = true;
                div_LichBaoGiangQuanTri.Visible = false;

                //get danh sách các lịch công tác tháng của cs và thống kê số người xem vẽ biểu đồ
                var listLichCongTacThang = (from lct in db.tbLichCongTac_Thangs
                                            join i in db.tbImage_Liches on lct.image_id equals i.image_lich
                                            where lct.coso_id == CoSo && lct.namhoc_id == namhoc_id
                                            select new
                                            {
                                                lct.lichcongtac_thang_id,
                                                i.image_link,
                                                songuoixem = (from ls in db.tbQuanTri_LichSuXemLichCongTacThangs
                                                              where ls.lichcongtac_thang_id == lct.lichcongtac_thang_id
                                                              group ls by new { ls.username_id } into g
                                                              select g).Count(),
                                                //tonggiaovien = (from u in db.admin_Users
                                                //                where u.coso_id == CoSo
                                                //                && u.groupuser_id == 3
                                                //                select u).Count(),
                                            });
                //string dsThang = string.Join(",", listLichCongTacThang.Select(x => x.image_link).ToArray());
                //string dsSoNguoiXem_LCT_Thang = string.Join(",", listLichCongTacThang.Select(x => x.songuoixem).ToArray());
                txtDSLichCongTacThang.Value = string.Join(",", listLichCongTacThang.Select(x => x.image_link).ToArray()); ;
                txtDSSoNguoiXem_LCT_Thang.Value = string.Join(",", listLichCongTacThang.Select(x => x.songuoixem).ToArray()); ;
                txtDSLichCongTacThang_ID.Value = string.Join(",", listLichCongTacThang.Select(x => x.lichcongtac_thang_id).ToArray()); ;
                txtTongGiaoVien.Value = string.Join(",", LCT_Thang.Select(x => x.tonggiaovien).ToArray());
                //get danh sách các lịch công tác tuần của cs và thống kê số người xem 
                var listLichCongTacTuan = (from lct in db.tbLichCongTacs
                                           join i in db.tbHocTap_Tuans on lct.image_lich equals i.tuan_id
                                           where lct.coso_id == CoSo && lct.namhoc_id == namhoc_id
                                           select new
                                           {
                                               lct.lichcongtac_id,
                                               lct.lichcongtac_tuan,
                                               i.tuan_id,
                                               songuoixem = (from ls in db.tbQuantri_LichSuXemLichCongTacTuans
                                                             join u in db.admin_Users on ls.username_id equals u.username_id
                                                             where ls.lichcongtactuan_id == lct.lichcongtac_id
                                                             && u.coso_id == CoSo
                                                             group ls by new { ls.username_id } into g
                                                             select g).Count(),
                                           });


                string dsTuan = string.Join(",", listLichCongTacTuan.Select(x => x.lichcongtac_tuan.Substring(0, x.lichcongtac_tuan.Length - 14).Replace("(", "")).ToArray());
                string dsSoNguoiXem_LCT_Tuan = string.Join(",", listLichCongTacTuan.Select(x => x.songuoixem).ToArray());
                txtDSLichCongTacTuan.Value = dsTuan;
                txtDSLichCongTacTuan_ID.Value = string.Join(",", listLichCongTacTuan.Select(x => x.lichcongtac_id).ToArray());
                txtDSSoNguoiXem_LCT_Tuan.Value = dsSoNguoiXem_LCT_Tuan;
                txtTuanID.Value = string.Join(",", listLichCongTacTuan.Select(x => x.tuan_id).ToArray());
                try
                {
                    // lấy ds số lượng giáo viên đã nhập nhận xét sức khỏe
                    var getNXSK = from nxsk in db.tbVietNhatKids_SucKhoes
                                  join u in db.admin_Users on nxsk.username_id equals u.username_id
                                  where u.coso_id == CoSo
                                  group nxsk by nxsk.suckhoe_thang into k
                                  select new
                                  {
                                      k.Key,
                                      thang = (from t in db.tbImage_Liches
                                               where t.image_lich == Convert.ToInt32(k.Key)
                                               select t.image_link).First(),
                                      danhap = (from sk in db.tbVietNhatKids_SucKhoes
                                                join user in db.admin_Users on sk.username_id equals user.username_id
                                                where sk.suckhoe_thang == k.Key && sk.suckhoe_chieucao != "" && sk.suckhoe_cannang != "" && user.coso_id == CoSo
                                                group sk by new
                                                {
                                                    sk.username_id,
                                                } into c
                                                select new
                                                {
                                                    solan = c.Count(),
                                                }).Count(),
                                  };
                    if (getNXSK.Count() > 0)
                    {


                        txtDSSoNguoiNhap_NXSK.Value = string.Join(",", getNXSK.Select(x => x.danhap).ToArray());
                        txtDSThangNXSK.Value = string.Join(",", getNXSK.Select(x => x.thang + "|" + x.danhap).ToArray());
                    }
                }
                catch { }
                //get năm học hiện tại
                _idNamhoc = db.tbHoctap_NamHocs.Select(x => x.namhoc_id).ToList().Last();

                // get danh sách lịch báo giảng cs và thống kê số người đã nhập
                var listLichBaoGiangTuan = from lbg in db.tbLichBaoGiangs
                                           join us in db.admin_Users on lbg.username_id equals us.username_id
                                           join t in db.tbHocTap_Tuans on lbg.tuan_id equals t.tuan_id
                                           where us.coso_id == CoSo
                                           && t.namhoc_id == _idNamhoc
                                           group lbg by lbg.tuan_id into k
                                           select new
                                           {
                                               k.Key,
                                               tuan = (from tuan in db.tbHocTap_Tuans
                                                       where tuan.tuan_id == Convert.ToInt32(k.Key)
                                                       select tuan.tuan_name).First(),
                                               danhap = (from bg in db.tbLichBaoGiangs
                                                         join u in db.admin_Users on bg.username_id equals u.username_id
                                                         where bg.tuan_id == k.Key && u.coso_id == CoSo
                                                         && bg.lichbaogiang_trangthai == 1 && bg.hidden == false
                                                         group bg by bg.username_id into g
                                                         select new
                                                         {
                                                             g.Key
                                                         }).Count(),
                                           };
                txtDSLichBaoGiangTuan.Value = string.Join(",", listLichBaoGiangTuan.Select(x => x.danhap + "|" + x.tuan.Substring(0, x.tuan.Length - 14).Replace("(", "")).ToArray());
                txtDSSoNguoiDaNhap_LBG_Tuan.Value = string.Join(",", listLichBaoGiangTuan.Select(x => x.danhap).ToArray());
                //Thong ke suc khoe can nang
                var listHocSinh = (from hs in db.tbHocSinhs
                                   join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                                   join gvtl in db.tbGiaoVienTrongLops on hstl.lop_id equals gvtl.lop_id
                                   join user in db.admin_Users on gvtl.taikhoan_id equals user.username_id
                                   where user.username_username == Request.Cookies["UserName"].Value
                                   && gvtl.namhoc_id == _idNamhoc
                                   && hstl.namhoc_id == _idNamhoc
                                   select new
                                   {
                                       hs.hocsinh_name,
                                       hs.hocsinh_id,
                                       hstl.hstl_id
                                   });

                rpDanhSachHocSinhSucKhoe.DataSource = listHocSinh;
                rpDanhSachHocSinhSucKhoe.DataBind();

                txtDanhSachHocSinh.Value = string.Join(",", listHocSinh.Select(x => x.hocsinh_id));

                //nếu là hiệu trưởng các cs thì thấy được phiên chế năm học
                if (checkuserid.username_hieutruong_hieupho == true)
                {
                    //get phiên chế năm học
                    var phienche_namhoc = (from pc in db.tbQuanTri_PhienCheNamHocs
                                           join n in db.tbHoctap_NamHocs on pc.namhoc_id equals n.namhoc_id
                                           //join k in db.tbKhois on pc.khoi_id equals k.khoi_id
                                           //where k.coso_id == CoSo
                                           where pc.phienche_hidden == null
                                           orderby pc.phienche_id descending
                                           select new
                                           {
                                               pc.phienche_id,
                                               n.namhoc_nienkhoa,
                                               phienchedanhap = (from pcnh in db.tbQuanTri_PhienCheNamHocs
                                                                 join nh in db.tbHoctap_NamHocs on pcnh.namhoc_id equals nh.namhoc_id
                                                                 where pcnh.namhoc_id == n.namhoc_id && pcnh.phienche_hidden == null
                                                                 select pcnh).Count(),
                                               tongkhoi = 5,
                                           }).Take(1);
                    rpPhienCheNamHoc.DataSource = phienche_namhoc;
                    rpPhienCheNamHoc.DataBind();
                    //get kế hoạch dayh học đã được cô hương duyệt
                    var get_KeHoachDayHoc = (from khdh in db.tbQuanTri_KeHoachDayHoc_MamNons
                                             where khdh.kehoachdayhoc_hidden != true && khdh.kehoachdayhoc_trangthai == 4
                                             orderby khdh.kehoachdayhoc_id descending
                                             select new
                                             {
                                                 khdh.kehoachdayhoc_id,
                                                 keHoach_DaDuyet = (from kh in db.tbQuanTri_KeHoachDayHoc_MamNons
                                                                    where kh.kehoachdayhoc_hidden != true && kh.kehoachdayhoc_trangthai == 4
                                                                    select kh).Count(),
                                                 tongkhoi = (from kh in db.tbQuanTri_KeHoachDayHoc_MamNons
                                                             where kh.kehoachdayhoc_hidden != true
                                                             select kh).Count(),
                                             }).Take(1);
                    rpKeHoachDayHoc.DataSource = get_KeHoachDayHoc;
                    rpKeHoachDayHoc.DataBind();
                    //div_PhienCheQuanTri.Visible = true;
                    //div_LichCongTac_QuanTri.Visible = true;
                    div_KeHoachDayHoc.Visible = true;

                }
                else
                {
                    //div_LichCongTac_QuanTri.Visible = false;
                    div_KeHoachDayHoc.Visible = false;
                }
            }
            else
            {

                div_LichCongTacCoSo.Visible = false;
                div_LichCongTac_QuanTri.Visible = true;
                //rpt lịch báo  giảng quản trị
                var getLichBaoGiang = (from lbg in db.tbLichBaoGiangs
                                       where lbg.hidden == false
                                       select new
                                       {
                                           giaoviendanhap = (from gv in db.tbLichBaoGiangs
                                                             join u in db.admin_Users on gv.username_id equals u.username_id
                                                             where gv.lichbaogiang_trangthai == 1
                                                             select u).Count(),
                                           tonggiaovien = (from u in db.admin_Users
                                                           where u.groupuser_id == 3
                                                           select u).Count(),
                                       }).Take(1);
                rpLichBaoGiangQuanTri.DataSource = getLichBaoGiang;
                rpLichBaoGiangQuanTri.DataBind();
            }
            if (_idUser == 251)
            {
                div_DiemDanhNhanXetHangNgay.Visible = false;
                div_ThongKe.Visible = false;
                div_LichCongTac_QuanTri.Visible = true;
                var phienche_namhoc = (from pc in db.tbQuanTri_PhienCheNamHocs
                                       join n in db.tbHoctap_NamHocs on pc.namhoc_id equals n.namhoc_id
                                       //join k in db.tbKhois on pc.khoi_id equals k.khoi_id
                                       //where k.coso_id == CoSo
                                       where pc.phienche_hidden == null
                                       orderby pc.phienche_id descending
                                       select new
                                       {
                                           pc.phienche_id,
                                           n.namhoc_nienkhoa,
                                           phienchedanhap = (from pcnh in db.tbQuanTri_PhienCheNamHocs
                                                             join nh in db.tbHoctap_NamHocs on pcnh.namhoc_id equals nh.namhoc_id
                                                             where pcnh.namhoc_id == n.namhoc_id && pcnh.phienche_hidden == null
                                                             select pcnh).Count(),
                                           tongkhoi = 5,
                                       }).Take(1);
                rpPhienCheNamHocQuanTri.DataSource = phienche_namhoc;
                rpPhienCheNamHocQuanTri.DataBind();
                div_LichBaoGiangQuanTri.Visible = true;
                var get_KeHoachDayHoc = (from khdh in db.tbQuanTri_KeHoachDayHoc_MamNons
                                         where khdh.kehoachdayhoc_hidden != true
                                         orderby khdh.kehoachdayhoc_id descending
                                         select new
                                         {
                                             khdh.kehoachdayhoc_id,
                                             keHoach_DaDuyet = (from kh in db.tbQuanTri_KeHoachDayHoc_MamNons
                                                                where kh.kehoachdayhoc_hidden != true && kh.kehoachdayhoc_trangthai == 4
                                                                select kh).Count(),
                                             tongkhoi = (from kh in db.tbQuanTri_KeHoachDayHoc_MamNons
                                                         where kh.kehoachdayhoc_hidden != true
                                                         select kh).Count(),
                                         }).Take(1);
                rpKeHoachDayHoc.DataSource = get_KeHoachDayHoc;
                rpKeHoachDayHoc.DataBind();
                div_KeHoachDayHoc.Visible = true;
                var getLichBaoGiang = (from lbg in db.tbLichBaoGiangs
                                       where lbg.hidden == false
                                       select new
                                       {
                                           giaoviendanhap = (from gv in db.tbLichBaoGiangs
                                                             join u in db.admin_Users on gv.username_id equals u.username_id
                                                             select u).Count(),
                                           tonggiaovien = (from u in db.admin_Users
                                                           where u.groupuser_id == 3
                                                           select u).Count(),
                                       }).Take(1);
                rpLichBaoGiangQuanTri.DataSource = getLichBaoGiang;
                rpLichBaoGiangQuanTri.DataBind();
                div_LichBaoGiangCoSo.Visible = false;
            }
            //load kho tư liệu từng cơ sở
            int _idCoSo = Convert.ToInt32((from u in db.admin_Users
                                           where u.username_username == Request.Cookies["UserName"].Value
                                           select u.coso_id).First());
            //tính tổng file chung
            tong_filechung = (from f in db.tbQuanTri_FormMaus
                              where f.formau_loai == "file chung"
                              && f.formau_hidden == false
                              select f).Count();
            //tính tổng file cs1
            tong_file_coso1 = (from f in db.tbQuanTri_FormMaus
                               where f.formau_loai == "file co so 1"
                               && f.formau_hidden == false
                               select f).Count();
            //tính tổng file cs2
            tong_file_coso2 = (from f in db.tbQuanTri_FormMaus
                               where f.formau_loai == "file co so 2"
                               && f.formau_hidden == false
                               select f).Count();
            //tính tổng file cs3
            tong_file_coso3 = (from f in db.tbQuanTri_FormMaus
                               where f.formau_loai == "file co so 3"
                               && f.formau_hidden == false
                               select f).Count();
            if (_idCoSo == 1)
            {
                div_KhoTuLieu_CS1.Visible = true;
                div_KhoTuLieu_CS2.Visible = false;
                div_KhoTuLieu_CS3.Visible = false;
            }
            else if (_idCoSo == 2)
            {
                div_KhoTuLieu_CS1.Visible = false;
                div_KhoTuLieu_CS2.Visible = true;
                div_KhoTuLieu_CS3.Visible = false;
            }
            else if (_idCoSo == 3)
            {
                div_KhoTuLieu_CS1.Visible = false;
                div_KhoTuLieu_CS2.Visible = false;
                div_KhoTuLieu_CS3.Visible = true;
            }
            else
            {
                div_KhoTuLieu_CS1.Visible = true;
                div_KhoTuLieu_CS2.Visible = true;
                div_KhoTuLieu_CS3.Visible = true;
            }
            rpList.DataSource = from l in db.tbThongBaos orderby l.thongbao_id descending select l;
            rpList.DataBind();

        }
        else
        {
            Response.Redirect("/admin-login");
        }
        //int tuan_id = Convert.ToInt32((from t in db.tbLichBookPhongThongMinhs orderby t.lichbookphongthongminh_id descending select t).First().tuan_id);
        //lblTuan.Text = (from t in db.tbHocTap_Tuans where t.tuan_id == tuan_id select t).SingleOrDefault().tuan_name + "";
        //rpBookRoom.DataSource = from nb in db.tbLichBookPhongThongMinhs
        //                        where nb.tuan_id == tuan_id
        //                        select nb;
        //rpBookRoom.DataBind();
    }
    protected void btnXem_ServerClick(object sender, EventArgs e)
    {
        //alert.alert_Success(Page,"get_id" + txtThongBao_id.Value,"");
        Response.Redirect("admin-file-huong-dan-danh-gia-" + txtThongBao_id.Value);
    }
    protected void rpBookRoom_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpChiTiet = e.Item.FindControl("rpChiTiet") as Repeater;
        int lichbookphongthongminh_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "lichbookphongthongminh_id").ToString());
        rpChiTiet.DataSource = from ct in db.tblichbookphongchitiets
                               where ct.lichbookphongthongminh_id == lichbookphongthongminh_id
                               select new
                               {
                                   ct.lichbookphongchitiet_class,
                                   ct.lichbookphongchitiet_id,
                                   giaovien = ct.lichbookphongchitiet_giaovien == null ? "Chưa book" : ct.lichbookphongchitiet_giaovien,
                               };
        rpChiTiet.DataBind();
    }
    //kiểm tra xem giáo viên đó đã xem lịch công tác tuần nào đó chưa
    private bool checkXemLCT_Tuan(int username_id, int lct_id)
    {
        var check = db.tbQuanTri_XemLichCongTacTuans.Any(x => x.username_id == username_id && x.lichcongtactuan_id == lct_id);
        if (check == true)
            return false;
        else
            return true;

    }
    //kiểm tra xem giáo viên đó đã xem lịch công tác tháng nào đó chưa
    private bool checkXemLCT_Thang(int username_id, int lct_id)
    {
        var check = db.tbQuanTri_XemLichCongTacThangs.Any(x => x.username_id == username_id && x.lichcongtacthang_id == lct_id);
        if (check == true)
            return false;
        else
            return true;

    }
    protected void btnXemLichCongTacTuanCoSo_ServerClick(object sender, EventArgs e)
    {
        //int lct_id = (from lct in db.tbLichCongTacs
        //              where lct.lichcongtac_hidden == null && lct.coso_id == CoSo
        //              orderby lct.lichcongtac_id descending
        //              select lct).Take(1).FirstOrDefault().lichcongtac_id;
        //tbQuantri_LichSuXemLichCongTacTuan lichsu = new tbQuantri_LichSuXemLichCongTacTuan();
        //lichsu.username_id = _idUser;
        //lichsu.lichcongtactuan_id = lct_id;
        //lichsu.lichsu_ngayxem = DateTime.Now;
        //db.tbQuantri_LichSuXemLichCongTacTuans.InsertOnSubmit(lichsu);
        //db.SubmitChanges();
        ////nếu user đã xem thì chuyển trang và không đếm lên
        //if (checkXemLCT_Tuan(_idUser, lct_id) == false)
        //{
        //    Response.Redirect("admin-xem-lich-cong-tac-hang-tuan-co-so-" + CoSo);
        //}
        //else
        //{
        //    tbQuanTri_XemLichCongTacTuan insert = new tbQuanTri_XemLichCongTacTuan();
        //    insert.username_id = _idUser;
        //    insert.lichcongtactuan_id = lct_id;
        //    insert.xem_ngayxem = DateTime.Now;
        //    insert.xem_trangthai = 1; //mặc định
        //    db.tbQuanTri_XemLichCongTacTuans.InsertOnSubmit(insert);
        //    db.SubmitChanges();
        Response.Redirect("admin-xem-lich-cong-tac-hang-tuan-co-so-" + CoSo);
        //}
    }
    protected void btnXemLichCongTacThangCoSo_ServerClick(object sender, EventArgs e)
    {
        //int lct_id = (from lct in db.tbLichCongTac_Thangs
        //              where lct.lichcongtac_thang_hidden == null && lct.coso_id == CoSo
        //              orderby lct.lichcongtac_thang_id descending
        //              select lct).Take(1).FirstOrDefault().lichcongtac_thang_id;
        ////nếu user đã xem thì chuyển trang và không đếm lên
        //if (checkXemLCT_Thang(_idUser, lct_id) == false)
        //{
        //    Response.Redirect("admin-xem-lich-cong-tac-thang-co-so-" + CoSo);
        //}
        //else
        //{
        //    tbQuanTri_XemLichCongTacThang insert = new tbQuanTri_XemLichCongTacThang();
        //    insert.username_id = _idUser;
        //    insert.lichcongtacthang_id = lct_id;
        //    insert.xem_ngayxem = DateTime.Now;
        //    insert.xem_trangthai = 1; //mặc định
        //    db.tbQuanTri_XemLichCongTacThangs.InsertOnSubmit(insert);
        //    db.SubmitChanges();
        Response.Redirect("admin-xem-lich-cong-tac-thang-co-so-" + CoSo);
        //}
    }
    protected void btnXemPhienCheNamHocCoSo_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("admin-xem-phien-che-nam-hoc-co-so-" + CoSo);
    }
    protected void btnXemLichCongTacTuanQuanTri_ServerClick(object sender, EventArgs e)
    {
        //admin-xem-lich-cong-tac-hang-tuan
        Response.Redirect("admin-xem-lich-cong-tac-hang-tuan");
    }
    protected void btnXemLichCongTacThangQuanTri_ServerClick(object sender, EventArgs e)
    {
        //admin-xem-lich-cong-tac-thang
        Response.Redirect("admin-xem-lich-cong-tac-thang");
    }
    protected void btnXemPhienCheNamHocQuanTri_ServerClick(object sender, EventArgs e)
    {
        //admin-xem-phien-che-nam-hoc
        Response.Redirect("admin-xem-phien-che-nam-hoc");
    }
    protected void btnLichBaoGiangQuanTri_ServerClick(object sender, EventArgs e)
    {
        //admin-lich-bao-giang-tong
        Response.Redirect("/admin-xem-lich-bao-giang-tong");
    }
    protected void btnLichBaoGiangCoSo_ServerClick(object sender, EventArgs e)
    {
        //admin-lich-bao-giang-tong-theo-co-so-{cosoid}
        Response.Redirect("admin-lich-bao-giang-tong-theo-co-so-" + CoSo);
    }
    protected void btnXemChiTiet_LCT_Thang_ServerClick(object sender, EventArgs e)
    {
        //get id lịch công tác tháng
        int id_Lich = Convert.ToInt32(txtThangDuocChon.Value);
        //lấy toàn bộ ds nhân viên
        var listUser = from u in db.admin_Users
                       join bp in db.tbBoPhans on u.bophan_id equals bp.bophan_id
                       where u.username_id != 1 && u.coso_id == CoSo && u.username_active == true/* && u.groupuser_id == 3*/
                       select new
                       {
                           u.username_fullname,
                           bp.bophan_name,
                       };
        var listDaXem = from ls in db.tbQuanTri_LichSuXemLichCongTacThangs
                        join u in db.admin_Users on ls.username_id equals u.username_id
                        where ls.lichcongtac_thang_id == id_Lich
                        && u.coso_id == CoSo && u.username_active == true //&& u.groupuser_id == 3
                        group ls by new { ls.username_id } into g
                        select new
                        {
                            username_fullname = (from user in db.admin_Users
                                                 where user.username_id == g.First().username_id
                                                 select user.username_fullname).FirstOrDefault(),
                            bophan_name = (from bophan in db.tbBoPhans
                                           join bp_u in db.admin_Users on bophan.bophan_id equals bp_u.bophan_id
                                           where bp_u.username_id == g.First().username_id
                                           select bophan.bophan_name).FirstOrDefault(),
                            xemcongtacthang_ngayxem = g.First().lichsu_xemlichcongtac_thang_ngayxem,
                        };
        var listDaXem2 = from ls in db.tbQuanTri_LichSuXemLichCongTacThangs
                         join u in db.admin_Users on ls.username_id equals u.username_id
                         where ls.lichcongtac_thang_id == id_Lich
                          && u.coso_id == CoSo && u.username_active == true //&& u.groupuser_id == 3
                         group ls by new { ls.username_id } into g
                         select new
                         {
                             username_fullname = (from user in db.admin_Users
                                                  where user.username_id == g.First().username_id
                                                  select user.username_fullname).FirstOrDefault(),
                             bophan_name = (from bophan in db.tbBoPhans
                                            join bp_u in db.admin_Users on bophan.bophan_id equals bp_u.bophan_id
                                            where bp_u.username_id == g.First().username_id
                                            select bophan.bophan_name).FirstOrDefault(),
                         };
        rpDSDaXem.DataSource = listDaXem;
        rpDSDaXem.DataBind();
        rpDSChuaXem.DataSource = listUser.Except(listDaXem2);
        rpDSChuaXem.DataBind();
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupXemChiTiet_LCT_Thang.Show();", true);
    }
    protected void btnXemChiTiet_LCT_Tuan_ServerClick(object sender, EventArgs e)
    {
        //get id lịch công tác tuần
        int id_Lich = Convert.ToInt32(txtTuanDuocChon.Value);
        var listDaNhap = from u in db.admin_Users
                         join bp in db.tbBoPhans on u.bophan_id equals bp.bophan_id
                         join ls in db.tbQuantri_LichSuXemLichCongTacTuans on u.username_id equals ls.username_id
                         //join lct in db.tbLichCongTacs on ls.lichcongtactuan_id equals lct.lichcongtac_tuan
                         where ls.lichcongtactuan_id == id_Lich && u.coso_id == CoSo && u.username_active == true
                         group ls by new
                         {
                             ls.username_id,
                         } into k
                         select new
                         {
                             username_fullname = (from user in db.admin_Users
                                                  where user.username_id == k.First().username_id
                                                  select user.username_fullname).FirstOrDefault(),
                             bophan_name = (from bophan in db.tbBoPhans
                                            join bp_u in db.admin_Users on bophan.bophan_id equals bp_u.bophan_id
                                            where bp_u.username_id == k.First().username_id
                                            select bophan.bophan_name).FirstOrDefault(),
                             xemcongtactuan_ngayxem = k.First().lichsu_ngayxem,
                             solanxem = k.Count(),
                         };

        var _idTong = (from u in db.admin_Users
                       join bp in db.tbBoPhans on u.bophan_id equals bp.bophan_id
                       where u.username_id != 1 && u.coso_id == CoSo && u.username_active == true
                       //&& u.groupuser_id != 11 && u.groupuser_id != 12
                       select new
                       {
                           u.username_id,
                           u.username_fullname,
                           bp.bophan_name,
                       });

        var _idChuaXem = (from ls in db.tbQuantri_LichSuXemLichCongTacTuans
                          join u in db.admin_Users on ls.username_id equals u.username_id
                          join bp in db.tbBoPhans on u.bophan_id equals bp.bophan_id
                          where ls.lichcongtactuan_id == id_Lich
                          && u.coso_id == CoSo && u.username_active == true
                          select new
                          {
                              u.username_id,
                              u.username_fullname,
                              bp.bophan_name,
                          });

        rpDSDaXemTuan.DataSource = listDaNhap;
        rpDSDaXemTuan.DataBind();

        rpDSChuaXemTuan.DataSource = _idTong.Except(_idChuaXem);
        rpDSChuaXemTuan.DataBind();
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupXemLCT_Tuan.Show();", true);
    }
    protected void btnXemChiTiet_LBG_Tuan_ServerClick(object sender, EventArgs e)
    {
        //lấy toàn bộ ds nhân viên
        var listUser = from u in db.admin_Users
                       join bp in db.tbBoPhans on u.bophan_id equals bp.bophan_id
                       where u.username_id != 1 && u.coso_id == CoSo && u.groupuser_id == 3
                       && u.username_active == true
                       select new
                       {
                           u.username_fullname,
                           bp.bophan_name,
                       };


        var listDaNhap = (from lbg in db.tbLichBaoGiangs
                          join t in db.tbHocTap_Tuans on lbg.tuan_id equals t.tuan_id
                          join us in db.admin_Users on lbg.username_id equals us.username_id
                          join bp in db.tbBoPhans on us.bophan_id equals bp.bophan_id
                          where t.tuan_id == Convert.ToInt32(txtTuanDuocChonBG.Value)
                          && lbg.hidden == false && lbg.lichbaogiang_active == true
                          && lbg.lichbaogiang_trangthai == 1
                          && us.coso_id == CoSo
                          && t.namhoc_id == _idNamhoc
                          select new
                          {
                              us.username_fullname,
                              bp.bophan_name,
                              ngaynhap = lbg.lichbaogiang_ngaytao,
                          });


        var listDaNhap1 = (from lbg in db.tbLichBaoGiangs
                           join t in db.tbHocTap_Tuans on lbg.tuan_id equals t.tuan_id
                           join us in db.admin_Users on lbg.username_id equals us.username_id
                           join bp in db.tbBoPhans on us.bophan_id equals bp.bophan_id
                           where t.tuan_id == Convert.ToInt32(txtTuanDuocChonBG.Value)
                           && lbg.hidden == false && lbg.lichbaogiang_active == true
                           && lbg.lichbaogiang_trangthai == 1
                           && us.coso_id == CoSo
                           && t.namhoc_id == _idNamhoc
                           select new
                           {
                               us.username_fullname,
                               bp.bophan_name,
                           });

        rpDSDaNhap.DataSource = listDaNhap;
        rpDSDaNhap.DataBind();
        rpDSChuaNhap.DataSource = listUser.Except(listDaNhap1);
        rpDSChuaNhap.DataBind();
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupXemLBG_Tuan.Show();", true);
    }
    protected void btnXemChiTiet_NXSK_Thang_ServerClick(object sender, EventArgs e)
    {
        //lấy toàn bộ ds nhân viên
        var listUser = from u in db.admin_Users
                       join bp in db.tbBoPhans on u.bophan_id equals bp.bophan_id
                       where u.username_id != 1 && u.coso_id == CoSo && u.groupuser_id == 3 && u.username_active==true
                       select new
                       {
                           u.username_fullname,
                           bp.bophan_name,
                       };

        int id_lich = (from nxsk in db.tbVietNhatKids_SucKhoes
                       join img in db.tbImage_Liches on Convert.ToInt32(nxsk.suckhoe_thang) equals img.image_lich
                       where img.image_link == txtThangDuocChonNXSK.Value
                       select img.image_lich).First();

        var listDaNhap = (from nxsk in db.tbVietNhatKids_SucKhoes
                          join u in db.admin_Users on nxsk.username_id equals u.username_id
                          join bp in db.tbBoPhans on u.bophan_id equals bp.bophan_id
                          where u.coso_id == CoSo
                          && nxsk.suckhoe_thang == id_lich.ToString()
                          select new
                          {
                              u.username_fullname,
                              bp.bophan_name,
                              ngaynhap = nxsk.suckhoe_ngay,
                          }).Distinct();

        var listDaNhap1 = (from nxsk in db.tbVietNhatKids_SucKhoes
                           join u in db.admin_Users on nxsk.username_id equals u.username_id
                           join bp in db.tbBoPhans on u.bophan_id equals bp.bophan_id
                           where u.coso_id == CoSo
                           && nxsk.suckhoe_thang == id_lich.ToString()
                           select new
                           {
                               u.username_fullname,
                               bp.bophan_name,
                           }).Distinct();

        rpNXSKDaNhap.DataSource = listDaNhap;
        rpNXSKDaNhap.DataBind();
        rpNXSKChuaNhap.DataSource = listUser.Except(listDaNhap1);
        rpNXSKChuaNhap.DataBind();
        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Detail", "popupXemNXSK.Show();", true);
    }
    protected void btnShowSucKhoe_ServerClick(object sender, EventArgs e)
    {
        var arrIdHs = txtDanhSachSucKhoeHocSinhDaChon.Value.Split(',');

        List<string> listTenHocSinh = new List<string>();

        for (int i = 0; i < arrIdHs.Length; i++)
        {
            var getHocSinhName = (from hs in db.tbHocSinhs where hs.hocsinh_id == Convert.ToInt32(arrIdHs[i]) select new { hs.hocsinh_name });
            string thongTinHocSinh = string.Join(",", getHocSinhName.Select(x => x.hocsinh_name));
            listTenHocSinh.Add(thongTinHocSinh);
        }
        string[] arrThongTinHocSinh = listTenHocSinh.ToArray();

        var getUser = (from u in db.admin_Users
                       join gvtl in db.tbGiaoVienTrongLops on u.username_id equals gvtl.taikhoan_id
                       where u.username_username == Request.Cookies["UserName"].Value
                       orderby gvtl.gvtl_id descending
                       select new { u.username_id, gvtl.lop_id }).First();

        txtDanhSachSucKhoeTenHocSinhDaChon.Value = string.Join(",", arrThongTinHocSinh.Select(x => x));
        //Thang 1 -> 12
        List<string> listCanNangThang = new List<string>();
        List<string> listChieuCaoThang = new List<string>();

        for (int i = 0; i < arrIdHs.Length; i++)
        {
            for (int j = 36; j <= 47; j++)
            {
                var getSKThang = (from sk in db.tbVietNhatKids_SucKhoes
                                      //join u in db.admin_Users on sk.username_id equals u.username_id
                                  join t in db.tbHocTap_Tuans on sk.namhoc_id equals t.namhoc_id
                                  join hstl in db.tbHocSinhTrongLops on sk.hocsinh_id equals hstl.hocsinh_id
                                  join gvtl in db.tbGiaoVienTrongLops on hstl.lop_id equals gvtl.lop_id
                                  where
                                  //u.username_username == Request.Cookies["UserName"].Value && 
                                  gvtl.taikhoan_id == getUser.username_id &&
                                  t.namhoc_id == _idNamhoc
                                  && gvtl.namhoc_id == _idNamhoc
                                  && hstl.namhoc_id == _idNamhoc
                                  && sk.suckhoe_thang == j.ToString()
                                  && sk.hocsinh_id == Convert.ToInt64(arrIdHs[i])
                                  && sk.lop_id == getUser.lop_id
                                  group sk by sk.suckhoe_id into k
                                  orderby k.Key descending
                                  select new
                                  {
                                      suckhoe_cannang = k.First().suckhoe_cannang,
                                      suckhoe_chieucao = k.First().suckhoe_chieucao,
                                      hocsinh_id = k.First().hocsinh_id,
                                      suckhoe_id = k.Key,
                                  }).Take(1);
                string thongTinCanNang = string.Join(",", getSKThang.Select(x => x.suckhoe_cannang + "|" + x.hocsinh_id));
                string thongTinChieuCao = string.Join(",", getSKThang.Select(x => x.suckhoe_chieucao + "|" + x.hocsinh_id));
                listCanNangThang.Add(thongTinCanNang);
                listChieuCaoThang.Add(thongTinChieuCao);
            }
        }
        string[] arrCanNangThang = listCanNangThang.ToArray();
        string[] arrChieuCaoThang = listChieuCaoThang.ToArray();

        txtCanNangThang.Value = string.Join(",", arrCanNangThang.Select(x => x));
        txtChieuCaoThang.Value = string.Join(",", arrChieuCaoThang.Select(x => x));
    }

    //get chi tiết điểm tích lũy

    protected void rpGiaoVienNhaXetThuongXuyen_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        Repeater rpChiTietNhanXetHangNgay = e.Item.FindControl("rpChiTietNhanXetHangNgay") as Repeater;
        int username_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "username_id").ToString());
        if (ddlThang.SelectedValue != "Chọn tháng")
        {
            var getChiTiet = from u in db.admin_Users
                             where u.username_id == username_id
                             select new
                             {
                                 u.username_id,
                                 u.username_fullname,
                                 diemtichluychitiet_congviechangngay = (from ls in db.tbLichSus
                                                                        where ls.username_id == u.username_id
                                                                        where ls.lichsu_date.Value.Month == Convert.ToInt16(ddlThang.SelectedValue)
                                                                        select ls).Sum(x => x.lichsu_diemtichluy),
                                 diemtichluychitiet_DanThuoc = (from ls in db.tbVietNhatKids_PhuHuynhDanDoThuocs
                                                                join hstl in db.tbHocSinhTrongLops on ls.hstl_id equals hstl.hstl_id
                                                                join l in db.tbLops on hstl.lop_id equals l.lop_id
                                                                join gvtl in db.tbGiaoVienTrongLops on l.lop_id equals gvtl.lop_id
                                                                where gvtl.taikhoan_id == u.username_id && ls.namhoc_id == 11 && gvtl.namhoc_id == 11
                                                                && ls.phuhuynhdandothuoc_createdate.Value.Month == Convert.ToInt16(ddlThang.SelectedValue)
                                                                select ls).Sum(x => x.phuhuynhdandothuoc_diemtichluy),
                                 diemtichluychitiet_TaoBaiViet = (from ls in db.tbVietNhatKids_AlbumImages
                                                                  join gvtl in db.tbGiaoVienTrongLops on ls.gvtl_id equals gvtl.gvtl_id
                                                                  where gvtl.taikhoan_id == u.username_id && ls.namhoc_id == 11 && gvtl.namhoc_id == 11
                                                                   && ls.albumimage_datecreate.Value.Month == Convert.ToInt16(ddlThang.SelectedValue)
                                                                   && ls.albumimage_tinhtrang == true
                                                                  select ls).Sum(x => x.albumImage_diemtichluy),
                                 diemtichluychitiet_XinNghi = (from ls in db.tbVietNhatKids_PhuHuynhXinNghis
                                                               join hstl in db.tbHocSinhTrongLops on ls.hstl_id equals hstl.hstl_id
                                                               join l in db.tbLops on hstl.lop_id equals l.lop_id
                                                               join gvtl in db.tbGiaoVienTrongLops on l.lop_id equals gvtl.lop_id
                                                               where gvtl.taikhoan_id == u.username_id && ls.namhoc_id == 11 && gvtl.namhoc_id == 11
                                                                && ls.phuhuynhxinnghi_ngaydangki.Value.Month == Convert.ToInt16(ddlThang.SelectedValue)
                                                               select ls).Sum(x => x.phuhuynhxinnghi_diemtichluy),
                                 diemtichluychitiet_TaoThongBaoLop = (from ls in db.tbVietNhatKids_ThongBaoLops
                                                                      join lop in db.tbLops on ls.lop_id equals lop.lop_id
                                                                      join gvtl in db.tbGiaoVienTrongLops on ls.lop_id equals gvtl.lop_id
                                                                      where gvtl.taikhoan_id == u.username_id && ls.namhoc_id == 11 && gvtl.namhoc_id == 11
                                                                       && ls.thongbaoLop_datecreate.Value.Month == Convert.ToInt16(ddlThang.SelectedValue)
                                                                       && ls.username_id == u.username_id
                                                                      select ls).Sum(x => x.thongbaolop_diemtichluy),
                                 diemtichluychitiet_TaoThongBaoTruong = (from ls in db.tbVietNhatKids_ThongBaoTruongs
                                                                         where ls.username_id == u.username_id && ls.namhoc_id == 11
                                                                          && ls.thongbaotruong_datecreate.Value.Month == Convert.ToInt16(ddlThang.SelectedValue)
                                                                         select ls).Sum(x => x.thongbaotruong_diemtichluy),
                                 diemtichluychitiet_DuyetThongBaoLop = (from ls in db.tbLichSuDuyet_BanGiamHieus
                                                                        where ls.username_id == u.username_id && ls.namhoc_id == 11
                                                                         && ls.lichsuduyet_ngayduyet.Value.Month == Convert.ToInt16(ddlThang.SelectedValue)
                                                                        select ls).Sum(x => x.lichsuduyet_diemtichluy),
                                 diemtichluychitiet_XacNhanNgoaiKhoa = (from ls in db.tbVietNhatKids_DangKyNgoaiKhoas
                                                                        join hstl in db.tbHocSinhTrongLops on ls.hstl_id equals hstl.hstl_id
                                                                        join l in db.tbLops on hstl.lop_id equals l.lop_id
                                                                        join gvtl in db.tbGiaoVienTrongLops on l.lop_id equals gvtl.lop_id
                                                                        where gvtl.taikhoan_id == u.username_id && ls.namhoc_id == 11 && gvtl.namhoc_id == 11
                                                                         && ls.dangkyngoaikhoa_datecreate.Value.Month == Convert.ToInt16(ddlThang.SelectedValue)
                                                                        select ls).Sum(x => x.dangkyngoaikhoa_diemtichluy),
                                 diemtichluychitiet_TaoLichBaoGiang = (from ls in db.tbLichBaoGiangs
                                                                       where ls.username_id == u.username_id && ls.namhoc_id == 11
                                                                        && ls.lichbaogiang_ngaytao.Value.Month == Convert.ToInt16(ddlThang.SelectedValue)
                                                                        && ls.hidden == false
                                                                       select ls).Sum(x => x.lichbaogiang_diemtichluy),
                             };


            rpChiTietNhanXetHangNgay.DataSource = getChiTiet;
            rpChiTietNhanXetHangNgay.DataBind();
        }
        else
        {
            var getChiTiet = from u in db.admin_Users
                             where u.username_id == username_id
                             select new
                             {
                                 u.username_id,
                                 u.username_fullname,
                                 diemtichluychitiet_congviechangngay = (from ls in db.tbLichSus
                                                                        where ls.username_id == u.username_id
                                                                        && ls.lichsu_date.Value.Month == DateTime.Now.Month
                                                                        select ls).Sum(x => x.lichsu_diemtichluy),
                                 diemtichluychitiet_DanThuoc = (from ls in db.tbVietNhatKids_PhuHuynhDanDoThuocs
                                                                join hstl in db.tbHocSinhTrongLops on ls.hstl_id equals hstl.hstl_id
                                                                join l in db.tbLops on hstl.lop_id equals l.lop_id
                                                                join gvtl in db.tbGiaoVienTrongLops on l.lop_id equals gvtl.lop_id
                                                                where gvtl.taikhoan_id == u.username_id && ls.namhoc_id == 11 && gvtl.namhoc_id == 11
                                                                && ls.phuhuynhdandothuoc_createdate.Value.Month == DateTime.Now.Month
                                                                select ls).Sum(x => x.phuhuynhdandothuoc_diemtichluy),
                                 diemtichluychitiet_TaoBaiViet = (from ls in db.tbVietNhatKids_AlbumImages
                                                                  join gvtl in db.tbGiaoVienTrongLops on ls.gvtl_id equals gvtl.gvtl_id
                                                                  where gvtl.taikhoan_id == u.username_id && ls.namhoc_id == 11 && gvtl.namhoc_id == 11
                                                                   && ls.albumimage_datecreate.Value.Month == DateTime.Now.Month
                                                                   && ls.albumimage_tinhtrang == true
                                                                  select ls).Sum(x => x.albumImage_diemtichluy),
                                 diemtichluychitiet_XinNghi = (from ls in db.tbVietNhatKids_PhuHuynhXinNghis
                                                               join hstl in db.tbHocSinhTrongLops on ls.hstl_id equals hstl.hstl_id
                                                               join l in db.tbLops on hstl.lop_id equals l.lop_id
                                                               join gvtl in db.tbGiaoVienTrongLops on l.lop_id equals gvtl.lop_id
                                                               where gvtl.taikhoan_id == u.username_id && ls.namhoc_id == 11 && gvtl.namhoc_id == 11
                                                                && ls.phuhuynhxinnghi_ngaydangki.Value.Month == DateTime.Now.Month
                                                               select ls).Sum(x => x.phuhuynhxinnghi_diemtichluy),
                                 diemtichluychitiet_TaoThongBaoLop = (from ls in db.tbVietNhatKids_ThongBaoLops
                                                                      join lop in db.tbLops on ls.lop_id equals lop.lop_id
                                                                      join gvtl in db.tbGiaoVienTrongLops on ls.lop_id equals gvtl.lop_id
                                                                      where gvtl.taikhoan_id == u.username_id && ls.namhoc_id == 11 && gvtl.namhoc_id == 11
                                                                       && ls.thongbaoLop_datecreate.Value.Month == DateTime.Now.Month
                                                                       && ls.username_id == u.username_id
                                                                      select ls).Sum(x => x.thongbaolop_diemtichluy),
                                 diemtichluychitiet_TaoThongBaoTruong = (from ls in db.tbVietNhatKids_ThongBaoTruongs
                                                                         where ls.username_id == u.username_id && ls.namhoc_id == 11
                                                                          && ls.thongbaotruong_datecreate.Value.Month == DateTime.Now.Month
                                                                         select ls).Sum(x => x.thongbaotruong_diemtichluy),
                                 diemtichluychitiet_DuyetThongBaoLop = (from ls in db.tbLichSuDuyet_BanGiamHieus
                                                                        where ls.username_id == u.username_id && ls.namhoc_id == 11
                                                                         && ls.lichsuduyet_ngayduyet.Value.Month == DateTime.Now.Month
                                                                        select ls).Sum(x => x.lichsuduyet_diemtichluy),
                                 diemtichluychitiet_XacNhanNgoaiKhoa = (from ls in db.tbVietNhatKids_DangKyNgoaiKhoas
                                                                        join hstl in db.tbHocSinhTrongLops on ls.hstl_id equals hstl.hstl_id
                                                                        join l in db.tbLops on hstl.lop_id equals l.lop_id
                                                                        join gvtl in db.tbGiaoVienTrongLops on l.lop_id equals gvtl.lop_id
                                                                        where gvtl.taikhoan_id == u.username_id && ls.namhoc_id == 11 && gvtl.namhoc_id == 11
                                                                         && ls.dangkyngoaikhoa_datecreate.Value.Month == DateTime.Now.Month
                                                                        select ls).Sum(x => x.dangkyngoaikhoa_diemtichluy),
                                 diemtichluychitiet_TaoLichBaoGiang = (from ls in db.tbLichBaoGiangs
                                                                       where ls.username_id == u.username_id && ls.namhoc_id == 11
                                                                        && ls.lichbaogiang_ngaytao.Value.Month == DateTime.Now.Month
                                                                        && ls.hidden == false
                                                                       select ls).Sum(x => x.lichbaogiang_diemtichluy),
                             };


            rpChiTietNhanXetHangNgay.DataSource = getChiTiet;
            rpChiTietNhanXetHangNgay.DataBind();
        }
    }
    protected void rpGiaoVienNhanXetThuongXuyen_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rpChiTietNhanXetHangNgay = e.Item.FindControl("rpChiTietNhanXetHangNgay") as Repeater;
        int username_id = int.Parse(DataBinder.Eval(e.Item.DataItem, "username_id").ToString());
        if (dteNgay.Value != "")
        {
            var getChiTiet = from ls in db.tbLichSus
                             join cv in db.tbDanhSachCongViecs on ls.danhsachcongviec_id equals cv.danhsachcongviec_id
                             where ls.username_id == username_id
                               && ls.lichsu_date.Value.Day == Convert.ToDateTime(dteNgay.Value).Day && ls.lichsu_date.Value.Month == Convert.ToDateTime(dteNgay.Value).Month
                               && ls.lichsu_date.Value.Year == Convert.ToDateTime(dteNgay.Value).Year
                             select new
                             {
                                 cv.danhsachcongviec_name,
                                 ls.lichsu_date
                             };

            rpChiTietNhanXetHangNgay.DataSource = getChiTiet;
            rpChiTietNhanXetHangNgay.DataBind();
        }
        else
        {
            var getChiTiet = from ls in db.tbLichSus
                             join cv in db.tbDanhSachCongViecs on ls.danhsachcongviec_id equals cv.danhsachcongviec_id
                             where ls.username_id == username_id
                               && ls.lichsu_date.Value.Day == DateTime.Now.Day && ls.lichsu_date.Value.Month == DateTime.Now.Month
                               && ls.lichsu_date.Value.Year == DateTime.Now.Year
                             select new
                             {
                                 cv.danhsachcongviec_name,
                                 ls.lichsu_date
                             };

            rpChiTietNhanXetHangNgay.DataSource = getChiTiet;
            rpChiTietNhanXetHangNgay.DataBind();
        }
    }

    protected void btnXemThongKeNhanXetHangNgay_ServerClick(object sender, EventArgs e)
    {
        if (dteNgay.Value == "")
        {
            alert.alert_Warning(Page, "Vui lòng nhập ngày", "");
        }
        else
        {
            var getDiemDanhHangNgay = from u in db.admin_Users
                                      join gvtl in db.tbGiaoVienTrongLops on u.username_id equals gvtl.taikhoan_id
                                      where u.coso_id == CoSo && u.username_active == true
                                      && gvtl.namhoc_id == _idNamhoc
                                      select new
                                      {
                                          u.username_id,
                                          u.username_fullname,
                                          u.username_avatar,
                                          gvtl.lop_id,
                                          lop_name = (from l in db.tbLops where l.lop_id == gvtl.lop_id select l.lop_name).FirstOrDefault(),
                                          SoLuongDiemDanhHangNgay = (from ls in db.tbLichSus
                                                                     where ls.username_id == u.username_id
                                             && ls.lichsu_date.Value.Day == Convert.ToDateTime(dteNgay.Value).Day && ls.lichsu_date.Value.Month == Convert.ToDateTime(dteNgay.Value).Month
                                             && ls.lichsu_date.Value.Year == Convert.ToDateTime(dteNgay.Value).Year
                                                                     select ls).Count(),
                                          TongSoLuongDiemDanhHangNgay = 5,
                                      };
            rpDiemDanhHangNgay.DataSource = getDiemDanhHangNgay.OrderBy(x => x.lop_name);
            rpDiemDanhHangNgay.DataBind();
            rpGiaoVienNhanXetThuongXuyen.DataSource = getDiemDanhHangNgay;
            rpGiaoVienNhanXetThuongXuyen.DataBind();
        }
    }

    protected void ddlThang_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlThang.SelectedValue != "Chọn tháng")
        {


            div_SucKhoeHocSinh.Visible = true;
            div_CongViecHangNgay.Visible = true;
            div_DiemDanhNhanXetHangNgay.Visible = false;

            //tính điểm tích lũy những công việc hàng ngày
            var getDiemDanhHangNgay = from u in db.admin_Users
                                      where u.coso_id == CoSo && u.username_active == true && u.groupuser_id == 3
                                      select new
                                      {
                                          u.username_id,
                                          u.username_fullname,
                                          diemtichluy = (from ls in db.tbLichSus
                                                         where ls.username_id == u.username_id
                                                         && ls.lichsu_date.Value.Month == Convert.ToInt16(ddlThang.SelectedValue)
                                                         select ls).Sum(x => x.lichsu_diemtichluy),
                                      };


            var getDiemThuocPhuHuynh = from u in db.admin_Users
                                       where u.coso_id == CoSo && u.username_active == true
                                       && u.groupuser_id == 3
                                       select new
                                       {
                                           u.username_id,
                                           u.username_fullname,
                                           diemtichluy = (from ls in db.tbVietNhatKids_PhuHuynhDanDoThuocs
                                                          join hstl in db.tbHocSinhTrongLops on ls.hstl_id equals hstl.hstl_id
                                                          join l in db.tbLops on hstl.lop_id equals l.lop_id
                                                          join gvtl in db.tbGiaoVienTrongLops on l.lop_id equals gvtl.lop_id
                                                          where gvtl.taikhoan_id == u.username_id && ls.namhoc_id == 11 && gvtl.namhoc_id == 11
                                                          && ls.phuhuynhdandothuoc_ngaydangki.Value.Month == Convert.ToInt16(ddlThang.SelectedValue)
                                                          select ls).Sum(x => x.phuhuynhdandothuoc_diemtichluy),
                                       };

            var getDiemTaoBaiViet = from u in db.admin_Users
                                    where u.coso_id == CoSo && u.username_active == true
                           && u.groupuser_id == 3
                                    select new
                                    {
                                        u.username_id,
                                        u.username_fullname,
                                        diemtichluy = (from ls in db.tbVietNhatKids_AlbumImages
                                                       join gvtl in db.tbGiaoVienTrongLops on ls.gvtl_id equals gvtl.gvtl_id
                                                       where gvtl.taikhoan_id == u.username_id && ls.namhoc_id == 11 && gvtl.namhoc_id == 11
                                                       && ls.albumimage_datecreate.Value.Month == Convert.ToInt16(ddlThang.SelectedValue) && ls.albumimage_tinhtrang == true
                                                       select ls).Sum(x => x.albumImage_diemtichluy),

                                    };
            var getDiemXacNhanXinNghi = from u in db.admin_Users
                                        where u.coso_id == CoSo && u.username_active == true
                           && u.groupuser_id == 3
                                        select new
                                        {
                                            u.username_id,
                                            u.username_fullname,
                                            diemtichluy = (from ls in db.tbVietNhatKids_PhuHuynhXinNghis
                                                           join hstl in db.tbHocSinhTrongLops on ls.hstl_id equals hstl.hstl_id
                                                           join l in db.tbLops on hstl.lop_id equals l.lop_id
                                                           join gvtl in db.tbGiaoVienTrongLops on l.lop_id equals gvtl.lop_id
                                                           where gvtl.taikhoan_id == u.username_id && ls.namhoc_id == 11 && gvtl.namhoc_id == 11
                                                           && ls.phuhuynhxinnghi_ngaydangki.Value.Month == Convert.ToInt16(ddlThang.SelectedValue)
                                                           select ls).Sum(x => x.phuhuynhxinnghi_diemtichluy),
                                        };
            var getThemThongBaoLop = from u in db.admin_Users
                                     where u.coso_id == CoSo && u.username_active == true
                          && u.groupuser_id == 3
                                     select new
                                     {
                                         u.username_id,
                                         u.username_fullname,
                                         diemtichluy = (from ls in db.tbVietNhatKids_ThongBaoLops
                                                        join lop in db.tbLops on ls.lop_id equals lop.lop_id
                                                        join gvtl in db.tbGiaoVienTrongLops on ls.lop_id equals gvtl.lop_id
                                                        where gvtl.taikhoan_id == u.username_id && ls.namhoc_id == 11 && gvtl.namhoc_id == 11
                                                        && ls.thongbaoLop_datecreate.Value.Month == Convert.ToInt16(ddlThang.SelectedValue)
                                                        && ls.username_id == u.username_id
                                                        select ls).Sum(x => x.thongbaolop_diemtichluy),
                                     };
            var getThemThongBaoTruong = from u in db.admin_Users
                                        where u.coso_id == CoSo && u.username_active == true
                         && u.groupuser_id == 3
                                        select new
                                        {
                                            u.username_id,
                                            u.username_fullname,
                                            diemtichluy = (from ls in db.tbVietNhatKids_ThongBaoTruongs
                                                           where ls.username_id == u.username_id && ls.namhoc_id == 11
                                                           && ls.thongbaotruong_datecreate.Value.Month == Convert.ToInt16(ddlThang.SelectedValue)
                                                           select ls).Sum(x => x.thongbaotruong_diemtichluy),
                                        };
            var getDuyetThongBaoLop = from u in db.admin_Users
                                      where u.coso_id == CoSo && u.username_active == true
                            && u.groupuser_id == 3
                                      select new
                                      {
                                          u.username_id,
                                          u.username_fullname,
                                          diemtichluy = (from ls in db.tbLichSuDuyet_BanGiamHieus
                                                         where ls.username_id == u.username_id && ls.namhoc_id == 11
                                                         && ls.lichsuduyet_ngayduyet.Value.Month == Convert.ToInt16(ddlThang.SelectedValue)
                                                         select ls).Sum(x => x.lichsuduyet_diemtichluy),
                                      };

            var getXacNhanNgoaiKhoa = from u in db.admin_Users
                                      where u.coso_id == CoSo && u.username_active == true
                         && u.groupuser_id == 3
                                      select new
                                      {
                                          u.username_id,
                                          u.username_fullname,
                                          diemtichluy = (from ls in db.tbVietNhatKids_DangKyNgoaiKhoas
                                                         join hstl in db.tbHocSinhTrongLops on ls.hstl_id equals hstl.hstl_id
                                                         join l in db.tbLops on hstl.lop_id equals l.lop_id
                                                         join gvtl in db.tbGiaoVienTrongLops on l.lop_id equals gvtl.lop_id
                                                         where gvtl.taikhoan_id == u.username_id && ls.namhoc_id == 11 && gvtl.namhoc_id == 11
                                                         && ls.dangkyngoaikhoa_datecreate.Value.Month == Convert.ToInt16(ddlThang.SelectedValue)
                                                         select ls).Sum(x => x.dangkyngoaikhoa_diemtichluy),
                                      };

            var getTaoLichBaoGiang = from u in db.admin_Users
                                     where u.coso_id == CoSo && u.username_active == true
                           && u.groupuser_id == 3
                                     select new
                                     {
                                         u.username_id,
                                         u.username_fullname,
                                         diemtichluy = (from ls in db.tbLichBaoGiangs
                                                        where ls.username_id == u.username_id && ls.namhoc_id == 11
                                                        && ls.lichbaogiang_ngaytao.Value.Month == Convert.ToInt16(ddlThang.SelectedValue)
                                                        && ls.hidden == false
                                                        select ls).Sum(x => x.lichbaogiang_diemtichluy),

                                     };
            //load thống kê điểm tích lũy giáo viên
            var getTong = from u in db.admin_Users
                          where u.coso_id == CoSo && u.username_active == true
                          && u.groupuser_id == 3
                          select new
                          {
                              u.username_id,
                              u.username_fullname,
                              diemtichluy = getDiemDanhHangNgay.Where(hn => hn.username_id == u.username_id).Select(x => x.diemtichluy ?? 0).Sum()
                              + getDiemThuocPhuHuynh.Where(dt => dt.username_id == u.username_id).Select(x => x.diemtichluy ?? 0).Sum()
                              + getThemThongBaoLop.Where(tbl => tbl.username_id == u.username_id).Select(x => x.diemtichluy ?? 0).Sum()
                              + getDiemTaoBaiViet.Where(tbv => tbv.username_id == u.username_id).Select(x => x.diemtichluy ?? 0).Sum()
                              + getDiemXacNhanXinNghi.Where(xn => xn.username_id == u.username_id).Select(x => x.diemtichluy ?? 0).Sum()
                              + getThemThongBaoTruong.Where(tbt => tbt.username_id == u.username_id).Select(x => x.diemtichluy ?? 0).Sum()
                              + getDuyetThongBaoLop.Where(dtb => dtb.username_id == u.username_id).Select(x => x.diemtichluy ?? 0).Sum()
                              + getTaoLichBaoGiang.Where(tbg => tbg.username_id == u.username_id).Select(x => x.diemtichluy ?? 0).Sum()
                              //   + getTaoAlbumCaNhan.Where(acn => acn.username_id == u.username_id).Select(x => x.diemtichluy ?? 0).Sum()
                              + getXacNhanNgoaiKhoa.Where(nk => nk.username_id == u.username_id).Select(x => x.diemtichluy ?? 0).Sum(),
                          };
            rpTongDiemTichLuyGiaoVien.DataSource = getTong.OrderByDescending(x => x.diemtichluy);
            rpTongDiemTichLuyGiaoVien.DataBind();
            rpGiaoVienNhaXetThuongXuyen.DataSource = getTong;
            rpGiaoVienNhaXetThuongXuyen.DataBind();
        }
    }
}