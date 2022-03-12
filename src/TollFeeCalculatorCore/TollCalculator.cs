using System;
using System.Linq;
using TollFeeCalculatorCore.Vehicles;

namespace TollFeeCalculatorCore
{
    public class TollCalculator
    {

        /**
         * Calculate the total toll fee for one day
         *
         * @param vehicle - the vehicle
         * @param day   - day of passes
         * @param times   - times of all passes on one day
         * @return - the total toll fee for that day
         */
        public int GetTollFee(IVehicle vehicle, DateTime day, TimeSpan[] times)
        {
            if (day.IsTollFreeDate() || vehicle.IsTollFreeVehicle()) return 0;

            var timeBuckets = times.MakeTimeBuckets(60);

            var totalFee = 0;

            foreach (var timeBucket in timeBuckets)
            {
                var maxFeeInThePeriod = timeBucket.Max(x => x.GetFeeOfSpecificTime());

                totalFee += maxFeeInThePeriod;
            }

            return totalFee > 60 ? 60 : totalFee;
        }
    }
}
