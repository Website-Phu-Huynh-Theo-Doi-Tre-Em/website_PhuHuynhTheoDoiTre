using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for webui
/// </summary>
public class webui
{
    public webui()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<string> UrlRoutes()
    {
        List<string> list = new List<string>();
        list.Add("webTrangChu|viet-nhat-kids|~/Default.aspx");
        list.Add("webwlcome|welcome|~/web_module/module_PageWelcome.aspx");
        list.Add("webthaydoitaikhoan|viet-nhat-kids-thay-doi-tai-khoan|~/web_module/vietnhatkids_ThayDoiTaiKhoan.aspx");
        // Thông báo
        list.Add("webthongbaonhatruong|vietnhatkids-thong-bao-nha-truong-{id}|~/web_module/vietnhatkids_ThongBaoNhaTruong.aspx");
        list.Add("webthongbaolop|vietnhatkids-thong-bao-lop-{id}|~/web_module/vietnhatkids_ThongBaoLop.aspx");
        list.Add("webLoginVietNhatKids|login-viet-nhat-kids|~/web_module/vietnhatkids_Login.aspx");
        list.Add("weblichhoc|lich-hoc|~/web_module/vietnhatkids_LichHoc.aspx");
        list.Add("webdangkyngoaikhoa|vietnhatkids-dang-ky-ngoai-khoa|~/web_module/vietnhatkids_DangKyNgoaiKhoa.aspx");
        list.Add("webdangkyngoaikhoachitiet|vietnhatkids-dang-ky-ngoai-khoa-{id}|~/web_module/vietnhatkids_DangKyNgoaiKhoa_ChiTiet.aspx");
        list.Add("webxinnghi|vietnhatkids-xin-nghi|~/web_module/vietnhatkids_XinNghi.aspx");
        list.Add("webdanthuoc|vietnhatkids-dan-thuoc|~/web_module/vietnhatkids_DanDoThuoc.aspx");
        list.Add("webdangkydongphuc|vietnhatkids-dang-ky-dong-phuc|~/web_module/vietnhatkids_DangKiDongPhuc.aspx");
        list.Add("websukienhangtuan|vietnhatkids-su-kien-hang-tuan-{id}|~/web_module/vietnhatkids_SuKienHangTuan.aspx");
        list.Add("webthongtincanhancuabe|vietnhatkids-thong-tin-ca-nhan-cua-be|~/web_module/vietnhatkids_ThongTinCaNhanCuaBe.aspx");
        list.Add("webthaydoianhdaidien|vietnhatkids-thay-doi-anh-dai-dien|~/web_module/vietnhatkids_ThayDoiAnhDaiDien.aspx");
        list.Add("websuckhoe|vietnhatkids-suc-khoe|~/web_module/vietnhatkids_SucKhoe.aspx");
        //list.Add("webhoctap|vietnhatkids-hoc-tap|~/web_module/vietnhatkids_HocTap.aspx");
        list.Add("webdiachi|vietnhatkids-dia-chi|~/web_module/vietnhatkids_DiaChi.aspx");
        list.Add("webthugopy|vietnhatkids-thu-gop-y|~/web_module/vietnhatkids_ThuGopY.aspx");
        list.Add("webhoctapsohoc|vietnhatkids-hoc-tap-so-hoc|~/web_module/vietnhatkids_HocTap_SoHoc.aspx");
        list.Add("webhoctaphinhhoc|vietnhatkids-hoc-tap-hinh-hoc|~/web_module/vietnhatkids_HocTap_HinhHoc.aspx");
        list.Add("webhoctapnguoithan|vietnhatkids-hoc-tap-nguoi-than|~/web_module/vietnhatkids_HocTap_NguoiThan.aspx");
        list.Add("webhoctaptraicay|vietnhatkids-hoc-tap-trai-cay|~/web_module/vietnhatkids_HocTap_TraiCay.aspx");
        list.Add("webhoctapraucu|vietnhatkids-hoc-tap-rau-cu|~/web_module/vietnhatkids_HocTap_RauCu.aspx");
        list.Add("webhoctapnghenghiep|vietnhatkids-hoc-tap-nghe-nghiep|~/web_module/vietnhatkids_HocTap_NgheNghiep.aspx");
        list.Add("webalbumanh|vietnhatkids-album-anh|~/web_module/vietnhatkids_Album.aspx");
        list.Add("webalbumanhchitiet|vietnhatkids-album-anh-chi-tiet-{album-id}|~/web_module/vietnhatkids_AlbumAnhChiTiet.aspx");
        list.Add("webdangkiansanguongsua|vietnhatkids-dang-ki-an-sang-uong-sua|~/web_module/vietnhatkids_DangKiAnSangUongSua.aspx");
        list.Add("webhuydangkiansanguongsua|vietnhatkids-huy-dang-ki-an-sang-uong-sua|~/web_module/vietnhatkids_HuyDangKiAnSangUongSua.aspx");
        list.Add("webdangkidodung|vietnhatkids-dang-ky-do-dung|~/web_module/vietnhatkids_DangKyDoDung.aspx");
        list.Add("webdangkihocve|vietnhatkids-dang-ky-hoc-ve|~/web_module/vietnhatkids_DangKyHocVe.aspx");
        list.Add("webdangkihoctienganh|vietnhatkids-dang-ky-hoc-tieng-anh|~/web_module/vietnhatkids_DangKyHocTiengAnh.aspx");
        list.Add("webdangkihocaerobic|vietnhatkids-dang-ky-hoc-aerobic|~/web_module/vietnhatkids_DangKyHocAerobic.aspx");



        list.Add("webxemhocphi|vietnhatkids-xem-hoc-phi|~/web_module/vietnhatkids_XemHocPhi.aspx");
        //trang loại game
        list.Add("webhoctaploaigame|vietnhatkids-hoc-tap-loai-game|~/web_module/vietnhatkids_HocTap_LoaiGame.aspx");
        //list.Add("webhoctaploaigametets|vietnhatkids-hoc-tap-loai-game-test|~/web_module/vietnhatkids_HocTap_LoaiGame - Copy.aspx");
        //trang chủ đề game
        list.Add("webhoctaploaigamechude|vietnhatkids-hoc-tap-{loaigame}-danh-sach-chu-de|~/web_module/vietnhatkids_HocTap.aspx");

        //Game nhận biết 
        //list.Add("webchudesohocnhanbiettu1toi10|chu-de-so-hoc-nhan-biet-tu-1-toi-10|~/web_module/vietnhatkids_Game/game_SoHoc/sohoc_tu1toi10_NhanBiet.aspx");
        list.Add("webchudesohocnhanbiettu1toi10-eng|chu-de-so-hoc-nhan-biet-tu-1-toi-10-test|~/web_module/vietnhatkids_Game/game_SoHoc/sohoc_tu1toi10_NhanBiet_eng.aspx");
        list.Add("webchudenguoithannhanbiet|chu-de-nguoi-than-nhan-biet|~/web_module/vietnhatkids_Game/game_NguoiThan/nguoithan_NhanBiet.aspx");
        list.Add("webchudehinhhocnhanbiet2|chu-de-hinh-hoc-nhan-biet-2|~/web_module/vietnhatkids_Game/game_HinhHoc/hinhhoc_NhanBiet.aspx");
        list.Add("webchuderaucunhanbiet|chu-de-rau-cu-nhan-biet|~/web_module/vietnhatkids_Game/game_RauCu/raucu_NhanBiet.aspx");
        list.Add("webchudetraicaynhanbiet|chu-de-trai-cay-nhan-biet|~/web_module/vietnhatkids_Game/game_TraiCay/traicay_NhanBiet.aspx");
        list.Add("webchudenghenghiepnhanbiet|chu-de-nghe-nghiep-nhan-biet|~/web_module/vietnhatkids_Game/game_NgheNghiep/nghenghiep_NhanBiet.aspx");
        list.Add("webchudegiaothongnhanbiet|chu-de-giao-thong-nhan-biet|~/web_module/vietnhatkids_Game/game_GiaoThong/giaothong_NhanBiet.aspx");
        list.Add("webchudechucainhanbiet|chu-de-chu-cai-nhan-biet|~/web_module/vietnhatkids_Game/game_ChuCai/chucai_NhanBiet.aspx");
        list.Add("webchudedongvatnhanbiet|chu-de-dong-vat-nhan-biet|~/web_module/vietnhatkids_Game/game_DongVat/dongvat_NhanBiet.aspx");
        list.Add("webchudedungcuhoctapnhanbiet|chu-de-dung-cu-hoc-tap-nhan-biet|~/web_module/vietnhatkids_Game/game_DungCuHocTap/dungcuhoctap_NhanBiet.aspx");
        list.Add("webchudechucainhanbietversion2|chu-de-chu-cai-nhan-biet-version-2|~/web_module/vietnhatkids_Game/game_ChuCai/chucai_NhanBiet_ver2.aspx");
        //Game kéo thả
        list.Add("webchudehinhhockeotha|chu-de-hinh-hoc-keo-tha-{id}|~/web_module/vietnhatkids_Game/game_HinhHoc/hinhhoc_KeoTha.aspx");
        list.Add("webchudenghenghiepkeotha|chu-de-nghe-nghiep-keo-tha-{id}|~/web_module/vietnhatkids_Game/game_NgheNghiep/nghenghiep_KeoTha.aspx");
        list.Add("webchuderaucukeotha|chu-de-rau-cu-keo-tha-{id}|~/web_module/vietnhatkids_Game/game_RauCu/raucu_KeoTha.aspx");
        list.Add("webchudetraicaykeotha|chu-de-trai-cay-keo-tha-{id}|~/web_module/vietnhatkids_Game/game_TraiCay/traicay_KeoTha.aspx");
        list.Add("webchudesohockeotha|chu-de-so-hoc-keo-tha-{id}|~/web_module/vietnhatkids_Game/game_SoHoc/sohoc_KeoTha.aspx");
        list.Add("webchudenguoithankeotha|chu-de-nguoi-than-keo-tha-{id}|~/web_module/vietnhatkids_Game/game_NguoiThan/nguoithan_KeoTha.aspx");
        list.Add("webchudechucaikeotha|chu-de-chu-cai-keo-tha-{id}|~/web_module/vietnhatkids_Game/game_ChuCai/chucai_KeoTha.aspx");
        list.Add("webchudegiaothongkeotha|chu-de-giao-thong-keo-tha-{id}|~/web_module/vietnhatkids_Game/game_GiaoThong/giaothong_KeoTha.aspx");
        list.Add("webchudetraicaykeotha-eng|chu-de-trai-cay-keo-tha-test-{id}|~/web_module/vietnhatkids_Game/game_TraiCay/test_KeoTha.aspx.aspx");


        //Game trắc  nghiệm
        list.Add("webchudehinhhoctracnghiem|chu-de-hinh-hoc-trac-nghiem|~/web_module/vietnhatkids_Game/game_HinhHoc/hinhhoc_TracNghiem.aspx");
        list.Add("webchudenguoithantracnghiem|chu-de-nguoi-than-trac-nghiem|~/web_module/vietnhatkids_Game/game_NguoiThan/nguoithan_TracNghiem.aspx");
        list.Add("webchudenghenghieptracnghiem|chu-de-nghe-nghiep-trac-nghiem|~/web_module/vietnhatkids_Game/game_NgheNghiep/nghenghiep_TracNghiem.aspx");
        list.Add("webchuderaucutracnghiem|chu-de-rau-cu-trac-nghiem|~/web_module/vietnhatkids_Game/game_RauCu/raucu_TracNghiem.aspx");
        list.Add("webchudetraicaytracnghiem|chu-de-trai-cay-trac-nghiem|~/web_module/vietnhatkids_Game/game_TraiCay/traicay_TracNghiem.aspx");
        list.Add("webchudesohoctracnghiem|chu-de-so-hoc-trac-nghiem|~/web_module/vietnhatkids_Game/game_SoHoc/sohoc_TracNghiem.aspx");
        list.Add("webchudechucaitracnghiem|chu-de-chu-cai-trac-nghiem|~/web_module/vietnhatkids_Game/game_ChuCai/chucai_TracNghiem.aspx");
        list.Add("webchudegiaothongtracnghiem|chu-de-giao-thong-trac-nghiem|~/web_module/vietnhatkids_Game/game_GiaoThong/giaothong_TracNghiem.aspx");
        list.Add("webchudedungcuhoctaptracnghiem|chu-de-dung-cu-hoc-tap-trac-nghiem|~/web_module/vietnhatkids_Game/game_DungCuHocTap/dungcuhoctap_TracNghiem.aspx");

        //Game trúc xanh
        list.Add("webchudesohoctrucxanh|chu-de-so-hoc-truc-xanh|~/web_module/vietnhatkids_Game/game_SoHoc/sohoc_TrucXanh.aspx");
        list.Add("webchudehinhhoctrucxanh|chu-de-hinh-hoc-truc-xanh|~/web_module/vietnhatkids_Game/game_HinhHoc/hinhhoc_TrucXanh.aspx");
        list.Add("webchudenguoithantrucxanh|chu-de-nguoi-than-truc-xanh|~/web_module/vietnhatkids_Game/game_NguoiThan/nguoithan_TrucXanh.aspx");
        list.Add("webchudenghenghieptrucxanh|chu-de-nghe-nghiep-truc-xanh|~/web_module/vietnhatkids_Game/game_NgheNghiep/nghenghiep_TrucXanh.aspx");
        list.Add("webchuderaucutrucxanh|chu-de-rau-cu-truc-xanh|~/web_module/vietnhatkids_Game/game_RauCu/raucu_TrucXanh.aspx");
        list.Add("webchudetraicaytrucxanh|chu-de-trai-cay-truc-xanh|~/web_module/vietnhatkids_Game/game_TraiCay/traicay_TrucXanh.aspx");
        list.Add("webchudegiaothongtrucxanh|chu-de-giao-thong-truc-xanh|~/web_module/vietnhatkids_Game/game_GiaoThong/giaothong_TrucXanh.aspx");
        list.Add("webchudedungcuhoctaptrucxanh|chu-de-dung-cu-hoc-tap-truc-xanh|~/web_module/vietnhatkids_Game/game_DungCuHocTap/dungcuhoctap_TrucXanh.aspx");
        list.Add("webchudedongvattrucxanh|chu-de-dong-vat-truc-xanh|~/web_module/vietnhatkids_Game/game_DongVat/dongvat_TrucXanh.aspx");
        list.Add("webchudetraicaytrucxanhdemnguoc|chu-de-trai-cay-truc-xanh-thoi-gian-dem-nguoc|~/web_module/vietnhatkids_Game/game_TraiCay/traicay_TrucXanh_ThoiGianDemNguoc.aspx");
        list.Add("webchudetraicaytrucxanhthoigianluyentap|chu-de-trai-cay-truc-xanh-thoi-gian-luyen-tap|~/web_module/vietnhatkids_Game/game_TraiCay/traicay_TrucXanh_ThoiGianLuyenTap.aspx");
        //list.Add("webchudetraicaytrucxanhthachdau|chu-de-trai-cay-truc-xanh-thach-dau|~/web_module/vietnhatkids_Game/game_TraiCay/traicay_TrucXanh_ThachDau.aspx");
        list.Add("webchudetraicaytrucxanhcapdo|chu-de-trai-cay-truc-xanh-cap-do|~/web_module/vietnhatkids_Game/game_TraiCay/traicay_TrucXanh_CapDo.aspx");
        list.Add("webchudechucaitrucxanhcapdo|chu-de-chu-cai-truc-xanh|~/web_module/vietnhatkids_Game/game_ChuCai/chucai_TrucXanh.aspx");
        list.Add("webchudemausactrucxanh|chu-de-mau-sac-truc-xanh|~/web_module/vietnhatkids_Game/game_MauSac/mausac_TrucXanh.aspx");


        //Game ghép hình 
        //list.Add("webchudesohocghephinh|chu-de-so-hoc-ghep-hinh-{id}|~/web_module/vietnhatkids_Game/game_SoHoc/sohoc_GhepHinh.aspx");
        list.Add("webchudesohocghephinh|chu-de-so-hoc-ghep-hinh-{id}|~/web_module/vietnhatkids_Game/gametheosach/game_SoHoc/sohoc_GhepHinh_TheoSach.aspx");
        list.Add("webchuderaucughephinh|chu-de-rau-cu-ghep-hinh-{id}|~/web_module/vietnhatkids_Game/game_RauCu/raucu_GhepHinh.aspx");
        list.Add("webchudecgiaothongghephinh|chu-de-giao-thong-ghep-hinh-{id}|~/web_module/vietnhatkids_Game/game_GiaoThong/giaothong_GhepHinh.aspx");
        list.Add("webchudetraicayghephinh|chu-de-trai-cay-ghep-hinh-{id}|~/web_module/vietnhatkids_Game/game_TraiCay/traicay_GhepHinh.aspx");
        list.Add("webchudenghenghiepghephinh|chu-de-nghe-nghiep-ghep-hinh-{id}|~/web_module/vietnhatkids_Game/game_NgheNghiep/nghenghiep_GhepHinh.aspx");
        list.Add("webchudechucaighephinh|chu-de-chu-cai-ghep-hinh-{id}|~/web_module/vietnhatkids_Game/game_ChuCai/ChuCai_GhepHinh.aspx");
        list.Add("webchudehinhhocghephinh|chu-de-hinh-hoc-ghep-hinh-{id}|~/web_module/vietnhatkids_Game/game_HinhHoc/HinhHoc_GhepHinh.aspx");


        //Game nối 
        list.Add("webchudesohocnoi|chu-de-so-hoc-noi-{id}|~/web_module/vietnhatkids_Game/game_SoHoc/sohoc_Noi.aspx");
        list.Add("webchudetraicaynoi|chu-de-trai-cay-noi-{id}|~/web_module/vietnhatkids_Game/game_TraiCay/traicay_Noi.aspx");
        list.Add("webchuderaucunoi|chu-de-rau-cu-noi-{id}|~/web_module/vietnhatkids_Game/game_RauCu/raucu_Noi.aspx");
        list.Add("webchudehinhhoc|chu-de-hinh-hoc-noi-{id}|~/web_module/vietnhatkids_Game/game_HinhHoc/hinhhoc_Noi.aspx");
        list.Add("webchudechucai|chu-de-chu-cai-noi-{id}|~/web_module/vietnhatkids_Game/game_ChuCai/chucai_Noi.aspx");
        list.Add("webchudedungcuhoctap|chu-de-dung-cu-hoc-tap-noi-{id}|~/web_module/vietnhatkids_Game/game_DungCuHocTap/dungcuhoctap_Noi.aspx");

        //game trò chơi
        list.Add("webtrochoivongquaymayman|tro-choi-vong-quay-may-man|~/web_module/vietnhatkids_Game/game_TroChoi/game_VongQuayMayMan.aspx");

        //game trên giấy
        list.Add("webdanhmucsach|danh-muc-sach|~/web_module/vietnhatkids_Game/game_GiayHoc/game_DanhMucSach.aspx");
        list.Add("webdanhsachtrengiayquyen1|danh-sach-quyen-1|~/web_module/vietnhatkids_Game/game_GiayHoc/game_DanhSach_Quyen1.aspx");
        list.Add("webdanhsachtrengiayquyen2|danh-sach-quyen-2|~/web_module/vietnhatkids_Game/game_GiayHoc/game_DanhSach_Quyen2.aspx");
        list.Add("webdanhsachtrengiayquyen3|danh-sach-quyen-3|~/web_module/vietnhatkids_Game/game_GiayHoc/game_DanhSach_Quyen3.aspx");
        list.Add("webdanhsachtrengiayquyen4|danh-sach-quyen-4|~/web_module/vietnhatkids_Game/game_GiayHoc/game_DanhSach_Quyen4.aspx");
        list.Add("webdanhsachtrengiayquyen5|danh-sach-quyen-5|~/web_module/vietnhatkids_Game/game_GiayHoc/game_DanhSach_Quyen5.aspx");

        list.Add("webdanhsachtrengiayquyen1bookvo|danh-sach-quyen-1-book-vo|~/web_module/vietnhatkids_Game/game_GiayHoc/game_DanhSach_Quyen1_BookVo.aspx");
        list.Add("webdanhsachtrengiayquyendein|in-giay|~/web_module/vietnhatkids_Game/game_GiayHoc/game_XuatFileWord.aspx");


        list.Add("webdanhmuctohinh|danh-muc-to-hinh|~/web_module/vietnhatkids_Game/game_GiayHoc/game_DanhMucToHinh.aspx");
        list.Add("webdanhsachtohinhquyen|to-hinh-{chude_name}-{chude_id}|~/web_module/vietnhatkids_Game/game_GiayHoc/game_ToHinh_Quyen.aspx");

        //website việt nhật kids
        //Login
        list.Add("webvietnhatkidslogin|website-vietnhatkids-login|~/web_module/website_VietNhatKids/web_Login.aspx");

        //Trang chủ- website
        list.Add("webvietnhatkidstrangchu|website-trang-chu|~/web_module/module_website/web_trangchu.aspx");
        list.Add("webvietnhatkidsthongbao|website-thong-bao|~/web_module/website_VietNhatKids/Web_ThongBao_Navtab.aspx");
        list.Add("webvietnhatkidssukienhangtuan|website-vietnhatkids-su-kien-hang-tuan|~/web_module/website_VietNhatKids/web_SuKienHangTuan.aspx");
        list.Add("webvietnhatkidsablumAnh|website-vietnhatkids-ablum-anh|~/web_module/website_VietNhatKids/web_AblumAnh-Copy.aspx");
        list.Add("webvietnhatkidsansanguongsua|website-vietnhatkids-an-sang-uong-sua|~/web_module/website_VietNhatKids/Web_DangKyAnSang.aspx");
        list.Add("webvietnhatkidsdangkidongphuclephuc|website-vietnhatkids-dang-ky-dong-phuc-le-phuc|~/web_module/website_VietNhatKids/web_DangKyDongPhuc_LePhuc.aspx");
        list.Add("webvietnhatkidsdangkingoaikhoa|website-vietnhatkids-dang-ky-da-ngoai|~/web_module/website_VietNhatKids/web_DangKyNgoaiKhoa.aspx");
        list.Add("webvietnhatkidsdanthuoc|website-vietnhatkids-dan-thuoc|~/web_module/website_VietNhatKids/web_DanThuoc.aspx");
        list.Add("webvietnhatkidshoatdonghangngay|website-vietnhatkids-hoat-dong-hang-ngay|~/web_module/website_VietNhatKids/web_HoatDongHangNgay.aspx");
        list.Add("webvietnhatkidsthongtinsuckhoe|website-vietnhatkids-thong-tin-suc-khoe|~/web_module/website_VietNhatKids/web_ThongTinSucKhoe.aspx");
        list.Add("webvietnhatkidsxinnghi|website-vietnhatkids-xin-nghi|~/web_module/website_VietNhatKids/web_XinNghi.aspx");
        list.Add("webvietnhatkidsdanhgiagiaovien|website-vietnhatkids-danh-gia-giao-vien|~/web_module/website_VietNhatKids/web_DanhGiaGiaoVien.aspx");
        list.Add("webvietnhatkidsForgetPassword|website-ForgetPassword|~/web_module/website_VietNhatKids/web_QuenMatKhau.aspx");
        list.Add("webvietnhatkidsHocPhi|website-vietnhatkids-hoc-phi|~/web_module/website_VietNhatKids/web_HocPhi.aspx");
        list.Add("webvietnhatkidsDoDungHocTap|website-vietnhatkids-do-dung-hoc-tap|~/web_module/website_VietNhatKids/web_DangKyDoDung.aspx");
        list.Add("webvietnhatkidsDangKyNangKhieu|website-vietnhatkids-nang-khieu|~/web_module/website_VietNhatKids/web_DangKyNangKhieu.aspx");
        list.Add("webdoingugiaovien|mam-non-doi-ngu-giao-vien|~/web_module/website_VietNhatKids/web_DoiNguGiaoVien.aspx");
        list.Add("webcocautochuc|mam-non-co-cau-to-chuc|~/web_module/website_VietNhatKids/web_CoCauToChuc.aspx");
        list.Add("webdoitacchienluoc|mam-non-doi-tac-chien-luoc|~/web_module/website_VietNhatKids/web_DoiTacChienLuoc.aspx");
        list.Add("webthanhtuuvietnhat|mam-non-thanh-tuu-viet-nhat|~/web_module/website_VietNhatKids/web_ThanhTuuVietNhat.aspx");
        list.Add("webcosovatchat|mam-non-co-so-vat-chat|~/web_module/website_VietNhatKids/web_CoSoVatChat.aspx");
        list.Add("webgioithieuhung|mam-non-gioi-thieu-chung|~/web_module/website_VietNhatKids/web_GioiThieuChung.aspx");
        list.Add("webtamnhinsumenh|mam-non-tam-nhin-su-menh|~/web_module/website_VietNhatKids/web_TamNhinSuMenh.aspx");
        list.Add("webthungo|mam-non-thu-ngo|~/web_module/website_VietNhatKids/web_ThuNgo.aspx");
        list.Add("webthucdon|mam-non-thuc-don|~/web_module/website_VietNhatKids/web_ThucDon.aspx");
        list.Add("webbacdaotao|mam-non-bac-dao-tao|~/web_module/website_VietNhatKids/Web_BacDaoTaoMamNon.aspx");
        list.Add("webtuyensinhmamnon|mam-non-tuyen-sinh-mam-non|~/web_module/website_VietNhatKids/web_TuyenSinhMamNon.aspx");
        list.Add("webquytrinhtuyensinh|mam-non-quy-trinh-tuyen-sinh-mam-non|~/web_module/website_VietNhatKids/Web_QuyTrinhTuyenSinh.aspx");
        list.Add("webhocphivachinhsachuudai|mam-non-hoc-phi-chinh-sach-uu-dai|~/web_module/website_VietNhatKids/web_HocPhiVaChinhSachUuDai.aspx");
        //
        list.Add("webhoctap|hoc-tap|~/web_module/vietnhatkids_HocTap_DanhSachChuDe.aspx");
        list.Add("webhoctaploaigamechudemamnon|hoc-tap-chu-de-loai-game-{chude}|~/web_module/vietnhatkids_HocTap_LoaiGame_ChuDe.aspx");
        list.Add("webhoctapnhanbietchudemamnon2|hoc-tap-nhan-biet-chu-de-{chude-name}-{chude-id}|~/web_module/vietnhatkids_Game/web_Game/web_GameNhanBiet.aspx");
        list.Add("webhoctapnhanbietchudemamnon|hoc-tap-nhan-biet-2-chu-de-{chude-name}-{chude-id}|~/web_module/vietnhatkids_Game/web_Game/web_GameNhanBiet_Ver2.aspx");
        list.Add("webhoctapnhanbiettuchonchudemamnon|hoc-tap-nhan-biet-tu-chon-chu-de-{chude-name}-{chude-id}|~/web_module/vietnhatkids_Game/web_Game/web_GameNhanBiet_TuChon.aspx");
        list.Add("webhoctaptracnghiemtuchonchudemamnon|hoc-tap-trac-nghiem-tu-chon-chu-de-{chude-name}-{chude-id}|~/web_module/vietnhatkids_Game/web_Game/web_GameHocTapTracNghiem_TuChon.aspx");
        list.Add("webhoctaptracnghiemchudemamnon|hoc-tap-trac-nghiem-chu-de-{chude-name}-{chude-id}|~/web_module/vietnhatkids_Game/web_Game/web_GameHocTapTracNghiem.aspx");
        // 
        list.Add("webhoctapchonnhieuchudemamnon|hoc-tap-chon-nhieu-chu-de-{chude-name}-{chude-id}|~/web_module/vietnhatkids_Game/game_ChonNhieuHinh/game_KhoanhTron.aspx");
        list.Add("webhoctaptrucxanhchudemamnon|hoc-tap-truc-xanh-chu-de-{chude-name}-{chude-id}|~/web_module/vietnhatkids_Game/web_Game/web_GameTrucXanh.aspx");
        list.Add("webhoctapkeothadechudemamnon|hoc-tap-keo-tha-de-chu-de-{chude-name}-{chude-id}-{id}|~/web_module/vietnhatkids_Game/web_Game/web_GameKeoTha_3Hinh.aspx");
        list.Add("webhoctapkeothavuachudemamnon|hoc-tap-keo-tha-vua-chu-de-{chude-name}-{chude-id}-{id}|~/web_module/vietnhatkids_Game/web_Game/web_GameKeoTha_4Hinh.aspx");
        list.Add("webhoctapkeothakhochudemamnon|hoc-tap-keo-tha-kho-chu-de-{chude-name}-{chude-id}-{id}|~/web_module/vietnhatkids_Game/web_Game/web_GameKeoTha_6Hinh.aspx");
        list.Add("webhoctapkeothadechudegiaothong1mamnon|hoc-tap-keo-tha-muc-de-chu-de-giao-thong-{chude-id}-{id}|~/web_module/vietnhatkids_Game/web_Game/web_GameKeoTha_3Hinh_GiaoThong.aspx");



        list.Add("webhoctapchoncapchudemamnon|hoc-tap-chon-cap-chu-de-{chude-name}-{chude-id}|~/web_module/vietnhatkids_Game/web_Game/web_GameTrucXanh_Ver3.aspx");

        list.Add("webhoctaptrucxanhver2chudemamnon|hoc-tap-truc-xanh-ver2|~/web_module/vietnhatkids_Game/web_Game/web_GameTrucXanh_Ver2_1.aspx");
        list.Add("webhoctaptrucxanhthachdauchudemamnon|hoc-tap-truc-xanh-thach-dau|~/web_module/vietnhatkids_Game/web_Game/web_GameTrucXanh_ThachDau.aspx");

        list.Add("webdanhmuchoctap|danh-muc-hoc-tap|~/web_module/vietnhatkids_DanhMuc1.aspx");
        //danh muc so hoc- chu cai
        list.Add("webdanhmuchoctapsohoc|danh-muc-so-hoc|~/web_module/Vietnhatkids_DanhMucSoHoc.aspx");
        list.Add("webdanhmuc|danh-muc|~/web_module/vietnhatkids_DanhMucHocTap.aspx");
        list.Add("webchudesohocnhanbiettheosach|chu-de-so-hoc-nhan-biet-theo-sach|~/web_module/vietnhatkids_Game/gametheosach/game_SoHoc/sohoc_tu1toi10_NhanBiet_eng.aspx");
        //
        list.Add("webchudesohocnhanbiettheosachtatca|chu-de-so-hoc-nhan-biet-theo-sach-tat-ca|~/web_module/vietnhatkids_Game/gametheosach/game_SoHoc/sohoc_tatca_ver2.aspx");
        
        list.Add("webchudesohockeothatheosach|hoc-tap-mam-non-keo-tha-{id}|~/web_module/vietnhatkids_Game/gametheosach/game_SoHoc/sohoc_KeoTha_TheoSach.aspx");
        list.Add("webchudesohoctracnghiemtheosach|hoc-tap-mam-non-trac-nghiem|~/web_module/vietnhatkids_Game/gametheosach/game_SoHoc/sohoc_TracNghiem_TheoSach.aspx");
        list.Add("webchudesohoctrucxanhtheosach|hoc-tap-mam-non-truc-xanh|~/web_module/vietnhatkids_Game/gametheosach/game_SoHoc/sohoc_TrucXanh_TheoSach.aspx");
        list.Add("webchudesohocghephinhtheosach|hoc-tap-mam-non-ghep-hinh-{id}|~/web_module/vietnhatkids_Game/gametheosach/game_SoHoc/sohoc_GhepHinh_TheoSach.aspx");
        //list.Add("webchudesohockeothatheosach|chu-de-so-hoc-keo-tha-theo-sach-{id}|~/web_module/gametheosach/game_SoHoc/sohoc_KeoTha.aspx");

        list.Add("webdanhmuchoctapchucai|danh-muc-chu-cai|~/web_module/Vietnhatkids_DanhMucChuCai.aspx");
        list.Add("webmamnonchudechucainhanbiettheosach|chu-de-chu-cai-nhan-biet-theo-sach|~/web_module/vietnhatkids_Game/gametheosach/game_ChuCai/chucai_NhanBiet_TheoSach.aspx");
        list.Add("webmamnonchudechucaikeothatheosach|chu-de-chu-cai-mam-non-keo-tha-theo-sach-{id}|~/web_module/vietnhatkids_Game/gametheosach/game_ChuCai/chucai_KeoTha.aspx");
        list.Add("webmamnonchudechucaitracnghiemtheosach|hoc-tap-mam-non-chu-cai-trac-nghiem|~/web_module/vietnhatkids_Game/gametheosach/game_ChuCai/chucai_TracNghiem.aspx");
        list.Add("webmamnonchudechucaitrucxanhtheosach|hoc-tap-mam-non-chu-cai-truc-xanh|~/web_module/vietnhatkids_Game/gametheosach/game_ChuCai/ChuCai_TrucXanh_TheoSach.aspx");
        //list.Add("webchudechucaighephinhtheosach|hoc-tap-mam-non-chu-cai-ghep-hinh-{id}|~/web_module/vietnhatkids_Game/game_ChuCai/ChuCai_GhepHinh.aspx");
        list.Add("webchudechucainoitheosach|hoc-tap-mam-non-chu-cai-noi|~/web_module/vietnhatkids_Game/gametheosach/game_ChuCai/chucai_TracNghiem.aspx");

        //chủ đề hiện tượng tự nhiên
        list.Add("webhoctapchudehientuongtunhien|hoc-tap-chu-de-nuoc-hien-tuong-tu-nhien|~/web_module/vietnhatkids_Game/gametheosach/vietnhatkids_NuocVaHienTuongTuNhien.aspx");
        list.Add("webhoctapchudedatnuocbacho|hoc-tap-chu-de-que-huong-dat-nuoc-bac-ho|~/web_module/vietnhatkids_Game/gametheosach/vietnhatkids_QueHuongDatNuocBacHo.aspx");



        //list.Add("webchudetracnghiemtest|hoc-tap-mam-non-trac-nghiem-test|~/web_module/vietnhatkids_Game/web_Game/web_GameTracNghiem.aspx");




        // game tuy duy
        list.Add("webchudetuduystart|tu-duy-tinh-toan|~/web_module/vietnhatkids_Game/game_TinhToan/TinhToan.aspx");
        list.Add("webchudetuduy|tu-duy-tinh-toan-{id}-{pheptinh}|~/web_module/vietnhatkids_Game/game_TinhToan/game_TinhToan.aspx");
        // game tập đếm
        list.Add("webchudetapdem|tap-dem|~/web_module/vietnhatkids_Game/game_TapDem/module_TapDem.aspx");

        //game tô màu
        list.Add("webhoctapmamnontomau|hoc-tap-mam-non-to-mau|~/web_module/vietnhatkids_Game/game_GiayHoc/game_DanhSach_TranhVe.aspx");
        //game chọn nhiều

        list.Add("webhoctapdongvatchonnhieu|hoc-tap-mam-non-dong-vat-chon-nhieu|~/web_module/vietnhatkids_Game/game_ChonNhieuHinh/game_KhoanhTron.aspx");
        return list;
    }
}