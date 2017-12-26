using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdCardGenerator
{
    class WaecSchoolInfo
    {
        string logoPath, schoolName, examDetail;

        public WaecSchoolInfo(string logoPath, string schoolName, string examDetail = "")
        {
            this.logoPath = logoPath;
            this.schoolName = schoolName;
            this.examDetail = examDetail;
        }
        public WaecSchoolInfo() { }

        public string LogoPath
        {
            get { return logoPath; }
        }
        public string CompanyName
        {
            get { return schoolName; }
        }
        public string ExamDetail
        {
            get { return examDetail; }
        }
    }
}
