using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace IdCardGenerator
{
    class IceFormat : IdCardFormat
    {
        public override void cardFormat(Document doc, List<WaecStudentCard> studentInfo)
        {
            try
            {
                PdfPTable borderTable = new PdfPTable(3);

                PdfPTable cardTable = new PdfPTable(3);
                PdfPTable cardTable2 = new PdfPTable(3);
                Image logo;
                Image passport;
                Image logo2;
                Image passport2;

                float[] width = new float[] { 15.2f, 28f, 25f };
                float[] width2 = new float[] { 50f, 1f, 50f };

                BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, BaseFont.EMBEDDED);
                Font ft = new Font(bf, 16);
                Font ff = new Font(bf, 18, 1, BaseColor.BLUE);

                logo = Image.GetInstance(studentInfo[0].LogoPath);
                logo.WidthPercentage = 30;
                logo.ScalePercent(33);
                PdfPCell logoCell = new PdfPCell(logo);
                logoCell.Rowspan = 2;
                logoCell.HorizontalAlignment = Element.ALIGN_CENTER;
                logoCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cardTable.AddCell(logoCell);

                PdfPCell schoolCell = new PdfPCell(new Phrase(studentInfo[0].CompanyName, ff));
                schoolCell.HorizontalAlignment = Element.ALIGN_CENTER;
                schoolCell.BackgroundColor = BaseColor.ORANGE;
                cardTable.AddCell(schoolCell);

                passport = Image.GetInstance(studentInfo[0].PassportPath);
                passport.WidthPercentage = 30;
                passport.ScalePercent(40);
                PdfPCell passportCell = new PdfPCell(passport);
                passportCell.Rowspan = 6;
                passportCell.HorizontalAlignment = Element.ALIGN_CENTER;
                passportCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cardTable.AddCell(passportCell);

                PdfPCell ExamCell = new PdfPCell(new Phrase(studentInfo[0].ExamDetail, ff));
                ExamCell.HorizontalAlignment = Element.ALIGN_CENTER;
                cardTable.AddCell(ExamCell);

                PdfPCell name = new PdfPCell(new Phrase("Name:", ft));
                cardTable.AddCell(name);
                PdfPCell studentNameCell = new PdfPCell(new Phrase(studentInfo[0].Name, ft));
                //studentNameCell.Colspan = 2;
                cardTable.AddCell(studentNameCell);

                PdfPCell exam = new PdfPCell(new Phrase("Exam No:", ft));
                cardTable.AddCell(exam);
                PdfPCell studentExamNumberCell = new PdfPCell(new Phrase(studentInfo[0].ExamNumber, ft));
                //studentExamNumberCell.Colspan = 2;
                cardTable.AddCell(studentExamNumberCell);

                PdfPCell seat = new PdfPCell(new Phrase("Seat No:", ft));
                cardTable.AddCell(seat);
                PdfPCell studentSeatNumberCell = new PdfPCell(new Phrase(studentInfo[0].SeatNumber, ft));
                //studentSeatNumberCell.Colspan = 2;
                cardTable.AddCell(studentSeatNumberCell);

                PdfPCell gender = new PdfPCell(new Phrase("Gender:", ft));
                cardTable.AddCell(gender);
                PdfPCell genderCell = new PdfPCell(new Phrase(studentInfo[0].Gender, ft));
                //genderCell.Colspan = 2;
                cardTable.AddCell(genderCell);

                /* PdfPCell serialNumber = new PdfPCell(new Phrase("Serial Number:", ft));
                 cardTable.AddCell(serialNumber);
                 PdfPCell serialNumberCell = new PdfPCell(new Phrase(studentInfo[0].SerialNumber, ft));
                 serialNumberCell.Colspan = 2;
                 cardTable.AddCell(serialNumberCell);*/

                PdfPCell subjects21 = new PdfPCell(new Phrase("Subjects:", ft));
                cardTable.AddCell(subjects21);
                string subjects = "";
                foreach (string subject in studentInfo[0].Subject)
                {
                    subjects += subject + ",";
                }
                PdfPCell subjectCell = new PdfPCell(new Phrase(subjects, ft));
                subjectCell.Colspan = 2;
                cardTable.AddCell(subjectCell);

                PdfPCell examOfficer = new PdfPCell(new Phrase("Exam Officer Sig:", ft));
                cardTable.AddCell(examOfficer);
                PdfPCell examOfficerSigCell = new PdfPCell(new Phrase("", ft));
                examOfficerSigCell.Colspan = 2;
                examOfficerSigCell.Rowspan = 2;
                cardTable.AddCell(examOfficerSigCell);

                PdfPCell emptycell1 = new PdfPCell(new Phrase("--------------------------------"));
                emptycell1.Colspan = 1;
                cardTable.AddCell(emptycell1);

                cardTable.SetWidths(width);

                //*************************

                logo2 = Image.GetInstance(studentInfo[1].LogoPath);
                logo2.Alignment = Element.ALIGN_CENTER;
                logo2.WidthPercentage = 10;
                logo2.ScalePercent(33);
                PdfPCell logoCell2 = new PdfPCell(logo2);
                logoCell2.Rowspan = 2;
                logoCell2.HorizontalAlignment = Element.ALIGN_CENTER;
                logoCell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cardTable2.AddCell(logoCell2);

                PdfPCell schoolCell2 = new PdfPCell(new Phrase(studentInfo[1].CompanyName, ff));
                schoolCell2.HorizontalAlignment = Element.ALIGN_CENTER;
                schoolCell2.BackgroundColor = BaseColor.ORANGE;
                cardTable2.AddCell(schoolCell2);

                passport2 = Image.GetInstance(studentInfo[1].PassportPath);
                passport2.WidthPercentage = 30;
                passport2.ScalePercent(40);
                PdfPCell passportCell2 = new PdfPCell(passport2);
                passportCell2.Rowspan = 6;
                passportCell2.HorizontalAlignment = Element.ALIGN_CENTER;
                passportCell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cardTable2.AddCell(passportCell2);

                PdfPCell ExamCell2 = new PdfPCell(new Phrase(studentInfo[1].ExamDetail, ff));
                ExamCell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cardTable2.AddCell(ExamCell2);

                PdfPCell name2 = new PdfPCell(new Phrase("Name:", ft));
                cardTable2.AddCell(name2);
                PdfPCell studentNameCell2 = new PdfPCell(new Phrase(studentInfo[1].Name, ft));
                //studentNameCell2.Colspan = 2;
                cardTable2.AddCell(studentNameCell2);

                PdfPCell exam2 = new PdfPCell(new Phrase("Exam No:", ft));
                cardTable2.AddCell(exam2);
                PdfPCell studentExamNumberCell2 = new PdfPCell(new Phrase(studentInfo[1].ExamNumber, ft));
                //studentExamNumberCell2.Colspan = 2;
                cardTable2.AddCell(studentExamNumberCell2);

                PdfPCell seat2 = new PdfPCell(new Phrase("Seat No:", ft));
                cardTable2.AddCell(seat2);
                PdfPCell studentSeatNumberCell2 = new PdfPCell(new Phrase(studentInfo[1].SeatNumber, ft));
                //studentSeatNumberCell2.Colspan = 2;
                cardTable2.AddCell(studentSeatNumberCell2);

                PdfPCell gender2 = new PdfPCell(new Phrase("Gender:", ft));
                cardTable2.AddCell(gender2);
                PdfPCell gender2Cell = new PdfPCell(new Phrase(studentInfo[1].Gender, ft));
                //gender2Cell.Colspan = 2;
                cardTable2.AddCell(gender2Cell);

                /*PdfPCell serialNumber2 = new PdfPCell(new Phrase("Serial Number:", ft));
                cardTable2.AddCell(serialNumber2);
                PdfPCell serialNumberCell2 = new PdfPCell(new Phrase(studentInfo[1].SerialNumber, ft));
                serialNumberCell2.Colspan = 2;
                cardTable2.AddCell(serialNumberCell2);*/

                PdfPCell subjects22 = new PdfPCell(new Phrase("Subjects:", ft));
                cardTable2.AddCell(subjects22);
                string subjects2 = "";
                foreach (string subject in studentInfo[1].Subject)
                {
                    subjects2 += subject + ",";
                }
                PdfPCell subjectCell2 = new PdfPCell(new Phrase(subjects2, ft));
                subjectCell2.Colspan = 2;
                cardTable2.AddCell(subjectCell2);

                PdfPCell examOfficer2 = new PdfPCell(new Phrase("Exam Officer Sig:", ft));
                cardTable2.AddCell(examOfficer2);
                PdfPCell examOfficerSigCell2 = new PdfPCell(new Phrase("", ft));
                examOfficerSigCell2.Colspan = 2;
                examOfficerSigCell2.Rowspan = 2;
                cardTable2.AddCell(examOfficerSigCell2);

                PdfPCell emptycell2 = new PdfPCell(new Phrase("--------------------------------"));
                emptycell2.Colspan = 1;
                cardTable2.AddCell(emptycell2);

                cardTable2.SetWidths(width);
                //****************

                PdfPCell card1 = new PdfPCell(cardTable);
                PdfPCell card2 = new PdfPCell(cardTable2);
                borderTable.AddCell(card1);
                borderTable.AddCell("");
                borderTable.AddCell(card2);

                PdfPCell emptycell = new PdfPCell();
                emptycell.Colspan = 3;
                borderTable.AddCell(emptycell);
                borderTable.SetWidths(width2);

                doc.Add(borderTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
