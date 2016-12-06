using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nArmedBandit.Backend
{
    class Game
    {
        public List<Action> Action { get; protected set; }

        public Game(List<Action> action)
        {
            this.Action = action;
        }
    }
}
