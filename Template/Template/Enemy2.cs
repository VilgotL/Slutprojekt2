using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Template
{
    class Enemy2 : EnemyClass
    {
        //ska kunna ändra vinkel
        protected float rotation = -1f;

        ///<summary>
        ///Konstruktor för Enemy2
        ///</summary>
        ///<param name="texture">Textur för fienden</param>
        ///<param name="position">Position för fienden</param>
        ///<param name="rectangle">Hitbox för fienden</param>
        public Enemy2(Texture2D texture, Vector2 position, Rectangle rectangle) : base(texture, position, rectangle)
        {
            this.texture = texture;
            this.position = position;
            this.rectangle = rectangle;

            //Hastighet och antal liv
            ySpeed = 1.5f;
            xSpeed = 2f;
            lives = 1;
        }

        ///<summary>
        ///Flyttar spelaren
        ///</summary>
        private void Move()
        {
            //Studsa
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
            //Gör så att den kan rotera
            spriteBatch.Draw(texture, rectangle, null, Color.LightBlue, rotation, new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.None, 0);
        }
    }
}
