using System.Windows.Forms;

namespace NotatnikMechanika.WinForms
{
    internal class CTBtowar
    {
        public TextBox TBtowar;
        public TextBox TBtowarCena;

        public void Init()
        {
            TBtowar = new TextBox();
            TBtowarCena = new TextBox();
        }
        public CTBtowar SetParams(TextBox TBtowar, TextBox TBtowarCena)
        {
            this.TBtowar = TBtowar;
            this.TBtowarCena = TBtowarCena;

            return this;
        }
    }
}