using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Demo_Animation_Explosion
{
    /// <summary>
    /// An Apple object
    /// </summary>
    public class Apple
    {
        #region Fields

        // sprite image
        private Texture2D _sprite;

        // sprite location on screen
        private Rectangle _drawRectangle;

        // set sprite size
        private const int _spriteWidth = 64;
        private const int _spriteHeight = 64;

        #endregion

        #region PROPERTIES

        // Boolean to set status through the game loop
        public bool Active { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a new explosion object
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
        /// Draws the apple
        /// </summary>
        /// <param name="spriteBatch">the spritebatch</param>
        /// <param name="location">the Vector2 location of the apple on the screen</param>
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            // set the draw rectangle for the sprite on the screen
            _drawRectangle = new Rectangle(0, 0, _spriteWidth, _spriteHeight);
            _drawRectangle.X = (int)location.X;
            _drawRectangle.Y = (int)location.Y;

            spriteBatch.Draw(_sprite, _drawRectangle, Color.White);
        }


        #endregion

    }
}
