namespace BookExampleDefault.Models;

public class Book
{
    private readonly List<string> _authors;

    public string Title { get; set; }
    public string Publisher { get; set; }
    public IEnumerable<string> Authors => _authors;
    public int Edition { get; set; }
    public DateOnly PublicationDate { get; set; }

    public Book(string title, List<string> authors, string publisher, int edition, DateOnly publicationDate)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title, nameof(title));
        ArgumentException.ThrowIfNullOrWhiteSpace(publisher, nameof(publisher));
        ArgumentOutOfRangeException.ThrowIfLessThan(edition, 1, nameof(edition));

        this.Title = title;
        this._authors = authors.Where(IsValidAuthor).ToList();
        this.Publisher = publisher;
        this.Edition = edition;
        this.PublicationDate = publicationDate;
    }

    private static bool IsValidAuthor(string author)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(author, nameof(author));
        return true;
    }

    #region Business Logic
    public void AppendAuthor(string author)
    {
        IsValidAuthor(author);
        this._authors.Add(author);
    }

    // TODO: is Stephen King == stephen king? Implement a case-insensitive comparison.
    public void RemoveAuthor(string author) => this._authors.Remove(author);

    public void AuthorsToUpperCase()
    {
        for (var i = 0; i < this._authors.Count; i++)
        {
            this._authors[i] = this._authors[i].ToUpperInvariant();
        }
    }

    public bool MoveAuthorUp(string author) => SwapAuthors(this._authors.IndexOf(author), -1);

    public bool MoveAuthorDown(string author) => SwapAuthors(this._authors.IndexOf(author), 1);

    public bool MoveAuthorToBeginning(string author) => MoveAuthorToExtreme(this._authors.IndexOf(author), -1);

    public bool MoveAuthorToEnd(string author) => MoveAuthorToExtreme(this._authors.IndexOf(author), 1);

    private bool MoveAuthorToExtreme(int index, int step)
    {
        var result = false;
        while (SwapAuthors(index, step))
        {
            (index, result) = (index + step, true);
        }
        return result;
    }

    private bool SwapAuthors(int index, int offset)
    {
        var (index1, index2) = (index, index + offset);
        if (Math.Min(index1, index2) < 0 || Math.Max(index1, index2) >= this._authors.Count) return false;

        (this._authors[index1], this._authors[index2]) = (this._authors[index2], this._authors[index1]);
        return true;
    }

    #endregion
}
