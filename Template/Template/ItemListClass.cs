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
    	//Itemlista
        public static List<Item> itemList = new List<Item>();

	    //Texturer för de olika itemsen
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

	    //Används för att generera ett slumpmässigt värde
        public static Random random = new Random();

	    ///<summary>
	    ///Används för att spawna ett item
        ///</summary>
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

        ///<summary>
	    ///Lägger till item i kön så länge det inte finns fler än 3 items redan i listan
	    ///</summary>
        public static void AddItem(Item item)
        {
            if (itemQueue.Count < 3)
                itemQueue.Enqueue(item);
        }

	    ///<summary>
	    ///Startar itemtimern
	    ///</summary>
        public static void StartTimer()
        {
            spawnTimer.Start();
        }

	    ///<summary>
	    ///Startar om itemtimern
	    ///</summary>
        public static void RestartTimer()
        {
            spawnTimer.Stop();
            spawnTimer.Reset();
            spawnTimer.Start();
        }

        /// <summary>
        /// Körs hela tiden och används för att spawna items och hålla koll på tiden
        /// </summary>
        public static void Update()
        {
            //Spawnar item efter en viss tid
            if(spawnTimer.ElapsedMilliseconds > spawnTime)
            {
                SpawnItem();
                RestartTimer();
            }
        }

        /// <summary>
        /// Ritar ut första itemet i kön
        /// </summary>
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
