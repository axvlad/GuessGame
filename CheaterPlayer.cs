using System;
using System.Collections.Generic;
using System.Threading;

namespace GuessNumberGame
{
    class CheaterPlayer : Player
    {
        public CheaterPlayer()
        {
            name = PlayerName.Cheater.ToString();
        }

        public HashSet<int> spisok_cheater = new HashSet<int>
        {

        };

        public override void Roll(CancellationTokenSource cancelTokenSource)
        {
            Random random = new Random();
            
            do
            {
                int value = random.Next(min, max);
                // Вводим токены
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

                // Проверка хешсета из абстрактного класса
                if (!player_responses.Contains(value) && !spisok_cheater.Contains(value))
                {
                    Console.WriteLine($"{name} : {value}");
                    spisok_cheater.Add(value);
                    player_responses.Add(value);
                }


            } while (!spisok_cheater.Contains(true_answer));

            //var hash_result = spisok_cheater.Except(player_responses);

            /*
            foreach (var item in spisok_cheater)
            {
                //Console.SetCursorPosition(40, 0);
                if (item <= max)
                
                Console.WriteLine("Cheater :" + item);
            }
            */
            
        }
    }
}
