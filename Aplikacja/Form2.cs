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
    public partial class Form2 : Form
    {
        private Form1 form;

        public Form2(Form1 form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(progressBar1.Value < 11)
            {
                progressBar1.Value++;
                Text = $"Wczytywanie danych... ({(progressBar1.Value/(double)progressBar1.Maximum*100d):0}%)";
            }
            else
            {
                form.flaga = true;
                Close();
            }
        }
    }
}
