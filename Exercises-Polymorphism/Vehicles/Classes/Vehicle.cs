using System;

namespace Vehicles.Classes
{
    public abstract class Vehicle
    {
        private string typeOfVehicle;
        private double fuelQuantity;
        private double fuelConsumptionLittersPerKm;
        private double tankCapacity;

        protected Vehicle(string typeOfVehicle, double fuelQuantity, double fuelConsumptionLittersPerKm, double tankCapacity)
        {
            this.TypeOfVehicle = typeOfVehicle;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionLittersPerKm = fuelConsumptionLittersPerKm;
            this.TankCapacity = tankCapacity;
        }

        public string TypeOfVehicle
        {
            get
            {
                return this.typeOfVehicle;
            }
            protected set
            {
                this.typeOfVehicle = value;
            }
        }

        public virtual double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                this.fuelQuantity = value;
            }
        }

        public virtual double FuelConsumptionLittersPerKm
        {
            get
            {
                return this.fuelConsumptionLittersPerKm;
            }
            protected set
            {
                this.fuelConsumptionLittersPerKm = value;
            }
        }

        public double TankCapacity
        {
            get
            {
                return this.tankCapacity;
            }
            set
            {
                this.tankCapacity = value;
            }
        }

        public virtual string Drive(double distanceToDrive)
        {
            double availableKm = this.FuelQuantity / this.FuelConsumptionLittersPerKm;
            double fuelConsumptionInLitters = distanceToDrive * this.FuelConsumptionLittersPerKm;

            if (availableKm >= distanceToDrive)
            {
                this.FuelQuantity -= fuelConsumptionInLitters;
                return $"{this.TypeOfVehicle} travelled {distanceToDrive} km";
            }

            return $"{this.TypeOfVehicle} needs refueling";
        }

        public string DriveEmpty(double distanceToDrive)
        {
            double availableKm = this.FuelQuantity / this.FuelConsumptionLittersPerKm - 1.4;
            double fuelConsumptionInLitters = distanceToDrive * this.FuelConsumptionLittersPerKm - 1.4;

            if (availableKm >= distanceToDrive)
            {
                this.FuelQuantity -= fuelConsumptionInLitters;
                return $"{this.TypeOfVehicle} travelled {distanceToDrive} km";
            }

            return $"{this.TypeOfVehicle} needs refueling";
        }

        public virtual void Refuel(double refuelInLitters)
        {
            if (this.FuelQuantity + refuelInLitters > this.TankCapacity)
            {
                throw new ArgumentException("Cannot fit fuel in tank");
            }

            if (this.FuelQuantity + refuelInLitters <= 0d)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            this.FuelQuantity += refuelInLitters;
        }
    }
}
