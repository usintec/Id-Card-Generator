using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace IdCardGenerator
{
    abstract class IdCardFormat
    {
        public abstract void cardFormat(Document doc, List<WaecStudentCard> studentInfo);
    }
}
