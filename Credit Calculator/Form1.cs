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
        public Form1()
        {
            InitializeComponent();
            DrawGraf();
            Setting();
            panel4.Height = button2.Height;
            panel4.Top = button2.Top;
        }
        void DrawGraf() // рисует столбцы
        {
            CreditGraf.Columns.Add("data", "Дата");
            CreditGraf.Columns.Add("month", "Месяц");
            CreditGraf.Columns.Add("payment", "Платеж");
            CreditGraf.Columns.Add("procent", "Процент");
            CreditGraf.Columns.Add("MainSum", "Основная \nсумма");
            CreditGraf.Columns.Add("amount", "Остаток");
        }
        #region tablesetting 
        // сюда забивай настройки таблицы
       //***************
        void Setting()
        {
            foreach (DataGridViewColumn item in CreditGraf.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            CreditGraf.RowHeadersVisible = false;
            CreditGraf.AllowUserToResizeColumns = false;
            CreditGraf.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
