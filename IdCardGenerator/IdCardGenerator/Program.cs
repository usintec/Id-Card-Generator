using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IdCardGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string folderpath = new System.IO.DirectoryInfo(Environment.CurrentDirectory).FullName;
                string passportpath = folderpath + "/passport";
                string masterfile = "data";
                string logo = "logo";

                DataExtraction IceCardGeneration = new WaecStudentDataExtraction("ICE SEC. SCH. GUSAU", "WAEC EXAM SLIP MAY/JUNE 2017", folderpath, passportpath,
                    masterfile, logo);

                IceCardGeneration.generateIdCardPdfThread();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
