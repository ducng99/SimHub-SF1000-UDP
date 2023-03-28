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
            }
            catch { }

            return (T)Convert.ChangeType(returnValue, typeof(T));
        }

        /**
         * <summary>Clamp the unknown object to the specified floating-point type min and max values</summary>
         */
        public static T ClampFloatingValue<T>(object value)
        {
            double returnValue = 0;

            try
            {
                returnValue = Convert.ToDouble(value);

                if (typeof(T) == typeof(float))
                {
                    returnValue = Math.Min(returnValue, float.MaxValue);
                    returnValue = Math.Max(returnValue, float.MinValue);
                }
                else if (typeof(T) == typeof(decimal))
                {
                    returnValue = Math.Min(returnValue, Convert.ToDouble(decimal.MaxValue));
                    returnValue = Math.Max(returnValue, Convert.ToDouble(decimal.MinValue));
                }
            }
            catch { }

            return (T)Convert.ChangeType(returnValue, typeof(T));
        }
    }
}
