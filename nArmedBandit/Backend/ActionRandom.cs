using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nArmedBandit.Backend
{
    class ActionRandom : Action
    {
        protected Random random;

        public ActionRandom(Random random)
        {
            this.random = random;
        }

        public override double Reward()
        {
            return random.Generate();
        }
    }
}
