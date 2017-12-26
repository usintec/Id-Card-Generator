using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Specialized;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace IdCardGenerator
{
    class StudentDataExtraction
    {
        static string folder = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)).FullName;
        StringCollection result = new StringCollection();
        StudentCardCollection studentCollection = new StudentCardCollection();
        //StudentCard studentCard = new StudentCard();

        DirectoryInfo schoolDirectory = new DirectoryInfo(folder + "/ice again/");
        string studentMasterList;
        string studentPassports;
        private void readStudentMasterList()
        {
            try
            {
                studentMasterList = schoolDirectory + "/data.txt";
                StreamReader reader = new StreamReader(studentMasterList);
                string nextLine;

                while ((nextLine = reader.ReadLine()) != null)
                {
                    result.Add(nextLine);
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void rename()
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
                }*/

            }
        
        }

        private bool ELItTest(string[] firstPath, string[] secondPath)
        {
            if (!firstPath.Contains(" E lit") && !secondPath.Contains(" E lit"))
                return false;
            else
                return true;
        }
        public void loadDataToObject()
        {
            try
            {
                readStudentMasterList();
                foreach (string student in result)
                {
                    string[] studentDetail = student.Split(' ');
                    string[] studentSubject = student.Split(',');
                    studentPassports = schoolDirectory + "/pics";

                    string serialNumber = studentDetail[0];
                    string examNumber = studentDetail[1];
                    char[] seatNumberArray = examNumber.ToArray();
                    string seatNumber = (seatNumberArray[7] + seatNumberArray[8] + seatNumberArray[9]).ToString();
                    string name, gender;
                    List<string> subject = new List<string>();

                    string[] firstSubj = studentSubject[0].Split(' ');
                    string[] otherSubj = new string[] { studentSubject[1], studentSubject[2] , studentSubject[3], studentSubject[4] , studentSubject[5] , studentSubject[6] ,
                        studentSubject[7] };
                    bool ElitTestResult = ELItTest(firstSubj, otherSubj);
                    if (!ElitTestResult)
                    {
                        if (studentDetail.Length == 15)//two names
                        {
                            name = studentDetail[2] + " " + studentDetail[3];
                            gender = studentDetail[5];
                            string firstSubject = studentSubject[0].Split(' ')[6];
                            subject.Add(firstSubject);
                            subject.Add(studentSubject[1]);
                            subject.Add(studentSubject[2]);
                            subject.Add(studentSubject[3]);
                            subject.Add(studentSubject[4]);
                            subject.Add(studentSubject[5]);
                            subject.Add(studentSubject[6]);
                            subject.Add(studentSubject[7]);
                            subject.Add(studentSubject[8]);

                            string passportPath = studentPassports + "/" + examNumber + ".jpg";
                            StudentCard studentCard = new StudentCard(schoolDirectory + "/logo.jpg", name, examNumber, seatNumber, gender, passportPath, serialNumber);
                            studentCard.Subject = subject;
                            studentCollection.StudentCards.Add(studentCard);
                        }
                        else if (studentDetail.Length == 16)//three names
                        {
                            name = studentDetail[2] + " " + studentDetail[3] + " " + studentDetail[4];
                            gender = studentDetail[6];
                            string firstSubject = studentSubject[0].Split(' ')[7];
                            subject.Add(firstSubject);
                            subject.Add(studentSubject[1]);
                            subject.Add(studentSubject[2]);
                            subject.Add(studentSubject[3]);
                            subject.Add(studentSubject[4]);
                            subject.Add(studentSubject[5]);
                            subject.Add(studentSubject[6]);
                            subject.Add(studentSubject[7]);
                            subject.Add(studentSubject[8]);

                            string passportPath = studentPassports + "/" + examNumber + ".jpg";
                            StudentCard studentCard = new StudentCard(schoolDirectory + "/logo.jpg", name, examNumber, seatNumber, gender, passportPath, serialNumber);
                            studentCard.Subject = subject;
                            studentCollection.StudentCards.Add(studentCard);
                        }
                        else if (studentDetail.Length >= 17)//four names
                        {
                            name = studentDetail[2] + " " + studentDetail[3] + " " + studentDetail[4] + " " + studentDetail[5];
                            gender = studentDetail[7];
                            string firstSubject = studentSubject[0].Split(' ')[8];
                            subject.Add(firstSubject);
                            subject.Add(studentSubject[1]);
                            subject.Add(studentSubject[2]);
                            subject.Add(studentSubject[3]);
                            subject.Add(studentSubject[4]);
                            subject.Add(studentSubject[5]);
                            subject.Add(studentSubject[6]);
                            subject.Add(studentSubject[7]);
                            subject.Add(studentSubject[8]);

                            string passportPath = studentPassports + "/" + examNumber + ".jpg";
                            StudentCard studentCard = new StudentCard(schoolDirectory + "/logo.jpg", name, examNumber, seatNumber, gender, passportPath, serialNumber);
                            studentCard.Subject = subject;
                            studentCollection.StudentCards.Add(studentCard);
                        }
                    }
                    else
                    {
                        if (studentDetail.Length == 16)//two names
                        {
                            name = studentDetail[2] + " " + studentDetail[3];
                            gender = studentDetail[5];
                            string firstSubject = studentSubject[0].Split(' ')[6];
                            subject.Add(firstSubject);
                            subject.Add(studentSubject[1]);
                            subject.Add(studentSubject[2]);
                            subject.Add(studentSubject[3]);
                            subject.Add(studentSubject[4]);
                            subject.Add(studentSubject[5]);
                            subject.Add(studentSubject[6]);
                            subject.Add(studentSubject[7]);
                            subject.Add(studentSubject[8]);

                            string passportPath = studentPassports + "/" + examNumber + ".jpg";
                            StudentCard studentCard = new StudentCard(schoolDirectory + "/logo.jpg", name, examNumber, seatNumber, gender, passportPath, serialNumber);
                            studentCard.Subject = subject;
                            studentCollection.StudentCards.Add(studentCard);
                        }
                        else if (studentDetail.Length == 17)//three names
                        {
                            name = studentDetail[2] + " " + studentDetail[3] + " " + studentDetail[4];
                            gender = studentDetail[6];
                            string firstSubject = studentSubject[0].Split(' ')[7];
                            subject.Add(firstSubject);
                            subject.Add(studentSubject[1]);
                            subject.Add(studentSubject[2]);
                            subject.Add(studentSubject[3]);
                            subject.Add(studentSubject[4]);
                            subject.Add(studentSubject[5]);
                            subject.Add(studentSubject[6]);
                            subject.Add(studentSubject[7]);
                            subject.Add(studentSubject[8]);

                            string passportPath = studentPassports + "/" + examNumber + ".jpg";
                            StudentCard studentCard = new StudentCard(schoolDirectory + "/logo.jpg", name, examNumber, seatNumber, gender, passportPath, serialNumber);
                            studentCard.Subject = subject;
                            studentCollection.StudentCards.Add(studentCard);
                        }
                        else if (studentDetail.Length >= 18)//four names
                        {
                            name = studentDetail[2] + " " + studentDetail[3] + " " + studentDetail[4] + " " + studentDetail[5];
                            gender = studentDetail[7];
                            string firstSubject = studentSubject[0].Split(' ')[8];
                            subject.Add(firstSubject);
                            subject.Add(studentSubject[1]);
                            subject.Add(studentSubject[2]);
                            subject.Add(studentSubject[3]);
                            subject.Add(studentSubject[4]);
                            subject.Add(studentSubject[5]);
                            subject.Add(studentSubject[6]);
                            subject.Add(studentSubject[7]);
                            subject.Add(studentSubject[8]);

                            string passportPath = studentPassports + "/" + examNumber + ".jpg";
                            StudentCard studentCard = new StudentCard(schoolDirectory + "/logo.jpg", name, examNumber, seatNumber, gender, passportPath, serialNumber);
                            studentCard.Subject = subject;
                            studentCollection.StudentCards.Add(studentCard);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void generateIdCard()
        {
            try
            {
                using (FileStream fs = new FileStream(folder + "/ice.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
                // Step 2: Creating iTextSharp.text.Document object
                using (Document doc = new Document(PageSize.A2))
                // Step 3: Creating iTextSharp.text.pdf.PdfWriter object
                // It helps to write the Document to the Specified FileStream
                using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                {
                    doc.SetPageSize(iTextSharp.text.PageSize.A3.Rotate());

                    doc.Open();
                    Int32 counter = -1;
                    Int32 pageCounter = 1;
                    List<StudentCard> doubleCard = new List<StudentCard>();
                    foreach (StudentCard card in studentCollection.StudentCards)
                    {
                        counter++;
                        doubleCard.Add(card);

                        if (pageCounter >= 3)
                        {
                            doc.NewPage();
                            pageCounter = 1;
                        }

                        if (counter >= 1)
                        {
                            IdCardFormat cardFormat = new IdCardFormat();
                            cardFormat.cardFormat(doc, doubleCard);
                            doubleCard.Clear();
                            counter = -1;
                            pageCounter++;
                        }                        
                    }
                    doc.Close();
                    fs.Close();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
