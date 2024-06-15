using System.Globalization;
using BenchmarkDotNet.Attributes;
using BookExampleImproved.Models;
using BookImproved = BookExampleImproved.Models.Book;
using BookDefault = BookExampleDefault.Models.Book;

namespace BookExample.App;

[MemoryDiagnoser]
[ThreadingDiagnoser]
[ExceptionDiagnoser]
public class BenchMarks
{
    private BookImproved BookImproved;
    private BookDefault BookDefault;

    [GlobalSetup]
    public void Setup()
    {
        var authors = new List<string> { "Author1", "Author2", "Author3", "Author4", "Author5" };
        BookDefault = new BookDefault("Sample Title", authors, "Sample Publisher", 1, new DateOnly(2022, 1, 1), CultureInfo.InvariantCulture);

        var publisher = new Publisher("Sample Publisher");
        var bookRelease = new BookRelease(
            publisher,
            new NumberEdition(1),
            new FullDate(DateOnly.FromDateTime(new DateTime(2022, 1, 1))),
            CultureInfo.InvariantCulture);
        BookImproved = new BookImproved(
            "Sample Title",
            new AuthorsList(authors.Select(x => new Author(x, CultureInfo.InvariantCulture))),
            bookRelease);
    }

    [Benchmark]
    public void MoveAuthorToEndDefault()
    {
        BookDefault.MoveAuthorToEnd("Author1");
    }

    [Benchmark]
    public void MoveAuthorToEndImproved()
    {
        BookImproved.Authors.MoveAuthorToEnd("Author1");
    }
}