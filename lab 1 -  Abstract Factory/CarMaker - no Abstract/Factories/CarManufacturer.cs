using CarMaker.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMaker.Factories
{
    internal class CarManufacturer
    {
        private readonly string carFactory;
        public CarManufacturer(string factory)
        {
            carFactory = factory;
        }
        public Car AssembleCar()
        {
            if (carFactory == "Honda")
            {
                string name = "Honda Accord";
                HondaEngine engine = new HondaEngine("K20", 150, "150kg", 0.38, true);
                HondaGearbox gearbox = new HondaGearbox("6-Speed", 6, "Manual", 400, true);
                Wheel wheel = new HondaWheel(17.0, 215.0, "Alloy", "Bridgestone", "5-Lug");
                return new Car(engine, gearbox, wheel, name);
            } 
            else if (carFactory == "Ferrari")
            {
                string name = "Luce EV";
                FerrariEngine engine = new FerrariEngine("F154", 600, "200kg", 0.28, 8, true);
                FerrariGearbox gearbox = new FerrariGearbox("DCT", 7, "Auto", 750, 0.05);
                FerrariWheel wheel = new FerrariWheel(20.0, 305.0, "Carbon", "Pirelli", true); 
                return new Car(engine, gearbox, wheel, name);
            }
            else
            {
                string name = "Lada Niva 4x4";
                LadaEngine engine = new LadaEngine("VAZ-2106", 120, "120kg", 0.22, 1400);
                LadaGearbox gearbox = new LadaGearbox("Heavy-Duty", 5, "Manual", 150, true);
                LadaWheel wheel = new LadaWheel(14.0, 175.0, "Reinforced Steel", "Kama", true);
                return new Car(engine, gearbox, wheel, name);
            }
        }
    }
    internal class Car
    {
        private readonly string model;
        private readonly Engine engine;
        private readonly Gearbox gearbox;
        private readonly Wheel wheel;

        public string Model => model;
        public Engine Engine => engine;
        public Gearbox Gearbox => gearbox;
        public Wheel Wheel => wheel;   

        public Car(Engine engine, Gearbox gearbox, Wheel wheel, string model)
        {
            this.model = model;
            this.engine = engine;
            this.gearbox = gearbox;
            this.wheel = wheel;
        }
    }

    
}
