using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdCardGenerator
{
    class StudentCardCollection
    {
        List<WaecStudentCard> studentCards;
        public StudentCardCollection()
        {
            studentCards = new List<WaecStudentCard>();
        }

        public List<WaecStudentCard> StudentCards
        {
            set { studentCards = value; }
            get { return studentCards; }
        }
    }
}
