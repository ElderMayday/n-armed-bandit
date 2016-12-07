using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nArmedBandit.Backend
{
    class ActionRandom : Action
    {
        protected RandomValue random;

        public ActionRandom(RandomValue random) : base()
        {
            this.random = random;
        }

        protected override double Reward()
        {
            return random.Generate();
        }
    }
}
