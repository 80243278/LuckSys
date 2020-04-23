using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using ClosedXML.Excel;
using System.Threading;
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
    /// 获奖名单类
    /// </summary>
    public partial class info : Form
    {
        /// <summary>
        /// 主窗体对象
        /// </summary>
        Main main;
        /// <summary>
        /// 进度条窗体
        /// </summary>
        frmProgressBar notifyForm = new frmProgressBar();

        /// <summary>
        /// 导出方法里面需要的集合
        /// </summary>
        List<Luck> list = new List<Luck>();

        /// <summary>
        /// 获奖名单构造函数
        /// </summary>
        /// <param name="m">主窗体对象</param>
        public info(Main m)
        {
            InitializeComponent();
            this.main=m;
            // 使用BackgroundWorker时不能在工作线程中访问UI线程部分，  
            // 即你不能在BackgroundWorker的事件和方法中操作UI，否则会抛跨线程操作无效的异常  
            // 添加下列语句可以避免异常。  
            CheckForIllegalCrossThreadCalls = false;

            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
        }


        #region 窗体加载方法
        private void info_Load(object sender, EventArgs e)
        {
            //设置保存文本框的文件类型
            sfd.Filter = "Excel工作簿(*.xlsx)|*.xlsx";
        
        
            dgvList.AutoGenerateColumns = false;
            //设定本窗体的标题
            Text = "本轮获奖名单";

            if (main.batchPersonList.Count == 0)
            {
                lbl_Record.Text = "无中奖信息记录";
                btnRecord.Visible = false;
            }
            else
            {
                btnRecord.Visible = true;
                lbl_Record.Text = "本轮截止到目前共有" + main.batchPersonList.Count + "条中奖信息";
            }
            //调用方法绑定datagridview 传入本轮记录的集合
            bind(main.batchPersonList);

        }
       
        #endregion
 
        #region 绑定集合
        /// <summary>
        /// 将集合倒序排序，并绑定到datagridview
        /// </summary>
        /// <param name="list">要排序的中奖名单集合</param>
        private void bind(List<Luck> list)
        {

            //使原集合倒序排列
            List<Luck> templist = new List<Luck>();
            for (int i = 0; i < list.Count; i++)
            {
                templist.Add(list[i]);
            }
            templist.Reverse();
            dgvList.DataSource = templist;
        }
        #endregion

        #region 导出按钮
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (main.luckList.Count == 0||main.batchPersonList.Count==0)
            {
                MessageBox.Show("没有可导出记录", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //生成带时间戳的文件名
            DateTime dt = DateTime.Now;
             string fileName=null;
            if (btnExport.Text.Equals("导出本场所有记录"))
            {
              
               fileName=dt.Year + dt.Month.ToString().PadLeft(2, '0') + dt.Day.ToString().PadLeft(2, '0') + dt.Hour.ToString().PadLeft(2, '0') + dt.Minute.ToString().PadLeft(2, '0') + dt.Second.ToString().PadLeft(2, '0') + "全部抽奖记录.xlsx";
               list = main.luckList;
            }
            else {

                fileName = dt.Year + dt.Month.ToString().PadLeft(2, '0') + dt.Day.ToString().PadLeft(2, '0') + dt.Hour.ToString().PadLeft(2, '0') + dt.Minute.ToString().PadLeft(2, '0') + dt.Second.ToString().PadLeft(2, '0') + "第"+main.batchPersonList[0].batchNum+"轮抽奖记录.xlsx";
                list = main.batchPersonList ;
            }
            sfd.FileName = fileName;
            //显示另存为窗口
            DialogResult r = sfd.ShowDialog();
            if (r == DialogResult.OK)
            {
                string path = sfd.FileName;
                GetWorkBook(path);
                //调用开启线程，执行DoWork方法
                bw.RunWorkerAsync();
                notifyForm.ShowDialog();
                list = main.batchPersonList;
            }
        }        
        #endregion

        #region 关闭按钮
        //关闭按钮
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
  
        #region 导出到Excel的方法
        /// <summary>
        /// 导出到Excel的方法
        /// </summary>
        /// <param name="strFile">包含路径的文件名称(</param>
        private void GetWorkBook(string strFile)
        {

            XLWorkbook workBook = new XLWorkbook();
            IXLWorksheet workSheet = workBook.AddWorksheet("中奖人信息");
            IXLStyle style = workSheet.Style;

            //设定边框样式
            style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            style.Alignment.Vertical = XLAlignmentVerticalValues.Bottom;

            style.Font.FontColor = XLColor.Black;
            style.Font.FontName = "宋体";
            style.Font.FontSize = 16;
            //style.Font.Italic = true;
            // style.Font.Shadow = false;
            style.Font.Underline = XLFontUnderlineValues.None;

            //设置A1，B1的字体颜色为黑色
            workSheet.Range(1, 1, 1, 5).Style.Font.FontColor = XLColor.Red;

            //把第5行第1列和第2列合并单元格
            //  workSheet.Range(5, 1, 5, 2).Merge();
            //设置第5行第1列和第2列内容中间对齐
            workSheet.Range(5, 1, 5, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            //设置第二列的宽度
            //workSheet.Column(2).Width = 10;
            //设置第4到7列的宽度
            workSheet.Columns(1, 7).Width = 40;

            //设定标题列
            workSheet.Cell(1, 1).Value = "中奖号码";
            workSheet.Cell(1, 2).Value = "中奖顺序";
            workSheet.Cell(1, 3).Value = "中奖批次";
            workSheet.Cell(1, 4).Value = "奖项名称";
            workSheet.Cell(1, 5).Value = "奖品名称";
            //设定数据的值的值
            for (int j = 0; j < list.Count; j++)
            {
                workSheet.Cell(j + 2, 1).Value = list[j].number;
                workSheet.Cell(j + 2, 2).Value = list[j].id;
                workSheet.Cell(j + 2, 3).Value = list[j].batchNum;
                workSheet.Cell(j + 2, 4).Value = list[j].Prize.JiangXiang;
                workSheet.Cell(j + 2, 5).Value = list[j].Prize.PrizeName;
                
               //设定的每列的边框属性
                for (int i = 1; i <= 5; i++)
                {
                    //设置底部边框及颜色
                    workSheet.Cell(j + 2, i).Style.Border.BottomBorder = XLBorderStyleValues.Medium;
                    workSheet.Cell(j + 2, i).Style.Border.BottomBorderColor = XLColor.Black;

                    //设置顶部边框及颜色
                    workSheet.Cell(j + 2, i).Style.Border.TopBorder = XLBorderStyleValues.Medium;
                    workSheet.Cell(j + 2, i).Style.Border.TopBorderColor = XLColor.Black;
                    //设置左部边框及颜色
                    workSheet.Cell(j + 2, i).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                    workSheet.Cell(j + 2, i).Style.Border.LeftBorderColor = XLColor.Black;

                    //设置右部边框及颜色
                    workSheet.Cell(j + 2, i).Style.Border.RightBorder = XLBorderStyleValues.Hair;
                    workSheet.Cell(j + 2, i).Style.Border.RightBorderColor = XLColor.Black;
                }

            }
            //对象保存
            workBook.SaveAs(strFile);
        }
        #endregion

        #region  对象的有自定义类型属性，需要装换后才能绑定datagridview

        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if ((dgvList.Rows[e.RowIndex].DataBoundItem != null) &&
             (dgvList.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                string[] names = dgvList.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgvList.Rows[e.RowIndex].DataBoundItem;
                for (int i = 0; i < names.Count(); ++i)
                {
                    try
                    {
                        var result = obj.GetType().GetProperty(names[i]).GetValue(obj, null);
                        obj = result;
                        e.Value = result.ToString();
                    }
                    catch (Exception)
                    {
                        return;
                        throw;
                    }
                }
            }
        } 
        #endregion
     
        #region 查看记录方法
        /// <summary>
        ///  查看记录方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecord_Click(object sender, EventArgs e)
        {
            //如果，点击时为按钮文字全部为全部的话，查询全部记录，
            if (btnRecord.Text.Equals("查看全部记录"))
            {
                bind(main.luckList);
                btnRecord.Text = "查看本轮记录";
                lbl_Record.Text = "本场截止到目前共有" + main.luckList.Count + "条中奖信息";
                Text = "本场全部获奖名单";
                btnExport.Text = "导出本场所有记录";
            }
            else
            {
                //查询本轮的记录
                bind(main.batchPersonList);
                btnRecord.Text = "查看全部记录";
                lbl_Record.Text = "本轮截止到目前共有" + main.batchPersonList.Count + "条中奖信息";
                btnExport.Text = "导出本轮所有记录";
                Text = "本轮全部获奖名单";
            }

        }   
        #endregion

        #region 执行backgroundWork方法
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            //返回更新的百分比
            e.Result = ProcessProgress(bw, e);
        } 
        #endregion

        #region 进度条改变时的方法
        /// <summary>
        /// 进度条改变时的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // bw.ReportProgress 会调用到这里，此处可以进行自定义报告方式  
            notifyForm.SetNotifyInfo(e.ProgressPercentage, "处理进度:" + Convert.ToString(e.ProgressPercentage) + "%");
        }   
        #endregion

        #region 进程结束时的提示
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            notifyForm.Close();
            MessageBox.Show("导出记录成功", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        } 
        #endregion
       

        #region 更新进度条百分比
        private int ProcessProgress(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 1000; i++)
            {
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                    return -1;
                }
                else
                {
                    // 状态报告  
                    bw.ReportProgress(i / 10);
                    // 等待，用于UI刷新界面，很重要  
                    System.Threading.Thread.Sleep(2);
                }
            }

            return -1;
        }    
        #endregion
    






     


    }
}
