using System;

namespace DogShowApp
{
    public class DogInFile : DogBase
    {
        public override event PointsAddedDelegate PointsAdded;

        public DogInFile(string name, Breed breed) : base(name, breed)
        {

        }

        public DogInFile()
        { }

        const string fileName = "_points.txt";

        public override void AddPoint(float point)
        {

            if (point <= 10 && point >= 1)
            {
                using (var writer = File.AppendText(Name.ToUpper() + fileName))
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

            if (File.Exists(Name.ToUpper() + fileName))
            {
                using (var reader = File.OpenText(Name.ToUpper() + fileName))
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
                Console.ResetColor();
            }

            return statistics;
        }
    }
}
