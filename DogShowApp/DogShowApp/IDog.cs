namespace DogShowApp
{
    public interface IDog
    {
        string Name { get; }

        string Breed { get; }

        void AddPoint(float point);

        void AddPoint(string point);

        void AddPoint(int point);

        Statistics GetStatistics();

    }
}
