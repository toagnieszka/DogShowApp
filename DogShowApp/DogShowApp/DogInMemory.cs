namespace DogShowApp
{
    public class DogInMemory : DogBase
    {
        private List<float> points = new List<float>();

        public DogInMemory(string name, string breed) : base(name, breed)
        {
        }

        public override void AddPoint(float point)
        {
            if (point >= 0 && point <= 10)
            {
                this.points.Add(point);
            }
            else
            {
                //throw new Exception(Console.WriteLine("Invalid point value"));
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
