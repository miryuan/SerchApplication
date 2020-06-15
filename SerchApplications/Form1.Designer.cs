namespace SerchApplications
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_xingming = new System.Windows.Forms.TextBox();
            this.tbHardInfo = new System.Windows.Forms.TextBox();
            this.tbSoftList = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cb_bumen = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "部门:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "姓名:";
            // 
            // tb_xingming
            // 
            this.tb_xingming.Location = new System.Drawing.Point(60, 69);
            this.tb_xingming.MaxLength = 20;
            this.tb_xingming.Name = "tb_xingming";
            this.tb_xingming.Size = new System.Drawing.Size(113, 21);
            this.tb_xingming.TabIndex = 3;
            // 
            // tbHardInfo
            // 
            this.tbHardInfo.Location = new System.Drawing.Point(21, 140);
            this.tbHardInfo.Multiline = true;
            this.tbHardInfo.Name = "tbHardInfo";
            this.tbHardInfo.ReadOnly = true;
            this.tbHardInfo.Size = new System.Drawing.Size(363, 298);
            this.tbHardInfo.TabIndex = 4;
            // 
            // tbSoftList
            // 
            this.tbSoftList.Location = new System.Drawing.Point(390, 26);
            this.tbSoftList.Multiline = true;
            this.tbSoftList.Name = "tbSoftList";
            this.tbSoftList.ReadOnly = true;
            this.tbSoftList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSoftList.Size = new System.Drawing.Size(631, 579);
            this.tbSoftList.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(620, 608);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(401, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "精工工业建筑系统有限公司 - 绿色产品事业部 - 智能研发部(2020-06-11)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "硬件信息:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(388, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "识别列表:";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(294, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "上传";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cb_bumen
            // 
            this.cb_bumen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_bumen.FormattingEnabled = true;
            this.cb_bumen.Items.AddRange(new object[] {
            "工业_总经办行政",
            "工业_成本管理部",
            "工业_人力资源部",
            "工业_财务结算中心",
            "工业_营销管理中心",
            "工业_营销管理中心商务部",
            "工业_运营管理中心",
            "工业_运营深化设计部",
            "工业_运营招标采购部",
            "工业_创新研发中心",
            "工业_技术中心",
            "工业_一厂",
            "工业_二厂",
            "工业_三厂",
            "工业_工程管理中心",
            "工业_质量安全部",
            "工业_海外事业部",
            "工业_华东事业部",
            "工业_绿色建筑产品事业部",
            "工业_EPC总承包事业部"});
            this.cb_bumen.Location = new System.Drawing.Point(60, 26);
            this.cb_bumen.Name = "cb_bumen";
            this.cb_bumen.Size = new System.Drawing.Size(323, 20);
            this.cb_bumen.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(199, 110);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "识别软件列表";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 629);
            this.Controls.Add(this.cb_bumen);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbSoftList);
            this.Controls.Add(this.tbHardInfo);
            this.Controls.Add(this.tb_xingming);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "查找软件列表";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_xingming;
        private System.Windows.Forms.TextBox tbHardInfo;
        private System.Windows.Forms.TextBox tbSoftList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cb_bumen;
        private System.Windows.Forms.Button button2;
    }
}

