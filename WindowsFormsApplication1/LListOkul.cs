using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class LListOkul:LListAdtOkul
    {

        public override void InsertFirst(object value)
        {
            NodeOkul tmpHead = new NodeOkul
            {
                Data = value
            };

            if (Head == null)
                Head = tmpHead;
            else
            {

                tmpHead.Next = Head;

                Head = tmpHead;
            }

            Size++;
        }
    }
}
