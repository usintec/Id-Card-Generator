using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Threading;

namespace IdCardGenerator
{
    class WaecStudentDataExtraction : DataExtraction
    {
        
        StudentCardCollection studentCollection;

        string SchoolName, ExamType;
        EventClass IdCardEvent;

        public WaecStudentDataExtraction(string SchoolName, string ExamType, string folderPath, string PassportPath,
            string masterFile, string logo) : base(folderPath, PassportPath, masterFile, logo)
        {
            this.SchoolName = SchoolName;
            this.ExamType = ExamType;

            studentCollection = new StudentCardCollection();
            IdCardEvent = new EventClass();
            IdCardEvent.CardWriteEvent += CardWrite;
        }
        
        /*private void rename()
        {
            DirectoryInfo schoolDirectory = new DirectoryInfo(folder + "/ice again/pics/");

            foreach (FileInfo passport in schoolDirectory.GetFiles())
            {
                //string[] nameSplited = passport.Name.Split(' ');
                //string passportName = nameSplited[0];
                string passportName = passport.Name;
                if(!result.Contains(passportName))
                    Console.WriteLine(passportName);
                /*foreach(string strName in result)
                {
                    //string[] strClean = str.Split(' ');
                    //string strName = strClean[1];
                    if (passportName == strName)
                    {
                        Console.WriteLine(passportName);
                        //string examNumber = strClean[1];
                        //passport.MoveTo(schoolDirectory + "/nn/" + examNumber + ".jpg");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("************************");
                        Console.WriteLine(passport.Name);
                        break;
                    }
                }

            }
        
        }*/

        private bool ELItTest(string[] firstPath, string[] secondPath)
        {
            if (!firstPath.Contains(" E lit") && !secondPath.Contains(" E lit"))
                return false;
            else
                return true;
        }

        private void CardWrite(List<WaecStudentCard> doubleCard)
        {
            try
            {
                foreach (WaecStudentCard card in doubleCard)
                {
                    string subjects = "";
                    Console.WriteLine(card.CompanyName);
                    Console.WriteLine(card.ExamDetail);
                    Console.WriteLine("Name: " + card.Name);
                    Console.WriteLine("Gender: " + card.Gender);
                    Console.WriteLine("Exam Number: " + card.ExamNumber);
                    Console.WriteLine("Serial Number: " + card.SeatNumber);
                    foreach (string subject in card.Subject)
                    {
                        subjects += subject + ",";
                    }
                    Console.WriteLine("Subjects: " + subjects);
                    Console.WriteLine("*************************************************************************");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void load(List<string> subject, string[] studentDetail, string[] studentSubject, string examNumber,
            string serialNumber, string seatNumber, Int32 lengthNumber, Int32 genderNumber)
        {
            if (studentDetail.Length == lengthNumber)//two names
            {
                string name = studentDetail[2] + " " + studentDetail[3];
                string gender = studentDetail[genderNumber];
                string firstSubject = studentSubject[0].Split(' ')[genderNumber + 1];
                subject.Add(firstSubject);
                subject.Add(studentSubject[1]);
                subject.Add(studentSubject[2]);
                subject.Add(studentSubject[3]);
                subject.Add(studentSubject[4]);
                subject.Add(studentSubject[5]);
                subject.Add(studentSubject[6]);
                subject.Add(studentSubject[7]);
                subject.Add(studentSubject[8]);

                string passportPath = Passports + "/" + examNumber + ".jpg";
                WaecStudentCard studentCard = new WaecStudentCard(MainDirectory + "/logo.jpg", name, examNumber, seatNumber,
                    gender, passportPath, serialNumber, SchoolName, ExamType);
                studentCard.Subject = subject;
                studentCollection.StudentCards.Add(studentCard);
            }
            else if (studentDetail.Length == lengthNumber + 1)//three names
            {
                string name = studentDetail[2] + " " + studentDetail[3] + " " + studentDetail[4];
                string gender = studentDetail[genderNumber + 1];
                string firstSubject = studentSubject[0].Split(' ')[genderNumber + 2];
                subject.Add(firstSubject);
                subject.Add(studentSubject[1]);
                subject.Add(studentSubject[2]);
                subject.Add(studentSubject[3]);
                subject.Add(studentSubject[4]);
                subject.Add(studentSubject[5]);
                subject.Add(studentSubject[6]);
                subject.Add(studentSubject[7]);
                subject.Add(studentSubject[8]);

                string passportPath = Passports + "/" + examNumber + ".jpg";
                WaecStudentCard studentCard = new WaecStudentCard(MainDirectory + "/logo.jpg", name, examNumber, seatNumber,
                    gender, passportPath, serialNumber, SchoolName, ExamType);
                studentCard.Subject = subject;
                studentCollection.StudentCards.Add(studentCard);
            }
            else if (studentDetail.Length >= lengthNumber + 2)//four names
            {
                string name = studentDetail[2] + " " + studentDetail[3] + " " + studentDetail[4] + " " + studentDetail[5];
                string gender = studentDetail[genderNumber + 2];
                string firstSubject = studentSubject[0].Split(' ')[genderNumber + 3];
                subject.Add(firstSubject);
                subject.Add(studentSubject[1]);
                subject.Add(studentSubject[2]);
                subject.Add(studentSubject[3]);
                subject.Add(studentSubject[4]);
                subject.Add(studentSubject[5]);
                subject.Add(studentSubject[6]);
                subject.Add(studentSubject[7]);
                subject.Add(studentSubject[8]);

                string passportPath = Passports + "/" + examNumber + ".jpg";
                WaecStudentCard studentCard = new WaecStudentCard(MainDirectory + "/logo.jpg", name, examNumber, seatNumber,
                    gender, passportPath, serialNumber, SchoolName, ExamType);
                studentCard.Subject = subject;
                studentCollection.StudentCards.Add(studentCard);
            }
        }
        public void loadDataToObject()
        {
            try
            {
                readStudentMasterList();
                foreach (string student in Result)
                {
                    string[] studentDetail = student.Split(' ');
                    string[] studentSubject = student.Split(',');

                    string serialNumber = studentDetail[0];
                    string examNumber = studentDetail[1];
                    char[] seatNumberArray = examNumber.ToArray();
                    char seven = seatNumberArray[7];
                    char eight = seatNumberArray[8];
                    char nine = seatNumberArray[9];
                    string seatNumber = seven.ToString() + eight.ToString() + nine.ToString();

                    List<string> subject = new List<string>();

                    string[] firstSubj = studentSubject[0].Split(' ');
                    string[] otherSubj = new string[] { studentSubject[1], studentSubject[2] , studentSubject[3], studentSubject[4] , studentSubject[5] , studentSubject[6] ,
                        studentSubject[7] };
                    bool ElitTestResult = ELItTest(firstSubj, otherSubj);
                    if (!ElitTestResult)
                    {
                        load(subject, studentDetail, studentSubject, examNumber, serialNumber, seatNumber, 15, 5);
                    }
                    else
                    {
                        load(subject, studentDetail, studentSubject, examNumber, serialNumber, seatNumber, 16, 5);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void generateIdCardPdf()
        {
            try
            { loadDataToObject(); }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                using (FileStream fs = new FileStream(MainDirectory + "/ice.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
                // Step 2: Creating iTextSharp.text.Document object
                using (Document doc = new Document(PageSize.A2))
                // Step 3: Creating iTextSharp.text.pdf.PdfWriter object
                // It helps to write the Document to the Specified FileStream
                using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                {
                    doc.SetPageSize(iTextSharp.text.PageSize.A2.Rotate());

                    doc.Open();
                    Int32 counter = -1;
                    Int32 pageCounter = 1;
                    List<WaecStudentCard> doubleCard = new List<WaecStudentCard>();
                    foreach (WaecStudentCard card in studentCollection.StudentCards)
                    {
                        counter++;
                        doubleCard.Add(card);

                        if (pageCounter >= 6)
                        {
                            doc.NewPage();
                            pageCounter = 1;
                        }

                        if (counter >= 1)
                        {
                            IdCardFormat cardFormat = new IceFormat();
                            cardFormat.cardFormat(doc, doubleCard);
                            CardWrite(doubleCard);
                            doubleCard.Clear();
                            counter = -1;
                            pageCounter++;
                        }
                    }
                    Console.WriteLine("Open This file For Print Out: " + MainDirectory + "/ice.pdf");
                    Console.WriteLine("Program Designed BY Kareem Yusuf Olatayo");
                    doc.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override void generateIdCardPdfThread()
        {
            Thread generateCardThread = new Thread(generateIdCardPdf);
            generateCardThread.Start();
        }
    }
}
