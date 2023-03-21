using System;

namespace SimHubToF12020UDP
{
    internal static class Utils
    {
        /**
         * <summary>Clamp the unknown object to the specified integer type min and max values</summary>
         */
        public static T ClampIntegerValue<T>(object value)
        {
            long returnValue = 0;

            try
            {
                returnValue = Convert.ToInt64(value);
            }
            catch { }

            if (typeof(T) == typeof(byte))
            {
                returnValue = Math.Min(returnValue, byte.MaxValue);
                returnValue = Math.Max(returnValue, byte.MinValue);
            }
            else if (typeof(T) == typeof(sbyte))
            {
                returnValue = Math.Min(returnValue, sbyte.MaxValue);
                returnValue = Math.Max(returnValue, sbyte.MinValue);
            }
            else if (typeof(T) == typeof(short))
            {
                returnValue = Math.Min(returnValue, short.MaxValue);
                returnValue = Math.Max(returnValue, short.MinValue);
            }
            else if (typeof(T) == typeof(ushort))
            {
                returnValue = Math.Min(returnValue, ushort.MaxValue);
                returnValue = Math.Max(returnValue, ushort.MinValue);
            }
            else if (typeof(T) == typeof(int))
            {
                returnValue = Math.Min(returnValue, int.MaxValue);
                returnValue = Math.Max(returnValue, int.MinValue);
            }
            else if (typeof(T) == typeof(uint))
            {
                returnValue = Math.Min(returnValue, uint.MaxValue);
                returnValue = Math.Max(returnValue, uint.MinValue);
            }
            else
            {
                returnValue = 0;
            }

            return (T)Convert.ChangeType(returnValue, typeof(T));
        }

        /**
         * <summary>Clamp the unknown object to the specified floating-point type min and max values</summary>
         */
        public static T ClampFloatingValue<T>(object value)
        {
            decimal returnValue = 0;

            try
            {
                returnValue = Convert.ToDecimal(value);
            }
            catch { }

            if (typeof(T) == typeof(float))
            {
                returnValue = Math.Min(returnValue, Convert.ToDecimal(float.MaxValue));
                returnValue = Math.Max(returnValue, Convert.ToDecimal(float.MinValue));
            }
            else if (typeof(T) == typeof(double))
            {
                returnValue = Math.Min(returnValue, Convert.ToDecimal(double.MaxValue));
                returnValue = Math.Max(returnValue, Convert.ToDecimal(double.MinValue));
            }

            return (T)Convert.ChangeType(returnValue, typeof(T));
        }
    }
}
