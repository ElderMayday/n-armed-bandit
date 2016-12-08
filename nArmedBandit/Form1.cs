using nArmedBandit.Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        }

        private void ArmEstimateChart(List<Selector> selectors, List<GameAction> action, int armIndex)
        {
            int rounds = 1000;

            initializeNewChart();

            for (int selectorIndex = 0; selectorIndex < selectors.Count; selectorIndex++)
            {
                Selector selector = selectors[selectorIndex];
                Game game = new Game(action);
                Simulation simulation = new Simulation(game, selector);
                string plotName = selector.ToString();

                initializeNewSeries(plotName, SeriesChartType.Line);

                for (int i = 1; i <= rounds; i++)
                {
                    simulation.NextStep();
                    chart.Series[plotName].Points.AddXY(i, simulation.Game.Action[armIndex].Estimate);
                }

                resetActions(action);
            }
        }
        
        private void AlgorithmRewardChart(List<Selector> selectors, List<GameAction> action)
        {
            int rounds = 1000;

            initializeNewChart();

            for (int selectorIndex = 0; selectorIndex < selectors.Count; selectorIndex++)
            {
                Selector selector = selectors[selectorIndex];
                Game game = new Game(action);
                Simulation simulation = new Simulation(game, selector);
                string plotName = selector.ToString();

                initializeNewSeries(plotName, SeriesChartType.Line);

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

        private void initializeNewChart()
        {
            chart.Series.Clear();
            chart.ChartAreas[0].AxisX.Title = "Round";
            chart.ChartAreas[0].AxisY.Title = "Reward";
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0}";
            chart.ChartAreas[0].AxisY.Minimum = 0;
        }

        private void initializeNewSeries(string name, SeriesChartType type)
        {
            chart.Series.Add(name);
            chart.Series[name].ChartType = type;
            chart.Series[name].Color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            chart.Series[name].BorderWidth = 2;
        }

        private void ResetActions(List<GameAction> list)
        {
            for (int i = 0; i < list.Count; i++)
                list[i].Reset();
        }
    }
}
