using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Text.RegularExpressions;
namespace LuckSys
{
     /**************
      * 指导教师:聂小颖 
      * 作者：张力文
      * 日期：2016年12月5号
      * 项目名称：抽奖系统
      * 
      * ************/
    /// <summary>
    /// 奖项管理
    /// </summary>
    public partial class frmPrize : Form
    {
        /// <summary>
        /// 主窗体对象 
        /// </summary>

        public Main main;


        public frmPrize()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 奖项管理构造函数
        /// </summary>
        /// <param name="main">主窗体对象</param>
        public frmPrize(Main main)
        {
            InitializeComponent();
            this.main = main;
        }

        #region 修改按钮
        private void btnSave_Click(object sender, EventArgs e)
        {
            //没选中不继续
            if (dgvList.SelectedRows.Count == 0)
            {
                return;
            }
            //非空验证
            if (txtJiangXiang.Text.Trim().Equals("") || txtjiangpin.Text.Trim().Equals("") || txtPrizeCount.Text.Trim().Equals(""))
            {
                MessageBox.Show("请完善信息", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //修改操作
            if (dgvList.SelectedRows.Count > 0)
            {
                //获取选中的id
                int id = Convert.ToInt32(dgvList.SelectedRows[0].Cells["id"].Value);
                //循环奖品集合
                foreach (Prize p in this.main.prizeList)
                {
                    //如果集合的某个id等于选中的id的话，进行修改操作
                    if (p.ID == id)
                    {
                        p.JiangXiang = txtJiangXiang.Text;
                        p.PrizeName = txtjiangpin.Text;
                        //放报错
                        if (dgvList.SelectedRows.Count > 0)
                        {
                           //如果输入的奖品总数不等于dgv中的选中行的奖品总数的话，或者 剩余商品为0的时候 可以更新
                            if (!txtPrizeCount.Text.Equals(dgvList.SelectedRows[0].Cells["prizeCount"].Value.ToString()) || dgvList.SelectedRows[0].Cells["c"].Value.ToString().Equals("0"))
                            {
                                p.PrizeCount = Convert.ToInt32(txtPrizeCount.Text);
                               //将更新后的商品总数，赋值给剩余商品数量
                                //也就是说，每更新一次商品总数后，剩余数量都和商品总数保持一致
                               p.ShengYuCount = p.PrizeCount;
                            }
                        }
                        MessageBox.Show("修改成功", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }


            }
            //重新绑定div
            BindData();
        }
        #endregion


        #region 窗体加载
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPrize_Load(object sender, EventArgs e)
        {
            //如果奖项信息不为空时
            if (main.globalPrize != null)
            {
                //调用方法，查出现有奖项信息
                Prize p = main.getPrizeByPrizeId(main.globalPrize.ID);
                //防异常处理
                if (p != null)
                {
                    //将奖项信息中的商品数量存在集合中
                    p.ShengYuCount = main.globalPrize.ShengYuCount;
                }
                //将奖项状态名称赋值给奖项状态
                lblStatu.Text = main.globalPrize.JiangXiang;
                //系统设置了奖项信息不可见时
                if (!main.lblJiangPin.Visible)
                {
                    //在后面加上已隐藏
                    lblStatu.Text += "  已隐藏";
                }
            }
            else
            {
                //如果没设置奖项的话，奖品为无
                lblStatu.Text = "无";
            }
            //绑定dgv控件
            BindData();

            //如果数据为空时，修改文本框不启用
            if (dgvList.Rows.Count == 0)
            {
                txtJiangXiang.Enabled = false;
                txtjiangpin.Enabled = false;
                txtPrizeCount.Enabled = false;
            }


        }
        #endregion


        #region 改变选中单元格
        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            //获取选中的行数
            int row = dgvList.SelectedRows.Count;
            if (row > 0)
            {
                //将text控件启用，并将数据读到控件中  
                txtJiangXiang.Enabled = true;
                txtjiangpin.Enabled = true;
                txtPrizeCount.Enabled = true;
                txtJiangXiang.Text = dgvList.SelectedRows[0].Cells["jiangXiang"].Value.ToString();
                txtjiangpin.Text = dgvList.SelectedRows[0].Cells["jiangPin"].Value.ToString();
                txtPrizeCount.Text = dgvList.SelectedRows[0].Cells["prizeCount"].Value.ToString();
                lbl_shengyu.Text = dgvList.SelectedRows[0].Cells["c"].Value.ToString();
            }
            else
            {
                //将控件禁用
                txtJiangXiang.Enabled = false;
                txtjiangpin.Enabled = false;
                txtPrizeCount.Enabled = false;
            }

        }
        #endregion


        #region 绑定dgv控件
        /// <summary>
        /// 绑定dgv控件
        /// </summary>
        public void BindData()
        {


            BindingList<Prize> list = new BindingList<Prize>(); ;
            if (main.prizeList.Count > 0)
            {
                list = new BindingList<Prize>(main.prizeList);
            }

            dgvList.DataSource = list;


        }
        #endregion


        #region 删除按钮
        private void btn_del_Click(object sender, EventArgs e)
        {

            if (dgvList.SelectedRows.Count > 0)
            {
                //获取选中的id值
                int id = Convert.ToInt32(dgvList.CurrentRow.Cells["id"].Value.ToString());
                //根据奖项id查找奖项对象
                Prize p = main.getPrizeByPrizeId(id);

                if (main.globalPrize != null)
                {
                    //要删除正在使用的奖项时
                    if (main.globalPrize.ID == id)
                    {
                        //将使用的奖项清空
                        main.globalPrize = null;
                        //把奖项显示区的文字，设为无奖项，提示语
                        main.lblJiangPin.Text = Init.readInfo("jiangXiangPro");
                        //将奖项状态设为无
                        lblStatu.Text = "无";
                    }
                }

                if (!Init.readInfo("id").Equals(""))
                {
                    //配置文件中的id等于选中的id
                    if (Convert.ToInt32(Init.readInfo("id")) == id)
                    {
                        //清空id的值
                        Init.WriteInfo("id", "");
                    }
                }

                if (p != null)
                {
                    //从奖品集合中S将它删除
                    main.prizeList.Remove(p);
                }
                //从新绑定dgv控件
                BindData();
                MessageBox.Show("删除成功", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }
        #endregion


        #region 关闭按钮
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


        #region  双击单元格
        private void dgvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (dgvList.SelectedRows.Count > 0)
            {
                //如果剩余为0时，不能选择
                string shengyu = dgvList.CurrentRow.Cells["c"].Value.ToString();
                if (shengyu.Equals("0"))
                {
                    MessageBox.Show("该奖项剩余奖品为0，不能选择！请从新设置奖品数量！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            
            //将选中的信息输出到主页面的奖项显示区
            String jiangXiang = dgvList.CurrentRow.Cells["jiangXiang"].Value.ToString();
            String JiangPin = dgvList.CurrentRow.Cells["JiangPin"].Value.ToString();
            main.globalPrize = new Prize(jiangXiang, JiangPin);
            main.lblJiangPin.Text = "奖项名:" + jiangXiang + "    " + "奖品名:" + JiangPin;
             //奖项显示区 设置为可见，并将状态写到配置文件
            main.lblJiangPin.Visible = true;
            Init.WriteInfo("JiangPinInfo", "true");
            //设置完奖项后，将号码区的数字归零，但集合不动
            string str = "";
            main.number.Text = str.PadLeft(main.number.Text.Length, '0');
           
            if (dgvList.SelectedRows.Count > 0)
            {
                //将选中的奖项信息 设置为当前使用的奖项
                Prize p = new Prize();
                p.ID = Convert.ToInt32(dgvList.CurrentRow.Cells["id"].Value);
                p.JiangXiang = dgvList.CurrentRow.Cells["jiangXiang"].Value.ToString();
                p.PrizeName = dgvList.CurrentRow.Cells["jiangPin"].Value.ToString();
                p.PrizeCount = Convert.ToInt32(dgvList.CurrentRow.Cells["PrizeCount"].Value.ToString());
                p.ShengYuCount = Convert.ToInt32(dgvList.CurrentRow.Cells["c"].Value.ToString());
                main.globalPrize = p;
                //改变奖项状态文字：为当前奖项
                lblStatu.Text = p.JiangXiang;
            }
            //并将奖项id写入配置文件
            Init.WriteInfo("id", dgvList.CurrentRow.Cells["id"].Value.ToString());
        }
        #endregion



        #region 不设置奖项按钮
        private void btn_noSet_Click(object sender, EventArgs e)
        {
            //将所有的信息清空
            Init.WriteInfo("id", "");
            lblStatu.Text = "无";
            //并显示不设置奖项时候的提示语
            main.lblJiangPin.Text = Init.readInfo("jiangXiangPro");
            main.globalPrize = null;
            MessageBox.Show("设置成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        #endregion


        #region 删除行时的事件
        private void dgvList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //如果删除后 行数为0的话，清空所有文本
            if (dgvList.SelectedRows.Count <= 0)
            {
                txtjiangpin.Text = "";
                txtJiangXiang.Text = "";
                txtPrizeCount.Text = "";
                lbl_shengyu.Text = "";
            }
        }
       
        #endregion


        #region 商品总数文字改变时
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
                    //MessageBox.Show("系统只支持四位以下的数字");
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


        #region 新增商品按鈕
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddPrize faf = new frmAddPrize(this);
            faf.ShowDialog();
        }   
        #endregion  
     


    }
}
