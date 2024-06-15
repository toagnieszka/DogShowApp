using DogShowApp;

void GetDog(IDog dog)
{
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine("\n Wprowadź imię psa:\n");
    Console.ResetColor();
    var name = Console.ReadLine();
    dog.Name = name.ToUpper();

    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine("\nWprowadź rasę psa poprzez wybranie odpowiadjącego jej numeru\n\u001b[36m 1 - Kelpie\n 2 - Owczarek belgijski\n " +
        "3 - Owczarek niemiecki\n 4 - Border Collie\n 5 - Mudi\n");
    Console.ResetColor();
    var breed = Console.ReadLine();

    switch (breed)
    {
        case "1":
            dog.Breed = Breed.Kelpie;
            break;
        case "2":
            dog.Breed = Breed.BelgianMalinois;
            break;
        case "3":
            dog.Breed = Breed.GermanShepherd;
            break;
        case "4":
            dog.Breed = Breed.BorderCollie;
            break;
        case "5":
            dog.Breed = Breed.Mudi;
            break;
    }

}

void WriteDogInfo(IDog dog)
{
    var statistics = dog.GetStatistics();

    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine($"\nOto statystyki dla psa o imieniu {dog.Name} rasy {dog.Breed}:\n");
    Console.WriteLine($"Najwyższa nota: \u001b[33m{statistics.Max}\u001b[35m");
    Console.WriteLine($"Najniższa nota: \u001b[33m{statistics.Min}\u001b[35m");
    Console.WriteLine($"Średnia punktów: \u001b[33m{statistics.Average}\u001b[35m");
    Console.WriteLine($"Finalna ocena: \u001b[33m{statistics.FinalTitle}\u001b[35m");
    Console.ResetColor();
}

void PointAdded(object sender, EventArgs args)
{
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("Ocenę dodano");
    Console.ResetColor();
}


Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.WriteLine("Witaj w programie do oceny psów wystawowych\n");
Console.WriteLine("Jeżeli chcesz dodać ocenę w pamięci wpisz: \u001b[31m 1 \u001b[34m \nJeżeli chcesz dodać ocenę do pliku wpisz: \u001b[31m 2\n");
Console.ResetColor();

var number = Console.ReadLine();
var activeApp = false;


if (number == "1")
{
    var dog = new DogInMemory();
    dog.PointsAdded += PointAdded;
    GetDog(dog);

    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("\n*Jeżeli chcesz wyświetlić statystyki wpisz: \u001b[31m Q");
    Console.ResetColor();

    while (!activeApp)
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("\nWprowadź ocenę dla psa (od 1 do 10):");
        Console.ResetColor();
        var input = Console.ReadLine();

        if (input == "q" || input == "Q")
        {
            break;
        }

        try
        {
            dog.AddPoint(input);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    WriteDogInfo(dog);
}
else if (number == "2")
{
    var dog = new DogInFile();
    dog.PointsAdded += PointAdded;
    GetDog(dog);

    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("\n*Jeżeli chcesz wyświetlić statystyki wpisz: \u001b[31m Q");
    Console.ResetColor();

    while (!activeApp)
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("\nWprowadź ocenę dla psa (od 1 do 10):");
        Console.ResetColor();
        var input = Console.ReadLine();

        if (input == "q" || input == "Q")
        {
            break;
        }

        try
        {
            dog.AddPoint(input);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    WriteDogInfo(dog);
}
