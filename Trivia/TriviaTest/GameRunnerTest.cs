using System;
using System.Collections.Generic;
using System.IO;
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

        public static void VerifyConsoleOutput(Action action)
        {
            var oldOut = Console.Out;
            try
            {
                using (var writer = new StringWriter())
                {
                    Console.SetOut(writer);

                    action();

                    Approvals.Verify(writer.ToString());
                }
            }
            finally
            {
                Console.SetOut(oldOut);
            }
        }

        [Test]
        public static void GoldenMaster()
        {
            VerifyConsoleOutput(() => { Console.WriteLine("ok"); });
        }

        [Test]
        public static void FakeMain()
        {
            VerifyConsoleOutput(() =>
            {
                var fakeRandom = new FakeRand(0, 1, 2, 4, 3, 8, 2, 3, 3, 3, 1, 2, 1, 3, 2, 0, 0, 8, 3, 5, 1, 7, 2, 7, 0, 4, 4, 6, 3, 3, 2, 4);
                GameRunner.StartGame(_ => fakeRandom.Next());
            });
        }

        [Test]
        public static void FakeMain2()
        {
            VerifyConsoleOutput(() =>
            {
                var fakeRandom = new FakeRand(1, 6, 4, 5, 1, 5, 4, 1, 0, 3, 1, 6, 3, 3, 2, 0, 1, 5, 1, 5, 4, 8, 3, 6, 3, 2, 2, 5, 3, 8, 3, 2);
                GameRunner.StartGame(_ => fakeRandom.Next());
            });
        }

        [Test]
        public static void FakeMain3()
        {
            VerifyConsoleOutput(() =>
            {
                var fakeRandom = new FakeRand(0, 6, 3, 6, 2, 6, 1, 3, 3, 2, 2, 2, 4, 2, 1, 0, 0, 3, 2, 2, 4, 2, 2, 8, 2, 4, 1, 7, 1, 3, 2, 4);
                GameRunner.StartGame(_ => fakeRandom.Next());
            });
        }

        [Test]
        public static void FakeMain4()
        {
            VerifyConsoleOutput(() =>
            {
                var fakeRandom = new FakeRand(3, 2, 0, 2, 4, 4, 0, 6, 3, 3, 4, 7, 0, 1, 2, 3, 0, 8, 2, 4, 2, 6, 3, 1, 4, 3, 3, 4, 3, 3, 2, 7, 3, 6);
                GameRunner.StartGame(_ => fakeRandom.Next());
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
