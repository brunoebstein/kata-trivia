using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;
using Trivia;
using UglyTrivia;

namespace TriviaTest
{
    [UseReporter(typeof(DiffReporter))]
    [TestFixture]
    public class GameRunnerTest
    {
        private static bool notAWinner;
        
        [Test]
        public static void FakeMain()
        {
            var stringBuild = new StringBuilder();
            var fakeRandom = new FakeRand(0, 1, 2, 4, 3, 8, 2, 3, 3, 3, 1, 2, 1, 3, 2, 0, 0, 8, 3, 5, 1, 7, 2, 7, 0, 4, 4, 6, 3, 3, 2, 4);

            Game aGame = new Game(str => stringBuild.AppendLine(str));

            aGame.add("Chet");
            aGame.add("Pat");
            aGame.add("Sue");

            GameRunner.RunGame(_ => fakeRandom.Next(), aGame);

            Approvals.Verify(stringBuild.ToString());
        }

        [Test]
        public static void FakeMain2()
        {
            var stringBuild = new StringBuilder();
            var fakeRandom = new FakeRand(1, 6, 4, 5, 1, 5, 4, 1, 0, 3, 1, 6, 3, 3, 2, 0, 1, 5, 1, 5, 4, 8, 3, 6, 3, 2, 2, 5, 3, 8, 3, 2);

            Game aGame = new Game(str => stringBuild.AppendLine(str));

            aGame.add("Chet");
            aGame.add("Pat");
            aGame.add("Sue");

            GameRunner.RunGame(_ => fakeRandom.Next(), aGame);

            Approvals.Verify(stringBuild.ToString());
        }

        [Test]
        public static void FakeMain3()
        {
            var stringBuild = new StringBuilder();
            var fakeRandom = new FakeRand(0, 6, 3, 6, 2, 6, 1, 3, 3, 2, 2, 2, 4, 2, 1, 0, 0, 3, 2, 2, 4, 2, 2, 8, 2, 4, 1, 7, 1, 3, 2, 4);

            Game aGame = new Game(str => stringBuild.AppendLine(str));

            aGame.add("Chet");
            aGame.add("Pat");
            aGame.add("Sue");

            GameRunner.RunGame(_ => fakeRandom.Next(), aGame);

            Approvals.Verify(stringBuild.ToString());
        }

        [Test]
        public static void FakeMain4()
        {
            var stringBuild = new StringBuilder();
            var fakeRandom = new FakeRand(3, 2, 0, 2, 4, 4, 0, 6, 3, 3, 4, 7, 0, 1, 2, 3, 0, 8, 2, 4, 2, 6, 3, 1, 4, 3, 3, 4, 3, 3, 2, 7, 3, 6);

            Game aGame = new Game(str => stringBuild.AppendLine(str));

            aGame.add("Chet");
            aGame.add("Pat");
            aGame.add("Sue");

            GameRunner.RunGame(_ => fakeRandom.Next(), aGame);

            Approvals.Verify(stringBuild.ToString());
        }

        [Test]
        public static void FakeMain5()
        {
            var stringBuild = new StringBuilder();
            var fakeRandom = new FakeRand(1, 8, 2, 3, 1, 4, 0, 5, 4, 4, 0, 8, 3, 1, 1, 6, 1, 0, 1, 6, 0, 1, 3, 0, 2, 7, 4, 6, 0, 6, 2, 2, 4, 1);

            Game aGame = new Game(str => stringBuild.AppendLine(str));

            aGame.add("Chet");
            aGame.add("Pat");
            aGame.add("Sue");

            GameRunner.RunGame(_ => fakeRandom.Next(), aGame);

            Approvals.Verify(stringBuild.ToString());
        }

        [Test]
        public static void NotEnoughQuestions()
        {
            Assert.Throws<System.InvalidOperationException>(() =>
            {
                GameRunner.StartGame(bound => bound == 9 ? 7 : 0);
            });
        }
    }


    public class FakeRand
    {
        private readonly int[] _values;
        private int index = 0;

        public FakeRand(params int[] values)
        {
            _values = values;
        }

        public int Next()
        {
            return _values[index++];
        }
    }
}
