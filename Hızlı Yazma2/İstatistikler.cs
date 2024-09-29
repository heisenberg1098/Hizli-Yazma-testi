using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Hızlı_Yazma2
{
    public partial class İstatistikler : Form
    {
       
        public İstatistikler()
        {
            InitializeComponent();
            

        }
        decimal top = 0;
        private void İstatistikler_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Form1.skore.Count; i++)
            {
                chart1.Series["oyun-skor"].Points.AddXY(i, Form1.skore[i]);
                top += Convert.ToInt32(Form1.skore[i]);
                label1.Text = "oyun başına ortalama " + top / Form1.skore.Count + " tane kelime bildin!";
                label2.Text = "oyunda toplamda " + top + " tane kelime bildin!";
            }
            label3.Text = "Toplam Süre: " + Form1.topsn;
            if (Form1.topsn != 0 && top != 0)
            {

                label4.Text = "dk/kel:" + top / Convert.ToDecimal(Form1.topsn / 60);
            }
            else
            {
                label4.Text = "dk/kel:" + " 0/0 - Maalesef hiçveri yok";
            }


            for (int i = 0; i < Form1.karakterler.Length; i++)
            {
            }
            keldy();


        }
        public void keldy()
        {
            label5.Text = null;
            for (int i = 26; i < Form1.karakterler.Length; i++)
            {
                chart2.Series["kelime dogru"].Points.AddXY(Form1.karakterler[i].ToString(), Form1.dogru[i]);
                chart2.Series["kelime yanlış"].Points.AddXY(Form1.karakterler[i].ToString(), Form1.yanlis[i]);
                chart2.ChartAreas[0].AxisX.Interval = 1;
                chart2.ChartAreas[0].AxisX.LabelStyle.IsStaggered = false;


                if ((i + 3) % 4 == 0)
                {
                    label5.Text += Form1.karakterler[i].ToString() + "  D:" + Form1.dogru[i].ToString() + "  Y:" + Form1.yanlis[i].ToString() + " \n ";

                }
                else
                {
                    label5.Text += Form1.karakterler[i].ToString() + "  D:" + Form1.dogru[i].ToString() + "  Y:" + Form1.yanlis[i].ToString() + "  -  ";

                }


            }
        }

        private void İstatistikler_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
