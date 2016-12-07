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
        }

        public override int Select(double[] estimate)
        {
            Round++;
            return DynamicSelect(estimate);
        }

        protected abstract int DynamicSelect(double[] estimate);
    }
}
