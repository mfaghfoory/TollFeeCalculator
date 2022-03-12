using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TollFeeCalculatorCore;
using TollFeeCalculatorCore.Vehicles;

namespace Tests
{
    [TestClass]
    public class TollCalculatorTests
    {
        readonly TollCalculator calculator = new TollCalculator();

        [TestMethod]
        public void weekend_should_return_zero_fee()
        {
            var res = calculator.GetTollFee(new Car(), DateTime.Parse("3/5/2022"), new[] { new TimeSpan(6, 0, 0) });

            Assert.IsTrue(res == 0);
        }

        [TestMethod]
        public void on_july_should_return_zero_fee()
        {
            var res1 = calculator.GetTollFee(new Car(), DateTime.Parse("7/1/2022"), new[] { new TimeSpan(6, 0, 0) });
            var res2 = calculator.GetTollFee(new Car(), DateTime.Parse("7/15/2022"), new[] { new TimeSpan(6, 0, 0) });
            var res3 = calculator.GetTollFee(new Car(), DateTime.Parse("7/29/2022"), new[] { new TimeSpan(6, 0, 0) });

            Assert.IsTrue(res1 == 0);
            Assert.IsTrue(res2 == 0);
            Assert.IsTrue(res3 == 0);
        }

        [TestMethod]
        public void toll_fee_vehicle_should_get_zero_fee()
        {
            var res = calculator.GetTollFee(new Motorbike(), DateTime.Parse("3/1/2022"), new[] { new TimeSpan(6, 0, 0) });

            Assert.IsTrue(res == 0);
        }

        [TestMethod]
        public void ordinary_vehicle_should_not_get_zero_fee()
        {
            var res = calculator.GetTollFee(new Car(), DateTime.Parse("3/1/2022"), new[] { new TimeSpan(6, 0, 0) });

            Assert.IsTrue(res > 0);
            Assert.IsTrue(res == 8);
        }

        [DataRow("6:0:0", 8)]
        [DataRow("6:29:0", 8)]
        [DataRow("6:30:0", 13)]
        [DataRow("6:59:0", 13)]
        [DataRow("7:0:0", 18)]
        [DataRow("7:59:0", 18)]
        [DataRow("8:0:0", 13)]
        [DataRow("8:29:0", 13)]
        [DataRow("8:30:0", 8)]
        [DataRow("14:59:0", 8)]
        [DataRow("15:0:0", 13)]
        [DataRow("15:29:0", 13)]
        [DataRow("15:30:0", 18)]
        [DataRow("16:59:0", 18)]
        [DataRow("17:0:0", 13)]
        [DataRow("17:59:0", 13)]
        [DataRow("18:0:0", 8)]
        [DataRow("18:29:0", 8)]
        [DataRow("18:30:0", 0)]
        [DataRow("19:0:0", 0)]
        [DataRow("20:0:0", 0)]
        [DataRow("21:0:0", 0)]
        [DataRow("22:0:0", 0)]
        [DataRow("23:0:0", 0)]
        [DataRow("1:0:0", 0)]
        [DataRow("2:0:0", 0)]
        [DataRow("3:0:0", 0)]
        [DataRow("4:0:0", 0)]
        [DataRow("5:0:0", 0)]
        [DataRow("5:59:59", 0)]
        [DataTestMethod]
        public void test_fee_of_time_ranges(string timeStr, int fee)
        {
            var res = calculator.GetTollFee(new Car(), DateTime.Parse("3/1/2022"), new[] { TimeSpan.Parse(timeStr) });

            Assert.IsTrue(res == fee);
        }
    }
}