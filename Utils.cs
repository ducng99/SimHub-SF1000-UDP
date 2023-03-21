using System;

namespace SimHubToF12020UDP
{
    internal static class Utils
    {
        public static byte ClampByte(object value)
        {
            long returnValue = 0;

            try
            {
                returnValue = Convert.ToInt64(value);
            }
            catch { }

            returnValue = Math.Min(returnValue, byte.MaxValue);
            returnValue = Math.Max(returnValue, byte.MinValue);

            return Convert.ToByte(returnValue);
        }
    }
}
