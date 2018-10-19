﻿namespace SKCOMTester
{
    partial class Form1
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
            this.btnInitialize = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPassWord2 = new System.Windows.Forms.TextBox();
            this.txtAccount2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Chk_Env = new System.Windows.Forms.CheckBox();
            this.listInformation = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Center_Log = new System.Windows.Forms.Button();
            this.txt_Center_LogPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.skooQuote1 = new SKCOMTester.SKOOQuote();
            this.tabpage4 = new System.Windows.Forms.TabPage();
            this.skosQuote1 = new SKCOMTester.SKOSQuote();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.skQuote1 = new SKCOMTester.SKQuote();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.skReply1 = new SKCOMTester.SKReply();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.skOrder1 = new SKCOMTester.SKOrder();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblSignalSGXAPI = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabpage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInitialize
            // 
            this.btnInitialize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnInitialize.Location = new System.Drawing.Point(850, 31);
            this.btnInitialize.Margin = new System.Windows.Forms.Padding(4);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(55, 31);
            this.btnInitialize.TabIndex = 21;
            this.btnInitialize.Text = "LogIn1";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPassword.Location = new System.Drawing.Point(630, 33);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(75, 15);
            this.lblPassword.TabIndex = 20;
            this.lblPassword.Text = "Password：";
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(710, 11);
            this.txtPassWord.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(132, 22);
            this.txtPassWord.TabIndex = 19;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblAccount.Location = new System.Drawing.Point(422, 34);
            this.lblAccount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(69, 15);
            this.lblAccount.TabIndex = 18;
            this.lblAccount.Text = "Account：";
            // 
            // txtAccount
            // 
            this.txtAccount.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtAccount.Location = new System.Drawing.Point(490, 10);
            this.txtAccount.Margin = new System.Windows.Forms.Padding(4);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(132, 25);
            this.txtAccount.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.txtPassWord2);
            this.groupBox1.Controls.Add(this.txtAccount2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.Chk_Env);
            this.groupBox1.Controls.Add(this.listInformation);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btn_Center_Log);
            this.groupBox1.Controls.Add(this.txt_Center_LogPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnInitialize);
            this.groupBox1.Controls.Add(this.txtAccount);
            this.groupBox1.Controls.Add(this.lblPassword);
            this.groupBox1.Controls.Add(this.lblAccount);
            this.groupBox1.Controls.Add(this.txtPassWord);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1014, 180);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. Center";
            // 
            // txtPassWord2
            // 
            this.txtPassWord2.Location = new System.Drawing.Point(710, 37);
            this.txtPassWord2.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassWord2.Name = "txtPassWord2";
            this.txtPassWord2.PasswordChar = '*';
            this.txtPassWord2.Size = new System.Drawing.Size(132, 22);
            this.txtPassWord2.TabIndex = 28;
            // 
            // txtAccount2
            // 
            this.txtAccount2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtAccount2.Location = new System.Drawing.Point(490, 37);
            this.txtAccount2.Margin = new System.Windows.Forms.Padding(4);
            this.txtAccount2.Name = "txtAccount2";
            this.txtAccount2.Size = new System.Drawing.Size(132, 25);
            this.txtAccount2.TabIndex = 27;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(913, 31);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 31);
            this.button1.TabIndex = 29;
            this.button1.Text = "LogIn2";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Chk_Env
            // 
            this.Chk_Env.AutoSize = true;
            this.Chk_Env.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Chk_Env.Location = new System.Drawing.Point(850, 14);
            this.Chk_Env.Name = "Chk_Env";
            this.Chk_Env.Size = new System.Drawing.Size(72, 16);
            this.Chk_Env.TabIndex = 26;
            this.Chk_Env.Text = "模擬平台";
            this.Chk_Env.UseVisualStyleBackColor = true;
            // 
            // listInformation
            // 
            this.listInformation.FormattingEnabled = true;
            this.listInformation.HorizontalExtent = 2;
            this.listInformation.HorizontalScrollbar = true;
            this.listInformation.ItemHeight = 12;
            this.listInformation.Location = new System.Drawing.Point(8, 69);
            this.listInformation.Name = "listInformation";
            this.listInformation.ScrollAlwaysVisible = true;
            this.listInformation.Size = new System.Drawing.Size(949, 88);
            this.listInformation.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(423, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "2. 登入";
            // 
            // btn_Center_Log
            // 
            this.btn_Center_Log.Location = new System.Drawing.Point(281, 34);
            this.btn_Center_Log.Name = "btn_Center_Log";
            this.btn_Center_Log.Size = new System.Drawing.Size(83, 23);
            this.btn_Center_Log.TabIndex = 24;
            this.btn_Center_Log.Text = "變更LOG路徑";
            this.btn_Center_Log.UseVisualStyleBackColor = true;
            this.btn_Center_Log.Click += new System.EventHandler(this.btn_Center_Log_Click);
            // 
            // txt_Center_LogPath
            // 
            this.txt_Center_LogPath.Location = new System.Drawing.Point(8, 36);
            this.txt_Center_LogPath.Name = "txt_Center_LogPath";
            this.txt_Center_LogPath.Size = new System.Drawing.Size(246, 22);
            this.txt_Center_LogPath.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "1. 變更Log儲存路徑-預設存於執行檔目錄下，LOG產生後中途變更路徑無效";
            // 
            // tabPage5
            // 
            this.tabPage5.AutoScroll = true;
            this.tabPage5.Controls.Add(this.skooQuote1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1006, 793);
            this.tabPage5.TabIndex = 5;
            this.tabPage5.Text = "海選報價";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // skooQuote1
            // 
            this.skooQuote1.Location = new System.Drawing.Point(41, 20);
            this.skooQuote1.Name = "skooQuote1";
            this.skooQuote1.Size = new System.Drawing.Size(900, 577);
            this.skooQuote1.SKOOQuoteLib = null;
            this.skooQuote1.TabIndex = 0;
            this.skooQuote1.GetMessage += new SKCOMTester.SKOOQuote.MyMessageHandler(this.GetMessage);
            // 
            // tabpage4
            // 
            this.tabpage4.AutoScroll = true;
            this.tabpage4.Controls.Add(this.skosQuote1);
            this.tabpage4.Location = new System.Drawing.Point(4, 22);
            this.tabpage4.Name = "tabpage4";
            this.tabpage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabpage4.Size = new System.Drawing.Size(1006, 793);
            this.tabpage4.TabIndex = 4;
            this.tabpage4.Text = "海期報價";
            this.tabpage4.UseVisualStyleBackColor = true;
            // 
            // skosQuote1
            // 
            this.skosQuote1.Location = new System.Drawing.Point(7, 6);
            this.skosQuote1.LoginID = "";
            this.skosQuote1.Name = "skosQuote1";
            this.skosQuote1.Size = new System.Drawing.Size(959, 593);
            this.skosQuote1.SKOSQuoteLib = null;
            this.skosQuote1.TabIndex = 0;
            this.skosQuote1.GetMessage += new SKCOMTester.SKOSQuote.MyMessageHandler(this.GetMessage);
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.Controls.Add(this.skQuote1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1006, 793);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "報價";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // skQuote1
            // 
            this.skQuote1.Location = new System.Drawing.Point(37, 6);
            this.skQuote1.LoginID = "";
            this.skQuote1.LoginID2 = "";
            this.skQuote1.Name = "skQuote1";
            this.skQuote1.Size = new System.Drawing.Size(907, 487);
            this.skQuote1.SKQuoteLib = null;
            this.skQuote1.SKQuoteLib2 = null;
            this.skQuote1.TabIndex = 0;
            this.skQuote1.GetMessage += new SKCOMTester.SKQuote.MyMessageHandler(this.GetMessage);
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.skReply1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1006, 793);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "回報";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // skReply1
            // 
            this.skReply1.AutoSize = true;
            this.skReply1.Location = new System.Drawing.Point(3, 6);
            this.skReply1.LoginID = "";
            this.skReply1.LoginID2 = "";
            this.skReply1.Name = "skReply1";
            this.skReply1.Size = new System.Drawing.Size(1000, 738);
            this.skReply1.SKReplyLib = null;
            this.skReply1.SKReplyLib2 = null;
            this.skReply1.TabIndex = 0;
            this.skReply1.GetMessage += new SKCOMTester.SKReply.MyMessageHandler(this.GetMessage);
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.skOrder1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1006, 793);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "下單";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // skOrder1
            // 
            this.skOrder1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.skOrder1.Location = new System.Drawing.Point(10, 32);
            this.skOrder1.LoginID = "";
            this.skOrder1.Name = "skOrder1";
            this.skOrder1.OrderObj = null;
            this.skOrder1.Size = new System.Drawing.Size(966, 755);
            this.skOrder1.TabIndex = 0;
            this.skOrder1.GetMessage += new SKCOMTester.SKOrder.MyMessageHandler(this.GetMessage);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabpage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 198);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1014, 819);
            this.tabControl1.TabIndex = 23;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblSignalSGXAPI);
            this.groupBox3.Location = new System.Drawing.Point(963, 69);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(70, 54);
            this.groupBox3.TabIndex = 52;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SGX_API";
            // 
            // lblSignalSGXAPI
            // 
            this.lblSignalSGXAPI.AutoSize = true;
            this.lblSignalSGXAPI.Font = new System.Drawing.Font("PMingLiU", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSignalSGXAPI.ForeColor = System.Drawing.Color.Red;
            this.lblSignalSGXAPI.Location = new System.Drawing.Point(15, 18);
            this.lblSignalSGXAPI.Name = "lblSignalSGXAPI";
            this.lblSignalSGXAPI.Size = new System.Drawing.Size(32, 22);
            this.lblSignalSGXAPI.TabIndex = 0;
            this.lblSignalSGXAPI.Text = "●";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 1029);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabpage4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Center_Log;
        private System.Windows.Forms.TextBox txt_Center_LogPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listInformation;
        private System.Windows.Forms.CheckBox Chk_Env;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPassWord2;
        private System.Windows.Forms.TextBox txtAccount2;
        private System.Windows.Forms.TabPage tabPage5;
        private SKOOQuote skooQuote1;
        private System.Windows.Forms.TabPage tabpage4;
        private SKOSQuote skosQuote1;
        private System.Windows.Forms.TabPage tabPage3;
        private SKQuote skQuote1;
        private System.Windows.Forms.TabPage tabPage1;
        private SKReply skReply1;
        private System.Windows.Forms.TabPage tabPage2;
        private SKOrder skOrder1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblSignalSGXAPI;

    }
}

