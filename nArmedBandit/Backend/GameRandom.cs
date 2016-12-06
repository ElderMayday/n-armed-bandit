using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nArmedBandit.Backend
{
    class GameRandom : GameAbstract
    {
        public List<RandomAbstract> Random { get; protected set; }

        public void AddRandomDistribution(RandomAbstract newRandom)
        {
            Random.Add(newRandom);
            this.NumberOfActions = Random.Count;
        }

        public override double Reward(int actionNumber)
        {
            return Random[actionNumber].Generate();
        }
    }
}
