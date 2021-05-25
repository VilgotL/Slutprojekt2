using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Template
{
    class Enemy3 : EnemyClass, IShootable
    {
        //skottlista för Enemy3
        protected static List<Bullet> bulletList = new List<Bullet>();

        //Textur för kulorna
        protected Texture2D bulletTexture;

        //Timer för att beräkna tiden sedan senaste skottet
        protected Stopwatch shootTimer = new Stopwatch();

        ///<summary>
        ///Konstruktor för Enemy3
        ///</summary>
        ///<param name="texture">Texture för fienden</param>
        ///<param name="bulletTexture">Textur för kulorna</param>
        ///<param name="position">Position för fienden</param>
        ///<param name="rectangle">Hitbox för fienden</param>
        public Enemy3(Texture2D texture, Texture2D bulletTexture, Vector2 position, Rectangle rectangle) : base(texture, position, rectangle)
        {
            this.texture = texture;
            this.bulletTexture = bulletTexture;
            this.position = position;
            this.rectangle = rectangle;

            //Hastighet och antal liv
            ySpeed = 1.5f;
            xSpeed = 0f;
            lives = 1;

            //Startar skottimern
            shootTimer.Start();
        }

        //Ger skottlistan
        public static List<Bullet> BulletList
        {
            get { return bulletList; }
        }

        ///<summary>
        ///Startar om skottimern
        ///</summary>
        private void RestartTimer()
        {
            shootTimer.Stop();
            shootTimer.Reset();
            shootTimer.Start();
        }

        ///<summary>
        ///Gör så att fienden skjuter
        ///</summary>
        public void Shoot()
        {
            //Skjuter om det har gått 1 sekund sedan förra skottet
            if (shootTimer.ElapsedMilliseconds > 1000)
            {
                bulletList.Add(new Bullet(bulletTexture, new Vector2(position.X + 20, position.Y + 12), new Rectangle((int)position.X + 20, (int)position.Y + 12, 10, 10), (float)((3 / 2) * Math.PI), 5f));
                RestartTimer();
            }
        }

        public override void Update()
        {
            base.Update();
            Shoot();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.LightYellow);
        }
    }
}
