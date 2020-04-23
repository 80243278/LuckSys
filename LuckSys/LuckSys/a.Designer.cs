namespace LuckSys
{
    partial class a
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(a));
            this.number = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Timer(this.components);
            this.shuoming = new System.Windows.Forms.Label();
            this.strat = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // number
            // 
            this.number.BackColor = System.Drawing.Color.Transparent;
            this.number.Font = new System.Drawing.Font("微软雅黑", 150F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.number.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.number.Location = new System.Drawing.Point(34, 88);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(993, 280);
            this.number.TabIndex = 1;
            this.number.Text = "000";
            this.number.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // time
            // 
            this.time.Interval = 10;
            this.time.Tick += new System.EventHandler(this.time_Tick);
            // 
            // shuoming
            // 
            this.shuoming.BackColor = System.Drawing.Color.Transparent;
            this.shuoming.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.shuoming.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.shuoming.Location = new System.Drawing.Point(515, 526);
            this.shuoming.Name = "shuoming";
            this.shuoming.Size = new System.Drawing.Size(407, 96);
            this.shuoming.TabIndex = 3;
            this.shuoming.Text = "1232";
            // 
            // strat
            // 
            this.strat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.strat.BackColor = System.Drawing.Color.Transparent;
            this.strat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("strat.BackgroundImage")));
            this.strat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.strat.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.strat.FlatAppearance.BorderSize = 0;
            this.strat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.strat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.strat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.strat.Font = new System.Drawing.Font("华文楷体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.strat.Location = new System.Drawing.Point(147, 393);
            this.strat.Name = "strat";
            this.strat.Size = new System.Drawing.Size(156, 48);
            this.strat.TabIndex = 2;
            this.strat.Text = "开始";
            this.strat.UseVisualStyleBackColor = false;
            this.strat.Click += new System.EventHandler(this.strat_Click);
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
            this.close.Font = new System.Drawing.Font("华文楷体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.close.Location = new System.Drawing.Point(678, 393);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(156, 48);
            this.close.TabIndex = 4;
            this.close.Text = "退出系统";
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("华文楷体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(420, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 48);
            this.button1.TabIndex = 5;
            this.button1.Text = "系统设置";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.title.Location = new System.Drawing.Point(-14, 27);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(1024, 44);
            this.title.TabIndex = 6;
            this.title.Text = "北大青鸟抽奖系统";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LuckSys.Properties.Resources.backgroup;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1022, 631);
            this.Controls.Add(this.title);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.close);
            this.Controls.Add(this.shuoming);
            this.Controls.Add(this.strat);
            this.Controls.Add(this.number);
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label number;
        private System.Windows.Forms.Timer time;
        private System.Windows.Forms.Label shuoming;
        private System.Windows.Forms.Button strat;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label title;
    }
}

