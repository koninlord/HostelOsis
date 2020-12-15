using HostelOsis.Models.Data.HostelDBContext;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HostelOsis.Models.Services
{
    public class RoomtypeReportService
    {
        private RoomType _roomType;

        public RoomtypeReportService(RoomType roomType)
        {
            _roomType = roomType;
        }

        int _maxColumn = 2;
        Document _document;
        Font _fontStyle;
        PdfPTable _pdfTable = new PdfPTable(2);
        PdfPCell _pdfCell;
        MemoryStream _memoryStream = new MemoryStream();

        List<RoomType> _roomTypes = new List<RoomType>();
   
        public byte[] Reports(List<RoomType> roomTypes)
        {
            _roomTypes = roomTypes;

            _document = new Document();
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(5f, 5f, 20f, 5f);

            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);

            PdfWriter docWrite = PdfWriter.GetInstance(_document, _memoryStream);

            _document.Open();

            float[] sizes = new float[_maxColumn];
            for (var i = 0; i < _maxColumn; i++)
            {
                if (i == 0) sizes[i] = 20;
                else sizes[i] = 100;
            }

            _pdfTable.SetWidths(sizes);
            this.ReportHeader();
            this.EmptyRow(2);
            this.ReportBody();

            _pdfTable.HeaderRows = 2;
            _document.Add(_pdfTable);

            _document.Close();
            return _memoryStream.ToArray();

        }

        private void ReportHeader()
        {
            _pdfCell = new PdfPCell(this.SetPageTitle());
            _pdfCell.Colspan = _maxColumn - 1;
            _pdfCell.Border = 0;
            _pdfTable.AddCell(_pdfCell);

            _pdfTable.CompleteRow();

        }

        private PdfPTable SetPageTitle()
        {
            int maxColumn = 3;
            PdfPTable pdfPTable = new PdfPTable(maxColumn);

            _fontStyle = FontFactory.GetFont("Tahoma", 18f, 1);
            _pdfCell = new PdfPCell(new Phrase("Room types", _fontStyle));
            _pdfCell.Colspan = maxColumn - 1;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.Border = 0;
            _pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(_pdfCell);
            pdfPTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 14f, 1);
            _pdfCell = new PdfPCell(new Phrase("Room type", _fontStyle));
            _pdfCell.Colspan = maxColumn - 1;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.Border = 0;
            _pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(_pdfCell);
            pdfPTable.CompleteRow();

            return pdfPTable;
        }

        private void EmptyRow(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                _pdfCell = new PdfPCell(new Phrase("", _fontStyle));
                _pdfCell.Colspan = _maxColumn;
                //_pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.Border = 0;
                _pdfCell.ExtraParagraphSpace = 10;
                _pdfTable.AddCell(_pdfCell);
                _pdfTable.CompleteRow();
            }
        }

        private void ReportBody()
        {
            var fontStyleBold = FontFactory.GetFont("Tahoma", 9f, 1);
            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);

            _pdfCell = new PdfPCell(new Phrase("RoomTypeId", fontStyleBold));
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.Gray;
            _pdfTable.AddCell(_pdfCell);


            _pdfCell = new PdfPCell(new Phrase("Type", fontStyleBold));
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.Gray;
            _pdfTable.AddCell(_pdfCell);

            _pdfTable.CompleteRow();

            foreach (var roomType in _roomTypes)
            {
                _pdfCell = new PdfPCell(new Phrase(roomType.RoomTypeId.ToString(), _fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.White;
                _pdfTable.AddCell(_pdfCell);


                _pdfCell = new PdfPCell(new Phrase(roomType.Type.ToString(), _fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.Gray;
                _pdfTable.AddCell(_pdfCell);

            }

        }
    }
}
