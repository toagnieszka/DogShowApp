using DogShowApp;

DogInMemory dog = new DogInMemory("Jim", "Border");
DogInFile dog1 = new DogInFile("Moo", "Malinois");

dog.AddPoint(4);
dog.AddPoint(5.5f);
dog.AddPoint("0,5");
dog.AddPoint(5);

dog1.AddPoint(6);
dog1.AddPoint(7);

var statistics = dog.GetStatistics();
var statistics1 = dog1.GetStatistics();

Console.WriteLine(statistics1.Max);


