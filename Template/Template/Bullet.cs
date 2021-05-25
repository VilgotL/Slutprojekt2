using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Template
{
    class Bullet : BaseClass, IDamageable
    {
        //Hastighet på x-axeln, y-axeln samt total hastighet.
        protected double xSpeed;
        protected double ySpeed;
        protected float totalSpeed;

        //vinkeln för skottet
        protected float angle;

        ///<summary>
        ///Konstruktor för bullet
        ///</summary>
        ///<param name="texture"> texturen för kulan </param>
        ///<param name="position">Positionen för kulan</param>
        ///<param name="rectangle">hitbox för kulan</param>
        ///<param name="angle">Lutning som används för att bestämma skottets vinkel</param>
        ///<param name="totalSpeed">Skottets totala hastighet, används för att beräkna korrekt x- och y-hastighet beroende på vinkeln</param>
        public Bullet(Texture2D texture, Vector2 position, Rectangle rectangle, float angle, float totalSpeed) :base(texture, position, rectangle)
        {
            this.texture = texture;
            this.position = position;
            this.rectangle = rectangle;
            this.angle = angle;
            this.totalSpeed = totalSpeed;
        }

        ///<summary>
        ///Används för att skottet ska kunna röra sig
        ///</summary>
        private void Move()
        {
            //Ändrar hastigheten på x och y beroende på vinkeln
            ySpeed = totalSpeed * Math.Sin(angle - Math.PI / 2);
            xSpeed = totalSpeed * Math.Cos(angle - Math.PI / 2);

            position.X += (float)xSpeed;
            position.Y += (float)ySpeed;

            //Flyttar hitboxen till rätt position
            rectangle.Location = position.ToPoint();
        }

        ///<summary>
        ///Gör skada på skottet (tar bort det)
        ///</summary>
        public void Damage()
        {
            //Tar bort 
            totalSpeed = 0f;
            position = new Vector2(1000, 800);
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
