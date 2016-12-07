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

namespace nArmedBandit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<GameAction> action = new List<GameAction>();
            action.Add(new GameActionRandom(new RandomValueNormal(2.3, 0.9)));
            action.Add(new GameActionRandom(new RandomValueNormal(2.1, 0.6)));
            action.Add(new GameActionRandom(new RandomValueNormal(1.5, 0.4)));
            action.Add(new GameActionRandom(new RandomValueNormal(1.3, 2.0)));

            Game game = new Game(action);

            Selector selector = new SelectorGreedy(0.5);

            Simulation simulation = new Simulation(game, selector);
            simulation.Simulate(100);
        }
    }
}
