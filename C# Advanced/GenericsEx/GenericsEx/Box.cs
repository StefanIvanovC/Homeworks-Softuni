using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsEx
{
    public class Box<T> where T : IComparable
    {
        public List<T> Values { get; set; } = new List<T>();

        public Box(List<T> values)
        {
            this.Values = values;
        }

        public void Swap(int first,int second)
        {
            T temp = this.Values[first];
            this.Values[first] = this.Values[second];
            this.Values[second] = temp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T value in this.Values)
            {
                sb.AppendLine($"{value.GetType()}: {value}");
            }
            return sb.ToString();
        }

        internal int GetCountOfGreiterValues(T value)
        {
            int counter = 0;
            foreach (T currentValue in Values)
            {
                if (value.CompareTo(currentValue) < 0)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
