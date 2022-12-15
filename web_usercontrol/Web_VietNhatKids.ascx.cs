using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_usercontrol_WebUserControl : System.Web.UI.UserControl
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert Al = new cls_Alert();
    private static int id_Lop;
    private static int id_nam;
    public int sothongbao, namhoc_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        //check đã đọc thông báo chưa
        // nếu chưa đọc thì hiển thị số thông báo mới lên
        // nếu đọc rồi thì mất số luôn
        if (Request.Cookies["web_hocsinh"] != null)
        {
            try
            {
                namhoc_id = (from nm in db.tbHoctap_NamHocs
                             orderby nm.namhoc_id descending
                             select nm.namhoc_id).First();

                //Lay so thong bao moi
                var gettbt = from hs in db.tbHocSinhs
                             join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                             join l in db.tbLops on hstl.lop_id equals l.lop_id
                             join tb in db.tbVietNhatKids_ThongBaoTruongs on l.khoi_id equals tb.khoi_id
                             where hs.hocsinh_taikhoan == Request.Cookies["web_hocsinh"].Value
                             && hstl.namhoc_id == namhoc_id
                           && !db.tbVietNhatKids_ThongBaoTruong_LichSus.Any(x => (x.thongbaotruong_id == tb.thongbaotruong_id && x.hstl_id == hstl.hstl_id))
                             select tb;

                var gettbl = from hs in db.tbHocSinhs
                             join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                             join l in db.tbLops on hstl.lop_id equals l.lop_id
                             join tb in db.tbVietNhatKids_ThongBaoLops on l.lop_id equals tb.lop_id
                             where hs.hocsinh_taikhoan == Request.Cookies["web_hocsinh"].Value
                             && tb.thongbaolop_tinhtrang==2
                             && hstl.namhoc_id == namhoc_id
                             && !db.tbVietNhatKids_ThongBaoLop_LichSus.Any(ls => (ls.thongbaolop_id == tb.thongbaoLop_id && ls.hstl_id == hstl.hstl_id))
                             select tb;

                sothongbao = gettbt.Count() + gettbl.Count();
                if (sothongbao == 0)
                {
                    divThongBao.Visible = false;
                }

                var getListSuKien = from hs in db.tbHocSinhs
                                    join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                                    join tb in db.tbVietNhatKids_AlbumImages on hstl.lop_id equals tb.lop_id
                                    where hs.hocsinh_taikhoan == Request.Cookies["web_hocsinh"].Value
                                    && hstl.namhoc_id == namhoc_id
                                   && !db.tbVietNhatKids_AlbumImage_LichSuHocSinhs.Any(x => (x.ablumimage_id == tb.albumimage_id))
                                    select tb;
                if (getListSuKien.Count() > 0)
                {
                    divSuKien.Visible = true;
                }
                else
                {
                    divSuKien.Visible = false;

                }

                var getListDangoai = from hs in db.tbHocSinhs
                                     join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                                     join l in db.tbLops on hstl.lop_id equals l.lop_id
                                     join tb in db.tbVietNhatKids_NgoaiKhoas on l.khoi_id equals tb.khoi_id
                                     where hs.hocsinh_taikhoan == Request.Cookies["web_hocsinh"].Value
                                     && hstl.namhoc_id == namhoc_id
                                    && !db.tbVietNhatKids_NgoaiKhoa_LichSus.Any(x => (x.ngoaikhoa_id == tb.ngoaikhoa_id))
                                     select tb;
                if (getListDangoai.Count() > 0)
                {
                    divDaNgoai.Visible = true;
                }
                else
                {
                    divDaNgoai.Visible = false;

                }
            }
            catch { }
        }
        else
        {
            Response.Redirect("/website-vietnhatkids-login");
        }
    }

 
}