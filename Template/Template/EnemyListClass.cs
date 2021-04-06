using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Template
{
    class EnemyListClass
    {
        protected List<EnemyClass> enemyList = new List<EnemyClass>();

        protected Texture2D enemyTexture;

        protected Texture2D bulletTexture;

        protected Stopwatch spawnTimer = new Stopwatch();

        Random random = new Random();

        public EnemyListClass(Texture2D enemyTexture, Texture2D bulletTexture)
        {
            this.enemyTexture = enemyTexture;
            this.bulletTexture = bulletTexture;
        }

        public List<EnemyClass> EnemyList
        {
            get { return enemyList; }
        }

        private void SpawnEnemy()
        {
            int randomNumber = random.Next(1, 101);

            if (randomNumber <= 70)
                enemyList.Add(new Enemy1(enemyTexture, new Vector2(random.Next(0, 751), -50), new Rectangle(325, -50, 50, 50)));
            else
                enemyList.Add(new Enemy3(enemyTexture, bulletTexture, new Vector2(random.Next(0, 751), -50), new Rectangle(325, -50, 50, 50)));
        }

        public void StartTimer()
        {
            spawnTimer.Start();
        }

        private void RestartTimer()
        {
            spawnTimer.Stop();
            spawnTimer.Reset();
            spawnTimer.Start();
        }

        public void Update()
        {
            if (spawnTimer.ElapsedMilliseconds > 2000)
            {
                SpawnEnemy();
                RestartTimer();
            }
        }
    }
}
