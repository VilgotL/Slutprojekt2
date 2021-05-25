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
	//Fiendelista
        public static List<EnemyClass> enemyList = new List<EnemyClass>();

	//Textur för fiendena och kulorna i Enemy3s skottlista
        public static Texture2D enemyTexture;
        public static Texture2D bulletTexture;

        //Timer för att beräkna tiden sedan den senaste enemy spawnen
        public static Stopwatch spawnTimer = new Stopwatch();

        //Hur lång tid det ska ta att spawna en fiende
        public static float spawnTime = 2000;

	//för att kunna få ett slumpmässigt värde
        public static Random random = new Random();

	///<summary>
	///Används för att spawna fiender
        private static void SpawnEnemy()
        {
            //Beräknar hur stor sannolikheten ska vara att en viss fiende ska spawna
            int randomNumber = random.Next(1, 101);

            //spawnar fiende
            if (randomNumber <= 34)
                enemyList.Add(new Enemy1(enemyTexture, new Vector2(random.Next(0, 751), -50), new Rectangle(325, -50, 50, 50)));
            else if (randomNumber <= 67)
                enemyList.Add(new Enemy2(enemyTexture, new Vector2(random.Next(30, 723), -50), new Rectangle(325, -50, 50, 50)));
            else
                enemyList.Add(new Enemy3(enemyTexture, bulletTexture, new Vector2(random.Next(0, 751), -50), new Rectangle(325, -50, 50, 50)));

        }

	///<summary>
        ///Startar fiendetimern
	///</summary>
        public static void StartTimer()
        {
            spawnTimer.Start();
        }

	///<summary>
	///Startar om fiendetimern
	///</summary>
        private static void RestartTimer()
        {
            spawnTimer.Stop();
            spawnTimer.Reset();
            spawnTimer.Start();
        }

        ///<summary>
	///Minskar tiden som går mellan två fiendespawns
	///</summary>
        public static void DecreaseSpawnTime()
		{
            spawnTime = spawnTime * 0.98f;
		}

        public static void Update()
        {
	    //Spawnar fiende efter att tillräckligt lång tid har gått
            if (spawnTimer.ElapsedMilliseconds > spawnTime)
            {
                SpawnEnemy();
                RestartTimer();
            }
        }
    }
}
