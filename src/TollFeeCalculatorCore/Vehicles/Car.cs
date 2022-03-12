namespace TollFeeCalculatorCore.Vehicles
{
    public class Car : IVehicle
    {
        public VehicleType GetVehicleType()
        {
            return VehicleType.Car;
        }
    }
}