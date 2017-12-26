using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdCardGenerator
{
    class SchoolInfo
    {
        string logoPath, schoolName, examDetail;

        public SchoolInfo(string logoPath, string schoolName, string examDetail)
        {
            this.logoPath = logoPath;
            this.schoolName = schoolName;
            this.examDetail = examDetail;
        }
        public SchoolInfo() { }

        public string LogoPath
        {
            get { return logoPath; }
        }
        public string SchoolName
        {
            get { return schoolName; }
        }
        public string ExamDetail
        {
            get { return examDetail; }
        }
    }
}
