using Nager.Date;
using Nager.Date.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using TollFeeCalculatorCore.Vehicles;

namespace TollFeeCalculatorCore
{
    public static class Extensions
    {
        public static bool IsTollFreeDate(this DateTime dateTime)
        {
            return dateTime.IsWeekend(CountryCode.SE) || 
                DateSystem.IsPublicHoliday(dateTime, CountryCode.SE) ||
                dateTime.Month == 7;
        }

        public static bool IsTollFreeVehicle(this IVehicle vehicle)
        {
            if (vehicle == null) return false;
            var vehicleType = vehicle.GetVehicleType();
            return TollFreeVehicles.GetTollFreeVehicles().Contains(vehicleType);
        }

        /// <summary>
        /// Bucketizes times into specific time intervals of minutes - based on the first item.
        /// </summary>
        /// <param name="times">An array of times which should be grouped into time buckets</param>
        /// <param name="minutesInterval">Time intervals of minutes</param>
        /// <returns>A list of timespan arrays</returns>
        public static List<TimeSpan[]> MakeTimeBuckets(this TimeSpan[] times, int minutesInterval)
        {
            times = times.OrderBy(x => x).ToArray();

            var timeBuckets = times.GroupBy(x => (x - times.FirstOrDefault()).Ticks / TimeSpan.FromMinutes(minutesInterval).Ticks)
                .Select(x => x.ToArray()).ToList(); // grouping based on the first item

            return timeBuckets;
        }

        public static int GetFeeOfSpecificTime(this TimeSpan timeSpan) => FeeRangeCollection.Range
                .FirstOrDefault(x => timeSpan >= x.From && timeSpan <= x.To)?.Fee ?? 0;
    }
}
