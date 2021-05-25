using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Template
{
    class Life: Item
    {
        ///<summary>
        ///Konstruktor för liv
        ///</summary>
        ///<param name="texture">textur för livet</param>
        ///<param name="position">Position för livet</param>
        ///<param name="rectangle">Hitbox för livet</param>
        public Life(Texture2D texture, Vector2 position, Rectangle rectangle):base(texture, position, rectangle)
        {
            this.texture = texture;
            this.position = position;
            this.rectangle = rectangle;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
