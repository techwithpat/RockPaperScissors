using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors.Components
{
    public class WinningRules
    {
        private readonly IList<(int, int, bool, bool, string)> winningRules =
            new List<(int, int, bool, bool, string)>
            {
                (0,0, false, false, "You both select Rock, it's tie"),
                (0, 1, false, true, "Paper beats Rock, you lose"),
                (0, 2, true, false, "Rock beats Scissors, you win"),
                (1, 0, true, false, "Paper beats Rock, you win"),
                (1, 1, false, false, "You both select Paper, it's tie"),
                (1, 2, false, true, "Scissors beats Paper, you lose"),
                (2, 0, false, true, "Rock beats Scissors, you lose"),
                (2, 1, true, false, "Scissors beats Paper, you win"),
                (2, 2, false, false,"You both select Scissors, it's tie")
            };

        public (int, int, bool, bool, string) this[int playerChoice, int computerChoice]
            => winningRules.Single(w => w.Item1 == playerChoice && w.Item2 == computerChoice);
    }
}
