using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Template
{
    class Item: BaseClass
    {
        //Hastighet för itemen
        protected float xSpeed = 0f;
        protected float ySpeed = 1.5f;

        ///<summary>
        ///Konstruktor för item
        ///</summary>
        ///<param name="texture">Texture för item</param>
        ///<param name="position">Position för item</param>
        ///<param name="rectangle">Hitbox för item</param>
        public Item(Texture2D texture, Vector2 position, Rectangle rectangle):base(texture, position, rectangle)
        {
            this.texture = texture;
            this.position = position;
            this.rectangle = rectangle;
        }

        ///<summary>
        ///Flyttar itemet
        ///</summary>
        private void Move() 
        {
            //hastigheten
            position.X += xSpeed;
            position.Y += ySpeed;

            //Studsar
            if (position.X > 720 || position.X < 30)
                xSpeed = -xSpeed;
        }

        ///<summary>
        ///Tar bort Item från skärmen
        ///</summary>
        public void Remove()
        {
            ySpeed = 0f;
            xSpeed = 0f;

            position = new Vector2(1200, 800);
        }

        
        public override void Update()
        {
            Move();
            //Flyttar hitboxen till rätt position
            rectangle.Location = position.ToPoint();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
