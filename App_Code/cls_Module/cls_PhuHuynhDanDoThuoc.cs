using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_News
/// </summary>
public class cls_PhuHuynhDanDoThuoc
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_PhuHuynhDanDoThuoc()
    {
        //
        // TODO: Add constructor logic here
        //
    }
   
    public bool Linq_XacNhan(int news_id)
    {
        tbVietNhatKids_PhuHuynhDanDoThuoc update = db.tbVietNhatKids_PhuHuynhDanDoThuocs.Where(x => x.phuhuynhdandothuoc_id == news_id).FirstOrDefault();
        update.phuhuynhdandothuoc_tinhtrang = true;
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