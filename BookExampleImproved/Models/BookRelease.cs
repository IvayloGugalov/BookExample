using System.Globalization;

namespace BookExampleImproved.Models;

public class BookRelease(
    Publisher publisher,
    IEdition edition,
    PublicationDate publicationDate,
    CultureInfo cultureInfo)
{
    public Publisher Publisher { get; } = publisher;
    public IEdition Edition { get; } = edition;
    public PublicationDate PublicationDate { get; } = publicationDate;
    public CultureInfo CultureInfo { get; } = cultureInfo;
}