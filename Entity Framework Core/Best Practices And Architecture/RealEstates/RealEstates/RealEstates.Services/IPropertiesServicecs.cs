using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Services
{
    public interface IPropertiesServicecs
    {
        void Add(string distring, int floor, int maxFloor, int size, int yardSize, int year,
            string typeByilding, string typeProperty, int prize);

        IEnumerable<PropertyInfoDto> Search(int minPrice, int maxPrice, int minSize, int MaxSize);
    }
}
