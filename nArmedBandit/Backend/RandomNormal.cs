using System;

namespace nArmedBandit.Backend
{
    class RandomNormal : Random
    {
        public double Mean { get; protected set; }
        public double Deviation { get; protected set; }
        protected int rounds;
        protected static System.Random random = new System.Random();

        public RandomNormal(double mean, double deviation) : base()
        {
            this.Mean = mean;
            this.Deviation = deviation;
            rounds = 12;
        }

        public override double Generate()
        {
            double result = 0.0;

            for (int i = 0; i < rounds; i++)
                result += random.NextDouble();

            return Deviation * Math.Sqrt(12.0 / rounds) * (result - rounds / 2.0) + Mean;
        }
    }
}
