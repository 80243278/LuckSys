using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
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
    /// 系统设置窗体
    /// </summary>
    public partial class setting : Form
    {
        public setting()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 主窗体
        /// </summary>
        private Main main;
        /// <summary>
        /// 系统设置 构造函数
        /// </summary>
        /// <param name="main">主窗体</param>
        public setting(Main main)
        {
            InitializeComponent();
            this.main = main;
        }

        #region 窗体加载
        private void setting_Load(object sender, EventArgs e)
        {
            //设置只能浏览MP3文件
            ofdBgm.Filter = "音频文件(*.mp3)|*.mp3";
            //设置文本框的值
            this.title.Text = main.txtTitle.Text;
            this.jiangCount.Value = main.count;
            this.nudNum.Value = main.updateBatchPerson;
            btn_YinCang.Text = main.lblJiangPin.Visible ? "隐藏奖项显示区" : "显示奖项显示区";
            txtPrizePro.Text = Init.readInfo("jiangXiangPro");
            String music = Init.readInfo("backgroundMusic");
             //如果是 相对路径的话，加上程序主目录地址
            if (music.IndexOf(":") == -1)
            {
                this.txtBGM.Text = Application.StartupPath + @"\" + music;
            }
            else
            {
                this.txtBGM.Text = music;
            }

            //是停止状态下时，开启音乐
            if (((int)main.cm.mc.state == 3))
            {
                this.musicbtn.Text = "开启背景音乐";
            }
            else
            {
                this.musicbtn.Text = "关闭背景音乐";
            }
       
        }  
        #endregion
      
        #region 保存按钮
        private void save_Click(object sender, EventArgs e)
        {


            //标题设置
            main.txtTitle.Text = title.Text;
            Init.WriteInfo("title", title.Text);

            //无奖项提示语

            //如果奖品对象象为空的话
            if (main.globalPrize == null)
            {
                //无奖项提示语显示在奖项显示区
                main.lblJiangPin.Text = txtPrizePro.Text;
            }
            //并把无奖项提示语,加入到初始化配置文件中
            Init.WriteInfo("jiangXiangPro", txtPrizePro.Text);



            bool statu = true; //更新奖券数量状态

            //获取奖券数量
            Int32 newCount = Convert.ToInt32(jiangCount.Value);
            //和主页面的奖券数量不一致时将更新它
            if (newCount != main.count)
            {
                DialogResult r = MessageBox.Show("你确定要调整奖券数量吗？\n奖池中的信息以及获奖名单将会被清空！", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (r == DialogResult.OK)
                {

                    //更新奖券成功设置为否
                    statu = false;
                    main.count = newCount;
                    Init.WriteInfo("JiangQuanCount", newCount.ToString());
                    main.luckList = new List<Luck>();
                    main.initData();//初始化信息
                }
            }

            //如果nudNum不等于BatchPerson时，进行调整
            if (Convert.ToInt32(nudNum.Value) != main.BatchPerson)
            {
                //将nudNum的值赋值给updateBatchPerson
                main.updateBatchPerson = Convert.ToInt32(nudNum.Value);
                //说明就就一轮刚刚结束，新的还没有开始呢
                if (main.WinOrder == 0)
                {
                    //直接赋值给 main.BatchPerson
                    main.BatchPerson = Convert.ToInt32(nudNum.Value);
                    //让初始化和他只能弹出一个
                    if (statu)
                        MessageBox.Show("设置成功!本轮生效", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //因为updateBatchPerson 和 BatchPerson 是在一轮结束时，才作比较 进行赋值，所以，在下一轮生效

                    if (statu)
                        MessageBox.Show("设置成功!下轮生效", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


                Init.WriteInfo("BatchPerson", nudNum.Value.ToString());

            }

            this.Close();
        }     
        #endregion

        #region 返回
        private void fanhui_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 控制音乐播放的按钮
        private void musicbtn_Click(object sender, EventArgs e)
        {

            //如果不是播放状态的话，进行播放
            if ((int)main.cm.mc.state == 2 || (int)main.cm.mc.state == 3)
            {
                this.musicbtn.Text = "关闭背景音乐";
                this.main.tsmiMusic_swith.Text = "关闭背景音乐";
                main.cm = new clsMCI();
               //获取 背景音乐路径
                main.cm.FileName = Init.readInfo("backgroundMusic");
                //进行播放
                main.cm.play();
                //更改音乐状态为 开
                Init.WriteInfo("bgmStatu", "ON");
            }
            else
            {
                
                this.musicbtn.Text = "开启背景音乐";
                this.main.tsmiMusic_swith.Text = "开启背景音乐";
                //关闭音乐,设置状态为关
                main.cm.StopT();
                Init.WriteInfo("bgmStatu", "OFF");
            }
        }
        #endregion


        #region 控制奖项奖项显示区 按钮
        private void btn_YinCang_Click(object sender, EventArgs e)
        {
            //如果奖项显示区为显示的话，给他做隐藏
            if (main.lblJiangPin.Visible)
            {

                btn_YinCang.Text = "显示奖项显示区";
                main.lblJiangPin.Visible = false;
                Init.WriteInfo("JiangpinInfo", "false");
            }
            else
            {

                btn_YinCang.Text = "隐藏奖项显示区";
                main.lblJiangPin.Visible = true;
                Init.WriteInfo("JiangpinInfo", "true");
            }

        }
       
        #endregion

        #region 更换背景音乐
        private void btnSelectBgm_Click(object sender, EventArgs e)
        {
            DialogResult dr = ofdBgm.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            else
            {

                txtBGM.Text = ofdBgm.FileName;
                main.cm = new clsMCI();
                main.cm.FileName = txtBGM.Text;
               //将路径写入到配置文件
                Init.WriteInfo("backgroundMusic", txtBGM.Text);
                //如果。音乐开关时关闭状态的话，选择完，音乐后，将他改为开启状态
                if ((int)main.cm.mc.state == 2 || (int)main.cm.mc.state == 3)
                {
                    this.musicbtn.Text = "关闭背景音乐";
                    this.main.tsmiMusic_swith.Text = "关闭背景音乐";
                    main.cm.play();
                    main.cm.setSoundValue(1000);
                    //更改音乐状态为 开
                    Init.WriteInfo("bgmStatu", "ON");
                }
            }
        }

        #endregion

        #region 背景音乐文本框键盘事件
        private void txtBGM_KeyPress(object sender, KeyPressEventArgs e)
        {
            //使按下的键子，全部无效
            e.Handled = true;
        }     
        #endregion
   




    }
}
