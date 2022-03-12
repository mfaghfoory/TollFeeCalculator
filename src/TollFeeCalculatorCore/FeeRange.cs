using System;

namespace TollFeeCalculatorCore
{
    public class FeeRange
    {
        public FeeRange(TimeSpan from, TimeSpan to, int fee)
        {
            From = from;
            To = to;
            Fee = fee;
        }

        public TimeSpan From { get; }
        public TimeSpan To { get; }
        public int Fee { get; }
    }
}
