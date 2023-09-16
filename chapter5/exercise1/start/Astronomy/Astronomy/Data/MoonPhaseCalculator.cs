namespace Astronomy.Data;

public static class MoonPhaseCalculator
{
    public enum Phase
    {
        New,
        WaxingCrescent,
        FirstQuarter,
        WaxingGibbous,
        Full,
        WaningGibbous,
        LastQuarter,
        WaningCrescent,
    }

    /// <summary>
    /// 
    /// </summary>
    private static readonly double SynodicLength = 29.530588853; //length in days of a complete moon cycle

    /// <summary>
    /// 
    /// </summary>
    private static readonly DateTime ReferenceNewMoonDate = new DateTime(2017, 11, 18);

    public static Phase GetPhase(DateTime date)
    {
        return GetPhase(GetAge(date));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    private static double GetAge(DateTime date)
    {
        var days = (date - ReferenceNewMoonDate).TotalDays;

        return days % SynodicLength;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="age"></param>
    /// <returns></returns>
    private static Phase GetPhase(double age)
    {
        return age switch
        {
            < 1 => Phase.New,
            < 7 => Phase.WaxingCrescent,
            < 8 => Phase.FirstQuarter,
            < 14 => Phase.WaxingGibbous,
            < 15 => Phase.Full,
            < 22 => Phase.WaningGibbous,
            < 23 => Phase.LastQuarter,
            < 29 => Phase.WaningCrescent,
            _ => Phase.New,
        };
    }
}