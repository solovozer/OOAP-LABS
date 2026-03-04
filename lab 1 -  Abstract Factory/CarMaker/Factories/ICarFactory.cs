using CarMaker.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaker.Factories
{
    internal interface ICarFactory
    {
        string NameModel();
        Engine CreateEngine();
        Gearbox CreateGearbox();
        Wheel CreateWheel();
    }

    internal class HondaFactory : ICarFactory
    {
        public string NameModel() => "Honda Accord";
        public Engine CreateEngine() => new HondaEngine("K20", 150, "150kg", 0.38, true);
        public Gearbox CreateGearbox() => new HondaGearbox("6-Speed", 6, "Manual", 400, true);
        public Wheel CreateWheel() => new HondaWheel(17.0, 215.0, "Alloy", "Bridgestone", "5-Lug");
    }

    internal class FerrariFactory : ICarFactory
    {
        public string NameModel() => "Luce EV";
        public Engine CreateEngine() => new FerrariEngine("F154", 600, "200kg", 0.28, 8, true);
        public Gearbox CreateGearbox() => new FerrariGearbox("DCT", 7, "Auto", 750, 0.05);
        public Wheel CreateWheel() => new FerrariWheel( 20.0, 305.0, "Carbon", "Pirelli", true);
    }

    internal class LadaFactory : ICarFactory
    {
        public string NameModel() => "Lada Niva 4x4";
        public Engine CreateEngine() => new LadaEngine("VAZ-2106", 120, "120kg", 0.22, 1400);
        public Gearbox CreateGearbox() => new LadaGearbox("Heavy-Duty", 5, "Manual", 150, true);
        public Wheel CreateWheel() => new LadaWheel(14.0, 175.0, "Reinforced Steel", "Kama", true);
    }
}
