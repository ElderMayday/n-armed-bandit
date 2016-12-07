using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nArmedBandit.Backend
{
    class Simulation
    {
        public Game Game { get; protected set; }
        public Selector Selector { get; protected set; }

        public Simulation(Game game, Selector selector)
        {
            this.Game = game;
            this.Selector = selector;
        }

        public void Simulate(int maxRound)
        {
            for (int round = 0; round < maxRound; round++)
            {
                int selected = Selector.Select(Game.Estimate);
                Game.Select(selected);
            }
        }
    }
}
