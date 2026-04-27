using Domain.Models;
using Infrastructure.Services;

var movieservice = new MovieService();
while (true)
{
    Console.WriteLine("\nMENU");
    Console.WriteLine("1. Show Movies");
    Console.WriteLine("2. Add Movie");
    Console.WriteLine("3. Update Movie");
    Console.WriteLine("4. Delete Movie");
    Console.WriteLine("5. Get Movie By Id");
    Console.WriteLine("0. Exit");
    Console.Write("Choose: ");

    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            GetMovies();
            break;

        case 2:
            AddMovie();
            break;

        case 3:
            UpdateMovie();
            break;

        case 4:
            DeleteMovie();
            break;

        case 5:
            GetMovieById();
            break;

        case 0:
            return;

        default:
            Console.WriteLine("Failed choice!");
            break;
    }
}

void GetMovies()
{
    var movies = movieservice.GetAllMovies();

    if (movies.Count == 0)
    {
        Console.WriteLine("No movies found");
        return;
    }

    foreach (var m in movies)
    {
        Console.WriteLine($"{m.Id} | {m.Title} | {m.Director} | {m.Year} | {m.Genre}");
    }
}

void AddMovie()
{
    var movie = new Movie();

    Console.Write("Title: ");
    movie.Title = Console.ReadLine();

    Console.Write("Director: ");
    movie.Director = Console.ReadLine();

    Console.Write("Year: ");
    movie.Year = Convert.ToInt32(Console.ReadLine());

    Console.Write("Duration: ");
    movie.Duration = Convert.ToInt32(Console.ReadLine());

    Console.Write("Genre: ");
    movie.Genre = Console.ReadLine();

    Console.Write("Description: ");
    movie.Description = Console.ReadLine();

    movieservice.AddMovie(movie);

    Console.WriteLine("Movie added!");
}

void UpdateMovie()
{
    var movie = new Movie();

    Console.Write("Id: ");
    movie.Id = Convert.ToInt32(Console.ReadLine());

    Console.Write("Title: ");
    movie.Title = Console.ReadLine();

    Console.Write("Director: ");
    movie.Director = Console.ReadLine();

    Console.Write("Year: ");
    movie.Year = Convert.ToInt32(Console.ReadLine());

    Console.Write("Duration: ");
    movie.Duration = Convert.ToInt32(Console.ReadLine());

    Console.Write("Genre: ");
    movie.Genre = Console.ReadLine();

    Console.Write("Description: ");
    movie.Description = Console.ReadLine();

    movieservice.UpdateMovie(movie);

    Console.WriteLine("Movie updated!");
}

void DeleteMovie()
{
    Console.Write("Id: ");
    int id = Convert.ToInt32(Console.ReadLine());

    movieservice.DeleteMovie(id);

    Console.WriteLine("Movie deleted!");
}

void GetMovieById()
{
    Console.Write("Id: ");
    int id = Convert.ToInt32(Console.ReadLine());

    var movie = movieservice.GetMovieById(id);

    if (movie == null)
    {
        Console.WriteLine("Movie not found");
        return;
    }

    Console.WriteLine($"{movie.Id} | {movie.Title} | {movie.Director} | {movie.Year} | {movie.Genre} | {movie.Description}");
}





// var screeningService = new ScreeningService();

// while (true)
// {
//     Console.WriteLine("\nSCREENING MENU");
//     Console.WriteLine("1. Show Screenings");
//     Console.WriteLine("2. Add Screening");
//     Console.WriteLine("3. Update Screening");
//     Console.WriteLine("4. Delete Screening");
//     Console.WriteLine("5. Get Screening By Id");
//     Console.WriteLine("0. Exit");
//     Console.Write("Choose: ");

//     int choice = Convert.ToInt32(Console.ReadLine());

//     switch (choice)
//     {
//         case 1:
//             GetScreenings();
//             break;

//         case 2:
//             AddScreening();
//             break;

//         case 3:
//             UpdateScreening();
//             break;

//         case 4:
//             DeleteScreening();
//             break;

//         case 5:
//             GetScreeningById();
//             break;

//         case 0:
//             return;

//         default:
//             Console.WriteLine("Wrong choice!");
//             break;
//     }
// }

// void GetScreenings()
// {
//     var screenings = screeningService.GetAllScreenings();

//     if (screenings.Count == 0)
//     {
//         Console.WriteLine("No screenings found");
//         return;
//     }

//     foreach (var s in screenings)
//     {
//         Console.WriteLine($"{s.Id} | Movie:{s.MovieId} | Theater:{s.TheaterId} | {s.ScreeningTime} | {s.TicketPrice} | Seats:{s.AvailableSeats}");
//     }
// }

// void AddScreening()
// {
//     var screening = new Screening();

//     Console.Write("Movie Id: ");
//     screening.MovieId = Convert.ToInt32(Console.ReadLine());

//     Console.Write("Theater Id: ");
//     screening.TheaterId = Convert.ToInt32(Console.ReadLine());

//     Console.Write("Screening Time (yyyy-MM-dd HH:mm): ");
//     screening.ScreeningTime = Convert.ToDateTime(Console.ReadLine());

//     Console.Write("Ticket Price: ");
//     screening.TicketPrice = Convert.ToDecimal(Console.ReadLine());

//     Console.Write("Available Seats: ");
//     screening.AvailableSeats = Convert.ToInt32(Console.ReadLine());

//     screeningService.AddScreening(screening);

//     Console.WriteLine("Screening added!");
// }

// void UpdateScreening()
// {
//     var screening = new Screening();

//     Console.Write("Id: ");
//     screening.Id = Convert.ToInt32(Console.ReadLine());

//     Console.Write("Movie Id: ");
//     screening.MovieId = Convert.ToInt32(Console.ReadLine());

//     Console.Write("Theater Id: ");
//     screening.TheaterId = Convert.ToInt32(Console.ReadLine());

//     Console.Write("Screening Time (yyyy-MM-dd HH:mm): ");
//     screening.ScreeningTime = Convert.ToDateTime(Console.ReadLine());

//     Console.Write("Ticket Price: ");
//     screening.TicketPrice = Convert.ToDecimal(Console.ReadLine());

//     Console.Write("Available Seats: ");
//     screening.AvailableSeats = Convert.ToInt32(Console.ReadLine());

//     screeningService.UpdateScreening(screening);

//     Console.WriteLine("Screening updated!");
// }

// void DeleteScreening()
// {
//     Console.Write("Id: ");
//     int id = Convert.ToInt32(Console.ReadLine());

//     screeningService.DeleteScreening(id);

//     Console.WriteLine("Screening deleted!");
// }

// void GetScreeningById()
// {
//     Console.Write("Id: ");
//     int id = Convert.ToInt32(Console.ReadLine());

//     var screening = screeningService.GetScreeningById(id);

//     if (screening == null)
//     {
//         Console.WriteLine("Screening not found");
//         return;
//     }

//     Console.WriteLine($"{screening.Id} | Movie:{screening.MovieId} | Theater:{screening.TheaterId} | {screening.ScreeningTime} | {screening.TicketPrice} | Seats:{screening.AvailableSeats}");
// }






// var theaterService = new TheaterService();

// while (true)
// {
//     Console.WriteLine("\nTHEATER MENU");
//     Console.WriteLine("1. Show Theaters");
//     Console.WriteLine("2. Add Theater");
//     Console.WriteLine("3. Update Theater");
//     Console.WriteLine("4. Delete Theater");
//     Console.WriteLine("5. Get Theater By Id");
//     Console.WriteLine("0. Exit");
//     Console.Write("Choose: ");

//     int choice = Convert.ToInt32(Console.ReadLine());

//     switch (choice)
//     {
//         case 1:
//             GetTheaters();
//             break;

//         case 2:
//             AddTheater();
//             break;

//         case 3:
//             UpdateTheater();
//             break;

//         case 4:
//             DeleteTheater();
//             break;

//         case 5:
//             GetTheaterById();
//             break;

//         case 0:
//             return;

//         default:
//             Console.WriteLine("Wrong choice!");
//             break;
//     }
// }

// void GetTheaters()
// {
//     var theaters = theaterService.GetAllTheaters();

//     if (theaters.Count == 0)
//     {
//         Console.WriteLine("No theaters found");
//         return;
//     }

//     foreach (var t in theaters)
//     {
//         Console.WriteLine($"{t.Id} | {t.Name} | {t.Location} | {t.Manager} | {t.Phone} | {t.Capacity} | {t.Website}");
//     }
// }

// void AddTheater()
// {
//     var theater = new Theater();

//     Console.Write("Name: ");
//     theater.Name = Console.ReadLine();

//     Console.Write("Location: ");
//     theater.Location = Console.ReadLine();

//     Console.Write("Manager: ");
//     theater.Manager = Console.ReadLine();

//     Console.Write("Phone: ");
//     theater.Phone = Console.ReadLine();

//     Console.Write("Capacity: ");
//     theater.Capacity = Convert.ToInt32(Console.ReadLine());

//     Console.Write("Website: ");
//     theater.Website = Console.ReadLine();

//     theaterService.AddTheater(theater);

//     Console.WriteLine("Theater added!");
// }

// void UpdateTheater()
// {
//     var theater = new Theater();

//     Console.Write("Id: ");
//     theater.Id = Convert.ToInt32(Console.ReadLine());

//     Console.Write("Name: ");
//     theater.Name = Console.ReadLine();

//     Console.Write("Location: ");
//     theater.Location = Console.ReadLine();

//     Console.Write("Manager: ");
//     theater.Manager = Console.ReadLine();

//     Console.Write("Phone: ");
//     theater.Phone = Console.ReadLine();

//     Console.Write("Capacity: ");
//     theater.Capacity = Convert.ToInt32(Console.ReadLine());

//     Console.Write("Website: ");
//     theater.Website = Console.ReadLine();

//     theaterService.UpdateTheater(theater);

//     Console.WriteLine("Theater updated!");
// }

// void DeleteTheater()
// {
//     Console.Write("Id: ");
//     int id = Convert.ToInt32(Console.ReadLine());

//     theaterService.DeleteTheater(id);

//     Console.WriteLine("Theater deleted!");
// }

// void GetTheaterById()
// {
//     Console.Write("Id: ");
//     int id = Convert.ToInt32(Console.ReadLine());

//     var theater = theaterService.GetTheaterById(id);

//     if (theater == null)
//     {
//         Console.WriteLine("Theater not found");
//         return;
//     }

//     Console.WriteLine($"{theater.Id} | {theater.Name} | {theater.Location} | {theater.Manager} | {theater.Phone} | {theater.Capacity} | {theater.Website}");
// }





// var ticketService = new TicketService();

// while (true)
// {
//     Console.WriteLine("\nTICKET MENU");
//     Console.WriteLine("1. Show Tickets");
//     Console.WriteLine("2. Add Ticket");
//     Console.WriteLine("3. Update Ticket");
//     Console.WriteLine("4. Delete Ticket");
//     Console.WriteLine("5. Get Ticket By Id");
//     Console.WriteLine("6. Buy Ticket");
//     Console.WriteLine("0. Exit");
//     Console.Write("Choose: ");

//     int choice = Convert.ToInt32(Console.ReadLine());

//     switch (choice)
//     {
//         case 1:
//             GetTickets();
//             break;

//         case 2:
//             AddTicket();
//             break;

//         case 3:
//             UpdateTicket();
//             break;

//         case 4:
//             DeleteTicket();
//             break;

//         case 5:
//             GetTicketById();
//             break;

//         case 6:
//             BuyTicket();
//             break;

//         case 0:
//             return;

//         default:
//             Console.WriteLine("Wrong choice!");
//             break;
//     }
// }

// void GetTickets()
// {
//     var tickets = ticketService.GetAllTickets();

//     if (tickets.Count == 0)
//     {
//         Console.WriteLine("No tickets found");
//         return;
//     }

//     foreach (var t in tickets)
//     {
//         Console.WriteLine($"{t.Id} | {t.ScreeningId} | {t.CustomerName} | {t.SeatNumber} | {t.PurchaseTime} | {t.Price} | {t.PaymentMethod}");
//     }
// }

// void AddTicket()
// {
//     var ticket = new Ticket();

//     Console.Write("Screening Id: ");
//     ticket.ScreeningId = Convert.ToInt32(Console.ReadLine());

//     Console.Write("Customer Name: ");
//     ticket.CustomerName = Console.ReadLine();

//     Console.Write("Seat Number: ");
//     ticket.SeatNumber = Console.ReadLine();

//     Console.Write("Purchase Time: ");
//     ticket.PurchaseTime = Convert.ToDateTime(Console.ReadLine());

//     Console.Write("Price: ");
//     ticket.Price = Convert.ToDecimal(Console.ReadLine());

//     Console.Write("Payment Method: ");
//     ticket.PaymentMethod = Console.ReadLine();

//     ticketService.AddTicket(ticket);

//     Console.WriteLine("Ticket added!");
// }

// void UpdateTicket()
// {
//     var ticket = new Ticket();

//     Console.Write("Id: ");
//     ticket.Id = Convert.ToInt32(Console.ReadLine());

//     Console.Write("Screening Id: ");
//     ticket.ScreeningId = Convert.ToInt32(Console.ReadLine());

//     Console.Write("Customer Name: ");
//     ticket.CustomerName = Console.ReadLine();

//     Console.Write("Seat Number: ");
//     ticket.SeatNumber = Console.ReadLine();

//     Console.Write("Purchase Time: ");
//     ticket.PurchaseTime = Convert.ToDateTime(Console.ReadLine());

//     Console.Write("Price: ");
//     ticket.Price = Convert.ToDecimal(Console.ReadLine());

//     Console.Write("Payment Method: ");
//     ticket.PaymentMethod = Console.ReadLine();

//     ticketService.UpdateTicket(ticket);

//     Console.WriteLine("Ticket updated!");
// }

// void DeleteTicket()
// {
//     Console.Write("Id: ");
//     int id = Convert.ToInt32(Console.ReadLine());

//     ticketService.DeleteTicket(id);

//     Console.WriteLine("Ticket deleted!");
// }

// void GetTicketById()
// {
//     Console.Write("Id: ");
//     int id = Convert.ToInt32(Console.ReadLine());

//     var ticket = ticketService.GetTicketById(id);

//     if (ticket == null)
//     {
//         Console.WriteLine("Ticket not found");
//         return;
//     }

//     Console.WriteLine($"{ticket.Id} | {ticket.ScreeningId} | {ticket.CustomerName} | {ticket.SeatNumber} | {ticket.PurchaseTime} | {ticket.Price} | {ticket.PaymentMethod}");
// }

// void BuyTicket()
// {
//     Console.Write("Screening Id: ");
//     int screeningId = Convert.ToInt32(Console.ReadLine());

//     Console.Write("Customer Name: ");
//     string customerName = Console.ReadLine();

//     Console.Write("Seat Number: ");
//     string seatNumber = Console.ReadLine();

//     Console.Write("Price: ");
//     decimal price = Convert.ToDecimal(Console.ReadLine());
// }