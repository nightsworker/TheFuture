using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SKCOMLib;

namespace SKOrderTester
{
    public partial class OptionOrderControl : UserControl
    {
        #region Define Variable
        //----------------------------------------------------------------------
        // Define Variable
        //----------------------------------------------------------------------

        private int m_nCode;
        public string m_strMessage;

        public delegate void MyMessageHandler(string strType, int nCode, string strMessage);
        public event MyMessageHandler GetMessage;

        public delegate void OrderHandler(string strLogInID, bool bAsyncOrder, FUTUREORDER pStock);
        public event OrderHandler OnOptionOrderSignal;

        public delegate void DuplexOrderHandler(string strLogInID, bool bAsyncOrder, FUTUREORDER pStock);
        public event DuplexOrderHandler OnDuplexOrderSignal;


        private string m_UserID = "";
        public string UserID
        {
            get { return m_UserID; }
            set { m_UserID = value; }
        }

        private string m_UserAccount = "";
        public string UserAccount
        {
            get { return m_UserAccount; }
            set { m_UserAccount = value; }
        }

        #endregion

        #region Initialize
        //----------------------------------------------------------------------
        // Initialize
        //----------------------------------------------------------------------
        public OptionOrderControl()
        {
            InitializeComponent();
        }

        #endregion

        private void btnSendOptionOrder_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇期貨帳號");
                return;
            }

            string strFutureNo;
            int nBidAsk;
            int nPeriod;
            int nFlag;
            string strPrice;
            int nQty;
            int nReserved;


            if (txtStockNo.Text.Trim() == "")
            {
                MessageBox.Show("請輸入商品代碼");
                return;
            }
            strFutureNo = txtStockNo.Text.Trim();

            if (boxBidAsk.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇買賣別");
                return;
            }
            nBidAsk = boxBidAsk.SelectedIndex;

            if (boxPeriod.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇委託條件");
                return;
            }
            nPeriod = boxPeriod.SelectedIndex;

            if (boxFlag.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇當沖與否");
                return;
            }
            nFlag = boxFlag.SelectedIndex;

            double dPrice = 0.0;
            if (double.TryParse(txtPrice.Text.Trim(), out dPrice) == false && txtPrice.Text.Trim() != "M" && txtPrice.Text.Trim() != "P")
            {
                MessageBox.Show("委託價請輸入數字");
                return;
            }
            strPrice = txtPrice.Text.Trim();

            if (int.TryParse(txtQty.Text.Trim(), out nQty) == false)
            {
                MessageBox.Show("委託量請輸入數字");
                return;
            }

            if (boxReserved.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇盤別");
                return;
            }
            nReserved = boxReserved.SelectedIndex;

            FUTUREORDER pFutureOrder = new FUTUREORDER();

            pFutureOrder.bstrFullAccount = m_UserAccount;
            pFutureOrder.bstrPrice = strPrice;
            pFutureOrder.bstrStockNo = strFutureNo;
            pFutureOrder.nQty = nQty;
            pFutureOrder.sBuySell = (short)nBidAsk;
            pFutureOrder.sNewClose = (short)nFlag;
            pFutureOrder.sTradeType = (short)nPeriod;
            pFutureOrder.sReserved = (short)nReserved;

            pFutureOrder.bstrTrigger = "";
            pFutureOrder.bstrDealPrice = "";
            pFutureOrder.bstrMovingPoint = "";


            if (OnOptionOrderSignal != null)
            {
                OnOptionOrderSignal(m_UserID, false, pFutureOrder);
            }

        }

        private void btnSendOptionOrderAsync_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇期貨帳號");
                return;
            }

            string strFutureNo;
            int nBidAsk;
            int nPeriod;
            int nFlag;
            string strPrice;
            int nQty;
            int nReserved;


            if (txtStockNo.Text.Trim() == "")
            {
                MessageBox.Show("請輸入商品代碼");
                return;
            }
            strFutureNo = txtStockNo.Text.Trim();

            if (boxBidAsk.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇買賣別");
                return;
            }
            nBidAsk = boxBidAsk.SelectedIndex;

            if (boxPeriod.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇委託條件");
                return;
            }
            nPeriod = boxPeriod.SelectedIndex;

            if (boxFlag.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇倉別");
                return;
            }
            nFlag = boxFlag.SelectedIndex;

            double dPrice = 0.0;
            if (double.TryParse(txtPrice.Text.Trim(), out dPrice) == false && txtPrice.Text.Trim() != "M" && txtPrice.Text.Trim() != "P")
            {
                MessageBox.Show("委託價請輸入數字");
                return;
            }
            strPrice = txtPrice.Text.Trim();

            if (int.TryParse(txtQty.Text.Trim(), out nQty) == false)
            {
                MessageBox.Show("委託量請輸入數字");
                return;
            }

            if (boxReserved.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇盤別");
                return;
            }
            nReserved = boxReserved.SelectedIndex;

            FUTUREORDER pFutureOrder = new FUTUREORDER();

            pFutureOrder.bstrFullAccount = m_UserAccount;
            pFutureOrder.bstrPrice = strPrice;
            pFutureOrder.bstrStockNo = strFutureNo;
            pFutureOrder.nQty = nQty;
            pFutureOrder.sBuySell = (short)nBidAsk;
            pFutureOrder.sNewClose = (short)nFlag;
            pFutureOrder.sTradeType = (short)nPeriod;
            pFutureOrder.sReserved = (short)nReserved;

            pFutureOrder.bstrTrigger = "";
            pFutureOrder.bstrDealPrice = "";
            pFutureOrder.bstrMovingPoint = "";

            if (OnOptionOrderSignal != null)
            {
                OnOptionOrderSignal(m_UserID, true, pFutureOrder);
            }
        }

        private void btnSendDuplexOrder_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇期貨帳號");
                return;
            }

            string strOptionNo1;
            string strOptionNo2;
            int nBidAsk1;
            int nBidAsk2;
            int nPeriod;
            int nFlag;
            string strPrice;
            int nQty;


            if (txtDStockNo1.Text.Trim() == "")
            {
                MessageBox.Show("請輸入商品代碼1");
                return;
            }
            strOptionNo1 = txtDStockNo1.Text.Trim();
            if (txtDStockNo2.Text.Trim() == "")
            {
                MessageBox.Show("請輸入商品代碼2");
                return;
            }
            strOptionNo2 = txtDStockNo2.Text.Trim();

            if (boxDBidAsk1.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇買賣別1");
                return;
            }
            nBidAsk1 = boxDBidAsk1.SelectedIndex;
            if (boxDBidAsk2.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇買賣別2");
                return;
            }
            nBidAsk2 = boxDBidAsk2.SelectedIndex;

            if (boxDPeriod.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇委託條件");
                return;
            }
            nPeriod = boxDPeriod.SelectedIndex;

            if (boxDFlag.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇當沖與否");
                return;
            }
            nFlag = boxDFlag.SelectedIndex;

            double dPrice = 0.0;
            if (double.TryParse(txtDPrice.Text.Trim(), out dPrice) == false && txtDPrice.Text.Trim() != "M" && txtDPrice.Text.Trim() != "P")
            {
                MessageBox.Show("委託價請輸入數字");
                return;
            }
            strPrice = txtDPrice.Text.Trim();

            if (int.TryParse(txtDQty.Text.Trim(), out nQty) == false)
            {
                MessageBox.Show("委託量請輸入數字");
                return;
            }

            FUTUREORDER pFutureOrder = new FUTUREORDER();

            pFutureOrder.bstrFullAccount = m_UserAccount;
            pFutureOrder.bstrPrice = strPrice;
            pFutureOrder.bstrStockNo = strOptionNo1;
            pFutureOrder.bstrStockNo2 = strOptionNo2;
            pFutureOrder.nQty = nQty;
            pFutureOrder.sBuySell = (short)nBidAsk1;
            pFutureOrder.sBuySell2 = (short)nBidAsk2;
            pFutureOrder.sNewClose = (short)nFlag;
            pFutureOrder.sTradeType = (short)nPeriod;

            if (OnDuplexOrderSignal != null)
            {
                OnDuplexOrderSignal(m_UserID, false, pFutureOrder);
            }
        }

        private void btnSendDuplexOrderAsync_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇期貨帳號");
                return;
            }

            string strOptionNo1;
            string strOptionNo2;
            int nBidAsk1;
            int nBidAsk2;
            int nPeriod;
            int nFlag;
            string strPrice;
            int nQty;


            if (txtDStockNo1.Text.Trim() == "")
            {
                MessageBox.Show("請輸入商品代碼1");
                return;
            }
            strOptionNo1 = txtDStockNo1.Text.Trim();
            if (txtDStockNo2.Text.Trim() == "")
            {
                MessageBox.Show("請輸入商品代碼2");
                return;
            }
            strOptionNo2 = txtDStockNo2.Text.Trim();

            if (boxDBidAsk1.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇買賣別1");
                return;
            }
            nBidAsk1 = boxDBidAsk1.SelectedIndex;
            if (boxDBidAsk2.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇買賣別2");
                return;
            }
            nBidAsk2 = boxDBidAsk2.SelectedIndex;

            if (boxDPeriod.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇委託條件");
                return;
            }
            nPeriod = boxDPeriod.SelectedIndex;

            if (boxDFlag.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇當沖與否");
                return;
            }
            nFlag = boxDFlag.SelectedIndex;

            double dPrice = 0.0;
            if (double.TryParse(txtDPrice.Text.Trim(), out dPrice) == false && txtDPrice.Text.Trim() != "M" && txtDPrice.Text.Trim() != "P")
            {
                MessageBox.Show("委託價請輸入數字");
                return;
            }
            strPrice = txtDPrice.Text.Trim();

            if (int.TryParse(txtDQty.Text.Trim(), out nQty) == false)
            {
                MessageBox.Show("委託量請輸入數字");
                return;
            }

            FUTUREORDER pFutureOrder = new FUTUREORDER();

            pFutureOrder.bstrFullAccount = m_UserAccount;
            pFutureOrder.bstrPrice = strPrice;
            pFutureOrder.bstrStockNo = strOptionNo1;
            pFutureOrder.bstrStockNo2 = strOptionNo2;
            pFutureOrder.nQty = nQty;
            pFutureOrder.sBuySell = (short)nBidAsk1;
            pFutureOrder.sBuySell2 = (short)nBidAsk2;
            pFutureOrder.sNewClose = (short)nFlag;
            pFutureOrder.sTradeType = (short)nPeriod;

            if (OnDuplexOrderSignal != null)
            {
                OnDuplexOrderSignal(m_UserID, true, pFutureOrder);
            }
        }
    }
}
