using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Template
{
    class Bullet : BaseClass
    {
        protected double xSpeed;
        protected double ySpeed;
        protected float totalSpeed = 10f;

        protected float angle;

        public Bullet(Texture2D texture, Vector2 position, Rectangle rectangle, float angle) :base(texture, position, rectangle)
        {
            this.texture = texture;
            this.position = position;
            this.rectangle = rectangle;
            this.angle = angle;
        }

        private void Move()
        {
            ySpeed = totalSpeed * Math.Sin(angle - Math.PI / 2);
            xSpeed = totalSpeed * Math.Cos(angle - Math.PI / 2);

            position.X += (float)xSpeed;
            position.Y += (float)ySpeed;

            rectangle.Location = position.ToPoint();
        }

        public void Delete()
        {
            totalSpeed = 0f;
            position = new Vector2(1000, 800);
        }

        public override void Update()
        {
            Move();
            rectangle.Location = position.ToPoint();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
