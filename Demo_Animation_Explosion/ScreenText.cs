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
    public class ScreenText
    {
        #region Fields

        // sprite font
        private SpriteFont _textFont;

        #endregion

        #region PROPERTIES

        // Boolean to set status through the game loop
        public bool Active { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a new screen text object
        /// </summary>
        /// <param name="contentManager">the content manager</param>
        public ScreenText(ContentManager contentManager)
        {
            // load the font
            _textFont = contentManager.Load<SpriteFont>("Text");

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
        public void Draw(SpriteBatch spriteBatch, Vector2 location, string message)
        {
            spriteBatch.DrawString(_textFont, message, new Vector2(100, 100), Color.Black);
        }


        #endregion

    }
}
