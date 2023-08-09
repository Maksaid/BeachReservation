using Domain.Exceptions;

namespace Domain.Entities;

public class Umbrella
{
    public Umbrella(Guid id, int number, int index, Beach beach)
    {
        Id = id;
        Number = number;
        Reservations = new List<Reservation>();
        Beach = beach;
        Index = index;
    }

    protected Umbrella()
    {
    }

    public Guid Id { get; set; }
    public int Number { get; set; }
    public int Index { get; set; }

    public virtual Beach Beach { get; set; }
    public virtual List<Reservation> Reservations { get; set; } = new();

    public void AddReservation(Reservation reservation)
    {
        if (CheckIfTimeIsAvailable(reservation))
            Reservations.Add(reservation);
        else
            throw ReservationException.ReservationTimeOverlap(reservation);
    }

    private bool CheckIfTimeIsAvailable(Reservation reservation)
    {
        foreach (var reserv in Reservations)
        {
            if (reserv.ReservationStart <= reservation.ReservationEnd &&
                reserv.ReservationEnd >= reservation.ReservationStart )
                return false;
        }

        return true;
    }
}