using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FuzzyDicee
{
    public partial class Ininio : Form
    {
        Random rand = new Random();
        int totalPrice = 0;
        int totalD = 0;
        bool campFill = false;
        public Ininio()
        {
            InitializeComponent();
            order.Text = rand.Next(1, int.MaxValue).ToString();
        }
        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Ininio_Load(object sender, EventArgs e)
        {
            
        }
        private void label4_Click(object sender, EventArgs e)
        {
            label6.Enabled = false;
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void label12_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            campFill = (solicitudDireccion.Text != "" && solicitudNombre.Text != "");
            if (!campFill)
            {
                num1.Enabled = false;
                num2.Enabled = false;
                num3.Enabled = false;
            }
        }

        private void num1_TextChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            foreach (char character in box.Text.ToCharArray())
            {
                ep.Clear();

                if (Char.IsDigit(character))
                {
                    switch (box.Name)
                    {
                        case "num1": totalPrice += int.Parse(box.Text) * 6; totalD += int.Parse(box.Text); textBox8.Text = (int.Parse(box.Text) * 6).ToString("C"); break;
                        case "num2": totalPrice += int.Parse(box.Text) * 5; totalD += int.Parse(box.Text); textBox9.Text = (int.Parse(box.Text) * 5).ToString("C"); break;
                        case "num3": totalPrice += int.Parse(box.Text) * 8; totalD += int.Parse(box.Text); textBox10.Text = (int.Parse(box.Text) * 8).ToString("C"); break;
                        default:
                            break;
                    }

                    
                    textBox11.Text = totalPrice.ToString("C");
                }
                else
                {
                    ep.SetError(box, "solo valores numericos.");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (campFill)
            {
                num1.Enabled = check1.Checked;
                num2.Enabled = check2.Checked;
                num3.Enabled = check3.Checked;
            }
        }
        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            totalPrice *= 5;
            if (totalD < 20)
            {
                totalPrice += 2;
            }
            if (totalPrice > 500)
            {
                totalPrice = (totalPrice * 7) / 100;
                MessageBox.Show("Tienes un 7% de descuento.", "Descuento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            textBox3.Text = totalPrice.ToString("C");
        }

        //Pinta fondos
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                       Color.Purple,
                                                                       Color.Red,
                                                                       90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }   
        }
    }
}
