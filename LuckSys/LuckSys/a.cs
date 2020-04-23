using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media; 
namespace LuckSys
{
    public partial class a : Form
    {
      
        public a()
        {
            InitializeComponent();
          
        }

        List<String> list = new List<String>();
        public void init() {
            int zeroLength = 3;
            for (int i = 0; i < 500; i++)
            {       
                string num =(i+1).ToString().PadLeft(zeroLength,'0');
                list.Add(num);
            }
        }
        String path = Application.StartupPath;
        SoundPlayer msc = null;
        private void Main_Load(object sender, EventArgs e)
        {
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
           this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
           this.BackgroundImageLayout = ImageLayout.Stretch;
           this.number.Width = this.Width; 
            this.number.Height = this.Height;
           this.title.Width = this.Width;
           strat.BackColor = Color.Transparent;//去背景  
           strat.FlatAppearance.BorderSize = 0;//去边线  
           init();
            int zeroLength = list.Count.ToString().Length;
           String zero = "";
            for (int i = 0; i <zeroLength; i++)
           {
               zero += "0";
           }
            number.Text = zero;
            shuoming.Text = "奖池中还剩" + list.Count + "个号码!";
            msc = new SoundPlayer(path + @"/Resources/bgm.wav");
           msc.Play();
        
        }
        Random r = new Random();
        private void time_Tick(object sender, EventArgs e)
        {
            number.Text=list[r.Next(list.Count)];

            
        }

        SoundPlayer begin = null;
        SoundPlayer end = null;
        private void strat_Click(object sender, EventArgs e)
        {
        
            if (time.Enabled)
            {
                begin.Stop();
                strat.Text = "开始";
                time.Enabled = false;
                list.Remove(number.Text);
                Double lv=(1.0 / list.Count)*100;
                shuoming.Text = "奖池中还剩" + list.Count + "个号码！";
               end = new SoundPlayer(path + @"/Resources/end.wav");
               end.Play();
             
            }
            else
            {
                
                strat.Text = "停止";
                time.Enabled = true;
              
               begin = new SoundPlayer(path + @"/Resources/begin.wav");
               begin.PlayLooping();
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            
            DialogResult result=MessageBox.Show("真的要退出系统吗？","退出系统",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
          
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }



          
        

    
    }
}
