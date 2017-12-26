using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdCardGenerator
{
    class WaecStudentCard : WaecSchoolInfo
    {
        string name, gender, examNumber, seatNumber, examOfficer, passportPath, serialNumber;
        List<string> subject;
        public WaecStudentCard(string imagePath, string name, string examNumber, string seatNumber, string gender, 
            string passportPath, string serialNumber, string schoolName, string examType) :
            base(imagePath, schoolName, examType)
        {
            this.name = name;
            this.examNumber = examNumber;
            this.seatNumber = seatNumber;
            examOfficer = "Exam Officer";
            this.gender = gender;
            this.passportPath = passportPath;
            this.serialNumber = serialNumber;
            subject = new List<string>();
        }
        public string PassportPath
        {
            get { return passportPath; }
            set { passportPath = value; }
        }
        public string Name
        {
            get { return name; }
        }
        public string ExamNumber
        {
            get { return examNumber; }
        }
        public string SeatNumber
        {
            get { return seatNumber; }
        }
        public string SerialNumber
        {
            get { return serialNumber; }
        }
        public List<string> Subject
        {
            set { subject = value; }
            get { return subject; }
        }
        public string Gender
        {
            get { return gender; }
        }
    }
}
