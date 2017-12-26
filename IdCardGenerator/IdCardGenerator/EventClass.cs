using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdCardGenerator
{
    delegate void CardWrite(List<WaecStudentCard> doubleCard);
    class EventClass
    {
        public event CardWrite CardWriteEvent;

        public void DisplayCard(List<WaecStudentCard> doubleCard)
        {
            if(CardWriteEvent != null)
            {
                CardWriteEvent(doubleCard);
            }
        }
    }
}
