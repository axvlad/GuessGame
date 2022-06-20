using System;
using System.Threading;

namespace GuessNumberGame 
{
    class DiligentPlayer : Player
    {
        public DiligentPlayer()
        {
            name = PlayerName.Diligent.ToString();
        }  

        public override void Roll(CancellationTokenSource cancelTokenSource)
        {
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
                Console.WriteLine($"{name}: :" + i);
                player_responses.Add(i);
            }
        }
    }
}
