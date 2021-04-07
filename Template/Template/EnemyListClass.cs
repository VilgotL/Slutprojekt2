using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Template
{
    static class EnemyListClass
    {
        public static List<EnemyClass> enemyList = new List<EnemyClass>();

        public static Texture2D enemyTexture;

        public static Texture2D bulletTexture;

        public static Stopwatch spawnTimer = new Stopwatch();

        public static Random random = new Random();

        private static void SpawnEnemy()
        {
            int randomNumber = random.Next(1, 101);

            if (randomNumber <= 34)
                enemyList.Add(new Enemy1(enemyTexture, new Vector2(random.Next(0, 751), -50), new Rectangle(325, -50, 50, 50)));
            else if (randomNumber <= 67)
                enemyList.Add(new Enemy2(enemyTexture, new Vector2(random.Next(0, 751), -50), new Rectangle(325, -50, 50, 50)));
            else
                enemyList.Add(new Enemy3(enemyTexture, bulletTexture, new Vector2(random.Next(0, 751), -50), new Rectangle(325, -50, 50, 50)));

        }

        public static void StartTimer()
        {
            spawnTimer.Start();
        }

        private static void RestartTimer()
        {
            spawnTimer.Stop();
            spawnTimer.Reset();
            spawnTimer.Start();
        }

        public static void Update()
        {
            if (spawnTimer.ElapsedMilliseconds > 2000)
            {
                SpawnEnemy();
                RestartTimer();
            }
        }
    }
}
