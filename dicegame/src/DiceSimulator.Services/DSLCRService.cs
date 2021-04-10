using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiceSimulator.Intefaces.Models;


using System.Threading.Tasks.Dataflow;
using DiceSimulator.Models.Servcies.OutputModels;
using DiceSimulator.Intefaces.Services;

namespace DiceSimulator.Services
{
    public partial class DSLCRService : IDSLCRService
    {
        public IDSLCROutputModel PlayLCRGame(IDSLCRInputModel inputModel)
        {
            var transformBlock = new TransformBlock<Tuple<int, int>, Tuple<int, int, double>>
                   (
                   n =>
                   {
                       var dtStart = DateTime.Now;
                       int winner = 0;
                       var r = new Random();
                       //Create a list of chips
                       var players = Enumerable.Repeat(n.Item1, n.Item2).ToList();
                       //Loop as long any player still has chips
                       int turnNums = 0;
                       for (var turnNum = 0; players.Any(c => c > 0); turnNum++)
                       {
                           //Get a random number within the range of 0-5 and loop for either 3 or the amount of chips we have, whichever is smaller
                           for (int k = 0, x = r.Next(6); k++ < Math.Min(players[turnNum % n.Item2], 3);
                           //Increment either the right player if the random number is 1, else increment the right player if it is 0
                           players[((x < 1 ? -1 : 1) + turnNum + n.Item2) % n.Item2] += x < 2 ? 1 : 0
                           //Decrement current player if the die roll is under 3
                           , players[turnNum % n.Item2] -= x < 3 ? 1 : 0) ;
                           if (players.Where(y => y != 0).Count() == 1)
                           {
                               winner = 0;
                               foreach (var player in players)
                               {
                                   if (player > 0)
                                   {
                                       turnNums = turnNum;
                                       break;
                                   }
                                   winner++;
                               }
                           }
                       }
                       TimeSpan ts = DateTime.Now - dtStart;
                       return new Tuple<int, int, double>(turnNums, winner, ts.TotalSeconds);
                   }

                 );
            var turns = new List<int>();
            for (int i = 0; i < inputModel.NumberOfGames; i++)
            {
                transformBlock.Post(new Tuple<int, int>(inputModel.ChipsPerPlayer,inputModel.NumberOfPlayer));
            }
            for (int i = 0; i < inputModel.NumberOfGames; i++)
            {
                var x = transformBlock.Receive();
                turns.Add(x.Item1);
            }
            int min = turns.Min();
            int max = turns.Max();
            var ave = Convert.ToDouble(turns.Sum()) / Convert.ToDouble(inputModel.NumberOfGames);
            return new DSLCROutputModel {AverageTurns=ave,MinimumTurns=min,LongesrTurns=max };
        }
    }
}
