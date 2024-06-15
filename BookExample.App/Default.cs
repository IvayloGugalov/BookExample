using System.Globalization;
using BookExampleDefault.Models;

namespace BookExample.App;

public static class Default
{
    public static void Run()
    {
        var authors = new List<string> { "Ivo G" };
        var book = new Book("Effective C#", authors, "Apollo", 1, new DateOnly(2024, 1, 1), CultureInfo.InvariantCulture);

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add a New Author");
            Console.WriteLine("2. Remove an Author");
            Console.WriteLine("3. Convert Authors' Names to Uppercase");
            Console.WriteLine("4. Move an Author Up in the List");
            Console.WriteLine("5. Move an Author Down in the List");
            Console.WriteLine("6. Move an Author to the Beginning of the List");
            Console.WriteLine("7. Move an Author to the End of the List");
            Console.WriteLine("8. Preview all Authors");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddAuthor(book);
                    break;
                case "2":
                    RemoveAuthor(book);
                    break;
                case "3":
                    ConvertAuthorsToUpperCase(book);
                    break;
                case "4":
                    MoveAuthorUp(book);
                    break;
                case "5":
                    MoveAuthorDown(book);
                    break;
                case "6":
                    MoveAuthorToBeginning(book);
                    break;
                case "7":
                    MoveAuthorToEnd(book);
                    break;
                case "8":
                    Console.WriteLine(string.Join(", ", book.Authors));
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        static string IsInputValid(Func<string?> callback)
        {
            string? input;
            do
            {
                input = callback();
                if (!string.IsNullOrWhiteSpace(input)) break;
                Console.WriteLine("Invalid input!");
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        #region Scenarios implementation

        static void AddAuthor(Book book)
        {
            var author = IsInputValid(() =>
            {
                Console.Write("Enter the author's name to add: ");
                return Console.ReadLine();
            });

            book.AppendAuthor(author);
            Console.WriteLine(string.Join(", ", book.Authors));
            Console.WriteLine($"Author {author} added.");
        }

        static void RemoveAuthor(Book book)
        {
            var author = IsInputValid(() =>
            {
                Console.Write("Enter the author's name to remove: ");
                return Console.ReadLine();
            });
            if (book.RemoveAuthor(author)) Console.WriteLine($"Author {author} removed.");

            Console.WriteLine(string.Join(", ", book.Authors));
        }

        static void ConvertAuthorsToUpperCase(Book book)
        {
            book.AuthorsToUpperCase();
            Console.WriteLine(string.Join(", ", book.Authors));
            Console.WriteLine("All authors' names have been converted to uppercase.");
        }

        static void MoveAuthorUp(Book book)
        {
            var author = IsInputValid(() =>
            {
                Console.Write("Enter the author's name to move up: ");
                return Console.ReadLine();
            });
            Console.WriteLine(book.MoveAuthorUp(author)
                ? $"Author {author} moved up."
                : $"Unable to move {author} up.");
            Console.WriteLine(string.Join(", ", book.Authors));
        }

        static void MoveAuthorDown(Book book)
        {
            var author = IsInputValid(() =>
            {
                Console.Write("Enter the author's name to move down: ");
                return Console.ReadLine();
            });
            Console.WriteLine(book.MoveAuthorDown(author)
                ? $"Author {author} moved down."
                : $"Unable to move {author} down.");
            Console.WriteLine(string.Join(", ", book.Authors));
        }

        static void MoveAuthorToBeginning(Book book)
        {
            var author = IsInputValid(() =>
            {
                Console.Write("Enter the author's name to move to the beginning: ");
                return Console.ReadLine();
            });
            Console.WriteLine(book.MoveAuthorToBeginning(author)
                ? $"Author {author} moved to the beginning."
                : $"Unable to move {author} to the beginning.");
            Console.WriteLine(string.Join(", ", book.Authors));
        }

        static void MoveAuthorToEnd(Book book)
        {
            var author = IsInputValid(() =>
            {
                Console.Write("Enter the author's name to move to the end: ");
                return Console.ReadLine();
            });
            Console.WriteLine(book.MoveAuthorToEnd(author)
                ? $"Author {author} moved to the end."
                : $"Unable to move {author} to the end.");
            Console.WriteLine(string.Join(", ", book.Authors));
        }

        #endregion
    }
}