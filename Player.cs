using System.Collections.Generic;
using System.Threading;

namespace GuessNumberGame
{
    abstract class Player
    {
        public string name;
        public const int min = 0;
        public const int max = 40;
        public const int true_answer = (max - min) / 2;

        public abstract void Roll(CancellationTokenSource cancelTokenSource);

        public HashSet<int> player_responses = new HashSet<int>
        {
            0,2,4,5,6,7,8
        };

        public enum PlayerName
        {
            Diligent,
            Random,
            Random_Smart,
            Cheater,
            Diligent_Cheater,
            Super_Cheater
        }

    }
}
