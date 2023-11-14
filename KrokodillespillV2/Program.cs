// See https://aka.ms/new-console-template for more information

namespace KrokodillespillV2
{
    class Program
    {
        private static void Main(string[] args)
        {
            NewRound();
        }

        static class GameState
        {
            public static int points = 0;
        }

        private static void NewRound()
        {
            int numberOne = new Random().Next(11);
            int numberTwo = new Random().Next(11);
            char answer = AskForChar(numberOne, numberTwo);
            if (CheckAnswer(numberOne, numberTwo, answer))
            {
                GameState.points++;
                Console.WriteLine($"Riktig svar! {GameState.points} poeng.");
            }
            else
            {
                Console.WriteLine($"Feil svar! {GameState.points} poeng.");
            }
            NewRound();
        }

        private static char AskForChar(int numberOne, int numberTwo)
        {
            Console.Write($"{numberOne}__{numberTwo}: ");
            string answerStr = Console.ReadLine();
            char answer;
            while (!char.TryParse(answerStr, out answer))
            {
                Console.Write("Ugyldig tegn. Mulige svar er <, > eller =.");
                answerStr = Console.ReadLine();
            }

            return answer;
        }

        private static bool CheckAnswer(int numberOne, int numberTwo, char answer)
        {
            return (numberOne > numberTwo && answer.Equals('>'))
                   || (numberOne < numberTwo && answer.Equals('<'))
                   || (numberOne == numberTwo && answer.Equals('='));
        }
    }
}