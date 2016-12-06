﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nArmedBandit.Backend
{
    abstract class GameAbstract
    {
        public int NumberOfActions { get; protected set; }

        public abstract double Reward(int actionNumber);
    }
}
