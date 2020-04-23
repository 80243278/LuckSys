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
    /// 中奖信息类
    /// </summary>
   public class Luck
    {

        public Luck()
        {

        }
       /// <summary>
       /// 中奖信息构造函数
       /// </summary>
       /// <param name="id">中奖的顺序号</param>
       /// <param name="number">中奖号码</param>
       /// <param name="batchNum">中奖的轮次</param>
       /// <param name="p">奖项信息</param>
        public Luck(Int32 id, String number, int batchNum, Prize p)
        {
            this.id = id;
            this.number = number;
            this.batchNum = batchNum;
            this.Prize = p;
        }


        /// <summary>
        /// 中奖序号
        /// </summary>

        public int id { get; set; }
        /// <summary>
        /// 中奖号码
        /// </summary>

        public string number { get; set; }
        /// <summary>
        /// 表示第几轮中的奖
        /// </summary>
        public int batchNum { get; set; }
        /// <summary>
        /// 奖品信息
        /// </summary>
        public Prize Prize { get; set; }

    }
}
