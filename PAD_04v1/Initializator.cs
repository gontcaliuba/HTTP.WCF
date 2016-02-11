using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAD_04v1
{
    public class Initializator
    {
        string[] arg;
        public Initializator(string[] arg)
        {
            this.arg = arg;
        }

        public string txtName()
        {
            if (arg.Count() <= 0) return null;
            return arg[0];
        }
    }
}
