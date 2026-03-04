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
        ICarFactory _carFactory;
        public CarManufacturer(ICarFactory carFactory)
        {
            _carFactory = carFactory;
        }
        public Car AssembleCar()
        {
            string name = _carFactory.NameModel();
            Engine engine = _carFactory.CreateEngine();
            Gearbox gearbox = _carFactory.CreateGearbox();
            Wheel wheel = _carFactory.CreateWheel();
            return new Car(engine, gearbox, wheel, name);
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
