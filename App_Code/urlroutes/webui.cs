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
        //Trang chủ- website
        list.Add("websitetrangchu|website-trang-chu|~/web_module/module_website/web_trangchu.aspx");
        list.Add("websitedangnhap|website-dang-nhap|~/web_module/website_PhuHuynhTheoDoiTre/web_Login.aspx");
        list.Add("websitethongbao|website-thong-bao|~/web_module/website_PhuHuynhTheoDoiTre/Web_ThongBao_Navtab.aspx");
        list.Add("websitequenmatkhau|website-quen-mat-khau|~/web_module/website_PhuHuynhTheoDoiTre/web_QuenMatKhau.aspx");
        list.Add("websitexinnghi|website-xin-nghi|~/web_module/website_PhuHuynhTheoDoiTre/web_XinNghi.aspx");
        list.Add("websitethongtinsuckhoe|website-thong-tin-suc-khoe|~/web_module/website_PhuHuynhTheoDoiTre/web_ThongTinSucKhoe.aspx");
        list.Add("websitedanthuoc|website-thong-dan-thuoc|~/web_module/website_PhuHuynhTheoDoiTre/web_DanThuoc.aspx");
        list.Add("websitedangkiansang|website-dang-ki-an-sang|~/web_module/website_PhuHuynhTheoDoiTre/Web_DangKyAnSang.aspx");
        list.Add("websitedangkingoaikhoa|website-dang-ki-ngoai-khoa|~/web_module/website_PhuHuynhTheoDoiTre/web_DangKyNgoaiKhoa.aspx");
        list.Add("websitechucnangdangcapnhat|website-chuc-nang-dang-duoc-cap-nhat|~/web_module/website_PhuHuynhTheoDoiTre/Page_ComingSoonaspx.aspx");
        return list;
    }
}