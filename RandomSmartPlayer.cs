using System;
using System.Collections.Generic;
using System.Threading;

namespace GuessNumberGame
{
    class RandomSmartPlayer : Player
    {
        public RandomSmartPlayer()
        {
            name = PlayerName.Random_Smart.ToString();
        }

        HashSet<int> answer_random_smart = new HashSet<int>
        {

        };

        public override void Roll(CancellationTokenSource cancelTokenSource)
        {
            Random random = new Random();

            do
                {
                    int value = random.Next(min, max);
                    if (cancelTokenSource.IsCancellationRequested)
                    {
                        Console.WriteLine($"Победил другой игрок, а не {name}");
                        return;
                    }
                    if (value == true_answer)
                    {
                        cancelTokenSource.Cancel();
                        Console.WriteLine($"Победитель игрок {name}. Правильный ответ:{true_answer}");
                        return;
                    }

                if (!answer_random_smart.Contains(value))
                {
                    answer_random_smart.Add(value);
                    Console.WriteLine($"{name} : {value}");
                    player_responses.Add(value);
                }
                
                } while (!answer_random_smart.Contains(true_answer));
        }
    }
}
