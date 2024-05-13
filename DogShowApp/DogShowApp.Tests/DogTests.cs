namespace DogShowApp.Tests
{
    public class Tests
    {
        [Test]
        public void WhenPointsAdded_ThenShowCorrectMaxValue()
        {
            //arrange
            var dog = new DogInMemory("Jim", "Border");
            dog.AddPoint(5);
            dog.AddPoint(7.5f);
            dog.AddPoint("10");

            //act
            var statistics = dog.GetStatistics();

            //assert
            Assert.AreEqual(10, statistics.Max);
        }

        [Test]
        public void WhenPointsAdded_ThenShowCorrectMinValue()
        {
            //arrange
            var dog = new DogInMemory("River", "Collie");
            dog.AddPoint(3);
            dog.AddPoint(9.5f);
            dog.AddPoint("8");

            //act
            var statistics = dog.GetStatistics();

            //assert
            Assert.AreEqual(3, statistics.Min);
        }

        [Test]
        public void WhenPointsAdded_ThenShowCorrectAverageValue()
        {
            //arrange
            var dog = new DogInMemory("Luk", "Corgi");
            dog.AddPoint(9);
            dog.AddPoint(3.0f);
            dog.AddPoint("9");

            //act
            var statistics = dog.GetStatistics();

            //assert
            Assert.AreEqual(7, statistics.Average);
        }

        [Test]
        public void WhenPointsAdded_ThenShowCorrectFinalTitle()
        {
            //arrange
            var dog = new DogInMemory("Moo", "Papillon");
            dog.AddPoint(10);
            dog.AddPoint(9.5f);
            dog.AddPoint("9,66");

            //act
            var statistics = dog.GetStatistics();

            //assert
            Assert.AreEqual("Doskona³a", statistics.FinalTitle);
        }
    }
}