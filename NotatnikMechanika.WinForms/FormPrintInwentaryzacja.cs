using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace NotatnikMechanika.WinForms
{
    public partial class FormPrintInwentaryzacja : Form
    {
        private readonly PrintDocument pd;
        private int pageNumber = 0;

        public FormPrintInwentaryzacja()
        {
            InitializeComponent();

            pd = new PrintDocument();

            pd.PrintPage += new PrintPageEventHandler(PrintDocument1_PrintPage);

            DGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            DGV.RowsDefaultCellStyle.SelectionBackColor = Color.White;
            DGV.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void FormPrintInwentaryzacja_Shown(object sender, EventArgs e)
        {
            LadujDane();
        }

        private void LadujDane()
        {

            Ldata.Text = "Data sporządzenia wydruku: " + DateTime.Now.ToShortDateString();

            DGV.Rows.Clear();

            PrintControl();

            Close();
        }

        public void PrintControl()
        {
            // pd.Print();
            printPreviewDialog1.Document = pd;
            printPreviewDialog1.ShowDialog();
        }


        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            for (int i = 0 + 45 * pageNumber; i < 45 + 45 * pageNumber; i++)
            {
                if (i < Program.dataMenager.towary.Count)
                {
                    Towar towar = Program.dataMenager.towary[i];
                    DGV.Rows.Add((i + 1).ToString(), towar.nazwa, towar.symbol, towar.cena, towar.ilosc);

                    if (i + 1 < Program.dataMenager.towary.Count)
                    {
                        e.HasMorePages = true;
                    }

                    else
                    {
                        e.HasMorePages = false;
                    }
                }

                else
                {
                    e.HasMorePages = false;

                    pageNumber = -1;

                    break;
                }
            }

            pageNumber++;


            Bitmap bitmap = new Bitmap(panel1.Width, panel1.Height);

            panel1.DrawToBitmap(bitmap, new Rectangle(0, 0, panel1.Width, panel1.Height));

            e.Graphics.DrawImage(bitmap, 0, 0);

            DGV.Rows.Clear();
        }
    }
}