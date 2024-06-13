using System.Collections;

namespace BookExampleDefault.Models;

public class AuthorsList : IEnumerable<string>
{
    private List<string> _authors;

    public AuthorsList(IEnumerable<string> authors) =>
        this._authors = authors.Where(IsValidAuthor).ToList();

    private bool IsValidAuthor(string author) =>
        !string.IsNullOrWhiteSpace(author) ? true : throw new ArgumentException(nameof(author));

    public void AppendAuthor(string author)
    {
        IsValidAuthor(author);
        this._authors.Add(author);
    }

    public bool RemoveAuthor(string author) =>
        FirstOrDefaultAuthor(author) is string found && this._authors.Remove(found);

    private string? FirstOrDefaultAuthor(string author) =>
        this._authors.FirstOrDefault(found => found.Equals(author, StringComparison.InvariantCultureIgnoreCase));

    public void AuthorsToUppercase()
    {
        for (int i = 0; i < _authors.Count; i++)
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


    public IEnumerator<string> GetEnumerator() => this._authors.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
