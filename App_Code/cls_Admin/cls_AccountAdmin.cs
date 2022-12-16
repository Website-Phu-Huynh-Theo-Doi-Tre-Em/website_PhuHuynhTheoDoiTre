using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_NewsCate
/// </summary>
public class cls_AccountAdmin
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public cls_AccountAdmin()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Linq_Them(string username, string pass, string fullnanme, string phone, string email, string diachi)
    {
        admin_User insert = new admin_User();
        insert.username_username = username;
        insert.username_password = "12378248145104161527610811213823414203124130";
        insert.username_fullname = fullnanme;
        insert.username_phone = phone;
        insert.username_email = email;
        insert.username_diachi = diachi;
        db.admin_Users.InsertOnSubmit(insert);
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
    public bool Linq_Sua(int account_id, string username, string pass, string fullnanme, string phone, string email, int coso_id, string diachi)
    {
        admin_User update = db.admin_Users.Where(x => x.username_id == account_id).FirstOrDefault();
        update.username_username = username;
        //update.username_password = pass;
        update.username_fullname = fullnanme;
        update.username_phone = phone;
        update.username_email = email;
        update.username_active = true;
        update.username_diachi = diachi;
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
    public bool Linq_Xoa(int account_id)
    {
        admin_User delete = db.admin_Users.Where(x => x.username_id == account_id).FirstOrDefault();
        delete.username_active = false;
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