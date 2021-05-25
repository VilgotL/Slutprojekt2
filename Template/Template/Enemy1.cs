using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Template
{
    class Enemy1 : EnemyClass
    {
        ///<summary>
        ///Konstruktor för Enemy1
        ///</summary>
        ///<param name="texture">Texture för fienden</param>
        ///<param name="position">Position för fienden</param>
        ///<param name="rectangle">Hitbox för fienden</param>
        
        public Enemy1(Texture2D texture, Vector2 position, Rectangle rectangle) :base(texture, position, rectangle)
        {
            this.texture = texture;
            this.position = position;
            this.rectangle = rectangle;

            //Hastighet och antal liv
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
