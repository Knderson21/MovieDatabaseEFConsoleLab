using MovieDatabaseEFConsoleLab;
using MovieDatabaseEFConsoleLab.Models;

Console.WriteLine("Hello welcome to the Retro Movie Store!\nTake a look through our selection:\n");

using (MovieDBContext context = new MovieDBContext())
{
    foreach(Movie m in context.Movies)
    {
        Console.WriteLine($"{m.Title} {m.Genre} {m.RunTime}");
    }
}

Console.WriteLine("Would you like to search by Title or Genre?");
string choice = Console.ReadLine();
if(choice == "Title")
{
    SearchByTitle();
}
if(choice == "Genre")
{
    SearchByGenre();
}

    static void SearchByGenre()
{
    Console.WriteLine("What genre of movie would you like?");
    string genreChoice = Console.ReadLine();
    using (MovieDBContext context = new MovieDBContext())
    {
        List<Movie> result = context.Movies.Where(m => m.Genre.ToLower() == genreChoice.ToLower()).ToList();

        foreach (Movie m in result)
        {
            Console.WriteLine($"{m.Title}");
        }
    }
}

static void SearchByTitle()
{
    Console.WriteLine("What movie would you like?");
    string movieChoice = Console.ReadLine();
    using (MovieDBContext context = new MovieDBContext())
    {
        List<Movie> result = context.Movies.Where(m => m.Title.ToLower() == movieChoice.ToLower()).ToList();

        foreach (Movie m in result)
        {
            Console.WriteLine($"You picked {m.Title}. Enjoy the film!");
        }
    }
}



static void AddMovies()
    {
        using (MovieDBContext context = new MovieDBContext())
        {
            List<Movie> list = new List<Movie>()
        {
            new Movie()
            {
                Title = "Ready Player One",
                Genre = "SciFi",
                RunTime = 140
            },
            new Movie()
            {
                Title = "Ghostbusters",
                Genre = "Comedy",
                RunTime = 105
            },
            new Movie()
            {
                Title = "The Breakfast Club",
                Genre = "Drama",
                RunTime = 97
            },
            new Movie()
            {
                Title = "Footloose",
                Genre = "Musical",
                RunTime = 110
            },
            new Movie()
            {
                Title = "Ferris Bueller's Day Off",
                Genre = "Comedy",
                RunTime = 103
            },
            new Movie()
            {
                Title = "Back to the Future",
                Genre = "SciFi",
                RunTime = 116
            },
            new Movie()
            {
                Title = "The Goonies",
                Genre = "Adventure",
                RunTime = 114
            },
            new Movie()
            {
                Title = "Stand by Me",
                Genre = "Adventure",
                RunTime = 89
            },
            new Movie()
            {
                Title = "Fast Times at Ridgemont High",
                Genre = "Comedy",
                RunTime = 90
            },
            new Movie()
            {
                Title = "Risky Business",
                Genre = "Comedy",
                RunTime = 99
            },
        };

            context.Movies.AddRange(list);
            context.SaveChanges();
        }
            
    }


