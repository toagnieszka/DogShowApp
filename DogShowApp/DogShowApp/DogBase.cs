namespace DogShowApp
{
    public abstract class DogBase : IDog
    {
        public delegate void PointsAddedDelegate(object sender, EventArgs args);

        public abstract event PointsAddedDelegate PointsAdded;

        public DogBase (string name, string breed)
        {
            this.Name = name;
            this.Breed = breed;
        }

        public string Name { get; private set; }

        public string Breed { get; private set; }

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
                  throw new Exception("Invalid point value");
            }
        }

        public abstract Statistics GetStatistics();

    }
}
