using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const double k = 0.02;
        Random t = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            double cost = (double)inputPrice.Value;
            int day = (int)inputDays.Value;
            chart1.Series[0].Points.AddXY(0, cost);
            for (int i = 1; i <= day; i++)
            {
                cost = cost * (1 + k * (t.NextDouble() - 0.5));
                chart1.Series[0].Points.AddXY(i, cost);
                if (i == day)
                {
                    double profit = (double)inputPrice.Value * (double)money.Value - cost * (double)money.Value;
                    if (profit < 0) answer.Text = "profit " + profit * (-1) + " dollars";
                    else if (profit > 0) answer.Text = "loss " + profit + " dollars";
                    else answer.Text = "profit not changed";
                }
            }

        }
    }
}
