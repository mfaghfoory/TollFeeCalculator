using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TollFeeCalculatorCore;
using TollFeeCalculatorCore.Vehicles;

namespace TollFeeCalculator.Tests
{
    [TestClass]
    public class ExtensionsTests
    {
        [DataRow("3/1/2022", false)]
        [DataRow("3/5/2022", true)] // saturday
        [DataRow("3/6/2022", true)] // sunday
        [DataTestMethod]
        public void check_weekend(string dateTimeStr, bool isWeekendOrHoliday)
        {
            var res = DateTime.Parse(dateTimeStr).IsTollFreeDate();

            Assert.IsTrue(res == isWeekendOrHoliday);
        }

        [DataRow(typeof(Car), false)]
        [DataRow(typeof(Motorbike), true)]
        [DataTestMethod]
        public void test_vehicle_types_in_terms_of_being_free(Type vehicleTypeObject , bool isTollFree)
        {
            var vehicle = (IVehicle)Activator.CreateInstance(vehicleTypeObject);

            var res = vehicle.IsTollFreeVehicle();

            Assert.IsTrue(res == isTollFree);
        }

        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataTestMethod]
        public void fee_of_an_item_should_be_equal_to_its_actual_value(int index)
        {
            var item = FeeRangeCollection.Range[index];

            var fee = item.From.GetFeeOfSpecificTime();

            Assert.IsTrue(fee == item.Fee);
        }

        [TestMethod]
        [TestCategory("Time_Bucketizer")]
        public void test_times_bucketizer_1()
        {
            var times = new TimeSpan[]
            {
                new TimeSpan(13, 30, 0), //bucket - 1
                new TimeSpan(14, 20, 0), //bucket - 1
                new TimeSpan(14, 30, 0), //bucket - 2
                new TimeSpan(14, 35, 0), //bucket - 2
                new TimeSpan(15, 30, 0), //bucket - 3
            };
            var buckets = times.MakeTimeBuckets(60);

            Assert.IsTrue(buckets.Count == 3);
            Assert.IsTrue(buckets[0].Count() == 2);
            Assert.IsTrue(buckets[1].Count() == 2);
            Assert.IsTrue(buckets[2].Count() == 1);
        }

        [TestMethod]
        [TestCategory("Time_Bucketizer")]
        public void test_times_bucketizer_2()
        {
            var times = new TimeSpan[]
            {
                new TimeSpan(13, 00, 0), //bucket - 1
                new TimeSpan(13, 30, 0), //bucket - 1
                new TimeSpan(13, 59, 0), //bucket - 1
                new TimeSpan(14, 20, 0), //bucket - 2
                new TimeSpan(14, 30, 0), //bucket - 2
                new TimeSpan(14, 35, 0), //bucket - 2
                new TimeSpan(15, 30, 0), //bucket - 3
            };
            var buckets = times.MakeTimeBuckets(60);

            Assert.IsTrue(buckets.Count == 3);
            Assert.IsTrue(buckets[0].Count() == 3);
            Assert.IsTrue(buckets[1].Count() == 3);
            Assert.IsTrue(buckets[2].Count() == 1);
        }

        [TestMethod]
        [TestCategory("Time_Bucketizer")]
        public void test_times_bucketizer_3()
        {
            var times = new TimeSpan[]
            {
                new TimeSpan(13, 00, 0), //bucket - 1
                new TimeSpan(13, 50, 0), //bucket - 1
                new TimeSpan(14, 00, 0), //bucket - 2
                new TimeSpan(14, 10, 0), //bucket - 2
                new TimeSpan(14, 20, 0), //bucket - 2
                new TimeSpan(14, 30, 0), //bucket - 2
                new TimeSpan(14, 40, 0), //bucket - 2
            };
            var buckets = times.MakeTimeBuckets(60);

            Assert.IsTrue(buckets.Count == 2);
            Assert.IsTrue(buckets[0].Count() == 2);
            Assert.IsTrue(buckets[1].Count() == 5);
        }
    }
}