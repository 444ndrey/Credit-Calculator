using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Credit_Calculator
{
    public partial class Form1 : Form
    {
        protected string Excpt; //текст исключения
        public Form1()
        {
            InitializeComponent();
            panel4.Height = button2.Height;
            panel4.Top = button2.Top;
            Setting();
            
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
            AmountBox.MaxLength = 10;
            RateBox.MaxLength = 5;
            if(listBox1.SelectedIndex == 0)
            {
             MonthsBox.MaxLength = 5;
            }
            else
            {
                MonthsBox.MaxLength = 2;
            }
            #endregion
        }
        //***************
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
            panel4.Height = button2.Height;
            panel4.Top = button2.Top;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            panel4.Height = button3.Height;
            panel4.Top = button3.Top;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            panel4.Height = button4.Height;
            panel4.Top = button4.Top;
        }
        private void tocount_Click(object sender, EventArgs e)
        {
            try
            {
                int a = Int32.Parse(AmountBox.Text);
                double r = Double.Parse(RateBox.Text);
                int m = Int32.Parse(MonthsBox.Text);
                Credit c = new Credit(a, r, m);
                try
                {
                    c.dateTime1 = System.DateTime.Parse(String.Format(DataBox.Text));
                }
                catch(Exception) when (DataBox.MaskCompleted == true)
                {
                    c.dateTime1 = DateTime.Now;
                    Excpt = "Неккоректный ввод даты";
                    ExceptionNullBox();
                }
                catch when (DataBox.MaskCompleted == false)
                {
                    c.dateTime1 = DateTime.Now;
                }
                catch (Exception)
                {
                    c.dateTime1 = DateTime.Now;
                    Excpt = "Неккоректный ввод даты";
                    ExceptionNullBox();
                }
                if (listBox1.SelectedIndex == 0)
                {
                }
                else
                {
                    c.Months *= 12;
                }
                CreditGraf.Columns.Clear();
                DrawGraf();
                int j = c.dateTime1.Month;
                if (listBox2.SelectedIndex == 0)
                {
                    c.ToCount();
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
                    c.Clear();
                    CreditGraf.ClearSelection();
                }
                else
                {
                    c.ToCountDif();
                    for (int i = 0; i < c.Months; i++)
                    {
                        j += 1;
                        CreditGraf.Rows.Add();
                        CreditGraf[0, i].Value = (c.dateTime1.AddMonths(i)).ToString(("dd.MM.yyyy"));
                        CreditGraf[1, i].Value = i + 1;
                        CreditGraf[2, i].Value = Math.Round((double)c.ListPayment[i], 2);
                        CreditGraf[3, i].Value = Math.Round((double)c.listRate[i], 2);
                        CreditGraf[4, i].Value = Math.Round(c.MainSum, 2);
                        CreditGraf[5, i].Value = Math.Round((double)c.listAmount[i], 2);
                    }
                }
            }
            catch (Exception) when (AmountBox.Text == string.Empty || RateBox.Text == string.Empty || MonthsBox.Text == string.Empty)
            {
                Excpt = "Заполните все необходимые поля";
                ExceptionNullBox();
            }
            catch (FormatException)
            {
                Excpt = "Некорректный ввод";
                ExceptionNullBox();
            }
        }
        private void CreditGraf_MouseEnter(object sender, EventArgs e)
        {
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
        private void ExceptionNullBox() 
        {
            label5.Visible = true;
            label5.Text = Excpt; 
            tm.Elapsed += Timeout;
            tm.Start();
            tm.AutoReset = false;
        }
        private void Timeout(Object sender, System.Timers.ElapsedEventArgs e)
        {
            label5.Visible = false;
            tm.Stop();
        }

        private void DataBox_Click(object sender, EventArgs e)
        {
            DataBox.SelectionStart = 0;
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
    }
}
