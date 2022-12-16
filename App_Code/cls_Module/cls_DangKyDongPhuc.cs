using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_News
/// </summary>
public class cls_DangKyDongPhuc
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_DangKyDongPhuc()
    {
        //
        // TODO: Add constructor logic here
        //
    }
   //xác nhận đăng ký đồng phục
    public bool Linq_XacNhan(int news_id)
    {
        tbVietNhatKids_DangKyDongPhuc update = db.tbVietNhatKids_DangKyDongPhucs.Where(x => x.dongphuc_id == news_id).FirstOrDefault();
        update.dongphuc_tinhtrang = true;
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
    //xác nhận đăng ký ngoại khóa
    public bool Linq_XacNhanNgoaiKhoa(int dangkyngoaikhoa_id)
    {
        tbVietNhatKids_DangKyNgoaiKhoa update = db.tbVietNhatKids_DangKyNgoaiKhoas.Where(x => x.dangkyngoaikhoa_id == dangkyngoaikhoa_id).FirstOrDefault();
        update.dangkyngoaikhoa_tinhtrang = 1;//vp xác nhận
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