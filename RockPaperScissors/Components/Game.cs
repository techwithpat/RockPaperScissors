using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors.Components
{
    public partial class Game
    {
        private int playerScore;
        private int computerScore;
        private string playerChoiceImage;
        private string computerChoiceImage;
        private string message;

        private readonly Action<int> playerMadeChoice;
        private readonly Action<int> computerMadeChoice;
        private readonly Action<int, int> bothMadeChoice;

        private readonly Random random;

        public Game()
        {
            random = new Random();

            playerMadeChoice = (playerChoice) => 
            {
                playerChoiceImage = choices[playerChoice];
                computerMadeChoice(playerChoice);
            };

            computerMadeChoice = (playerChoice) => 
            {
                var computerChoice = random.Next(2);
                computerChoiceImage = choices[computerChoice];
                StateHasChanged();

                bothMadeChoice(playerChoice, computerChoice);
            };

            bothMadeChoice = (playerChoice, computerChoice) => 
            {
                var (_, _, playerWon, computerWon, message) = WinningRules[playerChoice, computerChoice];
                this.message = message;
                playerScore = playerWon ? ++playerScore : playerScore;
                computerScore = computerWon ? ++computerScore : computerScore;

                StateHasChanged();
            };
        }

        protected override void OnInitialized() => SetDefaultMessage();
        private void SetDefaultMessage() => message = "Make a choice";
        private void OnPlayerMadeChoice(int playerChoice) => playerMadeChoice(playerChoice);

        private void Reset()
        {
            SetDefaultMessage();
            playerScore = computerScore = 0;
            playerChoiceImage = computerChoiceImage = string.Empty;
        }

        [Inject]
        public WinningRules WinningRules { get; set; }
    }
}
