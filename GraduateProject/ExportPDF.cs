using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp;
using System.Timers;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms;


namespace GraduateProject
{
    class ExportPDF
    {

        public void pdf(DataGridView dataview)
        {

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "PDF(*.pdf)|*.pdf";
            string filename = DateTime.Now.ToString("yyyyMMddhhmmss");
            savefile.FileName = filename;
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BaseFont bf = BaseFont.CreateFont("C:\\Windows\\Fonts\\simhei.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    PdfPTable pdf = new PdfPTable(dataview.Columns.Count);
                    pdf.DefaultCell.Padding = 3;
                    pdf.WidthPercentage = 100;
                    pdf.HorizontalAlignment = Element.ALIGN_LEFT;
                    iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.NORMAL);
                    foreach (DataGridViewColumn column in dataview.Columns)
                    {
                        PdfPCell _pdfcell = new PdfPCell(new Phrase(column.HeaderText, text));
                        pdf.AddCell(_pdfcell);
                    }

                    foreach (DataGridViewRow rows in dataview.Rows)
                        foreach (DataGridViewCell cells in rows.Cells)
                        {
                            pdf.AddCell(new Phrase(cells.Value.ToString(), text));
                        }
                    using (FileStream _filestream = new FileStream(savefile.FileName, FileMode.Create))
                    {
                        Document newpdf = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                        PdfWriter.GetInstance(newpdf, _filestream);
                        newpdf.Open();
                        newpdf.Add(pdf);
                        newpdf.Close();
                        _filestream.Close();
                    }
                    MessageBox.Show("导出成功！", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error :" + ex.Message);
                }
            }

        }
         
    }
}


