using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeroMonsterClassesChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                Character hero = new Character();

                hero.Name = "Hero";
                hero.Health = 100;
                hero.DamageMaximum = 20;
                hero.AttackerBonus = true;

                Character monster = new Character();
                monster.Name = "Monster";
                monster.Health = 100;
                monster.DamageMaximum = 15;
                monster.AttackerBonus = false;

                Dice dice = new Dice();
                dice.Sides = 27;

                int damage = hero.Attack(dice);
                //if (hero.AttackerBonus)


                monster.Health = (monster.Health - damage);
                hero.Health = (hero.Health - damage);

                int i = 0; i++;
                while (hero.Health >= 0 && monster.Health >= 0)
                {
                    hero.Health = (hero.Health - damage);
                    monster.Health = (monster.Health - damage);

                    printStats(hero);
                    printStats(monster);


                    if (hero.Health <= 0)
                        declareWinner(hero);

                    else if (monster.Health <= 0)
                        declareWinner(monster);



                }

                //int damage = hero.Attack();
                //hero.Health = (hero.Health - damage);
                //hero.Defend(damage);

                // damage = monster.Attack();
                //  monster.Health = (monster.Health - damage);
                //monster.Defend(damage);

            }


            private void declareWinner(Character character)
            {
                if (character.Health <= 0)
                {
                    resultLabel.Text += String.Format("<br />{0} has won the challenge", character.Name);
                }
            }

            private void printStats(Character character)
            {
                resultLabel.Text += String.Format("The {0} attacked; <br />" +
                    "Injuries inflicted {1}; <br />" +

                    "Current State of health: {2} <br /><br />", character.Name, character.DamageMaximum, character.Health);

            }

        }


        class Character
        {
            Random random = new Random();

            public string Name { get; set; }
            public int Health { get; set; }
            public int DamageMaximum { get; set; }
            public bool AttackerBonus { get; set; }

            public int Attack(Dice dice)


            {

                int damage = random.Next(dice.Sides);

                return damage;
            }
            public int Defend(int damage)
            {
                int CurrentHealth = (this.Health - damage);
                return CurrentHealth;
            }

        }
        class Dice
        {
            public int Sides { get; set; }

            public int Rolls()
            {
                Random random = new Random();
                return random.Next(Sides);

            }

        }
    }
