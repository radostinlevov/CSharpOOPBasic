using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Classes
{
    public class Bus : Vehicle
    {
        public Bus(string typeOfVehicle, double fuelQuantity, double fuelConsumptionLittersPerKm, double tankCapacity) 
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
                base.FuelConsumptionLittersPerKm = value + 1.4;
            }
        }
    }
}
