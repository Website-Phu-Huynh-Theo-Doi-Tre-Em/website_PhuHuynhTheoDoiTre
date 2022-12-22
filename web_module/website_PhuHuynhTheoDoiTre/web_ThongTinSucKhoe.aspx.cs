using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_ThongTinSucKhoe : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    public int STT = 1;
    int _idNamHoc = 0;
    string _sdtHocSinh = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["web_hocsinh"] != null)
        {
            _sdtHocSinh = Request.Cookies["web_hocsinh"].Value;
            var getNamHoc = from hs in db.tbHocSinhs
                            join sk in db.tbThongTinSucKhoes on hs.hocsinh_id equals sk.hocsinh_id
                            join nh in db.tbHoctap_NamHocs on sk.namhoc_id equals nh.namhoc_id
                            where hs.hocsinh_taikhoan == _sdtHocSinh
                            orderby nh.namhoc_nienkhoa descending
                            group nh by nh.namhoc_id into gr
                            select new
                            {
                                suckhoe_namhoc_id = gr.Key,
                                suckhoe_namhoc_name = (from nhnk in db.tbHoctap_NamHocs where nhnk.namhoc_id == gr.Key select nhnk).FirstOrDefault().namhoc_nienkhoa
                            };
            var getNam = (from n in db.tbHoctap_NamHocs
                          orderby n.namhoc_id descending
                          select n).FirstOrDefault();
            lblNam.Text = getNam.namhoc_nienkhoa;
            var getData = from hs in db.tbHocSinhs
                          join sk in db.tbThongTinSucKhoes on hs.hocsinh_id equals sk.hocsinh_id
                          join lt in db.tbThangs on Convert.ToInt32( sk.suckhoe_thang) equals lt.thang_id
                          join nh in db.tbHoctap_NamHocs on sk.namhoc_id equals nh.namhoc_id
                          where hs.hocsinh_taikhoan == _sdtHocSinh && nh.namhoc_id == getNam.namhoc_id
                          orderby sk.suckhoe_id ascending
                          select new
                          {
                              sk.suckhoe_chieucao,
                              sk.suckhoe_cannang,
                              sk.suckhoe_ghichu,
                              lt.thang_name
                          };
            rpSucKhoe.DataSource = getData;
            rpSucKhoe.DataBind();
            txtThang.Value = String.Join(",", getData.Select(y => y.thang_name));
            txtCanNang.Value = String.Join(",", getData.Select(y => y.suckhoe_cannang));
            txtChieuCao.Value = String.Join(",", getData.Select(y => y.suckhoe_chieucao));
        }
        else
        {
            Response.Redirect("/website-trang-chu");
        }
    }
}