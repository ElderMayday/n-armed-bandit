using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nArmedBandit.Backend
{
    abstract class Action
    {
        /// <summary>
        /// Number of times chosen
        /// </summary>
        public int SelectedNumber { get; protected set; }

        public double Estimate { get; protected set; }

        public Action()
        {
            SelectedNumber = 0;
            Estimate = 0.0;
        }

        public double Select()
        {
            SelectedNumber++;
            double reward = Reward();
            Estimate = Estimate + 1.0 / SelectedNumber * (reward - Estimate); 
            return reward;
        }

        protected abstract double Reward();
    }
}
