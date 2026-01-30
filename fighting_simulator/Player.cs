using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fighting_simulator
{
    public abstract class Player
    {
        public PlayerClass Class { get; protected set; } //Класс игрока
        public PlayerStats Stats { get; protected set; } //Характеристики игрока (ХП, Мана, урон и пр.)
        public abstract void PlayerGameClass(); //Выдача игрового класса игроку
        public abstract void Attack(Enemy enemy); //Игрок атакует
        public virtual void Shield(Enemy enemy) 
        {
            //Воин атакует с использованием щита
        }
        public abstract void PlayerTurn(Enemy enemy);
        public virtual void UseManaPotion()
        {
            //метод для восстановления маны игроком с классом Mage (Маг).
        }

    }
}
