using System.Runtime.InteropServices;

namespace SimHubSF1000UDP.DataStructures_F123;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct WeatherForecastSample
{
    /**
     * <summary>0 = unknown, 1 = P1, 2 = P2, 3 = P3, 4 = Short P, 5 = Q1,
     * 6 = Q2, 7 = Q3, 8 = Short Q, 9 = OSQ, 10 = R, 11 = R2,
     * 12 = Time Trial</summary>
     */
    public byte m_sessionType;

    /**
     * <summary>Time in minutes the forecast is for</summary>
     */
    public byte m_timeOffset;

    /**
     * <summary>Weather - 0 = clear, 1 = light cloud, 2 = overcast,
     * 3 = light rain, 4 = heavy rain, 5 = storm</summary>
     */
    public byte m_weather;

    /**
     * <summary>Track temp. in degrees celsius</summary>
     */
    public sbyte m_trackTemperature;

    /**
     * <summary>Track temp. change - 0 = up, 1 = down, 2 = no change</summary>
     */
    public sbyte m_trackTemperatureChange;

    /**
     * <summary>Air temp. in degrees celsius</summary>
     */
    public sbyte m_airTemperature;

    /**
     * <summary>Air temp. change - 0 = up, 1 = down, 2 = no change</summary>
     */
    public sbyte m_airTemperatureChange;

    /**
     * <summary>Rain percentage (0-100)</summary>
     */
    public byte m_rainPercentage;
};
