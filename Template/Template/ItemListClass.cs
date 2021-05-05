using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Template
{
    static class ItemListClass
    {
        public static List<Item> itemList = new List<Item>();

        public static Texture2D lifeTexture;
        public static Texture2D multiBulletTexture;

        public static Queue<Item> itemQueue = new Queue<Item>();

        public static Stopwatch spawnTimer = new Stopwatch();

        public static float spawnTime = 4900;

        public static Random random = new Random();

        public static void SpawnItem()
        {
            int randomNumber = random.Next(1, 101);

            if (randomNumber > 20)
                itemList.Add(new Life(lifeTexture, new Vector2(random.Next(0, 751), -50), new Rectangle(325, -50, 30, 30)));
            else
                itemList.Add(new MultiBullet(multiBulletTexture, new Vector2(random.Next(0, 751), -50), new Rectangle(325, -50, 30, 30)));
        }

        public static void AddItem(Item item)
        {
            itemQueue.Enqueue(item);
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
