using System;
using System.Collections;
using System.Web;
using System.IO;
using System.Drawing;
using System.Net;
using System.Configuration;

/// <summary>
///UpLoad 的摘要说明
/// </summary>
public class UpLoad
{
	public UpLoad()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}



    /// <summary>
    /// 文件上传方法
    /// </summary>
    /// <param name="postedFile">文件流</param>
    /// <param name="isThumbnail">是否生成缩略图</param>
    /// <param name="isWater">是否打水印</param>
    /// <returns>上传后文件信息</returns>
    public string fileSaveAs(HttpPostedFile postedFile, bool isThumbnail, bool isWater)
    {
        try
        {
            string fileExt = Utils.GetFileExt(postedFile.FileName); //文件扩展名，不含“.”
            int fileSize = postedFile.ContentLength; //获得文件大小，以字节为单位
            string fileName = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf(@"\") + 1); //取得原文件名
            string newFileName = Utils.GetRamCode() + "." + fileExt; //随机生成新的文件名
            string newThumbnailFileName = "thumb_" + newFileName; //随机生成缩略图文件名
            string upLoadPath = GetUpLoadPath(); //上传目录相对路径
            string fullUpLoadPath = Utils.GetMapPath(upLoadPath); //上传目录的物理路径
            string newFilePath = upLoadPath + newFileName; //上传后的路径
            string newThumbnailPath = upLoadPath + newThumbnailFileName; //上传后的缩略图路径

            //检查文件扩展名是否合法
            if (!CheckFileExt(fileExt))
            {
                return "{\"status\": 0, \"msg\": \"不允许上传" + fileExt + "类型的文件！\"}";
            }
            //检查文件大小是否合法
            if (!CheckFileSize(fileExt, fileSize))
            {
                return "{\"status\": 0, \"msg\": \"文件超过限制的大小啦！\"}";
            }
            //检查上传的物理路径是否存在，不存在则创建
            if (!Directory.Exists(fullUpLoadPath))
            {
                Directory.CreateDirectory(fullUpLoadPath);
            }

            //保存文件
            postedFile.SaveAs(fullUpLoadPath + newFileName);
        
            //处理完毕，返回JOSN格式的文件信息
            return "{\"status\": 1, \"msg\": \"上传文件成功！\", \"name\": \""
                + fileName + "\", \"path\": \"" + newFilePath + "\", \"thumb\": \""
                + newThumbnailPath + "\", \"size\": " + fileSize + ", \"ext\": \"" + fileExt + "\"}";
        }
        catch
        {
            return "{\"status\": 0, \"msg\": \"上传过程中发生意外错误！\"}";
        }
    }

    #region 私有方法

    /// <summary>
    /// 返回上传目录相对路径
    /// </summary>
    /// <param name="fileName">上传文件名</param>
    private string GetUpLoadPath()
    {
        string path =  "/upload/"; //站点目录+上传目录
        //switch (this.siteConfig.filesave)
        //{
        //    case 1: //按年月日每天一个文件夹
        //        path += DateTime.Now.ToString("yyyyMMdd");
        //        break;
        //    default: //按年月/日存入不同的文件夹
                path += DateTime.Now.ToString("yyyyMM") + "/" + DateTime.Now.ToString("dd");
        //        break;
        //}
        return path + "/";
    }



    /// <summary>
    /// 是否为图片文件
    /// </summary>
    /// <param name="_fileExt">文件扩展名，不含“.”</param>
    private bool IsImage(string _fileExt)
    {
        ArrayList al = new ArrayList();
        al.Add("bmp");
        al.Add("jpeg");
        al.Add("jpg");
        al.Add("gif");
        al.Add("png");
        if (al.Contains(_fileExt.ToLower()))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 检查是否为合法的上传文件
    /// </summary>
    private bool CheckFileExt(string _fileExt)
    {
        //检查危险文件
        string[] excExt = { "asp", "aspx", "php", "jsp", "htm", "html" };
        for (int i = 0; i < excExt.Length; i++)
        {
            if (excExt[i].ToLower() == _fileExt.ToLower())
            {
                return false;
            }
        }
        //检查合法文件
        string[] allowExt = "gif,jpg,png,bmp,rar,zip,doc,xls,txt".Split(',');
        for (int i = 0; i < allowExt.Length; i++)
        {
            if (allowExt[i].ToLower() == _fileExt.ToLower())
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 检查文件大小是否合法
    /// </summary>
    /// <param name="_fileExt">文件扩展名，不含“.”</param>
    /// <param name="_fileSize">文件大小(B)</param>
    private bool CheckFileSize(string _fileExt, int _fileSize)
    {
        //判断是否为图片文件
        if (IsImage(_fileExt))
        {
            if (10240 > 0 && _fileSize > 10240 * 1024)
            {
                return false;
            }
        }
        else
        {
            if (51200 > 0 && _fileSize > 51200 * 1024)
            {
                return false;
            }
        }
        return true;
    }

    #endregion
}