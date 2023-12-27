using System.Runtime.InteropServices;

namespace SimHubSF1000UDP.DataStructures_F123;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketSessionData
{
    /**
     * <summary>Header</summary>
     */
    public PacketHeader m_header;

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
     * <summary>Air temp. in degrees celsius</summary>
     */
    public sbyte m_airTemperature;

    /**
     * <summary>Total number of laps in this race</summary>
     */
    public byte m_totalLaps;

    /**
     * <summary>Track length in metres</summary>
     */
    public ushort m_trackLength;

    /**
     * <summary>0 = unknown, 1 = P1, 2 = P2, 3 = P3, 4 = Short P,
     * 5 = Q1, 6 = Q2, 7 = Q3, 8 = Short Q, 9 = OSQ,
     * 10 = R, 11 = R2, 12 = Time Trial</summary>
     */
    public byte m_sessionType;

    /**
     * <summary>-1 for unknown, 0-21 for tracks, see appendix</summary>
     */
    public sbyte m_trackId;

    /**
     * <summary>Formula, 0 = F1 Modern, 1 = F1 Classic, 2 = F2, 3 = F1 Generic, 4 = Beta, 5 = Supercars, 6 = Esports, 7 = F2 2021</summary>
     */
    public byte m_formula;

    /**
     * <summary>Time left in session in seconds</summary>
     */
    public ushort m_sessionTimeLeft;
    /**
     * <summary>Session duration in seconds</summary>
     */
    public ushort m_sessionDuration;

    /**
     * <summary>Pit speed limit in kilometres per hour</summary>
     */
    public byte m_pitSpeedLimit;

    /**
     * <summary>Whether the game is paused</summary>
     */
    public byte m_gamePaused;

    /**
     * <summary>Whether the player is spectating</summary>
     */
    public byte m_isSpectating;

    /**
     * <summary>Index of the car being spectated</summary>
     */
    public byte m_spectatorCarIndex;

    /**
     * <summary>SLI Pro support, 0 = inactive, 1 = active</summary>
     */
    public byte m_sliProNativeSupport;

    /**
     * <summary>Number of marshal zones to follow</summary>
     */
    public byte m_numMarshalZones;

    /**
     * <summary>List of marshal zones – max 21</summary>
     */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)]
    public MarshalZone[] m_marshalZones;

    /**
     * <summary>0 = no safety car, 1 = full safety car, 2 = virtual safety car, 3 = formation lap</summary>
     */
    public byte m_safetyCarStatus;

    /**
     * <summary>0 = offline, 1 = online</summary>
     */
    public byte m_networkGame;

    /**
     * <summary>Number of weather samples to follow</summary>
     */
    public byte m_numWeatherForecastSamples;

    /**
     * <summary>Array of weather forecast samples</summary>
     */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 56)]
    public WeatherForecastSample[] m_weatherForecastSamples;

    /**
    * <summary>0 = Perfect, 1 = Approximate</summary>
    */
    public byte m_forecastAccuracy;

    /**
     * <summary>AI Difficulty rating – 0-110</summary>
     */
    public byte m_aiDifficulty;

    /**
     * <summary>Identifier for season - persists across saves</summary>
     */
    public uint m_seasonLinkIdentifier;

    /**
     * <summary>Identifier for weekend - persists across saves</summary>
     */
    public uint m_weekendLinkIdentifier;

    /**
     * <summary>Identifier for session - persists across saves</summary>
     */
    public uint m_sessionLinkIdentifier;

    /**
     * <summary>Ideal lap to pit on for current strategy (player)</summary>
     */
    public byte m_pitStopWindowIdealLap;

    /**
     * <summary>Latest lap to pit on for current strategy (player)</summary>
     */
    public byte m_pitStopWindowLatestLap;

    /**
     * <summary>Predicted position to rejoin at (player)</summary>
     */
    public byte m_pitStopRejoinPosition;

    /**
     * <summary>0 = off, 1 = on</summary>
     */
    public byte m_steeringAssist;

    /**
     * <summary>0 = off, 1 = low, 2 = medium, 3 = high</summary>
     */
    public byte m_brakingAssist;

    /**
     * <summary>1 = manual, 2 = manual & suggested gear, 3 = auto</summary>
     */
    public byte m_gearboxAssist;

    /**
     * <summary>0 = off, 1 = on</summary>
     */
    public byte m_pitAssist;

    /**
     * <summary>0 = off, 1 = on</summary>
     */
    public byte m_pitReleaseAssist;

    /**
     * <summary>0 = off, 1 = on</summary>
     */
    public byte m_ERSAssist;

    /**
     * <summary>0 = off, 1 = on</summary>
     */
    public byte m_DRSAssist;

    /**
     * <summary>0 = off, 1 = corners only, 2 = full</summary>
     */
    public byte m_dynamicRacingLine;

    /**
     * <summary>0 = 2D, 1 = 3D</summary>
     */
    public byte m_dynamicRacingLineType;

    /**
     * <summary>Game mode id - see appendix</summary>
     */
    public byte m_gameMode;

    /**
     * <summary>Ruleset - see appendix</summary>
     */
    public byte m_ruleSet;

    /**
     * <summary>Local time of day - minutes since midnight</summary>
     */
    public uint m_timeOfDay;

    /**
     * <summary>0 = None, 2 = Very Short, 3 = Short, 4 = Medium, 5 = Medium Long, 6 = Long, 7 = Full</summary>
     */
    public byte m_sessionLength;

    /**
     * <summary>0 = MPH, 1 = KPH</summary>
     */
    public byte m_speedUnitsLeadPlayer;

    /**
     * <summary>0 = Celsius, 1 = Fahrenheit</summary>
     */
    public byte m_temperatureUnitsLeadPlayer;

    /**
     * <summary>0 = MPH, 1 = KPH</summary>
     */
    public byte m_speedUnitsSecondaryPlayer;

    /**
     * <summary>0 = Celsius, 1 = Fahrenheit</summary>
     */
    public byte m_temperatureUnitsSecondaryPlayer;

    /**
     * <summary>Number of safety cars called during session</summary>
     */
    public byte m_numSafetyCarPeriods;

    /**
     * <summary>Number of virtual safety cars called</summary>
     */
    public byte m_numVirtualSafetyCarPeriods;

    /**
     * <summary>Number of red flags called during session</summary>
     */
    public byte m_numRedFlagPeriods;
};
