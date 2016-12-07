using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nArmedBandit.Backend
{
    class SelectorGreedy : Selector
    {
        protected static Random random = new Random();
        protected double epsilon;

        public SelectorGreedy(double epsilon) : base()
        {
            this.epsilon = epsilon;
        }

        public override int Select(List<GameAction> action)
        {
            if (random.NextDouble() < epsilon)
                return random.Next(action.Count);
            else
            {
                double max = action.Max(x => x.Estimate);

                int index;

                for (index = 0; index < action.Count; index++)
                    if (action[index].Estimate == max)
                        break;

                return index;
            }
        }
    }
}
