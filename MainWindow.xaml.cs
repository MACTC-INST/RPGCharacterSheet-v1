using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RPGChar_PM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RPGCharacter _character = new RPGCharacter();
        private Random _rng = new Random();

        public MainWindow()
        {
            InitializeComponent();
            updateStats();
            int d1 = RPGCharacter.RollDice(2, 20);
            int d2 = RPGCharacter.RollDice(1000, 8);
            MessageBox.Show(d1.ToString());
            MessageBox.Show(d2.ToString());
        }

        private void buttonUpdateName_Click(object sender, RoutedEventArgs e)
        {
            _character.Name = textBoxName.Text;
        }

        private void buttonReroll_Click(object sender, RoutedEventArgs e)
        {
            _character.Roll();
            updateStats();
            double odds = .5;

            _character.PartyMembers.Clear();
            foreach (ListBoxItem i in listPotentialMembers.Items)
            {
                if (_rng.NextDouble() > odds)
                {
                    RPGCharacter r = new RPGCharacter()
                    { Name = i.Content.ToString() };

                    _character.PartyMembers.Add(r);
                }
            }

            listPartyMembers.Items.Clear();
            foreach (RPGCharacter r in _character.PartyMembers)
            {
                ListBoxItem i = new ListBoxItem();
                i.Content = $"{r.Name} STR: {r.Strength} INT: {r.Intelligence}";
                listPartyMembers.Items.Add(i);
            }
            

        }

        private void updateStats()
        {
            textStrength.Text = _character.Strength.ToString();
            textIntelligence.Text = _character.Intelligence.ToString();
            textDexterity.Text = _character.Dexterity.ToString();
            textStamina.Text = _character.Stamina.ToString();
            textWisdom.Text = _character.Wisdom.ToString();
            textCharisma.Text = _character.Charisma.ToString();
        }
    }
}
