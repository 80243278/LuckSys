
using System;

using System.Runtime.InteropServices;

using System.Text;

using System.IO;

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

    /// 播放音乐类

    /// </summary>

    
    public class clsMCI
    {

        public clsMCI()
        {


        }



        //定义API函数使用的字符串变量 

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]

        private string Name = "";

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]

        private string durLength = "";

        [MarshalAs(UnmanagedType.LPTStr, SizeConst = 128)]

        private string TemStr = "";

        int ilong;

        //定义播放状态枚举变量
        /// <summary>
        /// 播放状态
        /// </summary>
        public enum State
        {

            /// <summary>
            /// 播放
            /// </summary>
            mPlaying = 1,
            
            /// <summary>
            /// 暂停
            /// </summary>
            mPuase = 2,

            /// <summary>
            /// 停止
            /// </summary>
            mStop = 3

        };

        //结构变量

        public struct structMCI
        {

            public bool bMut;

            public int iDur;

            public int iPos;

            public int iVol;

            public int iBal;

            public string iName;
            /// <summary>
            /// 播放状态 1：播放 2:暂停 3：停止
            /// </summary>
            public State state;

        };


        /// <summary>
        /// 播放信息
        /// </summary>
        public structMCI mc = new structMCI();


        #region 文件名
        //取得播放文件属性
        /// <summary>
        /// 带路径的文件名
        /// </summary>
        public string FileName
        {

            get
            {

                return mc.iName;

            }

            set
            {

                //ASCIIEncoding asc = new ASCIIEncoding(); 

                try
                {

                    TemStr = "";

                    TemStr = TemStr.PadLeft(127, Convert.ToChar(" "));

                    Name = Name.PadLeft(260, Convert.ToChar(" "));

                    mc.iName = value;

                    ilong = APIClass.GetShortPathName(mc.iName, Name, Name.Length);

                    Name = GetCurrPath(Name);

                    //Name = "open " + Convert.ToChar(34) + Name + Convert.ToChar(34) + " alias media";

                    Name = "open " + Convert.ToChar(34) + Name + Convert.ToChar(34) + " alias media";

                    ilong = APIClass.mciSendString("close all", TemStr, TemStr.Length, 0);

                    ilong = APIClass.mciSendString(Name, TemStr, TemStr.Length, 0);

                    ilong = APIClass.mciSendString("set media time format milliseconds", TemStr, TemStr.Length, 0);

                    mc.state = State.mStop;

                }

                catch
                {

                }

            }

        }
 
        #endregion


        #region 播放
        /// <summary>
        /// 播放
        /// </summary>
        public void play()
        {

            TemStr = "";
            TemStr = TemStr.PadLeft(127, Convert.ToChar(" "));
         int state= APIClass.mciSendString("play media repeat ", TemStr, TemStr.Length, 0);
         if (state != 0) {
             MessageBox.Show("音乐播放错误，请更换音乐","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
         }
            mc.state = State.mPlaying;
        }

        //停止

        public void StopT()
        {

            TemStr = "";

            TemStr = TemStr.PadLeft(128, Convert.ToChar(" "));

            ilong = APIClass.mciSendString("close media", TemStr, 128, 0);

            ilong = APIClass.mciSendString("close all", TemStr, 128, 0);

            mc.state = State.mStop;

        }
        #endregion



        #region 暂停
        /// <summary>
        ///暂停
        /// </summary>
        public void Puase()
        {

            TemStr = "";

            TemStr = TemStr.PadLeft(128, Convert.ToChar(" "));

            ilong = APIClass.mciSendString("pause media", TemStr, TemStr.Length, 0);

            mc.state = State.mPuase;

        }
        #endregion


        #region 调节声音方法
        /// <summary>
        /// 调节声音
        /// </summary>
        /// <param name="value">参数值 0-1000 从小到大</param>
        public void setSoundValue(int value)
        {

            TemStr = "";

            TemStr = TemStr.PadLeft(128, Convert.ToChar(" "));
            int i = APIClass.mciSendString("setaudio media  volume to " + value + " ", null, 0, 0);
        }
        #endregion

        #region 将指定路径去空格

        private string GetCurrPath(string name)
        {

            if (name.Length < 1) return "";

            name = name.Trim();

            name = name.Substring(0, name.Length - 1);

            return name;

        }
        #endregion
    
        #region 总时间
        /// <summary>
        ///总时间
        /// </summary>
        public int Duration
        {

            get
            {

                durLength = "";

                durLength = durLength.PadLeft(128, Convert.ToChar(" "));

                APIClass.mciSendString("status media length", durLength, durLength.Length, 0);

                durLength = durLength.Trim();

                if (durLength == "") return 0;

                return (int)(Convert.ToDouble(durLength) / 1000f);

            }

        }
        #endregion

        #region 当前时间
        /// <summary>
        /// 当前时间
        /// </summary>

        public int CurrentPosition
        {

            get
            {

                durLength = "";

                durLength = durLength.PadLeft(128, Convert.ToChar(" "));

                APIClass.mciSendString("status media position", durLength, durLength.Length, 0);

                mc.iPos = (int)(Convert.ToDouble(durLength) / 1000f);

                return mc.iPos;

            }

        }

    }
        #endregion
     



    
   /// <summary>
    /// 声音API类
   /// </summary>
    public class APIClass
    {

        //获取指定路径的短路径形式。
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetShortPathName(

        string lpszLongPath,

        string shortFile,

        int cchBuffer

        );


        //用于执行声音控制命令
        [DllImport("winmm.dll", EntryPoint = "mciSendString", CharSet = CharSet.Auto)]

        public static extern int mciSendString(

        string lpstrCommand,

        string lpstrReturnString,

        int uReturnLength,

        int hwndCallback

        );



    }

}