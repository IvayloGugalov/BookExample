using System.Collections;
using System.Globalization;
using BookExampleImproved.Extensions;

namespace BookExampleImproved.Models;

public class AuthorsList : IEnumerable<Author>
{
    private readonly List<Author> _authors;

    private IEnumerable<CultureInfo> CultureInfos =>
        this._authors.Select(author => author.CultureInfo).Distinct();

    public AuthorsList(IEnumerable<Author> authors) =>
        this._authors = authors.ToList();

    public void AppendAuthor(Author author) => this._authors.Add(author);

    public bool RemoveAuthor(string fullName) =>
        this._authors.Remove(this.FilterByFullName(fullName));

    private Func<Author, bool> FilterByFullName(string fullName) =>
        author => author.IsMatchingName(fullName);

    public void AuthorsToUppercase() =>
        this._authors.ForEach(author => author.ToUpperCase());

    public bool MoveAuthorUp(string fullName) =>
        this._authors.SwapWithPrevious(FilterByFullName(fullName));

    public bool MoveAuthorDown(string fullName) =>
        this._authors.SwapWithNext(FilterByFullName(fullName));

    public bool MoveAuthorToBeginning(string fullName) =>
        this._authors.MoveToBeginning(FilterByFullName(fullName));

    public bool MoveAuthorToEnd(string fullName) =>
        this._authors.MoveToEnd(FilterByFullName(fullName));

    public IEnumerator<Author> GetEnumerator() => this._authors.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
