using System;
using System.Threading;
using System.Threading.Tasks;

namespace GuessNumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            DiligentPlayer Deligent = new DiligentPlayer();
            Task t1 = Task.Run(() => Deligent.Roll(cancelTokenSource));

            RandomPlayer Random = new RandomPlayer();
            Task t2 = Task.Run(() => Random.Roll(cancelTokenSource));

            RandomSmartPlayer Random_Smart = new RandomSmartPlayer();
            Task t3 = Task.Run(() => Random_Smart.Roll(cancelTokenSource));

            CheaterPlayer Cheater = new CheaterPlayer();
            Task t4 = Task.Run(() => Cheater.Roll(cancelTokenSource));

            //SuperCheaterPlayer Super_Cheater = new SuperCheaterPlayer();
            //Task t5 = Task.Run(() => Super_Cheater.Roll(cancelTokenSource));

            Console.ReadLine();
        }
    }
}
