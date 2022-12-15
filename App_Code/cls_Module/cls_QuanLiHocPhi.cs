using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_News
/// </summary>
public class cls_QuanLiHocPhi
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_QuanLiHocPhi()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(int txtMahocsinh, string txtTenHocPhi, string txtTongTien, string dtDate, string txtTongTienDaNop, int coso_id)
    {
        tbHocPhi hs = new tbHocPhi();
        hs.hocsinh_id = txtMahocsinh;
        hs.hocphi_ten = txtTenHocPhi;
        hs.hocphi_tongtien = txtTongTien;
        hs.hocphi_ngaybatdau = Convert.ToDateTime(dtDate);
        hs.hocphi_tiendanop = txtTongTienDaNop;
        hs.coso_id = coso_id;
        hs.hidden = false;
        db.tbHocPhis.InsertOnSubmit(hs);
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
    public bool Linq_Sua(int txtMahocsinh, string txtTenHocPhi, string txtTongTien, string dtDate, string txtTongTienDaNop, int coso_id)
    {
        tbHocPhi hs = db.tbHocPhis.Where(x => x.hocsinh_id == txtMahocsinh).FirstOrDefault();
        hs.hocsinh_id = txtMahocsinh;
        hs.hocphi_ten = txtTenHocPhi;
        hs.hocphi_tongtien = txtTongTien;
        hs.hocphi_ngaybatdau = Convert.ToDateTime(dtDate);
        hs.hocphi_tiendanop = txtTongTienDaNop;
        hs.coso_id = coso_id;
        hs.hidden = false;
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
        tbHocPhi delete = db.tbHocPhis.Where(x => x.hocphi_id == news_id).FirstOrDefault();
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