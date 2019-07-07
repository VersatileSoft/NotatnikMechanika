using System;
using System.Windows.Forms;

namespace NotatnikMechanika.WinForms
{
    public partial class FormHasloBaza : Form
    {
        public FormHasloBaza()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string password = textBox1.Text;

            if (password == Program.dataMenager.firstOpenSettings.password)
            {
                Close();
                Program.form1.Visible = true;
                Program.hasloOk = true;
            }
            else
            {
                MessageBox.Show("Hasło niepoprawne",
                "Notatnik mechanika",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                Program.hasloOk = false;

            }
        }

        private void BTzapomniałem_Click(object sender, EventArgs e)
        {
            Height = 240;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                  "Uwaga! Przywracając ustawienia fabryczne stracisz wszystkie dane. Czy napewno chcesz to zrobić?",
                  "Ustawienia fabryczne",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Warning
                  ) == DialogResult.Yes)
            {
                Program.UstawieniaFabryczne();
            }
        }
    }
}