namespace DogShowApp
{
    public class DogInMemory : DogBase
    {
        private List<float> points = new List<float>();

        public override event PointsAddedDelegate PointsAdded;

        public DogInMemory(string name, string breed) : base(name, breed)
        {
        }

        public override void AddPoint(float point)
        {
            if (point >= 0 && point <= 10)
            {
                this.points.Add(point);
                
                if (PointsAdded != null)
                {
                    PointsAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Invalid point value");
            }
        }


        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var point in this.points)
            {
                statistics.AddPoint(point);
            }

            return statistics;
        }
    }
}
