using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class LListEskiIs:LListAdtEskiIS
    {
        public override void InsertFirst(object value)
        {
            NodeEskiIs tmpHead = new NodeEskiIs
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
