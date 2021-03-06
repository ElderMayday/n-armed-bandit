﻿using nArmedBandit.Backend;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace nArmedBandit
{
    public partial class Form1 : Form
    {
        protected static Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            List<Selector> selectors = null;
            List<GameAction> action = null;

            if (radioTask1.Checked)
            {
                selectors = new List<Selector>();
                selectors.Add(new SelectorRandom());
                selectors.Add(new SelectorGreedy(0.0));
                selectors.Add(new SelectorGreedy(0.1));
                selectors.Add(new SelectorGreedy(0.2));
                selectors.Add(new SelectorSoftmax(1.0));
                selectors.Add(new SelectorSoftmax(0.1));

                action = new List<GameAction>();
                action.Add(new GameActionRandom(new RandomValueNormal(2.3, 0.9)));
                action.Add(new GameActionRandom(new RandomValueNormal(2.1, 0.6)));
                action.Add(new GameActionRandom(new RandomValueNormal(1.5, 0.4)));
                action.Add(new GameActionRandom(new RandomValueNormal(1.3, 2.0)));
            }
            else if (radioTask2.Checked)
            {
                selectors = new List<Selector>();
                selectors.Add(new SelectorRandom());
                selectors.Add(new SelectorGreedy(0.0));
                selectors.Add(new SelectorGreedy(0.1));
                selectors.Add(new SelectorGreedy(0.2));
                selectors.Add(new SelectorSoftmax(1.0));
                selectors.Add(new SelectorSoftmax(0.1));

                action = new List<GameAction>();
                action.Add(new GameActionRandom(new RandomValueNormal(2.3, 1.8)));
                action.Add(new GameActionRandom(new RandomValueNormal(2.1, 1.2)));
                action.Add(new GameActionRandom(new RandomValueNormal(1.5, 0.8)));
                action.Add(new GameActionRandom(new RandomValueNormal(1.3, 4.0)));
            }
            else
            {
                selectors = new List<Selector>();
                selectors.Add(new SelectorRandom());
                selectors.Add(new SelectorGreedy(0.0));
                selectors.Add(new SelectorGreedy(0.1));
                selectors.Add(new SelectorGreedy(0.2));
                selectors.Add(new SelectorSoftmax(1.0));
                selectors.Add(new SelectorSoftmax(0.1));
                selectors.Add(new SelectorDynamicGreedy());
                selectors.Add(new SelectorDynamicSoftmax());

                action = new List<GameAction>();
                action.Add(new GameActionRandom(new RandomValueNormal(2.3, 0.9)));
                action.Add(new GameActionRandom(new RandomValueNormal(2.1, 0.6)));
                action.Add(new GameActionRandom(new RandomValueNormal(1.5, 0.4)));
                action.Add(new GameActionRandom(new RandomValueNormal(1.3, 2.0)));
            }

            if (radioReward.Checked)
                AlgorithmRewardChart(selectors, action);
            else if (radioArm.Checked)
                ArmEstimateChart(selectors, action, (int)numericArm.Value);
            else if (radioHistogram.Checked)
                ArmHistogram(selectors, action, (int)numericSelector.Value);
        }

        private void ArmHistogram(List<Selector> selectors, List<GameAction> action, int selectorIndex)
        {
            int rounds = 1000;

            Selector selector = selectors[selectorIndex];
            Game game = new Game(action);
            Simulation simulation = new Simulation(game, selector);
            simulation.SimulateInstantly(rounds);

            string plotName = "Action histogram";

            initializeNewChart("Action", "Selected");
            chart.ChartAreas[0].AxisY.Maximum = rounds;
            initializeNewSeries(plotName, SeriesChartType.Column, 0);

            for (int i = 0; i < action.Count; i++)
                chart.Series[plotName].Points.AddXY(i, game.Action[i].SelectedNumber);
        }

        private void ArmEstimateChart(List<Selector> selectors, List<GameAction> action, int armIndex)
        {
            int rounds = 1000;

            initializeNewChart("Round", "Estimate");

            for (int selectorIndex = 0; selectorIndex < selectors.Count; selectorIndex++)
            {
                Selector selector = selectors[selectorIndex];
                Game game = new Game(action);
                Simulation simulation = new Simulation(game, selector);
                string plotName = selector.ToString();

                initializeNewSeries(plotName, SeriesChartType.Line, selectorIndex);

                for (int i = 1; i <= rounds; i++)
                {
                    simulation.NextStep();
                    chart.Series[plotName].Points.AddXY(i, simulation.Game.Action[armIndex].Estimate);
                }

                chart.ChartAreas[0].AxisY.Minimum = Math.Truncate((game.Action[armIndex].Estimate - 0.3) * 10) / 10;
                chart.ChartAreas[0].AxisY.Maximum = Math.Truncate((game.Action[armIndex].Estimate + 0.3) * 10) / 10;

                resetActions(action);
            }
        }
        
        private void AlgorithmRewardChart(List<Selector> selectors, List<GameAction> action)
        {
            int rounds = 1000;

            initializeNewChart("Round", "Reward");

            for (int selectorIndex = 0; selectorIndex < selectors.Count; selectorIndex++)
            {
                Selector selector = selectors[selectorIndex];
                Game game = new Game(action);
                Simulation simulation = new Simulation(game, selector);
                string plotName = selector.ToString();

                initializeNewSeries(plotName, SeriesChartType.Line, selectorIndex);

                for (int i = 1; i <= rounds; i++)
                {
                    simulation.NextStep();
                    chart.Series[plotName].Points.AddXY(i, simulation.Game.TotalReward);
                }

                resetActions(action);
            }
        }

        private void resetActions(List<GameAction> action)
        {
            for (int i = 0; i > action.Count; i++)
                action[i].Reset();
        }

        private void initializeNewChart(string xTitle, string yTitle)
        {
            chart.Series.Clear();
            chart.ChartAreas[0].AxisX.Title = xTitle;
            chart.ChartAreas[0].AxisY.Title = yTitle;
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0}";
        }

        private void initializeNewSeries(string name, SeriesChartType type, int colorIndex)
        {
            chart.Series.Add(name);
            chart.Series[name].ChartType = type;

            Color color;

            switch (colorIndex)
            {
                case 0: color = Color.Black; break;
                case 1: color = Color.Blue; break;
                case 2: color = Color.Green; break;
                case 3: color = Color.Yellow; break;
                case 4: color = Color.Red; break;
                case 5: color = Color.Orange; break;
                case 6: color = Color.Violet; break;
                case 7: color = Color.Aqua; break;
                default: color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)); break;
            }

            chart.Series[name].Color = color;
            chart.Series[name].BorderWidth = 2;
        }

        private void ResetActions(List<GameAction> list)
        {
            for (int i = 0; i < list.Count; i++)
                list[i].Reset();
        }
    }
}
