namespace SKOrderTester
{
    partial class OptionOrderControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.boxReserved = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnSendOptionOrderAsync = new System.Windows.Forms.Button();
            this.btnSendOptionOrder = new System.Windows.Forms.Button();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.boxFlag = new System.Windows.Forms.ComboBox();
            this.boxPeriod = new System.Windows.Forms.ComboBox();
            this.boxBidAsk = new System.Windows.Forms.ComboBox();
            this.txtStockNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSendDuplexOrderAsync = new System.Windows.Forms.Button();
            this.btnSendDuplexOrder = new System.Windows.Forms.Button();
            this.txtDQty = new System.Windows.Forms.TextBox();
            this.txtDPrice = new System.Windows.Forms.TextBox();
            this.boxDFlag = new System.Windows.Forms.ComboBox();
            this.boxDPeriod = new System.Windows.Forms.ComboBox();
            this.boxDBidAsk1 = new System.Windows.Forms.ComboBox();
            this.txtDStockNo1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.boxDBidAsk2 = new System.Windows.Forms.ComboBox();
            this.txtDStockNo2 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.boxReserved);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.btnSendOptionOrderAsync);
            this.groupBox1.Controls.Add(this.btnSendOptionOrder);
            this.groupBox1.Controls.Add(this.txtQty);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.boxFlag);
            this.groupBox1.Controls.Add(this.boxPeriod);
            this.groupBox1.Controls.Add(this.boxBidAsk);
            this.groupBox1.Controls.Add(this.txtStockNo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 90);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "選擇權委託";
            // 
            // boxReserved
            // 
            this.boxReserved.FormattingEnabled = true;
            this.boxReserved.Items.AddRange(new object[] {
            "盤中",
            "T盤預約"});
            this.boxReserved.Location = new System.Drawing.Point(557, 45);
            this.boxReserved.Name = "boxReserved";
            this.boxReserved.Size = new System.Drawing.Size(83, 20);
            this.boxReserved.TabIndex = 21;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(568, 21);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 20;
            this.label18.Text = "盤別";
            // 
            // btnSendOptionOrderAsync
            // 
            this.btnSendOptionOrderAsync.Location = new System.Drawing.Point(661, 43);
            this.btnSendOptionOrderAsync.Name = "btnSendOptionOrderAsync";
            this.btnSendOptionOrderAsync.Size = new System.Drawing.Size(124, 23);
            this.btnSendOptionOrderAsync.TabIndex = 13;
            this.btnSendOptionOrderAsync.Text = "SendOptionOrderAsync";
            this.btnSendOptionOrderAsync.UseVisualStyleBackColor = true;
            this.btnSendOptionOrderAsync.Click += new System.EventHandler(this.btnSendOptionOrderAsync_Click);
            // 
            // btnSendOptionOrder
            // 
            this.btnSendOptionOrder.Location = new System.Drawing.Point(661, 16);
            this.btnSendOptionOrder.Name = "btnSendOptionOrder";
            this.btnSendOptionOrder.Size = new System.Drawing.Size(124, 23);
            this.btnSendOptionOrder.TabIndex = 12;
            this.btnSendOptionOrder.Text = "SendOptionOrder";
            this.btnSendOptionOrder.UseVisualStyleBackColor = true;
            this.btnSendOptionOrder.Click += new System.EventHandler(this.btnSendOptionOrder_Click);
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(502, 45);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(49, 22);
            this.txtQty.TabIndex = 11;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(399, 45);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(74, 22);
            this.txtPrice.TabIndex = 10;
            // 
            // boxFlag
            // 
            this.boxFlag.FormattingEnabled = true;
            this.boxFlag.Items.AddRange(new object[] {
            "新倉",
            "平倉",
            "自動"});
            this.boxFlag.Location = new System.Drawing.Point(303, 45);
            this.boxFlag.Name = "boxFlag";
            this.boxFlag.Size = new System.Drawing.Size(68, 20);
            this.boxFlag.TabIndex = 9;
            // 
            // boxPeriod
            // 
            this.boxPeriod.FormattingEnabled = true;
            this.boxPeriod.Items.AddRange(new object[] {
            "ROD",
            "IOC",
            "FOK"});
            this.boxPeriod.Location = new System.Drawing.Point(204, 43);
            this.boxPeriod.Name = "boxPeriod";
            this.boxPeriod.Size = new System.Drawing.Size(64, 20);
            this.boxPeriod.TabIndex = 8;
            // 
            // boxBidAsk
            // 
            this.boxBidAsk.FormattingEnabled = true;
            this.boxBidAsk.Items.AddRange(new object[] {
            "買",
            "賣"});
            this.boxBidAsk.Location = new System.Drawing.Point(129, 45);
            this.boxBidAsk.Name = "boxBidAsk";
            this.boxBidAsk.Size = new System.Drawing.Size(49, 20);
            this.boxBidAsk.TabIndex = 7;
            // 
            // txtStockNo
            // 
            this.txtStockNo.Location = new System.Drawing.Point(19, 45);
            this.txtStockNo.MaxLength = 20;
            this.txtStockNo.Name = "txtStockNo";
            this.txtStockNo.Size = new System.Drawing.Size(93, 22);
            this.txtStockNo.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(501, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "委託量";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(411, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "委託價";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(315, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "倉別";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "委託條件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "買賣別";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "商品代碼";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.boxDBidAsk2);
            this.groupBox2.Controls.Add(this.txtDStockNo2);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.btnSendDuplexOrderAsync);
            this.groupBox2.Controls.Add(this.btnSendDuplexOrder);
            this.groupBox2.Controls.Add(this.txtDQty);
            this.groupBox2.Controls.Add(this.txtDPrice);
            this.groupBox2.Controls.Add(this.boxDFlag);
            this.groupBox2.Controls.Add(this.boxDPeriod);
            this.groupBox2.Controls.Add(this.boxDBidAsk1);
            this.groupBox2.Controls.Add(this.txtDStockNo1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(3, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 107);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "選擇權複式單";
            // 
            // btnSendDuplexOrderAsync
            // 
            this.btnSendDuplexOrderAsync.Location = new System.Drawing.Point(661, 63);
            this.btnSendDuplexOrderAsync.Name = "btnSendDuplexOrderAsync";
            this.btnSendDuplexOrderAsync.Size = new System.Drawing.Size(124, 23);
            this.btnSendDuplexOrderAsync.TabIndex = 15;
            this.btnSendDuplexOrderAsync.Text = "SendDuplexOrderAsync";
            this.btnSendDuplexOrderAsync.UseVisualStyleBackColor = true;
            this.btnSendDuplexOrderAsync.Click += new System.EventHandler(this.btnSendDuplexOrderAsync_Click);
            // 
            // btnSendDuplexOrder
            // 
            this.btnSendDuplexOrder.Location = new System.Drawing.Point(661, 36);
            this.btnSendDuplexOrder.Name = "btnSendDuplexOrder";
            this.btnSendDuplexOrder.Size = new System.Drawing.Size(124, 23);
            this.btnSendDuplexOrder.TabIndex = 14;
            this.btnSendDuplexOrder.Text = "SendDuplexOrder";
            this.btnSendDuplexOrder.UseVisualStyleBackColor = true;
            this.btnSendDuplexOrder.Click += new System.EventHandler(this.btnSendDuplexOrder_Click);
            // 
            // txtDQty
            // 
            this.txtDQty.Location = new System.Drawing.Point(502, 58);
            this.txtDQty.Name = "txtDQty";
            this.txtDQty.Size = new System.Drawing.Size(49, 22);
            this.txtDQty.TabIndex = 13;
            // 
            // txtDPrice
            // 
            this.txtDPrice.Location = new System.Drawing.Point(399, 58);
            this.txtDPrice.Name = "txtDPrice";
            this.txtDPrice.Size = new System.Drawing.Size(74, 22);
            this.txtDPrice.TabIndex = 12;
            // 
            // boxDFlag
            // 
            this.boxDFlag.FormattingEnabled = true;
            this.boxDFlag.Items.AddRange(new object[] {
            "新倉",
            "平倉"});
            this.boxDFlag.Location = new System.Drawing.Point(303, 58);
            this.boxDFlag.Name = "boxDFlag";
            this.boxDFlag.Size = new System.Drawing.Size(68, 20);
            this.boxDFlag.TabIndex = 11;
            // 
            // boxDPeriod
            // 
            this.boxDPeriod.FormattingEnabled = true;
            this.boxDPeriod.Items.AddRange(new object[] {
            "",
            "IOC",
            "FOK"});
            this.boxDPeriod.Location = new System.Drawing.Point(204, 56);
            this.boxDPeriod.Name = "boxDPeriod";
            this.boxDPeriod.Size = new System.Drawing.Size(64, 20);
            this.boxDPeriod.TabIndex = 10;
            // 
            // boxDBidAsk1
            // 
            this.boxDBidAsk1.FormattingEnabled = true;
            this.boxDBidAsk1.Items.AddRange(new object[] {
            "買",
            "賣"});
            this.boxDBidAsk1.Location = new System.Drawing.Point(129, 36);
            this.boxDBidAsk1.Name = "boxDBidAsk1";
            this.boxDBidAsk1.Size = new System.Drawing.Size(49, 20);
            this.boxDBidAsk1.TabIndex = 7;
            // 
            // txtDStockNo1
            // 
            this.txtDStockNo1.Location = new System.Drawing.Point(19, 36);
            this.txtDStockNo1.MaxLength = 20;
            this.txtDStockNo1.Name = "txtDStockNo1";
            this.txtDStockNo1.Size = new System.Drawing.Size(93, 22);
            this.txtDStockNo1.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(501, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "委託量";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(411, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "委託價";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(315, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "倉別";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(202, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 2;
            this.label11.Text = "委託條件";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(127, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "買賣別1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(39, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "商品代碼1";
            // 
            // boxDBidAsk2
            // 
            this.boxDBidAsk2.FormattingEnabled = true;
            this.boxDBidAsk2.Items.AddRange(new object[] {
            "買",
            "賣"});
            this.boxDBidAsk2.Location = new System.Drawing.Point(129, 76);
            this.boxDBidAsk2.Name = "boxDBidAsk2";
            this.boxDBidAsk2.Size = new System.Drawing.Size(49, 20);
            this.boxDBidAsk2.TabIndex = 9;
            // 
            // txtDStockNo2
            // 
            this.txtDStockNo2.Location = new System.Drawing.Point(19, 76);
            this.txtDStockNo2.MaxLength = 20;
            this.txtDStockNo2.Name = "txtDStockNo2";
            this.txtDStockNo2.Size = new System.Drawing.Size(93, 22);
            this.txtDStockNo2.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(127, 61);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 12);
            this.label14.TabIndex = 23;
            this.label14.Text = "買賣別2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(39, 61);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 22;
            this.label15.Text = "商品代碼2";
            // 
            // OptionOrderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "OptionOrderControl";
            this.Size = new System.Drawing.Size(808, 352);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSendOptionOrderAsync;
        private System.Windows.Forms.Button btnSendOptionOrder;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ComboBox boxFlag;
        private System.Windows.Forms.ComboBox boxPeriod;
        private System.Windows.Forms.ComboBox boxBidAsk;
        private System.Windows.Forms.TextBox txtStockNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox boxReserved;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSendDuplexOrderAsync;
        private System.Windows.Forms.Button btnSendDuplexOrder;
        private System.Windows.Forms.TextBox txtDQty;
        private System.Windows.Forms.TextBox txtDPrice;
        private System.Windows.Forms.ComboBox boxDFlag;
        private System.Windows.Forms.ComboBox boxDPeriod;
        private System.Windows.Forms.ComboBox boxDBidAsk1;
        private System.Windows.Forms.TextBox txtDStockNo1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox boxDBidAsk2;
        private System.Windows.Forms.TextBox txtDStockNo2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}
