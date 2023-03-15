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

namespace RPGCharacterSheet
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
                    RPGCharacter c = new RPGCharacter()
                    {
                        Name = i.Content.ToString()
                    };
                    _character.PartyMembers.Add(c);
                }
            }

            listPartyMembers.Items.Clear();
            foreach (RPGCharacter c in _character.PartyMembers)
            {
                ListBoxItem i = new ListBoxItem();
                i.Content = $"{c.Name} STR: {c.Strength} INT: {c.Intelligence}";
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
