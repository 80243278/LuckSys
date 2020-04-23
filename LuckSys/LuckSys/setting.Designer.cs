namespace LuckSys
{
    partial class setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(setting));
            this.label1 = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.jiangCount = new System.Windows.Forms.NumericUpDown();
            this.save = new System.Windows.Forms.Button();
            this.fanhui = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.musicbtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.nudNum = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_YinCang = new System.Windows.Forms.Button();
            this.ofdBgm = new System.Windows.Forms.OpenFileDialog();
            this.txtBGM = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSelectBgm = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrizePro = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.jiangCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "标题名称";
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(110, 26);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(226, 21);
            this.title.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "奖券数量";
            // 
            // jiangCount
            // 
            this.jiangCount.Location = new System.Drawing.Point(98, 145);
            this.jiangCount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.jiangCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.jiangCount.Name = "jiangCount";
            this.jiangCount.Size = new System.Drawing.Size(75, 21);
            this.jiangCount.TabIndex = 4;
            this.jiangCount.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(34, 212);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 5;
            this.save.Text = "保存";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // fanhui
            // 
            this.fanhui.Location = new System.Drawing.Point(349, 212);
            this.fanhui.Name = "fanhui";
            this.fanhui.Size = new System.Drawing.Size(75, 23);
            this.fanhui.TabIndex = 5;
            this.fanhui.Text = "返回";
            this.fanhui.UseVisualStyleBackColor = true;
            this.fanhui.Click += new System.EventHandler(this.fanhui_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(305, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "默认：500张，最低为2张。可按照实际情况，增加或减少";
            // 
            // musicbtn
            // 
            this.musicbtn.Location = new System.Drawing.Point(125, 212);
            this.musicbtn.Name = "musicbtn";
            this.musicbtn.Size = new System.Drawing.Size(95, 23);
            this.musicbtn.TabIndex = 9;
            this.musicbtn.Text = "关闭背景音乐";
            this.musicbtn.UseVisualStyleBackColor = true;
            this.musicbtn.Click += new System.EventHandler(this.musicbtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "默认：5人，最低为1人根据实际情况修改";
            // 
            // nudNum
            // 
            this.nudNum.Location = new System.Drawing.Point(98, 172);
            this.nudNum.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.nudNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNum.Name = "nudNum";
            this.nudNum.Size = new System.Drawing.Size(75, 21);
            this.nudNum.TabIndex = 11;
            this.nudNum.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "每轮人数：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(342, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "不填写，则不显示该项";
            // 
            // btn_YinCang
            // 
            this.btn_YinCang.Location = new System.Drawing.Point(236, 212);
            this.btn_YinCang.Name = "btn_YinCang";
            this.btn_YinCang.Size = new System.Drawing.Size(97, 23);
            this.btn_YinCang.TabIndex = 9;
            this.btn_YinCang.Text = "隐藏奖项显示区";
            this.btn_YinCang.UseVisualStyleBackColor = true;
            this.btn_YinCang.Click += new System.EventHandler(this.btn_YinCang_Click);
            // 
            // txtBGM
            // 
            this.txtBGM.Location = new System.Drawing.Point(110, 59);
            this.txtBGM.Name = "txtBGM";
            this.txtBGM.Size = new System.Drawing.Size(226, 21);
            this.txtBGM.TabIndex = 18;
            this.txtBGM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBGM_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "背景音乐";
            // 
            // btnSelectBgm
            // 
            this.btnSelectBgm.Location = new System.Drawing.Point(350, 57);
            this.btnSelectBgm.Name = "btnSelectBgm";
            this.btnSelectBgm.Size = new System.Drawing.Size(75, 23);
            this.btnSelectBgm.TabIndex = 21;
            this.btnSelectBgm.Text = "浏览";
            this.btnSelectBgm.UseVisualStyleBackColor = true;
            this.btnSelectBgm.Click += new System.EventHandler(this.btnSelectBgm_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(342, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 12);
            this.label9.TabIndex = 24;
            this.label9.Text = "不设置奖项时的提示语";
            // 
            // txtPrizePro
            // 
            this.txtPrizePro.Location = new System.Drawing.Point(110, 101);
            this.txtPrizePro.Name = "txtPrizePro";
            this.txtPrizePro.Size = new System.Drawing.Size(226, 21);
            this.txtPrizePro.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "奖项提示语";
            // 
            // setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 252);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPrizePro);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnSelectBgm);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBGM);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_YinCang);
            this.Controls.Add(this.musicbtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fanhui);
            this.Controls.Add(this.save);
            this.Controls.Add(this.jiangCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.title);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统设置";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.setting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jiangCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown jiangCount;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button fanhui;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button musicbtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_YinCang;
        private System.Windows.Forms.OpenFileDialog ofdBgm;
        private System.Windows.Forms.TextBox txtBGM;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSelectBgm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPrizePro;
        private System.Windows.Forms.Label label10;
    }
}