using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace AsyncTest
{
    class Flying : Button
    {
        string vector = "";
        public event Action ILeft;
        public event Action IRight;

        public string Vector
        {
            get {return vector; }
            set {vector = value; }
        }


        public void Start()
        {
            if (Location.X == 0)
            {
                ILeft();
            }
            else if (Location.X == 600) {
                IRight();
        }

        }
    }
}
