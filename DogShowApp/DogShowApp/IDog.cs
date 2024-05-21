namespace DogShowApp
{
    public interface IDog
    {
        string Name { get; }

        Breed Breed { get; }

        void AddPoint(float point);

        void AddPoint(string point);

        void AddPoint(int point);

        delegate void PointsAddedDelegate(object sender, EventArgs args);

        Statistics GetStatistics();

    }
}
