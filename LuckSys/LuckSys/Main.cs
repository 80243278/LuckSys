using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Media;
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
    /// 主窗体
    /// </summary>
    public partial class Main : Form
    {

        /// <summary>
        /// 储存所有号码集合 
        /// </summary>
        public List<String> list = new List<String>();
       /// <summary>
        ///  存储全部中奖号码集合
       /// </summary>
        public List<Luck> luckList = new List<Luck>();
     /// <summary>
     ///  本轮中奖号码集合
     /// </summary>
        public List<Luck> batchPersonList = new List<Luck>();
        /// <summary>
        /// 奖品集合
        /// </summary>
        public List<Prize> prizeList = new List<Prize>();
        /// <summary>
        ///  奖券总数
        /// </summary>
        public Int32 count = Convert.ToInt32(Init.readInfo("JiangQuanCount"));
       /// <summary>
        ///   中奖顺序号 
       /// </summary>
        public Int32 WinOrder = 0;
        /// <summary>
        /// 奖项id
        /// </summary>
        public Int32 prizeId;
       /// <summary>
        ///中奖的轮数 
       /// </summary>
        public int BatchNum = 1;
        /// <summary>
        /// 每轮的人数
        /// </summary>
        public int BatchPerson = 0;
        /// <summary>
        /// 用于判断，系统设置里每轮人数的改变，是否本轮生效
        /// </summary>
        public int updateBatchPerson = Convert.ToInt32(Init.readInfo("BatchPerson"));

        /// <summary>
        /// 获取主程序绝对路径
        /// </summary>
        String path = Application.StartupPath;
        /// <summary>
        /// 播放背景音乐的对象
        /// </summary>
        public clsMCI cm = new clsMCI();
      /// <summary>
        /// 播放音效的对象
      /// </summary>
        SoundPlayer yinxiao = new SoundPlayer();
        /// <summary>
        ///   随机数
        /// </summary>
        Random r = new Random();
        /// <summary>
        /// //控制状态  0:初始值 1:声音 2：系统设置 3：奖项管理
        /// </summary>
        int flag = 0;
        /// <summary>
        /// 系统设置窗体
        /// </summary>
        setting set = null;
        /// <summary>
        /// 奖项管理窗体
        /// </summary>
        frmPrize fp = null;
        /// <summary>
        ///当前使用的奖项信息
        /// </summary>
        public Prize globalPrize = null;


        #region 防止plane控件闪烁
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED 
                return cp;
            }
        }
        #endregion
        
      
        public Main()
        {
            InitializeComponent();
          
            #region 防止控件闪烁
		     SetStyle(ControlStyles.UserPaint, true);
            // 禁止擦除背景.  
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            // 双缓冲 
            SetStyle(ControlStyles.DoubleBuffer, true);
            //禁止table控件闪烁
            table.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
.SetValue(table, true, null);
	        #endregion
        
            // 设置表格布局的宽和高
            table.Width = this.Width;
            table.Height = this.Height;



        }

        #region 初始化奖池数据
        /// <summary>
        /// 初始化奖池数据
        /// </summary>
        public void initData()
        {
            //中奖人数清零
            WinOrder = 0;
            //轮数为第一轮
            BatchNum = 1;
            //获取奖券总数的位数，
            int zeroLength = count.ToString().Length;
            //将奖池信息清空，从新添加
            list = new List<string>();
            //奖获奖名单清空
            luckList = new List<Luck>();
            batchPersonList = new List<Luck>();
            //按照奖券数量生成对应的号码个数
            for (int i = 1; i <= count; i++)
            {
                //将对应的号码将加入到集合中，该数字位数与count的位数相差的话，用0补齐
                list.Add(i.ToString().PadLeft(zeroLength, '0'));
            }
            //根据，奖券数量的位数，在number位置上输入0
            String zero = "";
            number.Text = zero.PadLeft(zeroLength, '0');
            shuoming.Text = "奖池中还剩" + list.Count + "个号码";

        }
        #endregion

        #region 初始字体
        /// <summary>
        ///  初始字体 
        /// </summary>
        private void initFont()
        {
            //根据table控件的设置控件文字大小设置 PS: 文字与高度之间的公式: 高度/文字大小
            number.Font = new Font("黑体", (float)(number.Height / 1.25), FontStyle.Bold);
            lblJiangPin.Font = new Font("微软雅黑", (float)(txtTitle.Height / 2.1), FontStyle.Bold);
            txtTitle.Font = new Font("微软雅黑", (float)(txtTitle.Height / 2.1), FontStyle.Bold);
            shuoming.Font = new Font("微软雅黑", (float)(shuoming.Height / 1.76), FontStyle.Bold);
          
        }
        #endregion
    

        #region 窗体加载事件
        private void Form1_Load(object sender, EventArgs e)
        {
            //程序启动时，每轮人数和更新后的数字保持一致。
            BatchPerson = updateBatchPerson;
            //读取配置文件 背景音乐的路径
            cm.FileName = Init.readInfo("backgroundMusic");
            //读取背景音乐的状态，是ON的话，
            if (Init.readInfo("bgmStatu").Equals("ON"))
            {
                //就开音乐
                cm.play();
                //将声音大声
                cm.setSoundValue(1000);
            }
            else
            {
              // 否则,不开音乐，并设置系统托盘右键的控制背景音乐的菜单项，为开启背景音乐
                cm.StopT();
                this.tsmiMusic_swith.Text = "开启背景音乐";
            }
            //调用初始化数字和初始化字体方法
            initFont();
            initData();
            
            //读取奖项信息并赋值给集合
            prizeList = IOUtil.ReadFile();
            //获取奖项信息个数并将它赋值给奖项id,它就是奖项id的初始值
            prizeId = prizeList.Count;
            //读取title属性值，并赋值给页面的标题行，PS:最上面一行是标题栏
            txtTitle.Text = Init.readInfo("title");
            //如果查询到的奖项id不是空字符串的话
            if (!Init.readInfo("id").Equals(""))
            {
                //根据奖项id查找奖项对象，当前使用的奖项对象
                globalPrize = getPrizeByPrizeId(Convert.ToInt32(Init.readInfo("id")));
            }

            //如果当前使用的奖项对象为空的话
            if (globalPrize == null)
            {
                //奖项显示区，提示系统设置里面设定的无奖项时的提示语
                lblJiangPin.Text = Init.readInfo("jiangXiangPro"); ;
            }
            else
            {
                //奖项显示区提示奖项名和奖品名
                lblJiangPin.Text = "奖项名:" + globalPrize.JiangXiang + "    奖品名:" + globalPrize.PrizeName;
            }

            //如果JiangpinInfo属性值为false的话，不显示奖项显示区
            if (Init.readInfo("JiangpinInfo").Equals("false"))
            {
                this.lblJiangPin.Visible = false;
            }
            else
            {
                //显示奖项显示区
                this.lblJiangPin.Visible = true;
            }
        }

        #endregion



        #region 开始和停止按钮
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSwitch_MouseUp(object sender, MouseEventArgs e)
        {
            btnSwitch.Image = Properties.Resources.btn;
            showNum();
        }

     
        #endregion

 
        #region 开始抽奖和停止抽奖
        /// <summary>
        /// 开始抽奖和停止抽奖
        /// </summary>
        private void showNum()
        {
            //设置按钮状态为 未按下 状态
            btnSwitch.Image = Properties.Resources.btn;

            //奖池空了的提示
            if (list.Count == 0)
            {
                number.Text = number.Text.PadLeft(list.Count.ToString().Length, '0');
                MessageBox.Show("奖池空了..请重新设置奖券", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

           //停止抽奖操作
            if (time.Enabled)
            {
                time.Enabled = false;
                //将页面上除了中奖号码以外的所有信息全部隐藏
                txtTitle.Visible = false;
                lblJiangPin.Visible = false;
                shuoming.Visible = false;
                plbtn.Visible = false;
                //将中奖号码，设置为白色
                number.ForeColor = Color.White;
                //更换背景颜色
                table.BackgroundImage = Image.FromFile(Application.StartupPath + @"\image\backgroup03.jpg");
                //开启背景图片定时变化， 开始为1. 结束为2500，去他两中间的时间。
                bgiTime.Enabled = true; 
                bgiEnd.Enabled = true;
                 //如果是新的一轮的话。
                if (WinOrder == 1)
                {
                   //将每轮的中奖人数清空
                    batchPersonList = new List<Luck>();
                }
                //调整说明文字的字体变大
                shuoming.Font = new Font("微软雅黑", (float)(shuoming.Height / 1.76), FontStyle.Bold);
                btnSwitch.Text = "开始";
               
             
                //将中奖号码从奖池中移除
                list.Remove(number.Text);

                //将中奖号码放入中奖人集合中
                Luck luck = null;
                Prize p = null;

                //奖项没设置的情况
                if (globalPrize == null)
                {
                    p = new Prize("无", "未设置");
                    luck = new Luck(WinOrder, number.Text, BatchNum, p);
                }
                else
                {
                    p = new Prize(globalPrize.JiangXiang, globalPrize.PrizeName);
                    luck = new Luck(WinOrder, number.Text, BatchNum, p);
                }
                luckList.Add(luck);
                batchPersonList.Add(luck);
                //如果是到每轮的最后一个人的时候的话
                if (BatchPerson == WinOrder)
                {
                    //人数从新设置
                    WinOrder = 0;
                    //轮数加1
                    BatchNum++;

                    //设置每轮人数后，并且提示下一轮生效时，则进入该结果为true
                    if (updateBatchPerson != BatchPerson)
                    {
                        BatchPerson = updateBatchPerson;
                    }
                }

                //显示奖池中剩余奖券数量
                shuoming.Text = "奖池中还剩" + list.Count + "个号码";
                try
                {

                    //播放結束音乐
                    yinxiao = new SoundPlayer(path + @"/music/end.wav");
                    yinxiao.Play();
                    //并將背景音乐大声
                    cm.setSoundValue(1000);
                }
                catch (Exception)
                {
                }
            }
            else
            {

                //如果有奖项 的话 
                if (globalPrize != null)
                {
                    //剩余奖品小于等于0
                    if (globalPrize.ShengYuCount <= 0)
                    {

                        MessageBox.Show("该奖项已经抽完了,请更换奖项", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
               //开始抽奖
                number.ForeColor = Color.FromArgb(255, 255, 150);
                //开启time控件
                time.Enabled = true;
               
                //显示所有隐藏的元素
                txtTitle.Visible = true;
                //系统配置中设置了显示奖项显示区时，显示奖项显示区
                if (!Init.readInfo("JiangpinInfo").Equals("false"))
                {
                    lblJiangPin.Visible = true;
                }
                shuoming.Visible = true;
                plbtn.Visible = true;
                //关闭通知
                tongzhi.Enabled = false;
                tongzhiEnd.Enabled = false;
               
                shuoming.Dock = DockStyle.Fill;
               //更换背景图
                table.BackgroundImage = Image.FromFile(Application.StartupPath + @"\image\backgroup.jpg");
                //关闭背景图片切换
                bgiTime.Enabled = false;
                bgiEnd.Enabled = false;
         

                //將背景音乐小声
                cm.setSoundValue(0);
                //说明字体变小
                shuoming.Font = new Font("微软雅黑", (float)(shuoming.Height / 3.5), FontStyle.Bold);
                
                //如果使用奖项的话
                if (globalPrize != null)
                {
                    //带奖项的提示
                    shuoming.Text = "现在进行第" + BatchNum + "轮抽奖,现在的奖项：" + globalPrize.JiangXiang + "\n正在抽取第" + (++WinOrder) + "位幸运同学";
                    globalPrize.ShengYuCount--;
                }
                else
                {
                    //不带奖项提示
                    shuoming.Text = "现在进行第" + BatchNum + "轮抽奖\n正在抽取第" + (++WinOrder) + "位幸运同学";
                }
                
                btnSwitch.Text = "停止";
         
                try
                {
                    //循环播放抽奖时音乐
                    yinxiao = new SoundPlayer(path + @"/music/begin.wav");
                    yinxiao.PlayLooping();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
        #endregion

         #region 抽奖方法的timer
        /// <summary>
        /// 抽奖方法timer控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void time_Tick(object sender, EventArgs e)
        {


            //随机生成数字，并显示
            number.Text = list[r.Next(list.Count)];
        }

        #endregion


        #region 系统设置
        /// <summary>
        /// 系统设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSet_Click(object sender, EventArgs e)
        {
            if (IsButtonInvalid())
            {

                return;
            }
            //设置按钮样式
            btnSet.Image = Properties.Resources.btn;
            //打开系统设置窗体
            set = new setting(this);
            set.ShowDialog();

        }   
        #endregion


        #region 获奖名单
        /// <summary>
        /// 获奖名单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWin_Click(object sender, EventArgs e)
        {
            if (IsButtonInvalid())
            {

                return;
            }
            btnWin.Image = Properties.Resources.btn;
            info i = new info(this);
            i.ShowDialog();
        }

        #endregion

        #region 奖项管理
        /// <summary>
        /// 奖项管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJiangXiang_Click(object sender, EventArgs e)
        {
            if (IsButtonInvalid())
            {
                return;
            }
            btnJiangXiang.Image = Properties.Resources.btn;
         fp= new frmPrize(this);
         flag = 3;
            fp.ShowDialog();
        }
        #endregion


        #region 最小化
        /// <summary>
        /// 最小化
        /// </summary>
        int minCount = 1; //控制气泡只弹出一次
        private void btn_min_Click(object sender, EventArgs e)
        {
            if (IsButtonInvalid())
            {
                return;
            }
            btnZuiXiaoHua.Image = Properties.Resources.btn;
            //播发音效时，将音效停止
            yinxiao.Stop();
            //显示系统托盘图标
            this.nfi.Visible = true;
            //最小化窗口
            this.WindowState = FormWindowState.Minimized;
            //将窗体现在任务栏上
            this.ShowInTaskbar = true;
            //将背景音乐停止
            if ((int)cm.mc.state != 3)
            {
                cm.Puase();
            }
            //控制气泡只能弹一次
            if (minCount == 1)
            {
                nfi.ShowBalloonTip(3000, "提示", "我在这儿呢", ToolTipIcon.Info);
                minCount = 0;
            }
        }
        #endregion



        #region 退出系统
        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeSys_Click(object sender, EventArgs e)
        {
            if (IsButtonInvalid())
            {
                return;
            }
            btnCloseSys.Image = Properties.Resources.btn;
            DialogResult result = MessageBox.Show("确定要退出系统吗", "退出系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                try
                {
                    Form1_FormClosing(null, null);
                    Application.Exit();
                }
                catch (Exception)
                {

                }

            }
        }
        #endregion


        #region 关闭窗体前的事件
        /// <summary>
        /// 关闭窗体前的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //保存奖项信息
            try
            {
                IOUtil.WriteFile(prizeList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //释放所有资源
            if (yinxiao != null)
            {
                yinxiao.Dispose();
            }
            if ((int)cm.mc.state == 1 || (int)cm.mc.state == 3)
            {
                cm.StopT();
            }
        }
        #endregion
    
        #region 按钮状态控制
        /// <summary>
        /// 按钮状态控制
        /// </summary>
        /// <returns>是否锁住按钮</returns>

        private bool IsButtonInvalid()
        {
            if (time.Enabled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 左下角双击按钮
        private void nfi_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tsmiMax_Click(sender, e);
        }
        #endregion


        #region 右键系统设置按钮
        private void tsmiSet_Click(object sender, EventArgs e)
        {
            btnSet_Click(sender, e);
            flag = 2;

        }
        #endregion

        #region 右键关闭按钮
        private void tsmiClose_Click(object sender, EventArgs e)
        {
            closeSys_Click(sender, e);
        }
        #endregion

        #region 右键音乐按钮
        private void tsmiMusic_swith_Click(object sender, EventArgs e)
        {
            //如果音乐状态为暂停的话。将音乐停止
            if ((int)cm.mc.state == 2)
            {
                this.tsmiMusic_swith.Text = "开启背景音乐";
                cm.StopT();
            }
            //如果音乐状态为停止的话。将flag赋值为1
            else if ((int)cm.mc.state == 3)
            {
                this.tsmiMusic_swith.Text = "关闭背景音乐";
                flag = 1; //1表示 音乐可以最大化后正常播放了

            }

        }
        #endregion

        #region 奖项管理
        private void tsmiJXGL_Click(object sender, EventArgs e)
        {
            btnJiangXiang_Click(null, null);
        }

        #endregion

        #region   右键最大化
        /// <summary>
        /// 右键最大化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiMax_Click(object sender, EventArgs e)
        {

            //表示set窗体已经开了,给它先关闭
            if (flag == 2)
            {
                set.Close();
                flag = 0;
            }
            //表示fp窗体已经开了,给它先关闭
            if (flag == 3)
            {
                fp.Close();
                flag = 0;
            }

            //重新新播放
            if (this.tsmiMusic_swith.Text.Equals("关闭背景音乐") && flag == 1)
            {
                cm = new clsMCI();
                cm.FileName = Init.readInfo("backgroundMusic");
                cm.play();
            }
            //继续播放
            else if ((int)cm.mc.state == 2)
            {
                cm.play();
            }

            cm.setSoundValue(1000);

            //将窗体变成最大化
            this.WindowState = FormWindowState.Maximized;
            this.ShowInTaskbar = true;

        }
        #endregion


        #region 键盘事件
        string str = "";
        string temp = "";
        //键盘事件  
        private void Main_KeyUp(object sender, KeyEventArgs e)
        {

            //如果未抽奖状态下
            if (!time.Enabled)
            {
                //按 X键了，就是要跳过本轮剩余的人数
                if ((e.KeyCode == Keys.X))
                {
                    //如果显示的不等于通知包含的字的话，则记录该内容
                    if (shuoming.Text.IndexOf("设置成功") == -1 && shuoming.Text.IndexOf("不能设置") == -1)
                    {
                        temp = shuoming.Text;
                    }

                    //打开通知
                    tongzhi.Enabled = true;
                    tongzhiEnd.Enabled = true;
                    //如果当前轮数已经开始了，可以进入下一轮
                    if (WinOrder != 0)
                    {
                        WinOrder = 0;
                        ++BatchNum;
                        str = "设置成功,现在是第" + BatchNum + "轮";
                    }
                    else
                    {
                        str = "第" + BatchNum + "轮还没有开始，不能设置";
                    }
                    return;
                }
            }

            //开始或停止
            if ((int)e.KeyCode == 32)
            {
                //空格键
                showNum();
            }
            //退出系统
            if ((int)e.KeyCode == 27)
            {
                //esc键
                btnCloseSys.Image = Properties.Resources.btn;
                closeSys_Click(null, null);
            }
            //显示中奖结果时，嫌停留时间过长可按C进入抽奖页面
            if (e.KeyCode == Keys.C)
            {
                if (!plbtn.Visible)
                {
                    showControl();
                }
            }


        }
        #endregion


        #region    尺寸改变
        private void Main_SizeChanged(object sender, EventArgs e)
        {
            //从新设置字体
            initFont();

            //重新播放音乐
            if (this.tsmiMusic_swith.Text.Equals("关闭背景音乐") && flag == 1)
            {
                cm = new clsMCI();
                cm.FileName = Init.readInfo("backgroundMusic");
                cm.play();
            }
            //继续播放
            else if ((int)cm.mc.state == 2)
            {
                cm.play();
            }

            cm.setSoundValue(1000);


        }
        #endregion
     


        #region 根据奖项id查找奖项对象
        /// <summary>
        /// 根据奖项id查找奖项对象
        /// </summary>
        /// <param name="id">奖项id</param>
        /// <returns>奖项对象</returns>

        public Prize getPrizeByPrizeId(int id)
        {
            if (prizeList.Count > 0)
            {
                //循环奖项集合，找到了 反对 对象。否则返回null
                foreach (Prize i in prizeList)
                {

                    if (i.ID == id)
                    {
                        return i;
                    }
                }
            }
            return null;
        }

        #endregion


        #region 窗体关闭后发生的时间，
       //主要防止非正常退出时，能保存数据
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1_FormClosing(null, null);
        }
        #endregion


        #region 背景图更换

        //开始时
        private void bgiTime_Tick(object sender, EventArgs e)
        {
            //将字体设为白色
            number.ForeColor = Color.White;
            //隐藏控件
            txtTitle.Visible = false;
            lblJiangPin.Visible = false;
            shuoming.Visible = false;
            plbtn.Visible = false;
            //设置图片
            table.BackgroundImage = Image.FromFile(Application.StartupPath + @"\image\backgroup03.jpg");
            bgiTime.Enabled = false;

        }
        //结束时
        private void bgiEnd_Tick(object sender, EventArgs e)
        {
            showControl();
            bgiEnd.Enabled = false;
        }

        #endregion

        #region 显示抽完奖后的控件
        /// <summary>
        /// 显示抽完奖后的控件
        /// </summary>
        private void showControl()
        {
            //将所有控件显示
            txtTitle.Visible = true;
            shuoming.Visible = true;
            plbtn.Visible = true;
            //通过配置文件显示 ，如果不为false时，则显示
            if (!Init.readInfo("JiangpinInfo").Equals("false"))
            {
                lblJiangPin.Visible = true;
            }
            //设置字体和颜色
            number.ForeColor = Color.FromArgb(255, 255, 150);
            table.BackgroundImage = Image.FromFile(Application.StartupPath + @"\image\backgroup.jpg");

        }
        #endregion


        #region 按钮样式控制
        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == 32)
            {
                btnSwitch.Image = Properties.Resources.btn02;
            }
            if ((int)e.KeyCode == 27)
            {
                btnCloseSys.Image = Properties.Resources.btn02;
            }

        }

        private void btnSwitch_MouseDown(object sender, MouseEventArgs e)
        {
       
            btnSwitch.Image = Properties.Resources.btn02;

        }

        private void btnSet_MouseDown(object sender, MouseEventArgs e)
        {
            btnSet.Image = Properties.Resources.btn02;
        }

        private void btnWin_MouseDown(object sender, MouseEventArgs e)
        {
            btnWin.Image = Properties.Resources.btn02;
        }

        private void btnJiangXiang_MouseDown(object sender, MouseEventArgs e)
        {
            btnJiangXiang.Image = Properties.Resources.btn02;
        }

        private void btnZuiXiaoHua_MouseDown(object sender, MouseEventArgs e)
        {
            btnZuiXiaoHua.Image = Properties.Resources.btn02;

        }

        private void btnCloseSys_MouseDown(object sender, MouseEventArgs e)
        {
            btnCloseSys.Image = Properties.Resources.btn02;
        }


 

        private void btnSet_MouseUp(object sender, MouseEventArgs e)
        {
            btnSet.Image = Properties.Resources.btn;
        }

        private void btnWin_MouseUp(object sender, MouseEventArgs e)
        {
            btnWin.Image = Properties.Resources.btn;
        }

        private void btnJiangXiang_MouseUp(object sender, MouseEventArgs e)
        {
            btnJiangXiang.Image = Properties.Resources.btn;
        }

        private void btnZuiXiaoHua_MouseUp(object sender, MouseEventArgs e)
        {
            btnZuiXiaoHua.Image = Properties.Resources.btn;
        }

        private void btnCloseSys_MouseUp(object sender, MouseEventArgs e)
        {
            btnCloseSys.Image = Properties.Resources.btn;
        }

        private void btnSwitch_MouseMove(object sender, MouseEventArgs e)
        {
            btnSwitch.Image = Properties.Resources.btn03;
            btnSwitch.ForeColor = Color.Red;
        }

        private void btnSwitch_MouseLeave(object sender, EventArgs e)
        {
            btnSwitch.Image = Properties.Resources.btn;
            btnSwitch.ForeColor = Color.Black;
        }

        private void btnSet_MouseLeave(object sender, EventArgs e)
        {
            btnSet.Image = Properties.Resources.btn;
            btnSet.ForeColor = Color.Black;
        }

        private void btnSet_MouseMove(object sender, MouseEventArgs e)
        {
            btnSet.Image = Properties.Resources.btn03;
            btnSet.ForeColor = Color.Red;
        }

        private void btnWin_MouseLeave(object sender, EventArgs e)
        {
            btnWin.Image = Properties.Resources.btn;
            btnWin.ForeColor = Color.Black;

        }

        private void btnWin_MouseMove(object sender, MouseEventArgs e)
        {
            btnWin.Image = Properties.Resources.btn03;
            btnWin.ForeColor = Color.Red;
        }

        private void btnJiangXiang_MouseMove(object sender, MouseEventArgs e)
        {
            btnJiangXiang.Image = Properties.Resources.btn03;
            btnJiangXiang.ForeColor = Color.Red;
        }

        private void btnJiangXiang_MouseLeave(object sender, EventArgs e)
        {
            btnJiangXiang.Image = Properties.Resources.btn;
            btnJiangXiang.ForeColor = Color.Black;
        }

        private void btnZuiXiaoHua_MouseMove(object sender, MouseEventArgs e)
        {
            btnZuiXiaoHua.Image = Properties.Resources.btn03;
            btnZuiXiaoHua.ForeColor = Color.Red;
        }

        private void btnZuiXiaoHua_MouseLeave(object sender, EventArgs e)
        {
            btnZuiXiaoHua.Image = Properties.Resources.btn;
            btnZuiXiaoHua.ForeColor = Color.Black;
        }

        private void btnCloseSys_MouseLeave(object sender, EventArgs e)
        {
            btnCloseSys.Image = Properties.Resources.btn;
            btnCloseSys.ForeColor = Color.Black;
        }

        private void btnCloseSys_MouseMove(object sender, MouseEventArgs e)
        {
            btnCloseSys.Image = Properties.Resources.btn03;
            btnCloseSys.ForeColor = Color.Red;
        }

        #endregion

        #region 通知
        //开始
        private void tongzhi_Tick(object sender, EventArgs e)
        {
            //设置字体信息
            shuoming.Font = new Font("微软雅黑", (float)(35), FontStyle.Bold);
            shuoming.Dock = DockStyle.Bottom;
            shuoming.Text = str;
            tongzhi.Enabled = false; //只执行一遍

        }
        //结束
        private void tongzhiEnd_Tick(object sender, EventArgs e)
        {
            //设置字体信息
            shuoming.Dock = DockStyle.Fill;
            shuoming.Font = new Font("微软雅黑", (float)(shuoming.Height / 1.76), FontStyle.Bold);
            shuoming.Text = temp;
            tongzhiEnd.Enabled = false; //只执行一遍
        }

        #endregion

        #region 点击号码区域时发生
        private void number_Click(object sender, EventArgs e)
        {
            //如果，plbtn是隐藏的，点击后，就显示了
            if (!plbtn.Visible)
            {
                showControl();
            }
        }
        #endregion

        private void btnSwitch_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {

        }



  

    

     


  
    }
}

