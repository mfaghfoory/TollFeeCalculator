using System;
using System.Collections.Generic;

namespace TollFeeCalculatorCore
{

    public class FeeRangeCollection
    {
        public static List<FeeRange> Range => new List<FeeRange> //can get from a db or external webservice
        {
            new FeeRange(new TimeSpan(06, 00, 00), new TimeSpan(06, 29, 59), 8), 
            new FeeRange(new TimeSpan(06, 30, 00), new TimeSpan(06, 59, 59), 13),
            new FeeRange(new TimeSpan(07, 00, 00), new TimeSpan(07, 59, 59), 18),
            new FeeRange(new TimeSpan(08, 00, 00), new TimeSpan(08, 29, 59), 13),
            new FeeRange(new TimeSpan(08, 30, 00), new TimeSpan(14, 59, 59), 8),
            new FeeRange(new TimeSpan(15, 00, 00), new TimeSpan(15, 29, 59), 13),
            new FeeRange(new TimeSpan(15, 30, 00), new TimeSpan(16, 59, 59), 18),
            new FeeRange(new TimeSpan(17, 00, 00), new TimeSpan(17, 59, 59), 13),
            new FeeRange(new TimeSpan(18, 00, 00), new TimeSpan(18, 29, 59), 8),
            new FeeRange(new TimeSpan(18, 30, 00), new TimeSpan(05, 59, 59), 0),
        };
    }
}
