namespace DogShowApp
{
    public class DogInFile : DogBase
    {
        public override event PointsAddedDelegate PointsAdded;

        public DogInFile()
        { 
        }

        private string FullFileName 
        { get
            { return Name.ToUpper() + "_" + Breed + fileName; }
        }

        const string fileName = "_points.txt";

        public override void AddPoint(float point)
        {

            if (point <= 10 && point >= 1)
            {
                using (var writer = File.AppendText(FullFileName))
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
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception("Invalid point value");
                Console.ResetColor();
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            if (File.Exists(FullFileName))
            {
                using (var reader = File.OpenText(FullFileName))
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
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new Exception("Line is not float");
                            Console.ResetColor();
                        }
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception("File not exist");
            }
            return statistics;
        }
    }
}
