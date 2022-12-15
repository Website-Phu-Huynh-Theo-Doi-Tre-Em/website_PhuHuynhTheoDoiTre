<%@ WebHandler Language="C#" Class="ThumbNailHandler" %>

using System;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

public class ThumbNailHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        string imgPath = context.Request.QueryString["imgPath"];
        //get image width to be resized from querystring
        int imgwidth = Convert.ToInt32(context.Request.QueryString["width"]);
        //get image height to be resized from querystring
        int imgHeight = Convert.ToInt32(context.Request.QueryString["height"]);
        if (imgPath == "")
        {
            imgPath = "images/logo.jpg";
        }
        int W = imgwidth;
        int H = imgHeight;
        Image img = Image.FromFile(context.Server.MapPath(imgPath));

        H = img.Height * W / img.Width;

        //using (Bitmap avatar = DevExpress.Web.Internal.ImageUtils.CreateThumbnailImage((Bitmap)img, DevExpress.Web.ImageSizeMode.ActualSizeOrFit, new Size(W, H)))
        //{
        //    W = avatar.Width; H = avatar.Height; avatar.Dispose();
        //}
        Image _img = new Bitmap(W, H);
        Graphics g = Graphics.FromImage(_img);
        g.DrawImage(img, 0, 0, W, H);
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        System.Drawing.Rectangle rectDestination = new System.Drawing.Rectangle(0, 0, W, H);
        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
        g.Dispose();
        img.Dispose();
        MemoryStream str = new MemoryStream();
        _img = _img.GetThumbnailImage(W, H, null, IntPtr.Zero);
        _img.Save(str, System.Drawing.Imaging.ImageFormat.Jpeg);
        _img.Dispose();
        str.WriteTo(context.Response.OutputStream);
        str.Dispose();
        str.Close();
        context.Response.ContentType = ".Jpeg";
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}