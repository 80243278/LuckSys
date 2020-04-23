namespace LuckSys
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.time = new System.Windows.Forms.Timer(this.components);
            this.nfi = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsRightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiSet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiJXGL = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMax = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMusic_swith = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.shuoming = new System.Windows.Forms.Label();
            this.number = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.Label();
            this.lblJiangPin = new System.Windows.Forms.Label();
            this.btnMin = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.huojiang = new System.Windows.Forms.Button();
            this.setting = new System.Windows.Forms.Button();
            this.strat = new System.Windows.Forms.Button();
            this.bgiEnd = new System.Windows.Forms.Timer(this.components);
            this.bgiTime = new System.Windows.Forms.Timer(this.components);
            this.tongzhi = new System.Windows.Forms.Timer(this.components);
            this.tongzhiEnd = new System.Windows.Forms.Timer(this.components);
            this.plbtn = new LuckSys.MyPanel(this.components);
            this.btnJiangXiang = new System.Windows.Forms.Label();
            this.btnCloseSys = new System.Windows.Forms.Label();
            this.btnZuiXiaoHua = new System.Windows.Forms.Label();
            this.btnWin = new System.Windows.Forms.Label();
            this.btnSet = new System.Windows.Forms.Label();
            this.btnSwitch = new System.Windows.Forms.Label();
            this.cmsRightMenu.SuspendLayout();
            this.table.SuspendLayout();
            this.plbtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // time
            // 
            this.time.Interval = 40;
            this.time.Tick += new System.EventHandler(this.time_Tick);
            // 
            // nfi
            // 
            this.nfi.ContextMenuStrip = this.cmsRightMenu;
            this.nfi.Icon = ((System.Drawing.Icon)(resources.GetObject("nfi.Icon")));
            this.nfi.Text = "抽奖系统";
            this.nfi.Visible = true;
            this.nfi.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nfi_MouseDoubleClick);
            // 
            // cmsRightMenu
            // 
            this.cmsRightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSet,
            this.tsmiJXGL,
            this.tsmiMax,
            this.tsmiMusic_swith,
            this.tsmiClose});
            this.cmsRightMenu.Name = "cmsRightMenu";
            this.cmsRightMenu.Size = new System.Drawing.Size(149, 114);
            // 
            // tsmiSet
            // 
            this.tsmiSet.Name = "tsmiSet";
            this.tsmiSet.Size = new System.Drawing.Size(148, 22);
            this.tsmiSet.Text = "系统设置";
            this.tsmiSet.Click += new System.EventHandler(this.tsmiSet_Click);
            // 
            // tsmiJXGL
            // 
            this.tsmiJXGL.Name = "tsmiJXGL";
            this.tsmiJXGL.Size = new System.Drawing.Size(148, 22);
            this.tsmiJXGL.Text = "奖项管理";
            this.tsmiJXGL.Click += new System.EventHandler(this.tsmiJXGL_Click);
            // 
            // tsmiMax
            // 
            this.tsmiMax.Name = "tsmiMax";
            this.tsmiMax.Size = new System.Drawing.Size(148, 22);
            this.tsmiMax.Text = "最大化";
            this.tsmiMax.Click += new System.EventHandler(this.tsmiMax_Click);
            // 
            // tsmiMusic_swith
            // 
            this.tsmiMusic_swith.Name = "tsmiMusic_swith";
            this.tsmiMusic_swith.Size = new System.Drawing.Size(148, 22);
            this.tsmiMusic_swith.Text = "关闭背景音乐";
            this.tsmiMusic_swith.Click += new System.EventHandler(this.tsmiMusic_swith_Click);
            // 
            // tsmiClose
            // 
            this.tsmiClose.Name = "tsmiClose";
            this.tsmiClose.Size = new System.Drawing.Size(148, 22);
            this.tsmiClose.Text = "退出";
            this.tsmiClose.Click += new System.EventHandler(this.tsmiClose_Click);
            // 
            // table
            // 
            this.table.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("table.BackgroundImage")));
            this.table.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.table.ColumnCount = 1;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table.Controls.Add(this.shuoming, 0, 4);
            this.table.Controls.Add(this.number, 0, 2);
            this.table.Controls.Add(this.plbtn, 0, 3);
            this.table.Controls.Add(this.txtTitle, 0, 0);
            this.table.Controls.Add(this.lblJiangPin, 0, 1);
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Name = "table";
            this.table.RowCount = 5;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.27669F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.977255F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.43684F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.39044F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.91877F));
            this.table.Size = new System.Drawing.Size(784, 562);
            this.table.TabIndex = 0;
            // 
            // shuoming
            // 
            this.shuoming.AutoSize = true;
            this.shuoming.BackColor = System.Drawing.Color.Transparent;
            this.shuoming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shuoming.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.shuoming.ForeColor = System.Drawing.Color.Yellow;
            this.shuoming.Location = new System.Drawing.Point(3, 499);
            this.shuoming.Name = "shuoming";
            this.shuoming.Size = new System.Drawing.Size(778, 63);
            this.shuoming.TabIndex = 20;
            this.shuoming.Text = "说明文字";
            this.shuoming.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // number
            // 
            this.number.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.number.BackColor = System.Drawing.Color.Transparent;
            this.number.Font = new System.Drawing.Font("黑体", 264.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.number.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(150)))));
            this.number.Location = new System.Drawing.Point(3, 107);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(778, 334);
            this.number.TabIndex = 11;
            this.number.Text = "000";
            this.number.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.number.Click += new System.EventHandler(this.number_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.AllowDrop = true;
            this.txtTitle.BackColor = System.Drawing.Color.Transparent;
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTitle.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTitle.ForeColor = System.Drawing.Color.Yellow;
            this.txtTitle.Location = new System.Drawing.Point(3, 0);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(778, 57);
            this.txtTitle.TabIndex = 9;
            this.txtTitle.Text = "北大青鸟沈阳三好校区抽奖系统";
            this.txtTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJiangPin
            // 
            this.lblJiangPin.BackColor = System.Drawing.Color.Transparent;
            this.lblJiangPin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJiangPin.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblJiangPin.ForeColor = System.Drawing.Color.Yellow;
            this.lblJiangPin.Location = new System.Drawing.Point(3, 57);
            this.lblJiangPin.Name = "lblJiangPin";
            this.lblJiangPin.Size = new System.Drawing.Size(778, 50);
            this.lblJiangPin.TabIndex = 21;
            this.lblJiangPin.Text = "奖品名称:学习资料";
            this.lblJiangPin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMin
            // 
            this.btnMin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMin.BackColor = System.Drawing.Color.Transparent;
            this.btnMin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMin.BackgroundImage")));
            this.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMin.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Font = new System.Drawing.Font("华文楷体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMin.Location = new System.Drawing.Point(0, 0);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(110, 45);
            this.btnMin.TabIndex = 16;
            this.btnMin.Text = "最小化";
            this.btnMin.UseVisualStyleBackColor = false;
            // 
            // close
            // 
            this.close.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.close.BackColor = System.Drawing.Color.Transparent;
            this.close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("close.BackgroundImage")));
            this.close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.close.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(65)))), ((int)(((byte)(28)))));
            this.close.FlatAppearance.BorderSize = 0;
            this.close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.Font = new System.Drawing.Font("华文楷体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.close.Location = new System.Drawing.Point(611, 19);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(110, 45);
            this.close.TabIndex = 15;
            this.close.Text = "退出系统";
            this.close.UseVisualStyleBackColor = false;
            // 
            // huojiang
            // 
            this.huojiang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.huojiang.BackColor = System.Drawing.Color.Transparent;
            this.huojiang.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("huojiang.BackgroundImage")));
            this.huojiang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.huojiang.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.huojiang.FlatAppearance.BorderSize = 0;
            this.huojiang.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.huojiang.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.huojiang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.huojiang.Font = new System.Drawing.Font("华文楷体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.huojiang.Location = new System.Drawing.Point(348, 18);
            this.huojiang.Name = "huojiang";
            this.huojiang.Size = new System.Drawing.Size(110, 45);
            this.huojiang.TabIndex = 14;
            this.huojiang.Text = "获奖名单";
            this.huojiang.UseVisualStyleBackColor = false;
            // 
            // setting
            // 
            this.setting.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.setting.BackColor = System.Drawing.Color.Transparent;
            this.setting.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("setting.BackgroundImage")));
            this.setting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.setting.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this.setting.FlatAppearance.BorderSize = 0;
            this.setting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.setting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.setting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setting.Font = new System.Drawing.Font("华文楷体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.setting.Location = new System.Drawing.Point(212, 21);
            this.setting.Name = "setting";
            this.setting.Size = new System.Drawing.Size(110, 45);
            this.setting.TabIndex = 7;
            this.setting.Text = "系统设置";
            this.setting.UseVisualStyleBackColor = false;
            // 
            // strat
            // 
            this.strat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.strat.BackColor = System.Drawing.Color.Transparent;
            this.strat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("strat.BackgroundImage")));
            this.strat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.strat.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.strat.FlatAppearance.BorderSize = 0;
            this.strat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.strat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.strat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.strat.Font = new System.Drawing.Font("华文楷体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.strat.Location = new System.Drawing.Point(66, 19);
            this.strat.Name = "strat";
            this.strat.Size = new System.Drawing.Size(110, 45);
            this.strat.TabIndex = 4;
            this.strat.Text = "开始";
            this.strat.UseVisualStyleBackColor = false;
            // 
            // bgiEnd
            // 
            this.bgiEnd.Interval = 2500;
            this.bgiEnd.Tick += new System.EventHandler(this.bgiEnd_Tick);
            // 
            // bgiTime
            // 
            this.bgiTime.Interval = 1;
            this.bgiTime.Tick += new System.EventHandler(this.bgiTime_Tick);
            // 
            // tongzhi
            // 
            this.tongzhi.Interval = 1;
            this.tongzhi.Tick += new System.EventHandler(this.tongzhi_Tick);
            // 
            // tongzhiEnd
            // 
            this.tongzhiEnd.Interval = 2000;
            this.tongzhiEnd.Tick += new System.EventHandler(this.tongzhiEnd_Tick);
            // 
            // plbtn
            // 
            this.plbtn.BackColor = System.Drawing.Color.Transparent;
            this.plbtn.Controls.Add(this.btnJiangXiang);
            this.plbtn.Controls.Add(this.btnCloseSys);
            this.plbtn.Controls.Add(this.btnZuiXiaoHua);
            this.plbtn.Controls.Add(this.btnWin);
            this.plbtn.Controls.Add(this.btnSet);
            this.plbtn.Controls.Add(this.btnSwitch);
            this.plbtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plbtn.Location = new System.Drawing.Point(3, 444);
            this.plbtn.Name = "plbtn";
            this.plbtn.Size = new System.Drawing.Size(778, 52);
            this.plbtn.TabIndex = 19;
            // 
            // btnJiangXiang
            // 
            this.btnJiangXiang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnJiangXiang.Font = new System.Drawing.Font("华文楷体", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJiangXiang.Image = ((System.Drawing.Image)(resources.GetObject("btnJiangXiang.Image")));
            this.btnJiangXiang.Location = new System.Drawing.Point(386, 0);
            this.btnJiangXiang.Name = "btnJiangXiang";
            this.btnJiangXiang.Size = new System.Drawing.Size(110, 45);
            this.btnJiangXiang.TabIndex = 25;
            this.btnJiangXiang.Text = "奖项管理";
            this.btnJiangXiang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnJiangXiang.Click += new System.EventHandler(this.btnJiangXiang_Click);
            this.btnJiangXiang.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJiangXiang_MouseDown);
            this.btnJiangXiang.MouseLeave += new System.EventHandler(this.btnJiangXiang_MouseLeave);
            this.btnJiangXiang.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnJiangXiang_MouseMove);
            this.btnJiangXiang.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJiangXiang_MouseUp);
            // 
            // btnCloseSys
            // 
            this.btnCloseSys.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCloseSys.Font = new System.Drawing.Font("华文楷体", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCloseSys.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseSys.Image")));
            this.btnCloseSys.Location = new System.Drawing.Point(630, 0);
            this.btnCloseSys.Name = "btnCloseSys";
            this.btnCloseSys.Size = new System.Drawing.Size(110, 45);
            this.btnCloseSys.TabIndex = 23;
            this.btnCloseSys.Text = "退出系统";
            this.btnCloseSys.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCloseSys.Click += new System.EventHandler(this.closeSys_Click);
            this.btnCloseSys.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnCloseSys_MouseDown);
            this.btnCloseSys.MouseLeave += new System.EventHandler(this.btnCloseSys_MouseLeave);
            this.btnCloseSys.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCloseSys_MouseMove);
            this.btnCloseSys.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnCloseSys_MouseUp);
            // 
            // btnZuiXiaoHua
            // 
            this.btnZuiXiaoHua.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnZuiXiaoHua.Font = new System.Drawing.Font("华文楷体", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnZuiXiaoHua.Image = ((System.Drawing.Image)(resources.GetObject("btnZuiXiaoHua.Image")));
            this.btnZuiXiaoHua.Location = new System.Drawing.Point(508, 0);
            this.btnZuiXiaoHua.Name = "btnZuiXiaoHua";
            this.btnZuiXiaoHua.Size = new System.Drawing.Size(110, 48);
            this.btnZuiXiaoHua.TabIndex = 22;
            this.btnZuiXiaoHua.Text = "最小化";
            this.btnZuiXiaoHua.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnZuiXiaoHua.Click += new System.EventHandler(this.btn_min_Click);
            this.btnZuiXiaoHua.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnZuiXiaoHua_MouseDown);
            this.btnZuiXiaoHua.MouseLeave += new System.EventHandler(this.btnZuiXiaoHua_MouseLeave);
            this.btnZuiXiaoHua.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnZuiXiaoHua_MouseMove);
            this.btnZuiXiaoHua.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnZuiXiaoHua_MouseUp);
            // 
            // btnWin
            // 
            this.btnWin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnWin.Font = new System.Drawing.Font("华文楷体", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWin.Image = ((System.Drawing.Image)(resources.GetObject("btnWin.Image")));
            this.btnWin.Location = new System.Drawing.Point(264, 0);
            this.btnWin.Name = "btnWin";
            this.btnWin.Size = new System.Drawing.Size(110, 45);
            this.btnWin.TabIndex = 21;
            this.btnWin.Text = "获奖名单";
            this.btnWin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnWin.Click += new System.EventHandler(this.btnWin_Click);
            this.btnWin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnWin_MouseDown);
            this.btnWin.MouseLeave += new System.EventHandler(this.btnWin_MouseLeave);
            this.btnWin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnWin_MouseMove);
            this.btnWin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnWin_MouseUp);
            // 
            // btnSet
            // 
            this.btnSet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSet.Font = new System.Drawing.Font("华文楷体", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSet.Image = ((System.Drawing.Image)(resources.GetObject("btnSet.Image")));
            this.btnSet.Location = new System.Drawing.Point(142, 0);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(110, 45);
            this.btnSet.TabIndex = 20;
            this.btnSet.Text = "系统设置";
            this.btnSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            this.btnSet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSet_MouseDown);
            this.btnSet.MouseLeave += new System.EventHandler(this.btnSet_MouseLeave);
            this.btnSet.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSet_MouseMove);
            this.btnSet.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSet_MouseUp);
            // 
            // btnSwitch
            // 
            this.btnSwitch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSwitch.Font = new System.Drawing.Font("华文楷体", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSwitch.Image = ((System.Drawing.Image)(resources.GetObject("btnSwitch.Image")));
            this.btnSwitch.Location = new System.Drawing.Point(20, 0);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(110, 45);
            this.btnSwitch.TabIndex = 0;
            this.btnSwitch.Text = "开始";
            this.btnSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            this.btnSwitch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSwitch_MouseDown);
            this.btnSwitch.MouseLeave += new System.EventHandler(this.btnSwitch_MouseLeave);
            this.btnSwitch.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSwitch_MouseMove);
            this.btnSwitch.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSwitch_MouseUp);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.table);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "抽奖软件";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Main_KeyUp);
            this.cmsRightMenu.ResumeLayout(false);
            this.table.ResumeLayout(false);
            this.table.PerformLayout();
            this.plbtn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.Button strat;
        private System.Windows.Forms.Button setting;
        private System.Windows.Forms.Button huojiang;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Timer time;
        private MyPanel plbtn = new MyPanel();
        private System.Windows.Forms.Label shuoming;
        private System.Windows.Forms.Label btnSwitch;
        private System.Windows.Forms.Label btnZuiXiaoHua;
        private System.Windows.Forms.Label btnWin;
        private System.Windows.Forms.Label btnSet;
        private System.Windows.Forms.Label btnCloseSys;
        private System.Windows.Forms.NotifyIcon nfi;
        private System.Windows.Forms.ContextMenuStrip cmsRightMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiSet;
        private System.Windows.Forms.ToolStripMenuItem tsmiMax;
        private System.Windows.Forms.ToolStripMenuItem tsmiClose;
        public System.Windows.Forms.ToolStripMenuItem tsmiMusic_swith;
        private System.Windows.Forms.Label btnJiangXiang;
        public System.Windows.Forms.Label number;
        private System.Windows.Forms.ToolStripMenuItem tsmiJXGL;
        private System.Windows.Forms.Timer bgiEnd;
        private System.Windows.Forms.Timer bgiTime;
        public System.Windows.Forms.Label txtTitle;
        public System.Windows.Forms.Label lblJiangPin;
        private System.Windows.Forms.Timer tongzhi;
        private System.Windows.Forms.Timer tongzhiEnd;

    }
}