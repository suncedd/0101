using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBox1.Text);
            double b = Convert.ToDouble(textBox2.Text);
            double c = Convert.ToDouble(textBox3.Text);
            Uravnenie ur = new Uravnenie(a, b, c);
            ur.calculation();
            ur++;
            ur.pok();
            ur--;
            ur.pok();
        }
        class Uravnenie
        {
            public double a, b, c, x1, x2,d;

            public Uravnenie(double a, double b, double c)
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }
            public void calculation()
            {
               d = b * b - 4 * a * c;
               x1 = (-b - Math.Sqrt(d)) / (2 * a);
               x2 = (-b + Math.Sqrt(d)) / (2 * a);
                MessageBox.Show(a+ " " + b + " " + c + " " +"\n" + "Дискриминант= " + Convert.ToString(d) + "\n" + "x1= " + Convert.ToString(x1) + "\n" + "x2 = " + Convert.ToString(x2));
            }
            public static Uravnenie operator ++(Uravnenie ur)
            {
                ur.a++;
                ur.b++;
                ur.c++;
                return ur;
            }
            public static Uravnenie operator --(Uravnenie ur)
            {
                ur.a--;
                ur.b--;
                ur.c--;
                return ur;
            }
            public void pok()
            {
                MessageBox.Show(a + " " + b + " " + c);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a, b, c;
            a = Convert.ToInt32(textBox1.Text);
            b = Convert.ToInt32(textBox2.Text);
            c = Convert.ToInt32(textBox3.Text);
            raz(a, b);
            raz(a, b, c);
        }
        public void raz(int a, int b)
        {
            int r = a - b;
            MessageBox.Show("Разность первых 2-х чисел = " + r);
        }
        public void raz(int a, int b, int c)
        {
            int r = a - b - c;
            MessageBox.Show("Разность всех 3-х чисел = " + r);
        }
       
        
        
        
        
        
        class UravnenieArray
        {
           public Uravnenie[] arr;
            public int size;
            public UravnenieArray()
            {
                arr = null;
                size = 0;
            }
            public UravnenieArray(int s)
            {
                size = s;
                arr = new Uravnenie[size];
                Random rnd = new Random();
                for (int i = 0; i < size-1; i++)
                {
                    int a = rnd.Next(-10, 10);
                    int b = rnd.Next(0, 10);
                    int c = rnd.Next(0, 10);
                    Uravnenie f = new Uravnenie(a, b, c);
                    arr[i] = f;
                }
            }
            public void Show()
            {
                for (int i = 0; i < size-1; i++)
                {
                    arr[i].pok();
                }

            }
            public Uravnenie this [int index]
            {
                get
                {
                    if (index >= 0 && index < size)
                        return arr[index];
                    else
                    {
                        MessageBox.Show("неправильно задан индекс");
                        return new Uravnenie(0, 0, 0);
                    }
                }
                set
                {
                    if (index >= 0 && index < size)
                        arr[index] = value;
                    else

                        MessageBox.Show("неправильно задан индекс");
                }
            }
            public void UR()
            {
                for (int i = 0; i < size-1; i++)
                {
                    arr[i].calculation();

                }
                double max = arr[0].x1;
                double max1 = arr[0].x2;
                for (int i = 0; i < size-1; i++)
                {
                    if (double.IsInfinity(max))
                    {
                         max = arr[i].x1;
                    }
                    if (double.IsNaN(max)) 
                    {
                        max = arr[i].x1;
                    }
                    if(max > arr[i].x1)
                    {
                        max = arr[i].x1;
                    }
                    if (double.IsInfinity(max1))
                    {
                        max1 = arr[i].x2;
                    }
                    if (double.IsNaN(max1))
                    {
                        max1 = arr[i].x2;
                    }
                    if (max1 > arr[i].x2)
                    {
                        max1 = arr[i].x2;
                    }
                }
                if (max > max1)
                {
                    MessageBox.Show("Максимальное абсолютное значение корня = " + max);
                }
                else
                {
                    MessageBox.Show("Максимальное абсолютное значение корня = " + max1);
                }
                }

            }


        private void button3_Click(object sender, EventArgs e)
        {
            UravnenieArray Ua = new UravnenieArray(3);
            Uravnenie U = new Uravnenie(0,0,0);
            U = Ua[0];     
            Ua.Show();
            Ua.UR();

        }
    }
}
