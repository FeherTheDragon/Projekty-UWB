using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zajecia3a
{
    public partial class Form1 : Form
    {
        private int width = 0;
        private int height = 0;
        private int poziomJasnCiem = 0;
        private int poziomProg1 = 0;
        private int poziomProg2 = 0;

        public Form1()
        {
            InitializeComponent();
        }

// *****************************
// * Przycisk do odczytu pliku *
// *****************************

        private void buttonOdczyt_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);

                width = pictureBox1.Image.Width;
                height = pictureBox1.Image.Height;

                pictureBox2.Image = new Bitmap(width, height);

                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                //button7 to exit
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
            }
        }

// ******************************************************
// * Przycisk do zamiany koloru czerwonego z niebieskim *
// ******************************************************

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image; //Alias bitmapy
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k;
            int r, g, b;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    k = b1.GetPixel(x, y);
                    r = k.R;
                    g = k.G;
                    b = k.B;

                    k = Color.FromArgb(b, g, r);

                    b2.SetPixel(x, y, k);
                }
            }

            pictureBox2.Refresh();
        }

// ******************************************************
// * Przycisk do zamiany koloru niebieskiego z zielonym *
// ******************************************************

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k;
            int r, g, b;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    k = b1.GetPixel(x, y);
                    r = k.R;
                    g = k.G;
                    b = k.B;

                    k = Color.FromArgb(r, b, g);

                    b2.SetPixel(x, y, k);
                }
            }

            pictureBox2.Refresh();
        }

// ****************************************************
// * Przycisk do zamiany koloru czerwonego z zielonym *
// ****************************************************

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k;
            int r, g, b;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    k = b1.GetPixel(x, y);
                    r = k.R;
                    g = k.G;
                    b = k.B;

                    k = Color.FromArgb(g, r, b);

                    b2.SetPixel(x, y, k);
                }
            }

            pictureBox2.Refresh();
        }

// ****************************************
// * Przycisk do zamiany obrazów stronami *
// ****************************************

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = pictureBox2.Image;
        }

// ***********************************
// * Przycisk do stworzenia negatywu *
// ***********************************

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k;
            int r, g, b;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    k = b1.GetPixel(x, y);
                    r = 255 - k.R;
                    g = 255 - k.G;
                    b = 255 - k.B;

                    k = Color.FromArgb(r, g, b);

                    b2.SetPixel(x, y, k);
                }
            }

            pictureBox2.Refresh();
        }

// ****************************************************************
// * Suwak do ustawienia wartości dla Rozjaśnienia/Przyciemnienia *
// ****************************************************************

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            poziomJasnCiem = trackBar1.Value;
        }
        
// ******************************************************
// * Przycisk do ustawienia Rozjaśnienia/Przyciemnienia *
// ******************************************************

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k;
            int r, g, b;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    k = b1.GetPixel(x, y);

                    if (poziomJasnCiem + k.R > 255) r = 255;
                    else if (poziomJasnCiem + k.R < 0) r = 0;
                    else r = poziomJasnCiem + k.R;

                    if (poziomJasnCiem + k.G > 255) g = 255;
                    else if (poziomJasnCiem + k.G < 0) g = 0;
                    else g = poziomJasnCiem + k.G;

                    if (poziomJasnCiem + k.B > 255) b = 255;
                    else if (poziomJasnCiem + k.B < 0) b = 0;
                    else b = poziomJasnCiem + k.B;
                    
                    k = Color.FromArgb(r, g, b);

                    b2.SetPixel(x, y, k);
                }
            }

            pictureBox2.Refresh();
        }
        
// ***********************************
// * Przycisk do wyłączenia programu *
// ***********************************

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
// *********************************************************************
// * Przycisk do ustawienia Monochomatyzacji stosując śr. arytmetyczną *
// *********************************************************************

        private void button8_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    k = b1.GetPixel(x, y);

                    int a = (k.R + k.G + k.B) / 3;

                    k = Color.FromArgb(a, a, a);

                    b2.SetPixel(x, y, k);
                }
            }

            pictureBox2.Refresh();
        }

// *************************************
// * Przycisk do stworzenia Progowania *
// *************************************

        private void button9_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    k = b1.GetPixel(x, y);

                    int a = (k.R + k.G + k.B) / 3;
                    if (a < poziomProg1) k = Color.Black;
                    else if (a < poziomProg2) k = Color.Gray;
                    else k = Color.White;

                    b2.SetPixel(x, y, k);
                }
            }

            pictureBox2.Refresh();
        }

// ***************************************
// * Suwak dolnej wartości programowania *
// ***************************************

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            poziomProg1 = trackBar2.Value;
        }

// ***************************************************************
// * Przycisk do ustawienia Monochomatyzacji stosując śr. ważoną *
// ***************************************************************

        private void button10_Click(object sender, EventArgs e)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            Color k;
            double a;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    k = b1.GetPixel(x, y);

                    //Wzor wykorzystywany w modelu YUV
                    a = 0.299 * k.R + 0.587 * k.G + 0.114 * k.B;

                    k = Color.FromArgb((int)a, (int)a, (int)a);

                    b2.SetPixel(x, y, k);
                }
            }

            pictureBox2.Refresh();
        }

// ***************************************
// * Suwak górnej wartości programowania *
// ***************************************

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            poziomProg2 = trackBar3.Value;
        }


    }
}