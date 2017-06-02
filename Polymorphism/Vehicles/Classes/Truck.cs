namespace Vehicles.Classes
{
    public class Truck : Vehicle
    {
        private const double percentRefuel = 95d / 100d;

        public Truck(string typeOfVehicle, double fuelQuantity, double fuelConsumptionLittersPerKm, double tankCapacity) : base(typeOfVehicle, fuelQuantity, fuelConsumptionLittersPerKm, tankCapacity)
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
                base.FuelConsumptionLittersPerKm = value + 1.6;
            }
        }

        public override void Refuel(double refuelInLitters)
        {
            base.FuelQuantity += (percentRefuel * refuelInLitters);
        }
    }
}
