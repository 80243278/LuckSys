using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace LuckSys
{
     /*************
      * 指导教师:聂小颖 
      * 作者：张力文
      * 日期：2016年12月5号
      * 项目名称：抽奖系统
      * ************/
    /// <summary>
    /// 添加奖品窗体
    /// </summary>
    public partial class frmAddPrize : Form
    {


        /// <summary>
        /// 奖品窗体的对象
        /// </summary>
        private frmPrize frmPrize;
 
        /// <summary> 
        ///添加奖品的构造函数
        /// <summary> 
        public frmAddPrize()
        {
            InitializeComponent();
        }

        #region 添加奖品构造函数
        /// <summary>
        /// 添加奖品构造函数
        /// </summary>
        /// <param name="frmPrize">奖品窗体的对象</param>
        public frmAddPrize(frmPrize frmPrize)
        {
            InitializeComponent();
            this.frmPrize = frmPrize;
        }

        #endregion

        #region 返回按钮
        /// <summary>
        ///   返回按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 增加按鈕
        private void btnSave_Click(object sender, EventArgs e)
        {

            //非空验证
            if (txtJiangXiang.Text.Trim().Equals("") || txtjiangpin.Text.Trim().Equals("") || txtPrizeCount.Text.Trim().Equals(""))
            {
                MessageBox.Show("请完善信息", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //增加
            Prize p = new Prize();
            p.ID = ++frmPrize.main.prizeId;
            p.PrizeName = txtjiangpin.Text;
            p.JiangXiang = txtJiangXiang.Text;
            p.PrizeCount = Convert.ToInt32(txtPrizeCount.Text);
            p.ShengYuCount = p.PrizeCount;
            //将奖品加入到奖品集合中
            frmPrize.main.prizeList.Add(p);
            MessageBox.Show("添加成功", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Close();
            //更新奖品列表的datagridview
            frmPrize.BindData();
        }
        #endregion

        #region 奖品数量只能输入1-9999
        //匹配数字1-9999的正则表达式 
        private string pattern = @"(^[1-9]\d{0,3}$)";
        private string param1 = null;
        private void txtPrizeCount_TextChanged(object sender, EventArgs e)
        {
            if (this.txtPrizeCount.Text.Trim() == "")
            {
                txtPrizeCount.Text = "";
            }
            else
            {
                Match m = Regex.Match(this.txtPrizeCount.Text, pattern);   // 匹配正则表达式

                if (!m.Success)   // 输入的不是数字
                {

                    this.txtPrizeCount.Text = param1;   // textBox内容不变
                    // 将光标定位到文本框的最后
                    this.txtPrizeCount.SelectionStart = this.txtPrizeCount.Text.Length;
                    MessageBox.Show("奖品总数只能在1-9999之间", "非法输入", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else   // 输入的是数字
                {
                    param1 = this.txtPrizeCount.Text;   // 将现在textBox的值保存下来
                }
            }
        }
        #endregion
  
    }

}
