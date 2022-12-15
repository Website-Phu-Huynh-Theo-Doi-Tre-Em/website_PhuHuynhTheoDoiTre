using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_page_module_function_module_VietNhatKids_module_NhanXetGiaoVien : System.Web.UI.Page
{
    //Connect Database
    dbcsdlDataContext db = new dbcsdlDataContext();
    cls_Alert alert = new cls_Alert();
    private int _idUser;
    //STT
    public int STT = 1;

    public int id = 1;
    public string mystyle;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            div_Notification.Visible = false;
            div_KetQua.Visible = false;
        }
        loadData();
        var checkuserid = (from u in db.admin_Users where u.username_username == Request.Cookies["UserName"].Value select u).First();
        _idUser = checkuserid.username_id;
        //Date now
        lblDateCreate.Text = DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss");
        var checkNamHoc = (from nh in db.tbHoctap_NamHocs orderby nh.namhoc_id descending select nh).First();

    }

    protected void loadData()
    {
        if (Request.Cookies["UserName"] != null)
        {
            var checkNamHoc = (from nh in db.tbHoctap_NamHocs orderby nh.namhoc_id descending select nh).First();
            //Lay truong du lieu tu bang Lop, User, GiaoVienTrongLop
            var getLop = (from gvtl in db.tbGiaoVienTrongLops
                          join l in db.tbLops on gvtl.lop_id equals l.lop_id
                          join user in db.admin_Users on gvtl.taikhoan_id equals user.username_id
                          where user.username_username == Request.Cookies["UserName"].Value
                          && gvtl.namhoc_id == checkNamHoc.namhoc_id
                          select new
                          {
                              l.lop_id,
                              l.lop_name,
                              user.username_id
                          }).SingleOrDefault();

            //kiểm tra xem ngày hôm đó giáo viên đã điểm danh lớp học chưa
            //nếu đã điểm danh rồi thì cho nhận xét, ngược lại thì thông báo giáo viên vào điểm danh
            var checkDiemDanh = from ddhs in db.tbDiemDanh_HocSinhs
                                join hstl in db.tbHocSinhTrongLops on ddhs.hstl_id equals hstl.hstl_id
                                where hstl.lop_id == getLop.lop_id
                                && ddhs.diemdanh_ngay.Value.Date == Convert.ToDateTime(DateTime.Now).Date
                                && ddhs.diemdanh_ngay.Value.Month == Convert.ToDateTime(DateTime.Now).Month
                                && ddhs.diemdanh_ngay.Value.Year == Convert.ToDateTime(DateTime.Now).Year
                                select ddhs;
            if (checkDiemDanh.Count() > 0)
            {
                div_Notification.Visible = false;
                div_KetQua.Visible = true;

                rpSetLop.Text = getLop.lop_name;
                var listHocSinh = (from hs in db.tbHocSinhs
                                   join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                                   join gvtl in db.tbGiaoVienTrongLops on hstl.lop_id equals gvtl.lop_id
                                   join user in db.admin_Users on gvtl.taikhoan_id equals user.username_id
                                   where user.username_username == Request.Cookies["UserName"].Value
                                    && gvtl.namhoc_id == checkNamHoc.namhoc_id
                                    && hstl.namhoc_id == checkNamHoc.namhoc_id
                                    && hstl.hidden==false
                                   select new
                                   {
                                       hs.hocsinh_name,
                                       hs.hocsinh_id,
                                       hstl.hstl_id,
                                       nhanxet = db.tbVietNhatKids_NhanXetThuongXuyens.Any(x => x.nhanxetthuongxuyen_datecreate.Value.Day == DateTime.Now.Day
                                                  && x.nhanxetthuongxuyen_datecreate.Value.Month == DateTime.Now.Month
                                                  && x.nhanxetthuongxuyen_datecreate.Value.Year == DateTime.Now.Year
                                                  && x.nhanxetthuongxuyen_cate == "nhanxetthuongxuyen" && x.hstl_id == hstl.hstl_id) ? (from nx in db.tbVietNhatKids_NhanXetThuongXuyens
                                                                                                                                        where nx.nhanxetthuongxuyen_datecreate.Value.Day == DateTime.Now.Day
                                                                                                                                        && nx.nhanxetthuongxuyen_datecreate.Value.Month == DateTime.Now.Month
                                                                                                                                        && nx.nhanxetthuongxuyen_datecreate.Value.Year == DateTime.Now.Year
                                                                                                                                        && nx.nhanxetthuongxuyen_cate == "nhanxetthuongxuyen" && nx.hstl_id == hstl.hstl_id
                                                                                                                                        orderby nx.nhanxetthuongxuyen_id descending
                                                                                                                                        select nx.nhanxetthuongxuyen_content).First() : "",
                                       tinhtrang = (from nx in db.tbVietNhatKids_NhanXetThuongXuyens
                                                    where nx.nhanxetthuongxuyen_datecreate.Value.Day == DateTime.Now.Day
                                                    && nx.nhanxetthuongxuyen_datecreate.Value.Month == DateTime.Now.Month
                                                    && nx.nhanxetthuongxuyen_datecreate.Value.Year == DateTime.Now.Year
                                                    && nx.nhanxetthuongxuyen_cate == "nhanxetthuongxuyen" && nx.hstl_id == hstl.hstl_id
                                                    orderby nx.nhanxetthuongxuyen_id descending
                                                    select nx.nhanxetthuongxuyen_content).First() != "" ? "hocsinh__active" : "",
                                       //mystyle = db.tbVietNhatKids_NhanXetThuongXuyens.Any(x => x.nhanxetthuongxuyen_datecreate.Value.Day == DateTime.Now.Day
                                       //                                                         && x.nhanxetthuongxuyen_datecreate.Value.Month == DateTime.Now.Month
                                       //                                                          && x.nhanxetthuongxuyen_datecreate.Value.Year == DateTime.Now.Year
                                       //                                                          && x.nhanxetthuongxuyen_cate == "nhanxetthuongxuyen" && x.username_id == _idUser) == true ? "" : "button__disable"
                                   });

                //get những ds học sinh vắng trong ngày
                var checkVangHoc = from hs in db.tbHocSinhs
                                   join hstl in db.tbHocSinhTrongLops on hs.hocsinh_id equals hstl.hocsinh_id
                                   join l in db.tbLops on hstl.lop_id equals l.lop_id
                                   join ck in db.tbDiemDanh_HocSinhs on hstl.hstl_id equals ck.hstl_id
                                   where (ck.tinhtrang == "Vắng không phép" || ck.tinhtrang == "Vắng có phép")
                                   && hstl.namhoc_id == checkNamHoc.namhoc_id && l.lop_id == getLop.lop_id
                                   && (ck.diemdanh_ngay.Value.Date == Convert.ToDateTime(DateTime.Now).Date
                                   && ck.diemdanh_ngay.Value.Month == Convert.ToDateTime(DateTime.Now).Month
                                   && ck.diemdanh_ngay.Value.Year == Convert.ToDateTime(DateTime.Now).Year)
                                    && hstl.hidden == false
                                   select new
                                   {
                                       hs.hocsinh_name,
                                       hs.hocsinh_id,
                                       hstl.hstl_id,
                                       nhanxet = "",
                                       tinhtrang = "",
                                       //mystyle = ck.username_id == _idUser ? "" : "button__disable"
                                   };
                var ketqua = listHocSinh.Except(checkVangHoc);
                rpDanhSachHocSinh.DataSource = ketqua;
                rpDanhSachHocSinh.DataBind();
                rpNoiDungHocSinh.DataSource = ketqua;
                rpNoiDungHocSinh.DataBind();
                txtDanhSachHocSinhID.Value = string.Join(";", ketqua.Select(x => x.hstl_id).ToArray());

                //trường hợp ngày đó chưa có ai nhận xét thì hiện nút lưu bt
                //kiểm tra nếu ngày hôm đó đã có gv nhận xét rồi thì gv khác vào không nhận xét nữa
                if (db.tbVietNhatKids_NhanXetThuongXuyens.Any(x => x.nhanxetthuongxuyen_datecreate.Value.Day == DateTime.Now.Day
                                    && x.nhanxetthuongxuyen_datecreate.Value.Month == DateTime.Now.Month
                                    && x.nhanxetthuongxuyen_datecreate.Value.Year == DateTime.Now.Year
                                    && x.nhanxetthuongxuyen_cate == "nhanxetthuongxuyen"
                                    && x.lop_id == getLop.lop_id && x.namhoc_id == checkNamHoc.namhoc_id))
                {
                    var checkNhanXet = (from nx in db.tbVietNhatKids_NhanXetThuongXuyens
                                        where nx.nhanxetthuongxuyen_datecreate.Value.Day == DateTime.Now.Day
                                        && nx.nhanxetthuongxuyen_datecreate.Value.Month == DateTime.Now.Month
                                        && nx.nhanxetthuongxuyen_datecreate.Value.Year == DateTime.Now.Year
                                        && nx.nhanxetthuongxuyen_cate == "nhanxetthuongxuyen"
                                        && nx.lop_id == getLop.lop_id && nx.namhoc_id == checkNamHoc.namhoc_id
                                        && nx.username_id == getLop.username_id
                                        orderby nx.nhanxetthuongxuyen_id descending
                                        select nx);
                    if (checkNhanXet.Count() > 0)
                    {
                        mystyle = "display:inline-block";
                    }
                    else
                    {
                        mystyle = "display:none";
                    }
                }
                else
                {
                    mystyle = "display:inline-block";
                }
            }
            else
            {
                div_Notification.Visible = true;
                div_KetQua.Visible = false;
            }
        }
        else
        {
            Response.Redirect("/admin-login");
        }
    }

    public bool Save(DateTime date, String content, int hs_id)
    {
        tbVietNhatKids_NhanXetThuongXuyen insert = new tbVietNhatKids_NhanXetThuongXuyen();
        insert.nhanxetthuongxuyen_datecreate = date;
        insert.nhanxetthuongxuyen_content = content;
        insert.hstl_id = hs_id;
        db.tbVietNhatKids_NhanXetThuongXuyens.InsertOnSubmit(insert);
        try
        {
            db.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    protected void btnLuuTong_ServerClick(object sender, EventArgs e)
    {
        //int sodau = Convert.ToInt16(txtHocSinhDau.Value);
        //int socuoi = Convert.ToInt16(txtHocSinhCuoi.Value);

        var checkNamHoc = (from nh in db.tbHoctap_NamHocs orderby nh.namhoc_id descending select nh).First();
        var checkuserid = (from u in db.admin_Users
                           join gvtl in db.tbGiaoVienTrongLops on u.username_id equals gvtl.taikhoan_id
                           where u.username_username == Request.Cookies["UserName"].Value
                           && gvtl.namhoc_id == checkNamHoc.namhoc_id
                           select new
                           {
                               u.username_id,
                               gvtl.lop_id
                           }).First();
        var checkLichSu = from ls in db.tbLichSus
                          where ls.username_id == checkuserid.username_id
                          && ls.lichsu_date.Value.Day == DateTime.Now.Day
                           && ls.lichsu_date.Value.Month == DateTime.Now.Month
                             && ls.lichsu_date.Value.Year == DateTime.Now.Year
                             && ls.danhsachcongviec_id == 4
                          select ls;

        if (txtContentTong.Value == "")
        {
            alert.alert_Warning(Page, "Vui lòng chọn nhập dung nhận xét!", "");
        }
        else
        {
            db.Connection.Open();
            using (var transaction = db.Connection.BeginTransaction())
            {
                db.Transaction = transaction;
                try
                {
                    //đánh dấu hoàn thành công việc trong ngày
                    if (checkLichSu.Count() > 0)
                    {
                    }
                    else
                    {
                        tbLichSu insertls = new tbLichSu();
                        insertls.danhsachcongviec_id = 4;
                        insertls.username_id = checkuserid.username_id;
                        insertls.lichsu_class = ".time_line_5cf90ca818fa82";
                        insertls.lichsu_date = DateTime.Now;
                        insertls.lichsu_diemtichluy = 1;
                        db.tbLichSus.InsertOnSubmit(insertls);
                        db.SubmitChanges();
                    }
                    string[] arrListStr = txtContentTong.Value.Split(';');
                    string[] arrHocSinh = txtDanhSachHocSinhID.Value.Split(';');
                    for (int i = 0; i < arrHocSinh.Length; i++)
                    {
                        //kiểm tra xem ngày hnay bé đã được nhận xét chưa. Nếu đã nhận xét rồi thì cập nhật, ngược lại là thêm mới
                        var checkNhanXet = (from nx in db.tbVietNhatKids_NhanXetThuongXuyens
                                            where nx.nhanxetthuongxuyen_datecreate.Value.Day == DateTime.Now.Day
                                            && nx.nhanxetthuongxuyen_datecreate.Value.Month == DateTime.Now.Month
                                            && nx.nhanxetthuongxuyen_datecreate.Value.Year == DateTime.Now.Year
                                            && nx.nhanxetthuongxuyen_cate == "nhanxetthuongxuyen" && nx.hstl_id == Convert.ToInt32(arrHocSinh[i])
                                            orderby nx.nhanxetthuongxuyen_id descending
                                            select nx);
                        if (checkNhanXet.Count() > 0)
                        {
                            checkNhanXet.First().nhanxetthuongxuyen_datecreate = DateTime.Now;
                            checkNhanXet.First().nhanxetthuongxuyen_content = arrListStr[i].ToString();
                            checkNhanXet.First().username_id = checkuserid.username_id;
                            db.SubmitChanges();
                        }
                        else
                        {
                            tbVietNhatKids_NhanXetThuongXuyen insert = new tbVietNhatKids_NhanXetThuongXuyen();
                            insert.hstl_id = Convert.ToInt32(arrHocSinh[i]);
                            insert.nhanxetthuongxuyen_cate = "nhanxetthuongxuyen";
                            insert.nhanxetthuongxuyen_datecreate = DateTime.Now;
                            insert.nhanxetthuongxuyen_content = arrListStr[i].ToString();
                            insert.username_id = checkuserid.username_id;
                            insert.lop_id = checkuserid.lop_id;
                            insert.namhoc_id = checkNamHoc.namhoc_id;
                            db.tbVietNhatKids_NhanXetThuongXuyens.InsertOnSubmit(insert);
                            db.SubmitChanges();
                        }
                    }
                    alert.alert_Success(Page, "Hoàn thành", "");
                    loadData();
                    transaction.Commit();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "HiddenLoadingIcon()", true);
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }
    }

    protected void btnLuu_ServerClick(object sender, EventArgs e)
    {
        if (txtContent.Value == "")
        {
        }
        else
        {
            db.Connection.Open();
            using (var transaction = db.Connection.BeginTransaction())
            {
                db.Transaction = transaction;
                try
                {
                    var checkNamHoc = (from nh in db.tbHoctap_NamHocs orderby nh.namhoc_id descending select nh).First();
                    var checkuserid = (from u in db.admin_Users
                                       join gvtl in db.tbGiaoVienTrongLops on u.username_id equals gvtl.taikhoan_id
                                       where u.username_username == Request.Cookies["UserName"].Value
                                       && gvtl.namhoc_id == checkNamHoc.namhoc_id
                                       select new
                                       {
                                           u.username_id,
                                           gvtl.lop_id
                                       }).First();
                    var checkLichSu = from ls in db.tbLichSus
                                      where ls.username_id == checkuserid.username_id
                                      && ls.lichsu_date.Value.Day == DateTime.Now.Day
                                       && ls.lichsu_date.Value.Month == DateTime.Now.Month
                                         && ls.lichsu_date.Value.Year == DateTime.Now.Year
                                         && ls.danhsachcongviec_id == 4
                                      select ls;
                    //đánh dấu hoàn thành công việc trong ngày
                    if (checkLichSu.Count() > 0)
                    {
                    }
                    else
                    {
                        tbLichSu insertls = new tbLichSu();
                        insertls.danhsachcongviec_id = 4;
                        insertls.username_id = checkuserid.username_id;
                        insertls.lichsu_class = ".time_line_5cf90ca818fa82";
                        insertls.lichsu_date = DateTime.Now;
                        insertls.lichsu_diemtichluy = 1;
                        db.tbLichSus.InsertOnSubmit(insertls);
                        db.SubmitChanges();
                    }
                    //kiểm tra xem ngày hnay bé đã được nhận xét chưa. Nếu đã nhận xét rồi thì cập nhật, ngược lại là thêm mới
                    var checkNhanXet = (from nx in db.tbVietNhatKids_NhanXetThuongXuyens
                                        where nx.nhanxetthuongxuyen_datecreate.Value.Day == DateTime.Now.Day
                                        && nx.nhanxetthuongxuyen_datecreate.Value.Month == DateTime.Now.Month
                                        && nx.nhanxetthuongxuyen_datecreate.Value.Year == DateTime.Now.Year
                                        && nx.nhanxetthuongxuyen_cate == "nhanxetthuongxuyen" && nx.hstl_id == Convert.ToInt32(txtHocSinhID.Value)
                                        orderby nx.nhanxetthuongxuyen_id descending
                                        select nx);
                    if (checkNhanXet.Count() > 0)
                    {
                        checkNhanXet.First().nhanxetthuongxuyen_datecreate = DateTime.Now;
                        checkNhanXet.First().nhanxetthuongxuyen_content = txtContent.Value;
                        //checkNhanXet.First().username_id = checkuserid.username_id;
                        db.SubmitChanges();
                    }
                    else
                    {
                        tbVietNhatKids_NhanXetThuongXuyen insert = new tbVietNhatKids_NhanXetThuongXuyen();
                        insert.hstl_id = Convert.ToInt32(txtHocSinhID.Value);
                        insert.nhanxetthuongxuyen_cate = "nhanxetthuongxuyen";
                        insert.nhanxetthuongxuyen_datecreate = DateTime.Now;
                        insert.nhanxetthuongxuyen_content = txtContent.Value;
                        insert.username_id = checkuserid.username_id;
                        insert.lop_id = checkuserid.lop_id;
                        insert.namhoc_id = checkNamHoc.namhoc_id;
                        db.tbVietNhatKids_NhanXetThuongXuyens.InsertOnSubmit(insert);
                        db.SubmitChanges();
                    }
                    //alert.alert_Success(Page, "Hoàn thành", "");
                    loadData();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }
    }
}