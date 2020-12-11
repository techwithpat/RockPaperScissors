using System.Collections.Generic;

namespace RockPaperScissors.Components
{
    public class Choices
    {
        private readonly Dictionary<int, string> choices =
            new Dictionary<int, string> 
            {
                {0, "✊" },
                {1, "✋" },
                {2, "✌️" }
            };

        public string this[int choiceKey] => choices[choiceKey];
    }
}
