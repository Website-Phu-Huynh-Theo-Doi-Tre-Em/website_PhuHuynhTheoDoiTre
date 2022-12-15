using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_News
/// </summary>
public class cls_TaoHocsinhtronglop
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_TaoHocsinhtronglop()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Luu(int account_id, int lop_id,int monhoc_id)
    {
        // tao moi 1 doi tuong ( them vao bang ghi trong bang table hoc sinh trong lop)
        tbHocSinhTrongLop insert = new tbHocSinhTrongLop();
        // chen du lieu vao tuong truong
        insert.hocsinh_id = account_id;
        insert.lop_id = lop_id;
        //insert.monhoc_id = monhoc_id;
        insert.hstl_tinhtrang = false;
        // thuc thi cau lenh insert
        db.tbHocSinhTrongLops.InsertOnSubmit(insert);
        //Khi thêm học sinh vào lớp thì lấy ngầy hôm đó cho ngày bắt đầu học
        try
        {
            // luu xuong database
            db.SubmitChanges();
            return true;
        }
        catch
        {
            // neu gap loi ko ro thi se tra ve tinh trang false
            return false;
        }
    }
}