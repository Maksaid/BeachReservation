namespace Domain.Entities;

public class Review
{
    public Review(Guid id, string text, int reviewScore, User author, Beach beach)
    {
        Beach = beach;
        Id = id;
        Text = text;
        Author = author;
        Score = reviewScore;
        Date = DateTime.Now;
    }

    protected Review()
    {
    }

    public virtual Beach Beach { get; set; }
    public int Score { get; set; }
    public Guid Id { get; set; }
    public string Text { get; set; }
    public virtual User Author { get; set; }
    
    public DateTime Date { get; set; }
}