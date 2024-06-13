namespace BookExampleImproved.Models;

public interface IEdition { }

public record NumberEdition(int Number) : IEdition;

public class SeasonEdition(SeasonEdition.SeasonEnum season, int year) : IEdition
{
    public enum SeasonEnum
    {
        Spring,
        Summer,
        Autumn,
        Winter
    };

    public SeasonEnum Season { get; set; } = season;
    public int Year { get; set; } = year;
}