using System;
using System.Collections.Generic;
using System.Threading;

namespace GuessNumberGame
{
    class SuperCheaterPlayer : Player
    {
        public SuperCheaterPlayer()
        {
            name = PlayerName.Super_Cheater.ToString();
        }

        public HashSet<int> super_spisok_cheater = new HashSet<int>
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
                if (!player_responses.Contains(value) && !super_spisok_cheater.Contains(value))
                {
                    Console.WriteLine($"{name} : {value}");
                    super_spisok_cheater.Add(value);
                }

            } while (!super_spisok_cheater.Contains(true_answer));
        }
    }
}
