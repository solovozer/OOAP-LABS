using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaker.Parts
{
    internal class Engine : VehicleComponent
    {
        private readonly string model;
        private readonly double torque; // Newton-meters
        private readonly double displacement; // Liters
        private readonly FuelType fuel;
        private readonly double thermalEfficiencyPercentage;

        public string Model => model;
        public double Torque => torque;
        public double Displacement => displacement;
        public FuelType Fuel => fuel;
        public double ThermalEfficiencyPercentage => thermalEfficiencyPercentage;

        public Engine(string model, double torque, double displacement, FuelType fuel, double thermalEfficiencyPercentage)
        {
            this.model = model;
            this.torque = torque;
            this.displacement = displacement;
            this.fuel = fuel;
            this.thermalEfficiencyPercentage = thermalEfficiencyPercentage;
        }
    }

    internal class HondaEngine : Engine
    {
        private readonly bool hasVTEC;

        public bool HasVTEC => hasVTEC;

        public HondaEngine(string model, double torque, double displacement, FuelType fuel, double thermalEfficiencyPercentage, bool hasVTEC)
            : base(model, torque, displacement, fuel, thermalEfficiencyPercentage)
        {
            this.hasVTEC = hasVTEC;
        }
    }

    internal class FerrariEngine : Engine
    {
        private readonly int cylinders;
        private readonly bool hasTurbo;

        public int Cylinders => cylinders;
        public bool HasTurbo => hasTurbo;

        public FerrariEngine(string model, double torque, double displacement, FuelType fuel, double thermalEfficiencyPercentage, int cylinders, bool hasTurbo)
            : base(model, torque, displacement, fuel, thermalEfficiencyPercentage)
        {
            this.cylinders = cylinders;
            this.hasTurbo = hasTurbo;
        }
    }

    internal class LadaEngine : Engine
    {
        private readonly double emission;

        public double Emission => emission;

        public LadaEngine(string model, double torque, double displacement, FuelType fuel, double thermalEfficiencyPercentage, double emission)
            : base(model, torque, displacement, fuel, thermalEfficiencyPercentage)
        {
            this.emission = emission;
        }
    }
}
