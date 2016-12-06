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
        protected int round;

        public Simulation(Game game)
        {
            this.Game = game;
            round = 0;
        }
    }
}
