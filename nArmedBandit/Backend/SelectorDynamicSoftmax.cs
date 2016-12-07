using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nArmedBandit.Backend
{
    class SelectorDynamicSoftmax : SelectorDynamic
    {
        protected double tau;
        protected const double e = 2.71828;
        protected static Random random = new Random();

        public SelectorDynamicSoftmax() : base()
        {
        }

        protected override int DynamicSelect(List<GameAction> action)
        {
            // calculate tau

            this.tau = 4.0 * (1000.0 - Round) / 1000.0; 

            // calculate exponentiated values

            List<double> exp = new List<double>();

            foreach (var a in action)
                exp.Add(Math.Pow(SelectorDynamicSoftmax.e, a.Estimate / tau));

            double sum = exp.Sum();

            // calculate probabilities

            List<double> probability = new List<double>();

            double current = 0.0;

            for (int i = 0; i < exp.Count; i++)
            {
                current += exp[i];
                probability.Add(current / sum);
            }

            // find action index

            double r = random.NextDouble();

            for (int i = 0; i < probability.Count - 1; i++)
                if (r <= probability[i])
                    return i;

            return probability.Count - 1;
        }

        public override string ToString()
        {
            return "Dynamic softmax";
        }
    }
}
