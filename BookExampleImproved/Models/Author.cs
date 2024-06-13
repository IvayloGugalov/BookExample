using System.Globalization;

namespace BookExampleImproved.Models;

public class Author
{
    public CultureInfo CultureInfo { get; set; }

    public string FullName { get; private set; }

    public Author(string fullName, CultureInfo cultureInfo)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(fullName, nameof(fullName));

        this.FullName = fullName;
        this.CultureInfo = cultureInfo;
    }

    public void ToUpperCase()
    {
        this.FullName = CultureInfo.TextInfo.ToUpper(this.FullName);
    }

    public bool IsMatchingName(string fullName) =>
        string.Compare(this.FullName, fullName, this.CultureInfo, CompareOptions.IgnoreCase) == 0;

    public override string ToString() => this.FullName;
}