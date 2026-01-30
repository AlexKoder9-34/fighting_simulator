using System;

namespace fighting_simulator
{
    class GameController
    {
        private Player player;
        private Enemy boss; 
        public void GameStart()
        {
            Console.Clear();
            Console.WriteLine("Приветствую, игрок.");
            ChoosePlayerClass();
            CreateBoss();
            GameplayController();
        }
        public void ChoosePlayerClass()
        {
            Console.WriteLine("Выберите свой класс: \n 1 - Воин \n 2 - Маг");
            int choice = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (choice)
                {
                    case 1:
                        player = new Warrior();
                        break;
                    case 2:
                        player = new Mage();
                        break;
                }
                player.PlayerGameClass();
            }
            catch
            {
                Console.WriteLine("Неверный формат ввода! Нужно ввести \"1\" или \"2\". Попробуйте снова! ");
                ChoosePlayerClass();
            }
        }
        public void CreateBoss()
        {
            boss = new Dragon();
            boss.SetBoss();
        }
        public void GameplayController()
        {
            while (true)
            {
                player.PlayerTurn(boss);
                if (!boss.BossStats.IsBossAlive())
                {
                    Console.WriteLine("YOU WIN \n");
                    GameOver(); break;
                }

                boss.BossTurn(player);
                if (!player.Stats.IsPlayerAlive())
                {
                    Console.WriteLine("YOU DIED \n");
                    GameOver(); break;
                }
                
                player.Stats.ShowPlayerStats();
            }
        }
        public void GameOver()
        {
                Console.WriteLine("Игра окончена.\n 1 - попробовать снова \n 2 - выйти из игры");
                int playerChoice = Convert.ToInt32(Console.ReadLine());
                switch (playerChoice)
                {
                    case 1:
                        GameStart();
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                    default: 
                        Environment.Exit(1);
                    break;
                }
        }
        static void Main(string[] args)
        {
            GameController controller = new GameController();
            controller.GameStart();
        }
    }
}
    
    
    





