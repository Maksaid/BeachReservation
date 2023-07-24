namespace Domain.Entities;

public class User
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
}