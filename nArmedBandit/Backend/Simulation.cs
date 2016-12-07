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
        public int Step { get; protected set; }

        public Simulation(Game game, Selector selector)
        {
            this.Game = game;
            this.Selector = selector;
            this.Step = 0;
        }

        public void SimulateInstantly(int maxRound)
        {
            for (int round = 0; round < maxRound; round++)
            {
                int selected = Selector.Select(Game.Action);
                Game.Select(selected);
            }
        }

        public void NextStep()
        {
            this.Step++;
            int selected = Selector.Select(Game.Action);
            Game.Select(selected);
        }
    }
}
