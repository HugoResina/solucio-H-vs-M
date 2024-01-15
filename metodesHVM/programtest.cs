using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metodesHVM
{
    public class C1HVM
    {
        public static int suma (int num1, int num2)
        {
            return num1 + num2;
        }
        public static int resta (int num1, int num2)
        {
            return num1 - num2;
        }
        public static int recsuma(int num)
        {
            if (num == 1 || num == 0)
            {
                return 1;
            }
            return num * recsuma(num - 1);
        }
    }
}
