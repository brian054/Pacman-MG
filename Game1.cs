﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

/*
 *  to-do:
 *  Need a 2d array or some type of DS to hold the dots 
 *  so we can switch out the tiles when pacman eats dots
 * 
 *  BEFORE THAT THO: Let's get Pacman on screen and moving around w/ collision
 *  - pacman is now centered on screen
 *      - implement loop for that
 *  
 *  - Move pacman with arrow keys (have a speed factor, and set a direction based on the key pressed
 *  - Collide with walls
 */

// IDEA:
/*
 * Once you finish making the whole entire game:
 * - add some crazy thing for the tunnels where at certain points
 * a vortex portal thing opens up, go into that vortex and idk what happens gotta come up with something 
 * 
 * Hmmmmmmm could have a minigame idk something just random af
 * Maybe 3-4 small small minigames, and you could have a localized high score for your regular game, and then 
 * the individual mini games.
 */

namespace Pacman
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _pacmanSprites;

        private const int _tileSize = 8;
        private const int SCALE = 3;

        private const int mazeWidth = 28;
        private const int mazeHeight = 31;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Get the current display mode (screen resolution)
            DisplayMode displayMode = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;

            int screenWidth = displayMode.Width;
            int screenHeight = displayMode.Height;

            // Set the window size based on the users monitor size
            _graphics.PreferredBackBufferWidth = (int)(screenWidth * 0.6f);
            _graphics.PreferredBackBufferHeight = (int)(screenHeight * 0.85f);

            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // use big one texture for most of the game
            // use one texture for the menu screens 
            _pacmanSprites = Content.Load<Texture2D>("pacmanSprites"); // pro tip...never add .png here...ever lol
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,  // This disables smoothing/anti-aliasing = sharp mf pixels
                DepthStencilState.None,
                RasterizerState.CullCounterClockwise
            );

            // The Map w/ dots
            //for (int i = 0; i < mazeHeight; i++)
            //{
            //    for (int j = 0; j < mazeWidth; j++)
            //    {
            //        // Clean this up
            //        Rectangle srcRect3 = new Rectangle(j * _tileSize, i * _tileSize, _tileSize, _tileSize); // dry thooo
            //        _spriteBatch.Draw(_pacmanSprites, new Vector2(j * _tileSize * SCALE, i * _tileSize * SCALE), srcRect3, Color.White, 0f, Vector2.Zero, SCALE, SpriteEffects.None, 0f);
            //    }
            //}

            // The Map w/o dots
            for (int i = 0; i < mazeHeight; i++)
            {
                for (int j = 0; j <= mazeWidth; j++)
                {
                    Rectangle srcRect3 = new Rectangle(j * _tileSize + mazeWidth * _tileSize, i * _tileSize, _tileSize, _tileSize); // dry thooo;
                    _spriteBatch.Draw(_pacmanSprites, new Vector2(j * _tileSize * SCALE, i * _tileSize * SCALE), srcRect3, Color.White, 0f, Vector2.Zero, SCALE, SpriteEffects.None, 0f);
                }
            }

            // Draw Pacman
            //for (int i = 0; i < 2; i++)
            //{
            //    for (int j = 0; j < 2; j++)
            //    {
            //        Rectangle pacmanSrcRect = new Rectangle(i + 60 * _tileSize, j * _tileSize, _tileSize, _tileSize); // dry thooo
            //        _spriteBatch.Draw(_pacmanSprites, new Vector2(300, 300), pacmanSrcRect, Color.White, 0f, Vector2.Zero, SCALE, SpriteEffects.None, 0f);
            //    }
            //}

            // 23 * _tileSize * SCALE - 12
            // hmmmmm

            // to-do: Generalize this, remember we need offsetY = 12, I'm tired and it's Friday so I'm done w/ this for now
            Rectangle pacmanSrcRect = new Rectangle(59 * _tileSize, 0 * _tileSize, _tileSize, _tileSize); // dry thooo
            _spriteBatch.Draw(_pacmanSprites, new Vector2(316, 23 * _tileSize * SCALE - 12), pacmanSrcRect, Color.White, 0f, Vector2.Zero, SCALE, SpriteEffects.None, 0f);

            Rectangle pacmanSrcRect2 = new Rectangle(60 * _tileSize, 0 * _tileSize, _tileSize, _tileSize); // dry thooo
            _spriteBatch.Draw(_pacmanSprites, new Vector2(316 + _tileSize * SCALE, 23 * _tileSize * SCALE - 12), pacmanSrcRect2, Color.White, 0f, Vector2.Zero, SCALE, SpriteEffects.None, 0f);

            Rectangle pacmanSrcRect3 = new Rectangle(59 * _tileSize, 1 * _tileSize, _tileSize, _tileSize); // dry thooo
            _spriteBatch.Draw(_pacmanSprites, new Vector2(316, 24 * _tileSize * SCALE - 12), pacmanSrcRect3, Color.White, 0f, Vector2.Zero, SCALE, SpriteEffects.None, 0f);

            Rectangle pacmanSrcRect4 = new Rectangle(60 * _tileSize, 1 * _tileSize, _tileSize, _tileSize); // dry thooo
            _spriteBatch.Draw(_pacmanSprites, new Vector2(316 + _tileSize * SCALE, 24 * _tileSize * SCALE - 12), pacmanSrcRect4, Color.White, 0f, Vector2.Zero, SCALE, SpriteEffects.None, 0f);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
