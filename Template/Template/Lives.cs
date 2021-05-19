using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Template
{
	static class Lives
	{
		public static int lives = 3;

		public static Vector2 position;

		public static SpriteFont font;

		//Ritar ut antalet liv
		public static void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.DrawString(font, "Lives: " + lives.ToString(), position, Color.Black);
		}
	}
}