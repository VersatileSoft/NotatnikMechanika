using System.Windows.Forms;

namespace NotatnikMechanika.WinForms
{
    internal class CTBusluga
    {
        public TextBox TBusluga;
        public TextBox TBuslugaCena;

        public void Init()
        {
            TBusluga = new TextBox();
            TBuslugaCena = new TextBox();
        }

        public CTBusluga SetParams(TextBox TBusluga, TextBox TBuslugaCena)
        {
            this.TBusluga = TBusluga;
            this.TBuslugaCena = TBuslugaCena;

            return this;
        }
    }
}