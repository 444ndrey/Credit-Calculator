using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Credit_Calculator
{
    sealed class Credit
    {
        double payment;
        double amount; // Сумма кредита
        double rate; // кредитная ставка
        double months; // срок кредита в месяцах
        string name; //Имя кредита для сохраненния
        double mainsum; // Платеж по основному кредиту
        #region prop
        public DateTime dateTime1 = new DateTime();
        public double TotalPayment { get; protected set; }
        public double TotalRate { get; protected set; }
        public double MounthProcent { get; protected set; }
        public double MainSum 
        { 
            get
            {
                return mainsum;
            }
            private set
            {
                mainsum = value;
            }
        }
        public double Payment { get { return payment; } }
        public double Amount {
            get
            {
                return amount;
            }
            set
            {
                if (value > 0)
                {
                    amount = value;
                }
            }
        }
        public double Months 
        { 
            get
            {
                return months;
            }
            set
            {
                if (value > 0) 
                {
                    months = value;
                }
            }
        }
        public double Rate 
        {
            get
            {
                return rate;
            }
            set
            {
                if (value >= 1) { rate = value; }
            }
        }
        string Name
        {
            get { return name; }
            set 
            { 
                 if(value.Length <= 15) { name = value; }
            }
        }
        #endregion
        #region ctor 
        //Конструкторы 
        public Credit(int a, double r, int m) //(сумма,ставка,срок в месяцах)
        {
            Amount = Convert.ToDouble(a);
            Rate = Convert.ToDouble(r);
            Months = m;
        }
        #endregion
        #region Methods
        internal ArrayList ListPayment = new ArrayList();
        internal ArrayList listRate = new ArrayList();
        internal ArrayList listMainSum = new ArrayList();
        internal ArrayList listAmount = new ArrayList();
        public void ToCount() // Аннуитетный 
        {
            double i; // ежемесечная процентная ставка 
            i = rate / 100;
            i /= 12;
            double a;
            a = (double)Math.Pow((1.0 + i), months);
            a -= 1;
            payment = amount*(i + (i / a));
            for (int j = 0; j < Months; j++)
            {
                MounthProcent = (Amount * i);
                MainSum = payment - MounthProcent;
                amount -= MainSum;
                listRate.Add(Math.Round(MounthProcent,2));
                listMainSum.Add(Math.Round(MainSum,2));
                listAmount.Add(Math.Round(Amount,2));
                TotalRate += MounthProcent;
            }
            TotalPayment = Payment * Months;
        }
        public void Clear()
        {
            listMainSum.Clear();
            listRate.Clear();
            listAmount.Clear();
            ListPayment.Clear();
        }
        public void ToCountDif() //Дифференцированный
        {
            #region Condition
            int DaysInTheYear;
            if(dateTime1.Year % 4 == 0 && dateTime1.Year % 100 != 0 )
            {
                DaysInTheYear = 366;
            }
            else
            {
                if(dateTime1.Year % 400 == 0)
                {
                    DaysInTheYear = 366;
                }
                else
                {
                    DaysInTheYear = 365;
                }
            }
            #endregion
            MainSum = (Amount / Months);
            for (int i = 0; i < Months; i++)
            {
                TimeSpan timeSpan = dateTime1.AddMonths(i + 1) - dateTime1.AddMonths(i);
                MounthProcent = amount * (Rate / 100.0) * ((double)timeSpan.Days / DaysInTheYear);
                Amount -= MainSum;
                payment = MainSum + MounthProcent;
                listRate.Add(MounthProcent);
                ListPayment.Add(payment);
                listAmount.Add(amount);
                TotalRate += MounthProcent;
            }
            TotalPayment = Payment * Months;
        }
        #endregion
    }
}
