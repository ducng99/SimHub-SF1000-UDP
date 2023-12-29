using System.Runtime.InteropServices;

namespace SimHubSF1000UDP.DataStructures_F12020;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LapData
{
    /**
     * <summary>Last lap time in seconds</summary>
     */
    public float m_lastLapTime;

    /**
     * <summary>Current time around the lap in seconds</summary>
     */
    public float m_currentLapTime;

    //UPDATED in Beta 3:
    /**
     * <summary>Sector 1 time in milliseconds</summary>
     */
    public ushort m_sector1TimeInMS;
    
    /**
     * <summary>Sector 2 time in milliseconds</summary>
     */
    public ushort m_sector2TimeInMS;
    
    /**
     * <summary>Best lap time of the session in seconds</summary>
     */
    public float m_bestLapTime;
    
    /**
     * <summary>Lap number best time achieved on</summary>
     */
    public byte m_bestLapNum;
    
    /**
     * <summary>Sector 1 time of best lap in the session in milliseconds</summary>
     */
    public ushort m_bestLapSector1TimeInMS;
    
    /**
     * <summary>Sector 2 time of best lap in the session in milliseconds</summary>
     */
    public ushort m_bestLapSector2TimeInMS;
    
    /**
     * <summary>Sector 3 time of best lap in the session in milliseconds</summary>
     */
    public ushort m_bestLapSector3TimeInMS;

    /**
     * <summary>Best overall sector 1 time of the session in milliseconds</summary>
     */
    public ushort m_bestOverallSector1TimeInMS;
    
    /**
     * <summary>Lap number best overall sector 1 time achieved on</summary>
     */
    public byte m_bestOverallSector1LapNum;

    /**
     * <summary>Best overall sector 2 time of the session in milliseconds</summary>
     */
    public ushort m_bestOverallSector2TimeInMS;
    
    /**
     * <summary>Lap number best overall sector 2 time achieved on</summary>
     */
    public byte m_bestOverallSector2LapNum;

    /**
     * <summary>Best overall sector 3 time of the session in milliseconds</summary>
     */
    public ushort m_bestOverallSector3TimeInMS;
    
    /**
     * <summary>Lap number best overall sector 3 time achieved on</summary>
     */
    public byte m_bestOverallSector3LapNum;
    
    /**
     * <summary>Distance vehicle is around current lap in metres – could
     * be negative if line hasn’t been crossed yet</summary>
     */
    public float m_lapDistance;
    
    /**
     * <summary>Total distance travelled in session in metres – could
     * be negative if line hasn’t been crossed yet</summary>
     */
    public float m_totalDistance;
    
    /**
     * <summary>Delta in seconds for safety car</summary>
     */
    public float m_safetyCarDelta;
    
    /**
     * <summary>Car race position</summary>
     */
    public byte m_carPosition;
    
    /**
     * <summary>Current lap number</summary>
     */
    public byte m_currentLapNum;
    
    /**
     * <summary>0 = none, 1 = pitting, 2 = in pit area</summary>
     */
    public byte m_pitStatus;
    
    /**
     * <summary>0 = sector1, 1 = sector2, 2 = sector3</summary>
     */
    public byte m_sector;
    
    /**
     * <summary>Current lap invalid - 0 = valid, 1 = invalid</summary>
     */
    public byte m_currentLapInvalid;
    
    /**
     * <summary>Accumulated time penalties in seconds to be added</summary>
     */
    public byte m_penalties;
    
    /**
     * <summary>Grid position the vehicle started the race in</summary>
     */
    public byte m_gridPosition;
    
    /**
     * <summary>Status of driver - 0 = in garage, 1 = flying lap,
     * 2 = in lap, 3 = out lap, 4 = on track</summary>
     */
    public byte m_driverStatus;
    
    /**
     * <summary>Result status - 0 = invalid, 1 = inactive, 2 = active,
     * 3 = finished, 4 = disqualified, 5 = not classified,
     * 6 = retired</summary>
     */
    public byte m_resultStatus;
};
