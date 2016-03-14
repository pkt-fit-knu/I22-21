using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Npgsql;
using Emgu.CV.UI;

namespace Bilinear_interpolation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Image<Gray, Byte> imgProcessed;
            string src = @"Bilinear_interpolation.png";
            Image<Bgr, Byte> newimgOriginal;

            newimgOriginal = new Image<Bgr, byte>((Bitmap)Bitmap.FromFile(src));

            imgProcessed = newimgOriginal.InRange(new Bgr(0, 0, 0), new Bgr(100, 100, 100));

            //newimgOriginal[1, 1] = newimgOriginal[1, 1];// newimgOriginal[]

            int k = 3;

            Image<Bgr, Byte> zoom_img = new Image<Bgr, byte>(imgProcessed.Width * k, imgProcessed.Height * k);

            for (int i = 0; i < imgProcessed.Height * k; i++)
            {
                for (int j = 0; j < imgProcessed.Width * k; j++)
                {
                    if (i % k == 0)//i
                    {
                        if (j % k == 0)//j
                        {
                            zoom_img[i, j] = newimgOriginal[i / k, j / k];
                        }
                        else// j%k+1
                        {
                            Bgr color_l = newimgOriginal[i / k, j / k];
                            Bgr color_r;
                            if ((j / k) + 1 < newimgOriginal.Width)
                                color_r = newimgOriginal[i / k, (j / k)+1];
                            else
                                color_r = color_l;
                            Bgr bgr = new Bgr((color_l.Blue + color_r.Blue) / 2, (color_l.Green + color_r.Green) / 2, (color_l.Red + color_r.Red) / 2);
                            zoom_img[i, j] = bgr;
                        }
                    }
                    else //i
                    {
                        if (j % k == 0)//j
                        {
                            Bgr color_l = newimgOriginal[i / k, j / k];
                            Bgr color_r;
                            if ((i / k) + 1 < newimgOriginal.Height)
                                color_r = newimgOriginal[Convert.ToInt32((i / k) + 1), j / k];
                            else
                                color_r = color_l;
                            Bgr bgr = new Bgr((color_l.Blue + color_r.Blue) / 2, (color_l.Green + color_r.Green) / 2, (color_l.Red + color_r.Red) / 2);
                            zoom_img[i, j] = bgr;
                        }
                        else //j
                        {
                            Bgr color_l_t = newimgOriginal[i / k, j / k];
                            Bgr color_r_t;
                            if ((i / k) + 1 < newimgOriginal.Height)
                                color_r_t = newimgOriginal[(i / k) + 1, j / k];
                            else
                                color_r_t = color_l_t;
                            Bgr bgr_top = new Bgr((color_l_t.Blue + color_r_t.Blue) / 2, (color_l_t.Green + color_r_t.Green) / 2, (color_l_t.Red + color_r_t.Red) / 2);

                            Bgr bgr_bottom;
                            if ((j / k) + 1 < newimgOriginal.Width)
                            {
                                Bgr color_l_b = newimgOriginal[i / k, (j / k) + 1];
                                Bgr color_r_b;
                                if ((i / k) + 1 < newimgOriginal.Height)
                                    color_r_b = newimgOriginal[(i / k) + 1, (j / k) + 1];
                                else
                                    color_r_b = color_l_b;
                                bgr_bottom = new Bgr((color_l_b.Blue + color_r_b.Blue) / 2, (color_l_b.Green + color_r_b.Green) / 2, (color_l_b.Red + color_r_b.Red) / 2);
                            }
                            else
                                bgr_bottom = bgr_top;

                            Bgr bgr = new Bgr((bgr_top.Blue + bgr_bottom.Blue) / 2, (bgr_top.Green + bgr_bottom.Green) / 2, (bgr_top.Red + bgr_bottom.Red) / 2);

                            zoom_img[i, j] = bgr;
                        }
                    }
                }
            }
            // imgProcessed = matrix_new.ToImage;
            // CvInvoke.ma
            //Image<Bgr, Byte> img = matrix_new.QueryFrame().ToImage<Bgr, Byte>();


            new_img_box.Image = newimgOriginal;
            this.zoom_img_block.Image = zoom_img;





        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}
