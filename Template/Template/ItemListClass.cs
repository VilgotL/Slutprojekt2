using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Template
{
    class ItemListClass
    {
        public static List<Item> itemList = new List<Item>();

        public static Texture2D lifeTexture;

        public static Stopwatch spawnTimer = new Stopwatch();

        public static float spawnTime = 10000;

        public static Random random = new Random();

        public static void SpawnItem()
        {
            itemList.Add(new Life(lifeTexture, new Vector2(200, -50), new Rectangle(200, -50, 30, 30)));
        }

        public static void StartTimer()
        {
            spawnTimer.Start();
        }

        public static void RestartTimer()
        {
            spawnTimer.Stop();
            spawnTimer.Reset();
            spawnTimer.Start();
        }

        public static void Update()
        {
            if(spawnTimer.ElapsedMilliseconds > spawnTime)
            {
                SpawnItem();
                RestartTimer();
            }
        }
    }
}
