using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_DiemDanh_module_Nhap_DanhSachHocSinhAnSang : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _id;
    private int _idCoSo;
    private int _idUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserName"] != null)
        {
            var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
            var checkNamHoc= (from nh in db.tbHoctap_NamHocs orderby nh.namhoc_id descending select nh).First();
            _idCoSo = Convert.ToInt32(checkuserid.coso_id);
            _idUser = checkuserid.username_id;
            if (!IsPostBack)
            {

                //var listKhoi = from k in db.tbKhois
                //                   //join cs in db.tbCoSoVietNhats on k.coso_id equals cs.coso_id
                //                   //join u in db.admin_Users on cs.coso_id equals u.coso_id
                //               where k.coso_id == _idCoSo
                //               orderby k.khoi_id
                //               select k;
                //ddlKhoi.Items.Clear();
                //ddlKhoi.Items.Insert(0, "Chọn khối");
                //ddlKhoi.AppendDataBoundItems = true;
                //ddlKhoi.DataTextField = "khoi_name";
                //ddlKhoi.DataValueField = "khoi_id";
                //ddlKhoi.DataSource = listKhoi;
                //ddlKhoi.DataBind();
                //if (ddlKhoi.Text == "Chọn khối")
                //{

                //}
                //else
                //{
                //    var listNV = from l in db.tbLops
                //                 join k in db.tbKhois on l.khoi_id equals k.khoi_id
                //                 //join cs in db.tbCoSoVietNhats on l.coso_id equals cs.coso_id
                //                 //join u in db.admin_Users on cs.coso_id equals u.coso_id
                //                 where k.coso_id == _idCoSo && k.khoi_id == Convert.ToInt32(ddlKhoi.SelectedValue)
                //                 orderby l.khoi_id
                //                 select l;
                //    ddlLop.Items.Clear();
                //    ddlLop.Items.Insert(0, "Chọn Lớp");
                //    ddlLop.AppendDataBoundItems = true;
                //    ddlLop.DataTextField = "lop_name";
                //    ddlLop.DataValueField = "lop_id";
                //    ddlLop.DataSource = listNV;
                //    ddlLop.DataBind();
                //}
                var listNV = from l in db.tbLops
                             join gvtl in db.tbGiaoVienTrongLops on l.lop_id equals gvtl.lop_id
                             where gvtl.taikhoan_id == checkuserid.username_id
                             && gvtl.namhoc_id == checkNamHoc.namhoc_id
                             select l;
                ddlLop.Items.Clear();
                ddlLop.Items.Insert(0, "Chọn Lớp");
                ddlLop.AppendDataBoundItems = true;
                ddlLop.DataTextField = "lop_name";
                ddlLop.DataValueField = "lop_id";
                ddlLop.DataSource = listNV;
                ddlLop.DataBind();
                Session["_id"] = 0;
            }

            loadData();
        }
        else
        {
            Response.Redirect("/admin-login");
        }
    }
    private void loadData()
    {
        var checkNamHoc = (from nh in db.tbHoctap_NamHocs orderby nh.namhoc_id descending select nh).FirstOrDefault();
        if (ddlLop.SelectedValue == "0" || ddlLop.SelectedValue == "Chọn Lớp")
        {

        }
        else
        {
            var getData = from hs in db.tbHocSinhs
                          join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                          join l in db.tbLops on hstl.lop_id equals l.lop_id
                          where hstl.namhoc_id == checkNamHoc.namhoc_id && l.lop_id == Convert.ToInt16(ddlLop.SelectedValue)
                          select new
                          {
                              hs.hocsinh_name,
                              l.lop_name,
                              hstl.hstl_id
                          };

            //var getDataBiLock = from hs in db.tbHocSinhs
            //                    join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
            //                    join l in db.tbLops on hstl.lop_id equals l.lop_id
            //                    join a in db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs on hstl.hstl_id equals a.hstl_id
            //                    where hstl.namhoc_id == checkNamHoc.namhoc_id && l.lop_id == Convert.ToInt16(ddlLop.SelectedValue) && a.ansang_hidden == true
            //                    select new
            //                    {
            //                        hs.hocsinh_name,
            //                        l.lop_name,
            //                        hstl.hstl_id
            //                    };

            //load ds đã đăng ký
            var getDataBiLock = from hs in db.tbHocSinhs
                                join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                                join l in db.tbLops on hstl.lop_id equals l.lop_id
                                join a in db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs on hstl.hstl_id equals a.hstl_id
                                where hstl.namhoc_id == checkNamHoc.namhoc_id && l.lop_id == Convert.ToInt16(ddlLop.SelectedValue)
                                select new
                                {
                                    hs.hocsinh_name,
                                    l.lop_name,
                                    hstl.hstl_id
                                };
            var list = getData.Except(getDataBiLock);
            grvList.DataSource = list;
            grvList.DataBind();
        }
    }

    //protected void ddlKhoi_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
    //    if (ddlKhoi.Text == "Chọn khối")
    //    {

    //    }
    //    else
    //    {
    //        var listNV = from l in db.tbLops
    //                     join k in db.tbKhois on l.khoi_id equals k.khoi_id
    //                     //join cs in db.tbCoSoVietNhats on l.coso_id equals cs.coso_id
    //                     //join u in db.admin_Users on cs.coso_id equals u.coso_id
    //                     where k.coso_id == Convert.ToInt32(checkuserid.coso_id) && k.khoi_id == Convert.ToInt32(ddlKhoi.SelectedValue)
    //                     orderby l.khoi_id
    //                     select l;
    //        ddlLop.Items.Clear();
    //        ddlLop.Items.Insert(0, "Chọn Lớp");
    //        ddlLop.AppendDataBoundItems = true;
    //        ddlLop.DataTextField = "lop_name";
    //        ddlLop.DataValueField = "lop_id";
    //        ddlLop.DataSource = listNV;
    //        ddlLop.DataBind();
    //    }
    //}
    protected void btnLuu_ServerClick(object sender, EventArgs e)
    {
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "hstl_id" });
        if (dteNgayBatDau.Value == "")
        {
            alert.alert_Warning(Page, "Vui lòng chọn ngày bắt đầu", "");
        }
        else if (selectedKey.Count > 0)
        {
            db.Connection.Open();
            using (var transaction = db.Connection.BeginTransaction())
            {
                db.Transaction = transaction;
                try
                {
                    foreach (var item in selectedKey)
                    {
                        var checkHocSinh = from ck in db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs
                                           where ck.hstl_id == Convert.ToInt32(item)
                                           select ck;
                        //if (checkHocSinh.Count() > 0)
                        //{
                        //    checkHocSinh.FirstOrDefault().ansang_datecreate = Convert.ToDateTime(dteNgayBatDau.Value);
                        //    checkHocSinh.FirstOrDefault().ansang_tinhtrang = true;
                        //    checkHocSinh.FirstOrDefault().uongsua_tinhtrang = null;
                        //    checkHocSinh.FirstOrDefault().ansang_ngaydangky = DateTime.Now;
                        //    checkHocSinh.FirstOrDefault().username_id = _idUser;
                        //    db.SubmitChanges();
                        //}
                        //else
                        //{
                        tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSang insert = new tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSang();
                        insert.ansang_datecreate = Convert.ToDateTime(dteNgayBatDau.Value);
                        insert.ansang_tinhtrang = true;
                        insert.hstl_id = Convert.ToInt32(item);
                        insert.coso_id = _idCoSo;
                        insert.username_id = _idUser;
                        insert.ansang_ngaydangky = DateTime.Now;
                        db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs.InsertOnSubmit(insert);
                        db.SubmitChanges();
                        //}
                    }
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Đã hoàn thành!','','success').then(function(){grvList.UnselectRows();})", true);
        }
        else
        {
            alert.alert_Warning(Page, "Vui lòng chọn học sinh", "");
        }
    }

    protected void btnLuuUongSua_ServerClick(object sender, EventArgs e)
    {
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "hstl_id" });
        if (dteNgayBatDau.Value == "")
        {
            alert.alert_Warning(Page, "Vui lòng chọn ngày bắt đầu", "");
        }
        else if (selectedKey.Count > 0)
        {
            db.Connection.Open();
            using (var transaction = db.Connection.BeginTransaction())
            {
                db.Transaction = transaction;
                try
                {
                    foreach (var item in selectedKey)
                    {
                        var checkHocSinh = from ck in db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs
                                           where ck.hstl_id == Convert.ToInt32(item)
                                           select ck;
                        //if (checkHocSinh.Count() > 0)
                        //{
                        //    checkHocSinh.FirstOrDefault().ansang_datecreate = Convert.ToDateTime(dteNgayBatDau.Value);
                        //    checkHocSinh.FirstOrDefault().ansang_tinhtrang = null;
                        //    checkHocSinh.FirstOrDefault().uongsua_tinhtrang = true;
                        //    checkHocSinh.FirstOrDefault().ansang_ngaydangky = DateTime.Now;
                        //    checkHocSinh.FirstOrDefault().username_id = _idUser;
                        //    db.SubmitChanges();
                        //}
                        //else
                        //{
                        tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSang insert = new tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSang();
                        insert.ansang_datecreate = Convert.ToDateTime(dteNgayBatDau.Value);
                        insert.uongsua_tinhtrang = true;
                        insert.hstl_id = Convert.ToInt32(item);
                        insert.coso_id = _idCoSo;
                        insert.username_id = _idUser;
                        insert.ansang_ngaydangky = DateTime.Now;
                        db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs.InsertOnSubmit(insert);
                        db.SubmitChanges();
                        //}
                    }
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Đã hoàn thành!','','success').then(function(){grvList.UnselectRows();})", true);
        }
        else
        {
            alert.alert_Warning(Page, "Vui lòng chọn học sinh", "");
        }
    }

    protected void btnCoAnSangCoUongSua_ServerClick(object sender, EventArgs e)
    {
        List<object> selectedKey = grvList.GetSelectedFieldValues(new string[] { "hstl_id" });
        if (dteNgayBatDau.Value == "")
        {
            alert.alert_Warning(Page, "Vui lòng chọn ngày bắt đầu", "");
        }
        else if (selectedKey.Count > 0)
        {
            db.Connection.Open();
            using (var transaction = db.Connection.BeginTransaction())
            {
                db.Transaction = transaction;
                try
                {
                    foreach (var item in selectedKey)
                    {
                        var checkHocSinh = from ck in db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs
                                           where ck.hstl_id == Convert.ToInt32(item)
                                           select ck;
                        //if (checkHocSinh.Count() > 0)
                        //{
                        //    checkHocSinh.FirstOrDefault().ansang_datecreate = Convert.ToDateTime(dteNgayBatDau.Value);
                        //    checkHocSinh.FirstOrDefault().ansang_ngaydangky = DateTime.Now;
                        //    checkHocSinh.FirstOrDefault().username_id = _idUser;
                        //    db.SubmitChanges();
                        //}
                        //else
                        //{
                        tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSang insert = new tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSang();
                        insert.ansang_datecreate = Convert.ToDateTime(dteNgayBatDau.Value);
                        insert.ansang_tinhtrang = true;
                        insert.uongsua_tinhtrang = true;
                        insert.hstl_id = Convert.ToInt32(item);
                        insert.coso_id = _idCoSo;
                        insert.username_id = _idUser;
                        db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs.InsertOnSubmit(insert);
                        db.SubmitChanges();
                        //}
                    }
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert", "swal('Đã hoàn thành!','','success').then(function(){grvList.UnselectRows();})", true);
        }
        else
        {
            alert.alert_Warning(Page, "Vui lòng chọn học sinh", "");
        }
    }
}