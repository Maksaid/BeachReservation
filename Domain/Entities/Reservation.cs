namespace Domain.Entities;

public class Reservation : IComparable<Reservation>
{
    public Reservation(Guid id,DateTime reservationStart, DateTime reservationEnd, User user,
        Umbrella umbrella)
    {
        Umbrella = umbrella;
        DateOfReservation = DateTime.Now;
        ReservationStart = reservationStart;
        ReservationEnd = reservationEnd;
        User = user;
        Id = id;
    }

    public Reservation()
    {
    }

    public Guid Id { get; set; }
    public DateTime DateOfReservation { get; set; }
    public DateTime ReservationStart { get; set; }
    public DateTime ReservationEnd { get; set; }
    public virtual User User { get; set; }

    public virtual Umbrella Umbrella { get; set; }

    public int CompareTo(Reservation? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        var reservationStartComparison = ReservationStart.CompareTo(other.ReservationStart);
        if (reservationStartComparison != 0) return reservationStartComparison;
        return ReservationEnd.CompareTo(other.ReservationEnd);
    }
}