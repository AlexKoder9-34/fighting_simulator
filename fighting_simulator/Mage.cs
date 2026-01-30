using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fighting_simulator
{
    public class Mage : Player
    {
        public override void PlayerGameClass()
        {
            Class = PlayerClass.Mage;
            Stats = new PlayerStats(hp: 170, maxHP:170, _damage: 70, mp: 75, maxMP:75, mpPotions: 3, max_mpPotions: 3);
            Console.WriteLine("\nВаш класс: Маг \n Ваши характеристики: \n " +
                "Здоровье: 170 \n Урон: 70 \n Мана: 75 \n Зелья Маны: 3 \n");
        }
        public override void Attack(Enemy enemy)
        {
            Stats.WasteManaFromSpell();
            Stats.useAttackSpell(enemy);
            
        }
        public override void UseManaPotion()
        {
            Stats.RestoreMana();
        }
        public override void PlayerTurn(Enemy enemy)
        {
                Console.WriteLine("Ваш ход: \n 1 - Огненный шар \n 2 - Выпить элексир Маны \n 3 - Заклинание исцеления");
                int playerTurn = Convert.ToInt32(Console.ReadLine());
                switch (playerTurn)
                {
                    case 1:
                        Attack(enemy);
                        break;
                    case 2:
                        UseManaPotion();
                        break;
                    case 3:
                        Stats.RestoreHealth();
                        break;
                    default:
                        Console.WriteLine("Вы пропускаете ход, за тупость!");
                        break;
                }
                Console.WriteLine("");
        }
    }
}
