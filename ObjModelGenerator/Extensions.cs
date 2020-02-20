using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjModelGenerator
{
    public static class Extensions
    {
        public static Vector3[] With(this Vector3[] array, double? x = null, double? y = null, double? z = null)
        {
            var result = new Vector3[array.Length];

            for (int i = 0; i < array.Length; ++i)
            {
                result[i] = array[i].With(x, y, z);
            }

            return result;
        }
        public static Vector3[] Add(this Vector3[] array, double? x = null, double? y = null, double? z = null)
        {
            var result = new Vector3[array.Length];

            for (int i = 0; i < array.Length; ++i)
            {
                result[i] = array[i].Add(x, y, z);
            }

            return result;
        }
    }
}
