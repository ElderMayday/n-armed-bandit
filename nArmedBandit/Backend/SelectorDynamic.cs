using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nArmedBandit.Backend
{
    abstract class SelectorDynamic : Selector
    {
        public int Round { get; protected set; }

        public SelectorDynamic() : base()
        {
            Reset();
        }

        public void Reset()
        {
            Round = 0;
        }

        public override int Select(List<GameAction> action)
        {
            Round++;
            return DynamicSelect(action);
        }

        protected abstract int DynamicSelect(List<GameAction> action);
    }
}
