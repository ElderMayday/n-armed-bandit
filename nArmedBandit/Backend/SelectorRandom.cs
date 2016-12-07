using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nArmedBandit.Backend
{
    class SelectorRandom : Selector
    {
        protected static Random random = new Random();

        public SelectorRandom() : base()
        {
        }

        public override int Select(double[] estimate)
        {
            return random.Next(estimate.Length);
        }
    }
}
