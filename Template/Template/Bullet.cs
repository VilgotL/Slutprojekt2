using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class Bullet : BaseClass
    {
        protected float totalSpeed;

        public Bullet(Texture2D texture, Vector2 position, Rectangle rectangle) :base(texture, position, rectangle)
        {
            this.texture = texture;
            this.position = position;
            this.rectangle = rectangle;
        }

        private void Move()
        {
            position.Y -= totalSpeed;         
        }

        public override void Update()
        {
            Move();
            rectangle.Location = position.ToPoint();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
