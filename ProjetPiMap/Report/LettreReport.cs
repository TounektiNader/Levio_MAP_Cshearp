using Domain.Entities;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ProjetPiMap.Report
{
    public class LettreReport
    {
        int _columnTotal = 4;
        Document _document;
        Font _fontStyle;
        PdfPTable _pdfTable = new PdfPTable(1);
        PdfPTable table1 = new PdfPTable(1);
        PdfPTable table2 = new PdfPTable(1);
        PdfPTable _table3 = new PdfPTable(4);
        PdfPCell _pdfCell;
        List<Test> testss;
        MemoryStream _memoryStream = new MemoryStream();
        
        List<Test> _listsTest = new List<Test>();

        Paragraph paragraph = new Paragraph("Getting Started ITextSharp.");
       public  byte[] PrepareReport(List<Test> tests)
        {
            testss = tests  ;
            
            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
           //_pdfTable.SetWidths(new float[] { 20f, 150f, 100f });


            this.ReportHeader();
            this.ReportBody();
           _pdfTable.HeaderRows = 2;
            _document.Add(_pdfTable);
            _document.Add(table2);
            _document.Add(_table3);
            _document.Close();
            return _memoryStream.ToArray();

        }
        
        private void ReportHeader()
        {
            BaseFont arial = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.EMBEDDED);
            iTextSharp.text.Font f_15_bold = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font f_12_normal = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.NORMAL);


            //Image img = Image.GetInstance("C:/Users/Nader/Desktop/pg.jpg");
            //img.ScaleAbsoluteHeight(92);
            //img.ScaleAbsoluteWidth(600);
            //img.SetAbsolutePosition(10,10);
            //_document.Add(img);
            //_document.Add(new Paragraph("   "));
            float[] width = new float[] { 40f, 60f };


            PdfPCell c1 = new PdfPCell(new Phrase("Levio", f_15_bold));
            PdfPCell c2 = new PdfPCell(new Phrase("Consulting Frim", f_15_bold));
            PdfPCell c3 = new PdfPCell(new Phrase("Mail: info @levio.ca", f_15_bold));
            PdfPCell c4 = new PdfPCell(new Phrase("Adress : Québec (Québec) G1W 0C4", f_12_normal));
        

            c1.Border = Rectangle.NO_BORDER;
            c2.Border = Rectangle.NO_BORDER;
            c3.Border = Rectangle.NO_BORDER;
            c4.Border = Rectangle.NO_BORDER;

            c1.HorizontalAlignment = Element.ALIGN_CENTER;
            c2.HorizontalAlignment = Element.ALIGN_CENTER;
            c3.HorizontalAlignment = Element.ALIGN_CENTER;
            c4.HorizontalAlignment = Element.ALIGN_JUSTIFIED;

            _pdfTable.WidthPercentage = 40;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfTable.AddCell(c1);
            _pdfTable.AddCell(c2);
            _pdfTable.AddCell(c3);
            _pdfTable.AddCell(c4);


            _pdfTable.SpacingAfter = 20;
            _pdfTable.SpacingBefore = 50;



            //Client 


            c1 = new PdfPCell(new Phrase("\nNom Cllientn:", f_15_bold));
            c2 = new PdfPCell(new Phrase("\n Prenom :", f_15_bold));
            c3 = new PdfPCell(new Phrase("\n Adresse ", f_15_bold));
            c4 = new PdfPCell(new Phrase("\n Date : "+DateTime.Now, f_15_bold));

            

            c1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            c2.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            c3.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            c4.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            


            c1.Border = Rectangle.NO_BORDER;
            c2.Border = Rectangle.NO_BORDER;
            c3.Border = Rectangle.NO_BORDER;
            c4.Border = Rectangle.NO_BORDER;

            
            table1.AddCell(c1);
            table1.AddCell(c2);
            table1.AddCell(c3);
            table1.AddCell(c4);

            table1.SpacingAfter=20;
            table1.SpacingBefore = 10;
            
            table2.AddCell(table1);
            table2.HorizontalAlignment = Element.ALIGN_RIGHT;
            table2.WidthPercentage = 40;

            //date

            //Paragraph paragraph = new Paragraph(new Phrase("Starr lowel "+"\n", f_12_normal));
            // paragraph.Add (new Phrase("STar theniii ", f_12_normal));
            //paragraph.Alignment = Element.ALIGN_JUSTIFIED;
            //_document.Add(paragraph);


            //_document.Add(new Phrase("Lettre Embacueh", FontFactory.GetFont("Arial", 20, Font.BOLDITALIC)));

            //_fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            //_pdfCell = new PdfPCell(new Phrase("Lettre D'embauche",_fontStyle));
            //_pdfCell.Colspan = _totalColumn;
            //_pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //_pdfCell.Border = 0;
            //_pdfCell.BackgroundColor = BaseColor.WHITE;
            //_pdfCell.ExtraParagraphSpace = 0;
            //_pdfTable.AddCell(_pdfCell);
            //_pdfTable.CompleteRow();



        }
        private void ReportBody()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfCell = new PdfPCell(new Phrase("Question", _fontStyle));
             
            _pdfCell.HorizontalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;

            _pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table3.AddCell(_pdfCell);


            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfCell = new PdfPCell(new Phrase("REponse", _fontStyle));

            _pdfCell.HorizontalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;

            _pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table3.AddCell(_pdfCell);



            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfCell = new PdfPCell(new Phrase("Choix1", _fontStyle));

            _pdfCell.HorizontalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;

            _pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table3.AddCell(_pdfCell);


            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfCell = new PdfPCell(new Phrase("Choix2", _fontStyle));

            _pdfCell.HorizontalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;

            _pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _table3.AddCell(_pdfCell);
            _table3.CompleteRow();





            #region  tablebody
            foreach(var item in testss)
            { 
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 0);
            _pdfCell = new PdfPCell(new Phrase(item.question, _fontStyle));

            _pdfCell.HorizontalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;

            _pdfCell.BackgroundColor = BaseColor.WHITE;
                _table3.AddCell(_pdfCell);

                _fontStyle = FontFactory.GetFont(item.reponse, 8f, 0);
                _pdfCell = new PdfPCell(new Phrase(item.question, _fontStyle));

                _pdfCell.HorizontalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                _pdfCell.BackgroundColor = BaseColor.WHITE;
                _table3.AddCell(_pdfCell);


                _fontStyle = FontFactory.GetFont(item.choix1, 8f, 0);
                _pdfCell = new PdfPCell(new Phrase(item.question, _fontStyle));

                _pdfCell.HorizontalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                _pdfCell.BackgroundColor = BaseColor.WHITE;
                _table3.AddCell(_pdfCell);

                _fontStyle = FontFactory.GetFont(item.choix2, 8f, 0);
                _pdfCell = new PdfPCell(new Phrase(item.question, _fontStyle));

                _pdfCell.HorizontalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                _pdfCell.BackgroundColor = BaseColor.WHITE;
                _table3.AddCell(_pdfCell);
                _table3.CompleteRow();
            }
            #endregion




        }
    }
}