using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_3_19_DYCHKOVI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        abstract public class Accessories<T>
        {
            public T vendor { get; set; }
            public int year;
            public int price;
            public Accessories(T Vendor, int Year, int Price)
            {
                vendor = Vendor;
                year = Year;
                price = Price;
            }
            public abstract void Display(ListBox lb1);
        }
        class CentProc<T> : Accessories<T>
        {
            private int Freak { get; set; }
            private int Kernels { get; set; }
            private int Threads { get; set; }
            public CentProc(int freak, int kernels, int threads, T Vendor, int Year, int Price) : base(Vendor, Year, Price) { Freak = freak; Kernels = kernels; Threads = threads; }
            public override void Display(ListBox lb1)
            {
                lb1.Items.Add("#################################");
                lb1.Items.Add($"Артикул: {vendor}");
                lb1.Items.Add($"Цена: {price}");
                lb1.Items.Add($"Год: {year}");
                lb1.Items.Add($"Частота: {Freak}");
                lb1.Items.Add($"Количество ядер: {Kernels}");
                lb1.Items.Add($"Количество потоков: {Threads}");
                lb1.Items.Add("#################################");
            }
        }
        class VideoCard<T> : Accessories<T>
        {
            private int GPU { get; set; }
            private string Developer { get; set; }
            private int Memory { get; set; }
            public VideoCard(int gpu, string developer, int memory, T Vendor, int Year, int Price) : base(Vendor, Year, Price) { GPU = gpu; Developer = developer; Memory = memory; }
            public override void Display(ListBox lb1)
            {
                lb1.Items.Add("#################################");
                lb1.Items.Add($"Артикул: {vendor}");
                lb1.Items.Add($"Цена: {price}");
                lb1.Items.Add($"Год: {year}");
                lb1.Items.Add($"GPU частота: {GPU}");
                lb1.Items.Add($"Производитель: {Developer}");
                lb1.Items.Add($"Память: {Memory}");
                lb1.Items.Add("#################################");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string vend = Convert.ToString(textBox9.Text);
            int yer = Convert.ToInt32(textBox1.Text);
            int pric = Convert.ToInt32(textBox2.Text);
            int freaq = Convert.ToInt32(textBox3.Text);
            int core = Convert.ToInt32(textBox4.Text);
            int thread = Convert.ToInt32(textBox5.Text); 
            CentProc<string> CP = new CentProc<string>(Convert.ToInt32(yer), Convert.ToInt32(pric), Convert.ToInt32(freaq), Convert.ToString(vend), Convert.ToInt32(core), Convert.ToInt32(thread));
            CP.Display(listBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string vend = Convert.ToString(textBox9.Text);
            int yer = Convert.ToInt32(textBox1.Text);
            int pric = Convert.ToInt32(textBox2.Text);
            int gpu2 = Convert.ToInt32(textBox6.Text);
            string dev = Convert.ToString(textBox7.Text);
            int memo = Convert.ToInt32(textBox8.Text);
            VideoCard<string> VC = new VideoCard<string>(Convert.ToInt32(gpu2), Convert.ToString(dev), Convert.ToInt32(memo), Convert.ToString(vend), Convert.ToInt32(yer), Convert.ToInt32(pric));
            VC.Display(listBox1);
        }
    }
}
