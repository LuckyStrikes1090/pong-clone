using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace pong_clone
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D playerPaddle;
        Texture2D compPaddle;
        Texture2D pong;

        Vector2 playerPosition;
        Vector2 compPosition;
        Vector2 pongPosition;
        Vector2 velocity;

        BoxCollider collide = new BoxCollider();


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            Random rand = new Random();
            int randomNumber = rand.Next(1, 8);

            playerPosition = new Vector2(50, 200);
            compPosition = new Vector2(750, 200);
            pongPosition = new Vector2(400, 180);
            velocity = new Vector2(randomNumber, randomNumber);

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

            playerPaddle = Content.Load<Texture2D>("playerPaddle");
            compPaddle = Content.Load<Texture2D>("enemyPaddle");
            pong = Content.Load<Texture2D>("pong");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Escape))
                Exit();

            if (state.IsKeyDown(Keys.Up))
                playerPosition.Y -= 7;
            if (state.IsKeyDown(Keys.Down))
                playerPosition.Y += 7;
            if (state.IsKeyDown(Keys.Right))
                playerPosition.X += 7;
            if (state.IsKeyDown(Keys.Left))
                playerPosition.X -= 7;

            // if (collide.CheckBounds(playerPaddle, playerPosition, pong, pongPosition))
            //    pong.Dispose();
            pongPosition = collide.BoundaryCollision(playerPaddle, playerPosition, pong, pongPosition);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            spriteBatch.Draw(playerPaddle, playerPosition);
            spriteBatch.Draw(compPaddle, compPosition);
            spriteBatch.Draw(pong, pongPosition);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}