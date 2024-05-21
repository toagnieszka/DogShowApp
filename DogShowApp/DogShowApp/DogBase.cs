using System;

namespace DogShowApp
{
    public abstract class DogBase : IDog
    {
        public delegate void PointsAddedDelegate(object sender, EventArgs args);

        public abstract event PointsAddedDelegate PointsAdded;

        public DogBase (string name, Breed breed)
        {
            this.Name = name;
            this.Breed = breed;
        }

        public DogBase()
        { }

        public string Name { get; set; }

        public Breed Breed { get; set; }

        public abstract void AddPoint(float point);

        public virtual void AddPoint(int  point)
        {
            float floatValue = (float)point;
            this.AddPoint(floatValue);
        }

        public virtual void AddPoint(string point)
        {
            if (float.TryParse(point, out float result))
            {
                this.AddPoint(result);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception("Invalid point value");
                Console.ResetColor();
            }
        }

        public abstract Statistics GetStatistics();

    }
}
