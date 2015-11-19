using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Demo_Animation_Explosion
{
    /// <summary>
    /// the Apple class
    /// </summary>
    public class Apple
    {
        #region Fields

        // sprite image
        private Texture2D _sprite;

        // sprite location on screen
        private Rectangle _drawRectangle;

        // set sprite size
        private const int _SPRITE_WIDTH = 64;
        private const int _SPRITE_HEIGHT = 64;

        #endregion

        #region PROPERTIES

        // Boolean to set status through the game loop
        public bool Active { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// constructs a new explosion object
        /// </summary>
        /// <param name="contentManager">the content manager</param>
        public Apple(ContentManager contentManager)
        {
            // load the sprite
            _sprite = contentManager.Load<Texture2D>("apple");

            // initialize objects status as not active
            Active = false;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// draw the apple
        /// </summary>
        /// <param name="spriteBatch">the spritebatch</param>
        /// <param name="location">the Vector2 location of the apple on the screen</param>
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            // set the draw rectangle for the sprite on the screen
            _drawRectangle = new Rectangle(0, 0, _SPRITE_WIDTH, _SPRITE_HEIGHT);
            _drawRectangle.X = (int)location.X;
            _drawRectangle.Y = (int)location.Y;

            spriteBatch.Draw(_sprite, _drawRectangle, Color.White);
        }

        #endregion

    }
}
