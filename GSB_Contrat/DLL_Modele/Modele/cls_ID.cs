using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Modele
{
    public class cls_ID
    {
        private int c_ID;

        public cls_ID(int pID)
        {
            c_ID = pID;
        }

        public int ID
        {
            get { return c_ID; }
        }
    }
}
