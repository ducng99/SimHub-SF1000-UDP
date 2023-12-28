using System;

namespace SimHubSF1000UDP
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
                if (typeof(T) == typeof(ulong))
                {
                    return (T)Convert.ChangeType(Convert.ToUInt64(value), typeof(T));
                }

                returnValue = Convert.ToInt64(value);

                if (typeof(T) == typeof(byte))
                {
                    returnValue = Math.Max(Math.Min(returnValue, byte.MaxValue), byte.MinValue);
                }
                else if (typeof(T) == typeof(sbyte))
                {
                    returnValue = Math.Max(Math.Min(returnValue, sbyte.MaxValue), sbyte.MinValue);
                }
                else if (typeof(T) == typeof(short))
                {
                    returnValue = Math.Max(Math.Min(returnValue, short.MaxValue), short.MinValue);
                }
                else if (typeof(T) == typeof(ushort))
                {
                    returnValue = Math.Max(Math.Min(returnValue, ushort.MaxValue), ushort.MinValue);
                }
                else if (typeof(T) == typeof(int))
                {
                    returnValue = Math.Max(Math.Min(returnValue, int.MaxValue), int.MinValue);
                }
                else if (typeof(T) == typeof(uint))
                {
                    returnValue = Math.Max(Math.Min(returnValue, uint.MaxValue), uint.MinValue);
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
                    returnValue = Math.Max(Math.Min(returnValue, float.MaxValue), float.MinValue);
                }
                else if (typeof(T) == typeof(decimal))
                {
                    returnValue = Math.Max(Math.Min(returnValue, Convert.ToDouble(decimal.MaxValue)), Convert.ToDouble(decimal.MinValue));
                }
            }
            catch { }

            return (T)Convert.ChangeType(returnValue, typeof(T));
        }
    }
}
