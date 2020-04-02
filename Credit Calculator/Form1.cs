using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Data;
using System.Threading;
namespace Credit_Calculator
{
    public partial class Form1 : Form
    {
        protected string ExecpMessage;
        #region ForChart
        readonly ArrayList listRateAint = new ArrayList();
        readonly ArrayList listMainSumAint = new ArrayList();
        readonly ArrayList listRateDif = new ArrayList();
        readonly ArrayList listMainSumDif = new ArrayList();
        #endregion
        public Form1()
        {
            InitializeComponent();
            panel4.Height = ToCountButton.Height;
            panel4.Top = ToCountButton.Top;
            Setting();
            ComaprePanel.Visible = false;
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;
            chart4.Visible = false;
        }
        double TotalProcent;
        double TotalMainSum;
        double TotalProcentDif;
        double TotalMainSumDif;
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
            if (listBox1.SelectedIndex == 0)
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
        private void RatesBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (RatesBox.Text != string.Empty)
                {
                    if (RatesBox.Text.Contains('.'))
                    {
                        RatesBox.Text = RatesBox.Text.Replace('.', ',');
                    }
                    RatesBox.Text = double.Parse(RatesBox.Text).ToString("F2");

                    if (Convert.ToDouble(RatesBox.Text) > 365)
                    {
                        RatesBox.Text = $"{365.00}";
                        RatesBox.Text = double.Parse(RatesBox.Text).ToString("F2");
                    }
                }
            }
            catch (Exception)
            {
                errorProvider3.SetError(RatesBox, "Неверный формат");
                RatesBox.Text = string.Empty;
            }
        }
        private void Tocount_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(AmountBox.Text) <= 0 || Convert.ToInt32(MonthsBox.Text) <= 0 || Convert.ToDouble(RatesBox.Text) <= 0) { throw new FormatException(); }
                int a = Int32.Parse(AmountBox.Text);
                double r = double.Parse(RatesBox.Text);
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
                    errorProvider2.SetError(DataBox, "Неккоректный ввод даты");
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
                    TotalPayment.Text = c.TotalPayment.ToString("0.00");
                    TotalRate.Text = $"{Math.Round(c.TotalRate, 2)}" + " руб.";
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
                    TotalPayment.Text = d.TotalPayment.ToString("0.00");
                    TotalRate.Text = $"{Math.Round(d.TotalRate, 2)}" + " руб.";
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
                TotalSum.Text = AmountBox.Text + " руб.";
                
                TotalMainSum = c.TotalPayment - c.TotalRate;
                TotalMainSumDif = d.TotalPayment - d.TotalRate;
                TotalM.Text = $"{c.Months}";
                TotalProcentDif = Math.Round(d.TotalRate, 2);
                TotalProcent = Math.Round(c.TotalRate, 2);
                DiffrenceLabel.Text = $"{Math.Round(c.TotalPayment - Int32.Parse(AmountBox.Text),2)} руб.";
                DiffrenceLabelD.Text = $"{Math.Round(d.TotalPayment - Int32.Parse(AmountBox.Text), 2)} руб.";
            }
            catch (Exception) when (AmountBox.Text == string.Empty || RatesBox.Text == string.Empty || MonthsBox.Text == string.Empty)
            {
                errorProvider1.SetError(label5, "Не все необходимые поля были заполненны");
            }
            catch (FormatException)
            {
                errorProvider1.SetError(label5, "Неверный формат");
            }
            if (AmountBox.Text != string.Empty && RatesBox.Text != string.Empty && MonthsBox.Text != string.Empty)
            {
                if(Convert.ToInt32(AmountBox.Text) >= 0 || Convert.ToInt32(MonthsBox.Text) >= 0 || Convert.ToDouble(RatesBox.Text) >= 0)
                DrawGraphicA();
            }
            SaveToExcelButton.Enabled = true;
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
        private void DataBox_Click(object sender, EventArgs e)
        {
            errorProvider2.Clear();
            if (DataBox.MaskCompleted != true) { DataBox.SelectionStart = 0; DataBox.Clear(); }
        }
        private void ListBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                MonthsBox.MaxLength = 5;
            }
            else
            {
                if (MonthsBox.Text.Length > 2)
                {
                    MonthsBox.Text = MonthsBox.Text.Substring(0, 2);
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
            errorProvider2.Clear();
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8) return;
            else
                e.Handled = true;
        }
        //*****************************************************
        #region Swtich
        private void Button2_Click(object sender, EventArgs e)
        {
            panel4.Height = ToCountButton.Height;
            panel4.Top = ToCountButton.Top;
            ToCountPanel.Visible = true;
            ComaprePanel.Visible = false;
            SavePanel.Visible = false;
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            panel4.Height = ToCompareButton.Height;
            panel4.Top = ToCompareButton.Top;
            ToCompareProp();
            ToCountPanel.Visible = false;
            ComaprePanel.Visible = true;
            SavePanel.Visible = false;
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            panel4.Height = ToSaveButton.Height;
            panel4.Top = ToSaveButton.Top;
            ComaprePanel.Visible = false;
            ToCountPanel.Visible = false;
            SavePanel.Visible = true;
        }
        private void RatesBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider3.Clear();
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
            chart3.Series.Clear();
            chart4.Series.Clear();
            chart1.Visible = true;
            chart2.Visible = true;
            chart3.Visible = true;
            chart4.Visible = true;
            label9.Visible = true;
            label7.Visible = true;
            int countmonth;
            countmonth = Int32.Parse(MonthsBox.Text);
            int mod = 1;
            if (listBox1.SelectedIndex == 0) {  }
            else { countmonth = Int32.Parse(MonthsBox.Text) * 12; }
            chart1.Series.Add("Процент Аннуитетного");
            chart2.Series.Add("Процент \nДифференцированного");
            chart1.Series.Add("Тело кредита Аннуитетного");
            chart2.Series.Add("Тело кредита \nДифференцированного");
            chart3.Series.Add("Соотношение процента к телу кредита");
            chart3.Series[0].Points.Add(TotalProcent);
            chart3.Series[0].Points.Add(TotalMainSum);
            chart3.Series[0].Points[0].LegendText = "Процент";
            chart3.Series[0].Points[1].LegendText = "Тело \nкредита";
            chart3.BackColor = Color.FromArgb(35, 44, 63);
            chart4.Series.Add("Соотношение процента к телу кредита");
            chart4.Series[0].Points.Add(TotalProcentDif);
            chart4.Series[0].Points.Add(TotalMainSumDif);
            chart4.Series[0].Points[0].LegendText = "Процент";
            chart4.Series[0].Points[1].LegendText = "Тело \nкредита";
            chart4.BackColor = Color.FromArgb(35, 44, 63);
            #region ChartPop
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            chart2.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            chart3.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            chart4.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(1, 9);
            chart2.ChartAreas[0].AxisX.ScaleView.Zoom(1, 9);
            chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
            chart2.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            chart2.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
            #endregion
            try
            {
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
            }
            catch (Exception)
            {
                errorProvider2.SetError(label5, "Некорректные значения");
            }
            listMainSumAint.Clear();
            listMainSumDif.Clear();
            listRateAint.Clear();
            listRateDif.Clear();
            #endregion
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (AmountBox.Text != string.Empty && MonthsBox.Text != string.Empty && RatesBox.Text != string.Empty)
            {
                errorProvider1.Clear();
            }
        }
        private void SaveToExcelButton_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.InitialDirectory = "C:";
                saveFileDialog1.Title = "Сохранение графика";
                saveFileDialog1.FileName = "График_платежей";
                saveFileDialog1.Filter = "Excel 2010 |*.xlsx|Excel|*.xls";
                if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    Microsoft.Office.Interop.Excel.Application Excelsapp = new Microsoft.Office.Interop.Excel.Application();
                    Excelsapp.Application.Workbooks.Add(Type.Missing);

                    Excelsapp.Columns.ColumnWidth = 20;
                    for (int i = 1; i < CreditGraf.Columns.Count + 1; i++)
                    {
                        Excelsapp.Cells[1, i] = CreditGraf.Columns[i - 1].HeaderText;
                    }
                    for (int i = 0; i < CreditGraf.Rows.Count; i++)
                    {
                        for (int j = 0; j < CreditGraf.Columns.Count; j++)
                        {
                            Excelsapp.Cells[i + 2, j + 1] = CreditGraf.Rows[i].Cells[j].Value;
                        }
                    }
                    Excelsapp.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName.ToString());
                    Excelsapp.ActiveWorkbook.Saved = true;
                    Excelsapp.Quit();
                    MessageBox.Show("Сохранено!");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Возможно вы пытаетесь заменить открытый файл.\n " +
                    "Пожалуйста закройте заменяемый файл или попробуйте сохранить новый под другим именем", 
                    "Ошибка сохранения!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
            
        }
    }
    
}
