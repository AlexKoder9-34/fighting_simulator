using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fighting_simulator
{
    public abstract class Enemy
    {
        public EnemyStats BossStats { get; protected set; } //характеристики босса (Хп и урон)
        public abstract void SetBoss(); //установка характеристик у босса (кол-во хп и урона)
        public abstract void BossAttack(Player player); //босс атакует
        public abstract void BossTurn(Player player); //ход босса
    }
}
