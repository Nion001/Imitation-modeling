using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double[] probT, probEx, Err;
        int N; int[] stat;
        Random R = new Random();
        double a;

        private void button1_Click(object sender, EventArgs e)
        {
            probT = new double[7]; probEx = new double[7]; Err = new double[7]; stat = new int[7];
            N = (int)tbN.Value;
            probT[0] = (double)tbpr1.Value; probT[1] = (double)tbpr2.Value; probT[2] = (double)tbpr3.Value;
            probT[3] = (double)tbpr4.Value; probT[4] = (double)tbpr5.Value; probT[5] = (double)tbpr6.Value; 
            probT[6] = 1;
            
            for (int i = 0; i < 6; i++) probT[6] -= probT[i]; 
            
            tbpr7.Text = probT[6].ToString();

            for (int i = 0; i < N; i++) 
            {
                a = R.NextDouble();
                double summ = 0;
                
                for (int k = 0; k < 7; k++) 
                {
                    summ += probT[k];

                    if (a <= summ) 
                    { 
                        stat[k]++; 
                        break; 
                    }
                }
            }

            for(int i = 0; i < 7; i++) 
            {
                probEx[i] = stat[i] / (double)N;
                Err[i] = Math.Abs(1 - (probEx[i] / probT[i]))*100;
            }

            tbprEx1.Text = probEx[0].ToString(); tbprEx2.Text = probEx[1].ToString(); tbprEx3.Text = probEx[2].ToString(); tbprEx4.Text = probEx[3].ToString();
            tbprEx5.Text = probEx[4].ToString(); tbprEx6.Text = probEx[5].ToString(); tbprEx7.Text = probEx[6].ToString();
            
            tbprR1.Text = Err[0].ToString("F1"); tbprR2.Text = Err[1].ToString("F1"); tbprR3.Text = Err[2].ToString("F1"); tbprR4.Text = Err[3].ToString("F1");
            tbprR5.Text = Err[4].ToString("F1"); tbprR6.Text = Err[5].ToString("F1"); tbprR7.Text = Err[6].ToString("F1");

            chart1.Series[0].Points.Clear();
            
            for (int i = 0; i < 7; i++) chart1.Series[0].Points.AddXY(i+1, probEx[i]);
        } 
    }
}
