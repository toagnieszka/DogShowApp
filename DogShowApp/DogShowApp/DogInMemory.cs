namespace DogShowApp
{
    public class DogInMemory : DogBase
    {
        private List<float> points = new List<float>();

        public override event PointsAddedDelegate PointsAdded;

        public DogInMemory(string name, Breed breed) : base(name, breed)
        {
        }

        public DogInMemory()
        { }

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
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception("Invalid point value");
                Console.ResetColor();
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

