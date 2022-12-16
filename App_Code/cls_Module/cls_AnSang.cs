using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_NewsCate
/// </summary>
public class cls_AnSang
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_AnSang()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool Linq_Xoa( int newscate_id)
    {
        tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSang delete = db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs.Where(x => x.ansang_id == newscate_id).FirstOrDefault();
        db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs.DeleteOnSubmit(delete);
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
    public bool Linq_HuyAnSang(int ansang_id, DateTime ngay_apdung)
    {
        tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSang huy = db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs.Where(x => x.ansang_id == ansang_id).FirstOrDefault();
        //huy.ansang_tinhtrang = false; //hủy ăn sáng
        //huy.ansang_ngayhuy = DateTime.Now;
        //huy.ansang_ngayapdunghuy = ngay_apdung;
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
    public bool Linq_HuyUongSua(int ansang_id, DateTime ngay_apdung)
    {
        tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSang huy = db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs.Where(x => x.ansang_id == ansang_id).FirstOrDefault();
        //huy.uongsua_tinhtrang = false; //hủy uống sữa
        //huy.ansang_ngayhuy = DateTime.Now;
        //huy.ansang_ngayapdunghuy = ngay_apdung;
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
    public bool Linq_HuyAnSanUongSua(int ansang_id, DateTime ngay_apdung)
    {
        tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSang huy = db.tbQuanLyLop_DiemDanh_DanhSachHocSinh_AnSangs.Where(x => x.ansang_id == ansang_id).FirstOrDefault();
        //huy.ansang_tinhtrang = false; //hủy ăn sáng
        //huy.uongsua_tinhtrang = false; //hủy uống sữa
        //huy.ansang_ngayhuy = DateTime.Now;
        //huy.ansang_ngayapdunghuy = ngay_apdung;
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