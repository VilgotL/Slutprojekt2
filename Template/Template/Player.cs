using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Template
{
    class Player : BaseClass
    {
        protected float speed = 3f;
        protected float rotation;
        protected float rotationSpeed = .04f;

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

        private void Shoot()
        {
            kNewState = Keyboard.GetState();

            if (kNewState.IsKeyDown(Keys.Space) && kOldState.IsKeyUp(Keys.Space))
                bulletList.Add(new Bullet(bulletTexture, new Vector2(position.X - 4, position.Y - 12), new Rectangle((int)position.X - 4, (int)position.Y - 12, 10, 10), rotation));

            kOldState = kNewState;
        }

        public override void Update()
        {
            Move();
            Shoot();
            rectangle.Location = position.ToPoint();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, null, Color.White, rotation, new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.None, 0);
        }
    }
}
