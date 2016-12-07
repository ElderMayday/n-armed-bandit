using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nArmedBandit.Backend
{
    class SelectorDynamicGreedy : SelectorDynamic
    {
        protected static Random random = new Random();
        protected double epsilon;

        public SelectorDynamicGreedy() : base()
        {
        }

        protected override int DynamicSelect(List<GameAction> action)
        {
            this.epsilon = 1.0 / Math.Sqrt(Round);

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

        public override string ToString()
        {
            return "Dynamic epsilon-greedy";
        }
    }
}
