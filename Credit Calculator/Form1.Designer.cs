namespace Credit_Calculator
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ToSaveButton = new System.Windows.Forms.Button();
            this.ToCompareButton = new System.Windows.Forms.Button();
            this.ToCountButton = new System.Windows.Forms.Button();
            this.ToCountPanel = new System.Windows.Forms.Panel();
            this.CreditGraf = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AmountBox = new System.Windows.Forms.TextBox();
            this.RatesBox = new System.Windows.Forms.TextBox();
            this.MonthsBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.procentlabel = new System.Windows.Forms.Label();
            this.rublabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tocount = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.DataBox = new System.Windows.Forms.MaskedTextBox();
            this.TotalPayment = new System.Windows.Forms.Label();
            this.TotalLabel = new System.Windows.Forms.Label();
            this.TotalRate = new System.Windows.Forms.Label();
            this.TotalSum = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.ToCountPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CreditGraf)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(44)))), ((int)(((byte)(70)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.ToSaveButton);
            this.panel1.Controls.Add(this.ToCompareButton);
            this.panel1.Controls.Add(this.ToCountButton);
            this.panel1.Location = new System.Drawing.Point(0, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 535);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel4.Location = new System.Drawing.Point(168, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(11, 81);
            this.panel4.TabIndex = 4;
            // 
            // ToSaveButton
            // 
            this.ToSaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ToSaveButton.FlatAppearance.BorderSize = 0;
            this.ToSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToSaveButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ToSaveButton.ForeColor = System.Drawing.Color.White;
            this.ToSaveButton.Location = new System.Drawing.Point(3, 218);
            this.ToSaveButton.Name = "ToSaveButton";
            this.ToSaveButton.Size = new System.Drawing.Size(172, 84);
            this.ToSaveButton.TabIndex = 7;
            this.ToSaveButton.Text = "Сохранить";
            this.ToSaveButton.UseVisualStyleBackColor = true;
            this.ToSaveButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // ToCompareButton
            // 
            this.ToCompareButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ToCompareButton.FlatAppearance.BorderSize = 0;
            this.ToCompareButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToCompareButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ToCompareButton.ForeColor = System.Drawing.Color.White;
            this.ToCompareButton.Location = new System.Drawing.Point(3, 112);
            this.ToCompareButton.Name = "ToCompareButton";
            this.ToCompareButton.Size = new System.Drawing.Size(172, 84);
            this.ToCompareButton.TabIndex = 6;
            this.ToCompareButton.Text = "Сравнить";
            this.ToCompareButton.UseVisualStyleBackColor = true;
            this.ToCompareButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // ToCountButton
            // 
            this.ToCountButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ToCountButton.FlatAppearance.BorderSize = 0;
            this.ToCountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToCountButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ToCountButton.ForeColor = System.Drawing.Color.White;
            this.ToCountButton.Location = new System.Drawing.Point(3, -3);
            this.ToCountButton.Name = "ToCountButton";
            this.ToCountButton.Size = new System.Drawing.Size(172, 87);
            this.ToCountButton.TabIndex = 5;
            this.ToCountButton.Text = "Рассчет";
            this.ToCountButton.UseVisualStyleBackColor = true;
            this.ToCountButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // ToCountPanel
            // 
            this.ToCountPanel.Controls.Add(this.panel2);
            this.ToCountPanel.Controls.Add(this.CreditGraf);
            this.ToCountPanel.Location = new System.Drawing.Point(182, -1);
            this.ToCountPanel.Name = "ToCountPanel";
            this.ToCountPanel.Size = new System.Drawing.Size(725, 512);
            this.ToCountPanel.TabIndex = 6;
            // 
            // CreditGraf
            // 
            this.CreditGraf.AllowUserToAddRows = false;
            this.CreditGraf.AllowUserToDeleteRows = false;
            this.CreditGraf.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CreditGraf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CreditGraf.Location = new System.Drawing.Point(6, 3);
            this.CreditGraf.Name = "CreditGraf";
            this.CreditGraf.ReadOnly = true;
            this.CreditGraf.ShowEditingIcon = false;
            this.CreditGraf.Size = new System.Drawing.Size(714, 289);
            this.CreditGraf.TabIndex = 4;
            this.CreditGraf.MouseLeave += new System.EventHandler(this.CreditGraf_MouseLeave);
            this.CreditGraf.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.CreditGraf_MouseWheel);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.TotalSum);
            this.panel2.Controls.Add(this.TotalRate);
            this.panel2.Controls.Add(this.TotalLabel);
            this.panel2.Controls.Add(this.TotalPayment);
            this.panel2.Controls.Add(this.DataBox);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.tocount);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.listBox2);
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.rublabel);
            this.panel2.Controls.Add(this.procentlabel);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.MonthsBox);
            this.panel2.Controls.Add(this.RatesBox);
            this.panel2.Controls.Add(this.AmountBox);
            this.panel2.Location = new System.Drawing.Point(6, 300);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(714, 217);
            this.panel2.TabIndex = 2;
            // 
            // AmountBox
            // 
            this.AmountBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(44)))), ((int)(((byte)(63)))));
            this.AmountBox.ForeColor = System.Drawing.Color.White;
            this.AmountBox.Location = new System.Drawing.Point(261, 30);
            this.AmountBox.Name = "AmountBox";
            this.AmountBox.Size = new System.Drawing.Size(100, 20);
            this.AmountBox.TabIndex = 1;
            this.AmountBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AmountBox_KeyPress);
            this.AmountBox.Leave += new System.EventHandler(this.AmountBox_Leave);
            // 
            // RatesBox
            // 
            this.RatesBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(44)))), ((int)(((byte)(63)))));
            this.RatesBox.ForeColor = System.Drawing.Color.White;
            this.RatesBox.Location = new System.Drawing.Point(261, 66);
            this.RatesBox.Name = "RatesBox";
            this.RatesBox.Size = new System.Drawing.Size(100, 20);
            this.RatesBox.TabIndex = 1;
            this.RatesBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RatesBox_KeyPress);
            this.RatesBox.Leave += new System.EventHandler(this.RatesBox_Leave);
            // 
            // MonthsBox
            // 
            this.MonthsBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(44)))), ((int)(((byte)(63)))));
            this.MonthsBox.ForeColor = System.Drawing.Color.White;
            this.MonthsBox.Location = new System.Drawing.Point(261, 110);
            this.MonthsBox.Name = "MonthsBox";
            this.MonthsBox.Size = new System.Drawing.Size(100, 20);
            this.MonthsBox.TabIndex = 2;
            this.MonthsBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MonthsBox_KeyPress);
            this.MonthsBox.Leave += new System.EventHandler(this.MonthsBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(44)))), ((int)(((byte)(63)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(147, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Сумма кредита";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(44)))), ((int)(((byte)(63)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(452, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 34);
            this.label6.TabIndex = 3;
            this.label6.Text = "Дата первой \r\nоплаты";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(118, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 34);
            this.label2.TabIndex = 4;
            this.label2.Text = "Процентная ставка\r\n (%годовых)";
            // 
            // procentlabel
            // 
            this.procentlabel.AutoSize = true;
            this.procentlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.procentlabel.ForeColor = System.Drawing.Color.White;
            this.procentlabel.Location = new System.Drawing.Point(364, 69);
            this.procentlabel.Name = "procentlabel";
            this.procentlabel.Size = new System.Drawing.Size(20, 17);
            this.procentlabel.TabIndex = 4;
            this.procentlabel.Text = "%";
            // 
            // rublabel
            // 
            this.rublabel.AutoSize = true;
            this.rublabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rublabel.ForeColor = System.Drawing.Color.White;
            this.rublabel.Location = new System.Drawing.Point(364, 33);
            this.rublabel.Name = "rublabel";
            this.rublabel.Size = new System.Drawing.Size(35, 17);
            this.rublabel.TabIndex = 4;
            this.rublabel.Text = "руб.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(157, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Срок кредита";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(44)))), ((int)(((byte)(63)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Месяцов",
            "Лет"});
            this.listBox1.Location = new System.Drawing.Point(367, 110);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(65, 26);
            this.listBox1.TabIndex = 7;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(44)))), ((int)(((byte)(63)))));
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox2.ForeColor = System.Drawing.Color.White;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Items.AddRange(new object[] {
            "Аннуитетный",
            "Дифференцированный"});
            this.listBox2.Location = new System.Drawing.Point(261, 148);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(126, 26);
            this.listBox2.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(155, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Срок платежа";
            // 
            // tocount
            // 
            this.tocount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tocount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tocount.FlatAppearance.BorderSize = 0;
            this.tocount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tocount.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tocount.ForeColor = System.Drawing.Color.Black;
            this.tocount.Location = new System.Drawing.Point(536, 148);
            this.tocount.Name = "tocount";
            this.tocount.Size = new System.Drawing.Size(170, 49);
            this.tocount.TabIndex = 8;
            this.tocount.Text = "РАССЧИТАТЬ";
            this.tocount.UseVisualStyleBackColor = false;
            this.tocount.Click += new System.EventHandler(this.tocount_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label5.Location = new System.Drawing.Point(3, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 10;
            // 
            // DataBox
            // 
            this.DataBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(44)))), ((int)(((byte)(63)))));
            this.DataBox.ForeColor = System.Drawing.Color.White;
            this.DataBox.Location = new System.Drawing.Point(555, 66);
            this.DataBox.Mask = "00/00/0000";
            this.DataBox.Name = "DataBox";
            this.DataBox.Size = new System.Drawing.Size(100, 20);
            this.DataBox.TabIndex = 11;
            this.DataBox.ValidatingType = typeof(System.DateTime);
            this.DataBox.Click += new System.EventHandler(this.DataBox_Click);
            // 
            // TotalPayment
            // 
            this.TotalPayment.AutoSize = true;
            this.TotalPayment.ForeColor = System.Drawing.Color.White;
            this.TotalPayment.Location = new System.Drawing.Point(234, 0);
            this.TotalPayment.Name = "TotalPayment";
            this.TotalPayment.Size = new System.Drawing.Size(0, 13);
            this.TotalPayment.TabIndex = 12;
            // 
            // TotalLabel
            // 
            this.TotalLabel.AutoSize = true;
            this.TotalLabel.ForeColor = System.Drawing.Color.White;
            this.TotalLabel.Location = new System.Drawing.Point(12, 0);
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Size = new System.Drawing.Size(40, 13);
            this.TotalLabel.TabIndex = 12;
            this.TotalLabel.Text = "Всего:";
            // 
            // TotalRate
            // 
            this.TotalRate.AutoSize = true;
            this.TotalRate.ForeColor = System.Drawing.Color.White;
            this.TotalRate.Location = new System.Drawing.Point(351, 0);
            this.TotalRate.Name = "TotalRate";
            this.TotalRate.Size = new System.Drawing.Size(0, 13);
            this.TotalRate.TabIndex = 12;
            // 
            // TotalSum
            // 
            this.TotalSum.AutoSize = true;
            this.TotalSum.ForeColor = System.Drawing.Color.White;
            this.TotalSum.Location = new System.Drawing.Point(476, 0);
            this.TotalSum.Name = "TotalSum";
            this.TotalSum.Size = new System.Drawing.Size(0, 13);
            this.TotalSum.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label7.Location = new System.Drawing.Point(190, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(44)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(907, 523);
            this.Controls.Add(this.ToCountPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Кредитный калькулятор";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ToCountPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CreditGraf)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ToSaveButton;
        private System.Windows.Forms.Button ToCompareButton;
        private System.Windows.Forms.Button ToCountButton;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel ToCountPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label TotalSum;
        private System.Windows.Forms.Label TotalRate;
        private System.Windows.Forms.Label TotalLabel;
        private System.Windows.Forms.Label TotalPayment;
        private System.Windows.Forms.MaskedTextBox DataBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button tocount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label rublabel;
        private System.Windows.Forms.Label procentlabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MonthsBox;
        private System.Windows.Forms.TextBox RatesBox;
        private System.Windows.Forms.TextBox AmountBox;
        private System.Windows.Forms.DataGridView CreditGraf;
    }
}

