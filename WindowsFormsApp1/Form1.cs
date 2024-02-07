using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            if (dosya.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(dosya.FileName);

                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        List<MusteriClass> musteriler = new List<MusteriClass>();
        private void button2_Click(object sender, EventArgs e)
        {
            musteriler.Add(new MusteriClass
            {
                Tc_No = textBox1.Text,
                İsim = textBox2.Text,
                Soyisim = textBox3.Text,
                Tarih = dateTimePicker1.Value,
                Meslek = textBox4.Text,
                Cep_No = textBox5.Text,
                Tel_No = textBox6.Text,
                Mail = textBox7.Text,
                Adres = richTextBox1.Text,
                Ehliyet_No = textBox8.Text,
                Ehliyet_Turu = textBox9.Text,
                Notlar = richTextBox2.Text
            });
            dataGridView1.DataSource = musteriler.ToList();
        }
        MusteriClass verileriaktar = new MusteriClass();
        private void button3_Click(object sender, EventArgs e)
        {
            string tcbul = textBox13.Text;
            verileriaktar = (from i in musteriler where i.Tc_No == tcbul select i).FirstOrDefault();

            textBox1.Text = verileriaktar.Tc_No;
            textBox2.Text = verileriaktar.İsim;
            textBox3.Text = verileriaktar.Soyisim;
            dateTimePicker1.Value = verileriaktar.Tarih;
            textBox4.Text = verileriaktar.Meslek;
            textBox5.Text = verileriaktar.Cep_No;
            textBox6.Text = verileriaktar.Tel_No;
            textBox7.Text = verileriaktar.Mail;
            richTextBox1.Text = verileriaktar.Adres;
            textBox8.Text = verileriaktar.Ehliyet_No;
            textBox9.Text = verileriaktar.Ehliyet_Turu;
            richTextBox2.Text = verileriaktar.Notlar;
        }
    }
}
