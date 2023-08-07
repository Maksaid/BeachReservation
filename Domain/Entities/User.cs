namespace Domain.Entities;

public class User : IEquatable<User>
{
    public User(Guid id, string name, string email, string password, string phone)
    {
        Phone = phone;
        Id = id;
        Email = email;
        Password = password;
        Name = name;
        Beaches = new List<Beach>();
        Reservations = new List<Reservation>();
        Reviews = new List<Review>();
    }

    protected User()
    {
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public virtual List<Beach> Beaches { get; set; } = new List<Beach>();
    public virtual List<Reservation> Reservations { get; set; } = new List<Reservation>();
    public virtual List<Review> Reviews { get; set; } = new List<Review>();
    
    

    public bool Equals(User? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Email == other.Email && Phone == other.Phone;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((User)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Email, Phone);
    }
}