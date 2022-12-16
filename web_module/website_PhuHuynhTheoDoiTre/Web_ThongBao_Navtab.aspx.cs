using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_module_website_Web_ThongBao_Navtab : System.Web.UI.Page
{
    public int STT = 1;
    public int STTT = 1;
    private int namhoc_id;
    dbcsdlDataContext db = new dbcsdlDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["web_hocsinh"] != null)
        {
            namhoc_id = (from nm in db.tbHoctap_NamHocs
                         orderby nm.namhoc_id descending
                         select nm.namhoc_id
                                   ).First();
            var getThongBaoTruong = from tb in db.tbLoaiThongBaos
                                    join tbt in db.tbThongBaos on tb.loaithongbao_ID equals tbt.loaithongbao_ID
                                    orderby tbt.thongbao_id descending
                                    where tbt.loaithongbao_ID == 1 && tbt.namhoc_id == namhoc_id
                                    select new
                                    {
                                        tbt.thongbao_title,
                                        tbt.thongbao_id,
                                        tbt.thongbao_content,
                                        tbt.loaithongbao_ID
                                    };
            var getThongBaoLop = from hs in db.tbHocSinhs
                                 join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                                 join l in db.tbLops on hstl.lop_id equals l.lop_id
                                 join tb in db.tbThongBaos on l.lop_id equals tb.lop_id
                                 orderby tb.thongbao_id descending
                                 where tb.loaithongbao_ID == 2 && tb.namhoc_id == namhoc_id && hs.hocsinh_taikhoan == Request.Cookies["web_hocsinh"].Value
                                 select new
                                 {
                                     tb.thongbao_title,
                                     tb.thongbao_id,
                                     tb.thongbao_content
                                 };
            if (!IsPostBack)
            {
                txtLoaiThongBao.Value = "thongbaotruong";
                rpThongBaoChiTiet.DataSource = getThongBaoTruong.Take(1);
                rpThongBaoChiTiet.DataBind();
                rpThongBao.DataSource = getThongBaoTruong.Skip(1);
                rpThongBao.DataBind();
                txtID.Value = getThongBaoTruong.First().thongbao_id.ToString();

                rpThongBaoChiTietLop.DataSource = getThongBaoLop.Take(1);
                rpThongBaoChiTietLop.DataBind();
                rpThongBaoLop.DataSource = getThongBaoLop.Skip(1);
                rpThongBaoLop.DataBind();
                if (getThongBaoLop.Count() > 0)
                {
                    txtIDTBLop.Value = getThongBaoLop.First().thongbao_id.ToString();

                }
                else
                {
                    txtIDTBLop.Value = "";
                }

            }
            if (txtID.Value != "" && txtIDTBLop.Value != "")
            {
                int id = Convert.ToInt32(txtID.Value);
                var gettbtruong = getThongBaoTruong.Where(x => x.thongbao_id == id);
                rpThongBaoChiTiet.DataSource = gettbtruong;
                rpThongBaoChiTiet.DataBind();
                rpThongBao.DataSource = getThongBaoTruong.Except(gettbtruong).OrderByDescending(x => x.thongbao_id);
                rpThongBao.DataBind();

                int idl = Convert.ToInt32(txtIDTBLop.Value);
                var gettblop = getThongBaoLop.Where(x => x.thongbao_id == idl);
                rpThongBaoChiTietLop.DataSource = gettblop;
                rpThongBaoChiTietLop.DataBind();
                rpThongBaoLop.DataSource = getThongBaoLop.Except(gettblop).OrderByDescending(x => x.thongbao_id);
                rpThongBaoLop.DataBind();
            }
        }
        else
        {
            Response.Redirect("/website-dang-nhap");
        }


    }

    protected void btnXemThongBaoTruong_ServerClick(object sender, EventArgs e)
    {

    }

    protected void btn_ThongBaoLop_ServerClick(object sender, EventArgs e)
    {

    }
}