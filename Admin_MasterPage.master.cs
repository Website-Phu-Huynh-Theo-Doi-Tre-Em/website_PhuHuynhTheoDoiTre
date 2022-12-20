using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_MasterPage : System.Web.UI.MasterPage
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public string adminName, count, ThongBao_SoLieu, count_congvannoibo, count_congvanmoi;
    public string thongbaoNghi, thongbaoThuoc, thongbaoNgoaiKhoa, thongbaoDKXe, thongbaoDKDongPhuc, thongbaoThuGopY;
    public int UserID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            admin_User getusername = Session["AdminLogined"] as admin_User;
            adminName = Request.Cookies["UserName"].Value;
            loadMenu();
            //chuyển sang trang profile nếu click vào item profile
            var getUser = (from u in db.admin_Users
                           where u.username_username == Request.Cookies["UserName"].Value
                           select u).FirstOrDefault();
            var checkNamHoc = (from nh in db.tbHoctap_NamHocs orderby nh.namhoc_id descending select nh).FirstOrDefault();
            UserID = Convert.ToInt32(getUser.username_id);
            //thong bao icon show list
            thongbaoNghi = (from phxn in db.tbPhuHuynhXinNghis
                            join hstl in db.tbHocSinhTrongLops on phxn.hstl_id equals hstl.hstl_id
                            join gvtl in db.tbGiaoVienTrongLops on hstl.lop_id equals gvtl.lop_id
                            //join hs in db.tbHocSinhs on hstl.hocsinh_id equals hs.hocsinh_id
                            where phxn.phuhuynhxinnghi_xacnhan == false && hstl.namhoc_id == checkNamHoc.namhoc_id
                            && gvtl.namhoc_id == checkNamHoc.namhoc_id && gvtl.taikhoan_id == getUser.username_id
                            select phxn).Count() + "";
            thongbaoThuoc = (from ddt in db.tbDanDoThuocs
                             join hstl in db.tbHocSinhTrongLops on ddt.hstl_id equals hstl.hstl_id
                             join gvtl in db.tbGiaoVienTrongLops on hstl.lop_id equals gvtl.lop_id
                             //join hs in db.tbHocSinhs on hstl.hocsinh_id equals hs.hocsinh_id
                             where ddt.phuhuynhdandothuoc_tinhtrang == false && hstl.namhoc_id == checkNamHoc.namhoc_id
                            && gvtl.namhoc_id == checkNamHoc.namhoc_id && gvtl.taikhoan_id == getUser.username_id
                             select ddt).Count() + "";
            //nếu mà gvcn thì bắt theo lớp, ngược lại là get theo cs

        }
        else
        {
            Response.Redirect("/website_PhuHuynhTheoDoiTre/admin_page/adminl_Login.aspx");
        }
    }
    protected void btnLogout_ServerClick(object sender, EventArgs e)
    {
        HttpCookie ck = new HttpCookie("UserName");
        string s = ck.Value;
        ck.Value = "";  //set a blank value to the cookie 
        ck.Expires = DateTime.Now.AddDays(-1);
        Response.Cookies.Add(ck);
        Response.Redirect("/website_PhuHuynhTheoDoiTre/admin_page/adminl_Login.aspx");
    }

    private void loadMenu()
    {
        admin_User logedMember = (from tk in db.admin_Users where tk.username_username == Request.Cookies["UserName"].Value select tk).SingleOrDefault();
        int _idUser = Convert.ToInt32(logedMember.username_id);
        int _idGUer = Convert.ToInt32(logedMember.groupuser_id);

        //var getMenu = from gum in db.admin_AccessGroupUserModules
        //              join m in db.admin_Modules on gum.module_id equals m.module_id
        //              orderby m.module_position
        //              where gum.groupuser_id == _idGUer
        //              && gum.gum_active == true
        //              && (from f in db.admin_Forms
        //                  join guf in db.admin_AccessGroupUserForms on f.form_id equals guf.form_id
        //                  join uf in db.admin_AccessUserForms on guf.form_id equals uf.form_id
        //                  where f.module_id == m.module_id
        //                  && guf.groupuser_id == _idGUer
        //                  && guf.guf_active == true
        //                  && uf.uf_active == true
        //                  && uf.username_id == _idUser
        //                  select f).Count() > 0
        //              select new
        //              {
        //                  gum.module_id,
        //                  m.module_name,
        //                  open0 = db.admin_Forms.Where(x => "/" + x.form_link == HttpContext.Current.Request.Url.AbsolutePath && x.module_id == m.module_id).Count() > 0 ? "open" : "",
        //                  open = db.admin_Forms.Where(x => "/" + x.form_link == HttpContext.Current.Request.Url.AbsolutePath && x.module_id == m.module_id).Count() > 0 ? "collapse in" : ""
        //              };

        //rpModule.DataSource = getMenu;
        //rpModule.DataBind();
    }

}
