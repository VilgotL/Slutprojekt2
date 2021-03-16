using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class Player : BaseClass
    {
        protected float speed = 3f;
        protected float rotation;
        protected float rotationSpeed = .04f;

        protected KeyboardState kNewState;
        protected KeyboardState kOldState;

        public Player(Texture2D texture, Vector2 position, Rectangle rectangle) : base(texture, position, rectangle)
        {
            this.texture = texture;
            this.position = position;
            this.rectangle = rectangle;
        }

        private void Move()
        {
            kNewState = Keyboard.GetState();

            if (kNewState.IsKeyDown(Keys.A))
                position.X -= speed;
            if (kNewState.IsKeyDown(Keys.D))
                position.X += speed;
            if (kNewState.IsKeyDown(Keys.W))
                position.Y -= speed;
            if (kNewState.IsKeyDown(Keys.S))
                position.Y += speed;
            if (kNewState.IsKeyDown(Keys.Right))
                rotation += rotationSpeed;
            if (kNewState.IsKeyDown(Keys.Left))
                rotation -= rotationSpeed;
        }

        public override void Update()
        {
            Move();
            rectangle.Location = position.ToPoint();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, null, Color.White, rotation, new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.None, 0);
        }
    }
}
