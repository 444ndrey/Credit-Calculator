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
        }
        void DrawGraf() // рисует столбцы
        {
            CreditGraf.Columns.Add("data", "Дата");
            CreditGraf.Columns.Add("month", "Месяц");
            CreditGraf.Columns.Add("payment", "Платеж");
            CreditGraf.Columns.Add("procent", "Процент");
            CreditGraf.Columns.Add("MainSum", "Основная сумма");
            CreditGraf.Columns.Add("amount", "Остаток");
        }
        #region tablesetting 
        // сюда забивай настройки таблицы
       //***************
        void Setting()
        {
            CreditGraf.Columns[4].Width = 89;
        }
        //***************
        #endregion
    }
}
