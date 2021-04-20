using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Template
{
    class Enemy2 : EnemyClass
    {
        protected float rotation = -1f;

        public Enemy2(Texture2D texture, Vector2 position, Rectangle rectangle) : base(texture, position, rectangle)
        {
            this.texture = texture;
            this.position = position;
            this.rectangle = rectangle;

            ySpeed = 1.5f;
            xSpeed = 2f;
            lives = 1;
        }

        private void Move()
        {
            if (position.X > 720 || position.X < 30)
            {
                xSpeed = -xSpeed;
                rotation = -rotation;
            }           
        }

        public override void Update()
        {
            Move();
            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, null, Color.LightBlue, rotation, new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.None, 0);
        }
    }
}