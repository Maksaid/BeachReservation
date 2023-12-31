﻿using Domain.Exceptions;

namespace Domain.Entities;

public class Beach : IEquatable<Beach>
{
    public Beach(Guid id, string name, string description, int columnsCount, int rowsCount, List<int> indexes,
        User user, Location location)
    {
        if (columnsCount < 4)
            throw BeachException.NotEnoughColumns(id, columnsCount);
        if (rowsCount < 2)
            throw BeachException.NotEnoughRows(id, rowsCount);
        Id = id;
        Name = name;
        Description = description;

        ColumnsCount = columnsCount;
        RowsCount = rowsCount;
        Owner = user;
        Location = location;
        Reviews = new List<Review>();
        Umbrellas = new List<Umbrella>();
        BeachImages = new();
        CreateUmbrellas(indexes);
    }

    protected Beach()
    {
    }

    public virtual User Owner { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int AverageScore => Reviews.Count == 0 ? 0: Reviews.Sum(x => x.Score) / Reviews.Count;
    public string Description { get; set; }
    public virtual List<Review> Reviews { get; set; }
    public virtual List<Umbrella> Umbrellas { get; set; }
    
    public virtual List<Image> BeachImages { get; set; }
    public int ColumnsCount { get; set; }
    public int RowsCount { get; set; }
    public virtual Location Location { get; set; }
    public int UmbrellasMaxCount => RowsCount * ColumnsCount;

    public bool Equals(Beach? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name == other.Name;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Beach)obj);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    private void CreateUmbrellas(List<int> indexes)
    {
        int number = 1;
        for (int i = 0; i < UmbrellasMaxCount; i++)
        {
            if (indexes.Contains(i))
            {
                Umbrellas.Add(new Umbrella(Guid.NewGuid(), number,i, this));
                number++;
            }
        }
    }
}