using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var valuse = EnumUtil.GetValues<Nqkuv>();
            var other = EnumUtil.GetValuesAsNumbersWithNames<Nqkuv>();


            foreach (KeyValuePair<int, string> pair in other)
            {
                Console.WriteLine(pair.Key + "|" + pair.Value);
            }

        }
    }
}
