using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double dt;
        
        const double g = 9.81;

        double a;
        double v0;
        double y0;

        double t;
        double x;
        double y;
        int timer = 0;

        private void btStart_Click(object sender, EventArgs e)
        {
            a = (double)edAngle.Value;
            v0 = (double)edSpeed.Value;
            y0 = (double)edHeight.Value;
            dt = (double)Step.Value;

            t = 0;
            x = 0;
            y = y0;
            timer = 0;

            textBox1.Text = timer.ToString();
            //chart1.Series[0].Points.Clear();
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = (int)maxX(v0, a)+1;
            chart1.ChartAreas[0].AxisY.Maximum = (int)maxY(v0, a)+1+y0;
            chart1.Series[0].Points.AddXY(x, y);

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer++;
            t += dt;
            x = v0 * Math.Cos(a * Math.PI / 180) * t;
            y = y0 + v0 * Math.Sin(a * Math.PI / 180) * t - g * t * t / 2;
            chart1.Series[0].Points.AddXY(x, y);
            textBox1.Text = timer.ToString();
            if (y <= 0) timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e) // pause
        {
            timer1.Stop();

        }

        private void button2_Click(object sender, EventArgs e) //продолжение
        {
            timer1.Start();
            t += dt;
            x = v0 * Math.Cos(a * Math.PI / 180) * t;
            y = y0 + v0 * Math.Sin(a * Math.PI / 180) * t - g * t * t / 2;
            chart1.Series[0].Points.AddXY(x, y);
            if (y <= 0) timer1.Stop();
        }
        private double maxX(double v0, double a)
        {
            double result = v0 * v0 * Math.Sin(2 * a * Math.PI / 180) / g;
            return result;
        }

        private double maxY(double v0, double a)
        {
            double result = v0 * v0 * Math.Sin(a * Math.PI / 180) * Math.Sin(a * Math.PI / 180) / (2*g);
            return result;
        }
    }
}
