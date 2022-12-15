using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_website_VietNhatKids_Web_ThongBao_Navtab : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    public int namhoc_id;
    private static int id_Lop;
    public int STT = 1;
    public int STTT = 1;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Cookies["web_hocsinh"] != null)
        {
            namhoc_id = (from nm in db.tbHoctap_NamHocs
                         orderby nm.namhoc_id descending
                         select nm.namhoc_id
                       ).First();
            var getlist = from hs in db.tbHocSinhs
                          join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                          join l in db.tbLops on hstl.lop_id equals l.lop_id
                          join tb in db.tbVietNhatKids_ThongBaoTruongs on l.khoi_id equals tb.khoi_id
                          where hs.hocsinh_taikhoan == Request.Cookies["web_hocsinh"].Value
                          && hstl.namhoc_id == namhoc_id
                          orderby tb.thongbaotruong_id descending
                          select new
                          {
                              tb.thongbaotruong_title,
                              tb.thongbaotruong_id,
                              tb.thongbaotruong_content,
                              style = (from ls in db.tbVietNhatKids_ThongBaoTruong_LichSus
                                       where ls.thongbaotruong_id == tb.thongbaotruong_id
                                       && ls.hstl_id == hstl.hstl_id
                                       select ls
                                  ).Count() > 0 ? "display:none" : " ",
                              hs.hocsinh_id,
                              hstl.hstl_id,
                              l.lop_id,
                              l.khoi_id
                          };
            var gettbl = from hs in db.tbHocSinhs
                         join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                         join l in db.tbLops on hstl.lop_id equals l.lop_id
                         join tb in db.tbVietNhatKids_ThongBaoLops on l.lop_id equals tb.lop_id
                         where hs.hocsinh_taikhoan == Request.Cookies["web_hocsinh"].Value
                         && hstl.namhoc_id == namhoc_id && tb.thongbaolop_tinhtrang == 2
                         orderby tb.thongbaoLop_id descending
                         select new
                         {
                             tb.thongbaoLop_title,
                             tb.thongbaoLop_id,
                             tb.thongbaoLop_content,
                             style = (from ls in db.tbVietNhatKids_ThongBaoLop_LichSus
                                      where ls.thongbaolop_id == tb.thongbaoLop_id
                                      && ls.hstl_id == hstl.hstl_id
                                      select ls
                                  ).Count() > 0 ? "display:none" : " ",
                             hs.hocsinh_id,
                             hstl.hstl_id,
                             l.lop_id,
                             l.khoi_id
                         };
            if (!IsPostBack)
            {
                txtLoaiThongBao.Value = "thongbaotruong";
                rpThongBaoChiTiet.DataSource = getlist.Take(1);
                rpThongBaoChiTiet.DataBind();
                rpThongBao.DataSource = getlist.Skip(1);
                rpThongBao.DataBind();
                txtID.Value = getlist.First().thongbaotruong_id.ToString();
                ThemLichSuXemTBT(Convert.ToInt32(getlist.First().thongbaotruong_id), DateTime.Now, getlist.FirstOrDefault().hocsinh_id, getlist.FirstOrDefault().hstl_id, getlist.FirstOrDefault().lop_id, Convert.ToInt32(getlist.FirstOrDefault().khoi_id));

                rpThongBaoChiTietLop.DataSource = gettbl.Take(1);
                rpThongBaoChiTietLop.DataBind();
                rpThongBaoLop.DataSource = gettbl.Skip(1);
                rpThongBaoLop.DataBind();
                if (gettbl.Count() > 0)
                {
                    txtIDTBLop.Value = gettbl.First().thongbaoLop_id.ToString();    
                    ThemLichSuXemTBL(Convert.ToInt32(gettbl.First().thongbaoLop_id), DateTime.Now, gettbl.FirstOrDefault().hocsinh_id, gettbl.FirstOrDefault().hstl_id, gettbl.FirstOrDefault().lop_id, Convert.ToInt32(gettbl.FirstOrDefault().khoi_id));

                }
                else
                {
                    txtIDTBLop.Value = "";
                }

            }
            //else 
            if (txtID.Value != "" && txtIDTBLop.Value != "")
            {
                int id = Convert.ToInt32(txtID.Value);
                var gettbtruong = getlist.Where(x => x.thongbaotruong_id == id);
                rpThongBaoChiTiet.DataSource = gettbtruong;
                rpThongBaoChiTiet.DataBind();
                rpThongBao.DataSource = getlist.Except(gettbtruong).OrderByDescending(x => x.thongbaotruong_id);
                rpThongBao.DataBind();
                ThemLichSuXemTBT(id, DateTime.Now, getlist.FirstOrDefault().hocsinh_id, getlist.FirstOrDefault().hstl_id, getlist.FirstOrDefault().lop_id, Convert.ToInt32(getlist.FirstOrDefault().khoi_id));

                int idl = Convert.ToInt32(txtIDTBLop.Value);
                var gettblop = gettbl.Where(x => x.thongbaoLop_id == idl);
                rpThongBaoChiTietLop.DataSource = gettblop;
                rpThongBaoChiTietLop.DataBind();
                rpThongBaoLop.DataSource = gettbl.Except(gettblop).OrderByDescending(x => x.thongbaoLop_id);
                rpThongBaoLop.DataBind();
                ThemLichSuXemTBL(idl, DateTime.Now, gettblop.FirstOrDefault().hocsinh_id, gettblop.FirstOrDefault().hstl_id, gettblop.FirstOrDefault().lop_id, Convert.ToInt32(gettblop.FirstOrDefault().khoi_id));
            }
        }
        else
        {
            Response.Redirect("/website-trang-chu");
        }
    }
    private void ThemLichSuXemTBT(int idthongbao, DateTime ngay, int idhocsinh, int idhstl, int idlop, int idkhoi)
    {
        tbVietNhatKids_ThongBaoTruong_LichSu insert = new tbVietNhatKids_ThongBaoTruong_LichSu();
        insert.thongbaotruong_id = idthongbao;
        insert.thongbaotruong_lichsu_ngayxem = ngay;
        insert.hocsinh_id = idhocsinh;
        insert.hstl_id = idhstl;
        insert.lop_id = idlop;
        insert.khoi_id = idkhoi;
        db.tbVietNhatKids_ThongBaoTruong_LichSus.InsertOnSubmit(insert);
        try
        {
            db.SubmitChanges();
        }
        catch
        {

        }
    }
    private void ThemLichSuXemTBL(int idthongbao, DateTime ngay, int idhocsinh, int idhstl, int idlop, int idkhoi)
    {
        tbVietNhatKids_ThongBaoLop_LichSu insert = new tbVietNhatKids_ThongBaoLop_LichSu();
        insert.thongbaolop_id = idthongbao;
        insert.thongbaolop_lichsu_ngayxem = ngay;
        insert.hocsinh_id = idhocsinh;
        insert.hstl_id = idhstl;
        insert.lop_id = idlop;
        insert.khoi_id = idkhoi;
        db.tbVietNhatKids_ThongBaoLop_LichSus.InsertOnSubmit(insert);
        try
        {
            db.SubmitChanges();
        }
        catch
        {

        }
    }
    protected void btnXemThongBaoTruong_ServerClick(object sender, EventArgs e)
    {

    }

    protected void btn_ThongBaoLop_ServerClick(object sender, EventArgs e)
    {

    }
}