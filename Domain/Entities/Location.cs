namespace Domain.Entities;

public class Location
{
    public Location(string country, string city, string longitude, string latitude)
    {
        Id = Guid.NewGuid();
        Country = country;
        City = city;
        Longitude = longitude;
        Latitude = latitude;
    }

    protected Location()
    {
    }

    public Guid Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Longitude { get; set; }
    public string Latitude { get; set; }
}