using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    dbcsdlDataContext db = new dbcsdlDataContext();
    public int STT;
    cls_Alert alert = new cls_Alert();
    private static int _idUser;
    private static int CoSo;
    private static int _idNamhoc;
    public int tong_filechung = 0, tong_file_coso1 = 0, tong_file_coso2 = 0, tong_file_coso3 = 0;
    public string ten_tuan, phienche_namhoc;
    protected void Page_Load(object sender, EventArgs e)
    {
    }
}