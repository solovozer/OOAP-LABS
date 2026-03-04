using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaker.Parts
{
    internal class Engine
    {
        private readonly string id;
        private readonly string model;
        private readonly int horsePower;
        private readonly string weight;
        private readonly double efficiency;

        public string Id => id;
        public string Model => model;
        public int HorsePower => horsePower;
        public string Weight => weight;
        public double Efficiency => efficiency;

        public Engine(string id, string model, int horsePower, string weight, double efficiency)
        {
            this.id = id;
            this.model = model;
            this.horsePower = horsePower;
            this.weight = weight;
            this.efficiency = efficiency;
        }
    }

    internal class HondaEngine : Engine
    {
        private static int nextId = -1;

        private readonly bool hasVTEC;

        public static int NextId => ++nextId;
        public bool HasVTEC => hasVTEC;

        public HondaEngine(string model, int horsePower, string weight, double efficiency, bool hasVTEC)
            : base("H-VTEC-" + NextId.ToString(), model, horsePower, weight, efficiency)
        {
            this.hasVTEC = hasVTEC;
        }
    }

    internal class FerrariEngine : Engine
    {
        private static int nextId = -1;

        private readonly int cylinders;
        private readonly bool hasTurbo;

        public static int NextId => ++nextId;
        public int Cylinders => cylinders;
        public bool HasTurbo => hasTurbo;

        public FerrariEngine(string model, int horsePower, string weight, double efficiency, int cylinders, bool hasTurbo)
            : base("F-V8-" + NextId.ToString(), model, horsePower, weight, efficiency)
        {
            this.cylinders = cylinders;
            this.hasTurbo = hasTurbo;
        }
    }

    internal class LadaEngine : Engine
    {
        private static int nextId = -1;

        private readonly double emission;

        public static int NextId => ++nextId;
        public double Emission => emission;

        public LadaEngine(string model, int horsePower, string weight, double efficiency, double emission)
            : base("L-" + NextId.ToString(), model, horsePower, weight, efficiency)
        {
            this.emission = emission;
        }
    }
}
