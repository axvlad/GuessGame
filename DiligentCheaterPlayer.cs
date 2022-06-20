using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GuessNumberGame
{
    class DiligentCheater : Player
    {
        public DiligentCheater()
        {
            name = PlayerName.Diligent_Cheater.ToString();
        }

        public HashSet<int> spisok_diligent_cheater = new HashSet<int>
        {

        };


        public override void Roll(CancellationTokenSource cancelTokenSource)
        {
            Random random = new Random();
            
            do
            {
                int value = random.Next(min, max);
                spisok_diligent_cheater.Add(value);
            } while (spisok_diligent_cheater.Count != max);

            var hash_result = spisok_diligent_cheater.Except(player_responses);

            foreach (var item in hash_result)
            {
                if (item <= max)
                    Console.WriteLine(spisok_diligent_cheater);
            }
        }
    }
}
