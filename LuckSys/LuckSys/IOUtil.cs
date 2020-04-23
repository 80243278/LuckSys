using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
namespace LuckSys
{
    /// <summary>
    /// 数据库类(用于保存奖项信息)
    /// </summary>
    class IOUtil
    {

        #region 写入到数据文件中
        /// <summary>
        /// 写入到数据文件中
        /// </summary>
        /// <param name="list">奖项的集合</param>
        public static void WriteFile(List<Prize> list)
        {
           

            try
            {
                //将奖项的集合，通过io流的方式，写入到指定文件
                using (StreamWriter sw = new StreamWriter(Application.StartupPath + @"\db\jiangPin.dat", false, Encoding.GetEncoding("GB2312")))
                {
                    
                    int id = 1;
                    foreach (Prize p in list)
                    {
                        //因为我是使用了Split()方法，按","分割，防止读取时出错
                        //将带有","的属性值，替换为 乱码。。。。
                        if (p.JiangXiang.IndexOf(",") != -1)
                        {
                            p.JiangXiang = p.JiangXiang.Replace(",", "脨嬱婨");
                        } if (p.PrizeName.IndexOf(",") != -1)
                        {
                            p.PrizeName = p.PrizeName.Replace(",", "脨嬱婨");
                        }
                        //从新给奖项id赋值
                        p.ID = id++;
                        sw.WriteLine(p.ID + "," + p.JiangXiang + "," + p.PrizeName + "," + p.PrizeCount + "," + p.ShengYuCount);

                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }
        #endregion


        #region 读取奖项信息文件到集合中

        /// <summary>
        /// 读取奖项信息文件到集合中
        /// </summary>
        /// <returns>奖项集合</returns>
        public static List<Prize> ReadFile()
        {

            List<Prize> list=new List<Prize>();
            try
            {
                //将指定文件痛过io流读到指定集合中奖项的集合
                using (StreamReader sr = new StreamReader(Application.StartupPath + @"\db\jiangPin.dat",Encoding.GetEncoding("GB2312")))
                {
                    string s = null;
                    while ((s=sr.ReadLine())!=null)
                    {
                        string[] str = s.Split(',');
                        Prize p = new Prize();
                        
                        p.ID = Convert.ToInt32(str[0]);
                        p.JiangXiang = str[1];
                        if (p.JiangXiang.IndexOf("脨嬱婨") != -1) {
                           p.JiangXiang=p.JiangXiang.Replace("脨嬱婨", ",");
                        }
                        p.PrizeName = str[2];
                        if (p.PrizeName.IndexOf("脨嬱婨") != -1) {
                            p.PrizeName = p.PrizeName.Replace("脨嬱婨", ",");
                        }
                        p.PrizeCount = Convert.ToInt32(str[3]);
                        p.ShengYuCount = Convert.ToInt32(str[4]);
                        list.Add(p);
                    }
                     
                    
                }
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return list;
        }
        
        #endregion

    }
}
