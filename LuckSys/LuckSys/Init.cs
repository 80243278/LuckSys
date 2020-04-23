using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace LuckSys
{
      /*************
       * 指导教师:聂小颖 
       * 作者：张力文
       * 日期：2016年12月5号
       * 项目名称：抽奖系统
       * 
       * ************/
    /// <summary>
    /// 读取配置文件类
    /// </summary>
    class Init
    {
        //获取当前项目地址
        private  static String path = System.Windows.Forms.Application.StartupPath;
        
       

        //写入配置文件的方法
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);

        //读取配置文件的方法
       [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
            string key, string def, StringBuilder retVal,
            int size, string filePath);

       #region 写入配置文件方法
       /// <summary>
       /// 写入配置文件方法
       /// </summary>
       /// <param name="key">键</param>
       /// <param name="val">值</param>
       public static void WriteInfo(String key, string val)
       {
           WritePrivateProfileString("init", key, val, path + "\\Init.ini");
       }

       #endregion

       #region 读取配置文件的方法
       /// <summary>
       /// 读取配置文件的方法
       /// </summary>
       /// <param name="key">键</param>
       /// <returns>返回要查询的值</returns>
       public static String readInfo(String key)
       {
           StringBuilder temp = new StringBuilder(255);
           GetPrivateProfileString("init", key, "", temp, 255, path + "\\Init.ini");
           return temp.ToString();
       }    
       #endregion
   
    }
}
