using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikacja
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        private int loginProgress;

        public bool Sukces { get; set; }
        public char Rola { get; set; }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione.", "Błąd logowania", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            button1.Enabled = false;
            button2.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            comboBox1.Enabled = false;

            loginProgress = 0;
            timer1.Start();

            Rola = comboBox1.SelectedItem.ToString()[0];
            Sukces = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(loginProgress == 0)
            {
                progressBar1.Enabled = true;
                label4.Text = "Nawiazywanie połączenia...";
            }
            else if(loginProgress == 2)
            {
                label4.Text = "Weryfikacja danych...";
            }
            else if(loginProgress == 3)
            {
                if(textBox1.Text != "1234" || textBox2.Text != "1234")
                {
                    ResetFormState();
                    MessageBox.Show("Dane logowania nie są poprawne.", "Logowanie nieudane");
                    return;
                }
            }
            else if (loginProgress == 4)
            {
                ResetFormState();
                Sukces = true;
                Rola = comboBox1.SelectedItem.ToString()[0];
                Close();
                return;
            }


            loginProgress++;

        }

        private void ResetFormState()
        {
            timer1.Stop();
            button1.Enabled = true;
            button2.Enabled = true;
            textBox1.Enabled =  true;
            textBox2.Enabled =  true;
            comboBox1.Enabled = true;
            progressBar1.Enabled = true;
            label4.Text = "Gotowy.";
            textBox1.Text = "";
            textBox2.Text = "";
            loginProgress = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
