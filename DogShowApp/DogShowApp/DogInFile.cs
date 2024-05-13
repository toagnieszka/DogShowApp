namespace DogShowApp
{
    public class DogInFile : DogBase
    {
        public DogInFile(string name, string breed) : base(name, breed)
        {
        }

        const string fileName = "points.txt";

        public override void AddPoint(float point)
        {
            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine(point);
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
