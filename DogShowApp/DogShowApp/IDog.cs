namespace DogShowApp
{
    public interface IDog
    {
        string Name { get; set; }

        Breed Breed { get; set; }

        void AddPoint(float point);

        void AddPoint(string point);

        void AddPoint(int point);

        delegate void PointsAddedDelegate(object sender, EventArgs args);

        Statistics GetStatistics();
    }
}
