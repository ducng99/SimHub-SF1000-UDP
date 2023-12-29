using System.Runtime.InteropServices;

namespace SimHubSF1000UDP.DataStructures_F123;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LapData
{
    /**
     * <summary>Last lap time in milliseconds</summary>
     */
    public uint m_lastLapTimeInMS;	       	 

    /**
     * <summary>Current time around the lap in milliseconds</summary>
     */
    public uint m_currentLapTimeInMS; 	 

    /**
     * <summary>Sector 1 time in milliseconds</summary>
     */
    public ushort m_sector1TimeInMS;           

    /**
     * <summary>Sector 1 whole minute part</summary>
     */
    public byte m_sector1TimeMinutes;        

    /**
     * <summary>Sector 2 time in milliseconds</summary>
     */
    public ushort m_sector2TimeInMS;           

    /**
     * <summary>Sector 2 whole minute part</summary>
     */
    public byte m_sector2TimeMinutes;        

    /**
     * <summary>Time delta to car in front in milliseconds</summary>
     */
    public ushort m_deltaToCarInFrontInMS;     

    /**
     * <summary>Time delta to race leader in milliseconds</summary>
     */
    public ushort m_deltaToRaceLeaderInMS;     

    /**
     * <summary>Distance vehicle is around current lap in metres – could be negative if line hasn’t been crossed yet</summary>
     */
    public float m_lapDistance;         

    /**
     * <summary>Total distance travelled in session in metres – could be negative if line hasn’t been crossed yet</summary>
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
     * <summary>Number of pit stops taken in this race</summary>
     */
    public byte m_numPitStops;            	 

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
     * <summary>Accumulated number of warnings issued</summary>
     */
    public byte m_totalWarnings;             

    /**
     * <summary>Accumulated number of corner cutting warnings issued</summary>
     */
    public byte m_cornerCuttingWarnings;     

    /**
     * <summary>Num drive through pens left to serve</summary>
     */
    public byte m_numUnservedDriveThroughPens;  

    /**
     * <summary>Num stop go pens left to serve</summary>
     */
    public byte m_numUnservedStopGoPens;        

    /**
     * <summary>Grid position the vehicle started the race in</summary>
     */
    public byte m_gridPosition;         	 

    /**
     * <summary>Status of driver - 0 = in garage, 1 = flying lap, 2 = in lap, 3 = out lap, 4 = on track</summary>
     */
    public byte m_driverStatus;            

    /**
     * <summary>Result status - 0 = invalid, 1 = inactive, 2 = active, 3 = finished, 4 = didnotfinish, 5 = disqualified, 6 = not classified, 7 = retired</summary>
     */
    public byte m_resultStatus;              

    /**
     * <summary>Pit lane timing, 0 = inactive, 1 = active</summary>
     */
    public byte m_pitLaneTimerActive;     	 

    /**
     * <summary>If active, the current time spent in the pit lane in ms</summary>
     */
    public ushort m_pitLaneTimeInLaneInMS;   	 

    /**
     * <summary>Time of the actual pit stop in ms</summary>
     */
    public ushort m_pitStopTimerInMS;        	 

    /**
     * <summary>Whether the car should serve a penalty at this stop</summary>
     */
    public byte m_pitStopShouldServePen;   	 
};
