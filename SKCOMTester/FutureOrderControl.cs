using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SKCOMLib;
using System.Threading;

namespace SKOrderTester
{
    public partial class FutureOrderControl : UserControl
    {
        #region Define Variable
        //----------------------------------------------------------------------
        // Define Variable
        //----------------------------------------------------------------------
        public Dictionary<int, int> m_kma1;
        public Dictionary<int, int> m_kpast9ma;
        public Dictionary<int, int> m_kRSV;
        public Dictionary<int, int> m_kRSI;
        public Dictionary<int, int> m_kK;
        public Dictionary<int, int> m_kD;
        public List<int> m_kmaUp9;
        public List<int> m_kmaDn9;
        public int m_nRSVCount;
        public int m_nNowNum;
        public int m_nNowPrice;
        public int m_nNowMa1;
        public int m_nNowM;
        public int m_nNowRSV;
        public int m_nNowRSI;
        public int m_nNowK;
        public int m_nNowD;
        public int m_nMyPrice;
        private int m_nCode;
        private DataTable m_dtStocks;
        private bool m_bfirst = true;
        public string m_strMessage;
        private SKSTOCK m_pSKStock;

        public delegate void MyMessageHandler(string strType, int nCode, string strMessage);
        public event MyMessageHandler GetMessage;

        public delegate void OrderHandler(string strLogInID, bool bAsyncOrder, FUTUREORDER pStock);
        public event OrderHandler OnFutureOrderSignal;

        public delegate void OrderCLRHandler(string strLogInID, bool bAsyncOrder, FUTUREORDER pStock);
        public event OrderCLRHandler OnFutureOrderCLRSignal;

        public delegate void DecreaseOrderHandler(string strLogInID, bool bAsyncOrder, string strAccount, string strSeqNo, int nDecreaseQty);
        public event DecreaseOrderHandler OnDecreaseOrderSignal;

        public delegate void CancelOrderHandler(string strLogInID, bool bAsyncOrder, string strAccount, string strSeqNo);
        public event CancelOrderHandler OnCancelOrderSignal;

        public delegate void CancelOrderByStockHandler(string strLogInID, bool bAsyncOrder, string strAccount, string strStockNo);
        public event CancelOrderByStockHandler OnCancelOrderByStockSignal;


        public delegate void CorrectPriceBySeqNoHandler(string strLogInID, bool bAsyncOrder, string strAccount, string strSeqNo, string strPrice, int nTradeType);
        public event CorrectPriceBySeqNoHandler OnCorrectPriceBySeqNo;

        public delegate void CorrectPriceByBookNoHandler(string strLogInID, bool bAsyncOrder, string strAccount, string strSymbol, string strSeqNo, string strPrice, int nTradeType);
        public event CorrectPriceByBookNoHandler OnCorrectPriceByBookNo;


        public delegate void OpenInterestHandler(string strLogInID, string strAccount);
        public event OpenInterestHandler OnOpenInterestSignal;

        public delegate void FutureRightsHandler(string strLogInID, string strAccount, int nCoinType);
        public event FutureRightsHandler OnFutureRightsSignal;

        public delegate void CancelOrderByBookHandler(string strLogInID, bool bAsyncOrder, string strAccount, string strBookNo);
        public event CancelOrderByBookHandler OnCancelOrderByBookSignal;


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

        SKCOMLib.SKQuoteLib m_SKQuoteLib = null;
        public SKQuoteLib SKQuoteLib
        {
            get { return m_SKQuoteLib; }
            set { m_SKQuoteLib = value; }
        }
        #endregion

        #region Initialize
        //----------------------------------------------------------------------
        // Initialize
        //----------------------------------------------------------------------
        public FutureOrderControl()
        {
            InitializeComponent();
            m_pSKStock = new SKSTOCK();
            m_kma1 = new Dictionary<int, int>();
            m_kpast9ma = new Dictionary<int, int>();
            m_kmaUp9 = new List<int>();
            m_kmaDn9 = new List<int>();
            m_kRSI = new Dictionary<int, int>();
            m_kRSV = new Dictionary<int, int>();
            m_kK = new Dictionary<int, int>();
            m_kD = new Dictionary<int, int>();
            m_dtStocks = CreateStocksDataTable();
            m_nNowNum = 0;
            m_nNowPrice = 0;
            m_nNowMa1 = 0;
            m_nNowM = 0;
            m_nNowK = 50;
            m_nNowD = 50;
            m_nNowRSI = 0;
            m_nMyPrice = 9820;
            //SKQuoteLib = SKCOMTester.Form1.skQuote1
        }

        #endregion

        #region Component Event
        //----------------------------------------------------------------------
        // Component Event
        //----------------------------------------------------------------------
        private void btnSendFutureOrder_Click(object sender, EventArgs e)
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
            if (double.TryParse(txtPrice.Text.Trim(), out dPrice) == false)
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

            FUTUREORDER pFutureOrder = new FUTUREORDER();

            pFutureOrder.bstrFullAccount = m_UserAccount;
            pFutureOrder.bstrPrice = strPrice;
            pFutureOrder.bstrStockNo = strFutureNo;
            pFutureOrder.nQty = nQty;
            pFutureOrder.sBuySell = (short)nBidAsk;
            pFutureOrder.sDayTrade = (short)nFlag;
            pFutureOrder.sTradeType = (short)nPeriod;

            if (OnFutureOrderSignal != null)
            {
                OnFutureOrderSignal(m_UserID, false, pFutureOrder);
            }
        }

        private void btnSendFutureOrderAsync_Click(object sender, EventArgs e)
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
            if (double.TryParse(txtPrice.Text.Trim(), out dPrice) == false)
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

            FUTUREORDER pFutureOrder = new FUTUREORDER();

            pFutureOrder.bstrFullAccount = m_UserAccount;
            pFutureOrder.bstrPrice = strPrice;
            pFutureOrder.bstrStockNo = strFutureNo;
            pFutureOrder.nQty = nQty;
            pFutureOrder.sBuySell = (short)nBidAsk;
            pFutureOrder.sDayTrade = (short)nFlag;
            pFutureOrder.sTradeType = (short)nPeriod;

            if (OnFutureOrderSignal != null)
            {
                OnFutureOrderSignal(m_UserID, true, pFutureOrder);
            }

        }

        private void btnSendFutureOrderCLR_Click(object sender, EventArgs e)
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
            int nNewClose;
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

            if (boxNewClose.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇倉別");
                return;
            }
            nNewClose = boxNewClose.SelectedIndex;

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
            pFutureOrder.sDayTrade = (short)nFlag;
            pFutureOrder.sTradeType = (short)nPeriod;
            pFutureOrder.sNewClose = (short)nNewClose;
            pFutureOrder.sReserved = (short)nReserved;

            if (OnFutureOrderCLRSignal != null)
            {
                OnFutureOrderCLRSignal(m_UserID, false, pFutureOrder);
            }
        }

        private void btnSendFutureOrderCLRAsync_Click(object sender, EventArgs e)
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
            int nNewClose;
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

            if (boxNewClose.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇倉別");
                return;
            }
            nNewClose = boxNewClose.SelectedIndex;

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
            pFutureOrder.sDayTrade = (short)nFlag;
            pFutureOrder.sTradeType = (short)nPeriod;
            pFutureOrder.sNewClose = (short)nNewClose;
            pFutureOrder.sReserved = (short)nReserved;

            if (OnFutureOrderCLRSignal != null)
            {
                OnFutureOrderCLRSignal(m_UserID, true, pFutureOrder);
            }
        }
        #endregion


        #region COM EVENT
        //----------------------------------------------------------------------
        // COM EVENT
        //----------------------------------------------------------------------
        void m_SKQuoteLib_OnConnection(int nKind, int nCode)
        {
            if (nKind == 3001)
            {

                if (nCode == 0)
                {
                    //lblSignal.ForeColor = Color.Yellow;
                }
            }
            else if (nKind == 3002)
            {
                //lblSignal.ForeColor = Color.Red;
            }
            else if (nKind == 3003)
            {
                //lblSignal.ForeColor = Color.Green;
            }
            else if (nKind == 3021)//網路斷線
            {
                //lblSignal.ForeColor = Color.DarkRed;
            }
        }

        /* void m_SKQuoteLib2_OnConnection(int nKind, int nCode)
         {
             if (nKind == 3001)
             {

                 if (nCode == 0)
                 {
                     label_2.ForeColor = Color.Yellow;
                 }
             }
             else if (nKind == 3002)
             {
                 label_2.ForeColor = Color.Red;
             }
             else if (nKind == 3003)
             {
                 label_2.ForeColor = Color.Green;
             }
             else if (nKind == 3021)//網路斷線
             {
                 label_2.ForeColor = Color.DarkRed;
             }
         }*/

        public void m_SKQuoteLib_OnNotifyQuote(short sMarketNo, short sStockIdx)
        {
            SKSTOCK pSKStock = new SKSTOCK();

            m_SKQuoteLib.SKQuoteLib_GetStockByIndex(sMarketNo, sStockIdx, ref pSKStock);

            OnUpDateDataRow(pSKStock);
        }


        public void SKQuoteLib_OnNotifyTicks(short sMarketNo, short sStockIdx, int nPtr, int nDate, int lTimehms, int lTimemillismicros, int nBid, int nAsk, int nClose, int nQty, int nSimulate)
        { 

            int OldMa1 = m_nNowMa1;

            bool isReset = false;
            /// 1MA計算---------------------------------------  
            int newMin = lTimehms / 100;
            if (m_nNowM == 0)
            {
                m_nNowM = newMin;
            }
            if(newMin == m_nNowM)
            {
                m_nNowNum += nQty;
                m_nNowPrice += nClose * nQty;
                m_nNowMa1 = m_nNowPrice / m_nNowNum;
                
            }
            else
            {
                
                m_kma1.Add(m_nNowM, m_nNowMa1);
                WriteMessage(m_nNowM + "時的1ma值為:" + m_nNowMa1);
                m_kpast9ma.Add(m_nNowM, m_nNowMa1);
               
                if (m_kpast9ma.Count > 9)
                {
                    m_kpast9ma.Remove(m_kpast9ma.Keys.First());
                }
                isReset = true;
                m_nNowM = newMin;

                
            }

            /// RSV計算
            int[] Ma9 = m_kpast9ma.Values.ToArray();
            int MinMa = -1;
            int MaxMa = 0;
            if (Ma9.Length >= 9)
            {
                for (int i = 0; i < Ma9.Length; i++)
                {
                    if (MinMa < 0 || MinMa > Ma9[i])
                    {
                        MinMa = Ma9[i];
                    }
                    if(MaxMa < Ma9[i])
                    {
                        MaxMa = Ma9[i];
                    }
                }
                m_nNowRSV = (m_nNowMa1 - MinMa) / (MaxMa - MinMa);
                if (isReset)
                {
                    WriteMessage(m_nNowM + "時的RSV值為:" + m_nNowRSV);
                    m_kRSV.Add(m_nNowM, m_nNowRSV);
                }
            }

            /// KD計算
            if (m_nNowRSV > 0)
            {
                m_nNowK = ((2 / 3) * m_nNowK) + ((1 / 3) * m_nNowRSV);
                m_nNowD = ((2 / 3) * m_nNowD) + ((1 / 3) * m_nNowK);
                if (isReset)
                {
                    WriteMessage(m_nNowM + "時的K值為:" + m_nNowK + ", D值為:"+ m_nNowD);
                    m_kK.Add(m_nNowM, m_nNowK);
                    m_kD.Add(m_nNowM, m_nNowD);
                }
            }
            /// RSI計算
            int ndiff = m_nNowMa1 - OldMa1;
            if(ndiff > 0)
            {
                m_kmaUp9.Add(ndiff);
                m_kmaDn9.Add(0);
            }
            else
            {
                ndiff = Math.Abs(ndiff);
                m_kmaUp9.Add(0);
                m_kmaDn9.Add(ndiff);
            }
            if(m_kmaUp9.Count > 9)
            {
                m_kmaUp9.Remove(m_kmaUp9.First());
                m_kmaDn9.Remove(m_kmaDn9.First());
            }
            if(m_kmaUp9.Count == 9)
            {
                int avgUP = 0;
                int avgDN = 0;
                for(int i=0; i<m_kmaUp9.Count; i++)
                {
                    avgUP += m_kmaUp9[i];
                    avgDN += m_kmaDn9[i];
                }
                avgUP /= 9;
                avgDN /= 9;
                if (avgDN != 0 || avgUP != 0)
                {
                    m_nNowRSI = 100 * avgUP / (avgUP + avgDN);
                    if (isReset)
                    {
                        WriteMessage(m_nNowM + "時的RSI值為:" + m_nNowRSI);
                        m_kRSI.Add(m_nNowM, m_nNowRSI);

                    }
                }


            }

            //布林通道
            if (isReset)
            {
                isReset = false;
                m_nNowNum = 0;
                m_nNowPrice = 0;
                m_nNowMa1 = 0;
            }
        }

        //public Action<short, short, int, int, int, int, int, int, int, int, int> m_SKQuoteLib_OnNotifyTicks;



        void m_SKQuoteLib_OnNotifyBest5(short sMarketNo, short sStockIdx, int nBestBid1, int nBestBidQty1, int nBestBid2, int nBestBidQty2, int nBestBid3, int nBestBidQty3, int nBestBid4, int nBestBidQty4, int nBestBid5, int nBestBidQty5, int nExtendBid, int nExtendBidQty, int nBestAsk1, int nBestAskQty1, int nBestAsk2, int nBestAskQty2, int nBestAsk3, int nBestAskQty3, int nBestAsk4, int nBestAskQty4, int nBestAsk5, int nBestAskQty5, int nExtendAsk, int nExtendAskQty, int nSimulate)
        {
            //0:一般;1:試算揭示
            //if (nSimulate == 0)
            //{
            //    GridBest5Ask.ForeColor = Color.Black;
            //    GridBest5Bid.ForeColor = Color.Black;
            //}
            //else
            //{
            //    GridBest5Ask.ForeColor = Color.Gray;
            //    GridBest5Bid.ForeColor = Color.Gray;
            //}

            /*SKSTOCK pSKStock = new SKSTOCK();
            double dDigitNum = 0.000;
            string strStockNoTick = txtTick.Text.Trim();
            int nCode = m_SKQuoteLib.SKQuoteLib_GetStockByNo(strStockNoTick, ref pSKStock);
            //[-1022-a-]
            if (nCode == 0)
                dDigitNum = (Math.Pow(10, pSKStock.sDecimal));
            else
                dDigitNum = 100.00;//default value

            if (m_dtBest5Ask.Rows.Count == 0 && m_dtBest5Bid.Rows.Count == 0)
            {
                DataRow myDataRow;

                myDataRow = m_dtBest5Ask.NewRow();
                myDataRow["m_nAskQty"] = nBestAskQty1;
                myDataRow["m_nAsk"] = nBestAsk1 / dDigitNum;///100.00;
                m_dtBest5Ask.Rows.Add(myDataRow);

                myDataRow = m_dtBest5Ask.NewRow();
                myDataRow["m_nAskQty"] = nBestAskQty2;
                myDataRow["m_nAsk"] = nBestAsk2 / dDigitNum;//100.00;
                m_dtBest5Ask.Rows.Add(myDataRow);

                myDataRow = m_dtBest5Ask.NewRow();
                myDataRow["m_nAskQty"] = nBestAskQty3;
                myDataRow["m_nAsk"] = nBestAsk3 / dDigitNum;//100.00;
                m_dtBest5Ask.Rows.Add(myDataRow);

                myDataRow = m_dtBest5Ask.NewRow();
                myDataRow["m_nAskQty"] = nBestAskQty4;
                myDataRow["m_nAsk"] = nBestAsk4 / dDigitNum;// 100.00;
                m_dtBest5Ask.Rows.Add(myDataRow);

                myDataRow = m_dtBest5Ask.NewRow();
                myDataRow["m_nAskQty"] = nBestAskQty5;
                myDataRow["m_nAsk"] = nBestAsk5 / dDigitNum;// 100.00;
                m_dtBest5Ask.Rows.Add(myDataRow);



                myDataRow = m_dtBest5Bid.NewRow();
                myDataRow["m_nAskQty"] = nBestBidQty1;
                myDataRow["m_nAsk"] = nBestBid1 / dDigitNum;
                m_dtBest5Bid.Rows.Add(myDataRow);

                myDataRow = m_dtBest5Bid.NewRow();
                myDataRow["m_nAskQty"] = nBestBidQty2;
                myDataRow["m_nAsk"] = nBestBid2 / dDigitNum;
                m_dtBest5Bid.Rows.Add(myDataRow);

                myDataRow = m_dtBest5Bid.NewRow();
                myDataRow["m_nAskQty"] = nBestBidQty3;
                myDataRow["m_nAsk"] = nBestBid3 / dDigitNum;
                m_dtBest5Bid.Rows.Add(myDataRow);

                myDataRow = m_dtBest5Bid.NewRow();
                myDataRow["m_nAskQty"] = nBestBidQty4;
                myDataRow["m_nAsk"] = nBestBid4 / dDigitNum;
                m_dtBest5Bid.Rows.Add(myDataRow);

                myDataRow = m_dtBest5Bid.NewRow();
                myDataRow["m_nAskQty"] = nBestBidQty5;
                myDataRow["m_nAsk"] = nBestBid5 / dDigitNum;
                m_dtBest5Bid.Rows.Add(myDataRow);

            }
            else
            {
                m_dtBest5Ask.Rows[0]["m_nAskQty"] = nBestAskQty1;
                m_dtBest5Ask.Rows[0]["m_nAsk"] = nBestAsk1 / dDigitNum;

                m_dtBest5Ask.Rows[1]["m_nAskQty"] = nBestAskQty2;
                m_dtBest5Ask.Rows[1]["m_nAsk"] = nBestAsk2 / dDigitNum;

                m_dtBest5Ask.Rows[2]["m_nAskQty"] = nBestAskQty3;
                m_dtBest5Ask.Rows[2]["m_nAsk"] = nBestAsk3 / dDigitNum;

                m_dtBest5Ask.Rows[3]["m_nAskQty"] = nBestAskQty4;
                m_dtBest5Ask.Rows[3]["m_nAsk"] = nBestAsk4 / dDigitNum;

                m_dtBest5Ask.Rows[4]["m_nAskQty"] = nBestAskQty5;
                m_dtBest5Ask.Rows[4]["m_nAsk"] = nBestAsk5 / dDigitNum;


                m_dtBest5Bid.Rows[0]["m_nAskQty"] = nBestBidQty1;
                m_dtBest5Bid.Rows[0]["m_nAsk"] = nBestBid1 / dDigitNum;

                m_dtBest5Bid.Rows[1]["m_nAskQty"] = nBestBidQty2;
                m_dtBest5Bid.Rows[1]["m_nAsk"] = nBestBid2 / dDigitNum;

                m_dtBest5Bid.Rows[2]["m_nAskQty"] = nBestBidQty3;
                m_dtBest5Bid.Rows[2]["m_nAsk"] = nBestBid3 / dDigitNum;

                m_dtBest5Bid.Rows[3]["m_nAskQty"] = nBestBidQty4;
                m_dtBest5Bid.Rows[3]["m_nAsk"] = nBestBid4 / dDigitNum;

                m_dtBest5Bid.Rows[4]["m_nAskQty"] = nBestBidQty5;
                m_dtBest5Bid.Rows[4]["m_nAsk"] = nBestBid5 / dDigitNum;
            }*/

        }

        public void m_SKQuoteLib_OnNotifyServerTime(short sHour, short sMinute, short sSecond, int nTotal)
        {
             lblServerTime.Text = sHour.ToString("D2") + ":" + sMinute.ToString("D2") + ":" + sSecond.ToString("D2");
        }

        void m_SKQuoteLib_OnNotifyKLineData(string bstrStockNo, string bstrData)
        {
            //listKLine.Items.Add("[OnNotifyKLineData]" + bstrData);
        }

        void m_SKQuoteLib_OnNotifyMarketTot(short sMarketNo, short sPrt, int nTime, int nTotv, int nTots, int nTotc)
        {
            double dTotv = nTotv / 100.0;

            if (sMarketNo == 0)
            {
                //lblTotv.Text = dTotv.ToString() + "(億)";
                //lblTots.Text = nTots.ToString() + "(張)";
                //lblTotc.Text = nTotc.ToString() + "(筆)";
            }
            else
            {
                //lblTotv2.Text = dTotv.ToString() + "(億)";
                //lblTots2.Text = nTots.ToString() + "(張)";
                //lblTotc2.Text = nTotc.ToString() + "(筆)";
            }
        }

        void m_SKQuoteLib_OnNotifyMarketBuySell(short sMarketNo, short sPrt, int nTime, int nBc, int nSc, int nBs, int nSs)
        {
            if (sMarketNo == 0)
            {
                //lbllBc.Text = nBc.ToString() + "(筆)";
                //lbllBs.Text = nBs.ToString() + "(張)";
                //lbllSc.Text = nSc.ToString() + "(筆)";
                //lbllSs.Text = nSs.ToString() + "(張)";
            }
            else
            {
                //lbllBc2.Text = nBc.ToString() + "(筆)";
                //lbllBs2.Text = nBs.ToString() + "(張)";
                //lbllSc2.Text = nSc.ToString() + "(筆)";
                //lbllSs2.Text = nSs.ToString() + "(張)";
            }
        }

        void m_SKQuoteLib_OnNotifyMarketHighLow(short sMarketNo, short sPrt, int nTime, short sUp, short sDown, short sHigh, short sLow, short sNoChange)
        {
            if (sMarketNo == 0)
            {
                //lblsUp.Text = sUp.ToString();
                //lblsDown.Text = sDown.ToString();
                //lblsHigh.Text = sHigh.ToString();
                //lblsLow.Text = sLow.ToString();
                //lblsNoChange.Text = sNoChange.ToString();
            }
            else
            {
                //lblsUp2.Text = sUp.ToString();
                //lblsDown2.Text = sDown.ToString();
                //lblsHigh2.Text = sHigh.ToString();
                //lblsLow2.Text = sLow.ToString();
                //lblsNoChange2.Text = sNoChange.ToString();
            }
        }

        void m_SKQuoteLib_OnNotifyMACD(short sMarketNo, short sStockIdx, string bstrMACD, string bstrDIF, string bstrOSC)
        {
            //lblMACD.Text = bstrMACD;

            //lblDIF.Text = bstrDIF;
            //lblOSC.Text = bstrOSC;
        }

        void m_SKQuoteLib_OnNotifyBoolTunel(short sMarketNo, short sStockIdx, string bstrAVG, string bstrUBT, string bstrLBT)
        {
            //lblAVG.Text = bstrAVG;
            //lblUBT.Text = bstrUBT;
            //lblLBT.Text = bstrLBT;
        }

        void m_SKQuoteLib_OnNotifyFutureTradeInfo(string bstrStockNo, short sMarketNo, short sStockIdx, int nBuyTotalCount, int nSellTotalCount, int nBuyTotalQty, int nSellTotalQty, int nBuyDealTotalCount, int nSellDealTotalCount)
        {
            //lblFTIBc.Text = "TotalBc";
            //lblFTISc.Text = "TotalSc";
            //lblFTIBq.Text = "TotalBq";
            //lblFTISq.Text = "TotalSq";
            //lblFTIBDC.Text = "TotalBDC";
            //lblFTISDC.Text = "TotalSDC";



            //lblFTIBc.Text = nBuyTotalCount.ToString();
            //lblFTISc.Text = nSellTotalCount.ToString();
            //lblFTIBq.Text = nBuyTotalQty.ToString();
            //lblFTISq.Text = nSellTotalQty.ToString();
            //lblFTIBDC.Text = nBuyDealTotalCount.ToString();
            //lblFTISDC.Text = nSellDealTotalCount.ToString();

        }

        void m_SKQuoteLib_OnNotifyStrikePrices(string bstrOptionData)
        {
            //[-0119-]
            string strData = "";
            strData = "[OnNotifyStrikePrices]" + bstrOptionData;

            /*listStrikePrices.Items.Add(strData);
            m_nCount++;
            listStrikePrices.SelectedIndex = listStrikePrices.Items.Count - 1;

            if (bstrOptionData.Substring(0, 2) != "##")   //開頭##表結束，不計商品數量
                txt_StrikePriceCount.Text = m_nCount.ToString();*/

        }
        void m_SKQuoteLib_OnNotifyStockList(short sMarketNo, string bstrStockListData)
        {

            string strData = "";
            strData = "[OnNotifyStockList]" + bstrStockListData;

            /*StockList.Items.Add(strData);
            m_nCount++;
            if (StockList.Items.Count < 200)
                StockList.SelectedIndex = listStrikePrices.Items.Count - 1;
            else
                StockList.Items.Clear();

            Size size = TextRenderer.MeasureText(bstrStockListData, StockList.Font);
            if (StockList.HorizontalExtent < size.Width + 20)
                StockList.HorizontalExtent = size.Width + 20;
                */
        }


        #endregion

        private void btnDecreaseQty_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇期貨帳號");
                return;
            }
            int nQty = 0;
            string strSeqNo;

            if (txtDecreaseSeqNo.Text.Trim() == "")
            {
                MessageBox.Show("請輸入委託序號");
                return;
            }
            strSeqNo = txtDecreaseSeqNo.Text.Trim();

            if (int.TryParse(txtDecreaseQty.Text.Trim(), out nQty) == false)
            {
                MessageBox.Show("改量請輸入數字");
                return;
            }
            if (OnDecreaseOrderSignal != null)
            {
                OnDecreaseOrderSignal(m_UserID, true, m_UserAccount, strSeqNo, nQty);
            }
        }

        private void btnCancelOrderBySeqNo_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇期貨帳號");
                return;
            }
            string strSeqNo;

            if (txtCancelSeqNo.Text.Trim() == "")
            {
                MessageBox.Show("請輸入委託序號");
                return;
            }
            strSeqNo = txtCancelSeqNo.Text.Trim();
            if (OnCancelOrderSignal != null)
            {
                OnCancelOrderSignal(m_UserID, true, m_UserAccount, strSeqNo);
            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇期貨帳號");
                return;
            }
            string strStockNo;

            if (txtCancelStockNo.Text.Trim() == "")
            {
                if (MessageBox.Show("未輸入商品代碼會刪除所有委託單，是否刪單?", "委託全部刪單", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    MessageBox.Show("已取消本次操作");
                    return;
                }
            }
            strStockNo = txtCancelStockNo.Text.Trim();
            if (OnCancelOrderByStockSignal != null)
            {
                OnCancelOrderByStockSignal(m_UserID, true, m_UserAccount, strStockNo);
            }
        }

        private void btnCorrectPriceBySeqNo_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇期貨帳號");
                return;
            }
            if (OnCorrectPriceBySeqNo != null)
            {
                int nTradeType;
                string strSeqNo;
                string strPrice;

                if (txtCorrectSeqNo.Text.Trim() == "")
                {
                    MessageBox.Show("請輸入委託序號");
                    return;
                }
                strSeqNo = txtCorrectSeqNo.Text.Trim();

                double dPrice = 0.0;
                if (double.TryParse(txtCorrectPrice.Text.Trim(), out dPrice) == false)
                {
                    MessageBox.Show("修改價格請輸入數字");
                    return;
                }
                strPrice = txtCorrectPrice.Text.Trim();

                if (boxCorrectTradeType.SelectedIndex < 0)
                {
                    MessageBox.Show("請選擇委託條件");
                    return;
                }
                nTradeType = boxCorrectTradeType.SelectedIndex;

                OnCorrectPriceBySeqNo(m_UserID, true, m_UserAccount, strSeqNo, strPrice, nTradeType);
            }
        }

        private void btnCorrectPriceByBookNo_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇期貨帳號");
                return;
            }
            if (OnCorrectPriceByBookNo != null)
            {
                int nTradeType;
                string strBookNo;
                string strPrice;

                if (txtCorrectBookNo.Text.Trim() == "")
                {
                    MessageBox.Show("請輸入委託書號");
                    return;
                }
                strBookNo = txtCorrectBookNo.Text.Trim();

                double dPrice = 0.0;
                if (double.TryParse(txtCorrectPrice.Text.Trim(), out dPrice) == false)
                {
                    MessageBox.Show("修改價格請輸入數字");
                    return;
                }
                strPrice = txtCorrectPrice.Text.Trim();

                if (boxCorrectSymbol.SelectedIndex < 0)
                {
                    MessageBox.Show("請選擇市場簡稱");
                    return;
                }
                nTradeType = boxCorrectTradeType.SelectedIndex;

                if (boxCorrectTradeType.SelectedIndex < 0)
                {
                    MessageBox.Show("請選擇委託條件");
                    return;
                }

                OnCorrectPriceByBookNo(m_UserID, true, m_UserAccount, boxCorrectSymbol.Text.Trim(), strBookNo, strPrice, nTradeType);
            }
        }

        private void btnGetOpenInterest_Click(object sender, EventArgs e)
        {
            if (OnOpenInterestSignal != null)
            {
                OnOpenInterestSignal(m_UserID, m_UserAccount);
            }
        }

        private void btnGetFutureRights_Click(object sender, EventArgs e)
        {
            int nCoinType;
            if (comBox_CoinType.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇幣別");
                return;
            }
            nCoinType = comBox_CoinType.SelectedIndex;

            if (OnFutureRightsSignal != null)
            {

                OnFutureRightsSignal(m_UserID, m_UserAccount, nCoinType + 1);
            }
        }

        private void btnCancelOrderByBookNo_Click(object sender, EventArgs e)
        {
            if (m_UserAccount == "")
            {
                MessageBox.Show("請選擇期貨帳號");
                return;
            }
            string strBookNo;

            if (txtCancelBookNo.Text.Trim() == "")
            {
                MessageBox.Show("請輸入委託書號");
                return;
            }
            strBookNo = txtCancelBookNo.Text.Trim();
            if (OnCancelOrderByBookSignal != null)
            {
                OnCancelOrderByBookSignal(m_UserID, true, m_UserAccount, strBookNo);
            }
        }

        private void AutoOrder()
        {
            string pro = "MTX00";
            while (true)  //自動策略迴圈
            {
                if (m_bfirst == true)
                {
                    //m_SKQuoteLib.OnConnection += new _ISKQuoteLibEvents_OnConnectionEventHandler(m_SKQuoteLib_OnConnection);
                    //m_SKQuoteLib.OnNotifyQuote += new _ISKQuoteLibEvents_OnNotifyQuoteEventHandler(m_SKQuoteLib_OnNotifyQuote);
                    //m_SKQuoteLib.OnNotifyHistoryTicks += new _ISKQuoteLibEvents_OnNotifyHistoryTicksEventHandler(m_SKQuoteLib_OnNotifyHistoryTicks);
                    //m_SKQuoteLib.OnNotifyTicks += new _ISKQuoteLibEvents_OnNotifyTicksEventHandler(m_SKQuoteLib_OnNotifyTicks);
                    //m_SKQuoteLib.OnNotifyBest5 += new _ISKQuoteLibEvents_OnNotifyBest5EventHandler(m_SKQuoteLib_OnNotifyBest5);
                    //m_SKQuoteLib.OnNotifyKLineData += new _ISKQuoteLibEvents_OnNotifyKLineDataEventHandler(m_SKQuoteLib_OnNotifyKLineData);
                    //m_SKQuoteLib.OnNotifyServerTime += new _ISKQuoteLibEvents_OnNotifyServerTimeEventHandler(m_SKQuoteLib_OnNotifyServerTime);
                    //m_SKQuoteLib.OnNotifyMarketTot += new _ISKQuoteLibEvents_OnNotifyMarketTotEventHandler(m_SKQuoteLib_OnNotifyMarketTot);
                    //m_SKQuoteLib.OnNotifyMarketBuySell += new _ISKQuoteLibEvents_OnNotifyMarketBuySellEventHandler(m_SKQuoteLib_OnNotifyMarketBuySell);
                    //m_SKQuoteLib.OnNotifyMarketHighLow += new _ISKQuoteLibEvents_OnNotifyMarketHighLowEventHandler(m_SKQuoteLib_OnNotifyMarketHighLow);
                    //m_SKQuoteLib.OnNotifyMACD += new _ISKQuoteLibEvents_OnNotifyMACDEventHandler(m_SKQuoteLib_OnNotifyMACD);
                    //m_SKQuoteLib.OnNotifyBoolTunel += new _ISKQuoteLibEvents_OnNotifyBoolTunelEventHandler(m_SKQuoteLib_OnNotifyBoolTunel);
                    //m_SKQuoteLib.OnNotifyFutureTradeInfo += new _ISKQuoteLibEvents_OnNotifyFutureTradeInfoEventHandler(m_SKQuoteLib_OnNotifyFutureTradeInfo);
                    //m_SKQuoteLib.OnNotifyStrikePrices += new _ISKQuoteLibEvents_OnNotifyStrikePricesEventHandler(m_SKQuoteLib_OnNotifyStrikePrices);
                    //m_SKQuoteLib.OnNotifyStockList += new _ISKQuoteLibEvents_OnNotifyStockListEventHandler(m_SKQuoteLib_OnNotifyStockList);
                    m_bfirst = false;

                   // m_nCode = m_SKQuoteLib.SKQuoteLib_EnterMonitor();
                    //m_nCode = m_SKQuoteLib.SKQuoteLib_RequestTicks(0, pro.Trim());
                }
                

            }
            //自動策略的商品代號
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            Thread oThreadAuto = new Thread(new ThreadStart(AutoOrder));
            oThreadAuto.Name = "Auto Thread";
            oThreadAuto.Start();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            string pro = "MTX00";
            m_nCode = m_SKQuoteLib.SKQuoteLib_RequestTicks(0, pro.Trim());
            m_nCode = m_SKQuoteLib.SKQuoteLib_RequestServerTime();

            m_dtStocks.Clear();
            gridStocks.ClearSelection();

            gridStocks.DataSource = m_dtStocks;

            gridStocks.Columns["m_sStockidx"].Visible = false;
            gridStocks.Columns["m_sDecimal"].Visible = false;
            gridStocks.Columns["m_sTypeNo"].Visible = false;
            gridStocks.Columns["m_cMarketNo"].Visible = false;
            gridStocks.Columns["m_caStockNo"].HeaderText = "代碼";
            gridStocks.Columns["m_caName"].HeaderText = "名稱";
            gridStocks.Columns["m_nOpen"].HeaderText = "開盤價";
            //gridStocks.Columns["m_nHigh"].Visible = false;
            gridStocks.Columns["m_nHigh"].HeaderText = "最高";
            //gridStocks.Columns["m_nLow"].Visible = false;
            gridStocks.Columns["m_nLow"].HeaderText = "最低";
            gridStocks.Columns["m_nClose"].HeaderText = "成交價";
            gridStocks.Columns["m_nTickQty"].HeaderText = "單量";
            gridStocks.Columns["m_nRef"].HeaderText = "昨收價";
            gridStocks.Columns["m_nBid"].HeaderText = "買價";
            //gridStocks.Columns["m_nBc"].Visible = false;
            gridStocks.Columns["m_nBc"].HeaderText = "買量";
            gridStocks.Columns["m_nAsk"].HeaderText = "賣價";
            //gridStocks.Columns["m_nAc"].Visible = false;
            gridStocks.Columns["m_nAc"].HeaderText = "賣量";
            //gridStocks.Columns["m_nTBc"].Visible = false;
            gridStocks.Columns["m_nTBc"].HeaderText = "買盤量";
            //gridStocks.Columns["m_nTAc"].Visible = false;
            gridStocks.Columns["m_nTAc"].HeaderText = "賣盤量";
            gridStocks.Columns["m_nFutureOI"].Visible = false;
            //gridStocks.Columns["m_nTQty"].Visible = false;
            gridStocks.Columns["m_nTQty"].HeaderText = "總量";
            //gridStocks.Columns["m_nYQty"].Visible = false;
            gridStocks.Columns["m_nYQty"].HeaderText = "昨量";
            //gridStocks.Columns["m_nUp"].Visible = false;
            gridStocks.Columns["m_nUp"].HeaderText = "漲停";
            //gridStocks.Columns["m_nDown"].Visible = false;
            gridStocks.Columns["m_nDown"].HeaderText = "跌停";

          
          
            SKSTOCK pSKStock = new SKSTOCK();

            int nCode = m_SKQuoteLib.SKQuoteLib_GetStockByNo(pro.Trim(), ref pSKStock);

            OnUpDateDataRow(pSKStock);
            short sPage = -1;
            m_nCode = m_SKQuoteLib.SKQuoteLib_RequestStocks(ref sPage, pro.Trim());

        }
        private DataTable CreateStocksDataTable()
        {
            DataTable myDataTable = new DataTable();

            DataColumn myDataColumn;

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Int16");
            myDataColumn.ColumnName = "m_sStockidx";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Int16");
            myDataColumn.ColumnName = "m_sDecimal";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Int16");
            myDataColumn.ColumnName = "m_sTypeNo";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "m_cMarketNo";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "m_caStockNo";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "m_caName";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Double");
            myDataColumn.ColumnName = "m_nOpen";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Double");
            myDataColumn.ColumnName = "m_nHigh";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Double");
            myDataColumn.ColumnName = "m_nLow";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Double");
            myDataColumn.ColumnName = "m_nClose";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Int32");
            myDataColumn.ColumnName = "m_nTickQty";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Double");
            myDataColumn.ColumnName = "m_nRef";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Double");
            myDataColumn.ColumnName = "m_nBid";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Int32");
            myDataColumn.ColumnName = "m_nBc";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Double");
            myDataColumn.ColumnName = "m_nAsk";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Int32");
            myDataColumn.ColumnName = "m_nAc";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Int32");
            myDataColumn.ColumnName = "m_nTBc";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Int32");
            myDataColumn.ColumnName = "m_nTAc";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Int32");
            myDataColumn.ColumnName = "m_nFutureOI";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Int32");
            myDataColumn.ColumnName = "m_nTQty";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Int32");
            myDataColumn.ColumnName = "m_nYQty";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Double");
            myDataColumn.ColumnName = "m_nUp";
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Double");
            myDataColumn.ColumnName = "m_nDown";
            myDataTable.Columns.Add(myDataColumn);

            myDataTable.PrimaryKey = new DataColumn[] { myDataTable.Columns["m_caStockNo"] };

            return myDataTable;
        }
        private void OnUpDateDataRow(SKSTOCK pStock)
        {

            string strStockNo = pStock.bstrStockNo;

            DataRow drFind = m_dtStocks.Rows.Find(strStockNo);
            if (drFind == null)
            {
                try
                {
                    DataRow myDataRow = m_dtStocks.NewRow();

                    myDataRow["m_sStockidx"] = pStock.sStockIdx;
                    myDataRow["m_sDecimal"] = pStock.sDecimal;
                    myDataRow["m_sTypeNo"] = pStock.sTypeNo;
                    myDataRow["m_cMarketNo"] = pStock.bstrMarketNo;
                    myDataRow["m_caStockNo"] = pStock.bstrStockNo;
                    myDataRow["m_caName"] = pStock.bstrStockName;
                    myDataRow["m_nOpen"] = pStock.nOpen / (Math.Pow(10, pStock.sDecimal));
                    myDataRow["m_nHigh"] = pStock.nHigh / (Math.Pow(10, pStock.sDecimal));
                    myDataRow["m_nLow"] = pStock.nLow / (Math.Pow(10, pStock.sDecimal));
                    myDataRow["m_nClose"] = pStock.nClose / (Math.Pow(10, pStock.sDecimal));
                    label21.Text = Convert.ToString(50 * ( (pStock.nClose / (Math.Pow(10, pStock.sDecimal))) - m_nMyPrice) - 82);
                    myDataRow["m_nTickQty"] = pStock.nTickQty;
                    myDataRow["m_nRef"] = pStock.nRef / (Math.Pow(10, pStock.sDecimal));
                    myDataRow["m_nBid"] = pStock.nBid / (Math.Pow(10, pStock.sDecimal));
                    myDataRow["m_nBc"] = pStock.nBc;
                    myDataRow["m_nAsk"] = pStock.nAsk / (Math.Pow(10, pStock.sDecimal));
                   // m_nSimulateStock = pStock.nSimulate;                 //成交價/買價/賣價;揭示
                    myDataRow["m_nAc"] = pStock.nAc;
                    myDataRow["m_nTBc"] = pStock.nTBc;
                    myDataRow["m_nTAc"] = pStock.nTAc;
                    myDataRow["m_nFutureOI"] = pStock.nFutureOI;
                    myDataRow["m_nTQty"] = pStock.nTQty;
                    myDataRow["m_nYQty"] = pStock.nYQty;
                    myDataRow["m_nUp"] = pStock.nUp / (Math.Pow(10, pStock.sDecimal));
                    myDataRow["m_nDown"] = pStock.nDown / (Math.Pow(10, pStock.sDecimal));

                    m_dtStocks.Rows.Add(myDataRow);

                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }
            }
            else
            {
                drFind["m_sStockidx"] = pStock.sStockIdx;
                drFind["m_sDecimal"] = pStock.sDecimal;
                drFind["m_sTypeNo"] = pStock.sTypeNo;
                drFind["m_cMarketNo"] = pStock.bstrMarketNo;
                drFind["m_caStockNo"] = pStock.bstrStockNo;
                drFind["m_caName"] = pStock.bstrStockName;
                drFind["m_nOpen"] = pStock.nOpen / (Math.Pow(10, pStock.sDecimal));
                drFind["m_nHigh"] = pStock.nHigh / (Math.Pow(10, pStock.sDecimal));
                drFind["m_nLow"] = pStock.nLow / (Math.Pow(10, pStock.sDecimal));
                drFind["m_nClose"] = pStock.nClose / (Math.Pow(10, pStock.sDecimal));
                label21.Text = Convert.ToString(50 * ((pStock.nClose / (Math.Pow(10, pStock.sDecimal))) - m_nMyPrice)-82);
                drFind["m_nTickQty"] = pStock.nTickQty;
                drFind["m_nRef"] = pStock.nRef / (Math.Pow(10, pStock.sDecimal));
                drFind["m_nBid"] = pStock.nBid / (Math.Pow(10, pStock.sDecimal));
                drFind["m_nBc"] = pStock.nBc;
                drFind["m_nAsk"] = pStock.nAsk / (Math.Pow(10, pStock.sDecimal));
                drFind["m_nAc"] = pStock.nAc;
                drFind["m_nTBc"] = pStock.nTBc;
                drFind["m_nTAc"] = pStock.nTAc;
                drFind["m_nFutureOI"] = pStock.nFutureOI;
                drFind["m_nTQty"] = pStock.nTQty;
                drFind["m_nYQty"] = pStock.nYQty;
                drFind["m_nUp"] = pStock.nUp / (Math.Pow(10, pStock.sDecimal));
                drFind["m_nDown"] = pStock.nDown / (Math.Pow(10, pStock.sDecimal));
                //m_nSimulateStock = pStock.nSimulate;                 //成交價/買價/賣價;揭示
            }
        }
        private void txtStockNo_TextChanged(object sender, EventArgs e)
        {

        }

        public void WriteMessage(string strMsg)
        {
            listBox1.Items.Add(strMsg);

            listBox1.SelectedIndex = listBox1.Items.Count - 1;

            //listInformation.HorizontalScrollbar = true;

            // Create a Graphics object to use when determining the size of the largest item in the ListBox.
            Graphics g = listBox1.CreateGraphics();

            // Determine the size for HorizontalExtent using the MeasureString method using the last item in the list.
            int hzSize = (int)g.MeasureString(listBox1.Items[listBox1.Items.Count - 1].ToString(), listBox1.Font).Width;
            // Set the HorizontalExtent property.
            listBox1.HorizontalExtent = hzSize;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }
    }
}
