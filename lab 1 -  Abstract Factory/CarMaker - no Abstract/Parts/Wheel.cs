using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaker.Parts
{
    internal class Wheel
    {
        private readonly string id;
        private readonly double diameter; 
        private readonly double width;  
        private readonly string material;
        private readonly string tireBrand;
        
        public string Id => id;
        public double Diameter => diameter;
        public double Width => width;
        public string Material => material;
        public string TireBrand => tireBrand;


        public Wheel(string id, double diameter, double width, string material, string tireBrand)
        {
            this.id = id;
            this.diameter = diameter;
            this.width = width;
            this.material = material;
            this.tireBrand = tireBrand;
        }
    }

    internal class HondaWheel : Wheel
    {
        private static int nextId = -1;

        private readonly string hubType;

        public static int NextId = ++nextId;
        public string HubType => hubType;
        public HondaWheel(double dia, double width, string mat, string brand, string hubType)
            : base("HW-" + NextId.ToString(), dia, width, mat, brand) 
        { 
            this.hubType = hubType; 
        }
    }

    internal class FerrariWheel : Wheel
    {
        private static int nextId = -1;

        private readonly bool isCenterLock;

        public static int NextId = ++nextId;
        public bool IsCenterLock => isCenterLock;

        public FerrariWheel(double dia, double width, string mat, string brand, bool isCenterLock)
            : base("FW-" + NextId.ToString(), dia, width, mat, brand) 
        { 
            this.isCenterLock = isCenterLock; 
        }
    }

    internal class LadaWheel : Wheel
    {
        private static int nextId = -1;

        private readonly bool hasSteelFrame;

        public static int NextId = ++nextId;
        public bool HasSteelFrame => hasSteelFrame;

        public LadaWheel(double dia, double width, string mat, string brand, bool hasSteelFrame)
            : base("LW-" + NextId.ToString(), dia, width, mat, brand) 
        { 
            this.hasSteelFrame = hasSteelFrame; 
        }
    }
}
