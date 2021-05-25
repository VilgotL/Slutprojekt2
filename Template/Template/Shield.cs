using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Template
{
    class Shield : Item
    {
        ///<summary>
        ///KOnstruktor för sköld
        ///</summary>
        ///<param name="texture">textur för sköld</param>
        ///<param name="position">Position för sköld</param>
        ///<param name="rectangle">Hitbox för sköld</param>
        public Shield(Texture2D texture, Vector2 position, Rectangle rectangle) : base(texture, position, rectangle)
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
