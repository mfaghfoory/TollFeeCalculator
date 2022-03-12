using TollFeeCalculatorCore.Vehicles;

namespace TollFeeCalculatorCore
{
    public static class TollFreeVehicles
    {
        public static VehicleType[] GetTollFreeVehicles()
        {
            return new[]
            {
                VehicleType.Motorbike,
                VehicleType.Tractor,
                VehicleType.Emergency,
                VehicleType.Diplomat,
                VehicleType.Foreign,
                VehicleType.Military
            };
        }
    }
}