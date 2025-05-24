using System;
using System.Linq;

class LibraryManager
{
    static void Main()
    {
        const int maxBooks = 5;
        string[] books = new string[maxBooks];

        while (true)
        {
            Console.WriteLine("Would you like to add or remove a book? (add/remove/exit)");
            string action = (Console.ReadLine() ?? "").Trim().ToLower();

            switch (action)
            {
                case "add":
                    AddBook(books);
                    break;
                case "remove":
                    RemoveBook(books);
                    break;
                case "exit":
                    return;
                default:
                    Console.WriteLine("Invalid action. Please type 'add', 'remove', or 'exit'.");
                    break;
            }

            DisplayBooks(books);
        }
    }
    static void SearchBook(string[] books)
    {
        Console.WriteLine("Enter the title to search:");
        string searchTitle = (Console.ReadLine() ?? "").Trim();

        if (string.IsNullOrWhiteSpace(searchTitle))
        {
            Console.WriteLine("Search term cannot be empty.");
            return;
        }

        bool found = false;
        foreach (var book in books.Where(book => !string.IsNullOrEmpty(book) && book.Contains(searchTitle, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine($"Found: {book}");
            found = true;
        }

        if (!found)
        {
            Console.WriteLine("No matching books found.");
        }
    }
    static void AddBook(string[] books)
    {
        int emptyIndex = Array.FindIndex(books, string.IsNullOrEmpty);
        if (emptyIndex == -1)
        {
            Console.WriteLine("The library is full. No more books can be added.");
            return;
        }

        Console.WriteLine("Enter the title of the book to add:");
        string newBook = (Console.ReadLine() ?? "").Trim();

        if (string.IsNullOrWhiteSpace(newBook))
        {
            Console.WriteLine("Book title cannot be empty.");
            return;
        }

        // Case-insensitive duplicate check
        if (Array.Exists(books, b => !string.IsNullOrEmpty(b) && b.Equals(newBook, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("This book is already in the library.");
            return;
        }

        books[emptyIndex] = newBook;
        Console.WriteLine($"Book '{newBook}' added.");
    }

    static void RemoveBook(string[] books)
    {
        if (Array.TrueForAll(books, string.IsNullOrEmpty))
        {
            Console.WriteLine("The library is empty. No books to remove.");
            return;
        }

        Console.WriteLine("Enter the title of the book to remove:");
        string removeBook = (Console.ReadLine() ?? "").Trim();

        if (string.IsNullOrWhiteSpace(removeBook))
        {
            Console.WriteLine("Book title cannot be empty.");
            return;
        }

        // Case-insensitive search for removal
        int index = Array.FindIndex(books, b => !string.IsNullOrEmpty(b) && b.Equals(removeBook, StringComparison.OrdinalIgnoreCase));
        if (index != -1)
        {
            books[index] = "";
            Console.WriteLine($"Book '{removeBook}' removed.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    static void DisplayBooks(string[] books)
    {
        Console.WriteLine("Available books:");
        bool anyBook = false;
        foreach (var book in books)
        {
            if (!string.IsNullOrEmpty(book))
            {
                Console.WriteLine(book);
                anyBook = true;
            }
        }
        if (!anyBook)
        {
            Console.WriteLine("(none)");
        }
    }
}