using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
   /// 奖品类
   /// </summary>
   public class Prize
    {
        /// <summary>
        /// 奖项名称
        /// </summary>
        public String JiangXiang { get; set; }

       /// <summary>
       /// 奖品名称
       /// </summary>
        public String PrizeName { get; set; }

       /// <summary>
       /// 奖品的序号
       /// </summary>
        public Int32 ID { get; set; }
          
       /// <summary>
       /// 奖品总数
       /// </summary>
        public int PrizeCount { get; set; }

       /// <summary>
       /// 奖品剩余的数
       /// </summary>
        public int ShengYuCount { get; set; }

        public Prize() { }

       /// <summary>
       /// 奖品
       /// </summary>
       /// <param name="id"></param>
       /// <param name="jiangxiang"></param>
       /// <param name="prizeName"></param>
        public Prize(Int32 id,String jiangxiang,String prizeName) {
            JiangXiang = jiangxiang;
            PrizeName = prizeName;
            ID = id;
        }
        public Prize( String jiangxiang, String prizeName)
        {
            JiangXiang = jiangxiang;
            PrizeName = prizeName;
        }

    }
}
