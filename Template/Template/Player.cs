using Microsoft.Xna.Framework;
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

        protected int lives = 3;

        protected bool multiBulletActive = false;
        protected Stopwatch multiBulletTimer = new Stopwatch();
        protected float multiBulletTime = 10000f;

        protected Texture2D bulletTexture;
        protected List<Bullet> bulletList = new List<Bullet>();

        protected KeyboardState kNewState;
        protected KeyboardState kOldState;

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

        public int Lives
        {
            get { return lives; }
        }

        public void AddLife()
        {
            lives++;
        }

        public void ActivateMultiBullet()
        {
            multiBulletActive = true;
            multiBulletTimer.Start();
        }

        private void DeactivateMultiBullet()
        {
            multiBulletTimer.Stop();
            multiBulletTimer.Reset();
            multiBulletActive = false;
        }

        public void Damage()
        {
            lives--;
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
                if (!multiBulletActive)
                {
                    bulletList.Add(new Bullet(bulletTexture, new Vector2(position.X - 4, position.Y - 12), new Rectangle((int)position.X - 4, (int)position.Y - 12, 10, 10), rotation, 10f));
                }
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

        public override void Update()
        {
            Move();
            Shoot();

            if (multiBulletTimer.ElapsedMilliseconds > multiBulletTime)
                DeactivateMultiBullet();

            rectangle.Location = position.ToPoint();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, null, Color.White, rotation, new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.None, 0);
        }
    }
}
