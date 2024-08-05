using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pacman
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _pacmanSprites;

        private int _tileSize = 8;
        private Vector2 _tilePosition = new Vector2(100, 100);

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

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

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            // _spriteBatch.Draw(pacMenu, new Rectangle(0, 0, 800, 480), Color.White);
            Rectangle srcRect = new Rectangle(34, 0, _tileSize * 6, _tileSize * 6);
            //_spriteBatch.Draw(_pacmanSprites, _tilePosition, srcRect, Color.White);
            _spriteBatch.Draw(_pacmanSprites, _tilePosition, Color.White);


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
