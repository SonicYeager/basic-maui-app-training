using System;

namespace Astronomy
{
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

        private static double _synodicLength = 29.530588853; //length in days of a complete moon cycle
        private static DateTime _referenceNewMoonDate = new DateTime(2017, 11, 18);

        public static Phase GetPhase(DateTime date)
        {
            return GetPhase(GetAge(date));
        }

        private static double GetAge(DateTime date)
        {
            var days = (date - _referenceNewMoonDate).TotalDays;

            return days % _synodicLength;
        }

        private static Phase GetPhase(double age)
        {
            if (age < 1) return Phase.New;
            if (age < 7) return Phase.WaxingCrescent;
            if (age < 8) return Phase.FirstQuarter;
            if (age < 14) return Phase.WaxingGibbous;
            if (age < 15) return Phase.Full;
            if (age < 22) return Phase.WaningGibbous;
            if (age < 23) return Phase.LastQuarter;
            if (age < 29) return Phase.WaningCrescent;

            return Phase.New;
        }
    }
}