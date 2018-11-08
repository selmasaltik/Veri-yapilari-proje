using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public abstract class LListAdtOkul
    {
        public NodeOkul Head;
        public int Size = 0;
        public abstract void InsertFirst(object value);
    }
}
