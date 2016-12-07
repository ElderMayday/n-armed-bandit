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
            task1();
        }

        private void task1()
        {
            int rounds = 1000;

            List<GameAction> action = new List<GameAction>();
            action.Add(new GameActionRandom(new RandomValueNormal(2.3, 0.9)));
            action.Add(new GameActionRandom(new RandomValueNormal(2.1, 0.6)));
            action.Add(new GameActionRandom(new RandomValueNormal(1.5, 0.4)));
            action.Add(new GameActionRandom(new RandomValueNormal(1.3, 2.0)));
            
            List<Selector> selectors = new List<Selector>();
            selectors.Add(new SelectorRandom());
            selectors.Add(new SelectorGreedy(0.0));
            selectors.Add(new SelectorGreedy(0.1));
            selectors.Add(new SelectorGreedy(0.2));
            selectors.Add(new SelectorSoftmax(1.0));
            selectors.Add(new SelectorSoftmax(0.1));

            initializeNewChart();

            for (int selectorIndex = 0; selectorIndex < selectors.Count; selectorIndex++)
            {
                Selector selector = selectors[selectorIndex];
                Game game = new Game(action);
                Simulation simulation = new Simulation(game, selector);
                string plotName = selector.ToString();

                initializeNewSeries(plotName);

                for (int i = 1; i <= rounds; i++)
                {
                    simulation.NextStep();
                    chart.Series[plotName].Points.AddXY(i, simulation.Game.TotalReward);
                }

                for (int i = 0; i > action.Count; i++)
                    action[i].Reset();
            }
        }

        private void initializeNewChart()
        {
            chart.Series.Clear();
            chart.ChartAreas[0].AxisX.Title = "Round";
            chart.ChartAreas[0].AxisY.Title = "Reward";
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0}";
        }

        private void initializeNewSeries(string name)
        {
            chart.Series.Add(name);
            chart.Series[name].ChartType = SeriesChartType.Line;
            chart.Series[name].Color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            chart.Series[name].BorderWidth = 3;
        }

        private void ResetActions(List<GameAction> list)
        {
            for (int i = 0; i < list.Count; i++)
                list[i].Reset();
        }
    }
}
