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
        public static Texture2D shieldTexture;

        //item-kö
        public static Queue<Item> itemQueue = new Queue<Item>();

        //Där första itemet i kön ritas ut
        public static Rectangle queuePosition = new Rectangle(730, 750, 40, 40);

        //Tid sedan senaste item spawn
        public static Stopwatch spawnTimer = new Stopwatch();

        //Tid det ska ta mellan item spawns
        public static float spawnTime = 8320f;

        public static Random random = new Random();

        public static void SpawnItem()
        {
            //Beräknar sannolikheten för en viss item spawn
            int randomNumber = random.Next(1, 101);

            if (randomNumber > 66)
                itemList.Add(new Life(lifeTexture, new Vector2(random.Next(0, 751), -50), new Rectangle(325, -50, 30, 30)));
            else if (randomNumber > 33)
                itemList.Add(new MultiBullet(multiBulletTexture, new Vector2(random.Next(0, 751), -50), new Rectangle(325, -50, 30, 30)));
            else
                itemList.Add(new Shield(shieldTexture, new Vector2(random.Next(0, 751), -50), new Rectangle(325, -50, 30, 30)));
        }

        //Lägger till item i kön så länge det inte finns fler än 3 items redan i listan
        public static void AddItem(Item item)
        {
            if (itemQueue.Count < 3)
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

        //Ritar ut första itemet i kön
        public static void Draw(SpriteBatch spriteBatch)
		{
            if (itemQueue.Count > 0)
			{
                if (itemQueue.Peek() is Life)
                    spriteBatch.Draw(lifeTexture, queuePosition, Color.White);
                else if (itemQueue.Peek() is MultiBullet)
                    spriteBatch.Draw(multiBulletTexture, queuePosition, Color.White);
                else if (itemQueue.Peek() is Shield)
                    spriteBatch.Draw(shieldTexture, queuePosition, Color.White);
            }          
        }
    }
}
