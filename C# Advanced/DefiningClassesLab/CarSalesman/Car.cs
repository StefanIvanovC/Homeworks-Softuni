namespace CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private string newEngine;
        private int weight;
        private string color;

        public string Color
        {
            get { return color; }
            set { this.color = value; }
        }

        public string NewEngine
        {
            get { return newEngine; }
            set { this.newEngine = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { this.engine = value; }
        }

        public string Model
        {
            get { return model; }
            set { this.model = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { this.weight = value; }
        }

        public Car(string carModel, Engine inputEngine)
            : this(carModel, inputEngine, 0, "n/a")
        {
        }

        public Car(string carModel, Engine inputEngine, string color)
            : this(carModel, inputEngine, 0, color)

        {
        }

        public Car(string carModel, Engine inputEngine, int weight)
            : this(carModel, inputEngine, weight, "n/a")
        {
        }

        public Car(string carModel, Engine inputEngine, int weight, string color)
        {
            this.model = carModel;
            this.engine = inputEngine;
            this.weight = weight;
            this.color = color;
        }
    }
}