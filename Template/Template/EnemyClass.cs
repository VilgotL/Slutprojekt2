using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Template
{
    class EnemyClass : BaseClass, IDamageable
    {
        protected float ySpeed;
        protected float xSpeed;
        protected int lives;

        public EnemyClass(Texture2D texture, Vector2 position, Rectangle rectangle) : base(texture, position, rectangle)
        {
            this.texture = texture;
            this.position = position;
            this.rectangle = rectangle;
        }

        public void Damage()
        {
            lives--;

            if (lives < 1)
                Die();
        }

        public void Die()
        {
            //Tar bort
            ySpeed = 0f;
            position = new Vector2(1000, 1000);
        }

        private void Move()
        {
            position.Y += ySpeed;
            position.X += xSpeed;
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
