namespace Vehicles.Classes
{
    public class Car : Vehicle
    {
        public Car(string typeOfVehicle, double fuelQuantity, double fuelConsumptionLittersPerKm, double tankCapacity) 
            : base(typeOfVehicle, fuelQuantity, fuelConsumptionLittersPerKm, tankCapacity)
        {
        }

        public override double FuelConsumptionLittersPerKm
        {
            get
            {
                return base.FuelConsumptionLittersPerKm;
            }
            protected set
            {
                base.FuelConsumptionLittersPerKm = value + 0.9;
            }
        }
    }
}
