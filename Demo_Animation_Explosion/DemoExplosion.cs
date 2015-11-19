using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//using Microsoft.Xna.Framework.Content;


namespace Demo_Animation_Explosion
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class DemoExplosion : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private int _gameWindowWidth;
        private int _gameWindowHeight;

        private KeyboardState _keyboardOldState;
        private KeyboardState _keyboardNewState;

        private Vector2 _applePos;
        private Vector2 _explosionPos;
        private Vector2 _screenTextPos;

        private Apple _apple;
        private Explosion _appleExplosion;
        private ScreenText _screenText;

        public DemoExplosion()
        {
            _graphics = new GraphicsDeviceManager(this);

            // initialize game window settings
            _gameWindowWidth = 400;
            _gameWindowHeight = 400;

            _graphics.PreferredBackBufferWidth = _gameWindowWidth;
            _graphics.PreferredBackBufferHeight = _gameWindowHeight;

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
            // set the position of all objects
            _applePos.X = 200;
            _applePos.Y = 200;

            _explosionPos.X = 200;
            _explosionPos.Y = 200;

            _screenTextPos.X = 100;
            _screenTextPos.Y = 100;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // create (instantiate) objects
            _apple = new Apple(Content);
            _appleExplosion = new Explosion(Content);
            _screenText = new ScreenText(Content);

            // make apple and text visible
            _apple.Active = true;
            _screenText.Active = true;



        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // get new state of keyboard
            _keyboardNewState = Keyboard.GetState();  // get the newest state

            // handle the keyboard input

            // player chooses explosion
            if (_keyboardOldState.IsKeyUp(Keys.E) && _keyboardNewState.IsKeyDown(Keys.E))
            {
                _apple.Active = false;
                _appleExplosion.Active = true;
            }

            //player chooses to quit
            if (_keyboardOldState.IsKeyUp(Keys.Escape) && _keyboardNewState.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // set the new state of the keyboard as the old state
            _keyboardOldState = _keyboardNewState;

            // if explosion is active update frame
            if (_appleExplosion.Active) _appleExplosion.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.GreenYellow);

            _spriteBatch.Begin();

            string message = "Press the 'e' to explode the apple.\n Press the Escape key to quit.";

            if (_screenText.Active) _screenText.Draw(_spriteBatch, new Vector2(200, 200), message);

            if (_apple.Active) _apple.Draw(_spriteBatch, new Vector2(200, 200));

            if (_appleExplosion.Active) _appleExplosion.Draw(_spriteBatch, new Vector2(200, 200));

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
