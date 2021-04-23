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
    public partial class Form1 : Form
    {
        public bool flaga;

        public Form1()
        {
            var login = new LogInForm();
            login.ShowDialog();

            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == pobierzDaneMenuItem)
            {
                Form2 f = new Form2(this);
                f.ShowDialog();
                if (flaga)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    listView1.Items.Clear();
                    foreach (var item in Osoba.Osoby)
                        listView1.Items.Add((ListViewItem)item);
                    Cursor.Current = Cursors.Default;
                    toolStripMenuItem2.Enabled = true;
                }
            }
            else if (e.ClickedItem == toolStripMenuItem2)
            {
                if(MessageBox.Show("Czy na pewno chcesz usunąć wszystkie elementy?", "Wyczyść dane", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    listView1.Items.Clear();
            }
            else if (e.ClickedItem == czcionkaMenuItem)
            {
                if (fontDialog1.ShowDialog() == DialogResult.OK)
                    listView1.Font = fontDialog1.Font;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripMenuItem2.Enabled = false;
            RegisterStatusStripNotificationForMenuItem(pobierzDaneMenuItem, "Pobierz użytkowników z bazy danych");
            RegisterStatusStripNotificationForMenuItem(toolStripMenuItem2, "Wyczyść listę użytkowników");
            RegisterStatusStripNotificationForMenuItem(toolStripMenuItem3, "Zmień ustawienia aplikacji");
            RegisterStatusStripNotificationForMenuItem(czcionkaMenuItem, "Ustaw czcionkę dla listy osób");
        }

        private void RegisterStatusStripNotificationForMenuItem(ToolStripMenuItem item, string message)
        {
            item.MouseEnter += (o, ea) =>
            {
                toolStripStatusLabel1.Text = message;
            };
            item.MouseLeave += (o, ea) =>
            {
                toolStripStatusLabel1.Text = "";
            };
        }
    }
}
