using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nArmedBandit.Backend
{
    class Game
    {
        public List<Action> Random { get; protected set; }

        public void AddRandomDistribution(Action newAction)
        {
            Random.Add(newAction);
        }
    }
}
