namespace TollFeeCalculatorCore.Vehicles
{
    public class Motorbike : IVehicle
    {
        public VehicleType GetVehicleType()
        {
            return VehicleType.Motorbike;
        }
    }
}
