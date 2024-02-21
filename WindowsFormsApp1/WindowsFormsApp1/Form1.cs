using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        string dosyayolu;
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = null;
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.ShowDialog();

            pictureBox1.Image = Image.FromFile(dosya.FileName);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            dosyayolu = dosya.FileName;
        }
       
        veritabanibaglan DbYebaglan = new veritabanibaglan();
        MusteriClass verileriaktar = new MusteriClass();
        private void button2_Click(object sender, EventArgs e)
        {

            verileriaktar.TcNo = textBox1.Text;
            verileriaktar.İsim = textBox2.Text;
            verileriaktar.Soyisim = textBox3.Text;
            verileriaktar.DoguymTarihi = Convert.ToDateTime(dateTimePicker1.Value);
            verileriaktar.Meslek = textBox4.Text;
            verileriaktar.CepTelefonu = textBox5.Text;
            verileriaktar.Ev_İsTel = textBox6.Text;
            verileriaktar.Email = textBox7.Text;
            verileriaktar.Adres = richTextBox1.Text;
            verileriaktar.EhliyetNo = Convert.ToInt32(textBox8.Text);
            verileriaktar.EhliyetTuru = textBox9.Text;
            verileriaktar.Notlar = richTextBox2.Text;
            verileriaktar.DosyaYolu = dosyayolu;
            
            DbYebaglan.musteris.Add(verileriaktar);
            DbYebaglan.SaveChanges();
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            string tcbul = textBox13.Text;
            var verileriaktarr = (from i in DbYebaglan.musteris where i.TcNo == tcbul select i).FirstOrDefault();

            textBox1.Text = verileriaktarr.TcNo;
            textBox2.Text = verileriaktarr.İsim;
            textBox3.Text = verileriaktarr.Soyisim;
            dateTimePicker1.Value = verileriaktarr.DoguymTarihi;
            textBox4.Text = verileriaktarr.Meslek;
            textBox5.Text = verileriaktarr.CepTelefonu;
            textBox6.Text = verileriaktarr.Ev_İsTel;
            textBox7.Text = verileriaktarr.Email;
            richTextBox1.Text = verileriaktarr.Adres;
            textBox8.Text = verileriaktarr.EhliyetNo.ToString();
            textBox9.Text = verileriaktarr.EhliyetTuru;
            richTextBox2.Text = verileriaktarr.Notlar;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tcbul = textBox13.Text;
            var guncellenecekler = (from i in DbYebaglan.musteris where i.TcNo == tcbul select i).FirstOrDefault();

            guncellenecekler.TcNo = textBox1.Text;
            guncellenecekler.İsim = textBox2.Text;
            guncellenecekler.Soyisim = textBox3.Text;
            guncellenecekler.DoguymTarihi = dateTimePicker1.Value;
            guncellenecekler.Meslek = textBox4.Text;
            guncellenecekler.CepTelefonu = textBox5.Text;
            guncellenecekler.Ev_İsTel = textBox6.Text;
            guncellenecekler.Email = textBox7.Text;
            guncellenecekler.Adres = richTextBox1.Text;
            guncellenecekler.EhliyetNo = Convert.ToInt32(textBox8.Text);
            guncellenecekler.EhliyetTuru = textBox9.Text;
            guncellenecekler.Notlar = richTextBox2.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string tcbul = textBox13.Text;
            var silinecekKisi = from i in DbYebaglan.musteris where i.TcNo == tcbul select i.id;
            var sil = DbYebaglan.musteris.Find(silinecekKisi);
            DbYebaglan.musteris.Remove(sil);
            DbYebaglan.SaveChanges();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var tumveriler = DbYebaglan.musteris.ToList();
            dataGridView1.DataSource = tumveriler.ToList();
        }
       
        private void button7_Click(object sender, EventArgs e)
        {
            string tcbul = textBox10.Text;
            var bulunantc = (from i in DbYebaglan.musteris where i.TcNo == tcbul select i);
            dataGridView1.DataSource = bulunantc.ToList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string isimbul = textBox11.Text;
            var bulunanisim = from i in DbYebaglan.musteris where i.İsim == isimbul select i;
            dataGridView1.DataSource = bulunanisim.ToList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string mailbul = textBox12.Text;
            var bulunanMail = from i in DbYebaglan.musteris where i.Email == mailbul select i;
            dataGridView1.DataSource = bulunanMail.ToList();
        }
    }
}
