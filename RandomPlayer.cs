using System;
using System.Threading;

namespace GuessNumberGame
{
    class RandomPlayer : Player
    {
        public RandomPlayer()
        {
            name = PlayerName.Random.ToString();
        }

        public override void Roll(CancellationTokenSource cancelTokenSource)
        {
            Random random = new Random();
            for (int i = min; i < max; i++)
            {
                if (cancelTokenSource.IsCancellationRequested)
                {
                    Console.WriteLine($"Победил другой игрок, а не {name}");
                    return;
                }
                if (i == true_answer)
                {
                    cancelTokenSource.Cancel();
                    Console.WriteLine($"Победитель игрок {name}. Правильный ответ:{true_answer}");
                    return;
                }
                //Console.SetCursorPosition(0, 0);
                int value = random.Next(min, max);
                Console.WriteLine($"{name} :" + value);
                player_responses.Add(value);
            }


        }
    }
}
