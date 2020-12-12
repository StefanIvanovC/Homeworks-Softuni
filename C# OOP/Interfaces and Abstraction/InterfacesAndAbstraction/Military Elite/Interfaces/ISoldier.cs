using Military_Elite.Models;

namespace Military_Elite
{
    public interface ISoldier
    {
        int Id { get; }

        string Name { get; }

        string LastName { get; }
    }
}
