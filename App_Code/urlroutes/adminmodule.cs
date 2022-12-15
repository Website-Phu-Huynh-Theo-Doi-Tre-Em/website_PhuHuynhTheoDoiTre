using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for adminmodule
/// </summary>
public class adminmodule
{
    public adminmodule()
    {
        //
        // TODO: Add constructor logic here 
        //
    }

    public List<string> UrlRoutes()
    {
        List<string> list = new List<string>();
        //Ứng dụng đánh giá nhận xét giáo viên và nhân viên
        list.Add("modulequanlynoidung|admin-quan-ly-noi-dung|~/admin_page/module_function/module_DanhGiaNhanXetGiaoVienVaNhanVien/module_QuanLyNoiDung.aspx");
        list.Add("modulequanlylichsunoidung|admin-quan-ly-lich-su-noi-dung|~/admin_page/module_function/module_DanhGiaNhanXetGiaoVienVaNhanVien/module_QuanLyLichSuNoiDung.aspx");
        list.Add("modulequanlynoidungbophan|admin-quan-ly-noi-dung-bo-phan|~/admin_page/module_function/module_DanhGiaNhanXetGiaoVienVaNhanVien/module_QuanLyNoiDungBoPhan.aspx");
        list.Add("modulequanlybaivietnoidung1|admin-noi-dung-bai-viet-tieu-chuan-1|~/admin_page/module_function/module_DanhGiaNhanXetGiaoVienVaNhanVien/module_BaiVietNoiDungTieuChuan1.aspx");
        list.Add("modulequanlybaivietnoidung2|admin-noi-dung-bai-viet-tieu-chuan-2|~/admin_page/module_function/module_DanhGiaNhanXetGiaoVienVaNhanVien/module_BaiVietNoiDungTieuChuan2.aspx");
        list.Add("modulequanlybaivietnoidung3|admin-noi-dung-bai-viet-tieu-chuan-3|~/admin_page/module_function/module_DanhGiaNhanXetGiaoVienVaNhanVien/module_BaiVietNoiDungTieuChuan3.aspx");
        list.Add("modulequanlybaivietnoidung4|admin-noi-dung-bai-viet-tieu-chuan-4|~/admin_page/module_function/module_DanhGiaNhanXetGiaoVienVaNhanVien/module_BaiVietNoiDungTieuChuan4.aspx");
        list.Add("modulequanlybaivietnoidung5|admin-noi-dung-bai-viet-tieu-chuan-5|~/admin_page/module_function/module_DanhGiaNhanXetGiaoVienVaNhanVien/module_BaiVietNoiDungTieuChuan5.aspx");
        list.Add("modulequanlythongbao|admin-thong-bao|~/admin_page/module_function/module_DanhGiaNhanXetGiaoVienVaNhanVien/module_ThongBao.aspx");
        list.Add("modulexemdanhgiagiaovien|admin-xem-danh-gia|~/admin_page/module_function/module_DanhGiaNhanXetGiaoVienVaNhanVien/module_XemQuanLyNoiDung.aspx");
        list.Add("modulexembaivietgiaovientutruongbophan|admin-xem-bai-viet-cua-giao-vien-tu-truong-bo-phan-{id}|~/admin_page/module_function/module_DanhGiaNhanXetGiaoVienVaNhanVien/module_XemBaiVietCuaGiaoVienTuTruongBoPhan.aspx");
        list.Add("modulexembaivietgiaovien|admin-xem-bai-viet-tu-giao-vien-{id}|~/admin_page/module_function/module_DanhGiaNhanXetGiaoVienVaNhanVien/module_XemBaiVietTuGiaoVien.aspx");
        list.Add("modulehuongdandanhgia|admin-file-huong-dan-danh-gia-{id}|~/admin_page/module_function/module_DanhGiaNhanXetGiaoVienVaNhanVien/module_filehuongdandanhgia.aspx");
        //list.Add("moduleviduhuongdandanhgia|admin-vi-du-huong-dan-danh-gia|~/admin_page/module_function/module_DanhGiaNhanXetGiaoVienVaNhanVien/module_filehuongdandanhgia.aspx");

        // Ứng dụng phòng học thông minh
        list.Add("modulequanlyphongthongminh|admin-phong-hoc-thong-minh|~/admin_page/module_function/module_PhongHocThongMinh/module_QuanLyDiaDiemBookPhong.aspx");
        list.Add("modulecheckinphongthongminh|admin-checkin-phong-hoc-thong-minh|~/admin_page/module_function/module_PhongHocThongMinh/module_CheckinPhongThongMinh.aspx");
        list.Add("modulethongkephongthongminh|admin-thong-ke-phong-hoc-thong-minh|~/admin_page/module_function/module_PhongHocThongMinh/module_ThongTinPhong.aspx");
        list.Add("moduleDanhSachPhongDaBook|admin-danh-sach-phong-da-book|~/admin_page/module_function/module_PhongHocThongMinh/module_DanhSachPhongDaBook.aspx");

        // Ứng dụng quản lý công văn (module_QuanLyDeadline)
        // 1 của văn thư
        list.Add("modulecongvanchuyentiep|admin-chuyen-tiep-cong-van|~/admin_page/module_function/module_QuanLyDeadline/module_CongVan/module_ChuyenTiepCongVan.aspx");
        list.Add("modulecongvandithuthu|admin-cong-van-di-van-thu|~/admin_page/module_function/module_QuanLyDeadline/module_CongVan/module_CongVanDiThuThu.aspx");
        list.Add("modulequanlychuyencongvantoicacbophan|admin-chuyen-cong-van-toi-cac-bo-phan-{id}|~/admin_page/module_function/module_QuanLyDeadline/module_CongVan/module_NoiDungChuyenCongVanToiCacBoPhan.aspx");
        // 2 của Thầy Hiệu Trưởng
        list.Add("modulequanlycongvanchuyentiep|admin-quan-ly-cong-van|~/admin_page/module_function/module_QuanLyDeadline/module_CongVan/module_QuanLyCongVanChuyenTiep.aspx");
        list.Add("modulequanlyduyetcongvan|admin-duyet-cong-van-noi-bo-van-thu|~/admin_page/module_function/module_QuanLyDeadline/module_CongVan/module_QuanLyDuyetCongVan.aspx");
        list.Add("modulequanlynoidungcongvanchuyentiep|admin-noi-dung-cong-van-chuyen-tiep-{id}|~/admin_page/module_function/module_QuanLyDeadline/module_CongVan/module_NoiDungCongvanChuyenDen_Vesrion2.aspx");
        list.Add("modulequanlynoidungduyetcongvannoibo|admin-duyet-noi-dung-cong-van-noi-bo-{id}|~/admin_page/module_function/module_QuanLyDeadline/module_CongVan/module_DuyetNoiDungCongVanNoiBo.aspx");
        // 3 Các nhân viên và giáo viên nhận công văn
        list.Add("modulecongvanden|admin-cong-van-den|~/admin_page/module_function/module_QuanLyDeadline/module_CongVan/module_CongVanDen.aspx");
        list.Add("modulenoidungcongvanden|admin-noi-dung-cong-van-den-{id}|~/admin_page/module_function/module_QuanLyDeadline/module_CongVan/module_NoiDungCongVanDen.aspx");

        list.Add("modulenhapquanlydeadline|admin-nhap-quan-ly-deadline-{id}|~/admin_page/module_function/module_QuanLyDeadline/module_QuanLyCongViec/module_NoiDungChiTiet.aspx");
        list.Add("modulequanlydeadline|admin-quan-ly-deadline|~/admin_page/module_function/module_QuanLyDeadline/module_QuanLyCongViec/module_QuanLyDeadline.aspx");
        list.Add("modulequanlydeadlinecanhan|admin-quan-ly-cong-viec-ca-nhan|~/admin_page/module_function/module_QuanLyDeadline/module_QuanLyCongViec/module_QuanLyDeadlineCaNhan.aspx");
        list.Add("modulegiaoviec|admin-giao-viec|~/admin_page/module_function/module_QuanLyDeadline/module_QuanLyCongViec/module_GiaoViec.aspx");



        list.Add("modulecongvandi|admin-cong-van-di|~/admin_page/module_function/module_QuanLyDeadline/module_CongVanDi.aspx");
        list.Add("moduledachuyencongvan|admin-da-chuyen-cong-van|~/admin_page/module_function/module_QuanLyDeadline/module_DaChuyenCongVan.aspx");


        // Quan ly website
        list.Add("moduleslide|admin-slide|~/admin_page/module_function/module_WebSite/module_Slide.aspx");
        list.Add("modulenews|admin-news|~/admin_page/module_function/module_WebSite/module_News.aspx");
        list.Add("modulenewscate|admin-newscate|~/admin_page/module_function/module_WebSite/module_NewsCate.aspx");
        list.Add("moduleuc|admin-uc|~/admin_page/module_function/module_WebSite/module_UserControl.aspx");
        list.Add("moduleintroduce|admin-introduce|~/admin_page/module_function/module_WebSite/module_introduce.aspx");
        list.Add("modulelienhe|admin-lien-he|~/admin_page/module_function/module_WebSite/module_LienHe.aspx");
        list.Add("modulecontent|admin-content|~/admin_page/module_function/module_WebSite/module_Content.aspx");
        list.Add("moduleintroducemenu|admin-introduce-menu|~/admin_page/module_function/module_WebSite/module_IntroduceMenu.aspx");
        //Quản lý điểm
        list.Add("modulenhapdiem|admin-nhap-diem|~/admin_page/module_function/module_Diem/module_NhapDiemHocSinh.aspx");
        list.Add("modulethstl|admin-tao-hoc-sinh-trong-lop|~/admin_page/module_function/module_Diem/module_TaoHocSinhTrongLop.aspx");
        list.Add("modulemh|admin-mon-hoc|~/admin_page/module_function/module_Diem/module_MonHoc.aspx");
        // thư viện ảnh
        list.Add("modulethuvienanh|admin-thu-vien-anh|~/admin_page/module_function/module_WebSite/module_ThuVienAnh.aspx");
        list.Add("modulethemanh|admin-them-anh|~/admin_page/module_function/module_WebSite/module_AddImage.aspx");
        // Thư viện sách
        list.Add("modulenhapsach|admin-nhap-sach|~/admin_page/module_function/module_ThuVien/module_NhapHang.aspx");
        list.Add("modulethuviensachthem|admin-them-sach|~/admin_page/module_function/module_ThuVien/module_NhapHangInsert.aspx");
        list.Add("modulethuviencapnhat|admin-nhap-sach-{id}|~/admin_page/module_function/module_ThuVien/module_NhapHangUpdate.aspx");
        list.Add("modulethongketusach|admin-thong-ke-tu-sach|~/admin_page/module_function/module_ThuVien/module_KhoSach.aspx");
        list.Add("modulequanlytusach|admin-quan-ly-tu-sach|~/admin_page/module_function/module_ThuVien/module_TuSach.aspx");
        list.Add("modulequanlymuonsach|admin-quan-ly-muon-sach|~/admin_page/module_function/module_ThuVien/module_DanhSachMuonSach.aspx");
        list.Add("modulemuonsach|admin-muon-sach|~/admin_page/module_function/module_ThuVien/module_DatHang.aspx");
        list.Add("modulemuonsachupdate|admin-muon-sach-{id}|~/admin_page/module_function/module_ThuVien/module_MuonSachUpdate.aspx");
        list.Add("moduletrasach|admin-tra-sach-{id}|~/admin_page/module_function/module_ThuVien/module_TraSach.aspx");
        list.Add("moduleduyetdonmuonsach|admin-duyet-don-muon-sach|~/admin_page/module_function/module_ThuVien/module_MuonSachChoDuyet.aspx");
        list.Add("modulethongketonkho|admin-thu-vien-ton-kho|~/admin_page/module_function/module_ThuVien/module_ThongKeTonKho.aspx");
        list.Add("modulethuvienphotogiay|admin-pho-to|~/admin_page/module_function/module_ThuVien/module_PhoToGiay.aspx");
        list.Add("modulethuvienThongkephotogiay|admin-pho-to-thong-ke|~/admin_page/module_function/module_ThuVien/module_PhoToGiay_ThongKe.aspx");
        // Thủ kho hàng tồn
        list.Add("modulehangton|admin-hang-ton|~/admin_page/module_function/module_ThuKho/module_ThuKho_TonKho.aspx");
        //Thủ kho nhập hàng
        list.Add("modulenhaphang|admin-nhap-hang|~/admin_page/module_function/module_ThuKho/module_ThuKho_NhapHang.aspx");
        list.Add("modulethemhang|admin-them-hang|~/admin_page/module_function/module_ThuKho/module_ThuKho_NhapHangInsert.aspx");
        list.Add("modulecapnhathang|admin-nhap-hang-{id}|~/admin_page/module_function/module_ThuKho/module_ThuKho_NhapHangUpdate.aspx");
        //Thủ kho ban hàng
        list.Add("modulequanlybanhang|admin-quan-ly-ban-hang|~/admin_page/module_function/module_ThuKho/module_ThuKho_BanHang.aspx");
        list.Add("modulebanhang|admin-ban-hang|~/admin_page/module_function/module_ThuKho/module_ThuKho_BanHangInsert.aspx");
        list.Add("modulecapnhatbanhang|admin-ban-hang-chi-tiet-{id}|~/admin_page/module_function/module_ThuKho/module_ThuKho_BanHangUpdate.aspx");
        // Quản lý lớp
        list.Add("modulebophan|admin-bo-phan-giao-vien|~/admin_page/module_function/module_HocTap/module_QuanLyBoPhan.aspx");
        list.Add("modulegiaobaitap|admin-giao-bai-tap|~/admin_page/module_function/module_HocTap/module_GiaoBaiTap.aspx");
        list.Add("moduletrabaitap|admin-tra-bai-tap|~/admin_page/module_function/module_HocTap/module_TraBaiTap.aspx");
        //list.Add("modulequanlylopgiaovien|admin-danh-sach-hoc-sinh-cua-giao-vien|~/admin_page/module_function/module_HocTap/module_QuanLyLop_GiaoVien.aspx");
        list.Add("modulequanlyTongHocSinh|admin-danh-sach-tong-hoc-sinh|~/admin_page/module_function/module_HocTap/module_TongHocSinhCuaTruong.aspx");
        list.Add("modulequanlybaitap|admin-quan-ly-bai-tap|~/admin_page/module_function/module_HocTap/module_QuanLyLop.aspx");
        list.Add("modulequanlyketquahocsinh|admin-quan-ly-ket-qua-hoc-tap|~/admin_page/module_function/module_HocTap/module_QuanLyHocTapHocSinh.aspx");
        list.Add("modulenhanxetcuoituan|admin-nhan-xet-cuoi-tuan|~/admin_page/module_function/module_OMT/omt_GiaoVien/admin_omt_DanhGiaCuoiTuan.aspx");
        list.Add("modulethongkenhanxetcuoituan|admin-thong-ke-nhan-xet-cuoi-tuan|~/admin_page/module_function/module_OMT/omt_GiaoVien/admin_omt_ThongKeDanhGiaCuoiTuan.aspx");
        // chưa làm
        list.Add("modulethoikhoabieugiaovien|admin-thoi-khoa-bieu-giao-vien|~/admin_page/module_function/module_OMT/omt_GiaoVien/admin_Thoi_Khoa_Bieu_Giao_vien.aspx");
        // Danh sách đăng ký học sinh
        list.Add("moduledangkyhocsinh|admin-danh-sach-dang-ky-hoc-sinh|~/admin_page/module_function/module_DangKyHocSinh/module_ListHocSinhDangKy.aspx");
        list.Add("moduledangkyhocsinhtuyensinh|admin-dang-ky-hoc-sinh-tuyen-sinh|~/admin_page/module_function/module_DangKyHocSinh/form_DangKyHocSinhNhapHoc.aspx");
        list.Add("moduledangkyhocsinhphidichvu|admin-danh-sach-dang-ky-phi-dich-vu|~/admin_page/module_function/module_DangKyHocSinh/module_PhiDichVu.aspx");
        // Danh sách lịch 
        // lịch báo giảng khối 1,2,3,4,5
        list.Add("modulelichbaogiang|admin-lich-bao-giang-khoi-tieu-hoc|~/admin_page/module_function/module_LichCongTac/module_LichBaoGiangTieuHoc.aspx");
        list.Add("modulexemlichbaogiangtieuhoc|admin-xem-lich-bao-giang-khoi-{id}|~/admin_page/module_function/module_LichCongTac/module_XemLichBaoGiangTieuHoc.aspx");
        list.Add("modulethemlichbaogiangkhoitieuhoc|admin-them-lich-bao-giang-khoi-tieu-hoc-{id}|~/admin_page/module_function/module_LichCongTac/module_ThemLichBaoGiang.aspx");
        list.Add("modulethemlichbaogiangkhoitieuhocformart|admin-them-lich-bao-giang-khoi-tieu-hoc/formart-{id}|~/admin_page/module_function/module_LichCongTac/module_ThemLichBaoGiang_Formart.aspx");
        // Lịch báo giảng bộ môn
        list.Add("modulelichbaogiangbomon|admin-lich-bao-giang-bo-mon|~/admin_page/module_function/module_LichCongTac/module_LichBaoGiangBoMon.aspx");
        list.Add("modulethemlichbaogiangbomon|admin-them-lich-bao-giang-bo-mon-{id}|~/admin_page/module_function/module_LichCongTac/module_ThemLichBaoGiangBoMon.aspx");
        list.Add("modulexemlichbaogiangbomontunhien|admin-xem-lich-bao-giang-bo-mon-tu-nhien|~/admin_page/module_function/module_LichCongTac/module_XemLichBaoGiangTuNhien.aspx");
        list.Add("modulexemlichbaogiangbomonxahoi|admin-xem-lich-bao-giang-giao-vien|~/admin_page/module_function/module_LichCongTac/module_XemLichBaoGiangXaHoi.aspx");
        list.Add("modulexemlichbaogiangbomonngoaingu|admin-xem-lich-bao-giang-bo-mon-ngoai-ngu|~/admin_page/module_function/module_LichCongTac/module_XemLichBaoGiangNgoaiNgu.aspx");
        list.Add("modulexemlichbaogiangbomonTheDuc|admin-xem-lich-bao-giang-bo-mon-the-duc|~/admin_page/module_function/module_LichCongTac/module_XemLichBaoGiangtheDuc.aspx");
        list.Add("modulexemlichbaogiangbomonamnhac|admin-xem-lich-bao-giang-bo-mon-am-nhac-my-thuat|~/admin_page/module_function/module_LichCongTac/module_XemLichBaoGiangAmNhac.aspx");
        list.Add("modulexemlichbaogiangbomon|admin-xem-lich-bao-giang-bo-mon-{id}|~/admin_page/module_function/module_LichCongTac/module_XemLichBaoGiangBoMon.aspx");
        list.Add("modulethemlichbaogiangbomonformart|admin-them-lich-bao-giang-bo-mon/formart-{id}|~/admin_page/module_function/module_LichCongTac/module_ThemLichBaoGiangBoMon_Formart.aspx");
        list.Add("moduledanhsachlichbaogiangcaccoso|admin-danh-sach-lich-bao-giang-cac-co-so|~/admin_page/module_function/module_LichCongTac/module_DanhSachLichBaoGiangCacCoSo.aspx");

        //DUYỆT LỊCH BÁO GIẢNG
        list.Add("moduleduyetlichbaogiangbomon|admin-duyet-lich-bao-giang-bo-mon|~/admin_page/module_function/module_LichCongTac/module_DuyetLichBaoGiangBoMon.aspx");
        //Thời khóa biểu chính khóa - Lịch báo giảng tổng - Thời khóa biểu tiết 8
        list.Add("modulethoikhoabieuchinhkhoa|admin-thoi-khoa-bieu-chinh-khoa|~/admin_page/module_function/module_ThoiKhoaBieu/module_TKB_ChinhKhoa/admin_ThoiKhoaBieu_ChinhKhoa.aspx");
        list.Add("modulelichbaogiangtong|admin-lich-bao-giang-tong|~/admin_page/module_function/module_LichCongTac/module_XemLichBaoGiangTong.aspx");
        list.Add("modulelichbaogiangtongtheolop|admin-lich-bao-giang-tong-theo-lop|~/admin_page/module_function/module_LichCongTac/module_XemLichTongTheoLop.aspx");
        list.Add("modulexemlichbaogiantheocoso|admin-lich-bao-giang-tong-theo-co-so-{cosoid}|~/admin_page/module_function/module_LichCongTac/module_XemLichBaoGiangTheoCoSo.aspx");
        list.Add("modulexemlichbaogiangtongcaccoso|admin-xem-lich-bao-giang-tong|~/admin_page/module_function/module_LichCongTac/module_XemLichBaoGiangTongCacCoSo.aspx");

        // list.Add("modulelichbaogiangtongtest|admin-lich-bao-giang-tong-test|~/admin_page/module_function/module_LichCongTac/module_XemLichTongNamTest.aspx");
        // Lịch công tác
        list.Add("modulelichcongtacthang|admin-danh-sach-lich-cong-tac-thang|~/admin_page/module_function/module_LichCongTac/module_DanhSachLichCongTacThang.aspx");
        list.Add("modulexemlichcongtacthang|admin-xem-lich-cong-tac-thang|~/admin_page/module_function/module_LichCongTac/module_XemDanhSachLichCongTacThang.aspx");
        list.Add("modulelichcongtachangtuan|admin-lich-cong-tac-hang-tuan|~/admin_page/module_function/module_LichCongTac/module_DanhSachLichCongTac.aspx");
        list.Add("modulelichcongtachangthang|admin-lich-cong-tac-hang-thang|~/admin_page/module_function/module_LichCongTac/module_DanhSachLichCongTacThang.aspx");
        list.Add("modulelichcongtacchitiethangtuan|admin-lich-cong-tac-chi-tiet-hang-tuan-{id}|~/admin_page/module_function/module_LichCongTac/module_DanhSachLichCongTacChiTiet.aspx");
        list.Add("modulethemlichcongtacthang|admin-them-lich-cong-tac-thang-{id}|~/admin_page/module_function/module_LichCongTac/module_DanhSachLichCongTacChiTietThang.aspx");
        list.Add("modulexemlichcongtachangtuan|admin-xem-lich-cong-tac-hang-tuan|~/admin_page/module_function/module_LichCongTac/module_XemDanhSachLichCongTacChiTiet.aspx");
        list.Add("modulekehoachdayhoc|admin-ke-hoach-day-hoc-giao-vien|~/admin_page/module_function/module_LichCongTac/module_keHoachDayHocGiaoVien_version2.aspx");
        list.Add("modulexemkehoachdayhoc|admin-xem-ke-hoach-day-hoc-giao-vien|~/admin_page/module_function/module_LichCongTac/module_keHoachDayHocGiaoVien_Xem_Version2.aspx");
        list.Add("modulexemdanhsachdugio|admin-xem-danh-sach-du-gio|~/admin_page/module_function/module_LichCongTac/module_XemDanhSachDuGio.aspx");
        list.Add("modulexemdangkydanhsachdugio|admin-dang-ky-danh-sach-du-gio|~/admin_page/module_function/module_LichCongTac/module_XemDanhSachDangKyDuGio.aspx");
        list.Add("moduledanhsachkehoachchunhiem|admin-danh-sach-ke-hoach-chu-nhiem|~/admin_page/module_function/module_LichCongTac/module_DanhSachKeHoachChuNhiem.aspx");
        list.Add("modulethemkehoachchunhiemthang|admin-them-ke-hoach-chu-nhiem-thang-{id}|~/admin_page/module_function/module_LichCongTac/module_DanhSachKeHoachChuNhiemThang.aspx");
        //xem lịch công tác từng cơ sở
        list.Add("modulexemlichcongtachangtuantungcoso|admin-xem-lich-cong-tac-hang-tuan-co-so-{cosoid}|~/admin_page/module_function/module_LichCongTac/module_XemLichCongTacHangTuanTheoCoSo.aspx");
        list.Add("modulexemlichcongtachangthangtungcoso|admin-xem-lich-cong-tac-thang-co-so-{cosoid}|~/admin_page/module_function/module_LichCongTac/module_XemLichCongTacHangThangTheoCoSo.aspx");
        // Dự giờ 
        list.Add("modulexemdugio|admin-xem-du-gio|~/admin_page/module_function/module_LichCongTac/module_DuGio/module_XemDuGio.aspx");
        list.Add("moduledangkydugio|admin-dang-ky-du-gio|~/admin_page/module_function/module_LichCongTac/module_DuGio/module_DangKyDuGio.aspx");
        //duyệt đăng ký dự giờ
        list.Add("moduleduyetdangkydugio|admin-duyet-dang-ky-du-gio|~/admin_page/module_function/module_LichCongTac/module_DuGio/module_DuyetDangKyDuGio.aspx");
        //kế hoạch giảng dạy
        list.Add("moduledanhsachphienchechuyenmon|admin-danh-sach-phien-che-chuyen-mon|~/admin_page/module_function/module_LichCongTac/module_KeHoachGiangDay/module_DanhSachPhienCheChuyenMon.aspx");
        list.Add("modulethemphienchechuyenmon|admin-them-phien-che-chuyen-mon-{id}|~/admin_page/module_function/module_LichCongTac/module_KeHoachGiangDay/module_ThemPhienCheChuyenMon.aspx");
        list.Add("modulexemphienchechuyenmon|admin-xem-phien-che-chuyen-mon|~/admin_page/module_function/module_LichCongTac/module_KeHoachGiangDay/module_XemPhienCheChuyenMon.aspx");
        list.Add("modulexemphienchechuyenmontong|admin-xem-phien-che-chuyen-mon-tong|~/admin_page/module_function/module_LichCongTac/module_KeHoachGiangDay/module_XemPhienCheChuyenMonTong.aspx");
        list.Add("modulexemphienchechuyenmoncuoicung|admin-xem-phien-che-chuyen-mon-final|~/admin_page/module_function/module_LichCongTac/module_KeHoachGiangDay/module_XemPhienCheChuyenMon_CuoiCung.aspx");
        list.Add("modulexemkehoachdayhocdaduyet|admin-xem-ke-hoach-day-hoc-da-duyet|~/admin_page/module_function/module_LichCongTac/module_KeHoachGiangDay/module_XemKeHoachDayHocDaDuyet.aspx");
        list.Add("moduleduyetkehoachdayhochieutruong|admin-duyet-ke-hoach-day-hoc|~/admin_page/module_function/module_LichCongTac/module_KeHoachGiangDay/module_DuyetKeHoachDayHoc_HieuTruong.aspx");
        //kế hoạch dạy học khối H + R
        list.Add("modulethemkehoachdayhoc|admin-them-ke-hoach-day-hoc-{id}|~/admin_page/module_function/module_LichCongTac/module_KeHoachGiangDay/KhoiNhaTre/module_TaoKeHoachDayHoc.aspx");

        //xem kế hoạch dạy học từng lớp
        list.Add("modulexemkehoachdayhoctunglophieupho|admin-hieu-pho-xem-ke-hoach-day-hoc-tung-lop|~/admin_page/module_function/module_LichCongTac/module_KeHoachGiangDay/module_XemKeHoachDayHoc_TungLop_HieuPho.aspx");
        list.Add("modulexemkehoachdayhoctunglophieutruong|admin-hieu-truong-xem-ke-hoach-day-hoc-tung-lop|~/admin_page/module_function/module_LichCongTac/module_KeHoachGiangDay/module_XemKeHoachDayHoc_TungLop_HieuTruong.aspx");
        list.Add("modulexemkehoachdayhoctungloptong|admin-xem-ke-hoach-day-hoc-tung-lop-tong|~/admin_page/module_function/module_LichCongTac/module_KeHoachGiangDay/module_XemKeHoachDayHoc_TungLop_Tong.aspx");


        //phiên chế năm học
        list.Add("modulephienchenamhoc|admin-phien-che-nam-hoc|~/admin_page/module_function/module_LichCongTac/module_KeHoachGiangDay/module_PhienCheNamHoc.aspx");
        list.Add("modulexemphienchenamhoc|admin-xem-phien-che-nam-hoc|~/admin_page/module_function/module_LichCongTac/module_KeHoachGiangDay/module_XemPhienCheNamHoc.aspx");
        list.Add("modulexemphienchenamhoctheocoso|admin-xem-phien-che-nam-hoc-co-so-{cosoid}|~/admin_page/module_function/module_LichCongTac/module_KeHoachGiangDay/module_XemPhienCheNamHocTheoCoSo.aspx");
        //
        //thống kê xem lịch công tác 
        list.Add("modulethongkexemlichcongtactuan|admin-thong-ke-xem-lich-cong-tac-hang-tuan|~/admin_page/module_function/module_LichCongTac/module_ThongKe/module_ThongKeXemLichCongTacTuan.aspx");
        list.Add("modulethongkexemlichcongtacthang|admin-thong-ke-xem-lich-cong-tac-hang-thang|~/admin_page/module_function/module_LichCongTac/module_ThongKe/module_ThongKeXemLichCongTacThang.aspx");
        list.Add("modulethongkexemlichcongtacthangtong|admin-thong-ke-xem-lich-cong-tac-hang-thang-tong|~/admin_page/module_function/module_LichCongTac/module_ThongKe/module_ThongKeXemLichCongTacThangTong.aspx");
        list.Add("modulethongkexemlichcongtactuantong|admin-thong-ke-xem-lich-cong-tac-hang-tuan-tong|~/admin_page/module_function/module_LichCongTac/module_ThongKe/module_ThongKeXemLichCongTacTuanTong.aspx");

        // Quản lý thiết bị nhà trường
        list.Add("modulenhomthietbi|admin-nhom-thiet-bi|~/admin_page/module_function/module_ThietBiNhaTruong/module_NhomThietBi.aspx");
        list.Add("modulethietbihuhong|admin-bao-thiet-bi-hu-hong|~/admin_page/module_function/module_ThietBiNhaTruong/module_ThietBi_HuHong.aspx");
        list.Add("modulethietbihuhongduyet|admin-xu-ly-thiet-bi-hu-hong|~/admin_page/module_function/module_ThietBiNhaTruong/module_ThietBi_HuHong_Duyet.aspx");
        list.Add("modulenhansuathietbihuhong|admin-nhan-xu-ly-thiet-bi-hu-hong|~/admin_page/module_function/module_ThietBiNhaTruong/module_Nhan_Sua_ThietBi_HuHong.aspx");
        list.Add("modulethongkethietbihuhong|admin-thong-ke-thiet-bi-hu-hong|~/admin_page/module_function/module_ThietBiNhaTruong/module_ThietBi_HuHong_ThongKe.aspx");
        // Report kế hoạch dạy học
        list.Add("modulebaocaokehoachdayhoc|bao-cao-ke-hoach-day-hoc|~/Report/frmKeHoachDayHoc.aspx");
        // Quản lý điểm danh
        list.Add("modulequanlynhapdiemdanh|admin-dang-ki-an-sang|~/admin_page/module_function/module_DiemDanh/module_Nhap_DanhSachHocSinhAnSang.aspx");
        //list.Add("modulequanlydiemdanhansang|admin-danh-sach-an-sang|~/admin_page/module_function/module_DiemDanh/module_DanhSachHocSinhAnSang.aspx");
        list.Add("modulequanlydiemdanhansang|admin-xac-nhan-dang-ky-an-sang|~/admin_page/module_function/module_DiemDanh/module_XacNhanHocSinhDangKyAnSang.aspx");
        list.Add("modulequanlythongkediemdanh|admin-thong-ke-diem-danh-lop-hoc|~/admin_page/module_function/module_DiemDanh/module_QuanLyLop_DiemDanh_Thongke.aspx");
        list.Add("modulequanlydiemdanhgiaovien|admin-diem-danh-hoc-sinh|~/admin_page/module_function/module_DiemDanh/module_QuanLyLop_DiemDanh_AnSang.aspx");
        list.Add("modulequanlydiemdanhhocsinhve|admin-diem-danh-hoc-sinh-ve|~/admin_page/module_function/module_DiemDanh/module_QuanLyLop_DiemDanh_Ve.aspx");
        list.Add("modulequanlydiemdanhhocsinhvemuon|admin-diem-danh-hoc-sinh-ve-muon|~/admin_page/module_function/module_DiemDanh/module_QuanLyLop_DiemDanh_VeMuon.aspx");
        list.Add("modulequanlylichsudiemdanh|admin-lich-su-diem-danh-lop-hoc|~/admin_page/module_function/module_DiemDanh/module_QuanLyLop_DiemDanh_LichSu.aspx");
        list.Add("modulequanlydiemdanhlophoc|admin-quan-ly-diem-danh-lai|~/admin_page/module_function/module_DiemDanh/module_QuanLyLop_DiemDanhLai.aspx");
        list.Add("modulequanlythongkeansang|admin-thong-ke-an-sang|~/admin_page/module_function/module_DiemDanh/module_QuanLyLop_DiemDanh_Thongke_AnSang.aspx");
        list.Add("modulequanlythongkediemdanhhocsinh|admin-thong-ke-diem-danh-vang-hoc|~/admin_page/module_function/module_DiemDanh/module_QuanLyLop_DiemDanh_Thongke_DiemDanh.aspx");
        list.Add("moduledanhsachhuydangkyansanguongsua|admin-danh-sach-huy-dang-ky-an-sang|~/admin_page/module_function/module_DiemDanh/module_DanhSachHocSinh_HuyDangKi_AnSang_UongSua.aspx");
        list.Add("modulehuydangkyansanguongsua|admin-huy-dang-ki-an-sang-uong-sua|~/admin_page/module_function/module_DiemDanh/module_Huy_DanhSachHocSinh_AnSang_UongSua.aspx");
        list.Add("modulethongkesoluongsuatan|admin-thong-ke-suat-an|~/admin_page/module_function/module_DiemDanh/module_ThongKeSuatAnHangNgay.aspx");

        // form điểm danh chưa dùng
        list.Add("modulequanlylichsuansang|admin-lich-su-danh-sach-an-sang|~/admin_page/module_function/module_DiemDanh/module_DanhSachHocSinhAnSang_QuanSinh_LichSu.aspx");
        list.Add("modulequanlyblockhocsinhansang|admin-khoa-hoc-sinh-an-sang|~/admin_page/module_function/module_DiemDanh/module_DanhSachHocSinhAnSang_Block.aspx");
        // thông kê từng lớp để báo lên bravo ngày 23 làm tiếp thông kê ăn trưa
        list.Add("modulequanlythongkeantrua|admin-thong-ke-an-trua|~/admin_page/module_function/module_DiemDanh/module_ThongKeTungLop.aspx");


        // Quản lý điểm danh học sinh của giáo viên
        list.Add("modulequanlydiemdanhtonghocsinh|admin-diem-danh-tong-hoc-sinh|~/admin_page/module_function/module_DiemDanh/module_QuanLyLop_DiemDanh_TongHocSinh_TrongLop.aspx");
        list.Add("modulequanlydanhsachhocsinhkhonghoconline|admin-danh-sach-hoc-sinh-khong-hoc-online|~/admin_page/module_function/module_DiemDanh/module_QuanLyLop_DiemDanh_TongHocSinh_TrongLop_Vang.aspx");

        // Thống kê điểm danh học online
        list.Add("modulequanlythongkehocsinhonline|admin-thong-ke-hoc-sinh-hoc-online|~/admin_page/module_function/module_DiemDanh/module_ThongKeHocOnline_TongTungLop.aspx");

        // đăng ký phí dịch vụ
        list.Add("modulequanlydanhsachphidichvu|admin-danh-sach-phi-dich-vu-tong|~/admin_page/module_function/module_DangKyHocSinh/module_PhiDichVu_Tong.aspx");
        list.Add("modulereportquanlydanhsachphidichvu|danh-sach-phi-dich-vu-tai-truong|~/Report/PhiDichVu/frmPhiDichVuTruong.aspx");

        // Quản lý nhân sự
        //Admin Profile

        list.Add("modulequanlygiaovienvietnhat|admin-quan-ly-giao-vien|~/admin_page/module_function/module_QuanLyNhanSu/admin_DanhSachHoSoGiaoVien.aspx");
        list.Add("modulequanlynhanvienvietnhat|admin-danh-sach-nhan-vien|~/admin_page/module_function/module_QuanLyNhanSu/admin_DanhSachHoSo.aspx");
        list.Add("modulequanlyhosothuviec|admin-ho-so-thu-viec|~/admin_page/module_function/module_QuanLyNhanSu/admin_DanhSachThuViec.aspx");
        list.Add("modulequanlyhopdonglaodong|admin-hop-dong-lao-dong|~/admin_page/module_function/module_QuanLyNhanSu/admin_HopDongLaoDong.aspx");

        // thông tin cá nhân
        list.Add("moduleprofile|admin-ho-so-thong-tin|~/admin_page/module_function/module_QuanLyNhanSu/admin_Profile.aspx");
        list.Add("modulechangepassword|admin-change-password|~/admin_page/module_access/admin_ChangePassword.aspx");
        list.Add("modulethoikhoabieutunggiaovien|admin-thoi-khoa-bieu|~/admin_page/module_function/module_OMT/omt_GiaoVien/admin_omt_NhapThoiKhoaBieuGiaoVien.aspx");

        // file văn bản mẫu
        list.Add("modulefileformmau|admin-form-mau|~/admin_page/module_function/module_FormMau/module_FormMau_Chung.aspx");
        list.Add("modulefileformmautieuhoc|admin-form-mau-khoi-tieu-hoc|~/admin_page/module_function/module_FormMau/module_FormMau_KhoiTieuHoc.aspx");
        list.Add("modulefileformmautrunghoc|admin-form-mau-khoi-trung-hoc|~/admin_page/module_function/module_FormMau/module_FormMau_KhoiTrungHoc.aspx");
        list.Add("moduletailieulienquan|admin-tai-lieu-lien-quan-cac-chuyen-de|~/admin_page/module_function/module_FormMau/module_FormMau_TaiLieuLienQuanCacChuyenDe.aspx");
        list.Add("moduledownloadfile|admin-down-load-file|~/admin_page/module_function/module_FormMau/module_DownloadFile.aspx");
        list.Add("modulefileformmaucoso1|admin-form-mau-co-so-1|~/admin_page/module_function/module_FormMau/module_FormMau_CoSo1.aspx");
        list.Add("modulefileformmaucoso2|admin-form-mau-co-so-2|~/admin_page/module_function/module_FormMau/module_FormMau_CoSo2.aspx");
        list.Add("modulefileformmaucoso3|admin-form-mau-co-so-3|~/admin_page/module_function/module_FormMau/module_FormMau_CoSo3.aspx");
        // Kho tư liệu
        list.Add("modulekhotulieuchung|kho-tu-lieu-chung|~/admin_page/module_function/module_KhoTuLieu/admin_KhoTuLieu_Chung.aspx");
        list.Add("modulekhotulieuchungchitiet|kho-tu-lieu-chung-{id}|~/admin_page/module_function/module_KhoTuLieu/admin_KhoTuLieu_Chung_ChiTiet.aspx");

        list.Add("modulekhotulieutieuhoc|kho-tu-lieu-tieu-hoc|~/admin_page/module_function/module_KhoTuLieu/admin_KhoTuLieu_TieuHoc.aspx");
        list.Add("modulekhotulieukhoitieuhocchitiet|kho-tu-lieu-khoi-tieu-hoc-{id}|~/admin_page/module_function/module_KhoTuLieu/admin_KhoTuLieu_KhoiTieuHoc_ChiTiet.aspx");
        list.Add("modulekhotulieutrunghoc|kho-tu-lieu-trung-hoc|~/admin_page/module_function/module_KhoTuLieu/admin_KhoTuLieu_TrungHoc.aspx");
        list.Add("modulekhotulieukhoitrunghocchitiet|kho-tu-lieu-khoi-trung-hoc-{id}|~/admin_page/module_function/module_KhoTuLieu/admin_KhoTuLieu_KhoiTrungHoc_ChiTiet.aspx");
        list.Add("moduletailieulienquancacchuyende|kho-tai-lieu-lien-quan-cac-chuyen-de|~/admin_page/module_function/module_KhoTuLieu/admin_KhoTuLieu_LienQuan_CacChuyenDe.aspx");
        list.Add("moduletailieulienquancacchuyendechitiet|kho-tai-lieu-lien-quan-cac-chuyen-de-{id}|~/admin_page/module_function/module_KhoTuLieu/admin_KhoTuLieu_LienQuan_CacChuyenDe_ChiTiet.aspx");
        list.Add("modulekhotulieuphothong|kho-tu-lieu-phong-thong|~/admin_page/module_function/module_KhoTuLieu/admin_KhoTuLieu_PhoThong.aspx");
        //kho tư liệu từng cơ sở
        list.Add("modulekhotulieutungcoso|kho-tu-lieu-co-so-{id}|~/admin_page/module_function/module_KhoTuLieu/admin_KhoTuLieuTungCoSo.aspx");
        list.Add("modulexemchitietkhotulieutungcoso|kho-tu-lieu-co-so-{id}/{file_id}|~/admin_page/module_function/module_KhoTuLieu/admin_KhoTuLieuTungCoSo_ChiTiet.aspx");
        // Thời khóa biểu
        list.Add("moduleThoiKhoaBieu|admin-thoi-khoa-bieu-tiet-8|~/admin_page/module_function/module_ThoiKhoaBieu/module_TKB_Tiet8/admin_ThoiKhoaBieu_Tiet8.aspx");
        // Hồm thư góp ý
        list.Add("modulehomthugopy|admin-hom-thu-gop-y|~/admin_page/module_function/module_QuanLyNhanSu/admin_HomThuGopY.aspx");
        list.Add("modulenoidunghomthugopy|admin-noi-dung-hom-thu-gop-y-{id}|~/admin_page/module_function/module_QuanLyNhanSu/admin_NoiDungHomThuGopY.aspx");

        // Thống kê
        list.Add("modulethongkegiaoviendugio|admin-thong-ke-giao-vien-du-gio|~/admin_page/module_function/module_LichCongTac/module_ThongKe/module_ThongKeGiaoVienDuGio.aspx");
        list.Add("modulethongkelichbaogiang|admin-thong-ke-lich-bao-giang|~/admin_page/module_function/module_LichCongTac/module_ThongKe/module_ThongKeLichBaoGiang.aspx");
        list.Add("modulethongkenhanxethangtuan|admin-thong-ke-nhan-xet-hoc-sinh-hang-tuan|~/admin_page/module_function/module_LichCongTac/module_ThongKe/module_ThongKeNhanXetHocSinhHangTuan.aspx");
        list.Add("modulethongkelichdayhoc|admin-thong-ke-ke-hoach-day-hoc|~/admin_page/module_function/module_LichCongTac/module_ThongKe/module_ThongKeLichDayHoc.aspx");

        // Quản lý cuộc họp
        list.Add("moduledangkycuochop|admin-dang-ky-cuoc-hop|~/admin_page/module_function/module_CuocHop/module_DangKyCuocHop.aspx");
        list.Add("moduleduyetcuochop|admin-duyet-cuoc-hop|~/admin_page/module_function/module_CuocHop/module_DuyetCuocHop.aspx");
        list.Add("modulethongkecuochop|admin-thong-ke-cuoc-hop|~/admin_page/module_function/module_CuocHop/module_ThongKeDinhKy.aspx");
        list.Add("modulebaocaocuochop|admin-bao-cao-cuoc-hop|~/admin_page/module_function/module_CuocHop/module_BaoCaoCuocHop.aspx");

        // Quản lý lớp của học sinh
        list.Add("modulehocsinhtronglop|admin-hoc-sinh-trong-lop|~/admin_page/module_function/module_QuanLyLopCuaHocSinh/module_HocSinhTrongLop.aspx");


        //module đăng ký tuyển sinh
        list.Add("moduledangkytuyensinh|danh-sach-dang-ky-tuyen-sinh|~/admin_page/module_function/module_DangKyTuyenSinh/module_DanhSachDangKyTuyenSinh.aspx");

        //module quan li hoc sinh
        list.Add("moduledanhsachhocsinhcuagiaovien|admin-danh-sach-hoc-sinh-cua-giao-vien|~/admin_page/module_function/module_HocSinh/module_DanhSachHocSinh.aspx");
        list.Add("modulethemhocsinh|them-hoc-sinh|~/admin_page/module_function/module_HocSinh/module_ThemHocSinh.aspx");
        list.Add("modulexemdanhsachhocsinhtronglop|admin-xem-danh-sach-hoc-sinh-trong-lop|~/admin_page/module_function/module_HocSinh/module_XemDanhSachHocSinhTrongLop.aspx");
        list.Add("modulechuyenhocsinhtronglop|xem-chuyen-hoc-sinh-trong-lop|~/admin_page/module_function/module_HocSinh/module_ChuyenHocSinhTrongLop.aspx");
        list.Add("modulechuyenhocsinhlelop|chuyen-hoc-sinh-len-lop|~/admin_page/module_function/module_HocSinh/module_ChuyenHocSinhLenLop.aspx");
        //module quan li giao vien
        list.Add("modulegiaovien|them-giao-vien|~/admin_page/module_function/module_GiaoVien/module_GiaoVien.aspx");
        list.Add("modulequanlygiaovientronglop|admin-quan-ly-giao-vien-trong-lop|~/admin_page/module_function/module_GiaoVien/module_ThemGiaoVienTrongLop.aspx");
        list.Add("moduledanhsachhocsinhtronglop|danh-sach-hoc-sinh-trong-lop|~/admin_page/module_function/module_GiaoVien/module_DanhSachHocSinhTrongLop.aspx");

        list.Add("adminxemgiaovientronglop|admin-xem-danh-sach-giao-vien-trong-lop|~/admin_page/module_function/module_GiaoVien/module_XemDanhSachGiaoVienTrongLop.aspx");
        //module quan li lop
        list.Add("modulelop|admin-quan-ly-lop|~/admin_page/module_function/module_Lop/module_ThemLop.aspx");
        list.Add("modulekhoilop|admin-quan-ly-khoi|~/admin_page/module_function/module_Lop/module_ThemKhoi.aspx");
        list.Add("modulenamhoc|admin-quan-ly-nam-hoc|~/admin_page/module_function/module_Lop/module_ThemNamHoc.aspx");
        list.Add("moduletuanhoc|admin-quan-ly-tuan-hoc|~/admin_page/module_function/module_Lop/module_ThemTuanHoc.aspx");
        list.Add("modulehocky|admin-quan-ly-hoc-ky|~/admin_page/module_function/module_Lop/module_ThemHocKy.aspx");
        list.Add("moduledandothuoctuphuhuynh|admin-dan-do-thuoc-tu-phu-huynh|~/admin_page/module_function/module_VietNhatKids/module_DanDoThuocTuPhuHuynh.aspx");

        //module quan li he thong
        list.Add("modulequanlyhethonglop|admin-quan-ly-he-thong-lop|~/admin_page/module_function/module_QuanLyHeThong/module_QuanLyHeThongLop.aspx");
        list.Add("modulequanlyhethongkhoi|admin-quan-ly-he-thong-khoi|~/admin_page/module_function/module_QuanLyHeThong/module_QuanLyHeThongKhoi.aspx");
        list.Add("modulequanlyhethongtaikhoan|admin-quan-ly-he-thong-tai-khoan|~/admin_page/module_function/module_QuanLyHeThong/module_QuanLyHeThongTaiKhoan.aspx");
        list.Add("modulequanlyhethonghocsinh|admin-quan-ly-hoc-sinh|~/admin_page/module_function/module_QuanLyHeThong/module_QuanLyHeThongHocSinh.aspx");
        list.Add("modulequanlyhethonghocsinhtronglop|admin-quan-ly-hoc-sinh-trong-lop|~/admin_page/module_function/module_HocSinh/module_ThemHocSinhTrongLop.aspx");
        //module album anh
        list.Add("modulealbumanh|album-anh|~/admin_page/module_function/module_AlbumAnh/module_AlbumAnh.aspx");
        //nhận xét thường xuyên
        list.Add("modulenhanxetthuongxuyen|admin-nhan-xet-suc-khoe-hang-thang|~/admin_page/module_function/module_HocSinh/module_GiaoVienNhanXetThuongXuyen.aspx");

        //module so lien lac dien tu
        list.Add("modulethemhocphi|them-hoc-phi|~/admin_page/module_function/module_SoLienLacDienTu/module_ThemHocPhi.aspx");
        list.Add("modulequantrithongbaotruong|thong-bao-truong|~/admin_page/module_function/module_VietNhatKids/module_ThongBaoTruong.aspx");
        list.Add("modulequantrithongbaolop|thong-bao-lop|~/admin_page/module_function/module_VietNhatKids/module_ThongBaoLop.aspx");
        list.Add("modulequantrithongbaolopduyet|thong-bao-lop-duyet|~/admin_page/module_function/module_VietNhatKids/module_ThongBaoLop_Duyet.aspx");
        list.Add("modulequantrixinnghiphuhuynh|admin-phu-huynh-xin-nghi|~/admin_page/module_function/module_VietNhatKids/module_PhuHuynhXinNghi.aspx");
        list.Add("modulequantrinhanxetthuongxuyen|admin-nhan-xet-thuong-xuyen|~/admin_page/module_function/module_VietNhatKids/module_NhanXetThuongXuyen.aspx");
        list.Add("modulequantrinhanxetbenangihomnay|admin-nhan-xet-be-an-hom-nay|~/admin_page/module_function/module_VietNhatKids/module_NhanXetBeAnHomNay.aspx");
        list.Add("modulequantrinhanxetsuckhoehangngay|admin-nhan-xet-suc-khoe-hang-ngay|~/admin_page/module_function/module_VietNhatKids/module_NhanXetSucKhoeHangNgay.aspx");
        list.Add("modulequantridanhsachthucdon|admin-thuc-don|~/admin_page/module_function/module_DoAn/module_DanhSachThucDon.aspx");
        list.Add("modulequantrithemthucdon|admin-thuc-don-{thudon-id}|~/admin_page/module_function/module_DoAn/module_DoAn_Menu.aspx");
        list.Add("modulequantringoaikhoa|admin-ngoai-khoa|~/admin_page/module_function/module_VietNhatKids/module_NgoaiKhoa.aspx");
        list.Add("modulequantrialbumimage|admin-bai-viet-album-image|~/admin_page/module_function/module_VietNhatKids/module_AlbumImage.aspx");
        list.Add("modulequantrialbumimagecontent|admin-bai-viet-album-image-content-{id}|~/admin_page/module_function/module_VietNhatKids/module_AlbumImage_Content.aspx");
        list.Add("modulequantrialbumimagehocsinh|admin-album-image-hoc-sinh|~/admin_page/module_function/module_VietNhatKids/module_AlbumImage_HocSinh2.aspx");
        list.Add("modulequantrixemalbumimagehocsinh|admin-xem-album-anh-hoc-sinh|~/admin_page/module_function/module_VietNhatKids/module_Xem_AlbumImage_HocSinh.aspx");
        list.Add("modulequantriduyetthucdon|admin-duyet-thuc-don|~/admin_page/module_function/module_DoAn/module_Duyet_ThucDon.aspx");
        list.Add("moduleindanhsachthucdon|admin-in-danh-sach-thuc-don|~/admin_page/module_function/module_DoAn/module_InDanhSachThucDonHangTuan.aspx");


        list.Add("modulequantrixemdanhsachdangkyngoaikhoa|admin-danh-sach-dang-ky-chuong-trinh-ngoai-khoa|~/admin_page/module_function/module_VietNhatKids/module_DanhSachDangKyChuongTrinhNgoaiKhoa.aspx");
        list.Add("modulequantrixemdanhsachkhongdangkyngoaikhoa|admin-danh-sach-khong-dang-ky-chuong-trinh-ngoai-khoa|~/admin_page/module_function/module_VietNhatKids/module_DanhSachKhongDangKyChuongTrinhNgoaiKhoa.aspx");
        list.Add("modulequantrixemdanhsachdangkytuvanngoaikhoa|admin-danh-sach-dang-ky-tu-van-ngoai-khoa|~/admin_page/module_function/module_VietNhatKids/module_DanhSachDangKyTuVanNgoaiKhoa.aspx");
        list.Add("modulequantrixemdanhsachdangkyhoatdongngoaikhoa|admin-danh-sach-dang-ky-hoat-dong-ngoai-khoa|~/admin_page/module_function/module_VietNhatKids/module_DanhSachDangKyHoatDongNgoaiKhoa.aspx");
        //module kế hoạch dạy học từng học
        list.Add("moduledanhsachkehoachdaytunglop|admin-danh-sach-ke-hoach-day-hoc-tung-lop|~/admin_page/module_function/module_LichCongTac/module_KeHoachDayHocTungLop/module_DanhSachKeHoachDayHocTungLop.aspx");
        list.Add("modulethemkehoachdaytunglop|admin-ke-hoach-day-hoc-tung-lop-{khdhid}|~/admin_page/module_function/module_LichCongTac/module_KeHoachDayHocTungLop/module_ThemKeHoachDayHocTungLop.aspx");
        list.Add("moduleinkehoachdaytunglop|admin-in-ke-hoach-day-hoc-tung-lop|~/admin_page/module_function/module_LichCongTac/module_KeHoachDayHocTungLop/module_InKeHoachDayHocTungLop.aspx");
        list.Add("moduletaokehoachdaytungloptest|admin-tao-ke-hoach-day-hoc-tung-lop-{khdhid}|~/admin_page/module_function/module_LichCongTac/module_KeHoachDayHocTungLop/module_ThemKeHoachDayHocTungLop_Test.aspx");

        //hòm thư góp ý
        list.Add("modulevietnhatkidsgopytuphuhuynh|admin-gop-y-tu-phu-huynh|~/admin_page/module_function/module_VietNhatKids/module_XemHomThuGopY.aspx");
        //đăng ký đồng phục
        list.Add("modulevietnhatkidsdanhsachdangkydongphuc|admin-danh-sach-dang-ky-dong-phuc|~/admin_page/module_function/module_VietNhatKids/module_DangKyDongPhuc.aspx");
        //đăng ký đồ dùng
        list.Add("modulevietnhatkidsdanhsachdangkydodung|admin-danh-sach-dang-ky-do-dung|~/admin_page/module_function/module_VietNhatKids/module_DangKyDoDung.aspx");



        //thống kê đánh giá giáo viên
        list.Add("moduletdanhsachthongkedanhgiagiaovien|admin-danh-sach-thong-ke-danh-gia-giao-vien|~/admin_page/module_function/module_ThongKe_GiaoVien/module_DanhSachThongKeDanhGia.aspx");
        list.Add("modulethongkegiaoviennhapnhanxethangngay|admin-thong-ke-giao-vien-nhan-xet-hang-ngay|~/admin_page/module_function/module_ThongKe_GiaoVien/module_ThongKeGiaoVienNhapNhanXetHangNgay.aspx");
        list.Add("modulethongkegiaovienxacnhandanthuoc|admin-thong-ke-giao-vien-xac-nhan-dan-thuoc|~/admin_page/module_function/module_ThongKe_GiaoVien/module_DanhGiaGiaoVien_DanDoThuoc.aspx");
        list.Add("modulethongkegiaovientaobaivietsukienhangtuan|admin-thong-ke-giao-vien-tao-bai-viet-su-kien-hang-tuan|~/admin_page/module_function/module_ThongKe_GiaoVien/module_DanhGiaGiaoVien_TaoBaiVietAlbumAnh.aspx");
        list.Add("modulethongkegiaovienxacnhanxinnghituphuhuynh|admin-thong-ke-giao-vien-xac-nhan-xin-nghi-tu-phu-huynh|~/admin_page/module_function/module_ThongKe_GiaoVien/module_DanhGiaGiaoVien_XinNghiTuPhuHuynh.aspx");
        list.Add("modulethongkegiaovientaothongbaolop|admin-thong-ke-giao-vien-tao-thong-bao-lop|~/admin_page/module_function/module_ThongKe_GiaoVien/module_DanhGiaGiaoVienThemThongBaoLop.aspx");
        list.Add("modulethongkegiaovientaothongbaotruong|admin-thong-ke-giao-vien-tao-thong-bao-truong|~/admin_page/module_function/module_ThongKe_GiaoVien/module_DanhGiaGiaoVienThemThongBaoTruong.aspx");
        list.Add("modulethongkegiaovienxemlichcongtactuan|admin-thong-ke-giao-vien-xem-lich-cong-tac-tuan|~/admin_page/module_function/module_ThongKe_GiaoVien/module_DanhGiaGiaoVienXemCongTacTuan.aspx");
        list.Add("modulethongkegiaovienxemlichcongtacthang|admin-thong-ke-giao-vien-xem-lich-cong-tac-thang|~/admin_page/module_function/module_ThongKe_GiaoVien/module_DanhGiaGiaoVienXemCongTacThang.aspx");
        list.Add("modulethongkegiaoviennhaplichbaogiang|admin-thong-ke-giao-vien-nhap-lich-bao-giang|~/admin_page/module_function/module_ThongKe_GiaoVien/module_ThongKeLichBaoGiang.aspx");
        list.Add("modulethongkegiaovientaoalbumanhhocsinh|admin-thong-ke-giao-tao-album-image-hoc-sinh|~/admin_page/module_function/module_ThongKe_GiaoVien/module_ThongKeTaoAblumCaNhan.aspx");
        list.Add("modulethongkegiaovienxacnhandangkyngoaikhoa|admin-thong-ke-giao-xac-nhan-dang-ky-ngoai-khoa|~/admin_page/module_function/module_ThongKe_GiaoVien/module_ThongKeXacNhanDangKyNgoaiKhoa.aspx");
        list.Add("moduletongdiemtichluygiaovien|admin-tong-diem-tich-luy-cua-giao-vien|~/admin_page/module_function/module_ThongKe_GiaoVien/module_DanhGiaGiaoVien_TongDiemTichLuy.aspx");
        list.Add("modulethongkediemdanhvanghoctongcaccoso|admin-thong-ke-diem-danh-vang-hoc-cac-co-so|~/admin_page/module_function/module_ThongKe_GiaoVien/module_ThongKeGiaoVienDiemDanh.aspx");
        list.Add("modulethongkegiaoviennhanxetthuongxuyentheolop|admin-thong-ke-giao-vien-nhan-xet-thuong-xuyen-theo-lop|~/admin_page/module_function/module_ThongKe_GiaoVien/module_ThongKeGiaoVien_NhanXetHangNgay_TheoLop.aspx");
        list.Add("modulethongkephuhuynhhangngay|admin-thong-ke-phu-huynh-hang-ngay|~/admin_page/module_function/module_ThongKe_GiaoVien/module_ThongKeHangNgay_PhuHuynh.aspx");

        //thống kê phụ huynh
        list.Add("modulethongketuongtaccuaphuhuynh|admin-thong-ke-tuong-tac-cua-phu-huynh|~/admin_page/module_function/module_VietNhatKids/module_ThongKeTuongTacCuaPhuHuynh.aspx");
        list.Add("modulethongkephuhuynhxemhoatdonghangngay|admin-thong-ke-phu-huynh-xem-hoat-dong-hang-ngay|~/admin_page/module_function/module_VietNhatKids/module_ThongKePhuHuynhXemLichHocHangNgay.aspx");
        list.Add("modulethongkephuhuynhxemsuckhoe|admin-thong-ke-phu-huynh-xem-suc-khoe|~/admin_page/module_function/module_VietNhatKids/module_ThongKePhuHuynhXemSucKhoe.aspx");
        list.Add("modulethongkephuhuynhxemthongbaotruong|admin-thong-ke-phu-huynh-xem-thong-bao-truong|~/admin_page/module_function/module_VietNhatKids/module_ThongKePhuHuynhXemThongBaoTruong.aspx");
        list.Add("modulethongkephuhuynhxemthongbaolop|admin-thong-ke-phu-huynh-xem-thong-bao-lop|~/admin_page/module_function/module_VietNhatKids/module_ThongKePhuHuynhXemThongBaoLop.aspx");

        //học phí
        list.Add("modulenhaphocphi|admin-nhap-hoc-phi|~/admin_page/module_function/module_HocPhi/module_NhapHocPhi.aspx");
        list.Add("modulenhaphocphiloi|admin-nhap-hoc-phi-loi|~/admin_page/module_function/module_HocPhi/module_NhapHocPhiLoi.aspx");

        list.Add("moduletonghocsinh|admin-tong-hoc-sinh|~/admin_page/module_function/module_HocSinh/modue_TongHocSinh.aspx");

        //module quản lý game học tập
        list.Add("modulequanlychude|admin-quan-ly-chu-de-hoc-tap|~/admin_page/module_function/module_NhapLieuGame/module_ChuDeHocTap.aspx");
        list.Add("modulequanlyloaigamechude|admin-quan-ly-loai-game-hoc-tap|~/admin_page/module_function/module_NhapLieuGame/module_LoaiGameChuDe.aspx");
        list.Add("modulequanlygamenhanbiet|admin-quan-ly-game-nhan-biet|~/admin_page/module_function/module_NhapLieuGame/module_LoaiGameNhanBiet.aspx");
        list.Add("modulequanlygametracnghiem|admin-quan-ly-game-trac-nghiem|~/admin_page/module_function/module_NhapLieuGame/module_LoaiGameTracNghiem.aspx");
        list.Add("modulequanlygametrucxanh|admin-quan-ly-game-truc-xanh|~/admin_page/module_function/module_NhapLieuGame/module_LoaiGameTrucXanh.aspx");
        list.Add("modulequanlygamekeotha|admin-quan-ly-game-keo-tha|~/admin_page/module_function/module_NhapLieuGame/module_LoaiGameKeoTha.aspx");
        list.Add("modulequanlygamechoncap|admin-quan-ly-game-chon-cap|~/admin_page/module_function/module_NhapLieuGame/module_LoaiGameChonCap.aspx");

        return list;
    }
}