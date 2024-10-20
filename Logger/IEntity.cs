using System.Globalization;

namespace Logger;
public interface IEntity
{

    // Place members here.
    public string Name { get; set; }
    public Guid Id { get; init; }
}
