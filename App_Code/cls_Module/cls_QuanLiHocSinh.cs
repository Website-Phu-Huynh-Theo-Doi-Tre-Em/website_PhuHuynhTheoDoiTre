using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_News
/// </summary>
public class cls_QuanLiHocSinh
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_QuanLiHocSinh()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(string txtMahocsinh, string txtHoHocSinh, string txtTenhocsinh, string dtDate, string txtDiaChi, bool rdFeMale, string txtTenBa, string txtSDTBa, string txtEmailBa, string txtNgheNghiepBa, string txtTenMe, string txtSDTMe, string txtEmailMe, string txtNgheNghiepMe, string news_image, int coso_id,string taikhoan)
    {
        tbHocSinh hs = new tbHocSinh();
        hs.hocsinh_code = txtMahocsinh;
        hs.hocsinh_hohocsinh = txtHoHocSinh;
        hs.hocsinh_name = txtTenhocsinh;
        hs.hocsinh_ngaysinh = Convert.ToDateTime(dtDate);
        hs.hocsinh_noio = txtDiaChi;
        if (rdFeMale)
        {
            hs.hocsinh_gioitinh = false;
        }
        else
        {
            hs.hocsinh_gioitinh = true;
        }

        hs.hocsinh_tenba = txtTenBa;
        hs.hocsinh_sdtba = txtSDTBa;
        hs.hocsinh_eamilba = txtEmailBa;
        hs.hocsinh_nghenghiepba = txtNgheNghiepBa;

        hs.hocsinh_tenme = txtTenMe;
        hs.hocsinh_sdtme = txtSDTMe;
        hs.hocsinh_eamilme = txtEmailMe;
        hs.hocsinh_nghenghiepme = txtNgheNghiepMe;
        hs.hocsinh_image = news_image;
        hs.coso_id = coso_id;
        if (txtEmailBa != "")
        {
            hs.hocsinh_email = txtEmailBa;
        }
        else
        {
            hs.hocsinh_email = txtEmailMe;
        }
        hs.hocsinh_pass = "12378248145104161527610811213823414203124130";
        hs.hocsinh_taikhoan = taikhoan;
        db.tbHocSinhs.InsertOnSubmit(hs);
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
    public bool Linq_Sua(int hs_id, string txtMahocsinh, string txtHoHocSinh, string txtTenhocsinh, string dtDate, string txtDiaChi, bool rdFeMale, string txtTenBa, string txtSDTBa, string txtEmailBa, string txtNgheNghiepBa, string txtTenMe, string txtSDTMe, string txtEmailMe, string txtNgheNghiepMe, string news_image, int coso_id, string taikhoan)
    {

        tbHocSinh hs = db.tbHocSinhs.Where(x => x.hocsinh_id == hs_id).FirstOrDefault();
        hs.hocsinh_code = txtMahocsinh;
        hs.hocsinh_hohocsinh = txtHoHocSinh;
        hs.hocsinh_name = txtTenhocsinh;
        hs.hocsinh_ngaysinh = Convert.ToDateTime(dtDate);
        hs.hocsinh_noio = txtDiaChi;
        if (rdFeMale)
        {
            hs.hocsinh_gioitinh = false;
        }
        else
        {
            hs.hocsinh_gioitinh = true;
        }

        hs.hocsinh_tenba = txtTenBa;
        hs.hocsinh_sdtba = txtSDTBa;
        hs.hocsinh_eamilba = txtEmailBa;
        hs.hocsinh_nghenghiepba = txtNgheNghiepBa;

        hs.hocsinh_tenme = txtTenMe;
        hs.hocsinh_sdtme = txtSDTMe;
        hs.hocsinh_eamilme = txtEmailMe;
        hs.hocsinh_nghenghiepme = txtNgheNghiepMe;
        hs.coso_id = coso_id;
        hs.hocsinh_image = news_image;
        hs.hocsinh_taikhoan = taikhoan;
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
    public bool Linq_Xoa(int news_id)
    {
        tbHocSinh delete = db.tbHocSinhs.Where(x => x.hocsinh_id == news_id).FirstOrDefault();
        delete.hidden = true;
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
}