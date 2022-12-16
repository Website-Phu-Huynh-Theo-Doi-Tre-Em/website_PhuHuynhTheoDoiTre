using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_NewsCate
/// </summary>
public class cls_downloadfile
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_downloadfile()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool Linq_Them(string file_content, string filename)
    {
        tbFileDownLoad insert = new tbFileDownLoad();
        insert.filedownload_name = filename;
        insert.fildownload_content = file_content;
        db.tbFileDownLoads.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int download_id, string file_content, string filename)
    {
        tbFileDownLoad update = db.tbFileDownLoads.Where(x => x.filedownload_id == download_id).FirstOrDefault();
        update.filedownload_name = filename;
        update.fildownload_content = file_content;
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
    public bool Linq_Xoa( int newscate_id)
    {
        tbFileDownLoad delete = db.tbFileDownLoads.Where(x => x.filedownload_id == newscate_id).FirstOrDefault();
        db.tbFileDownLoads.DeleteOnSubmit(delete);
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