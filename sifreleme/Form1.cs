using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sifreleme
{
    public partial class Form1 : Form
    {
        public string sifre;
        public char[] sifreDizi;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            sifre = textBox1.Text;

            sifreDizi = sifre.ToCharArray();

            int i = 0;
            while (i <= sifreDizi.Length - 1) {
                
                label6.Text += sifreDizi[i] + "\n"; 
                i++;
            }            

            byte[] sifreAsci = new byte[sifreDizi.Length];

            i = 0;

            while (i <= sifreAsci.Length - 1)
            {
                sifreAsci[i] = Convert.ToByte(sifreDizi[i]);
                i++;
            }

            int[] sifreAscii = new int[sifreDizi.Length];

            i = 0;
            while(i <= sifreAscii.Length - 1)
            {
                sifreAscii[i] = sifreAsci[i];

                if (sifreAscii[i] < 10)
                    sifreAscii[i] *= 1000;

                if (sifreAscii[i] < 100)
                    sifreAscii[i] *= 100;

                if (sifreAscii[i] < 1000)
                    sifreAscii[i] *= 10;
                
                label8.Text += sifreAsci[i] + "\n";

                i++;
            }

            string eskiSifre = "";

            i = 0;
           
            while (i < sifreAscii.Length)
            {
                eskiSifre += sifreAscii[i].ToString();
                i++;
            }
            
            label4.Text = eskiSifre;

            string yeniSifre = "";
            string ters = "";

            for (i = eskiSifre.Length - 1; i >= 0; i--)
            {
                ters += eskiSifre[i];
            }

            i = 0;
            int k = 0;
            int y = 0;
            while (i < eskiSifre.Length)
            {
                if (i % 2 == 0)
                {
                    yeniSifre += ters[y];
                    y++;
                }
                else
                {
                    yeniSifre += eskiSifre[k];
                    k++;
                }

                label5.Text = yeniSifre;
                i++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sifre = label5.Text;
            label2.Text = sifre;

            string ilkYarisi = "";
            string sonYarisi = "";

            int x = 1;

            while (x < sifre.Length)
            {
                ilkYarisi += sifre[x];  
                x = x + 2;
            }

            x = sifre.Length - 1;

            while (x > 0)
            {
                if(x % 2 == 0)
                    sonYarisi += sifre[x];

                x--;
            }

            sonYarisi += sifre[0];
            sifre = ilkYarisi + sonYarisi;

            string[] parcalar = new string[sifre.Length / 4];

            x = 0;
            int z = 4;
            int g = 0;

            while (x < parcalar.Length)
            {
                if (g < z)
                {
                    while (g < z)
                    {
                        parcalar[x] += sifre[g].ToString();
                        g++;
                    }

                }

                //else if (g < z)
                //{
                //    while (g < z)
                //    {
                //        parcalar[x] += sifre[g].ToString();
                //        g++;
                //    }
                //}
                //else if (g < 12)
                //{
                //    while (g < 12)
                //    {
                //        parcalar[x] += sifre[g].ToString();
                //        g++;
                //    }
                //}

                z += 4;
                x++;
            }

            x = 0;
            while(x < parcalar.Length)
            {
                label7.Text += parcalar[x] + "\n";
                x++;
            }
            
            label3.Text = sifre;

            x = 0;
            
            int d = 0;
            while (d < parcalar.Length)
            {
                while (x < parcalar.Length)
                {
                    if (!(Convert.ToInt32(parcalar[x]) < 127))
                    {
                        parcalar[x] = parcalar[x].Remove(parcalar[x].Length - 1);
                    }
                    x++;
                }
                x = 0;
                d++;
            }

            x = 0;

            while (x < parcalar.Length)
            {
                label11.Text += parcalar[x] + "\n";
                x++;
            }

            int karakteryap;

            x = 0;

            while (x < parcalar.Length)
            {
                karakteryap = Convert.ToInt32(parcalar[x]);
                label12.Text += ((char)karakteryap).ToString();
                x++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label6.Text = "";
            label8.Text = "";
            label4.Text = "";
            label5.Text = "";
            label2.Text = "";
            label3.Text = "";
            label7.Text = "";
            label11.Text = "";
            label12.Text = "";
        }
    }
}