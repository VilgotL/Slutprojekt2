using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Template
{
    class Enemy1 : EnemyClass
    {
        public Enemy1(Texture2D texture, Vector2 position, Rectangle rectangle) :base(texture, position, rectangle)
        {
            this.texture = texture;
            this.position = position;
            this.rectangle = rectangle;

            ySpeed = 1.5f;
            xSpeed = 0f;
            lives = 1;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.LightGray);
        }
    }
}
