using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    public static class EnumUtil
    {
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static Dictionary<int, string> GetValuesAsNumbersWithNames<T>()
        {
            var values = GetValues<T>();
            Dictionary<int, string> valuesAsNumbersWithNames = new Dictionary<int, string>();

            foreach (var value in values)
            {
                object valueAsObject = (object) value;
                int valueAsNumber = (int)valueAsObject;
                string nameOfValue = valueAsObject.ToString();

                valuesAsNumbersWithNames[valueAsNumber] = nameOfValue;
            }

            return valuesAsNumbersWithNames;
        }
    }
}
