using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fighting_simulator
{
    public class Warrior : Player
    {

        public override void PlayerGameClass()
        {
            Class = PlayerClass.Warrior;
            Stats = new PlayerStats(hp: 300, maxHP: 300, _damage: 50);
            Console.WriteLine("\nВаш класс: Воин \n Ваши характеристики: \n Здоровье: 300 \n Урон: 50 \n");
        }
        public override void Attack(Enemy enemy)
        {
            Stats.MakeAttack(enemy);
        }

        public override void Shield(Enemy enemy)
        {
            Stats.ActivateShield();
            Stats.AttackWithShield(enemy);
        }
        public override void PlayerTurn(Enemy enemy)
        {

            Console.WriteLine("Ваш ход: \n 1 - Атаковать \n 2 - Щит \n");
            int playerTurn = Convert.ToInt32(Console.ReadLine());
            switch (playerTurn)
            {
                case 1:
                    Attack(enemy);
                    break;
                case 2:
                    Shield(enemy);
                    break;
                default:
                    Console.WriteLine("Вы пропускаете ход, за тупость!");
                    break;
            }
            Console.WriteLine("");
        }
    }
}
