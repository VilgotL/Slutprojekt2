using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class BaseClass
    {
        //Textur, position och hitbox för objektet
        protected Texture2D texture;
        protected Vector2 position;
        protected Rectangle rectangle;
        
        /// <summary>
        /// Konstruktor för BaseClass
        /// </summary>
        /// <param name="texture">Texturen för objektet</param>
        /// <param name="position">Positionen för objektet</param>
        /// <param name="rectangle">Hitbox för objektet, bestämmer även storlek</param>
        public BaseClass(Texture2D texture, Vector2 position, Rectangle rectangle)
        {
            this.texture = texture;
            this.position = position;
            this.rectangle = rectangle;
        }

        // Ger objektets position
        public Vector2 Position
        {
            get { return position; }
        }
        
        // Ger objektets hitbox
        public Rectangle Rectangle
        {
            get { return rectangle; }
        }

        /// <summary>
        ///Körs hela tiden. Kan användas för att ta in inputs och kolla om något kolliderar.
        /// </summary>
        public virtual void Update()
        {

        }

        /// <summary>
        /// Används för att rita ut saker på skärmen
        /// </summary>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
