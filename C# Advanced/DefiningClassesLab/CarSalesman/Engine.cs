namespace CarSalesman
{
    public class Engine
    {
        private string model;
        private string efficiency;
        private int enginePower;
        private int displacement;

        public string Model
        {
            get { return model; }
            set { this.model = value; }
        }

        public int EnginePower
        {
            get { return enginePower; }
            set { this.enginePower = value; }
        }

        public int Displacement
        {
            get { return displacement; }
            set { this.displacement = value; }
        }

        public string Efficiency
        {
            get { return efficiency; }
            set { this.efficiency = value; }
        }

        public Engine(string model, int enginePower)
            : this(model, enginePower, 0, "n/a")
        {
        }

        public Engine(string model, int enginePower, int displacement)
            : this(model, enginePower, displacement, "n/a")
        {
        }

        public Engine(string model, int enginePower, string efficiency)
            : this(model, enginePower, 0, efficiency)
        {
        }

        public Engine(string model, int enginePower, int displacement, string efficiency)
        {
            this.model = model;
            this.enginePower = enginePower;
            this.displacement = displacement;
            this.efficiency = efficiency;
        }
    }
}