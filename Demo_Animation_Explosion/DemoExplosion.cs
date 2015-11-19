using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace Demo_Animation_Explosion
{
    /// <summary>
    /// MonoGame to demonstrate how to implement an animation
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

        /// <summary>
        /// game constructor initializes the window
        /// </summary>
        public DemoExplosion()
        {
            _graphics = new GraphicsDeviceManager(this);

            // initialize game window settings
            _gameWindowWidth = 400;
            _gameWindowHeight = 400;

            _graphics.PreferredBackBufferWidth = _gameWindowWidth;
            _graphics.PreferredBackBufferHeight = _gameWindowHeight;

            // game content location
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// initialize the starting locations for each game object
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
        /// load all of the game content into the Content object
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
        /// unload all of the content from the Content object
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        /// <summary>
        /// this method is call once for each game "click"
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // handle any new keyboard events
            HandleKeyboardEvents();

            // if explosion is active update frame
            if (_appleExplosion.Active) _appleExplosion.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// this method is call once for each game "click"
        /// and draws all active game objects
        /// </summary>
        /// <param name="gameTime">provides a snapshot of timing values.</param>
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

        private void HandleKeyboardEvents()
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
        }
    }
}
