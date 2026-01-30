using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fighting_simulator
{
    public enum PlayerClass
    {
        Warrior,
        Mage
    }
    public class PlayerStats   //отвечает за хранение характеристик игрока и все их изменения.
    {
        //Здоровье игрока:
        private int maxPlayerHealth; //Max кол-во хп игрока
        private int playerHealth; //Кол-во ХП игрока
        
        //Магия (если у игрока класс Маг)
        private int maxMana; //Max кол-во маны у игрока
        private int mana; //Сколько маны у игрока (только для класса Маг)
        private const int spellPrice = 25; //Сколько маны тратит каждое заклинание
        private int manaPotions; //Сколько есть зелий для восстановления маны (только для класса Маг)
        private int maxManaPotions; //Max кол-во зелий маны (только для класса Маг)

        //Урон и защита:
        private bool isShieldActive; //Активен ли щит
        private int playerDamage; //Сколько урона наносит игрок

        public PlayerStats
            (int hp = 0,
            int maxHP = 0,
            int _damage = 0,
            int mp = 0, 
            int maxMP = 0, 
            int mpPotions = 0,
            int max_mpPotions = 0,
            bool isShieldUsing = false)
        {
            playerHealth = hp;
            maxPlayerHealth = maxHP;

            mana = mp;
            maxMana = maxMP;

            manaPotions = mpPotions;
            maxManaPotions = max_mpPotions;

            isShieldActive = isShieldUsing;
            playerDamage = _damage;
        }
        public void AttackWithShield(Enemy enemy)
        {
            enemy.BossStats.EnemyGetDamage(playerDamage - 20);
            Console.WriteLine($"\nВы атакуете с щитом в руках, а потому нанесли {playerDamage - 20} урона");
        }
        public void MakeAttack(Enemy enemy)
        {
            enemy.BossStats.EnemyGetDamage(playerDamage);
            Console.WriteLine($"\nВы нанесли {playerDamage} урона"); 
        }
        public void useAttackSpell(Enemy enemy)
        {
            if (mana > 0) 
            {
                MakeAttack(enemy);
            }
            else
            {
                Console.WriteLine("У вас не хватает маны");
            }
        }
        public void RestoreMana() //использования зелья с маной
        {
            if (manaPotions <= 0) //Проверка, остались ли у игрока зелья?
            {
                Console.WriteLine("Элексиров с маной больше нет.\n");
            }
            else //если ещё есть зелья с маной
            {
                manaPotions--; //уменьшить кол-во зелий на 1
                mana += 50; //Добавить + 50 к кол-ву маны
                Console.WriteLine($"Был выпит Элексир с Маной.\nБыло восстановлено 40 маны\n" +
                   $"Осталось {manaPotions} Элексиров с Маной\n");
            }
            SetManaEdge();
        }
        public int PlayerGetDamage(int damage) //Игрок получает урон
        {
            /*
             Если игрок использует щит, тот получает лишь половину от урона, 
             если нет - то 100% урона, а если у игрока больше нет ХП - GameOver.
             */
            if (isShieldActive == false)
            {
                playerHealth -= damage;
                Console.WriteLine($"Вам было нанесено {damage} урона.\n");
            }
            else if (isShieldActive == true)                    
            {                                            
                playerHealth -= damage / 2;
                Console.WriteLine($"При атаке был использован предмет \"Щит\".\n \nВам было нанесено {damage/2} урона.\n");
                DisactivateShield();
            }
            SetHealthEdge();
            return playerHealth;
        }
        public void ActivateShield()
        {
            isShieldActive = true;
        }
        public void DisactivateShield()
        {
            isShieldActive = false;
        }
        public void WasteManaFromSpell()
        {
            mana -= spellPrice;
            SetManaEdge();
        }
        public void SetManaEdge()
        {
            if (mana < 0)
                mana = 0;

            if (mana >= maxMana)
                mana = maxMana;
        }
        public void RestoreHealth()
        {
            if(mana < spellPrice)
            {
                Console.WriteLine("Нехватает маны");
            }
            else
            {
                playerHealth += 70;
                Console.WriteLine("Было восстановлено 70 здоровья");
                WasteManaFromSpell();
            }
            SetHealthEdge();
        }
        public void SetHealthEdge()
        {
            if (playerHealth > maxPlayerHealth)
                playerHealth = maxPlayerHealth;

            if (playerHealth < 0)
                playerHealth = 0;
        }
        public bool IsPlayerAlive()
        {
            return playerHealth > 0;
        }
        public void ShowPlayerStats()
        {
            Console.WriteLine($"Ваши характеристики: \n Здоровье: {playerHealth}/{maxPlayerHealth} \n Мана:{mana}/{maxMana} \n Зелья маны: {manaPotions}/{maxManaPotions}\n ");
        }
    }
    
}
