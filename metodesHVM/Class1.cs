using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace metodesHVM
{
    public class C1HVM
    {
       public static bool createStat(int min, int max, int value)
       {

            return (value >= min && value <= max) ? true : false;

        }
    }
}
