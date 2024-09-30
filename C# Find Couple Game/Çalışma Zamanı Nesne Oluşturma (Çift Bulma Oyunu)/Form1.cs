using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Çalışma_Zamanı_Nesne_Oluşturma__Çift_Bulma_Oyunu_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PictureBox[,] kutu = new PictureBox[4, 4];

        int[,] dizi = new int[4, 4];

        int[] d = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        int s;
        int açılanButonSayısı = 0;

        Random r = new Random();
        object sender2;


        private void tıkla(object sender, EventArgs e)
        {
            s = Convert.ToInt32((sender as PictureBox).Name);
            açılanButonSayısı++;
            switch (s)
            {
                case 1: (sender as PictureBox).Image = Image.FromFile(@"meyveler\karpuz.jpg"); break;
                case 2: (sender as PictureBox).Image = Image.FromFile(@"meyveler\portakal.jpg"); break;
                case 3: (sender as PictureBox).Image = Image.FromFile(@"meyveler\elma.jpg"); break;
                case 4: (sender as PictureBox).Image = Image.FromFile(@"meyveler\çilek.jpg"); break;
                case 5: (sender as PictureBox).Image = Image.FromFile(@"meyveler\armut.jpg"); break;
                case 6: (sender as PictureBox).Image = Image.FromFile(@"meyveler\muz.jpg"); break;
                case 7: (sender as PictureBox).Image = Image.FromFile(@"meyveler\ananas.jpg"); break;
                case 8: (sender as PictureBox).Image = Image.FromFile(@"meyveler\üzüm.jpg"); break;
            }

            if (açılanButonSayısı == 1) sender2 = sender;

            if (açılanButonSayısı == 2)
            {
                if (sender != sender2)
                {

                    if ((sender as PictureBox).Name == (sender2 as PictureBox).Name)
                    {
                        (sender as PictureBox).Enabled = false;             //Eşleşen resimler bulunduğu için artık tıklanamayacak.
                        (sender2 as PictureBox).Enabled = false;
                    }
                    else
                    {
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(2000);
                        (sender as PictureBox).Image = null;                //Farklı resimler açıldığı için resimler gizleniyor.
                        (sender2 as PictureBox).Image = null;
                    }
                }
                else (sender as PictureBox).Image = null;                 //İki kez aynı resim tıklandığından resim gizleniyor.

                açılanButonSayısı = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            label1.Text = "";

            for (int y = 0; y < 4; y++)
                for (int x = 0; x < 4; x++)
                {
                    s = r.Next(16) + 1;
                    if (d[s - 1] == 0)
                    {
                        d[s - 1] = s;
                        if (s <= 8) dizi[x, y] = s;
                        else dizi[x, y] = s -= 8;
                    }
                    else x--;
                }

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    kutu[x, y] = new PictureBox();
                    kutu[x, y].Parent = this;
                    kutu[x, y].Size = new Size(50, 50);
                    kutu[x, y].Location = new Point(x * 50, y * 50);
                    kutu[x, y].Click += new EventHandler(tıkla);
                    kutu[x, y].Name = Convert.ToString(dizi[x, y]);
                    kutu[x, y].Text = Convert.ToString(dizi[x, y]);
                    kutu[x, y].BorderStyle = BorderStyle.FixedSingle;

                    label1.Text += Convert.ToString(dizi[x, y]) + "  ";

                }
                label1.Text += "\n";
            }
        }
    }
}
