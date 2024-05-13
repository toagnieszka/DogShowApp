namespace DogShowApp
{
    public class DogInFile : DogBase
    {
        public override event PointsAddedDelegate PointsAdded;

        public DogInFile(string name, string breed) : base(name, breed)
        {
        }

        const string fileName = "points.txt";

        public override void AddPoint(float point)
        {
            if (point <= 10 && point >= 1)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(point);
                }

                if (PointsAdded != null)
                {
                    PointsAdded(this, new EventArgs());
                }
            }
            else 
            {
                throw new Exception("Wrong point value");
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {

                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        if (float.TryParse(line, out float result))
                        {
                            statistics.AddPoint(result);
                            line = reader.ReadLine();
                        }
                        else
                        {
                            throw new Exception("Line is not float");
                        }

                    }
                }
            }
            else
            {
                throw new Exception("File not exist");
            }

            return statistics;
        }
    }
}
