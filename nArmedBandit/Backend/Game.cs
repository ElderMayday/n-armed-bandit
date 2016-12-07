using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nArmedBandit.Backend
{
    class Game
    {
        public List<GameAction> Action { get; protected set; }
        public double TotalReward { get; protected set; }

        public Game(List<GameAction> action)
        {
            this.Action = action;
            this.TotalReward = 0.0;
        }

        public void Select(int ActionIndex)
        {
            double reward = Action[ActionIndex].Select();
            TotalReward += reward;
        }
    }
}
