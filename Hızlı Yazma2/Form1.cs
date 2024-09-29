using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Reflection.Emit;

namespace Hızlı_Yazma2
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Server=DESKTOP-GNKKFD3;Database=HızTest;Integrated Security=True;");
        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
            kelget();
        }
        public void kelget()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select kelime from kelimeler where ıd=" + rand.Next(0, 1001), conn);
            label1.Text = cmd.ExecuteScalar().ToString(); conn.Close();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        int skor = 0;
        static public int keysto = 0;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            keysto++;
            timer1.Start();
            try
            {


                for (int i = 0; i < textBox1.Text.Length; i++)
                {
                    char[] dizi = label1.Text.ToArray();
                    if (dizi[i] == textBox1.Text[i])
                    {
                        for(int j = 0; j < karakterler.Length; j++)
                        {
                            if (textBox1.Text[i] == karakterler[j])
                            {
                                
                                dogru[j] += 1;
                            }
                        }
                        label1.ForeColor = Color.Green;
                    }
                    else
                    {
                        for (int j = 0; j < karakterler.Length; j++)
                        {
                            if (textBox1.Text[i] == karakterler[j])
                            {
                                
                                yanlis[j] += 1;
                            }
                        }
                        label1.ForeColor = Color.Red;
                    }
                    if (label1.Text == textBox1.Text)
                    {
                        textBox1.Text = null;
                        skor++;
                        kelget();
                        textBox1.MaxLength = label1.Text.Length;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata :" + ex);

            }
        }
        static public ArrayList skore = new ArrayList();

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        int sn = 1;
        int dk = 2;
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            dk = trackBar1.Value;
            label2.Text = dk + ":" + sn;
        }
        static public int topsn = 0;
        static public char[] karakterler = new char[]
{

    // Büyük harfler
    'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
    'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
    'U', 'V', 'W', 'X', 'Y', 'Z',

    // Küçük harfler
    'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
    'u', 'v', 'w', 'x', 'y', 'z' };
        static public int[] dogru = new int[]
{
    // Büyük harfler
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0,

    // Küçük harfler
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0
};
        static public int[] yanlis = new int[]
{
    // Büyük harfler
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0,

    // Küçük harfler
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
    0, 0, 0, 0, 0, 0
};
         
        public void timb()
        {
            timer1.Start();
        }
        public void timer1_Tick(object sender, EventArgs e)
        {
            topsn++;
            sn--;
            if (dk == 0 && sn == 0)
            {
                skore.Add(skor);
                timer1.Stop();
                MessageBox.Show("Tebrikler " + skor + " tane kelime yazdınız");
                dk = trackBar1.Value;
                sn = 60;

            }
            if (sn == 0)
            {
                sn = 60;
                dk--;

            }
            label2.Text = dk + ":" + sn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            
            İstatistikler is1 = new İstatistikler();
            is1.Show();
        }
    }
}
