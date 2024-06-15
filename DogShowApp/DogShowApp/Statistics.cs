namespace DogShowApp
{
    public class Statistics
    {
        public float Min { get; set; }

        public float Max { get; set; }

        public float Sum { get; set; }

        public int Count { get; set; }

        public float Average
        {
            get
            {
                return this.Sum / this.Count;
            }
        }

        public string FinalTitle
        {
            get
            {
                switch (this.Average)
                {
                    case var average when average >= 9:
                        return "Doskonała";
                    case var average when average >= 7:
                        return "Bardzo dobra";
                    case var average when average >= 5:
                        return "Dobra";
                    case var average when average >= 3:
                        return "Dostateczna";
                    default:
                        return "Dyskwalifikująca";
                }
            }
        }

        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
            this.Min = float.MaxValue;
            this.Max = float.MinValue;
        }

        public void AddPoint(float point)
        {
            this.Count++;
            this.Sum += point;
            this.Min = Math.Min(this.Min, point);
            this.Max = Math.Max(this.Max, point);
        }
    }
}
