using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Breakout
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D backgroundTex;

        private Ball ball;
        private Player player;

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
            // TODO: Add your initialization logic here

            ball = new Ball();
            player = new Player();

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


            backgroundTex = Content.Load<Texture2D>("Background\\galaxy");

            player.Texture = Content.Load<Texture2D>("Background\\player");
            ball.Texture = Content.Load<Texture2D>("Background\\ball");

            player.Position = new Vector2(ClientSize().X / 2 - player.Width / 2, ClientSize().Y - player.Height - 10);
            ball.Position = new Vector2(ClientSize().X / 2, ClientSize().Y / 2);

            ball.SpeedX = 2;
            ball.SpeedY = 2;

            player.Speed = 5;
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
            ball = CalcBall(ball);
            player = CalcPlayer(player);


            // Userinput
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Drawing
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(backgroundTex, new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height), Color.White);
            spriteBatch.Draw(player.Texture, player.Position, Color.White);
            spriteBatch.Draw(ball.Texture, ball.Position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Ball Logik / Physik
        /// </summary>
        /// <param name="_ball">Ball an dem díe Logik berechnet werden soll</param>
        /// <returns>Ball an dem die Logik berechnet wurde</returns>
        private Ball CalcBall(Ball _ball)
        {
            Vector2 nextPosition = new Vector2(_ball.Position.X + _ball.SpeedX, _ball.Position.Y + _ball.SpeedY);

            if (nextPosition.X < 0 || nextPosition.X > ClientSize().X - _ball.Width)
                _ball.SpeedX *= -1;

            if (nextPosition.Y < 0 || nextPosition.Y > player.Position.Y - _ball.Height)
                _ball.SpeedY *= -1;


            _ball.Position = new Vector2(_ball.Position.X + _ball.SpeedX, _ball.Position.Y + _ball.SpeedY);
            return _ball;
        }

        /// <summary>
        /// Player Logik / Physik
        /// </summary>
        /// <param name="_player">Player an dem die Logik berechnet werden soll</param>
        /// <returns>Player an dem die Logik berechnet wurde</returns>
        private Player CalcPlayer(Player _player)
        {
            Vector2 nextPosition = _player.Position;

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                nextPosition = new Vector2(player.Position.X - _player.Speed, player.Position.Y);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                nextPosition = new Vector2(player.Position.X + _player.Speed, player.Position.Y);
            }

            if (nextPosition.X < 0 || nextPosition.X > ClientSize().X - _player.Width)
            {
                // out of view
            }
            else
            {
                _player.Position = nextPosition;
            }

            return _player;
        }

        /// <summary>
        /// Die Client Groesse
        /// </summary>
        /// <returns>Point X=Width, Y=Height</returns>
        private Point ClientSize()
        {
            return new Point(graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height);
        }
    }
}
