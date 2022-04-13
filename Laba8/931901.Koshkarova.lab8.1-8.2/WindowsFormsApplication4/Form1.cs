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

        double p = 0.6;
        double a;
        double[] prob = { 0.1, 0.15, 0.1, 0.15, 0.2, 0.05, 0.2, 0.05};
        string[] pred = { "Без сомнения", "Бесспорно", "Будущее не определено", "Не могу сейчас сказать", "Ну такое", "Последствия на твоей совести", "Спроси позже", "Сейчас самое подходящее время!"};
        Random r = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            a = r.NextDouble();
            
            if (a <= p) textBox2.Text = "Yeap"; 
            else textBox2.Text = "Nope";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double summ = 0;
            
            for (int i = 0; i < 8; i++)
            {
                textBox2.Clear();
                summ += prob[i];
                a = r.NextDouble();
                
                if (a < summ) 
                { 
                    textBox2.Text = pred[i]; 
                    break; 
                }
            }
        }
    }  
}
