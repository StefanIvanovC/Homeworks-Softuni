using System.Collections.Generic;

namespace RealEstates.Models
{
    public class Property
    {
        public Property()
        {
            this.Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        public int Size { get; set; }

        public int? YardSize { get; set; }

        public byte? Floor { get; set; }

        public byte? TotalFloors { get; set; }

        public int DistrictId { get; set; }

        public virtual District District { get; set; }

        public int? Year { get; set; }

        public int TypePropertyId { get; set; }

        public virtual TypeProperty TypeProperty { get; set; }

        public int TypeBuildingId { get; set; }

        public virtual TypeBuilding TypeBuilding { get; set; }

        public int Price  { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }


    }
}
