using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RPGCharacterSheet
{
    internal class RPGCharacter
    {
        // Fields
        private int _charisma;
        private int _dexterity;
        private int _intelligence;
        private int _stamina;
        private int _strength;
        private int _wisdom;
        private int _maxCharisma = 20;
        private int _maxDexterity = 20;
        private int _maxIntelligence = 20;
        private int _maxStamina = 20;
        private int _maxStrength = 20;
        private int _maxWisdom = 20;
        private int _statNumberDice = 1;
        private int _statDiceSides = 20;
        private List<RPGCharacter> _partyMembers = new List<RPGCharacter>();
        private Brush _favoriteColor; 
        private CharacterClasses _characterClass = CharacterClasses.None;
        private Random _rng = new Random();

        #region Properties
        public string Name { get; set; }
        public long XP { get; set; }
        public int Level { get; set; }
        public CharacterClasses CharacterClass
        {
            get { return _characterClass; }
            set { _characterClass = value; }
        }
        public List<RPGCharacter> PartyMembers
        {
            get { return _partyMembers; }
            set { _partyMembers = value; }
        }
        public Brush FavoriteColor
        {
            get { return _favoriteColor; }
            set { _favoriteColor = value; }
        }
        public int Charisma { get { return _charisma; } }
        public int Dexterity { get { return _dexterity; } }
        public int Intelligence { get { return _intelligence; } }
        public int Stamina { get { return _stamina; } }
        public int Strength { get { return _strength; } }
        public int Wisdom { get { return _wisdom; } }
        #endregion

        public RPGCharacter(Random rng)
        {
            _rng = rng;
            Roll();
        }

        public void Roll()
        {
            _charisma = Math.Min(RollDice(_statNumberDice, _statDiceSides, _rng), _maxCharisma);
            _dexterity = Math.Min(RollDice(_statNumberDice,_statDiceSides, _rng), _maxDexterity);
            _intelligence = Math.Min(RollDice(_statNumberDice, _statDiceSides, _rng), _maxIntelligence); ;
            _stamina = Math.Min(RollDice(_statNumberDice, _statDiceSides, _rng), _maxStamina);
            _strength = Math.Min(RollDice(_statNumberDice, _statDiceSides, _rng), _maxStrength);
            _wisdom = Math.Min(RollDice(_statNumberDice, _statDiceSides, _rng), _maxWisdom);
        }

        public static int RollDice(int numberOfDice, int numberOfSides, Random r)
        {   
            int total = 0;

            for(int i = 0; i < numberOfDice; i++)
            {
                total += r.Next(1, numberOfSides+1);
            }

            return total;
        }


    }

    public enum CharacterClasses
    {
        None = 0,
        Ranger,
        Mage,
        Rogue,
        Bard,
        Goliath,
        Paladin
    }
}
