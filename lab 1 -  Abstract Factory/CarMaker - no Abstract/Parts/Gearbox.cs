using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarMaker.Parts
{
    internal class Gearbox
    {
        private readonly string id;
        private readonly string model;
        private readonly int gearCount;
        private readonly string type;
        private readonly double maxTorque;

        public string Id => id;
        public string Model => model;
        public int GearCount => gearCount;
        public string Type => type; 
        public double MaxTorque => maxTorque;

        public Gearbox(string id, string model, int gearCount, string type, double maxTorque)
        {
            this.id = id;
            this.model = model;
            this.gearCount = gearCount;
            this.type = type;
            this.maxTorque = maxTorque;
        }
    }

    internal class HondaGearbox : Gearbox
    {
        private static int nextId = -1;

        public static int NextId = ++nextId;
        private readonly bool hasVTEC;
        public bool HasVTEC => hasVTEC;

        public HondaGearbox(string model, int gearCount, string type, double maxTorque, bool hasVTEC)
            : base("HG-" + NextId.ToString(), model, gearCount, type, maxTorque) 
        { 
            this.hasVTEC = hasVTEC; 
        }
    }

    internal class FerrariGearbox : Gearbox
    {
        private static int nextId = -1;

        public static int NextId = ++nextId;
        private readonly double shiftSpeedMs;
        public double ShiftSpeedMs => shiftSpeedMs;
        public FerrariGearbox(string model, int gearCount, string type, double maxTorque, double shiftSpeedMs)
            : base("FG-" + NextId.ToString(), model, gearCount, type, maxTorque) 
        { 
            this.shiftSpeedMs = shiftSpeedMs; 
        }
    }

    internal class LadaGearbox : Gearbox
    {
        private static int nextId = -1;

        private readonly bool hasLowRange; // For 4x4 Niva 

        public static int NextId = ++nextId;
        public bool HasLowRange => hasLowRange;

        public LadaGearbox(string model, int gearCount, string type, double maxTorque, bool hasLowRange)
            : base("LG-" + NextId.ToString(), model, gearCount, type, maxTorque) 
        { 
            this.hasLowRange = hasLowRange; 
        }
    }
}
