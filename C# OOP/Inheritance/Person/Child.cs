namespace Person
{
    public class Child : Person
    {
        private string name;
        private int age;

       
        public Child(string name, int age)
            : base(name, age)
        {
        }
    }
}