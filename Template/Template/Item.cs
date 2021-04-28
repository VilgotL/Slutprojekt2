using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Template
{
    class Item: BaseClass
    {
        protected float xSpeed;
        protected float ySpeed;

        public Item(Texture2D texture, Vector2 position, Rectangle rectangle):base(texture, position, rectangle)
        {
            this.texture = texture;
            this.position = position;
            this.rectangle = rectangle;
        }

        private void Move()
        {
            position.X += xSpeed;
            position.Y += ySpeed;

            if (position.X > 720 || position.X < 30)
                xSpeed = -xSpeed;
        }

        public void Remove()
        {
            ySpeed = 0f;
            xSpeed = 0f;

            position = new Vector2(1200, 800);
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
