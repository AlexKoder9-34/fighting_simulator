using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace fighting_simulator
{
    public class Dragon : Enemy 
    {

        public override void SetBoss()
        {
            BossStats = new EnemyStats(bossHP: 300, maxBossHP:300, _bossDamage: 40);
            Console.WriteLine("Босс \"Дрэйк, адское пламя\" \n Здоровье: 200 \n");
        }
        public override void BossAttack(Player player)
        {
            BossStats.MakeDamage(player);
        }
        public override void BossTurn(Player player)
        {
            BossAttack(player);
            BossStats.ShowBossHealth();
        }
    }
}
