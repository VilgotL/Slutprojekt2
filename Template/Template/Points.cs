using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;

namespace Template
{
	static class Points
	{
		public static int points = 0;

		//position för att skriva ut poäng och high score
		public static Vector2 pointsPosition;
		public static Vector2 highScorePosition;

		//Typsnitt för texten
		public static SpriteFont font;

		//Filläsare och filskrivare
		public static BinaryReader br;
		public static BinaryWriter bw;

		//Högsta poäng
		public static int highScore;

		///<summary>
		///Läser in high score
		///</summary>
		public static void ReadHighScore()
		{
			br = new BinaryReader(new FileStream("Fil.tim", FileMode.OpenOrCreate, FileAccess.Read));
			highScore = br.ReadInt32();
			br.Close();
		}

		///<summary>
		///Sparar high score
		///</summary>
		public static void WriteHighScore()
		{
			//Om antalet poäng är fler än high score sparas poängen som nytt high score
			if (points > highScore)
			{
				bw = new BinaryWriter(new FileStream("Fil.tim", FileMode.OpenOrCreate, FileAccess.Write));
				bw.Write(points);
				bw.Close();
			}

		}

		///<summary>
		///Ritar ut poäng och high score
		///</summary>
		public static void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.DrawString(font, "Points: " + points.ToString(), pointsPosition, Color.Black);
			spriteBatch.DrawString(font, "High Score: " + highScore.ToString(), highScorePosition, Color.Black);
		}
	}
}
