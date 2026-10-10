using System;
using System.Windows.Forms;

namespace Random_Number
{
    public partial class Form1 : Form
    {
        int num = 0;         
        int cehdSayi = 0;    

        ErrorProvider errorProvider1 = new ErrorProvider();

        public Form1()
        {
            InitializeComponent();


            button1.Click += new EventHandler(button1_Click);
            button2.Click += new EventHandler(yenioyunbtn_Click);
            this.Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            textBox1.Enabled = false;
        }

        private void yenioyunbtn_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            num = r.Next(1, 100); 

            button1.Enabled = true;
            textBox1.Enabled = true;


            cehdSayi = 0;
            textBox1.Clear();
            richTextBox1.Clear(); 
            errorProvider1.Clear();
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Axtarılan ədəd xanası boş ola bilməz!");
                return;
            }

            int daxilEdilen;
            if (!int.TryParse(textBox1.Text, out daxilEdilen))
            {
                errorProvider1.SetError(textBox1, "Zəhmət olmasa yalnız ədəd daxil edin!");
                return;
            }

            cehdSayi++;

            if (daxilEdilen == num)
            {
                richTextBox1.AppendText("Oyunu qazandınız\n");
                richTextBox1.AppendText($"Cəhd sayı: {cehdSayi}\n");

                button1.Enabled = false;
                textBox1.Enabled = false;
            }
            else
            {
                richTextBox1.AppendText("Daxil edilən ədəd yanlışdır\n");

                if (daxilEdilen < num)
                {
                    richTextBox1.AppendText("Təsadüfi ədəddən kiçikdir\n");
                }
                else
                {
                    richTextBox1.AppendText("Təsadüfi ədəddən böyükdür\n");
                }

                richTextBox1.AppendText($"Cəhd sayı: {cehdSayi}\n\n");

                textBox1.Clear();
                textBox1.Focus();
            }
        }
    }
}