using System;
using System.Windows.Forms;

namespace NotatnikMechanika.WinForms
{
    public partial class FormPrzywitanie : Form
    {
        public FormPrzywitanie()
        {
            InitializeComponent();
        }

        private void BTzatwierdz_Click(object sender, EventArgs e)
        {
            //SKGL.SerialKeyConfiguration skc = new SKGL.SerialKeyConfiguration();

            //SKGL.Validate valid = new SKGL.Validate(skc);

            //valid.Key = TBklucz.Text;


            //           if(valid.IsValid)
            //            {
            Lnieprawidłowy.Visible = false;
            Visible = false;
            Program.formFirstSettings.ShowDialog();
            Close();
            //           }
            //else
            //{
            //    Lnieprawidłowy.Visible = true;
            //}
        }

        private void BTklucz_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://notatnikmechanika.cba.pl/Klucz.html");
            Lnieprawidłowy.Visible = false;
        }

        private void BTdemo_Click(object sender, EventArgs e)
        {
            Lnieprawidłowy.Visible = false;
            Program.dataMenager.firstOpenSettings.firstOpen = false;
            Program.dataMenager.firstOpenSettings.demo = true;
            MessageBox.Show("Konfiguracja zakończona, uruchom program ponownie",
                    "Notatnik mechanika",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


            Application.Exit();

        }
    }
}
