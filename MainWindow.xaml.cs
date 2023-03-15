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
        private Random _rng = new Random();
        private RPGCharacter _character;
        

        public MainWindow()
        {
            InitializeComponent();
            _character = new RPGCharacter(_rng);

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
                    RPGCharacter r = new RPGCharacter(_rng)
                    { Name = i.Content.ToString() };

                    _character.PartyMembers.Add(r);
                }
            }

            // Junk code to test Favorite Color
            if (_character.PartyMembers.Count > 0)
            {
                _character.PartyMembers[0].FavoriteColor = Brushes.Azure;
            }

            // Adding party members to Party Member listbox
            listPartyMembers.Items.Clear();
            Brush color1 = Brushes.PowderBlue;
            Brush color2 = Brushes.PeachPuff;

            foreach (RPGCharacter r in _character.PartyMembers)
            {
                ListBoxItem i = new ListBoxItem();
                
                if (r.FavoriteColor != null)
                {
                    i.Background = r.FavoriteColor;
                }
                // Alternate background colors
                else if (listPartyMembers.Items.Count % 2 == 0)
                {
                    i.Background = color1;
                }
                else
                {
                    i.Background = color2;
                }

                i.Content = $"{r.Name}\nSTR: {r.Strength}\nINT: {r.Intelligence}";
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
