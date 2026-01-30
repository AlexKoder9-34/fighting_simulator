using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fighting_simulator
{
    public class EnemyStats //отвечает за характеристики босса и их изменения
    {
        private int bossHealth;
        private int bossDamage;
        private int maxBossHealth;
        public EnemyStats(int bossHP, int _bossDamage, int maxBossHP)
        {
            bossDamage = _bossDamage;
            bossHealth = bossHP;
            maxBossHealth = maxBossHP;
        }
        public void EnemyGetDamage(int damage)
        {
            bossHealth -= damage;
        }
        public void MakeDamage(Player player)
        {
            player.Stats.PlayerGetDamage(bossDamage);
        }
        public bool IsBossAlive()
        {
            return bossHealth > 0;
        }
        public void ShowBossHealth() //показывает сколько осталось хп у босса после каждого хода
        {
            Console.WriteLine($"У босса осталось {bossHealth}/{maxBossHealth} \n");
        }
    }
}
