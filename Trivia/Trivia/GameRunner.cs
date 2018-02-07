using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UglyTrivia;

namespace Trivia
{
    public class GameRunner
    {
        private static bool notAWinner;


        public static void Main(String[] args)
        {
            List<int> randomGeneratedNumbers = new List<int>();
            Random rand = new Random();
            StartGame(maxNumber =>
            {
                var num = rand.Next(maxNumber);
                randomGeneratedNumbers.Add(num);
                return num;
            });

            Console.WriteLine(string.Join(",",randomGeneratedNumbers));
        }

        public static void StartGame(Func<int, int> getNextRandomValue)
        {
            Game aGame = new Game();

            aGame.add("Chet");
            aGame.add("Pat");
            aGame.add("Sue");

            RunGame(getNextRandomValue, aGame);
        }

        public static void RunGame(Func<int, int> rollTheDice, Game aGame)
        {
            if (!aGame.isPlayable()) return;

            do
            {
                aGame.roll(rollTheDice(5) + 1);

                if (rollTheDice(9) == 7)
                {
                    notAWinner = aGame.wrongAnswer();
                }
                else
                {
                    notAWinner = aGame.wasCorrectlyAnswered();
                }
            } while (notAWinner);
        }
    }

}

