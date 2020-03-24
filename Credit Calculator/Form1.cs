using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
namespace Credit_Calculator
{
    public partial class Form1 : Form
    {
        protected string ExecpMessage;
        #region ForChart
        ArrayList listRateAint = new ArrayList();
        ArrayList listMainSumAint = new ArrayList();
        ArrayList listRateDif = new ArrayList();
        ArrayList listMainSumDif = new ArrayList();
        #endregion
        public Form1()
        {
            InitializeComponent();
            panel4.Height = ToCountButton.Height;
            panel4.Top = ToCountButton.Top;
            Setting();
            ComaprePanel.Visible = false;
        }
        void DrawGraf() // рисует столбцы
        {
            CreditGraf.Columns.Add("data", "Дата");
            CreditGraf.Columns.Add("month", "Месяц");
            CreditGraf.Columns.Add("payment", "Платеж");
            CreditGraf.Columns.Add("procent", "Процент");
            CreditGraf.Columns.Add("MainSum", "Основная \nсумма");
            CreditGraf.Columns.Add("amount", "Остаток");
            for (int i = 0; i < CreditGraf.ColumnCount; i++)
            {
                CreditGraf.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        #region prop
        // сюда забивай настройки таблицы
        //***************
        void Setting()
        {
            #region tablet
            CreditGraf.ScrollBars = ScrollBars.None;
            CreditGraf.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 44, 70);
            CreditGraf.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            CreditGraf.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
            CreditGraf.ReadOnly = true;
            CreditGraf.ForeColor = Color.White;
            CreditGraf.AllowUserToAddRows = false;
            CreditGraf.AllowUserToDeleteRows = false;
            CreditGraf.AllowUserToResizeColumns = false;
            CreditGraf.AllowUserToOrderColumns = false;
            CreditGraf.AllowUserToResizeRows = false;
            CreditGraf.CellBorderStyle = DataGridViewCellBorderStyle.None;
            CreditGraf.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(35, 44, 63);
            CreditGraf.RowsDefaultCellStyle.BackColor = Color.FromArgb(35, 44, 63);
            CreditGraf.BackgroundColor = Color.FromArgb(35, 44, 63);
            //Color.FromArgb(35, 44, 63);
            CreditGraf.EnableHeadersVisualStyles = false;
            CreditGraf.RowHeadersVisible = false;
            CreditGraf.AllowUserToResizeColumns = false;
            CreditGraf.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            #endregion


            #region listboxes
            listBox1.SelectedIndex = 0;
            listBox2.SelectedIndex = 0;
            #endregion


            #region TextBoxes
            AmountBox.MaxLength = 8;
            if(listBox1.SelectedIndex == 0)
            {
                MonthsBox.MaxLength = 5;
            }
            else
            {
                MonthsBox.MaxLength = 2;
            }
            RatesBox.MaxLength = 6;
            #endregion
        }
        //***************
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void tocount_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(AmountBox.Text) <= 0 || Convert.ToInt32(MonthsBox.Text) <= 0 || Convert.ToDouble(RatesBox.Text) <= 0) { throw new FormatException(); }
                int a = Int32.Parse(AmountBox.Text);
                double r;
                r = Convert.ToDouble(RatesBox.Text);
                int m = Int32.Parse(MonthsBox.Text);
                int CharMonths = m;
                Credit c = new Credit(a, r, m);
                Credit d = new Credit(a, r, m);
                try
                {
                    c.dateTime1 = System.DateTime.Parse(String.Format(DataBox.Text));
                }
                catch when (DataBox.MaskCompleted == false)
                {
                    c.dateTime1 = DateTime.Now;
                }
                catch (Exception)
                {
                    c.dateTime1 = DateTime.Now;
                    ExecpMessage = "Неккоректный ввод даты";
                    ThisExeptionData();
                }
                if (listBox1.SelectedIndex == 0)
                {
                }
                else
                {
                    c.Months *= 12;
                    d.Months *= 12;
                }
                CreditGraf.Columns.Clear();
                DrawGraf();
                int j = c.dateTime1.Month;
                d.ToCountDif();
                c.ToCount();
                if (listBox2.SelectedIndex == 0)
                {
                    for (int i = 0; i < c.Months; i++)
                    {
                        j += 1;
                        CreditGraf.Rows.Add();
                        CreditGraf[0, i].Value = (c.dateTime1.AddMonths(i)).ToString(("dd.MM.yyyy"));
                        CreditGraf[1, i].Value = i + 1;
                        CreditGraf[2, i].Value = Math.Round(c.Payment, 2);
                        CreditGraf[3, i].Value = Math.Round((double)c.listRate[i], 2);
                        CreditGraf[4, i].Value = Math.Round((double)c.listMainSum[i], 2);
                        CreditGraf[5, i].Value = Math.Round((double)c.listAmount[i], 2);
                    }
                    CreditGraf.ClearSelection();
                }
                else
                {
                    for (int i = 0; i < d.Months; i++)
                    {
                        j += 1;
                        CreditGraf.Rows.Add();
                        CreditGraf[0, i].Value = (c.dateTime1.AddMonths(i)).ToString(("dd.MM.yyyy"));
                        CreditGraf[1, i].Value = i + 1;
                        CreditGraf[2, i].Value = Math.Round((double)d.ListPayment[i], 2);
                        CreditGraf[3, i].Value = Math.Round((double)d.listRate[i], 2);
                        CreditGraf[4, i].Value = Math.Round(d.MainSum, 2);
                        CreditGraf[5, i].Value = Math.Round((double)d.listAmount[i], 2);
                    }
                    CreditGraf.ClearSelection();
                }
                for (int i = 0; i < c.Months; i++)                            //Заполняет список для график А
                {
                    listRateAint.Add(Math.Round((double)c.listRate[i], 2));
                    listMainSumAint.Add(Math.Round((double)c.listMainSum[i], 2));
                }
                for (int i = 0; i < d.Months; i++)                         //Заполняет список для график Б
                {
                    listRateDif.Add(Math.Round((double)d.listRate[i], 2));
                    listMainSumDif.Add(Math.Round(d.MainSum, 2));
                }
                d.Clear();
                c.Clear();
                TotalSum.Text = AmountBox.Text +" руб.";
                TotalPayment.Text = c.TotalPayment.ToString("0.00");
                TotalRate.Text = $"{Math.Round(c.TotalRate, 2)}" + " руб.";
            }
            catch (Exception) when (AmountBox.Text == string.Empty || RatesBox.Text == string.Empty || MonthsBox.Text == string.Empty)
            {
                ExecpMessage = "Не все необходимые поля были заполненны";
                ThisExceptionTextBox();
            }
            catch (FormatException)
            {
                ExecpMessage = "Неверный формат";
                ThisExceptionTextBox();
            }
            if (AmountBox.Text != string.Empty && RatesBox.Text != string.Empty && MonthsBox.Text != string.Empty)
            {
                DrawGraphicA();
            }
        }
        private void CreditGraf_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                try
                {
                    CreditGraf.FirstDisplayedScrollingRowIndex--;
                }
                catch (Exception)
                {
                    CreditGraf.FirstDisplayedScrollingColumnIndex = 0;
                }
            }
            else 
            { 
                if (e.Delta < 0)
                {
                    CreditGraf.FirstDisplayedScrollingRowIndex++;
                }
            }
        }
        private void CreditGraf_MouseLeave(object sender, EventArgs e)
        {
            CreditGraf.ClearSelection();
        }
        System.Timers.Timer tm = new System.Timers.Timer(2500);
        private void ThisExceptionTextBox() 
        {
            label5.Visible = true;
            label5.Text = ExecpMessage;
            tm.Elapsed += Timeout;
            tm.Start();
            tm.AutoReset = false;
        }
        System.Timers.Timer tm2 = new System.Timers.Timer(2500);
        private void ThisExeptionData()
        {
            label7.Visible = true;
            label7.Text = ExecpMessage;
            tm2.Elapsed += Timeout2;
            tm2.Start();
            tm2.AutoReset = false;
        }
        private void Timeout(Object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                label5.Visible = false;
            }
            catch (Exception)
            {
            }
            finally
            {
               tm.Stop();
            }
        }
        private void Timeout2(Object sender, System.Timers.ElapsedEventArgs e)
        {
            label7.Visible = false;
            tm2.Stop();
        }
        private void DataBox_Click(object sender, EventArgs e)
        {
            if(DataBox.MaskCompleted != true) { DataBox.SelectionStart = 0; DataBox.Clear(); }
        }
        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                MonthsBox.MaxLength = 5;
            }
            else
            {
                if (MonthsBox.Text.Length > 2)
                {
                    MonthsBox.Text = MonthsBox.Text.Substring(0,2);
                }
                MonthsBox.MaxLength = 2;
            }
        }
        private void AmountBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8) return;
            else
                e.Handled = true;
        }
        private void RatesBox_Leave(object sender, EventArgs e)
        {
            if (RatesBox.Text != string.Empty)
            {
                if (RatesBox.Text.Contains('.'))
                {
                    RatesBox.Text = RatesBox.Text.Replace('.', ',');
                }
                    RatesBox.Text = Convert.ToDouble(RatesBox.Text).ToString("0.00");
                
                if (Convert.ToDouble(RatesBox.Text) > 365)
                {
                    RatesBox.Text = $"{365.00}";
                    RatesBox.Text = Convert.ToDouble(RatesBox.Text).ToString("0.00");
                }
            }
        }
        private void MonthsBox_Leave(object sender, EventArgs e)
        {
            if (MonthsBox.Text != string.Empty)
            {
                if (listBox1.SelectedIndex == 1)
                {
                    if (Convert.ToInt32(MonthsBox.Text) > 50) { MonthsBox.Text = "50"; }
                }
                else
                {
                    if ((Convert.ToInt32(MonthsBox.Text) * 12) > 600) { MonthsBox.Text = "600"; }
                }
            }
        }

        private void AmountBox_Leave(object sender, EventArgs e)
        {
            if (AmountBox.Text != string.Empty)
            {
                if (Convert.ToDouble(AmountBox.Text) > 10000000)
                {
                    AmountBox.Text = "10000000";
                }
            }
        }

        private void MonthsBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8) return;
            else
                e.Handled = true;
        }


        //*****************************************************

        #region Swtich
        private void button2_Click(object sender, EventArgs e)
        {
            panel4.Height = ToCountButton.Height;
            panel4.Top = ToCountButton.Top;
            ToCountPanel.Visible = true;
            ComaprePanel.Visible = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            panel4.Height = ToCompareButton.Height;
            panel4.Top = ToCompareButton.Top;
            ToCompareProp();
            ToCountPanel.Visible = false;
            ComaprePanel.Visible = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            panel4.Height = ToSaveButton.Height;
            panel4.Top = ToSaveButton.Top;
        }
        private void RatesBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 44) return;
            else
                e.Handled = true;
        }
        private void ToCompareProp() 
        { 
            ComaprePanel.Size = new System.Drawing.Size(722, 522);
            ComaprePanel.Location = new System.Drawing.Point(182, -1);
        }
        private void DrawGraphicA() 
        {
            chart1.Series.Clear();
            chart2.Series.Clear();
            int countmonth = 0;
            countmonth = Int32.Parse(MonthsBox.Text);
            int mod = 1;
            if (listBox1.SelectedIndex == 0) { countmonth = Int32.Parse(MonthsBox.Text); }
            else { countmonth = Int32.Parse(MonthsBox.Text) * 12; }
            chart1.Series.Add("Процент Аннуитетного");
            chart2.Series.Add("Процент \nДифференцированного");
            chart1.Series.Add("Тело кредита Аннуитетного");
            chart2.Series.Add("Тело кредита \nДифференцированного");
            #region ChartPop
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            chart2.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(1, 13);
            chart2.ChartAreas[0].AxisX.ScaleView.Zoom(1, 13);
            chart1.ChartAreas[0].AxisX.Interval = 1;
            #endregion
            for (int i = 0; i < countmonth * mod; i++)
            {
                chart1.Series[0].Points.AddXY(i + 1, listRateAint[i]);
                chart1.Series[1].Points.AddXY(i + 1, listMainSumAint[i]);
            }
            for (int i = 0; i < countmonth * mod; i++)
            {
                chart2.Series[0].Points.AddXY(i + 1, listRateDif[i]);
                chart2.Series[1].Points.AddXY(i + 1, listMainSumDif[i]);
            }
            listMainSumAint.Clear();
            listMainSumDif.Clear();
            listRateAint.Clear();
            listRateDif.Clear();
        }
        #endregion
    }
}
