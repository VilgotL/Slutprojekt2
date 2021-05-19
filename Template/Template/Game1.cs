using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player;

        enum PlayerStartPos
		{
            X = 300,
            Y = 700
		}

        //Komentar
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            //Höjd: 800
            graphics.PreferredBackBufferHeight = 800;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            player = new Player(Content.Load<Texture2D>("xwing"), Content.Load<Texture2D>("bullet4"), new Vector2((int)PlayerStartPos.X, (int)PlayerStartPos.Y), new Rectangle(300, 700, 50, 50));

            EnemyListClass.bulletTexture = Content.Load<Texture2D>("bullet4");
            EnemyListClass.enemyTexture = Content.Load<Texture2D>("xwingRotated");
            EnemyListClass.StartTimer();

            ItemListClass.lifeTexture = Content.Load<Texture2D>("heart3");
            ItemListClass.multiBulletTexture = Content.Load<Texture2D>("star2");
            ItemListClass.shieldTexture = Content.Load<Texture2D>("shield");
            ItemListClass.StartTimer();

            Points.pointsPosition = new Vector2(660, 50);
            Points.highScorePosition = new Vector2(660, 70);
            Points.font = Content.Load<SpriteFont>("Text");
            Points.ReadHighScore();

            Lives.position = new Vector2(660, 30);
            Lives.font = Content.Load<SpriteFont>("Text");

            // TODO: use this.Content to load your game content here 
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update();

            EnemyListClass.Update();
            ItemListClass.Update();

            //Tar bort fiende och skadar spelaren om en fiende kolliderar med spelaren
            foreach (EnemyClass element in EnemyListClass.enemyList)
            {
                element.Update();

                if (element.Rectangle.Intersects(player.Rectangle))
                {
                    element.Die();
                    player.Damage();

                    if (Lives.lives <= 0)
					{
                        Points.WriteHighScore();
                        Exit();
                    }                     
                }
            }

            //Lägger till item i item-kön om den kolliderar med spelaren
            foreach (Item element in ItemListClass.itemList)
            {
                element.Update();

                if (element.Rectangle.Intersects(player.Rectangle))
                {
                    element.Remove();
                    ItemListClass.AddItem(element);   
                }
            }

            //Om ett skott kolliderar med en fiende dödas fienden 
            foreach(Bullet element in player.BulletList)
            {
                element.Update();

                foreach (EnemyClass enemyElement in EnemyListClass.enemyList)
                {
                    if (element.Rectangle.Intersects(enemyElement.Rectangle))
                    {
                        element.Damage();
                        enemyElement.Damage();
                        player.AddPoint();
                        EnemyListClass.DecreaseSpawnTime();
                    }
                }         
            }

            //Fiendens skott skadar spelaren
            foreach (Bullet element in Enemy3.BulletList)
            {
                element.Update();

                if (element.Rectangle.Intersects(player.Rectangle)) 
                {
                    element.Damage();
                    player.Damage();

                    if (Lives.lives <= 0)
                    {
                        Points.WriteHighScore();
                        Exit();
                    }
                }
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here.
            spriteBatch.Begin();

            Lives.Draw(spriteBatch);
            Points.Draw(spriteBatch);
            ItemListClass.Draw(spriteBatch);

            foreach (Bullet element in player.BulletList)
            {
                element.Draw(spriteBatch);
            }

            foreach (Bullet element in Enemy3.BulletList)
            {
                element.Draw(spriteBatch);
            }

            foreach (EnemyClass element in EnemyListClass.enemyList)
            {
                element.Draw(spriteBatch);
            }

            foreach (Item element in ItemListClass.itemList)
            {
                element.Draw(spriteBatch);
            }

            player.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
