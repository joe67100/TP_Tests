using MorpionApp;

namespace MorpionAppTest
{
    public class UnitTest1
    {
        public static Morpion morpion = new Morpion();
        
        [Fact]
        public void Test1()
        {
            Assert.Equal(2, 1+1);
        }
    }
}