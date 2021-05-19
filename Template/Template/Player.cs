﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Template
{
    class Player : BaseClass, IDamageable, IShootable
    {
        protected float speed = 3f;
        protected float rotation;
        protected float rotationSpeed = .03f;

        //Om multibullet-powerupet är aktiverat
        protected bool multiBulletActive = false;
        //Tid att vara aktiv
        protected Stopwatch multiBulletTimer = new Stopwatch();
        protected float multiBulletTime = 10000f;

        //Om skölden är aktiverad
        protected bool invincible = false;
        //Tid att vara aktiv
        protected Stopwatch invincibleTimer = new Stopwatch();
        protected float invincibleTime = 10000f;

        protected Texture2D bulletTexture;
        protected List<Bullet> bulletList = new List<Bullet>();

        protected KeyboardState kNewState;
        protected KeyboardState kOldState;

        protected KeyboardState kNewStateItem;
        protected KeyboardState kOldStateItem;

        public Player(Texture2D texture, Texture2D bulletTexture, Vector2 position, Rectangle rectangle) : base(texture, position, rectangle)
        {
            this.texture = texture;
            this.bulletTexture = bulletTexture;
            this.position = position;
            this.rectangle = rectangle;
        }

        public List<Bullet> BulletList
        {
            get { return bulletList; }
        }

        private void AddLife()
        {
            Lives.lives++;
        }

        public void AddPoint()
		{
            Points.points++;
		}

        private void ActivateMultiBullet()
        {
            multiBulletActive = true;
            multiBulletTimer.Start();
        }

        private void DeactivateMultiBullet()
        {
            multiBulletActive = false;
            multiBulletTimer.Stop();
            multiBulletTimer.Reset();   
        }

        private void ActivateShield()
		{
            invincible = true;
            invincibleTimer.Start();
		}

        private void DeactivateShield()
		{
            invincible = false;
            invincibleTimer.Stop();
            invincibleTimer.Reset();
		}

        //Skadar spelaren om man inte är odödlig
        public void Damage()
        {
            if (!invincible)
                Lives.lives--;
        }

        private void Move()
        {
            kNewState = Keyboard.GetState();

            if (kNewState.IsKeyDown(Keys.A))
                position.X -= speed;
            if (kNewState.IsKeyDown(Keys.D))
                position.X += speed;
            if (kNewState.IsKeyDown(Keys.W))
                position.Y -= speed;
            if (kNewState.IsKeyDown(Keys.S))
                position.Y += speed;
            if (kNewState.IsKeyDown(Keys.Right))
                rotation += rotationSpeed;
            if (kNewState.IsKeyDown(Keys.Left))
                rotation -= rotationSpeed;
        }

        public void Shoot()
        {
            kNewState = Keyboard.GetState();

            if (kNewState.IsKeyDown(Keys.Space) && kOldState.IsKeyUp(Keys.Space))
            {
                //Om multibullet inte är aktiverat skjuts ett skott
                if (!multiBulletActive)
                {
                    bulletList.Add(new Bullet(bulletTexture, new Vector2(position.X - 4, position.Y - 12), new Rectangle((int)position.X - 4, (int)position.Y - 12, 10, 10), rotation, 10f));
                }
                //Annars skjuts fem
                else
                {
                    bulletList.Add(new Bullet(bulletTexture, new Vector2(position.X - 4, position.Y - 12), new Rectangle((int)position.X - 4, (int)position.Y - 12, 10, 10), rotation - (float)(Math.PI / 8), 10f));
                    bulletList.Add(new Bullet(bulletTexture, new Vector2(position.X - 4, position.Y - 12), new Rectangle((int)position.X - 4, (int)position.Y - 12, 10, 10), rotation - (float)(Math.PI / 16), 10f));
                    bulletList.Add(new Bullet(bulletTexture, new Vector2(position.X - 4, position.Y - 12), new Rectangle((int)position.X - 4, (int)position.Y - 12, 10, 10), rotation, 10f));
                    bulletList.Add(new Bullet(bulletTexture, new Vector2(position.X - 4, position.Y - 12), new Rectangle((int)position.X - 4, (int)position.Y - 12, 10, 10), rotation + (float)(Math.PI / 16), 10f));
                    bulletList.Add(new Bullet(bulletTexture, new Vector2(position.X - 4, position.Y - 12), new Rectangle((int)position.X - 4, (int)position.Y - 12, 10, 10), rotation + (float)(Math.PI / 8), 10f));
                }
            }
                

            kOldState = kNewState;
        }

        private void UseItem()
        {
            kNewStateItem = Keyboard.GetState();

            if (kNewStateItem.IsKeyDown(Keys.Enter) && kOldStateItem.IsKeyUp(Keys.Enter)) 
            {
                //Om kön inte är tom
                if (ItemListClass.itemQueue.Count > 0)
                {
                    //Använder item och tar bort det från kön
                    if (ItemListClass.itemQueue.Peek() is Life)
                    {
                        AddLife();
                        ItemListClass.itemQueue.Dequeue();
                    }
                    else if (ItemListClass.itemQueue.Peek() is MultiBullet)
                    {
                        ActivateMultiBullet();
                        ItemListClass.itemQueue.Dequeue();
                    }
                    else if (ItemListClass.itemQueue.Peek() is Shield)
					{
                        ActivateShield();
                        ItemListClass.itemQueue.Dequeue();
					}
                }           
            }

            kOldStateItem = kNewStateItem;
        }

        public override void Update()
        {
            Move();
            Shoot();
            UseItem();

            //Avaktiverar multibullet/sköld efter en viss tid
            if (multiBulletTimer.ElapsedMilliseconds > multiBulletTime)
                DeactivateMultiBullet();

            if (invincibleTimer.ElapsedMilliseconds > invincibleTime)
                DeactivateShield();
            
            rectangle.Location = position.ToPoint();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //gör så att spelaren kan rotera
            spriteBatch.Draw(texture, rectangle, null, Color.White, rotation, new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.None, 0);
        }
    }
}
