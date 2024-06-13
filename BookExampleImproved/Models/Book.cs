namespace BookExampleImproved.Models;

public class Book
{
    public string Title { get; private set; }
    public AuthorsList Authors { get; }
    public BookRelease BookRelease { get; }

    public Book(string title, AuthorsList authorsList, BookRelease bookRelease)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title, nameof(title));

        this.Title = title;
        this.Authors = authorsList;
        this.BookRelease = bookRelease;
    }
}
