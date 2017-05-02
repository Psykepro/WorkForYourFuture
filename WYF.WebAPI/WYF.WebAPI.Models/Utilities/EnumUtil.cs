using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WYF.WebAPI.Models.Utilities
{
    public static class EnumUtil
    {
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static Dictionary<byte, string> GetValuesAsNumbersWithNames<T>()
        {
            var values = GetValues<T>();
            Dictionary<byte, string> valuesAsNumbersWithNames = new Dictionary<byte, string>();

            foreach (var value in values)
            {
                object valueAsObject = (object)value;
                byte valueAsNumber = (byte)valueAsObject;
                string nameOfValue = valueAsObject.ToString();

                valuesAsNumbersWithNames[valueAsNumber] = nameOfValue;
            }

            return valuesAsNumbersWithNames;
        }
    }
}
