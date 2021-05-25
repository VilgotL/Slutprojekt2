using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Template
{
	static class Lives
	{
		//Antal liv
		public static int lives = 3;

		//Position för texten
		public static Vector2 position;

		//Textens typsnitt
		public static SpriteFont font;

		///<summary>
		///Ritar ut antalet liv
		///</summary>
		public static void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.DrawString(font, "Lives: " + lives.ToString(), position, Color.Black);
		}
	}
}
