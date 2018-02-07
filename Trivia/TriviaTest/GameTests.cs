using NUnit.Framework;
using UglyTrivia;

namespace TriviaTest
{
    public class GameTests
    {
        [Test]
        public static void NotEnoughPlayer()
        {
            var aGame = new Game();

            aGame.add("Pat");

            Assert.IsFalse(aGame.isPlayable());
        }

        [Test]
        public static void HasEnoughPlayer()
        {
            var aGame = new Game();

            aGame.add("Chet");
            aGame.add("Pat");

            Assert.IsTrue(aGame.isPlayable());
        }
    }
}