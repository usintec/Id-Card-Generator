using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.IO;

namespace IdCardGenerator
{
    class DataExtraction
    {
        StringCollection result;

        DirectoryInfo passports;
        DirectoryInfo mainDirectory;
        string masterList, logo;

        public DataExtraction(string folderPath, string PassportPath, string masterFile, string logo)
        {
            mainDirectory = new DirectoryInfo(folderPath);
            passports = new DirectoryInfo(PassportPath);
            result = new StringCollection();
            masterList = mainDirectory + "/" + masterFile + ".txt";
            logo = mainDirectory + "/" + logo + ".jpg";
        }

        public DirectoryInfo Passports
        {
            get { return passports; }
        }
        public DirectoryInfo MainDirectory
        {
            get { return mainDirectory; }
        }
        public string MasterList
        {
            get { return masterList; }
        }
        public string Logo
        {
            get { return logo; }
        }
        public StringCollection Result
        {
            get { return result; }
        }

        protected void readStudentMasterList()
        {
            try
            {
                StreamReader reader = new StreamReader(MasterList);
                string nextLine;

                while ((nextLine = reader.ReadLine()) != null)
                {
                    Result.Add(nextLine);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public virtual void generateIdCardPdfThread()
        {

        }
    }
}
