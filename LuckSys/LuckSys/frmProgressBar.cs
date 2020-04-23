using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    /// 进度条窗体
    /// </summary>
    public partial class frmProgressBar : Form
    {
        public frmProgressBar()
        {
            InitializeComponent();
        }

        #region 更新进度条的进度，和显示的文字
        /// <summary>
        /// 更新进度条的进度，和显示的文字
        /// </summary>
        /// <param name="percent"></param>
        /// <param name="message"></param>
        public void SetNotifyInfo(int percent, string message)
        {
            this.label1.Text = message;
            this.progressBar1.Value = percent;
        }  
        #endregion
     
    }
}
